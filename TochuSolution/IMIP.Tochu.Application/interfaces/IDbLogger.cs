using IMIP.Tochu.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Application.Interfaces
{
    public interface IDbLogger
    {
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Error(Exception exception, string message = null);
        void Error(string message, string source, string stackTrace = null);
    }
}
