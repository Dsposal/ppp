using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlasticPackagingPortal.Web.Models.Data
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string? Identifier { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public string? LowCode { get; set; }

        public double? Height { get; set; }
        public DateTime? HeightDate { get; set; }

        public double? Width { get; set; }
        public DateTime? WidthDate { get; set; }

        public double? Depth { get; set; }
        public DateTime? DepthDate { get; set; }

        public double? Volume { get; set; }
        public DateTime? VolumeDate { get; set; }

        public double? Weight { get; set; }
        public DateTime? WeightDate { get; set; }
        public double? WeightTolerance { get; set; }

        public string? Function { get; set; }
        public string? Shape { get; set; }
        public string? Flexibility { get; set; }
        public string? ComponentRecyclingDisruptors { get; set; }
        public string? Colours { get; set; }
        public string? Opacity { get; set; }
        public string? Level { get; set; }
        public string? ReuseSystem { get; set; }
        public string? ManufacturedCountry { get; set; }
        public string? RecycledContent { get; set; }
        public string? RecycledContentEvidenceType { get; set; }
        public string? RecycledContentEvidenceReference { get; set; }
        public string? Recyclability { get; set; }
        public string? RecyclabilitySource { get; set; }
        public DateTime? RecyclabilityDate { get; set; }
        public bool PartOfMultipack { get; set; } = false;

        public DateTime UpdateDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }

        public DateTime SystemCreatedDate { get; set; }
        public DateTime SystemUpdatedDate { get; set; }

        public virtual List<Tag> Tags { get; set; } = new List<Tag>();

    }
}
