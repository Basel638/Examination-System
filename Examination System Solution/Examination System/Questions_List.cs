using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Questions_List
    {
        public int QuestionId { get; set; }   // Type Of Question

        public string? QuestionText { get; set; }  // Body Of Question

        public string[]? Choices{ get; set; }  // Choices If Type is MCQ

        public double MarkOfQuestion { get; set; }

        public int LimitChooseForChoices { get; set; } // Needed In MultipleChoices {Practical Exam}
    }
}
