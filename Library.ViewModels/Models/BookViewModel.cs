using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;




namespace Library.ViewModels.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15, ErrorMessage = "Must be under 15 characters")]
        public string Name { get; set; }

        public string AuthorName { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 2019, ErrorMessage = "Must be between 1 and 2019")]
        public int YearOfPublishing { get; set; }

        public List<int> PubHouses { get; set; }

        public  ICollection<PublicHouseViewModel> PublicHouses { get; set; }


    }
}
