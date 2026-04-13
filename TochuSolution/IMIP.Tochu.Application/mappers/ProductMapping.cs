using IMIP.Tochu.Application.Models;
using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Application.Mappers
{
    public static class ProductMapping
    {
        public static ProductModel Mapping(this Product product)
        {
            var model = new ProductModel();
            if (product == null)  return model;
            GlobalHelper.MapMatchingProperties(product, model);

            if (product.ProductMesh != null)
            {
                var mesh = new ProductMeshModel();
                GlobalHelper.MapMatchingProperties(product.ProductMesh, mesh);
                model.ProductMesh = mesh;
            }
            return model;
        }
        public static void UpdateMapping(this Product productEntity, ProductModel productModel)
        {
            productEntity.ProductId = productModel.ProductId;
            productEntity.OrderNumber = productModel.OrderNumber;
            productEntity.OrderDate = productModel.OrderDate;
            productEntity.DeliveryDate = productModel.DeliveryDate;
            productEntity.CustomerName = productModel.CustomerName;
            productEntity.PartNumber = productModel.PartNumber;
            productEntity.ProductName = productModel.ProductName;
            productEntity.OrderQuantity = productModel.OrderQuantity;
            productEntity.Unit = productModel.Unit;
            productEntity.Comment = productModel.Comment;
            productEntity.PackagingCD = productModel.PackagingCD;
            productEntity.PackagingName = productModel.PackagingName;
            productEntity.LotNumber = productModel.LotNumber;
            productEntity.PerformanceM = productModel.PerformanceM;
            productEntity.ForCustomers = productModel.ForCustomers;
            productEntity.PerformanceTable = productModel.PerformanceTable;
            productEntity.Insured = productModel.Insured;
            productEntity.Active = productModel.Active;
            productEntity.PrintingDate = productModel.PrintingDate;
            productEntity.Printing = productModel.Printing;
            productEntity.ResinContent = productModel.ResinContent;
            productEntity.TransverseRuptureStrengthX = productModel.TransverseRuptureStrengthX;
            productEntity.TransverseRuptureStrengthR = productModel.TransverseRuptureStrengthR;
            productEntity.StickyPoint = productModel.StickyPoint;
            productEntity.AFS_FN = productModel.AFS_FN;
            productEntity.AF_FN = productModel.AF_FN;
            productEntity.m14 = productModel.m14;
            productEntity.m18_5 = productModel.m18_5;
            productEntity.m26 = productModel.m26;
            productEntity.m36 = productModel.m36;
            productEntity.m50 = productModel.m50;
            productEntity.m70 = productModel.m70;
            productEntity.m100 = productModel.m100;
            productEntity.m140 = productModel.m140;
            productEntity.m200 = productModel.m200;
            productEntity.m280 = productModel.m280;
            productEntity.mPAN = productModel.mPAN;

            productEntity.UpdatedAt = DateTime.Now;
            if (productEntity.ProductMesh == null)
            {
                productEntity.ProductMesh = new ProductMesh();
            }
            GlobalHelper.MapMatchingProperties(productModel.ProductMesh, productEntity.ProductMesh);
        }

        
    }
}
