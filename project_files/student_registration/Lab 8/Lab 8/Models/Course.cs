using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_8.Models
{
    public class Course
    {
        internal string Code { get; private set; }
        internal string Title { get; private set; }
        internal int WeeklyHours { get; set; }
        public Course(string code, string title, int hours)
        {
            Title = title;
            Code = code;
            WeeklyHours = hours;

        }
    }
}