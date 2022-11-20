using System.ComponentModel.DataAnnotations;

namespace _4.Mountains_Code_First
{
    public class Peak
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Elevation { get; set; }
        public virtual Mountain Mountain { get; set; }
    }
}
