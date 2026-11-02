using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{
    internal class MultipleChoiceQuestion : Question
    {
        public string[] Choices { get; set; } = new string[4];
        public List<int> CorrectAnswerIndexes { get; set; } = new List<int>();
        public MultipleChoiceQuestion(string header, int marks, QuestionLevel level, string[] choices, List<int> correctAnswerIndexes)
           : base(header, marks, level)
        {
            Choices = choices;
            CorrectAnswerIndexes=correctAnswerIndexes;
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
            string[] parts = studentAnswer.Split(',');

            List<int> studentIndexes = new List<int>();

            foreach (string part in parts)
            {
                if (!int.TryParse(part.Trim(), out int number) ||
                    number < 1 || number > 4 ||
                    studentIndexes.Contains(number - 1))
                {
                    return false;
                }

                studentIndexes.Add(number - 1);
            }

            if (studentIndexes.Count != CorrectAnswerIndexes.Count)
            {
                return false;
            }

            foreach (int index in studentIndexes)
            {
                if (!CorrectAnswerIndexes.Contains(index))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
