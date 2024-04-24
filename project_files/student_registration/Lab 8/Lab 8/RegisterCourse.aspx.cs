using Lab_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;


namespace Lab_8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Color red = Color.Red;

            if (!IsPostBack)
            {//generate checklist
                foreach (Course c in Helper.GetAvailableCourses())
                {
                    chklst.Items.Add(new ListItem(c.Code + " - " + c.Title + " - " + c.WeeklyHours + " hours per week"));
                }
                Debug.WriteLine("Checklist loaded");

            if (Session["StudentList"] != null)
            {
                    addNamesToDropDown();

            }
            }

        }
        //onbuttonclick submit courses and check against object parameters
        protected void btnSubmit_Click(object sender, EventArgs arg)
        {
            Debug.WriteLine("Button Clicked!");


            //create list of selected items
            if (Page.IsValid)
            {
                string entry = drpLstStudents.SelectedValue as string;
                // split name for ID number to use in method
                string[] parts = entry.Split('-');
                string ID = parts[0];
                List<Course> selectedCourses = new List<Course>();
                //grab selected student name, VS code auto-filled "as string"!? if this works my mind is blown.
                string studentID = drpLstStudents.SelectedValue as string;
                Debug.WriteLine("Begin registration for: " + ID);
                //OR CAN I ITERATE THROUGH THE STUDENTS OBJECTS
                //TO JUST FIND THE MATCHING ID NUMBER?


                //iterate through generated checklist items
                foreach (ListItem item in chklst.Items)
                {
                    if (item.Selected)
                    //EDIT-totalWeeklyHours still doesnt properly calculate, and checklist doesn't repopulate?
                    {
                        string itemText = item.Text;
                        //split string into array
                        string[] itemParts = itemText.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                        //extract code from index 0
                        string code = itemParts[0];
                        Debug.WriteLine("Code extracted: " + code);
                        //activate helper method
                        Course selectedCourse = Helper.GetCourseByCode(code);
                        Debug.WriteLine("Selected Course: " + selectedCourse.Title);
                        //add selectedCourse to list
                        selectedCourses.Add(selectedCourse);
                        if (selectedCourses.Count > 0)
                        {
                            List<Student> registerstudents = (List<Student>)Session["StudentList"];

                            //find student object create GETSTUDENTSBY ID is it even necessary??
                            Student oneNewStudent = Helper.GetStudentByID(ID, registerstudents);
                            try
                            {
                                oneNewStudent.RegisterCourses(selectedCourses);
                            }
                            catch (Exception ex)
                            {
                                userMessage.Visible = true;
                                userMessage.Text = ex.Message;
                                userMessage.CssClass = "alert alert-danger";
                                return;
                            }
                            //build message

                            //make message visible


                        }
                        else if (selectedCourses.Count == 0)
                        {
                            userMessage.Text = "Please select a course for registration.";
                            userMessage.Visible = true;
                            userMessage.CssClass += "alert alert-danger";
                        }
                    }


                }



                Debug.WriteLine("selected course count OUTSIDE OF FOREACH BUTTON LOOP= " + selectedCourses.Count);
                List<Student> students = (List<Student>)Session["StudentList"];
                
                Student newStudent = Helper.GetStudentByID(ID, students);
                int totalHours = newStudent.TotalWeeklyHours(newStudent);
                userMessage.Visible = true;
                userMessage.Text = newStudent.Name + " has been registered for " + selectedCourses.Count + " course(s), for a total of " + totalHours + " weekly study hours.";
                userMessage.CssClass += "alert alert-success";//add checklist remembering selections and clear checklist when a new name is selected
                                                              //also clear display
            }     //add error throw for no selected student }
        }
        protected void drpLstStudent_SelectionChanged(object sender, System.EventArgs e)
        {
            // Find selected student object
            List<Student> students = (List<Student>)Session["StudentList"];
            string entry = drpLstStudents.SelectedValue as string;
            // Split name for ID number to use in method
            string[] parts = entry.Split('-');
            string ID = parts[0];
            Student studentToFind = Helper.GetStudentByID(ID, students);
            userMessage.Visible = false;

            // Extract registered courses and compare against chklst
            // If chklst item is in registered courses, pre-check it
            if (studentToFind != null)
            {
                List<Course> courses = studentToFind.RegisteredCourses;
                Debug.WriteLine("Number of extracted courses for comparison: " + courses.Count);

                foreach (ListItem item in chklst.Items)
                {
                    string[] courseParts = item.Text.Split('-');
                    // Trim to remove extra spaces, we already know code is at [0] so title is at [1]
                    string courseTitle = courseParts[1].Trim(); 

                    // Check if the course title is in the courses list 
                    // .Exists is a C# method for lists, it returns a bool to confirm if item exists in list or not
                    // course represents each Course object as Exists iterates through objects stored in list 
                    //the lambda section is the condition Exists is using to check each course object
                    //course.Title == item.Text
                    //in order to get the proper part of the item Text I will trim it to extract just the course title
                    bool courseFound = courses.Exists(course => course.Title.Trim() == courseTitle);

                    // Debug output for course pre-checking status
                    Debug.WriteLine("Course: " + courseTitle + " Found: " + courseFound);

                    // Set the .Selected attribute based on courseFound
                    item.Selected = courseFound;
                }
            }
        }

        //clear registered courses (?)
        private void addNamesToDropDown()
        {
            List<string> dropDownNames = (List<string>)Session["DropDownNames"];


            foreach (string entry in dropDownNames)
            {
                drpLstStudents.Items.Add(entry);
                drpLstStudents.DataBind();

                //add study type to name
            }
        }
    }  
    }
