using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Mappers
{
    public static class UserMapping
    {
        public static UserModel Mapping(this User user)
        {
            var model = new UserModel();
            if (user == null) return model;
            GlobalHelper.MapMatchingProperties(user, model);
            return model;
        }
    }
}
