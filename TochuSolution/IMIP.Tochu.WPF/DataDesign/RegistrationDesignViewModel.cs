using IMIP.Tochu.Core.models;
using IMIP.Tochu.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.DataDesign
{
    public class RegistrationDesignViewModel
    {
        public VI_SeinouMstSE_Model SeinouMstSE { get; } = new() {
            PRODUCT = "Engine Part X",
            NOUSCD = "N001",
            T10A = "A0",
            T20A = "A1 ～ B1",
            T30A = "A2 ～ B2",
            T40A = "A3 ～ B3",
            T50A = "A4 ～ B4",
            T60A = "A5 ～ B5",
            T70A = "A6 ～ B6",
            T80A = "A7 ～ B7",
            T90A = "A8 ～ B8",
            T100A = "A9 ～ B9",
            T110A = "A10 ～ B10",
            T120A = "A11 ～ B11",
            T130A = "A12 ～ B12",
            T140A = "A13 ～ B13",
            T150A = "A14 ～ B14",
            T160A = "A15 ～ B15"
        };
        
    }
}
