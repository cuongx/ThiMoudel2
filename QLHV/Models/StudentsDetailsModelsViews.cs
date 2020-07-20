using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLHV.Models
{
    public class StudentsDetailsModelsViews
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }
        [Required]
        public Dept GioiTinh { get; set; }
                
        public int LopHocId { get; set; }
        [Required]
        public string LopHocName { get; set; }
        
    }
}
