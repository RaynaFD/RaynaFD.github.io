<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab_8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Lab 8</title>
           <%-- Use Bootstrap to style the page --%>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>

<%-- Jquery required by Bootstrap  --%>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

<%-- Bootstrap's Javascript library --%>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

<link href="App_Themes/SiteStyles.css" rel="stylesheet"/>
<script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha384-KyZXEAg3QhqLMpG8r+VU7tx3OjvqpbZ8mkraduwJ67rzs5A54+jVOUaVrV9z9cc/" crossorigin="anonymous"></script>


</head>
<body>
    <form id="form1" runat="server">
        <header class="header">   
            <h1 class="mainTitle Display-1 ">Algonquin Student Registration</h1>
        </header>
        <main>
            <div class="inputFields container row">
              <div class="name_field container row m-1"> <asp:Label runat="server" ID="lblTxtName" Text= "Enter your name:   " CssClass="label">
                <asp:TextBox runat="server" ID="txtName" Width="350px"></asp:TextBox></asp:Label>
                <br /></div>
                <div class="drop_down container row m-1">
                <asp:Label runat="server" ID="lblDrop" Text="Select study-type" CssClass="label"></asp:Label>
                 <asp:DropDownList runat="server" ID="drpLstStudyType" CssClass="dropDown">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="Full-time" Text="Full-time"></asp:ListItem>
                <asp:ListItem Value="Part-time" Text="Part-time"></asp:ListItem>
                <asp:ListItem Value="Co-op" Text="Co-op"></asp:ListItem>
                </asp:DropDownList></div>
             <br /> </div>
                <asp:Button ID="Submit" runat="server" Text="Add Student" CssClass=" button no-border" OnClick="onButtonClick"/>
               <div class="vlaidationMessages">

                   <asp:RequiredFieldValidator ID="rqvName" runat="server" ErrorMessage="Please enter your name."
                    ControlToValidate ="txtName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                   <br />
                    <asp:RequiredFieldValidator runat="server" ID="rqvDrop" ErrorMessage="Please select a study type." ControlToValidate="drpLstStudyType"
                        Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> 

               </div>
        <div class="results">
            <asp:Panel runat="server" ID="pnlResultTable" Visible="false">
                <asp:Table runat="server" ID="tblStudents" CssClass ="table table-striped table-hover table-bordered">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>ID Number</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Student Name</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>

            </asp:Panel>

        </div>
            <a href="RegisterCourse.aspx">Register for Courses</a>
       </main> 
    </form>
    <footer>  

    </footer>
</body>
</html>
