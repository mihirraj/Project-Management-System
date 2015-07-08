<%@ Page Title="" Language="C#" MasterPageFile="~/PMS.Master" AutoEventWireup="true" CodeBehind="MyTasks.aspx.cs" Inherits="PMS.MyTasks" %>
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
                        <a href="DashboardJunior.aspx" ><i class="fa fa-dashboard "></i>Dashboard</a>
                    </li>
                      <li>
                        <a href="MyTasks.aspx" class="active-menu"><i class="fa fa-sitemap "></i>My Tasks</a>
                         
                    </li>
                    <li>
                        <a href="AnalysisJunior.aspx"><i class="fa fa-sitemap "></i>Analysis</a>
                         
                    </li>
                    <li>
                        <a href="DailyTaskUpdates.aspx"><i class="fa fa-sitemap "></i>Daily Task Update</a>
                         
                    </li>
                    <li>
                        <a href="TaskUpdateJunior.aspx"><i class="fa fa-sitemap "></i>Task Updates</a>
                         
                    </li>
                    
                   
                </ul>
            </div>

        </nav>
    <div id="page-wrapper" class="page-wrapper-cls">
        <%--<form id="form1" runat="server">--%>
            
            <div id="page-inner">
                
               







                <div class="row">
                    <div class="col-md-12">
                        <h1 class="page-head-line">My Tasks List</h1>
                    </div>
                    
                
                <div class="row">
                    <div class="col-md-3 col-sm-3">
                        <h1 class="page-head">&nbsp</h1> 
                       
                    </div>
                    <div class="col-md-3 col-sm-3">
                        <h1 class="page-head">&nbsp</h1> 
                       
                    </div>
                    <div class="col-md-3 col-sm-3">
                        <h1 class="page-head">&nbsp</h1> 
                       
                    </div>
                    <div class="col-md-3 col-sm-3">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem>all</asp:ListItem>
                            <asp:ListItem>done</asp:ListItem>
                            
                        </asp:DropDownList>
                    </div>
                </div>

              
                </div>
                 
                <div class="row">
                    
            <div class=" col-md-6 col-sm-6" style="width:100%">
                <div class="table-responsive">

                    
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="True"  PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                            <asp:TemplateField HeaderText="Project">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("pname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Module">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ModuleName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Task">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("TaskName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Progress (%)">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Progress") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        
                        
                    </asp:GridView>


                    </div>
                  </div>

            </div>
                </div>
        </div>
        
            </form>
    
            <!-- /. PAGE INNER  -->
            
    
</asp:Content>
