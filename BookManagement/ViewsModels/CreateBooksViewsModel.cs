using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.ViewsModels
{
    public class CreateBooksViewsModel
    {
   
        [Required]
        [StringLength(50)]
        public string TenSach { get; set; }
        [Required]
        [StringLength(50)]
        public string TenTacGia { get; set; }
        [Required]
        [StringLength(50)]
        public string Mota { get; set; }
        public DateTime Nsx { get; set; }
        public int SoLuong { get; set; }
        public int TheLoaiId { get; set; }
   
    }
}
