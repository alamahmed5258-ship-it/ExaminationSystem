

namespace ExaminationSystem
{
    internal class Program
    {
        static void DoctorMode(List<Question> questions)
        {
            // الدخول إلى Doctor Mode
            Console.WriteLine("Welcome Doctor");
            int NumberOfQuestions = 0;

            while (NumberOfQuestions <= 0)
            {
                Console.WriteLine("How many questions do you want to add?");

                if (!int.TryParse(Console.ReadLine(), out NumberOfQuestions) ||
                    NumberOfQuestions <= 0)
                {
                    Console.WriteLine("Invalid Number! Enter a positive number.");
                }
            }
            for (int i = 1; i <= NumberOfQuestions; i++)
            {
                // عرض رقم السؤال الحالي
                Console.WriteLine($"Question {i}");
                int TypeQuestion = 0;
                while (TypeQuestion < 1 || TypeQuestion > 3)
                {
                    // عرض أنواع الأسئلة المتاحة
                    Console.WriteLine("Choose Question Type:");
                    Console.WriteLine("1. True / False");
                    Console.WriteLine("2. Choose One");
                    Console.WriteLine("3. Multiple Choice");
                    Console.WriteLine("Enter Type:");
                    if (!int.TryParse(Console.ReadLine(), out TypeQuestion))
                    {
                        TypeQuestion = 0;
                    }

                    if (TypeQuestion < 1 || TypeQuestion > 3)
                    {
                        Console.WriteLine("Invalid Question Type, Try Again!");
                    }
                }

                switch (TypeQuestion)
                {
                    case 1:

                        Console.WriteLine("True / False Selected");



                        break;
                    case 2:
                        Console.WriteLine("Choose One Selected");

                        break;
                    case 3:
                        Console.WriteLine("Multiple Choice Selected");
                        break;

                    default:
                        Console.WriteLine("Invalid Question Type");
                        break;
                }
                int SelectLevel = 0;
                while (SelectLevel < 1 || SelectLevel > 3)
                {
                    Console.WriteLine("Choose Question Level:");
                    Console.WriteLine("1. Easy");
                    Console.WriteLine("2. Medium");
                    Console.WriteLine("3. Hard");

                    if (!int.TryParse(Console.ReadLine(), out SelectLevel))
                    {
                        SelectLevel = 0;
                    }

                    if (SelectLevel < 1 || SelectLevel > 3)
                    {
                        Console.WriteLine("Invalid Question Level, Try Again!");
                    }
                }
                switch (SelectLevel)
                {
                    case 1:
                        Console.WriteLine("Easy Level Selected.");
                        break;
                    case 2:
                        Console.WriteLine("Medium Level Selected.");
                        break;
                    case 3:
                        Console.WriteLine("Hard Level Selected.");
                        break;
                }
                QuestionLevel level = (QuestionLevel)SelectLevel;
                Console.WriteLine("Enter Question:");
                string QuestionHeader = Console.ReadLine();



                int QuestionMark = 0;

                while (QuestionMark <= 0)
                {
                    Console.WriteLine("Enter Question Marks:");

                    if (!int.TryParse(Console.ReadLine(), out QuestionMark) ||
                        QuestionMark <= 0)
                    {
                        Console.WriteLine("Invalid Marks! Enter a positive number.");
                    }
                }
                Question newQuestion;

                if (TypeQuestion == 1)
                {
                    bool correctAnswer;

                    while (true)
                    {
                        Console.WriteLine("Enter Correct Answer (true / false):");

                        if (bool.TryParse(Console.ReadLine(), out correctAnswer))
                        {
                            break;
                        }

                        Console.WriteLine("Invalid Answer! Enter true or false.");
                    }

                    newQuestion = new TrueFalseQuestion(
                        QuestionHeader, QuestionMark, level, correctAnswer);


                }
                else if (TypeQuestion == 2)
                {
                    Console.WriteLine("Enter 4 Choices:");
                    string WordsChosie1 = Console.ReadLine();
                    string WordsChosie2 = Console.ReadLine();
                    string WordsChosie3 = Console.ReadLine();
                    string WordsChosie4 = Console.ReadLine();

                    string[] choices = { WordsChosie1, WordsChosie2, WordsChosie3, WordsChosie4 };

                    int answerChoice = 0;

                    while (answerChoice < 1 || answerChoice > 4)
                    {
                        Console.WriteLine("Enter Correct Choice Number (1-4):");
                        if (!int.TryParse(Console.ReadLine(), out answerChoice))
                        {
                            answerChoice = 0;
                        }

                        if (answerChoice < 1 || answerChoice > 4)
                        {
                            Console.WriteLine("Invalid Choice, Try Again!");
                        }
                    }

                    newQuestion = new ChooseOneQuestion(
                        QuestionHeader, QuestionMark, level, choices, answerChoice - 1);
                }
                else
                {
                    Console.WriteLine("Enter 4 Choices:");

                    string[] choices = new string[4];

                    for (int k = 0; k < choices.Length; k++)
                    {
                        Console.WriteLine($"Enter Choice {k + 1}:");
                        choices[k] = Console.ReadLine();
                    }

                    List<int> correctAnswerIndexes = new List<int>();

                    while (true)
                    {
                        Console.WriteLine("Enter Correct Choices (e.g. 1,3):");
                        string input = Console.ReadLine();
                        string[] parts = input.Split(',');

                        List<int> tempIndexes = new List<int>();
                        bool isValid = true;

                        foreach (string part in parts)
                        {
                            if (!int.TryParse(part.Trim(), out int number) ||
                                number < 1 || number > 4 ||
                                tempIndexes.Contains(number - 1))
                            {
                                isValid = false;
                                break;
                            }

                            tempIndexes.Add(number - 1);
                        }

                        if (isValid)
                        {
                            correctAnswerIndexes = tempIndexes;
                            break;
                        }

                        Console.WriteLine("Invalid Answers! Try Again.");
                    }
                    newQuestion = new MultipleChoiceQuestion(QuestionHeader, QuestionMark, level, choices, correctAnswerIndexes);

                }

                questions.Add(newQuestion);


                Console.WriteLine("Question saved successfully!");
                Console.WriteLine($"Question:{QuestionHeader}");
                Console.WriteLine($"Marks:{QuestionMark}");


            }
            Console.WriteLine("===== Saved Questions =====");

            for (int j = 0; j < questions.Count; j++)
            {
                Console.WriteLine($"Question {j + 1}");
                Console.WriteLine($"Header: {questions[j].Header}");
                Console.WriteLine($"Marks: {questions[j].Marks}");
                Console.WriteLine($"Level: {questions[j].Level}");
                if (questions[j] is TrueFalseQuestion tf)
                {
                    Console.WriteLine($"Correct Answer: {tf.CorrectAnswer}");
                }
                else if (questions[j] is ChooseOneQuestion co)
                {
                    Console.WriteLine($"Correct Answer: {co.Choices[co.CorrectAnswerIndex]}");
                }
                else if (questions[j] is MultipleChoiceQuestion mc)
                {
                    Console.WriteLine("Correct Answers:");

                    for (int k = 0; k < mc.CorrectAnswerIndexes.Count; k++)
                    {
                        int index = mc.CorrectAnswerIndexes[k];

                        Console.WriteLine($"{index + 1}. {mc.Choices[index]}");
                    }
                }
            }
        }
        static void StudentMode(List<Question> questions)
        {
            // وضع الطالب
            Console.WriteLine("Welcome Student");

            if (questions.Count == 0)
            {
                Console.WriteLine("No Questions Available!");
                return;
            }

            int examType = 0;

            while (examType != 1 && examType != 2)
            {
                Console.WriteLine("Choose Exam Type:");
                Console.WriteLine("1. Practical");
                Console.WriteLine("2. Final");

                if (!int.TryParse(Console.ReadLine(), out examType) ||
                    (examType != 1 && examType != 2))
                {
                    Console.WriteLine("Invalid Exam Type, Try Again!");
                }
            }

            int selectedLevel = 0;

            while (selectedLevel < 1 || selectedLevel > 3)
            {
                Console.WriteLine("Choose Exam Level:");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard");

                if (!int.TryParse(Console.ReadLine(), out selectedLevel) ||
                    selectedLevel < 1 || selectedLevel > 3)
                {
                    Console.WriteLine("Invalid Level, Try Again!");
                }
            }

            QuestionLevel studentLevel = (QuestionLevel)selectedLevel;

            List<Question> examQuestions = new List<Question>();

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Level == studentLevel)
                {
                    examQuestions.Add(questions[i]);
                }
            }

            if (examQuestions.Count == 0)
            {
                Console.WriteLine("No questions available for this level!");
                return;
            }

            int numberOfExamQuestions = examQuestions.Count;

            if (examType == 1)
            {
                numberOfExamQuestions = (examQuestions.Count + 1) / 2;
            }
            int studentScore = 0;
            int totalMarks = 0;

            for (int j = 0; j < numberOfExamQuestions; j++)
            {
                Question currentQuestion = examQuestions[j];
                totalMarks += currentQuestion.Marks;

                Console.WriteLine($"Question {j + 1}");
                currentQuestion.Display();

                Console.WriteLine("Enter Your Answer (e.g. 1 or 1,3):");
                string studentAnswer = Console.ReadLine();

                if (currentQuestion.CheckAnswer(studentAnswer))
                {
                    studentScore += currentQuestion.Marks;
                    Console.WriteLine("Correct Answer!");
                }
                else
                {
                    Console.WriteLine("Wrong Answer!");
                }
            }

            Console.WriteLine("===== Exam Result =====");
            Console.WriteLine($"Your Score: {studentScore} / {totalMarks}");
        }
        static void Main(string[] args)
        {
            List<Question> questions = new List<Question>();
            while (true)
            {
                // عرض القائمة الرئيسية
                Console.WriteLine("===== Examination System =====");
                Console.WriteLine("1. Doctor Mode");
                Console.WriteLine("2. Student Mode");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter Your Choice:");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid Choice! Enter a number.");
                    continue;
                }

                switch (choice)
                {

                    case 1:
                        DoctorMode(questions);
                        break;
                    case 2:
                        StudentMode(questions);

                        break;

                    case 3:
                        // حاليًا ده بيقفل البرنامج
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;


                }

            }
        }
    }
}