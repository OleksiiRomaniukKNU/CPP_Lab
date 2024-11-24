using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class ServiceVendor
    {
        [Key]
        public int ServiceVendorId { get; set; }
        public string ServiceVendorDetails { get; set; }
        public ICollection<Distributor> Distributors { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
