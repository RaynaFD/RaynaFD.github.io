using Lab_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;


namespace Lab_8
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            FullTimeStudents.MaxWeeklyHours = 16;
            PartTimeStudent.MaxNumOfCourses = 3;
            CoopStudents.MaxNumOfCourses = 2;
            CoopStudents.MaxWeeklyHours = 4;
            
        }
    }
}