using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace Lab_8.Models
{
    internal class PartTimeStudent : Student 
    { 
         internal static int MaxNumOfCourses;

        internal PartTimeStudent(string inputName) : base(inputName) { }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
             RegisteredCourses.Clear();
            // cannot have more than max number of courses
            if (selectedCourses.Count > MaxNumOfCourses)
                {
                    throw new Exception("Please select fewer than 3 courses.");
                    // string message = "Please select fewer than 3 courses.";
                    //return message;
                }
                else
                {
                    if (selectedCourses != null && selectedCourses.Count > 0)
                    {
                        
                        //check for duplicates!!
                        foreach (Course course in selectedCourses)
                        {
                            if (!RegisteredCourses.Contains(course))
                            {
                                RegisteredCourses.Add(course);

                            }
                            Debug.WriteLine("Registered for Part Time Courses!");
                        }
                    }
                }
            }
        
        
        public override string ToString()
        {
            return $"{StudentNumber} - {Name} (Part time)";
        }
    }
}