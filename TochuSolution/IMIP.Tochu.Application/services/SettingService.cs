using IMIP.Tochu.Common.Helpers;
using IMIP.Tochu.Application.Interfaces;
using IMIP.Tochu.Application.Models;
using IMIP.Tochu.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Application.Services
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        public SettingService(IUnitOfWork unitOfWork, IProductRepository productRepository) { 
            _unitOfWork = unitOfWork;   
            _productRepository = productRepository;
        }
        public OutputAutoFillModel GenerateAutoFillData(List<InputAutoFillModel> inputs, decimal? resinContent = null, decimal? strengthX = null, decimal? strengthR = null, decimal? stickyPoint = null, decimal meshAFFN = 100)
        {
            // ここに計算ロジックを実装する
            OutputAutoFillModel output = new OutputAutoFillModel();
            output.AF_FN = meshAFFN;
            // ダミーの計算例
            inputs = inputs.OrderBy(i => i.NUM).ToList(); // NUMでソート
            var inputResinContent = inputs.Where(i => i.NUM == 10).FirstOrDefault();
            var inputStrengthX = inputs.Where(i => i.NUM == 20).FirstOrDefault();
            var inputStrengthR = inputs.Where(i => i.NUM == 30).FirstOrDefault();
            var inputStickyPoint = inputs.Where(i => i.NUM == 40).FirstOrDefault();
            if (resinContent != null)
            {
                if (!GlobalHelper.Between((double)inputResinContent.Min, (double)inputResinContent.Max, (double)resinContent))
                {
                    output.ResinContent = GlobalHelper.RandomFloat2Decimal(inputResinContent.Min, inputResinContent.Max);
                    //throw new ArgumentOutOfRangeException(nameof(resinContent), $"ResinContent must be between {inputResinContent.Min} and {inputResinContent.Max}.");
                } else output.ResinContent = resinContent.Value;
            }
            else
            {
                output.ResinContent = GlobalHelper.RandomFloat2Decimal(inputResinContent.Min, inputResinContent.Max);
            }
            // strength X
            if (strengthX != null)
            {
                if (!GlobalHelper.Between((double)inputStrengthX.Min, (double)inputStrengthX.Max, (double)strengthX))
                {
                    output.StrengthX = GlobalHelper.RandomFloat2Decimal(inputStrengthX.Min, inputStrengthX.Max);
                    //throw new ArgumentOutOfRangeException(nameof(strengthX), $"StrengthX must be between {inputStrengthX.Min} and {inputStrengthX.Max}.");
                } else output.StrengthX = strengthX.Value;
            } else
            {
                output.StrengthX = GlobalHelper.RandomFloat2Decimal(inputStrengthX.Min, inputStrengthX.Max);
            }
            // strength R
            if (strengthR != null)
            {
                if (!GlobalHelper.Between((double)inputStrengthR.Min, (double)inputStrengthR.Max, (double)strengthR))
                {
                    output.StrengthR = GlobalHelper.RandomFloat2Decimal(inputStrengthR.Min, inputStrengthR.Max);
                    //throw new ArgumentOutOfRangeException(nameof(strengthR), $"StrengthR must be between {inputStrengthR.Min} and {inputStrengthR.Max}.");
                } else output.StrengthR = strengthR.Value;
            } else
            {
                output.StrengthR = GlobalHelper.RandomFloat2Decimal(inputStrengthR.Min, inputStrengthR.Max);
            }
            // sticky point
            if (stickyPoint != null)
            {
                if (!GlobalHelper.Between((double)inputStickyPoint.Min, (double)inputStickyPoint.Max, (double)stickyPoint))
                {
                    output.StickyPoint = GlobalHelper.RandomFloat2Decimal(inputStickyPoint.Min, inputStickyPoint.Max);
                    //throw new ArgumentOutOfRangeException(nameof(stickyPoint), $"StickyPoint must be between {inputStickyPoint.Min} and {inputStickyPoint.Max}.");
                } else output.StickyPoint = stickyPoint.Value;
            } else
            {
                output.StickyPoint = GlobalHelper.RandomFloat2Decimal(inputStickyPoint.Min, inputStickyPoint.Max);
            }


            // set auto fill values for mesh properties
            // num 50 - 150までのループで、各NUMに対応する入力を取得して計算する例
            int countRepeat = 50;
            while (countRepeat >= 1)
            {
                var inputM14 = inputs.Where(i => i.NUM == 50).FirstOrDefault();
                output.m14 = GlobalHelper.RandomFloat2Decimal(inputM14.Min, inputM14.Max);
                var inputM18_5 = inputs.Where(i => i.NUM == 60).FirstOrDefault();
                output.m18_5 = GlobalHelper.RandomFloat2Decimal(inputM18_5.Min, inputM18_5.Max);
                var inputM26 = inputs.Where(i => i.NUM == 70).FirstOrDefault();
                output.m26 = GlobalHelper.RandomFloat2Decimal(inputM26.Min, inputM26.Max);
                var inputM36 = inputs.Where(i => i.NUM == 80).FirstOrDefault();
                output.m36 = GlobalHelper.RandomFloat2Decimal(inputM36.Min, inputM36.Max);
                var inputM50 = inputs.Where(i => i.NUM == 90).FirstOrDefault();
                output.m50 = GlobalHelper.RandomFloat2Decimal(inputM50.Min, inputM50.Max);
                var inputM70 = inputs.Where(i => i.NUM == 100).FirstOrDefault();
                output.m70 = GlobalHelper.RandomFloat2Decimal(inputM70.Min, inputM70.Max);
                var inputM100 = inputs.Where(i => i.NUM == 110).FirstOrDefault();
                output.m100 = GlobalHelper.RandomFloat2Decimal(inputM100.Min, inputM100.Max);
                var inputM140 = inputs.Where(i => i.NUM == 120).FirstOrDefault();
                output.m140 = GlobalHelper.RandomFloat2Decimal(inputM140.Min, inputM140.Max);
                var inputM200 = inputs.Where(i => i.NUM == 130).FirstOrDefault();
                output.m200 = GlobalHelper.RandomFloat2Decimal(inputM200.Min, inputM200.Max);
                var inputM280 = inputs.Where(i => i.NUM == 140).FirstOrDefault();
                output.m280 = GlobalHelper.RandomFloat2Decimal(inputM280.Min, inputM280.Max);
                var inputMPAN = inputs.Where(i => i.NUM == 150).FirstOrDefault();
                output.mPAN = GlobalHelper.RandomFloat2Decimal(inputMPAN.Min, inputMPAN.Max);
                var sumMeshValues = output.m14 + output.m18_5 + output.m26 + output.m36 + output.m50 + output.m70 + output.m100 + output.m140 + output.m200 + output.m280 + output.mPAN;
                var outputAFS_FN = (output.m14 * 7 + output.m18_5 * 10 + output.m26 * 20 + output.m36 * 30 + output.m70 * 50 + output.m100 * 70 + output.m140 * 100 + output.m200 * 140 + output.m280 * 200 + output.mPAN * 300) / 100;
                output.AFS_FN = outputAFS_FN;
                if (sumMeshValues == 100)
                {
                    break; // 合計が100ならループを抜ける
                }
                countRepeat--;
            }
            return output;
        }

        public OutputAutoFillModel GenerateAutoFillData(ProductMeshModel proMesh, decimal? resinContent = null, decimal? strengthX = null, decimal? strengthR = null, decimal? stickyPoint = null, decimal meshAFFN = 100)
        {
            var output = new OutputAutoFillModel();
            output.AF_FN = meshAFFN;
            output.ResinContent = resinContent ?? GlobalHelper.RandomFloat2Decimal(proMesh.ResinContextMin, proMesh.ResinContextMax);
            output.StrengthX = strengthX ?? GlobalHelper.RandomFloat2Decimal(proMesh.StrengthXMin, proMesh.StrengthXMax);
            output.StrengthR = strengthR ?? GlobalHelper.RandomFloat2Decimal(proMesh.StrengthRMin, proMesh.StrengthRMax);
            output.StickyPoint = stickyPoint ?? GlobalHelper.RandomFloat2Decimal(proMesh.StickyPointMin, proMesh.StickyPointMax);
            // set auto fill values for mesh properties
            int countRepeat = 50;
            while (countRepeat >= 1)
            {
                output.m14 = GlobalHelper.RandomFloat2Decimal(proMesh.M14Min, proMesh.M14Max);
                output.m18_5 = GlobalHelper.RandomFloat2Decimal(proMesh.M18_5Min, proMesh.M18_5Max);
                output.m26 = GlobalHelper.RandomFloat2Decimal(proMesh.M26Min, proMesh.M26Max);
                output.m36 = GlobalHelper.RandomFloat2Decimal(proMesh.M36Min, proMesh.M36Max);
                output.m50 = GlobalHelper.RandomFloat2Decimal(proMesh.M50Min, proMesh.M50Max);
                output.m70 = GlobalHelper.RandomFloat2Decimal(proMesh.M70Min, proMesh.M70Max);
                output.m100 = GlobalHelper.RandomFloat2Decimal(proMesh.M100Min, proMesh.M100Max);
                output.m140 = GlobalHelper.RandomFloat2Decimal(proMesh.M140Min, proMesh.M140Max);
                output.m200 = GlobalHelper.RandomFloat2Decimal(proMesh.M200Min, proMesh.M200Max);
                output.m280 = GlobalHelper.RandomFloat2Decimal(proMesh.M280Min, proMesh.M280Max);
                output.mPAN = GlobalHelper.RandomFloat2Decimal(proMesh.MPanMin, proMesh.MPanMax);

                var sumMeshValues = output.m14 + output.m18_5 + output.m26 + output.m36 + output.m50 + output.m70 + output.m100 + output.m140 + output.m200 + output.m280 + output.mPAN;
                output.AFS_FN = (output.m14 * 7 + output.m18_5 * 10 + output.m26 * 20 + output.m36 * 30 + output.m70 * 50 + output.m100 * 70 + output.m140 * 100 + output.m200 * 140 + output.m280 * 200 + output.mPAN * 300) / 100;
                if (sumMeshValues == 100)
                {
                    break; // 合計が100ならループを抜ける
                }
                countRepeat--;
            } 
            return output;
        }

        public ProductMeshModel GenerateMesh(List<InputAutoFillModel> inputs)
        {
            var mesh = new ProductMeshModel();
            inputs = inputs.OrderBy(i => i.NUM).ToList();

            var resinContent = inputs.Where(i => i.NUM == 10).FirstOrDefault() ?? new InputAutoFillModel();
            var strengthX = inputs.Where(i => i.NUM == 20).FirstOrDefault() ?? new InputAutoFillModel();
            var strengthR = inputs.Where(i => i.NUM == 30).FirstOrDefault() ?? new InputAutoFillModel();
            var stickyPoint = inputs.Where(i => i.NUM == 40).FirstOrDefault() ?? new InputAutoFillModel();
            var inputM14 = inputs.Where(i => i.NUM == 50).FirstOrDefault() ?? new InputAutoFillModel();
            var inputM18_5 = inputs.Where(i => i.NUM == 60).FirstOrDefault() ?? new InputAutoFillModel();
            var inputM26 = inputs.Where(i => i.NUM == 70).FirstOrDefault() ?? new InputAutoFillModel();
            var inputM36 = inputs.Where(i => i.NUM == 80).FirstOrDefault() ?? new InputAutoFillModel();
            var inputM50 = inputs.Where(i => i.NUM == 90).FirstOrDefault() ?? new InputAutoFillModel();
            var inputM70 = inputs.Where(i => i.NUM == 100).FirstOrDefault() ?? new InputAutoFillModel();
            var inputM100 = inputs.Where(i => i.NUM == 110).FirstOrDefault() ?? new InputAutoFillModel();
            var inputM140 = inputs.Where(i => i.NUM == 120).FirstOrDefault() ?? new InputAutoFillModel();
            var inputM200 = inputs.Where(i => i.NUM == 130).FirstOrDefault() ?? new InputAutoFillModel();
            var inputM280 = inputs.Where(i => i.NUM == 140).FirstOrDefault() ?? new InputAutoFillModel();
            var inputMPAN = inputs.Where(i => i.NUM == 150).FirstOrDefault() ?? new InputAutoFillModel();

            mesh.ResinContextMax = resinContent.Max;
            mesh.ResinContextMin = resinContent.Min;
            mesh.StrengthXMax = strengthX.Max;
            mesh.StrengthXMin = strengthX.Min;
            mesh.StrengthRMax = strengthR.Max;
            mesh.StrengthRMin = strengthR.Min;
            mesh.StickyPointMax = stickyPoint.Max;
            mesh.StickyPointMin = stickyPoint.Min;
            mesh.M14Max = inputM14.Max;
            mesh.M14Min = inputM14.Min;
            mesh.M18_5Max = inputM18_5.Max;
            mesh.M18_5Min = inputM18_5.Min;
            mesh.M26Max = inputM26.Max;
            mesh.M26Min = inputM26.Min;
            mesh.M36Max = inputM36.Max;
            mesh.M36Min = inputM36.Min;
            mesh.M50Max = inputM50.Max;
            mesh.M50Min = inputM50.Min;
            mesh.M70Max = inputM70.Max;
            mesh.M70Min = inputM70.Min;
            mesh.M100Max = inputM100.Max;
            mesh.M100Min = inputM100.Min;
            mesh.M140Max = inputM140.Max;
            mesh.M140Min = inputM140.Min;
            mesh.M200Max = inputM200.Max;
            mesh.M200Min = inputM200.Min;
            mesh.M280Max = inputM280.Max;   
            mesh.M280Min = inputM280.Min;
            mesh.MPanMax = inputMPAN.Max;
            mesh.MPanMin = inputMPAN.Min;

            return mesh;
        }

        public async Task<List<InputAutoFillModel>> GetInputAutoFillSettingsAsync()
        {
            var objectInput = await _productRepository.GetInputLogic("35-713");
            List<InputAutoFillModel> inputs = new List<InputAutoFillModel>();
            foreach (var item in objectInput)
            {
                inputs.Add(new InputAutoFillModel()
                {
                    ENUM = item.Enum.Value,
                    Max = item.Max.Value,
                    Min = item.Min.Value,
                    NM = item.Nm,
                    NUM = item.Num, 
                    PRODUCT = item.Product,
                });
            }

            return inputs;
        }


    }
}
