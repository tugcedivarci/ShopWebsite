using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string PhotoUrl { get; set; }

    }
}
