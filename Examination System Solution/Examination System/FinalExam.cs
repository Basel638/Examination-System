using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace Examination_System
{
    internal class FinalExam : Exam
    {

        public override int TimeExam { get; set; }
        public override int NumberQuestions { get; set; }

        public double TotalGrade { get; set; }
        public int TypeOfQuestion { get; set; }

        public MCQOneChoice MCQOneChoice { get; set; }

        public TF_Question TF_Question { get; set; }


        public Answers[]? Answers { get; set; }
        public Answers[]? AnswersRight { get; set; }
        public Questions_List[]? MyQuestionList { get; set; }



        public override void ShowExam(object Exam)
        {
            FinalExam exam = (FinalExam)Exam;
            for (int i = 0; i < exam.NumberQuestions; i++)
            {
                exam.Answers[i] = new Answers();
                if (exam.MyQuestionList[i].QuestionId == 1)
                {
                    Console.WriteLine($"True | False Question    Mark({exam.MyQuestionList[i].MarkOfQuestion})\n{exam.MyQuestionList[i].QuestionText}\n1. True \t 2. False\n----------------------------------------------------");

                    int _MyAnswer;
                    while (!(int.TryParse(Console.ReadLine(), out _MyAnswer)) || (_MyAnswer != 1 && _MyAnswer != 2))
                    {
                        Console.WriteLine("Please Enter A Valid Answer As Mentioned");
                    }
                    exam.Answers[i].AnswerId = _MyAnswer;

                    exam.Answers[i].MessageOfAnswer = exam.Answers[i].AnswerId == 1 ? "True" : "False";
                }
                else
                {
                    Console.WriteLine($"Choose One Answer Question  Mark({exam.MyQuestionList[i].MarkOfQuestion})\n{exam.MyQuestionList[i].QuestionText}\n");
                    for (int x = 0; x < 4; x++)
                    {
                        Console.Write($"{x + 1}. {exam.MyQuestionList[i].Choices[x]}  ");

                    }

                    Console.WriteLine("\n----------------------------------------------------");
                    int _MyAnswer;
                    while (!(int.TryParse(Console.ReadLine(), out _MyAnswer)) || _MyAnswer > 4 || _MyAnswer <= 0)
                    {
                        if (_MyAnswer > 4 || _MyAnswer <= 0)
                            Console.WriteLine("Please Enter A Valid Range For The Number Of Choice");
                        else
                            Console.WriteLine("Please Enter A Valid Answer As Mentioned");
                    }
                    exam.Answers[i].AnswerId = _MyAnswer;

                    // To Get The Choice Name's Not Just His Number
                    exam.Answers[i].MessageOfAnswer = exam.MyQuestionList[i].Choices[exam.Answers[i].AnswerId - 1];



                }
                Console.WriteLine("==========================================================================");
            }


            double MyRealGrade = TotalGrade;
            // Test For Answer Between Answers And AnswersRight
            for (int i = 0; i < exam.NumberQuestions; i++)
                if (exam.Answers[i].AnswerId != exam.AnswersRight[i].AnswerId)
                    MyRealGrade -= exam.MyQuestionList[i].MarkOfQuestion;



            Console.Clear();

            // Show Answers
            Console.WriteLine("Your Answers");
            for (int i = 0; i < exam.NumberQuestions; i++)
            {
                Console.Write($"Q){i + 1}   {exam.MyQuestionList[i].QuestionText}:\n=> {exam.Answers[i].MessageOfAnswer} \n");
            }


            Console.WriteLine($"Your Exam Grade is {MyRealGrade} from {TotalGrade}");

        }
    }
}
