<%@ Page Title="" Language="C#" MasterPageFile="~/PMS.Master" AutoEventWireup="true" CodeBehind="DailyTaskUpdates.aspx.cs" Inherits="PMS.DailyTaskUpdates" %>
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
                        <a href="DashboardJunior.aspx" ><i class="fa fa-dashboard "></i>Dashboard</a>
                    </li>
                      <li>
                        <a href="MyTasks.aspx" ><i class="fa fa-sitemap "></i>My Tasks</a>
                         
                    </li>
                    <li>
                        <a href="AnalysisJunior.aspx" ><i class="fa fa-sitemap "></i>Analysis</a>
                         
                    </li>
                    <li>
                        <a href="DailyTaskUpdates.aspx" class="active-menu"><i class="fa fa-sitemap "></i>Daily Task Update</a>
                         
                    </li>
                    <li>
                        <a href="TaskUpdateJunior.aspx"><i class="fa fa-sitemap "></i>Task Updates</a>
                         
                    </li>
                    
                   
                </ul>
            </div>

        </nav>
    <div id="page-wrapper" class="page-wrapper-cls">
            <div id="page-inner">
                
                 <div class="col-md-12">
                        <h1 class="page-head-line">Task Update</h1>
                 </div>
                <div class=" col-md-3 col-sm-3">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                        
                    </asp:DropDownList>
                </div>

                <div class=" col-md-3 col-sm-3">
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
                       
                    </asp:DropDownList>
                </div>
                <div class=" col-md-3 col-sm-3">
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="true">
                       
                    </asp:DropDownList>
                </div>
                
                



                <div class="col-md-12">
                
                <div class=" col-md-3 col-sm-3">
                 <%--   <textarea id="TextArea1" cols="30" rows="4"></textarea>--%>

                    <asp:TextBox ID="TextArea1" placeholder="Enter the Description" required="true" runat="server" Columns="30 " Rows="4 " TextMode="MultiLine"></asp:TextBox>
                </div>
                </div>
                <div class="col-md-12">
                
                <div class=" col-md-3 col-sm-3">
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control"/>
                </div>
                </div>
                 <div class="col-md-12">
                
                <div class=" col-md-3 col-sm-3">
                 Progress (in %): <asp:TextBox ID="TextBox1" required="true" runat="server" CssClass="form-control"></asp:TextBox>    
                </div>
                </div>
                <div class="col-md-12">
                
                <div class=" col-md-3 col-sm-3">
                    <asp:Button ID="Button1" runat="server" Text="Send" CssClass="form-control" OnClick="Button1_Click" /> 
                </div>
                </div>




                
                
              
                
                 
                <div class="row">
                   
              
             
              
            </div>
            <!-- /. PAGE INNER  -->
        </div>
        <!-- /. PAGE WRAPPER  -->
    </div>
    </form>
</asp:Content>
