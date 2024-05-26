using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class MultipleChoices : Question
    {
        public int LimitChooseForChoices { get; set; }
        public override string? Header_of_the_question { get { return $"Choose {LimitChooseForChoices} Answer Question As Maximum"; } }

        public override string? Body_of_the_question { get; set; }
        public override double Mark { get; set; }
        public string[]? Choices { get; set; }

        public int[] RightChoice { get; set; }
        public MultipleChoices()
        {

            int _LimitChooseForChoices;
            while (!(int.TryParse(Console.ReadLine(), out _LimitChooseForChoices)) || _LimitChooseForChoices <= 0 || _LimitChooseForChoices >= 4)
            {
                if (_LimitChooseForChoices <= 0 || _LimitChooseForChoices >= 4)
                    Console.WriteLine("Please Enter A Valid Range Start From 1 Up To 3");
                else
                    Console.WriteLine("Please Enter A Valid Number");
            }
            LimitChooseForChoices = _LimitChooseForChoices;

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
                Console.WriteLine($"Please Enter The Choice Number {i + 1}: ");
                Choices[i] = Console.ReadLine();
            }
            Console.WriteLine("Please Specify The Right Choices\n");
            //RightChoice = int.Parse(Console.ReadLine());
            RightChoice = new int[LimitChooseForChoices];
            for (int i = 0; i < LimitChooseForChoices; i++)
            {
                Console.Write($"Choice Number {i + 1}: ");

                int _RightChoice;
                while (!(int.TryParse(Console.ReadLine(), out _RightChoice)) || _RightChoice > 4 || _RightChoice <= 0)
                {
                    if (_RightChoice > 4 || _RightChoice < 0)
                        Console.Write($"Please Enter A Valid Range Number Of Choices\nChoice Number{i+1}: ");

                    else
                        Console.Write($"Please Enter A Valid Number\nChoice Number{i+1}: ");
                }

                int flag = 0;
                for (int x = 0; x < i; x++)
                {
                    if (_RightChoice == RightChoice[x])
                    {
                        flag = 1; break;
                    }
                }

                if (flag == 1)
                {
                    Console.WriteLine("This Number You Already Choosen, Please Set Another");
                    i--;
                }

                else
                    RightChoice[i] = _RightChoice;

            }

        }

    }
}
