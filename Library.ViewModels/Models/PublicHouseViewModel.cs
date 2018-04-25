using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels.Models
{
    public class PublicHouseViewModel
    {
        public int PublicHouseId { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15, ErrorMessage = "Must be under 15 characters")]
        public string PublicHouseName { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15, ErrorMessage = "Must be under 15 characters")]
        public string Country { get; set; }
    }
}
