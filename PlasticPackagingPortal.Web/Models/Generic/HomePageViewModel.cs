using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticPackagingPortal.Web.Models.Generic
{
    public class HomePageViewModel
    {
        public enum ItemFilterType
        {
            Validated = 1,
            Staging = 2
        }

        public ItemFilterType Filter { get; set; } = ItemFilterType.Validated;

    }
}
