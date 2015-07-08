<%@ Page Title="" Language="C#" MasterPageFile="~/PMS.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="DashboardJunior.aspx.cs" Inherits="PMS.DashboardJunior" %>
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
                        <a href="DashboardJunior.aspx" class="active-menu"><i class="fa fa-dashboard "></i>Dashboard</a>
                    </li>
                      <li>
                        <a href="MyTasks.aspx"><i class="fa fa-sitemap "></i>My Tasks</a>
                         
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
            <div id="page-inner">
                
                
                <div class="row">
                <div class=" col-md-3 col-sm-3">
                <asp:DataList ID="datalist1" runat="server" class=" col-md-3 col-sm-3" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <div >
                     <div class="style-box-one " style="border-left:none" >
                            <a href="#">
                                <span>

                                    <asp:ImageButton CommandArgument='<%#Bind("pname") %>' ID="image12" runat="server" Width="150px" Height="150px"  ImageUrl='<%#Bind("pimage") %>'  OnCommand="image12_Command" />
                                </span>
                                 <h5><asp:Label ID="lbl1" runat="server" Text='<%#Bind("pname") %>' ForeColor="Black" Font-Size="Medium"></asp:Label></h5>
                            </a>
                        </div>
                        </div>
                    </ItemTemplate>


                </asp:DataList>
                    </div>
                    </div>
                 
                <div class="row">
            <div class=" col-md-4 col-sm-4" style="width:100%">
                <div class="table-responsive">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5" AutoGenerateSelectButton="true" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" >
                        <Columns>
                            <asp:TemplateField HeaderText="Project Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("pname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ps_date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("ps_enddate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Budget">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("budget") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Team Leader">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("team_leader_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                   <asp:Label ID="Label6" runat="server" Text='<%# Bind("status1") %>'></asp:Label>
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
