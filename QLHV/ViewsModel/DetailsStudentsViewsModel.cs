using QLHV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLHV.ViewsModel
{
    public class DetailsStudentsViewsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string AvartarPath { get; set; }
    }
}
