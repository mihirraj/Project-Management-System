<%@ Page Title="" Language="C#" MasterPageFile="~/PMS.Master" AutoEventWireup="true" CodeBehind="JuniorTask.aspx.cs" Inherits="PMS.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cp1" runat="server">
    <form id="form1" runat="server">
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
                        <a href="Dashboard.aspx"><i class="fa fa-dashboard "></i>Dashboard</a>
                    </li>
                    <li>
                        <a class="active-menu" href="ManageProjects.aspx"><i class="fa fa-sitemap "></i>My Task</a>
                         
                    </li>
                    <li>
                        <a href="ui.html"><i class="fa fa-venus "></i>Analysis</a>
                        
                    </li>
                    
                    <li>
                        <a href="table.html"><i class="fa fa-bolt "></i>Task Updates</a>
                        
                    </li>
                   
                     
                     
                   
                </ul>
            </div>

        </nav>
        <div id="page-wrapper" class="page-wrapper-cls">
            <div id="page-inner">
                
                 <div class="col-md-12">
                        <h1 class="page-head-line">MY TASKS</h1>
                 </div>
                <div class=" col-md-3 col-sm-3">
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                
                </div>

                

                
                
              
                
                 
                
            <!-- /. PAGE INNER  -->
        </div>
        <!-- /. PAGE WRAPPER  -->
    </div>
    </form>
</asp:Content>
