using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlackThreadWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        // format for currency
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(0.01, 99999)]
        public double Price { get; set; }
        public string Image { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public Category Category { get; set; }
    }
}
