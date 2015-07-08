<%@ Page Title="" Language="C#" MasterPageFile="~/PMS.Master" AutoEventWireup="true" CodeBehind="AnalysisManager.aspx.cs" Inherits="PMS.Analysis" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
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
                        <a   href="DashboardManager.aspx"><i class="fa fa-dashboard "></i>Dashboard</a>
                    </li>
                      <li>
                        <a href="ManageProjectsManager.aspx"><i class="fa fa-sitemap "></i>Manage Project</a>
                         
                    </li>
                    <li>
                        <a href="AnalysisManager.aspx" class="active-menu"><i class="fa fa-sitemap "></i>Analysis</a>
                         
                    </li>
                    <li>
                        <a href="TaskUpdateManager.aspx"><i class="fa fa-sitemap "></i>Task Updates</a>
                         
                    </li>
                    
                   
                </ul>
            </div>
        
        </nav>


    <div id="page-wrapper" class="page-wrapper-cls">
            <div id="page-inner">
                <div class="col-md-12">
                        <h1 class="page-head-line">Project Progress chart</h1>
            </div> 
               <form id="form1" runat="server"> 
            <div>
                <asp:Chart ID="Chart3" runat="server">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="projectname" YValueMembers="projectprg"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>

            </div>
                   <div class="col-md-12">
                        <h1 class="page-head-line">Progerss chart of task</h1>
                 </div>
                <div class=" col-md-3 col-sm-3" >
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class=" col-md-3 col-sm-3">
                <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>

                </div>


                   <div>
                       <asp:Chart ID="Chart1" runat="server">
                           <Series>
                               <asp:Series Name="Series1" XValueMember="TaskName" YValueMembers="Progress" ></asp:Series>
                           </Series>
                           <ChartAreas>
                               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                           </ChartAreas>
                       </asp:Chart>
                   </div>
                   <div class="col-md-12">
                        <h1 class="page-head-line">Progress chart of modules</h1>
                 </div>
                   <div>

                       <div class=" col-md-3 col-sm-3" >
                <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server"  OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
                       <div>
                           <asp:Chart ID="Chart2" runat="server">
                               <Series>
                                   <asp:Series Name="Series1" XValueMember="modulname" YValueMembers="prg"></asp:Series>
                               </Series>
                               <ChartAreas>
                                   <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                               </ChartAreas>
                           </asp:Chart>
                       </div>
                   </div>
        </form>
        </div>
    </div>
        
</asp:Content>
