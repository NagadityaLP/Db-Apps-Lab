using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _4.Mountains_Code_First
{
    public class Mountain
    {
        public Mountain()
        {
            this.Countries = new HashSet<Country>();
            this.Peaks = new HashSet<Peak>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public virtual ICollection<Peak> Peaks { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}
