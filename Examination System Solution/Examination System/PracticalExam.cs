using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class PracticalExam : Exam
    {
        public override int TimeExam { get; set; }
        public override int NumberQuestions { get; set; }
        public double TotalGrade { get; set; }
        public int TypeOfQuestion { get; set; }

        public MultipleChoices MultipleChoices { get; set; }

        public Questions_List[]? MyQuestionList { get; set; }
        public MultipleAnswers[]? MultipleAnswers { get; set; }
        public MultipleAnswers[]? MultipleAnswersRight { get; set; }

        public override void ShowExam(object Exam)
        {
            PracticalExam exam = (PracticalExam)Exam;
            for (int i = 0; i < exam.NumberQuestions; i++)
            {
                exam.MultipleAnswers[i] = new MultipleAnswers();

                Console.WriteLine($"Choose {exam.MyQuestionList[i].LimitChooseForChoices} Answer Question  Mark({exam.MyQuestionList[i].MarkOfQuestion})\n{exam.MyQuestionList[i].QuestionText}\n");
                for (int x = 0; x < 4; x++)
                {
                    Console.Write($"{x + 1}. {exam.MyQuestionList[i].Choices[x]}   ");

                }

                Console.WriteLine("\n----------------------------------------------------");

                exam.MultipleAnswers[i].AnswerId = new int[exam.MultipleChoices.LimitChooseForChoices];
                exam.MultipleAnswers[i].MessageOfAnswer = new string[exam.MultipleChoices.LimitChooseForChoices];
                for (int x = 0; x < exam.MyQuestionList[i].LimitChooseForChoices; x++)
                {
                    Console.Write($"{x+1}st Your Answer: ");

                    int _MyAnswer;
                    while (!(int.TryParse(Console.ReadLine(), out _MyAnswer)) || _MyAnswer > 4 || _MyAnswer <= 0)
                    {
                        if (_MyAnswer > 4 || _MyAnswer < 0)
                            Console.Write($"Please Enter A Valid Range For The Number Of Choice\n{x+1}st Your Answer: ");
                        else
                            Console.Write($"Please Enter A Valid Answer As Mentioned\n{x+1}st Your Answer: ");
                    }



                    int flag = 0;
                    for (int z = 0; z < x; z++)
                    {
                        if (_MyAnswer == exam.MultipleAnswers[i].AnswerId[z])
                        {
                            flag = 1; break;
                        }
                    }
                    if (flag == 1)
                    {
                        Console.WriteLine("This Number You Already Choosen, Please Set Another");
                        x--;
                    }
                    else
                    {
                        exam.MultipleAnswers[i].AnswerId[x] = _MyAnswer;

                        // To Get The Choice Name's Not Just His Number
                        exam.MultipleAnswers[i].MessageOfAnswer[x] = exam.MyQuestionList[i].Choices[exam.MultipleAnswers[i].AnswerId[x] - 1];
                    }
                }


            }
            Console.WriteLine("==========================================================================");


            double MyRealGrade = 0;
            // Test For Answer Between Answers And AnswersRight
            for (int i = 0; i < exam.NumberQuestions; i++)
            {
                for (int x = 0; x < exam.MyQuestionList[i].LimitChooseForChoices; x++)
                {
                    for (int z = 0; z < exam.MyQuestionList[i].LimitChooseForChoices; z++)
                    {
                        if (exam.MultipleAnswers[i].AnswerId[x] == exam.MultipleAnswersRight[i].AnswerId[z])
                        {
                            // Mark Of Question / Number of Selection For The That Question = Mark For Each One Choose
                            MyRealGrade += ((exam.MyQuestionList[i].MarkOfQuestion / exam.MyQuestionList[i].LimitChooseForChoices));
                            break;
                        }
                    }
                }
            }

            Console.Clear();

            // Show Answers
            Console.WriteLine("Your Answers");
            for (int i = 0; i < exam.NumberQuestions; i++)
            {
                Console.Write($"Q){i + 1}   {exam.MyQuestionList[i].QuestionText}:\n => ");


                for (int x = 0; x < exam.MyQuestionList[i].LimitChooseForChoices; x++)
                {
                    Console.Write($"{exam.MultipleAnswers[i].MessageOfAnswer[x]}");

                    if (x != exam.MyQuestionList[i].LimitChooseForChoices - 1)
                        Console.Write(", ");
                    else
                        Console.Write(".");
                }
                Console.WriteLine("\n--------------------------------------------------------------------------------------");
            }


            Console.WriteLine($"\nYour Exam Grade is {MyRealGrade} from {TotalGrade}");

        }


    }
}