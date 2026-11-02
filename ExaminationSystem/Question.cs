using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{

    public enum QuestionLevel
    {
        Easy=1,
        Medium=2,
        Hard=3
    }
    internal class Question
    {
        public string Header { get; set; }
        public int Marks { get; set; }
        public QuestionLevel Level { get; set; }
        public virtual void Display()
        {
            Console.WriteLine($"Question: {Header}");
            Console.WriteLine($"Marks: {Marks}");
            Console.WriteLine($"Level: {Level}");
        }
        public Question(string header, int marks, QuestionLevel level)
        {
            Header = header;
            Marks = marks;
            Level = level;
        }

        public virtual bool CheckAnswer(string studentAnswer)
        {
            return false;
        }
    }
}
