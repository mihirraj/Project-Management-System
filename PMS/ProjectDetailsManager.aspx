<%@ Page Title="" Language="C#" MasterPageFile="~/PMS.Master" EnableEventValidation="true" AutoEventWireup="true" CodeBehind="ProjectDetailsManager.aspx.cs" Inherits="PMS.ProjectDetails" %>
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
                        <a href="DashboardManager.aspx"><i class="fa fa-dashboard "></i>Dashboard</a>
                    </li>
                      <li>
                        <a href="ManageProjectsManager.aspx"><i class="fa fa-sitemap "></i>Manage Project</a>
                         
                    </li>
                    <li>
                        <a href="AnalysisManager.aspx"><i class="fa fa-sitemap "></i>Analysis</a>
                         
                    </li>
                    <li>
                        <a href="TaskUpdateManager.aspx"><i class="fa fa-sitemap "></i>Task Updates</a>
                         
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
                        <h1 class="page-head-line">Project  Details</h1>
                    </div>






                    <div class="col-md-6" style="width:50%">
                        <div class="panel panel-default">
                        
                        <div class="panel-body">


    <div class="form-group">
     
    <label for="exampleInputEmail1"></label>
    <asp:Image ID="pimg" Width="200px" Height="200px" runat="server" CssClass=" img-rounded" BorderColor="Window" ></asp:Image>
       
    </div>
                                                  
  <div class="form-group">
  <label for="ProjectName" >Project Name :</label><asp:Label ID="ProjectName" CssClass="form-control" BorderColor="Window"   runat="server"></asp:Label>
  
      

  </div>
  <div class="form-group">
    <label for="StartDate">Project StartDate :</label>
    <asp:Label ID="pstdate" CssClass="form-control" runat="server" BorderColor="Window" ></asp:Label>
      

  </div>
  <div class="form-group">
    <label for="EndDate">Project End Date :</label>
    <asp:Label ID="penddate" CssClass="form-control" BorderColor="Window"  runat="server"></asp:Label>
      
  </div>
    <div class="form-group">
    <label for="Budget">Project Budget :</label>
    <asp:Label ID="pbudget" CssClass="form-control" BorderColor="Window"  runat="server"></asp:Label>
         
  </div>
    <div class="form-group">
    <label for="ProjectDes">Project Description :</label>
    <asp:Label ID="des" CssClass="form-control" runat="server" BorderColor="Window"></asp:Label>
    


  </div>
  <div class="form-group">
    <label for="TeamLeader">Project Team Leader :</label>
    <asp:Label ID="proteam" CssClass="form-control" BorderColor="Window" runat="server" ></asp:Label>
     
  </div>
    <div class="form-group">
    <label for="TeamMember">Project Team Member :</label>



    
<asp:GridView id="gd1" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="Employee Name">
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ename") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Module">
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("ModuleName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Task">
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("TaskName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Progress">
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Progress") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    
    

   
</asp:GridView>
  

     
  </div>

  
 
  
  


    
    </div>
                            </div>
                        </div>
                    </div>
                </div>
                                 
</form>
                            </div>
   
            <!-- /. PAGE INNER  -->
        
    

</asp:Content>
