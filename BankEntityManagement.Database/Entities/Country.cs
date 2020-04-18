using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankEntityManagement.Database.Entities
{
    public partial class Country
    {
        public Country()
        {
            Province = new HashSet<Province>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(3)]
        public string Code { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public bool Active { get; set; }

        [InverseProperty("IdCountryNavigation")]
        public virtual ICollection<Province> Province { get; set; }
    }
}
