<%@ Page Title="" Language="C#" MasterPageFile="~/PMS.Master" AutoEventWireup="true" CodeBehind="ProfileManager.aspx.cs" Inherits="PMS.EmployeeProfile" %>
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
                        <a href="AnalysisManager.aspx"><i class="fa fa-sitemap "></i>Analysis</a>
                         
                    </li>
                    <li>
                        <a href="TaskUpdateManager.aspx"><i class="fa fa-sitemap "></i>Task Updates</a>
                         
                    </li>
                    
                   
                </ul>
            </div>

        </nav>

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

                           

                          
                               
                            <asp:DetailsView ID="dt12" OnItemUpdating="dt12_ItemUpdating" AutoGenerateRows="false" OnDataBound="dt12_DataBound" runat="server" AutoGenerateEditButton="True" OnModeChanging="dt12_ModeChanging">
                        <Fields>
                            


                            <asp:TemplateField HeaderText="Employee Name">
                                <ItemTemplate>
                                   <div class="form-group">
     
    <label for="exampleInputEmail1"></label>
                                     <asp:Label ID="EmpName" CssClass="form-control" Text='<%#Bind("ename") %>' runat="server" BorderColor="Window"></asp:Label>  
                                       </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                      <asp:TextBox ID="txtename" CssClass="form-control" Text='<%#Bind("ename") %>' runat="server" BorderColor="Window"></asp:TextBox>  
                                   
                                </EditItemTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Employee Email-ID">
                                <ItemTemplate>
                                   <div class="form-group">
     
    <label for="exampleInputEmail1"></label>
                                     <asp:Label ID="lblemail" CssClass="form-control" Text='<%#Bind("eemail") %>' runat="server" BorderColor="Window"></asp:Label>  
                                       </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                   <asp:TextBox ID="txtemail" CssClass="form-control" Text='<%#Bind("eemail") %>' runat="server" BorderColor="Window"></asp:TextBox>  
                                    
                                </EditItemTemplate>
                            </asp:TemplateField>



                             <asp:TemplateField HeaderText="Contactno">
                                <ItemTemplate>
                                   <div class="form-group">
     
    <label for="exampleInputEmail1"></label>
                                     <asp:Label ID="lblcontact" CssClass="form-control" Text='<%#Bind("econtct") %>' runat="server" BorderColor="Window"></asp:Label>  
                                       </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                   <asp:TextBox ID="txtcontact" CssClass="form-control" Text='<%#Bind("econtct") %>' runat="server" BorderColor="Window"></asp:TextBox>  
                                    
                                </EditItemTemplate>
                            </asp:TemplateField>



                             <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                   <div class="form-group">
     
    <label for="exampleInputEmail1"></label>
                                     <asp:Label ID="lblgender" CssClass="form-control" Text='<%#Bind("egender") %>' runat="server" BorderColor="Window"></asp:Label>  
                                       </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                   <asp:Label ID="txtgender" CssClass="form-control" Text='<%#Bind("egender") %>' runat="server" BorderColor="Window"></asp:Label>  
                                    
                                </EditItemTemplate>
                            </asp:TemplateField>



                              <asp:TemplateField HeaderText="Employee postion ">
                                <ItemTemplate>
                                   <div class="form-group">
     
    <label for="exampleInputEmail1"></label>
                                     <asp:Label ID="lblspe" CssClass="form-control" Text='<%#Bind("Role") %>' runat="server" BorderColor="Window"></asp:Label>  
                                       </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                   <asp:Label ID="txtspe" CssClass="form-control" Text='<%#Bind("Role") %>' runat="server" BorderColor="Window"></asp:Label>  
                                    
                                </EditItemTemplate>
                            </asp:TemplateField>


                           <asp:TemplateField HeaderText="Employee Specialization ">
                                <ItemTemplate>
                                   <div class="form-group">
     
    <label for="exampleInputEmail1"></label>
                                     <asp:Label ID="lblspe1" CssClass="form-control" Text='<%#Bind("des_name") %>' runat="server" BorderColor="Window"></asp:Label>  
                                       </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                   <asp:Label ID="txtspe1" CssClass="form-control" Text='<%#Bind("des_name") %>' runat="server" BorderColor="Window"></asp:Label>  
                                    
                                </EditItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Employee Country ">
                                <ItemTemplate>
                                   <div class="form-group">
     
    <label for="exampleInputEmail1"></label>
                                     <asp:Label ID="lblcnt" CssClass="form-control" Text='<%#Bind("CountryName") %>' runat="server" BorderColor="Window"></asp:Label>  
                                       </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                  
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>



                          <asp:TemplateField HeaderText="Employee state ">
                                <ItemTemplate>
                                   <div class="form-group">
     
    <label for="exampleInputEmail1"></label>
                                     <asp:Label ID="lblstate" CssClass="form-control" Text='<%#Bind("StateName") %>' runat="server" BorderColor="Window"></asp:Label>  
                                       </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                  
                                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>



                             <asp:TemplateField HeaderText="Employee city ">
                                <ItemTemplate>
                                   <div class="form-group">
     
    <label for="exampleInputEmail1"></label>
                                     <asp:Label ID="lblcity" CssClass="form-control" Text='<%#Bind("CityName") %>' runat="server" BorderColor="Window"></asp:Label>  
                                       </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                  
                                    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>
                                   <div class="form-group">
     
    <label for="exampleInputEmail1"></label>
                                     <asp:Image ID="pimg" Width="200px" Height="200px" ImageUrl='<%#Bind("image_url") %>' runat="server" CssClass=" img-rounded" BorderColor="Window" ></asp:Image>
                                       </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Width="200px"  ImageUrl='<%#Bind("image_url") %>' Height="200px" CssClass=" img-rounded" BorderColor="Window" />
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Fields>
                       


                    </asp:DetailsView>


                           




 <%--   <div class="form-group">
     
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
    </div>--%>


  
 
  
  


    <asp:Button ID="btnedit"  runat="server" CssClass="btn btn-default" Text="Change Password" OnClick="btnedit_Click"/>
    </div>
                            </div>
                        </div>
                    </div>
                </div>
                                 
</form>
                            </div>
</asp:Content>
