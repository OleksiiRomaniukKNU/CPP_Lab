using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class RefServiceType
    {
        [Key]
        public int ServiceTypeCode { get; set; }
        public string ServiceTypeDescription { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
