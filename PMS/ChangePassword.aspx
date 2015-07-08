<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="PMS.ChangePassword" %>

<!DOCTYPE html>
<html>
<head>
	<title>Change Password</title>
	<meta name="keywords" content="" />
	<meta name="description" content="" />
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,700" rel="stylesheet" type="text/css">
    <link href="assets/css/bootstrap-social.css" rel="stylesheet" />
    <link href="assets/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="assets/css/templatemo_style.css" rel="stylesheet" />
</head>
<body style="background:border-box">

	<div class="container">
		<div class="col-md-12">
			<h1 class="margin-bottom-15">Change Password</h1>
            
			<form class="form-horizontal templatemo-container templatemo-login-form-1 margin-bottom-30" role="form" action="#" method="post" runat="server">		
                		<div class="form-group">
                            <div class="col-md-12">
                                <asp:Label ID="Label1" ForeColor="Red" Font-Size="15px" Visible="false" runat="server" Text="Invalid UserName And Password"></asp:Label>
                                </div>
		        	
		        </div>
		        <div class="form-group">
		          <div class="col-xs-12">		            
		            <div class="control-wrapper">
		            	<label for="oldpassword" class="control-label fa-label"><i class="fa fa-lock fa-medium"></i></label>
		            	
                        <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Enter old password"></asp:TextBox>
		            </div>		            	            
		          </div>              
		        </div>
		        <div class="form-group">
		          <div class="col-md-12">
		          	<div class="control-wrapper">
		            	<label for="newpassword" class="control-label fa-label"><i class="fa fa-lock fa-medium"></i></label>
		            	
                          <asp:TextBox ID="TextBox2" class="form-control" runat="server" TextMode="Password" placeholder="Enter new password"></asp:TextBox>
		            </div>
		          </div>
		        </div>
		        <div class="form-group">
		          <div class="col-md-12">
	             	<div class="control-wrapper">
	                	<label for="confirmpassword" class="control-label fa-label"><i class="fa fa-lock fa-medium"></i></label>
		            	
                          <asp:TextBox ID="TextBox3" cssclass="form-control" runat="server" TextMode="Password" placeholder="Re-Enter new password"></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="new password and confirm password should match" ControlToCompare="TextBox2" ControlToValidate="TextBox3" ForeColor="Red"></asp:CompareValidator>
	              	</div>
		          </div>
		        </div>
		        <div class="form-group">
		          <div class="col-md-12">
		          	<div class="control-wrapper">
		          		
                          <asp:Button ID="Update" class="btn btn-info"  runat="server" Text="Update" OnClick="Update_Click"  />
		          		
		          	</div>
		          </div>
		        </div>
		        
		      </form>
		      
		</div>
	</div>
</body>
</html>
