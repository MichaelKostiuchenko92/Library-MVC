using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels.Models
{
    public class MagazineViewModel
    {
        public int MagazineId { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(30, ErrorMessage = "Must be under 30 characters")]
        public string Name { get; set; }

        public string AuthorName { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 2019, ErrorMessage = "Must be between 1 and 2019")]
        public int YearOfPublishing { get; set; }
    }
}
