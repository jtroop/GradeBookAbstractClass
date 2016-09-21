using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        // What the virtual keyword does here is allow us to overwrite the method
        // and because of this ability to override we can now have different 
        // objects pointing to different methods at run time. 
        // This is a concrete example of polymorphism here in C#
        // multiple diffrent implementations of a method / object 
        // and being correctly used at run time based on their type
        // At run time the compiler will no longer use the type of variable
        // to determing what method to call, instead it will use the type 
        // of object to determine what method to call

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook:ComputeStatistics");


           GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }



        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }


        protected List<float> grades;
    }
}
