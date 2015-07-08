<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PMS.WebForm6" %>



<!DOCTYPE html>
<html>
<head>
	<title>Login</title>
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
<body>

	<div class="container">
		<div class="col-md-12">
			<h1 class="margin-bottom-15">Login</h1>
            
			<form class="form-horizontal templatemo-container templatemo-login-form-1 margin-bottom-30" role="form" action="#" method="post" runat="server">		
                		<div class="form-group">
                            <div class="col-md-12">
                                <asp:Label ID="Label1" ForeColor="Red" Font-Size="15px" Visible="false" runat="server" Text="Invalid UserName And Password"></asp:Label>
                                </div>
		        	<div class="col-md-12">
		        		
		        		<div class="inline-block">
                            <table width="400px" class="table-responsive">
                                <tr>
                                    <td>
                               <label style="color: rgb(74, 164, 180);font-size: 18px;font-family: 'Open Sans', sans-serif;" > Log in as: </label>
                                    </td>
                    
                                    <td >
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Vertical" CssClass="radio-inline">
                                <asp:ListItem Value="4" CssClass="form-control" Selected="True" style="margin-left:10px; color: rgb(74, 164, 180);font-size: 18px;font-family: sans-serif;" >Admin</asp:ListItem>
                                                            
                                <asp:ListItem Value="1" CssClass="form-control" style="margin-left:10px; color: rgb(74, 164, 180);font-size: 18px;font-family: sans-serif;" >Manager</asp:ListItem>
                                <asp:ListItem Value="2" CssClass="form-control" style="margin-left:10px; color: rgb(74, 164, 180);font-size:18px;font-family:  sans-serif;">Team-Leader</asp:ListItem>
                                <asp:ListItem Value="3" CssClass="form-control" style="margin-left:10px; color: rgb(74, 164, 180);font-size: 18px;font-family: sans-serif;">Junior</asp:ListItem>
                            </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                            
		        		</div>		        		
		        	</div>
		        </div>
		        <div class="form-group">
		          <div class="col-xs-12">		            
		            <div class="control-wrapper">
		            	<label for="username" class="control-label fa-label"><i class="fa fa-user fa-medium"></i></label>
		            	
                        <asp:TextBox ID="TextBox1" CssClass="form-control" required="True" runat="server"></asp:TextBox>
		            </div>		            	            
		          </div>              
		        </div>
		        <div class="form-group">
		          <div class="col-md-12">
		          	<div class="control-wrapper">
		            	<label for="password" class="control-label fa-label"><i class="fa fa-lock fa-medium"></i></label>
		            	
                          <asp:TextBox ID="TextBox2" CssClass="form-control" required="True" runat="server" TextMode="Password"></asp:TextBox>
		            </div>
		          </div>
		        </div>
		        <div class="form-group">
		          <div class="col-md-12">
	             	<div class="checkbox control-wrapper">
	                	<label>
	                  		
                            <asp:CheckBox ID="CheckBox1" runat="server"  /> Remember me
                		</label>
	              	</div>
		          </div>
		        </div>
		        <div class="form-group">
		          <div class="col-md-12">
		          	<div class="control-wrapper">
		          		
                          <asp:Button ID="Login" CssClass="btn btn-info"  runat="server" Text="Log in" OnClick="Login_Click"  />
		          		<a href="forgotpassword.aspx" class="text-right pull-right">Forgot password?</a>
		          	</div>
		          </div>
		        </div>
		        <hr>
		        
		      </form>
		      
		</div>
	</div>
</body>
</html>

