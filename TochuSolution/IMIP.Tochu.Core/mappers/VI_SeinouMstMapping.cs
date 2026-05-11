using IMIP.Tochu.Core.models;
using IMIP.Tochu.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.mappers
{
    public static class VI_SeinouMstMapping
    {
        public static VI_SeinouMst_Model ToModel(this VI_SeinouMst entity)
        {
            if (entity == null) return null;
            return new VI_SeinouMst_Model
            {
                PRODUCT = entity.PRODUCT,
                NOUSCD = entity.NOUSCD,
                T10A = entity.T10A,
                T10B = entity.T10B,
                T20A = entity.T20A,
                T20B = entity.T20B,
                T30A = entity.T30A,
                T30B = entity.T30B,
                T40A = entity.T40A,
                T40B = entity.T40B,
                T50A = entity.T50A,
                T50B = entity.T50B,
                T60A = entity.T60A,
                T60B = entity.T60B,
                T70A = entity.T70A,
                T70B = entity.T70B,
                T80A = entity.T80A,
                T80B = entity.T80B,
                T90A = entity.T90A,
                T90B = entity.T90B,
                T100A = entity.T100A,
                T100B = entity.T100B,
                T110A = entity.T110A,
                T110B = entity.T110B,
                T120A = entity.T120A,
                T120B = entity.T120B,
                T130A = entity.T130A,
                T130B = entity.T130B,
                T140A = entity.T140A,
                T140B = entity.T140B,
                T150A = entity.T150A,
                T150B = entity.T150B
            };
        }
        public static VI_SeinouMst ToEntity(this VI_SeinouMst_Model model)
        {
            if (model == null) return null;
            return new VI_SeinouMst
            {
                PRODUCT = model.PRODUCT,
                NOUSCD = model.NOUSCD,
                T10A = model.T10A,
                T10B = model.T10B,
                T20A = model.T20A,
                T20B = model.T20B,
                T30A = model.T30A,
                T30B = model.T30B,
                T40A = model.T40A,
                T40B = model.T40B,
                T50A = model.T50A,
                T50B = model.T50B,
                T60A = model.T60A,
                T60B = model.T60B,
                T70A = model.T70A,
                T70B = model.T70B,
                T80A = model.T80A,
                T80B = model.T80B,
                T90A = model.T90A,
                T90B = model.T90B,
                T100A = model.T100A,
                T100B = model.T100B,
                T110A = model.T110A,
                T110B = model.T110B,
                T120A = model.T120A,
                T120B = model.T120B,
                T130A = model.T130A,
                T130B = model.T130B,
                T140A = model.T140A,
                T140B = model.T140B,
                T150A = model.T150A,
                T150B = model.T150B
            };
        }
    }
}
