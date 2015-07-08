<%@ Page Title="PMS" Language="C#" MasterPageFile="~/PMS.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="PMS.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cp1" runat="server">
<form id="form2" runat="server">
    <nav  class="navbar-default navbar-side" role="navigation">
            <div class="sidebar-collapse">
                <ul class="nav" id="main-menu">
                    <li>
                        <div class="user-img-div">
                            
                            <asp:Image ID="userimage" runat="server" class="img-circle" />
                           
                        </div>

                    </li>
                     <li>
                        <a  href="#"> <strong> <asp:Label ID="username" runat="server"></asp:Label> </strong></a>
                    </li>

                    <li>
                        <a href="DashboardAdmin.aspx"><i class="fa fa-dashboard "></i>Dashboard</a>
                    </li>
                      <li>
                        <a href="ManageEmployee.aspx"><i class="fa fa-sitemap "></i>Employee List</a>
                         
                    </li>
                    <li>
                        <a href="RemoveEmployee.aspx"><i class="fa fa-sitemap "></i>Remove Employee</a>
                         
                    </li>
                    
                   
                </ul>
            </div>

        </nav>




   <%-- navigation complate--%>

   

    <div id="page-wrapper" class="page-wrapper-cls">
        
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="page-inner">
                
                <div class="row">
                    <div class="col-md-12">
                        <h1 class="page-head-line">Add Employee</h1>
                    </div>
                    <div class="col-md-6">
                        <div class="panel panel-default">
                        
                        <div class="panel-body">

                       
  <div class="form-group">

  <label for="exampleInputEmail1">Employee Name</label>
  <asp:TextBox ID="TextBox6" CssClass="form-control" required="true"  placeholder="Enter Employee Name" runat="server"></asp:TextBox>
      
  </div>
  <div class="form-group">
    <label for="exampleInputDate">Employee Email-ID</label>
    <asp:TextBox ID="TextBox7" CssClass="form-control" required="true" placeholder="Enter Email_ID" runat="server" ></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="please enter valid email-address" ControlToValidate="TextBox7" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
      
  </div>
    <div>
    <label for="exampleGender">Employee Gender</label>
    <asp:RadioButton ID="RadioButton1" CssClass="form-control" runat="server" Text="Male" GroupName="gender" />
    <asp:RadioButton ID="RadioButton2" CssClass="form-control" runat="server" Text="Female" GroupName="gender" />

    </div>
    
    <div class="form-group">
    <label for="exampleInputEmail1">Employee Contact Number </label>
    <asp:TextBox ID="TextBox8" CssClass="form-control" required="true" placeholder="Enter Contact Number" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Enter Valid Contact Number" ControlToValidate="TextBox8" ValidationExpression="^[7-9][0-9]{9}$" ForeColor="Red"></asp:RegularExpressionValidator>
      
  </div>

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
    <label for="exampleInputEmail1">Country</label>
    <asp:DropDownList ID="ddl3" CssClass="form-control"   runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl3_SelectedIndexChanged"></asp:DropDownList>
                                        
  </div>
    <div class="form-group">
    <label for="exampleInputEmail1">State</label>
    <asp:DropDownList ID="ddl4" CssClass="form-control"   runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl4_SelectedIndexChanged"></asp:DropDownList>

  </div>
    <div class="form-group">
    <label for="exampleInputEmail1">City</label>
    <asp:DropDownList ID="ddl5" CssClass="form-control"   runat="server"></asp:DropDownList>

  </div>

                                </ContentTemplate>


                            </asp:UpdatePanel>
    



    <div class="form-group">
    <label for="exampleInputEmail1">Employee Specialization</label>
    <asp:DropDownList ID="ddl" CssClass="form-control"   runat="server">
      
    </asp:DropDownList>

  </div>
  <div class="form-group">
    <label for="exampleInputEmail1">Employee position</label>
    <asp:DropDownList ID="ddl2" CssClass="form-control"   runat="server">
     
      </asp:DropDownList>
   
  </div>
  <div class="form-group">
    <label for="exampleInputFile">Upload Photo</label>
      <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
    
  </div>
  
  <asp:Button ID="btnadd"  runat="server" CssClass="btn btn-default" Text="Add Employee" OnClick="btnadd_Click"  />
                          

                            </div>
                            </div>
                    </div>
                    
                </div>

            </div>
            </form>
            <!-- /. PAGE INNER  -->
        </div>

</asp:Content>
