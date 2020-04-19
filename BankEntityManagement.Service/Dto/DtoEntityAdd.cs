using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankEntityManagement.Service.Dto
{
    public class DtoEntityAdd
    {
        public int IdEntityGroup { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int IdProvince { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(5)]
        public string PostalCode { get; set; }
        [Required]
        [MaxLength(11)]
        public string Telephone { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Logo { get; set; }
        public bool Active { get; set; }
    }
}
