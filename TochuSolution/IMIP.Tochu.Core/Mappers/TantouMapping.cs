using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Mappers
{
    public static class TantouMapping
    {
        public static SI_TANTOU_Model ToModel(this SI_TANTOU entity)
        {
            return new SI_TANTOU_Model
            {
                JIGYOUSHO = entity.JIGYOUSHO,
                NUM = entity.NUM,
                TEXT1 = entity.TEXT1
            };
        }
        public static SI_TANTOU ToEntity(this SI_TANTOU_Model model)
        {
            return new SI_TANTOU
            {
                JIGYOUSHO = model.JIGYOUSHO,
                NUM = model.NUM,
                TEXT1 = model.TEXT1
            };
        }
    }
}
