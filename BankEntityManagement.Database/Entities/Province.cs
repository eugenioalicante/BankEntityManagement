using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankEntityManagement.Database.Entities
{
    public partial class Province
    {
        public Province()
        {
            Entity = new HashSet<Entity>();
        }

        public int Id { get; set; }
        public int IdCountry { get; set; }
        [Required]
        [StringLength(3)]
        public string Code { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public bool Active { get; set; }

        [ForeignKey("IdCountry")]
        [InverseProperty("Province")]
        public virtual Country IdCountryNavigation { get; set; }
        [InverseProperty("IdProvinceNavigation")]
        public virtual ICollection<Entity> Entity { get; set; }
    }
}
