using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels.Models
{
    public class BrochureViewModel
    {
        public int BrochureId { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15, ErrorMessage = "Must be under 15 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public string TypeOfCover { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 10000, ErrorMessage = "Must be between 1 and 10000")]
        public int NumberOfPages { get; set; }
    }
}
