namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exam exam = new Exam();
            Console.WriteLine("Welcome to the Exam System!\n");

               Console.WriteLine("Enter your name:");
                string name = Console.ReadLine();
                Teacher teacher = new Teacher { Name = name };
                teacher.Menu(exam);
                Console.WriteLine();
                Console.WriteLine("--------The exam start----------\n");
                Console.WriteLine("Enter your name:");
                string name2 = Console.ReadLine();
                Student student = new Student { Name = name2 };
                student.Menu(exam);
        }

    }
}

