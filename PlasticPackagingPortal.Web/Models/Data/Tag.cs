using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticPackagingPortal.Web.Models.Data
{
    public class Tag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Value { get; set; }

        public DateTime SystemCreatedDate { get; set; }
        public DateTime SystemUpdatedDate { get; set; }

        public virtual Item Item { get; set; } = null!;
    }
}
