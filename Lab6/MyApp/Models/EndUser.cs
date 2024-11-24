using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class EndUser
    {
        public int EndUserId { get; set; }
        public string EndUserDetails { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}