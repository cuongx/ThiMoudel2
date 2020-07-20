using QLHV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLHV.ViewsModel
{
    public class EditStudentsViewsModel
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        public Dept GioiTinh { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int LopHocId { get; set; }
    }
}
