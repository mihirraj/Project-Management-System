<%@ Page Title="" Language="C#" MasterPageFile="~/PMS.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="PMS.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cp1" runat="server">

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
                        <a  href="DashboardAdmin.aspx"><i class="fa fa-dashboard "></i>Dashboard</a>
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
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="page-inner">
                
               







                <div class="row">
                    <div class="col-md-12">
                        <h1 class="page-head-line">Profile Details</h1>
                    </div>






                    <div class="col-md-6" style="width:50%">
                        <div class="panel panel-default">
                        
                        <div class="panel-body">


    <div class="form-group">
     
    <label for="exampleInputEmail1"></label>
    <asp:Image ID="pimg" Width="200px" Height="200px" runat="server" CssClass=" img-rounded" BorderColor="Window" ></asp:Image>
       
    </div>
                                                  
  <div class="form-group">
  <label for="EmployeeName" >Employee Name :</label>
  
   <asp:Label ID="EmpName" CssClass="form-control" runat="server" BorderColor="Window"></asp:Label>   

  </div>
  <div class="form-group">
    <label for="EmpEmail">Employee Email-ID :</label>
    <asp:Label ID="Email" CssClass="form-control" runat="server" BorderColor="Window" ></asp:Label>
      

  </div>
  <div class="form-group">
    <label for="EmployeeContact">Employee Contact :</label>
    <asp:Label ID="Contact" CssClass="form-control" BorderColor="Window"  runat="server"></asp:Label>
      
  </div>
    <div class="form-group">
    <label for="EmpGender">Employee Gender  :</label>
    <asp:Label ID="Gender" CssClass="form-control" BorderColor="Window"  runat="server"></asp:Label>
         
  </div>
    <div class="form-group">
    <label for="EmpSpecialization">Employee Specialization :</label>
    <asp:Label ID="Specialization" CssClass="form-control" runat="server" BorderColor="Window"></asp:Label>
    


  </div>
  <div class="form-group">
    <label for="EmpPosition">Employee Position :</label>
    <asp:Label ID="Position" CssClass="form-control" BorderColor="Window" runat="server" ></asp:Label>
    
  </div>
    <div class="form-group">
    <label for="EmpCountry">Employee Country :</label>
<asp:Label ID="EmpCountry" CssClass="form-control" runat="server" BorderColor="Window"></asp:Label>
    </div>
    <div class="form-group">
    <label for="EmpState">Employee State :</label>
<asp:Label ID="State" CssClass="form-control" runat="server" BorderColor="Window"></asp:Label>
    </div>
    <div class="form-group">
    <label for="EmpCity">Employee City :</label>
<asp:Label ID="City" CssClass="form-control" runat="server" BorderColor="Window"></asp:Label>
    </div>


  
 
  
  


    <%--<asp:Button ID="btnedit"  runat="server" CssClass="btn btn-default" Text="Edit Details"  />--%>
    </div>
                            </div>
                        </div>
                    </div>
                </div>
                                 
</form>
                            </div>
</asp:Content>
