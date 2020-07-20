using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLHV.Models
{
    public class Students
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Họ Và Tên")]
        public string HoTen { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        public Dept GioiTinh { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public LopHoc LopHoc { get; set; }
        public int LopHocId  { get; set; }
    }
}
