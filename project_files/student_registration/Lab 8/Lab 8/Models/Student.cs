using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Lab_8.Models
{
    public class Student
    {
        public string Name { get; private set; }

        public int StudentNumber { get; private set; }

        static Random rnd = new Random();

        public List<Course> RegisteredCourses { get; private set; }


        public Student(string inputName)//, List<Course> courses)
        {   //set name
            this.Name = inputName;
            //create student number
            this.StudentNumber = rnd.Next(100000, 999999);
            //intialize the list
            RegisteredCourses = new List<Course>();
        }
        public virtual void RegisterCourses(List<Course> selectedCourses)
        {    
            RegisteredCourses.Clear();
            try
            {
                //empty registered courses and fill with selected courses
                if (selectedCourses != null && selectedCourses.Count > 0)
                {
                   
                    //check for duplicates!!
                    foreach (Course course in selectedCourses)
                    {
                        if (!RegisteredCourses.Contains(course))
                        {
                            RegisteredCourses.Add(course);

                        }
                    }

                }
                else
                {
                    throw new ArgumentException("No courses selected for registration!");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("An exception occurred: " + ex.Message);
            }
        }
              
        public int TotalWeeklyHours(Student s)
        {
            Debug.WriteLine("Number of courses in TotalWeeklyHours method = " + s.RegisteredCourses.Count);
            foreach(Course course in s.RegisteredCourses)
            { 
                Debug.WriteLine("Course Title: " + course.Title);
            }
            int totalHours = 0;
            foreach (Course c in s.RegisteredCourses)
            {
                totalHours += c.WeeklyHours;
            }
            Debug.WriteLine("Total hours calculated: " + totalHours);
            return totalHours;
        }

    }
}
 

         

    


    
