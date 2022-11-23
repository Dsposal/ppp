using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlasticPackagingPortal.Web.Models.Dto
{
    public class StagingItemDto
    {
        [JsonPropertyName("id")]
        [Display(Name = "Id")]
        public Guid? Id { get; set; }

        [JsonPropertyName("identifier")]
        [Display(Name = "Identifier")]
        public string? Identifier { get; set; }

        [JsonPropertyName("name")]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("description")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [JsonPropertyName("imageUrl")]
        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("lowCode")]
        [Display(Name = "Low Code")]
        public string? LowCode { get; set; }

        [JsonPropertyName("height")]
        [Display(Name = "Height")]
        public string? Height { get; set; }
        [JsonPropertyName("heightDate")]
        [Display(Name = "Height Date")]
        public string? HeightDate { get; set; }

        [JsonPropertyName("width")]
        [Display(Name = "Width")]
        public string? Width { get; set; }
        [JsonPropertyName("widthDate")]
        [Display(Name = "Width Date")]
        public string? WidthDate { get; set; }

        [JsonPropertyName("depth")]
        [Display(Name = "Depth")]
        public string? Depth { get; set; }
        [JsonPropertyName("depthDate")]
        [Display(Name = "Depth Date")]
        public string? DepthDate { get; set; }

        [JsonPropertyName("volume")]
        [Display(Name = "Volume")]
        public string? Volume { get; set; }
        [JsonPropertyName("volumeDate")]
        [Display(Name = "Volume Date")]
        public string? VolumeDate { get; set; }

        [JsonPropertyName("weight")]
        [Display(Name = "Weight")]
        public string? Weight { get; set; }
        [JsonPropertyName("weightDate")]
        [Display(Name = "Weight Date")]
        public string? WeightDate { get; set; }
        [JsonPropertyName("weightTolerance")]
        [Display(Name = "Weight Tolerance")]
        public string? WeightTolerance { get; set; }

        [JsonPropertyName("function")]
        [Display(Name = "Function")]
        public string? Function { get; set; }
        
        [JsonPropertyName("shape")]
        [Display(Name = "Shape")]
        public string? Shape { get; set; }
        
        [JsonPropertyName("flexibility")]
        [Display(Name = "Flexibility")]
        public string? Flexibility { get; set; }
        
        [JsonPropertyName("componentRecyclingDisruptors")]
        [Display(Name = "Component Recycling Disruptors")]
        public string? ComponentRecyclingDisruptors { get; set; }
        
        [JsonPropertyName("colour")]
        [Display(Name = "Colour")]
        public string? Colour { get; set; }
        
        [JsonPropertyName("opacity")]
        [Display(Name = "Opacity")]
        public string? Opacity { get; set; }
        
        [JsonPropertyName("level")]
        [Display(Name = "Level")]
        public string? Level { get; set; }
        
        [JsonPropertyName("reuseSystem")]
        [Display(Name = "Reuse System")]
        public string? ReuseSystem { get; set; }
        
        [JsonPropertyName("manufacturedCountry")]
        [Display(Name = "Manufactured Country")]
        public string? ManufacturedCountry { get; set; }
        
        [JsonPropertyName("recycledContent")]
        [Display(Name = "Recycled Content")]
        public string? RecycledContent { get; set; }
        
        [JsonPropertyName("recycledContentEvidenceType")]
        [Display(Name = "Recycled Content Evidence Type")]
        public string? RecycledContentEvidenceType { get; set; }
        
        [JsonPropertyName("recycledContentEvidenceReference")]
        [Display(Name = "Recycled Content Evidence Reference")]
        public string? RecycledContentEvidenceReference { get; set; }
        
        [JsonPropertyName("recyclability")]
        [Display(Name = "Recyclability")]
        public string? Recyclability { get; set; }
        
        [JsonPropertyName("recyclabilitySource")]
        [Display(Name = "Recyclability Source")]
        public string? RecyclabilitySource { get; set; }
        
        [JsonPropertyName("recyclabilityDate")]
        [Display(Name = "Recyclability Date")]
        public string? RecyclabilityDate { get; set; }
        
        [JsonPropertyName("partOfMultipack")]
        [Display(Name = "Part Of Multipack")]
        public string? PartOfMultipack { get; set; }

        [JsonPropertyName("updateDate")]
        [Display(Name = "Update Date")]
        public string? UpdateDate { get; set; }
        
        [JsonPropertyName("releaseDate")]
        [Display(Name = "Release Date")]
        public string? ReleaseDate { get; set; }
        
        [JsonPropertyName("discontinueDate")]
        [Display(Name = "Discontinue Date")]
        public string? DiscontinueDate { get; set; }


    }
}
