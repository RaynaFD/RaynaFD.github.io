using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Lab_8.Models
{
    internal class FullTimeStudents : Student
    {
        internal static int MaxWeeklyHours;

        internal FullTimeStudents(string inputName) : base(inputName) { }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            // Calculate the total weekly hours before registration
            int currentTotalHours = this.TotalWeeklyHours(this);

            // Calculate the sum of weekly hours for the selected courses that are not already registered
            int selectedCoursesTotalHours = 0;
            foreach (Course course in selectedCourses)
            {
                if (!RegisteredCourses.Contains(course))  // Check if the course is not already registered
                {
                    selectedCoursesTotalHours += course.WeeklyHours;
                }
            }

            // Calculate the total hours after registration by adding the current total hours and selected courses' total hours
            int totalHoursAfterRegistration = currentTotalHours + selectedCoursesTotalHours;

            Debug.WriteLine("Current Total Hours: " + currentTotalHours);
            Debug.WriteLine("Selected Courses Total Hours: " + selectedCoursesTotalHours);
            Debug.WriteLine("Total Hours After Registration: " + totalHoursAfterRegistration);
            Debug.WriteLine("Max Weekly Hours: " + MaxWeeklyHours);

            // Check the total hours
            if (totalHoursAfterRegistration > MaxWeeklyHours)
            {
                throw new Exception("Please select fewer than 16 hours of total weekly study time.");
            }
            else
            {
                // register the courses
                if (selectedCourses != null && selectedCourses.Count > 0)
                {
                   
                    // Add only the courses that are not already registered
                    foreach (Course course in selectedCourses)
                    {
                        if (!RegisteredCourses.Contains(course))
                        {
                            RegisteredCourses.Add(course);
                        }
                    }
                    Debug.WriteLine("Registered for Full Time Courses!");
                }
            }
        }



        public override string ToString()
        {
            return $"{StudentNumber} - {Name} (Full time)";
        }
    }
}