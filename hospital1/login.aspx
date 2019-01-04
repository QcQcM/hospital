<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
    <meta charset="utf-8"   />
    <meta http-equiv="X-UA-Compatible" content="IE=edge"  />
    <meta name="description" content=""  />
    <meta name="viewport" content="width=device-width, initial-scale=1"  />
    <meta name="robots" content="all,follow"  />

    <title>系统登录界面 </title>
    <link rel="shortcut icon" href="img/favicon.ico"  />
    
    <!-- global stylesheets -->
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed" rel="stylesheet"  />
    <link rel="stylesheet" href="css/bootstrap.min.css"  />
    <link rel="stylesheet" href="font-awesome-4.7.0/css/font-awesome.min.css"  />
    <link rel="stylesheet" href="css/font-icon-style.css"  />
    <link rel="stylesheet" href="css/style.default.css" id="theme-stylesheet"  />

    <!-- Core stylesheets -->
    <link rel="stylesheet" href="css/pages/login.css"  />
</head>

<body> 
    
<!--====================================================
                        PAGE CONTENT
======================================================--> 
    <form runat="server">
      <section class="hero-area">
        <div class="overlay"></div>
        <div class="container">
          <div class="row">
            <div class="col-md-12 ">
                <div class="contact-h-cont">
                  <h3 class="text-center"><img src="img/logo.png" class="img-fluid" alt="" /></h3><br />
                    <div class="form-group">
                      <label for="username">用户名</label>
                      <input runat="server" type="text" class="form-control" id="username" placeholder="请输入编号"  /> 
                    </div>  
                    <div class="form-group">
                      <label for="exampleInputEmail1">密码</label>
                      <input runat="server" class="form-control" type="password" value="hunter2" id="password"  /> 
                    </div>  
                    <asp:button runat="server" class="btn btn-general btn-blue" role="button" Text="登录" OnClick="Unnamed1_Click"></asp:button>          
                </div>
            </div>
          </div>  
        </div>
      </section>
      
   </form>      
    <!--Global Javascript -->
    <script src="js/jquery.min.js"></script>
    <script src="js/tether.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>

</html>
