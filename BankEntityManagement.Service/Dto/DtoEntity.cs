using System;
using System.Collections.Generic;
using System.Text;

namespace BankEntityManagement.Service.Dto
{
    public class DtoEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }        
        public DtoEntityGroup EntityGroup { get; set; }
    }
}
