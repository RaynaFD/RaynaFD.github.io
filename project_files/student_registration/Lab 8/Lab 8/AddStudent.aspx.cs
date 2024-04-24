using Lab_8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //student list already in session?
                if (Session["StudentList"] == null)
                {
                    //no? make the student list!
                    List<Student> students = new List<Student>();
                    Session["StudentList"] = students;
                }
                else
                {
                    //yes? load the student list!
                    List<Student> students = (List<Student>)Session["StudentList"];
                }

            }

        }
        protected void onButtonClick(object name, EventArgs click)
        {
            //are required fields filled in?
            if (Page.IsValid)
            {

                Debug.WriteLine("Button clicked!");
                string newName = txtName.Text;
                string courseLoad = drpLstStudyType.SelectedValue;
                Debug.WriteLine(courseLoad);
                //uneccesarry check now that we have server-side validation??
                if (courseLoad != "0")
                {

                    // create new student object
                    Student newStudent;
                    //determine study-type and create specefic study type
                    if (courseLoad == "Full-time")
                    {
                        Debug.WriteLine("new full time student created");
                        newStudent = new FullTimeStudents(newName);
                    }
                    else if (courseLoad == "Part-time")
                    {
                        Debug.WriteLine("new part-time student created");
                        newStudent = new PartTimeStudent(newName);
                    }
                    else if (courseLoad == "Co-op")
                    {
                        Debug.WriteLine("new co-op student created");
                        newStudent = new CoopStudents(newName);
                    }
                    else
                    {
                        Debug.WriteLine("Invalid student creation");
                        return;
                    }
                    //create list of existing students from exisiting session data in order to include
                    //all previously entered students
                    List<Student> students = (List<Student>)Session["StudentList"];
                    students.Add(newStudent);


                    // populate table using list
                    foreach (Student s in students)
                    {
                        TableRow newRow = new TableRow();
                        tblStudents.Rows.Add(newRow);

                        TableCell idCell = new TableCell();
                        newRow.Cells.Add(idCell);
                        idCell.Text = s.StudentNumber.ToString();
                        TableCell nameCell = new TableCell();
                        newRow.Cells.Add(nameCell);
                        nameCell.Text = s.Name;

                    }
                    // reveal newly constructed table
                    pnlResultTable.Visible = true;
                    Debug.WriteLine("table made!");
                    Debug.WriteLine(students.Count);
                    drpLstStudyType.SelectedIndex = 0;
                    txtName.Text = "";
                    Session["StudentList"] = students;
                    // Add the student name to drpDownNames
                    List<string> drpDownNames = (List<string>)Session["DropDownNames"];
                    if (drpDownNames == null)
                    {
                        drpDownNames = new List<string>();
                    }
                    drpDownNames.Add(newStudent.ToString());
                    Session["DropDownNames"] = drpDownNames;

                }
                else
                {
                    Debug.WriteLine("Error creating student object and/or table");
                }
            }
        }
    }
}