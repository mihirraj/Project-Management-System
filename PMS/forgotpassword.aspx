<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="PMS.forgotpassword" %>
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
			<h1 class="margin-bottom-15">Forgot Password</h1>
            
			<form class="form-horizontal templatemo-container templatemo-login-form-1 margin-bottom-30" role="form" action="#" method="post" runat="server">		
                		<div class="form-group">
                            <div class="col-md-12">
                                <%--<label for="exampleInputEmail1"></label>
                                     <asp:Label ID="EmpName" CssClass="form-control" text="Enter Email" runat="server" BorderColor="Window"></asp:Label>
                                </div>--%>
		        	
		        </div>
		        <div class="form-group">
		          <div class="col-xs-12">		            
		            <div class="control-wrapper">
		            	<label for="exampleInputEmail1"></label>
                                     <asp:TextBox ID="txtpass" runat="server" placeholder="Enter Email-ID" CssClass="form-control" Width="70%"></asp:TextBox>
		            </div>		            	            
		          </div>              
		        </div>
		        <div class="form-group">
		          <div class="col-md-12">
		          	<div class="control-wrapper">
		            	<label for="exampleInputEmail1"></label>
                                    <asp:Button ID="btn1" runat="server" Text="Send" CssClass="form-control" width=50% OnClick="btn1_Click" />
		            </div>
		          </div>
		        </div>
		        <div class="form-group">
		          <div class="col-md-12">
	             	<div class="control-wrapper">
	                	
		            	
                          <label for="exampleInputEmail1"></label>
                                     <asp:Label ID="pwdmsg" CssClass="form-control" text="" Visible="false"  runat="server" BorderColor="Window"></asp:Label>
	              	</div>
		          </div>
		        </div>
		        </div>
		        
		      </form>
		      
		</div>
	</div>
</body>
</html>
		            
