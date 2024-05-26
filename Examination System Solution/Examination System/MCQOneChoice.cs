using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class MCQOneChoice : Question
    {
        public override string? Header_of_the_question { get { return "Choose One Answer Question"; } }

        public override string? Body_of_the_question { get; set; }
        public override double Mark { get; set; }
        public string[]? Choices { get; set; }

        public int RightChoice { get; set; }
        public MCQOneChoice()
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
            



            Console.WriteLine("The Choices of Question:\n");
            Choices = new string[4];
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Please Enter The Choice Number {i+1}: ");
                
                Choices[i] = Console.ReadLine();
            
            }
            Console.WriteLine("Please Specify The Right Choice\n");
            int _RightChoice;
            while (!(int.TryParse(Console.ReadLine(), out _RightChoice)) || _RightChoice > 4||_RightChoice<=0)
            {
                if (_RightChoice > 4||_RightChoice<=0)
                    Console.WriteLine("Please Enter A Valid Range Number Of Choices");

                else
                    Console.WriteLine("Please Enter A Valid Number");
            }
            RightChoice = _RightChoice;

        }
    }
}
