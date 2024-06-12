using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class CategoryViewModel
    {
        [DisplayName("ID")]
        public int CategoryId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage ="Debe digitar un Nombre")]
        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }
    }
}
