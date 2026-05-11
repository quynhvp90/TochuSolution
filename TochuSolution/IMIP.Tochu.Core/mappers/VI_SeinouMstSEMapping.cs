using IMIP.Tochu.Core.models;
using IMIP.Tochu.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.mappers
{
    public static class VI_SeinouMstSEMapping
    {
        public static VI_SeinouMstSE ToEntity(this models.VI_SeinouMstSE_Model model)
        {
            if (model == null) return null;
            return new VI_SeinouMstSE
            {
                PRODUCT = model.PRODUCT,
                NOUSCD = model.NOUSCD,
                T10A = model.T10A,
                T20A = model.T20A,
                T30A = model.T30A,
                T40A = model.T40A,
                T50A = model.T50A,
                T60A = model.T60A,
                T70A = model.T70A,
                T80A = model.T80A,
                T90A = model.T90A,
                T100A = model.T100A,
                T110A = model.T110A,
                T120A = model.T120A,
                T130A = model.T130A,
                T140A = model.T140A,
                T150A = model.T150A,
                T160A = null // SE版にはT160がないため、nullを設定
            };
        }
        public static VI_SeinouMstSE_Model ToModel(this VI_SeinouMstSE entity)
        {
            if (entity == null) return null;
            return new models.VI_SeinouMstSE_Model
            {
                PRODUCT = entity.PRODUCT,
                NOUSCD = entity.NOUSCD,
                T10A = entity.T10A,
                T20A = entity.T20A,
                T30A = entity.T30A,
                T40A = entity.T40A,
                T50A = entity.T50A,
                T60A = entity.T60A,
                T70A = entity.T70A,
                T80A = entity.T80A,
                T90A = entity.T90A,
                T100A = entity.T100A,
                T110A = entity.T110A,
                T120A = entity.T120A,
                T130A = entity.T130A,
                T140A = entity.T140A,
                T150A = entity.T150A
            };
        }
    }
}
