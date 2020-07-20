using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLHV.Models
{
    public interface IStudentsRepository
    {
        IEnumerable<Students> Gets();
        StudentsDetailsModelsViews Get(int id);
        Students Create(Students students);
        Students Edit(Students students);
        bool Delete(int id);
    }
}
