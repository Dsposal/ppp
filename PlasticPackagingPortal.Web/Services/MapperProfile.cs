using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClosedXML.Excel;
using PlasticPackagingPortal.Web.Extensions;
using PlasticPackagingPortal.Web.Models.Data;
using PlasticPackagingPortal.Web.Models.DataTables;
using PlasticPackagingPortal.Web.Models.Dto;

namespace PlasticPackagingPortal.Web.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region StagingItem

            //Map Items worksheet fields to StagingItem
            CreateMap<IXLTableRow, StagingItemDto>()
                .ForMember(x => x.Identifier, opt => opt.MapFrom(x => x.Field("identifier").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Field("name").GetString()))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Field("description").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.LowCode, opt => opt.MapFrom(x => x.Field("lowCode").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.Height, opt => opt.MapFrom(x => x.Field("height").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.HeightDate, opt => opt.MapFrom(x => x.Field("heightDate").GetString().ParseAndFormatExcelDate("dd/MM/yyyy")))
                .ForMember(x => x.Width, opt => opt.MapFrom(x => x.Field("width").GetString()))
                .ForMember(x => x.WidthDate, opt => opt.MapFrom(x => x.Field("widthDate").GetString().ParseAndFormatExcelDate("dd/MM/yyyy")))
                .ForMember(x => x.Depth, opt => opt.MapFrom(x => x.Field("depth").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.DepthDate, opt => opt.MapFrom(x => x.Field("depthDate").GetString().ParseAndFormatExcelDate("dd/MM/yyyy")))
                .ForMember(x => x.Volume, opt => opt.MapFrom(x => x.Field("volume").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.VolumeDate, opt => opt.MapFrom(x => x.Field("volumeDate").GetString().ParseAndFormatExcelDate("dd/MM/yyyy")))
                .ForMember(x => x.Weight, opt => opt.MapFrom(x => x.Field("weight").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.WeightTolerance, opt => opt.MapFrom(x => x.Field("weightTolerance").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.WeightDate, opt => opt.MapFrom(x => x.Field("weightDate").GetString().ParseAndFormatExcelDate("dd/MM/yyyy")))
                .ForMember(x => x.Shape, opt => opt.MapFrom(x => x.Field("shape").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.Function, opt => opt.MapFrom(x => x.Field("function").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.Flexibility, opt => opt.MapFrom(x => x.Field("flexibility").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.ComponentRecyclingDisruptors, opt => opt.MapFrom(x => x.Field("componentRecyclingDisruptors").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.Colour, opt => opt.MapFrom(x => x.Field("colour").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.Opacity, opt => opt.MapFrom(x => x.Field("opacity").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.Level, opt => opt.MapFrom(x => x.Field("level").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.ReuseSystem, opt => opt.MapFrom(x => x.Field("reuseSystem").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.ManufacturedCountry, opt => opt.MapFrom(x => x.Field("manufacturedCountry").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.RecycledContent, opt => opt.MapFrom(x => x.Field("recycledContent").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.RecycledContentEvidenceType, opt => opt.MapFrom(x => x.Field("recycledContentEvidenceType").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.RecycledContentEvidenceReference, opt => opt.MapFrom(x => x.Field("recycledContentEvidenceReference").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.Recyclability, opt => opt.MapFrom(x => x.Field("recyclability").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.RecyclabilitySource, opt => opt.MapFrom(x => x.Field("recyclabilitySource").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.RecyclabilityDate, opt => opt.MapFrom(x => x.Field("recyclabilityDate").GetString().ParseAndFormatExcelDate("dd/MM/yyyy")))
                .ForMember(x => x.PartOfMultipack, opt => opt.MapFrom(x => x.Field("partOfMultipack").GetString().ToNullIfWhiteSpace()))
                .ForMember(x => x.UpdateDate, opt => opt.MapFrom(x => x.Field("updateDate").GetString().ParseAndFormatExcelDate("dd/MM/yyyy")))
                .ForMember(x => x.ReleaseDate, opt => opt.MapFrom(x => x.Field("releaseDate").GetString().ParseAndFormatExcelDate("dd/MM/yyyy")))
                .ForMember(x => x.DiscontinueDate, opt => opt.MapFrom(x => x.Field("discontinueDate").GetString().ParseAndFormatExcelDate("dd/MM/yyyy")));

            CreateMap<StagingItemDto, StagingItem>();
            CreateMap<StagingItem, StagingItemDto>();
            CreateMap<StagingItem, DtItem>();
            CreateMap<Item, DtItem>()
                .ForMember(x => x.UpdateDate, opt => opt.MapFrom(x => x.UpdateDate.ToString("dd/MM/yyyy")));
            CreateMap<StagingItem, Item>()
                .ForMember(x => x.PartOfMultipack, opt => opt.MapFrom(x => x.PartOfMultipack != null && x.PartOfMultipack.ToBooleanFromBinaryStr()))
                .ForPath(x => x.Tags, opt => opt.MapFrom(x => x.Tags));
            #endregion

            #region StagingTag

            CreateMap<IXLTableRow, StagingTagDto>()
                .ForMember(x => x.Identifier, opt => opt.MapFrom(x => x.Field("identifier").GetString()))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Field("name").GetString()))
                .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Field("value").GetString()));

            CreateMap<StagingTagDto, StagingTag>();
            CreateMap<StagingTag, Tag>();
            CreateMap<StagingTag, Tag>();

            #endregion
        }
    }
}
