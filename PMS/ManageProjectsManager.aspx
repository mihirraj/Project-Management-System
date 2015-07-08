<%@ Page Title="" Language="C#" MasterPageFile="~/PMS.Master" AutoEventWireup="true" CodeBehind="ManageProjectsManager.aspx.cs" Inherits="PMS.WebForm4" %>




    <asp:Content ID="Content2" ContentPlaceHolderID="cp1" runat="server">

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
                        <a   href="DashboardManager.aspx"><i class="fa fa-dashboard "></i>Dashboard</a>
                    </li>
                      <li>
                        <a class="active-menu" href="ManageProjectsManager.aspx"><i class="fa fa-sitemap "></i>Manage Project</a>
                         
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


    <div id="page-wrapper" class="page-wrapper-cls">
            <div id="page-inner">
                
                
                <div class="row">
                <h1 class="page-head-line">Project List</h1>
                    
                
                <div class="col-md-3 col-sm-3">

                <asp:Button ID="ButtonAdd" runat="server" CssClass="btn btn-default" Text="+ New Project" Width="60%" OnClick="ButtonAdd_Project"/>
                </div>
                
                <div class="row">
                    <div class="col-md-3 col-sm-3">
                        <h1 class="page-head">&nbsp</h1> 
                       
                    </div>
                
                </div>

              
                </div>
                 
                <div class="row">
                    
            <div class=" col-md-6 col-sm-6" style="width:100%">
                <div class="table-responsive">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="True"  PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateSelectButton="True" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" EditRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                        <Columns>
                            <asp:TemplateField HeaderText="Project Name"  ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("pname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Date" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ps_date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End Date" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("ps_enddate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Team Leader" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("team_leader_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project Image" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Width="100px"  Height="100px" ImageUrl='<%# Bind("pimage") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Status"  ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("status1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>

                    
                            
                        </div>
                

                        </div>
              
             
              
            </div>
            <!-- /. PAGE INNER  -->
        </div>
        <!-- /. PAGE WRAPPER  -->
    </div>
        </form>

</asp:Content>
