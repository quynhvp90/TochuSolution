using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Mappers;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Services
{
    public class TANTOUService : ITANTOUService
    {
        private readonly ISI_TANTOURepository _tantouRepository;
        public TANTOUService(ISI_TANTOURepository tantouRepository)
        {
            _tantouRepository = tantouRepository;
        }
        public async Task<List<SI_TANTOU_Model>> GetTantouListAsync()
        {
            var tantouList = await _tantouRepository.GetAllAsync();
            return tantouList.Select(t => t.ToModel()).ToList();
        }
    }
}
