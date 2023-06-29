using ICAI_ISA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAI_ISA.Repository.Interfaces
{
    public interface IExamCenterRepository
    {
        Task<IEnumerable<ExamCenter>> GetExamCenterList();
    }
}
