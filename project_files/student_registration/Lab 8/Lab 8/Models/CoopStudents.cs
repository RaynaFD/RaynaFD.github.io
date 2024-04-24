using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Lab_8.Models
{
    internal class CoopStudents : Student
    {
        internal static int MaxNumOfCourses;
        internal static int MaxWeeklyHours;

        internal CoopStudents(string inputName) : base(inputName) { }


        public override void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            // Calculate the total weekly hours before registration
            int currentTotalHours = this.TotalWeeklyHours(this);

            // Calculate the sum of weekly hours for the selected courses
            int selectedCoursesTotalHours = 0;
            foreach (Course course in selectedCourses)
            {
                selectedCoursesTotalHours += course.WeeklyHours;
            }

            // Calculate the total hours after registration
            int totalHoursAfterRegistration = currentTotalHours + selectedCoursesTotalHours;

            // Check if the total hours exceed the maximum weekly hours allowed
            if (totalHoursAfterRegistration > MaxWeeklyHours)
            {
                throw new Exception("Please select courses such that the total weekly study hours are 4 or less.");
            }

            // Check if the selected courses exceed the maximum number of courses allowed
            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception("Please select fewer than 2 courses.");
            }

            // Register the courses if all checks pass
            if (selectedCourses != null && selectedCourses.Count > 0)
            {
               
                // Add selected courses without duplicates
                foreach (Course course in selectedCourses)
                {
                    if (!RegisteredCourses.Contains(course))
                    {
                        RegisteredCourses.Add(course);
                    }
                }
                Debug.WriteLine("Registered for Coop Courses!");
            }
        }





        public override string ToString()
        {
            return $"{StudentNumber} - {Name} (Coop)";
        }
    }
}