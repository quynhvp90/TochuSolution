using IMIP.Tochu.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.DataDesign
{
    public class SearchDesignViewModel
    {
        public ObservableCollection<T0000RR_Juchuu_RCS_Model> JuchuuRCSItems { get; } = new()
        {
            new() { JuchuuDenpyouNO = 684268, JuchuuYMD = new DateTime(2026,4,9),  Nouki = new DateTime(2026,4,14), NouSSNM = "Toyota Motor Corp.", NouSCD = "31011", UserHinban = "TY-2024-A", UserHinmei = "Engine Part X",  JuchuuSuu = 500,  TankaUnitCD = "pcs", NisugataCD = "Box",    Tekiyou1 = "Urgent" },
            new() { JuchuuDenpyouNO = 684269, JuchuuYMD = new DateTime(2026,4,10), Nouki = new DateTime(2026,4,15), NouSSNM = "Honda Corp.",        NouSCD = "31012", UserHinban = "HC-2024-B", UserHinmei = "Gear Box Y",    JuchuuSuu = 200,  TankaUnitCD = "pcs", NisugataCD = "Pallet", Tekiyou1 = "" },
            new() { JuchuuDenpyouNO = 684270, JuchuuYMD = new DateTime(2026,4,11), Nouki = new DateTime(2026,4,16), NouSSNM = "Suzuki Industries",  NouSCD = "31013", UserHinban = "SZ-2024-C", UserHinmei = "Brake Pad Z",   JuchuuSuu = 1000, TankaUnitCD = "pcs", NisugataCD = "Box",    Tekiyou1 = "Standard" },
            new() { JuchuuDenpyouNO = 684271, JuchuuYMD = new DateTime(2026,4,12), Nouki = new DateTime(2026,4,17), NouSSNM = "Yamaha Motor",       NouSCD = "31014", UserHinban = "YM-2024-D", UserHinmei = "Cylinder Head", JuchuuSuu = 300,  TankaUnitCD = "pcs", NisugataCD = "Pallet", Tekiyou1 = "" },
            new() { JuchuuDenpyouNO = 684272, JuchuuYMD = new DateTime(2026,4,13), Nouki = new DateTime(2026,4,18), NouSSNM = "Mitsubishi Heavy",   NouSCD = "31015", UserHinban = "MB-2024-E", UserHinmei = "Piston Ring",   JuchuuSuu = 750,  TankaUnitCD = "set", NisugataCD = "Box",    Tekiyou1 = "Rush" },
        };

        public ObservableCollection<SI_SEINOUDATA_Model> SeninouDataItems { get; } = new()
        {
            new() { JUCHUUNO = 684268, NOUSCD = "N001", NUM = 1, LOTNO = "L1001", PRINTDT = new DateTime(2026,4,9) },
            new() { JUCHUUNO = 684268, NOUSCD = "N002", NUM = 2, LOTNO = "L1002", PRINTDT = new DateTime(2026,4,9) },
            new() { JUCHUUNO = 684268, NOUSCD = "N003", NUM = 3, LOTNO = "L1003", PRINTDT = new DateTime(2026,4,9) },
            new() { JUCHUUNO = 684268, NOUSCD = "N004", NUM = 4, LOTNO = "L1004", PRINTDT = new DateTime(2026,4,9) },
            new() { JUCHUUNO = 684268, NOUSCD = "N005", NUM = 5, LOTNO = "L1005", PRINTDT = new DateTime(2026,4,9) }
        };
    }
}
