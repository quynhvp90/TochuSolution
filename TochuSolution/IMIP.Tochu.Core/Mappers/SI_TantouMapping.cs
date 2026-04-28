using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Mappers
{
    public static class SI_TantouMapping
    {
        public static SI_TANTOU_Model Mapping(this SI_TANTOU entity)
        {
            return new SI_TANTOU_Model
            {
                JIGYOUSHO = entity.JIGYOUSHO,
                NUM = entity.NUM,
                TEXT1 = entity.TEXT1
            };
        }
    }
}
