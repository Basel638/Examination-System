using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    abstract class Question 
    {
        public  abstract string? Header_of_the_question { get; }
        public abstract string? Body_of_the_question { get; set; }
        
        public abstract double Mark { get; set; }

        


    }
}
