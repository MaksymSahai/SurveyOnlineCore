using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyOnlineCore.Data.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Surveys = new HashSet<Surveys>();
        }

        [Key]
        public Guid CustomerId { get; set; }
        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(255)]
        public string CustomerEmail { get; set; }
        [Required]
        [StringLength(255)]
        public byte[] CustomerSalt { get; set; }
        [Required]
        [StringLength(255)]
        public byte[] CustomerPassword { get; set; }
        [Required]
        public string CustomerAbilities { get; set; }

        [InverseProperty("Customer")]
        public ICollection<Surveys> Surveys { get; set; }
    }
}
