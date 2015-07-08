<%@ Page Title="" Language="C#" MasterPageFile="~/PMS.Master" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="PMS.WebForm1" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cp1" runat="server">

    
    
    <script type="text/javascript">
        function myfunction12() {
          
            var a = document.getElementById("<%=TextBox2.ClientID %>").value;
            var b = document.getElementById("<%=TextBox3.ClientID %>").value;
           
            if (new Date(b) <= new Date(a)) {
                //compare end <=, not >=
               
                alert("Please Select EndDate Greater Than StartDate");
                document.getElementById("<%=TextBox2.ClientID %>").value = "";
                document.getElementById("<%=TextBox3.ClientID %>").value = "";
               
            }
        }
    </script>
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
         
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
            <div id="page-inner">
                <div class
                    
                    ="row">
                    <div class="col-md-12">
                        <h1 class="page-head-line">Add Project</h1>
                    </div>
                    <div class="col-md-6"   style="width:50%">
                        <div class="panel panel-default">
                        
                        <div class="panel-body">
                       
  <div class="form-group">
  <label for="exampleInputEmail1">Project Name</label>
  <asp:TextBox ID="TextBox1" required="True" CssClass="form-control" placeholder="Enter Project Name" runat="server"></asp:TextBox>
      <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Project Name is required" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>--%>

  </div>
  <div class="form-group">
    <label for="exampleInputDate">Project Start Date</label>
    <asp:TextBox ID="TextBox2" CssClass="form-control"  placeholder="Select Start Date" runat="server" ></asp:TextBox>
       <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Plese Select Start Date" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>--%>

      <asp:CalendarExtender ID="CalendarExtender1" CssClass="black" runat="server" TargetControlID="TextBox2"></asp:CalendarExtender>
  </div>
  <div class="form-group">
    <label for="exampleInputEmail1">Project End Date</label>
    <asp:TextBox ID="TextBox3" CssClass="form-control" onblur="myfunction12()"  placeholder="Enter End Date" runat="server"></asp:TextBox>
       <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Plese Select End Date" ControlToValidate="TextBox3" ForeColor="Red"></asp:RequiredFieldValidator>--%>
      <asp:CalendarExtender ID="CalendarExtender3" CssClass="black" runat="server" TargetControlID="TextBox3"></asp:CalendarExtender>


      
      
     <%--  <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="TextBox2" ControlToValidate="TextBox3" 
        ErrorMessage="EndDate must greater than StartDate" Operator="LessThan" ForeColor="Red"
        Type="Date"  CultureInvariantValues="True"></asp:CompareValidator>--%>
  </div>
    <div class="form-group">
    <label for="exampleInputEmail1">Project Budget (in Rs.)</label>
    <asp:TextBox ID="TextBox4" CssClass="form-control" required="True" placeholder="Enter Budget" runat="server"></asp:TextBox>
         <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Budget is Required" ControlToValidate="TextBox4" ForeColor="Red"></asp:RequiredFieldValidator>--%>
  </div>
    <div class="form-group">
    <label for="exampleInputEmail1">Project Team Leader</label>
    <asp:DropDownList ID="ddl2" CssClass="form-control"  runat="server"></asp:DropDownList>
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="team leader is required" ControlToValidate="ddl2" ForeColor="Red"></asp:RequiredFieldValidator>--%>


  </div>
  <div class="form-group">
    <label for="exampleInputEmail1">Project Description</label>
    <asp:TextBox ID="TextBox5" required="True" CssClass="form-control"  placeholder="Enter Description" runat="server" TextMode="MultiLine"></asp:TextBox>
       <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Project Description is Required" ControlToValidate="TextBox5" ForeColor="Red"></asp:RequiredFieldValidator>--%>
  </div>
  <div class="form-group" >
    <label for="exampleInputFile">Upload Photo</label>
      <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control"/>
    
  </div>
<asp:Button ID="btnsubmit"  runat="server" CssClass="btn btn-default" Text="Submit" OnClick="btnsubmit_Click"  />
                          
</>
                            </div>
                            </div>
                    </div>
                    
                </div>

            </div>
            </form>
            <!-- /. PAGE INNER  -->
        </div>

</asp:Content>
