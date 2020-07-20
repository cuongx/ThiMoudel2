using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLHV.ViewsModel
{
    public class CreateLopHocViewsModels
    {
        [Required(ErrorMessage = "Not found")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
