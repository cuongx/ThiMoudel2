using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class TheLoai
    {
        public int TheLoaiId { get; set; }
        [Required]
        [StringLength(70)]
        public string TheLoaiName { get; set; }
        public ICollection<Book>Books { get; set; }

    }
}
