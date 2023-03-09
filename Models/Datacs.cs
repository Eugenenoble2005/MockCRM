using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MockCRM.Models
{
    public class Data
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string DistributorName { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
