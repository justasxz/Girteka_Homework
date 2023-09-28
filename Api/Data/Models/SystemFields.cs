using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Girteka_Homework.Data.Models
{
    public class SystemFields
    {
        [Key]
        [MaxLength(32)]
        public string Key { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        //Commented out due to no users being present in the system

        //[NotMapped]
        //public User? CreatedByUser { get; set; }

        //[NotMapped]
        //public User? ModifiedByUser { get; set; }

        //[MaxLength(32)]
        //[ForeignKey("CreatedByUser")]
        //public string? CreatedBy { get; set; }

        //[MaxLength(32)]
        //[ForeignKey("ModifiedByUser")]
        //public string? ModifiedBy { get; set; }

        public bool Deleted { get; set; } = false;

        public SystemFields()
        {
            Key = Guid.NewGuid().ToString().Replace("-", string.Empty);
            Created = DateTime.Now;
        }
    }
}
