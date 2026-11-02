using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{

    internal class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }
        public TrueFalseQuestion(string header, int marks, QuestionLevel level, bool correctAnswer)
            : base(header, marks, level)
        {
            CorrectAnswer = correctAnswer;
        }
        public override void Display()
        {
            base.Display();

            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }
        public override bool CheckAnswer(string studentAnswer)
        {
            if (studentAnswer == "1" && CorrectAnswer == true)
            {
                return true;
            }

            if (studentAnswer == "2" && CorrectAnswer == false)
            {
                return true;
            }

            return false;
        }
    }
}
