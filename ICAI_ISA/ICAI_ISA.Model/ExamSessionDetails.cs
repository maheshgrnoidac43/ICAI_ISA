using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAI_ISA.Model
{
    public class ExamSessionDetails
    {
        public int ExamSessionDetailNo { get; set; }

        public int ExamId { get; set; }

        public string SessionKey { get; set; }

        public string SessionValue { get; set; }

        public bool IsDeleted { get; set; }
    }
}
