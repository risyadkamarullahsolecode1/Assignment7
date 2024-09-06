using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public int? LibraryCardNumber { get; set; }
        public DateTime? LibraryCardExpDate { get; set; }
        [Required]
        public string? Position { get; set; }
        [Required]
        public string? Previlege { get; set; }
        public string? Note { get; set; }
        public bool UnpaidPenalty { get; set; }
        public string? AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AppUser? AppUser { get; set; }
    }
}
