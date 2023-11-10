using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Content
    {
        [Key]
        public int Id { get; set; }
        public string Content_1 { get; set; }
        public string Content_2 { get; set; }
        public string Content_3 { get; set; }

    }
}
