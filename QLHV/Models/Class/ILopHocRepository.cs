using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLHV.Models.Class
{
   public interface ILopHocRepository
    {
        IEnumerable<LopHoc> Gets();
        LopHoc Get(int id);
        LopHoc Create(LopHoc lopHoc);
        LopHoc Edit(LopHoc lopHoc);
        bool Delete(int id);
    }
}
