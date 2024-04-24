using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_8.Models
{
    public class Helper
    {

        public static List<Course> GetAvailableCourses()
        {
            //initialize a list to hold all the new courses
            List<Course> availableCourses = new List<Course>();
            //create new Course object to add to list, will reuse.
            Course course = new Course("CST8282", "Introduction to Database Systems", 4);
            availableCourses.Add(course);
            //reuse course object, add new course to list, repeat.
            course = new Course("CST8253", "Web Programming Language I", 5);
            availableCourses.Add(course);

            course = new Course("CST8256", "Web Programming II", 2);
            availableCourses.Add(course);

            course = new Course("CST8255", "Web Imaging and Animations", 2);
            availableCourses.Add(course);

            course = new Course("CST8254", "Network Operating Systems", 1);
            availableCourses.Add(course);

            course = new Course("CST2200", "Data Warehouse Design", 3);
            availableCourses.Add(course);

            course = new Course("CST2240", "Advance Database Topics", 1);
            availableCourses.Add(course);

            return availableCourses;
        }

        public static Course GetCourseByCode(string code)
        {
            //iterate through GetAvailableCourses list and search

            foreach (Course course in GetAvailableCourses())
            {
                if (course.Code == code)
                {
                    return course;
                    {

                    }

                }
            }
            return null;
        }
        
        public static Student GetStudentByID(string id, List<Student> students)
        {
            int ID = Int32.Parse(id);
            //get student list
            //copy of above for students
            foreach (Student s in students)
            {
                if(s.StudentNumber == ID)
                {
                    return s;
                }
            }
            //if no name matches somehow
            return null;
        }
    
    }
}