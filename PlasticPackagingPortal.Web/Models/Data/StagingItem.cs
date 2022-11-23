using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlasticPackagingPortal.Web.Models.Data
{
    public class StagingItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string? Identifier { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public string? LowCode { get; set; }

        public string? Height { get; set; }
        public string? HeightDate { get; set; }

        public string? Width { get; set; }
        public string? WidthDate { get; set; }

        public string? Depth { get; set; }
        public string? DepthDate { get; set; }

        public string? Volume { get; set; }
        public string? VolumeDate { get; set; }

        public string? Weight { get; set; }
        public string? WeightDate { get; set; }
        public string? WeightTolerance { get; set; }

        public string? Function { get; set; }
        public string? Shape { get; set; }
        public string? Flexibility { get; set; }
        public string? ComponentRecyclingDisruptors { get; set; }
        public string? Colour { get; set; }
        public string? Opacity { get; set; }
        public string? Level { get; set; }
        public string? ReuseSystem { get; set; }
        public string? ManufacturedCountry { get; set; }
        public string? RecycledContent { get; set; }
        public string? RecycledContentEvidenceType { get; set; }
        public string? RecycledContentEvidenceReference { get; set; }
        public string? Recyclability { get; set; }
        public string? RecyclabilitySource { get; set; }
        public string? RecyclabilityDate { get; set; }
        public string? PartOfMultipack { get; set; }

        public string? UpdateDate { get; set; }
        public string? ReleaseDate { get; set; }
        public string? DiscontinueDate { get; set; }

        public DateTime SystemCreatedDate { get; set; }
        public DateTime SystemUpdatedDate { get; set; }

        public virtual List<StagingTag> Tags { get; set; } = new List<StagingTag>();

    }
}
