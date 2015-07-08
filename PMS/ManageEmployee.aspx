<%@ Page Title="" Language="C#" MasterPageFile="~/PMS.Master" AutoEventWireup="true" CodeBehind="ManageEmployee.aspx.cs" Inherits="PMS.ManageEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cp1" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


    


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
                        <a href="ManageEmployee.aspx" class="active-menu"><i class="fa fa-sitemap "></i>Employee List</a>
                         
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
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
            <div id="page-inner">
                
               







                <div class="row">
                    <div class="col-md-12">
                        <h1 class="page-head-line">Employee List</h1>
                    </div>
                    <div class="col-md-3 col-sm-3">

                <asp:Button ID="ButtonAdd" runat="server" CssClass="btn btn-default" Text="+ New Employee" Width="60%" OnClick="ButtonAdd_Employee"/>
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

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="True"  PageSize="5"  AutoGenerateSelectButton="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" EditRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Middle" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Project Image" >
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Width="100px" ImageUrl='<%#Bind("image_url") %>'   Height="100px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Name" >
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("ename") %>' EditRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Bind("egender") %>'>></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email-ID">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Bind("eemail") %>'>></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Bind("econtct") %>'>></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                            <asp:TemplateField HeaderText="Designation">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Bind("Role") %>'>></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Bind("CountryName") %>'>></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                            
                            
                        </Columns>
                    </asp:GridView>
                    


                    </div>
                  </div>

            </div>
                </div>
            </form>
            <!-- /. PAGE INNER  -->
        </div>


</asp:Content>
