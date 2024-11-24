using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class RefCustomerType
    {
        [Key]
        public int CustomerTypeCode { get; set; }
        public string CustomerTypeDescription { get; set; }
        public ICollection<Customer>? Customers { get; set; } = new List<Customer>();
    }
}
