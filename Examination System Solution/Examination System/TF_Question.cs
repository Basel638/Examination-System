using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class TF_Question : Question
    {

        public override string? Header_of_the_question
        {
            get { return "True | False Question"; }
        }
        public override string? Body_of_the_question { get; set; }
        public override double Mark { get; set; }


        public TF_Question()
        {
            Console.WriteLine($"{Header_of_the_question}\nPlease Enter The Body Of Question:");
            Body_of_the_question = Console.ReadLine();
            Console.WriteLine($"Please Enter The Marks of Question:");
            double _Mark;
            while (!(double.TryParse(Console.ReadLine(), out _Mark)) || _Mark <= 0)
            {
                Console.WriteLine("Please Enter A Valid Mark");
            }
            Mark = _Mark;


        }


    }
}
