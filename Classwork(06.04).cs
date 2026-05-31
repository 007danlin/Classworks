using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var students = new Student[]
            {
                new Student("A","a", new int[,] {{1,2,3},{5,5,5}}),
                new Student("B", "b", new int[,] { { 4, 4, 5 }, { 5, 4, 5 } }),
                new Student("C", "c", new int[,] { { 2, 2, 2 }, { 2, 3, 2 } })
            };

            foreach (var s in students)
            {
                Console.WriteLine(s[0]);
            }
            students[0][0, 0] = 5;
            string str = "I am a good student";
            string str2 = "Mot, i am!";
            str = "No, you are mistaken";
            str2 = str;
            //Console.WriteLine(str2);
            //str2 = str.ToLower();
            //Console.WriteLine(str2);
            var strings = str.Split(new char[] { ',', '?', '!' },
                StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();
            sb.Append("w3awdawd");
            
            
          



        }
       
        
        public class Student
        {
            string _name;
            string _surname;

            int[,] _marks;

            public int[,] Marks => _marks;

            public double[] AverageMarks
            {
                get
                {
                    if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0)
                        return null;
                    var average = new double[_marks.GetLength(0)];
                    for (int i = 0;  i < average.Length; i++)
                    {
                        for (int j = 0;  j < _marks.GetLength(1); j++)
                        {
                            average[i] += (double)_marks[i, j]/_marks.GetLength(1);
                        }
                    }
                    return average;
                }
            }
            
            public double this[int idx]
            {
                get { return AverageMarks[idx]; }
            }
            public int this[int i, int j]
            {
                get { return _marks[i, j]; }
                set
                {
                    if (value >= 2 && value <= 5)
                        _marks[i, j] = value;
                }
            }
        
            public Student(string name, string surname, int[,] marks = null)
            {
                _name = name;
                _surname = surname;
                if (marks != null)
                {
                    _marks = (int[,])marks.Clone();
                }
            }
            public override string ToString()
            {
                string output = _name + " " + _surname;
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        output += _marks[i, j] + " ";
                    }
                    output = output.TrimEnd();
                    output = Environment.NewLine;
                }

                return output;


            }
        }
    }
}
