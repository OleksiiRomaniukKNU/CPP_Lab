using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class RefAddressType
    {
        [Key]
        public int AddressTypeCode { get; set; }
        public string AddressTypeDescription { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
