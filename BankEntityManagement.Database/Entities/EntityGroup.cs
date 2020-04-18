using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankEntityManagement.Database.Entities
{
    public partial class EntityGroup
    {
        public EntityGroup()
        {
            Entity = new HashSet<Entity>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(7)]
        public string Color { get; set; }
        public bool Active { get; set; }

        [InverseProperty("IdEntityGroupNavigation")]
        public virtual ICollection<Entity> Entity { get; set; }
    }
}
