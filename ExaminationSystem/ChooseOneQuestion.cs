using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{
    internal class ChooseOneQuestion : Question
    {
        public string[] Choices { get; set; } = new string[4];
        public int CorrectAnswerIndex { get; set; }
        public ChooseOneQuestion(string header, int marks, QuestionLevel level, string[] choices, int correctAnswerIndex )
            : base(header, marks, level)
        {
            Choices = choices;
            CorrectAnswerIndex = correctAnswerIndex;
        }
        public override void Display()
        {
            base.Display();

            for (int i = 0; i < Choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }
        public override bool CheckAnswer(string studentAnswer)
        {
            if (int.TryParse(studentAnswer, out int answerNumber))
            {
                return answerNumber >= 1 &&
                       answerNumber <= 4 &&
                       answerNumber - 1 == CorrectAnswerIndex;
            }

            return false;
        }
    }
}
