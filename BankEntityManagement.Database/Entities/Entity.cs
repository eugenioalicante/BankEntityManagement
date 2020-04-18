using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankEntityManagement.Database.Entities
{
    public partial class Entity
    {
        public int Id { get; set; }
        public int IdEntityGroup { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int IdProvince { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(5)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(11)]
        public string Telephone { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Logo { get; set; }
        public bool Active { get; set; }

        [ForeignKey("IdEntityGroup")]
        [InverseProperty("Entity")]
        public virtual EntityGroup IdEntityGroupNavigation { get; set; }
        [ForeignKey("IdProvince")]
        [InverseProperty("Entity")]
        public virtual Province IdProvinceNavigation { get; set; }
    }
}
