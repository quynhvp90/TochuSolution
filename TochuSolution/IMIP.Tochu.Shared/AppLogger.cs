using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IMIP.Tochu.Shared
{
    public static class AppLogger
    {
        private static readonly string _logPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Logs", "app.log");

        private static readonly ConcurrentQueue<string> _logQueue
            = new ConcurrentQueue<string>();

        private static readonly System.Threading.Timer _writeTimer;
        private static readonly object _fileLock = new object();

        public static string CurrentUser { get; set; } = "System";

        // ── Static constructor ──
        static AppLogger()
        {
            _writeTimer = new System.Threading.Timer(
                callback: _ => FlushToFile(),
                state: null,
                dueTime: 1000,
                period: 1000);
        }

        // ── Public Methods ────────────────────────────────────────────────
        public static void Info(string message) => Enqueue("INFO", message);
        public static void Error(string message) => Enqueue("ERROR", message);
        public static void Warning(string message) => Enqueue("WARN", message);

        // ── Enqueue - thread safe, no block ───────────────────────────
        private static void Enqueue(string level, string message)
        {
            var line = string.Format("[{0:yyyy-MM-dd HH:mm:ss}] [{1}] [{2}] {3}",
                DateTime.Now, level, CurrentUser, message);

            _logQueue.Enqueue(line);
        }

        // ── Flush ra file for 1s each ──────────────────────────
        private static void FlushToFile()
        {
            if (_logQueue.IsEmpty) return;

            try
            {
                var logDir = Path.GetDirectoryName(_logPath);
                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);

                // Drain all queue
                var lines = new List<string>();
                while (_logQueue.TryDequeue(out var line))
                    lines.Add(line);

                if (lines.Count == 0) return;

                // write file
                lock (_fileLock)
                {
                    File.AppendAllLines(_logPath, lines);
                }

                TrimLog(1000);
            }
            catch { }
        }

        // ── Call before exit app ───────────────────
        public static void Flush()
        {
            _writeTimer?.Dispose();
            FlushToFile();
        }

        // ── Trim file maxLines ─────────────────────────────────
        private static void TrimLog(int maxLines)
        {
            try
            {
                if (!File.Exists(_logPath)) return;

                var lines = File.ReadAllLines(_logPath);
                if (lines.Length <= maxLines) return;

                var trimmed = lines.Skip(lines.Length - maxLines).ToArray();
                lock (_fileLock)
                {
                    File.WriteAllLines(_logPath, trimmed);
                }
            }
            catch { }
        }
    }
}