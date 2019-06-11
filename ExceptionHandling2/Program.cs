using System;

/* Accepts names of 2 students and marks in 3 subjects for each student.
 * Handle exceptions when accepting mark values:
 *  - NumberFormatException: Marks are required to be integers
 *  - InvalidGradeRange: (custome exception) Marks must be between 0 and 100.
 */

namespace ExceptionHandling2
{
    class Program
    {
        private const int NUM_STUDENTS = 2;
        private const int NUM_SUBJECTS = 3;

        public struct Student
        {
            public string name;
            public int[] marks;

            public Student(int studentNumber)
            {
                // Init name
                string nameMsg = string.Format("Student {0} Name: ", 
                    studentNumber);
                name = GetInputName(nameMsg);
                // Init marks
                marks = new int[NUM_SUBJECTS];
                for (int i = 0; i < NUM_SUBJECTS; i++)
                {
                    string markMsg = string.Format("{0}'s Subject {1} Mark: ", 
                        name, i+1);
                    this.marks[i] = GetInputMark(markMsg);
                }
            }
        }

        private static string GetInputName(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private static int GetInputMark(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                try
                {
                    int mark = Convert.ToInt32(input);
                    if (mark < 0 || mark > 100)
                    {
                        throw new GradeRangeException();
                    }
                    return mark;

                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Invalid input. Please enter an integer.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine(
                        "Invalid input. Overflow limit is exceeded.");
                }
                catch (GradeRangeException)
                {
                    Console.WriteLine(
                        "Invalid input. Marks must be between 0 and 100.");
                }
            }
        }

        private static void PrintSubjectAverages(Student[] students)
        {
            Console.WriteLine("Computing average marks for each subject...");
            for (int i = 0; i < NUM_SUBJECTS; i++)
            {
                int sum = 0;
                for (int j = 0; j < NUM_STUDENTS; j++)
                {
                    sum += students[j].marks[i];
                }
                double avg = (1.0 * sum) / NUM_STUDENTS;
                Console.WriteLine("Subject {0} average: {1:0.00}", i + 1, avg);
            }
        }

        static void Main(string[] args)
        {
            // Create student objects
            Student[] students = new Student[NUM_STUDENTS];
            for (int i = 0; i < NUM_STUDENTS; i++)
            {
                students[i] = new Student(i+1);
            }

            // Compute and print averages of each subject
            PrintSubjectAverages(students);
        }
    }
}
