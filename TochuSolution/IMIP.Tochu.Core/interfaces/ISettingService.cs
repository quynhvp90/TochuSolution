using IMIP.Tochu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Interfaces
{
    public interface ISettingService
    {
        Task<List<InputAutoFillModel>> GetInputAutoFillSettingsAsync();
        
        // Generate setting logic auto fill data based on the input auto fill settings
        OutputAutoFillModel GenerateAutoFillData(List<InputAutoFillModel> inputs, decimal? resinContent = null, decimal? strengthX = null, decimal? strengthR = null, decimal? stickyPoint = null, decimal meshAFFN = 100);
        OutputAutoFillModel GenerateAutoFillData(ProductMeshModel proMesh, decimal? resinContent = null, decimal? strengthX = null, decimal? strengthR = null, decimal? stickyPoint = null, decimal meshAFFN = 100);
        ProductMeshModel GenerateMesh(List<InputAutoFillModel> inputs);
    }
}
