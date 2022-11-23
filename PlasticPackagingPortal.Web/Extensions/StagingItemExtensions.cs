using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PlasticPackagingPortal.Web.Models.Data;
using PlasticPackagingPortal.Web.Models.Dto;

namespace PlasticPackagingPortal.Web.Extensions
{
    public static class StagingItemExtensions
    {
        public static StagingItem UpdateFromDto(this StagingItem item, StagingItemDto dto)
        {
            item.Identifier = dto.Identifier;
            item.Name = dto.Name;
            item.Description = dto.Description;
            item.ImageUrl = dto.ImageUrl;
            item.LowCode = dto.LowCode;
            item.Height = dto.Height;
            item.HeightDate = dto.HeightDate;
            item.Width = dto.Width;
            item.WidthDate = dto.WidthDate;
            item.Depth = dto.Depth;
            item.DepthDate = dto.DepthDate;
            item.Volume = dto.Volume;
            item.VolumeDate = dto.VolumeDate;
            item.Weight = dto.Weight;
            item.WeightDate = dto.WeightDate;
            item.WeightTolerance = dto.WeightTolerance;
            item.Function = dto.Function;
            item.Shape = dto.Shape;
            item.Flexibility = dto.Flexibility;
            item.ComponentRecyclingDisruptors = dto.ComponentRecyclingDisruptors;
            item.Colour = dto.Colour;
            item.Opacity = dto.Opacity;
            item.Level = dto.Level;
            item.ReuseSystem = dto.ReuseSystem;
            item.ManufacturedCountry = dto.ManufacturedCountry;
            item.RecycledContent = dto.RecycledContent;
            item.RecycledContentEvidenceType = dto.RecycledContentEvidenceType;
            item.RecycledContentEvidenceReference = dto.RecycledContentEvidenceReference;
            item.Recyclability = dto.Recyclability;
            item.RecyclabilitySource = dto.RecyclabilitySource;
            item.RecyclabilityDate = dto.RecyclabilityDate;
            item.PartOfMultipack = dto.PartOfMultipack;
            item.UpdateDate = dto.UpdateDate;
            item.ReleaseDate = dto.ReleaseDate;
            item.DiscontinueDate = dto.DiscontinueDate;
            item.SystemUpdatedDate = DateTime.Now;
            
            return item;
        }
    }
}
