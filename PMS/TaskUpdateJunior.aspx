<%@ Page Title="" Language="C#" MasterPageFile="~/PMS.Master" AutoEventWireup="true" CodeBehind="TaskUpdateJunior.aspx.cs" Inherits="PMS.TaskUpdateJunior" %>
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
                        <a href="DailyTaskUpdates.aspx" ><i class="fa fa-sitemap "></i>Daily Task Update</a>
                         
                    </li>
                    <li>
                        <a href="TaskUpdateJunior.aspx" class="active-menu"><i class="fa fa-sitemap "></i>Task Updates</a>
                         
                    </li>
                    
                   
                </ul>
            </div>

        </nav> 
    <div id="page-wrapper" class="page-wrapper-cls">
            <div id="page-inner">
               <div class="col-md-12">
                        <h1 class="page-head-line">Daily task details</h1>
                 </div>

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="True"  PageSize="5"   HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" EditRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Middle" OnPageIndexChanging="GridView1_PageIndexChanging" >
                    <Columns>
                        <asp:TemplateField HeaderText="Project">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("pname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Updated By">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ename") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Updated">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Files">
                            <ItemTemplate>
                                <asp:LinkButton ID="Label5" runat="server" Text='<%# Bind("FileURL") %>' CommandArgument='<%# Bind("ReportID") %>' OnCommand="Label5_Command"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Progress">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Progress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Module">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("ModuleName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Task">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("TaskName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                
                
              
                
                 
                
                   
              
             
              
            </div>
            <!-- /. PAGE INNER  -->
        </div>
        <!-- /. PAGE WRAPPER  -->
    </div>
       
    </form>
</asp:Content>
