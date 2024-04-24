<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab_8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Register Course</title>
         <%-- Use Bootstrap to style the page --%>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
  
  <%-- Jquery required by Bootstrap  --%>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  
  <%-- Bootstrap's Javascript library --%>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

  <link href="App_Themes/SiteStyles.css" rel="stylesheet"/>
</head>
<body>
    <main>
    <form id="form1" runat="server" class="was-validated" novalidate>
        <header class="container">
            <h3>Algonquin College Course Registration</h3>
        </header>
        
        <asp:Panel runat="server" ID="pnlNameStudyTime" Enabled="true" CssClass="container row">
            <h6>Select Your Name: </h6>
           
            <br /><br />
            
            <asp:DropDownList runat="server" ID="drpLstStudents" AutoPostBack="true" CssClass="dropDown" OnSelectedIndexChanged ="drpLstStudent_SelectionChanged">
                <asp:ListItem></asp:ListItem>    
            </asp:DropDownList>
          <asp:RequiredFieldValidator runat="server" ID="rqvDrop" ErrorMessage="Please select a name." ControlToValidate="drpLstStudents"
    Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
        </asp:Panel>
        <br />
           <asp:TextBox runat="server" ID="userMessage" Visible="false" Text="" CssClass="userMessage border-0" TextMode="MultiLine" Rows="2" ReadOnly="true" Width="500px"></asp:TextBox> 

        <div>
              <div class="checklistDiv">
                  <br />
                  <asp:Panel runat="server" ID="pnlChecklist" Visible="true" Enabled="true">
     <h6>Choose your Courses:</h6> 
      <br />
           <asp:TextBox runat="server" ID="errorMessage" Visible="false" Text="" ReadOnly="true" CssClass="errorMessage alert"></asp:TextBox>          
      <asp:CheckBoxList ID="chklst" runat="server"  SelectionMode= "ListSelectionMode.Multiple" CssClass="Checklist" />
    <br />
                  <asp:Button ID="btnSubmit" runat="server"  Text="Submit" ValidationGroups="formValidation" CssClass="btn-primary button" OnClick="btnSubmit_Click"/>
     </asp:Panel>
  </div>
        </div>
    </form>

    </main>
</body>
</html>

