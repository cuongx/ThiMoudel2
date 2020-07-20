using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLHV.Models
{
    public class LopHoc
    {
        [Required]
        public int LopHocId { get; set; }
        [Required]
      [StringLength(maximumLength:2,MinimumLength =60)]
         
        public string LopHocName { get; set; }
        public ICollection<Students>Students { get; set; }
    }
}
