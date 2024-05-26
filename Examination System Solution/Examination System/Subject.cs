using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Subject
    {

        public int SubjectId { get; set; }

        public string? SubjectName { get; set; }

        public int ExamOfSubject { get; set; }

        

        public FinalExam MyFinalExam { get; set; }
        public PracticalExam MyPracticalExam { get; set; }



        public Subject(int _SubjectId, string? _SubjectName)
        {
            SubjectId = _SubjectId;
            SubjectName = _SubjectName;
        }

        public void CreateExam()
        {
            Console.WriteLine("Please Enter The Type Of Exam You Want To Create (1 for Practical and 2 for Final): ");
            int _ExamOfSubject;
            while (!(int.TryParse(Console.ReadLine(), out _ExamOfSubject)) || (_ExamOfSubject!=1&&_ExamOfSubject!=2))
            {
                Console.WriteLine("Please Enter A Valid Number As Mentioned ");
            }

            ExamOfSubject = _ExamOfSubject;

            if (ExamOfSubject == 2)
            {
                MyFinalExam = new FinalExam();
                Console.WriteLine("Please Enter The Time Of Exam In Minutes: ");
                
                
                int _TimeExam;
                while((!int.TryParse(Console.ReadLine(),out _TimeExam))||_TimeExam<=0)
                {
                    if (_TimeExam <= 0)
                        Console.WriteLine("Please Enter A Valid Range Of Time");
                    else
                        Console.WriteLine("Please Enter A Valid Number As Mentioned");
                }
                MyFinalExam.TimeExam = _TimeExam;

                
                
                Console.WriteLine("Please Enter The Number Of Questions You Want To Create: ");
                int _NumberQuestions;
                while (!int.TryParse(Console.ReadLine(), out _NumberQuestions) || _NumberQuestions < 1)
                {
                    if (_NumberQuestions < 1)
                        Console.WriteLine("That's Not Valid Option, Please Enter A Valid Number");
                    
                }
                MyFinalExam.NumberQuestions = _NumberQuestions;



                Console.Clear();

                MyFinalExam.Answers = new Answers[MyFinalExam.NumberQuestions];

                MyFinalExam.AnswersRight = new Answers[MyFinalExam.NumberQuestions];

                MyFinalExam.MyQuestionList = new Questions_List[MyFinalExam.NumberQuestions];


                for (int i = 0; i < MyFinalExam.NumberQuestions; i++)
                {
                    MyFinalExam.MyQuestionList[i] = new Questions_List();
                    MyFinalExam.AnswersRight[i] = new Answers();



                    Console.WriteLine($"Please Choose The Type of Question Number ({i + 1}) (1 for True OR False || 2 for MCQ): ");
                    int _TypeOfQuestion;
                    while (!int.TryParse(Console.ReadLine(),out _TypeOfQuestion)||(_TypeOfQuestion!=1&&_TypeOfQuestion!=2))
                    {
                        Console.WriteLine("Please Enter A Valid Number As Mentioned");
                    }
                    MyFinalExam.TypeOfQuestion = _TypeOfQuestion;


                    Console.Clear();
                    if (MyFinalExam.TypeOfQuestion == 1)
                    {
                        MyFinalExam.TF_Question = new TF_Question();
                        MyFinalExam.MyQuestionList[i].QuestionId = MyFinalExam.TypeOfQuestion;
                        MyFinalExam.MyQuestionList[i].QuestionText = MyFinalExam.TF_Question.Body_of_the_question;
                        MyFinalExam.TotalGrade += MyFinalExam.TF_Question.Mark;
                        MyFinalExam.MyQuestionList[i].MarkOfQuestion = MyFinalExam.TF_Question.Mark;


                        Console.WriteLine("Please Enter The Right Answer of Question (1 for True and 2 for False)");
                        int _Answer;
                        while (!int.TryParse(Console.ReadLine(), out _Answer) || (_Answer != 1 && _Answer != 2))
                        {
                            Console.WriteLine("Please Enter A Valid Number As Mentioned");
                        }
                        MyFinalExam.AnswersRight[i].AnswerId = _Answer;


                    }

                    else
                    {
                        MyFinalExam.MCQOneChoice = new MCQOneChoice();
                        MyFinalExam.MyQuestionList[i].QuestionId = MyFinalExam.TypeOfQuestion;
                        MyFinalExam.MyQuestionList[i].QuestionText = MyFinalExam.MCQOneChoice.Body_of_the_question;
                        MyFinalExam.TotalGrade += MyFinalExam.MCQOneChoice.Mark;
                        MyFinalExam.MyQuestionList[i].MarkOfQuestion = MyFinalExam.MCQOneChoice.Mark;

                        MyFinalExam.MyQuestionList[i].Choices = new string[4];
                        for (int x = 0; x < 4; x++)
                        {
                            MyFinalExam.MyQuestionList[i].Choices[x] = MyFinalExam.MCQOneChoice.Choices[x];
                        }

                        MyFinalExam.AnswersRight[i].AnswerId = MyFinalExam.MCQOneChoice.RightChoice;



                    }
                    Console.Clear();
                }




            }
            else
            {

                MyPracticalExam = new PracticalExam();
               
                
                Console.WriteLine("Please Enter The Time Of Exam In Minutes: ");
                int _TimeExam;
                while ((!int.TryParse(Console.ReadLine(), out _TimeExam)) || _TimeExam <= 0)
                {
                    if (_TimeExam <= 0)
                        Console.WriteLine("Please Enter A Valid Range Of Time");
                    else
                        Console.WriteLine("Please Enter A Valid Number As Mentioned");
                }
                MyPracticalExam.TimeExam = _TimeExam;



                
                Console.WriteLine("Please Enter The Number Of Questions You Want To Create: ");
                int _NumberQuestions;
                while (!(int.TryParse(Console.ReadLine(), out _NumberQuestions))||_NumberQuestions<1)
                {
                    if(_NumberQuestions<1)
                        Console.WriteLine("That's Not Valid Option, Please Enter A Valid Number");
                    
                }
                MyPracticalExam.NumberQuestions = _NumberQuestions;
                

                Console.Clear();

                MyPracticalExam.MultipleAnswers = new MultipleAnswers[MyPracticalExam.NumberQuestions];

                MyPracticalExam.MultipleAnswersRight = new MultipleAnswers[MyPracticalExam.NumberQuestions];

                MyPracticalExam.MyQuestionList = new Questions_List[MyPracticalExam.NumberQuestions];

               

                for (int i = 0; i < MyPracticalExam.NumberQuestions; i++)
                {
                    MyPracticalExam.MyQuestionList[i] = new Questions_List();
                    MyPracticalExam.MultipleAnswersRight[i] = new MultipleAnswers();
                    Console.Write($"Please Enter The Number Of Selection Choices For Question Number {i+1} : ");
                    MyPracticalExam.MultipleChoices = new MultipleChoices();



                    MyPracticalExam.MyQuestionList[i].QuestionText = MyPracticalExam.MultipleChoices.Body_of_the_question;
                    MyPracticalExam.TotalGrade += MyPracticalExam.MultipleChoices.Mark;
                    MyPracticalExam.MyQuestionList[i].MarkOfQuestion = MyPracticalExam.MultipleChoices.Mark;
                    MyPracticalExam.MyQuestionList[i].LimitChooseForChoices = MyPracticalExam.MultipleChoices.LimitChooseForChoices;

                    MyPracticalExam.MyQuestionList[i].Choices = new string[4];
                    //MyPracticalExam.MultipleChoices.Choices = new string[4];
                    
                    for (int x = 0; x < 4; x++)
                    {
                        

                        MyPracticalExam.MyQuestionList[i].Choices[x] = MyPracticalExam.MultipleChoices.Choices[x];
                    }

                    MyPracticalExam.MultipleAnswersRight[i].AnswerId = new int[MyPracticalExam.MultipleChoices.LimitChooseForChoices];//??
                    for (int x = 0; x < MyPracticalExam.MultipleChoices.LimitChooseForChoices; x++)
                    {

                        MyPracticalExam.MultipleAnswersRight[i].AnswerId[x] = MyPracticalExam.MultipleChoices.RightChoice[x];
                    }



                    Console.Clear();
                }


            }


            Console.WriteLine("Do You Want To Start The Exam (y | n): ");
            char c;
            while(!(char.TryParse(Console.ReadLine(),out c))|| (c!='y'&&c!='n'))
            {
                Console.WriteLine("Please Enter A Valid Input As Mentioned");
            }

            if (c == 'y')
            {
                Console.Clear();
                Stopwatch Sw = new Stopwatch();
                Sw.Start();

                if (ExamOfSubject == 2)
                {
                    FinalExam exam = MyFinalExam;
                    MyFinalExam.ShowExam(exam);
                }
                else
                {
                    PracticalExam exam = MyPracticalExam;
                    MyPracticalExam.ShowExam(exam);
                }

                Console.WriteLine($"The Elapsed Time = {Sw.Elapsed}");
            }
        }





    }
}
