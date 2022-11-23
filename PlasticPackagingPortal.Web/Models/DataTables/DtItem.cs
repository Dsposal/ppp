using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlasticPackagingPortal.Web.Models.DataTables
{
    public class DtItem
    {
        [JsonPropertyName("DT_RowId")]
        public string DtRowId => Id.ToString();

        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("lowCode")]
        public string? LowCode { get; set; }

        [JsonPropertyName("updateDate")]
        public string? UpdateDate { get; set; }
        
        [JsonPropertyName("errors")]
        public bool Errors { get; set; }
    }
}
