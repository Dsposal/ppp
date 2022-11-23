using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClosedXML.Excel;
using PlasticPackagingPortal.Web.Models.Data;
using PlasticPackagingPortal.Web.Models.DataTables;
using PlasticPackagingPortal.Web.Models.Dto;

namespace PlasticPackagingPortal.Web.Extensions
{
    public static class MapperExtensions
    {
        public static StagingItemDto ToStagingItemDto(this IXLTableRow row, IMapper mapper)
        {
            return mapper.Map<StagingItemDto>(row);
        }

        public static StagingItem ToStagingItem(this IXLTableRow row, IMapper mapper)
        {
            return mapper.Map<StagingItem>(row.ToStagingItemDto(mapper));
        }

        public static StagingTagDto ToStatingTagDto(this IXLTableRow row, IMapper mapper)
        {
            return mapper.Map<StagingTagDto>(row);
        }

        public static StagingTag ToStagingTag(this StagingTagDto dto, IMapper mapper)
        {
            return mapper.Map<StagingTag>(dto);
        }

        public static StagingTag ToStagingTag(this IXLTableRow row, IMapper mapper)
        {
            return mapper.Map<StagingTag>(row.ToStatingTagDto(mapper));
        }

        public static DtItem ToDtItem(this Item item, IMapper mapper)
        {
            return mapper.Map<DtItem>(item);
        }

        public static StagingItemDto ToStagingItemDto(this StagingItem item, IMapper mapper)
        {
            return mapper.Map<StagingItemDto>(item);
        }

        public static Item ToItem(this StagingItem item, IMapper mapper)
        {
            return mapper.Map<Item>(item);
        }

        public static DtItem ToDtItem(this StagingItem item, IMapper mapper)
        {
            var dtItem = mapper.Map<DtItem>(item);
 
            try
            {
                mapper.Map<Item>(item);
            }
            catch (Exception e)
            {
                dtItem.Errors = true;
            }

            return dtItem;
        }
    }
}
