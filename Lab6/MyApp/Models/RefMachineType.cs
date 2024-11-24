using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class RefMachineType
    {
        [Key]
        public int MachineType { get; set; }
        public string MachineTypeDescription { get; set; }
        public ICollection<CustomerMachine> CustomerMachines { get; set; }
    }
}
