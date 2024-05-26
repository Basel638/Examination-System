using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Exam
    {
        

        public abstract int TimeExam { get; set; }
        public abstract int NumberQuestions { get; set; }
        
        public abstract void ShowExam(object Exam);

    }
}
