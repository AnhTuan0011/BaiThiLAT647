using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAITHILAT0647.Models
{
    [Table("LATCau3")]
    public class LATCau3
    {
        [Key]
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }

    }
}