﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateUsers.aspx.cs" Inherits="Views_updateUsers" %>
<!DOCTYPE html>
<script runat="server">
</script>

<html>

<head>
    
    <meta charset="gbk">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="robots" content="all,follow">

    <title>修改用户信息</title>
    <link rel="shortcut icon" href="img/favicon.ico">
    
    <!-- global stylesheets -->
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed" rel="stylesheet">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="font-awesome-4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="css/font-icon-style.css">
    <link rel="stylesheet" href="css/style.default.css" id="theme-stylesheet">

    <!-- Core stylesheets -->
    <link rel="stylesheet" href="css/form.css">
</head>

<body>
   <form runat="server"> 
<!--====================================================
                     MAIN NAVBAR
======================================================-->
    <header class="header">
        <nav class="navbar navbar-expand-lg ">
            <div class="search-box">
                <button class="dismiss"><i class="icon-close"></i></button>
            </div>
            <div class="container-fluid ">
                <div class="navbar-holder d-flex align-items-center justify-content-between">
                    <div class="navbar-header">
                       
                        <a id="toggle-btn" href="#" class="menu-btn active">
                            <span></span>
                            <span></span>
                            <span></span>
                        </a>
                    </div>
                </div>
                <ul class="nav-menu list-unstyled d-flex flex-md-row align-items-md-center">
                    <!-- Expand-->
                    <li class="nav-item d-flex align-items-center full_scr_exp"><a class="nav-link" href="#"><img src="img/expand.png" onclick="toggleFullScreen(document.body)" class="img-fluid" alt=""></a></li>
                    <!-- Search-->
                    <li class="nav-item d-flex align-items-center"><a id="search" class="nav-link" href="#"><i class="icon-search"></i></a></li>
                    <!-- Notifications-->
                    <li class="nav-item dropdown"> 
                        <a id="notifications" class="nav-link" rel="nofollow" data-target="#" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa fa-bell-o"></i><span class="noti-numb-bg"></span><span class="badge">12</span></a>
                        <ul aria-labelledby="notifications" class="dropdown-menu">
                            <li>
                                <a rel="nofollow" href="#" class="dropdown-item nav-link">
                                    <div class="notification">
                                        <div class="notification-content"><i class="fa fa-envelope bg-red"></i>You have 6 new messages </div>
                                        <div class="notification-time"><small>4 minutes ago</small></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a rel="nofollow" href="#" class="dropdown-item nav-link">
                                    <div class="notification">
                                        <div class="notification-content"><i class="fa fa-twitter bg-skyblue"></i>You have 2 followers</div>
                                        <div class="notification-time"><small>4 minutes ago</small></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a rel="nofollow" href="#" class="dropdown-item nav-link">
                                    <div class="notification">
                                        <div class="notification-content"><i class="fa fa-upload bg-blue"></i>Server Rebooted</div>
                                        <div class="notification-time"><small>4 minutes ago</small></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a rel="nofollow" href="#" class="dropdown-item nav-link">
                                    <div class="notification">
                                        <div class="notification-content"><i class="fa fa-twitter bg-skyblue"></i>You have 2 followers</div>
                                        <div class="notification-time"><small>10 minutes ago</small></div>
                                    </div>
                                </a>
                            </li>
                            <li><a rel="nofollow" href="#" class="dropdown-item all-notifications text-center"> <strong>view all notifications                                            </strong></a></li>
                        </ul>
                    </li>
                    <!-- Messages                        -->
                    <li class="nav-item dropdown"> <a id="messages" class="nav-link logout" rel="nofollow" data-target="#" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa fa-envelope-o"></i><span class="noti-numb-bg"></span><span class="badge">10</span></a>
                        <ul aria-labelledby="messages" class="dropdown-menu">
                            <li>
                                <a rel="nofollow" href="#" class="dropdown-item d-flex">
                                    <div class="msg-profile"> <img src="img/avatar-1.jpg" alt="..." class="img-fluid rounded-circle"></div>
                                    <div class="msg-body">
                                        <h3 class="h5 msg-nav-h3">Jason Doe</h3><span>Sent You Message</span>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a rel="nofollow" href="#" class="dropdown-item d-flex">
                                    <div class="msg-profile"> <img src="img/avatar-2.jpg" alt="..." class="img-fluid rounded-circle"></div>
                                    <div class="msg-body">
                                        <h3 class="h5 msg-nav-h3">Frank Williams</h3><span>Sent You Message</span>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a rel="nofollow" href="#" class="dropdown-item d-flex">
                                    <div class="msg-profile"> <img src="img/avatar-3.jpg" alt="..." class="img-fluid rounded-circle"></div>
                                    <div class="msg-body">
                                        <h3 class="h5 msg-nav-h3">Ashley Wood</h3><span>Sent You Message</span>
                                    </div>
                                </a>
                            </li>
                            <li><a rel="nofollow" href="#" class="dropdown-item all-notifications text-center"> <strong>Read all messages    </strong></a></li>
                        </ul>
                    </li> 
                    <li class="nav-item dropdown"><a id="profile" class="nav-link logout" data-target="#" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><img src="img/avatar-1.jpg" alt="..." class="img-fluid rounded-circle" style="height: 30px; width: 30px;"></a>
                        <ul aria-labelledby="profile" class="dropdown-menu profile">
                            <li>
                                <a rel="nofollow" href="#" class="dropdown-item d-flex">
                                    <div class="msg-profile"> <img src="img/avatar-1.jpg" alt="..." class="img-fluid rounded-circle"></div>
                                    <div class="msg-body">
                                        <h3 class="h5">Steena Ben</h3><span>steenaben@Businessbox.com</span>
                                    </div>
                                </a>
                                <hr>
                            </li>
                            <li>
                                <a rel="nofollow" href="profile.html" class="dropdown-item">
                                    <div class="notification">
                                        <div class="notification-content"><i class="fa fa-user "></i>My Profile</div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a rel="nofollow" href="profile.html" class="dropdown-item">
                                    <div class="notification">
                                        <div class="notification-content"><i class="fa fa-envelope-o"></i>Inbox</div> 
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a rel="nofollow" href="profile.html" class="dropdown-item">
                                    <div class="notification">
                                        <div class="notification-content"><i class="fa fa-cog"></i>Setting</div>
                                    </div>
                                </a>
                                <hr>
                            </li>
                            <li>
                                <a rel="nofollow" href="profile.html" class="dropdown-item">
                                    <div class="notification">
                                        <div class="notification-content"><i class="fa fa-power-off"></i>Logout</div>
                                    </div>
                                </a> 
                            </li>
                        </ul>
                    </li>
                    <li class="nav-item d-flex align-items-center"><a id="menu-toggle-right" class="nav-link" href="#"><i class="fa fa-bars"></i></a></li>
                    <nav id="sidebar-wrapper">
                      <div class="sidebar-nav"> 
                        <div class="tab" role="tabpanel"> 
                            <ul class="nav nav-tabs" role="tablist">
                              <li class="nav-item ">
                                <a class="nav-link active" href="#live" role="tab" data-toggle="tab"><i class="fa fa-globe"></i> Live</a>
                              </li>
                              <li class="nav-item">
                                <a class="nav-link" href="#trend" role="tab" data-toggle="tab"><i class="fa fa-rocket"></i> Trending</a>
                              </li> 
                            </ul> 
                            <div class="tab-content tabs">
                              <div role="tabpanel" class="tab-pane fade show active" id="live">
                                <h3>Connect Live</h3>
                                <div class="content newsf-list">
                                    <ul class="list-unstyled">
                                        <li class="border border-primary">
                                            <a rel="nofollow " href="#" class=" d-flex">
                                                <div class="news-f-img"> <img src="img/avatar-2.jpg" alt="..." class="img-fluid rounded-circle"></div>
                                                <div class="msg-body">
                                                    <h6 class="h5 msg-nav-h6">New Innovation world</h6>
                                                    <small>Tech soft is great innovation for...</small>
                                                </div>
                                            </a>
                                        </li>
                                        <li class="border border-success">
                                            <a rel="nofollow" href="#" class=" d-flex">
                                                <div class="news-f-img"> <img src="img/avatar-3.jpg" alt="..." class="img-fluid rounded-circle"></div>
                                                <div class="msg-body">
                                                    <h6 class="h5 msg-nav-h6">Modified hand-cart</h6>
                                                    <small>The idea is to incorporate easy...</small>
                                                </div>
                                            </a>
                                        </li>
                                        <li class="border border-info">
                                            <a rel="nofollow" href="#" class=" d-flex">
                                                <div class="news-f-img"> <img src="img/avatar-4.jpg" alt="..." class="img-fluid rounded-circle"></div>
                                                <div class="msg-body">
                                                    <h6 class="h5 msg-nav-h6">Low cost Modern printer</h6>
                                                    <small>A dot matrix printer modified at...</small>
                                                </div>
                                            </a>
                                        </li>
                                        <li class="border border-primary">
                                            <a rel="nofollow" href="#" class=" d-flex">
                                                <div class="news-f-img"> <img src="img/avatar-1.jpg" alt="..." class="img-fluid rounded-circle"></div>
                                                <div class="msg-body">
                                                    <h6 class="h5 msg-nav-h6">Low cost Modern printer</h6>
                                                    <small>A dot matrix printer modified at...</small>
                                                </div>
                                            </a>
                                        </li>
                                        <li class="border border-success">
                                            <a rel="nofollow" href="#" class=" d-flex">
                                                <div class="news-f-img"> <img src="img/avatar-2.jpg" alt="..." class="img-fluid rounded-circle"></div>
                                                <div class="msg-body">
                                                    <h6 class="h5 msg-nav-h6">Low cost Modern printer</h6>
                                                    <small>A dot matrix printer modified at...</small>
                                                </div>
                                            </a>
                                        </li> 
                                        <li class="border border-info">
                                            <a rel="nofollow" href="#" class=" d-flex">
                                                <div class="news-f-img"> <img src="img/avatar-3.jpg" alt="..." class="img-fluid rounded-circle"></div>
                                                <div class="msg-body">
                                                    <h6 class="h5 msg-nav-h6">Low cost Modern printer</h6>
                                                    <small>A dot matrix printer modified at...</small>
                                                </div>
                                            </a>
                                        </li> 
                                    </ul>
                                </div>
                              </div>
                              <div role="tabpanel" class="tab-pane fade" id="trend">
                                <div class="card card-c2" style="box-shadow: 0 0 0;">
                                    <div class="header">
                                        <h3 class="title">Trending Items</h3>
                                        <p class="category">Last Campaign Performance</p>
                                    </div>
                                    <div class="content">
                                        <canvas class="ct-chart" id="myChart-nav" height="250"></canvas>
                                        <div class="footer">
                                            <div class="legend">
                                                <i class="fa fa-circle text-info"></i> Open
                                                <i class="fa fa-circle text-danger"></i> Bounce
                                                <i class="fa fa-circle text-warning"></i> Unsubscribe
                                            </div>
                                            <hr>
                                            <div class="stats">
                                                <i class="fa fa-clock-o"></i> Campaign sent 2 days ago
                                            </div>
                                        </div>
                                    </div>
                                </div>
                              </div>
                           </div>
                      </div>
                          </div>
                    </nav>
                </ul> 
            </div>
        </nav>
    </header>

<!--====================================================
                    PAGE CONTENT
======================================================-->
    <div class="page-content d-flex align-items-stretch">
       
        <!--***** SIDE NAVBAR *****-->
                <nav class="side-navbar">
            <div class="sidebar-header d-flex align-items-center">
                <div class="avatar"><img src="img/avatar-1.jpg" alt="..." class="img-fluid rounded-circle"></div>
                <div class="title">
                     <asp:Label ID="session" runat="server"></asp:Label>
               </div>
                <asp:ImageButton CausesValidation = "false" runat="server" ID="sign_up" style="background-image:url(./img/logout/zhuxiao.png);margin-left:20px;margin-bottom:7px" OnClick="sign_up_Click" />
            </div>
            <hr>
            <!-- Sidebar Navidation Menus-->
            <ul class="list-unstyled">
                 
  
                <li  class="active"><a href="#apps" aria-expanded="false" data-toggle="collapse"> <i class="icon-interface-windows"></i>科室管理 </a>
                    <ul id="apps" class="collapse list-unstyled">
                        
                        <li><a href="addDepartment.aspx">添加</a></li> 
                        <li><a href="updateDepartment.aspx">修改</a></li> 
                       
                    </ul>
                </li>
                
                <li><a href="#forms" aria-expanded="false" data-toggle="collapse"> <i class="fa fa-building-o"></i>医护人员管理 </a>
                    <ul id="forms" class="collapse list-unstyled">
                        <li><a href="addUser.aspx">添加</a></li> 
                        <li><a href="updateUsers.aspx">修改</a></li> 
                    </ul>
                </li>
                
                <li><a href="#pages" aria-expanded="false" data-toggle="collapse"> <i class="fa fa-file-o"></i>病房管理</a>
                    <ul id="pages" class="collapse list-unstyled">
                        <li><a href="addRoom.aspx">添加</a></li> 
                        <li><a href="updateRoom.aspx">修改</a></li> 

                    </ul>
                </li>
                </ul>
        </nav>

        <div class="content-inner form-cont">
            <div class="row">
                <div class="col-md-12">

                    <!--***** BASIC FORM *****-->
                   <div class="card form" id="form1">
                        <div class="card-header">
                            <h3><strong>修改医护人员</strong></h3>
                        </div>
                        <br>
                          
                    <div class="col-md-12">
                        <div class="panel panel-default" >

                            <div class="panel-body" >
                                    <div class="form-group" style="margin-left:300px">
                                    <label>编号</label>
                                    <asp:Textbox id="user_search" runat="server"></asp:Textbox>
                                    <asp:Button ID="search_user" runat="server" Text="搜索 " class="btn btn-link" OnClick="search_user_Click" style="height: 21px"/> 
                             </div>
                                <div class="table-responsive">
                                    <table class="table-responsive" style ="width:900px;height:80px" cellpadding="0">
                                            <tr class="bg-info text-white">
                                              <td class="table-bordered td text-center "><strong>编号</strong></td>
                                              <td class="table-bordered td text-center "><strong>姓名</strong></td>
                                              <td class="table-bordered td text-center "><strong>密码</strong></td>
                                              <td class="table-bordered td text-center "><strong>性别</strong></td>
                                              <td class="table-bordered td text-center "><strong>用户类型</strong></td>
                                              <td class="table-bordered td text-center "><strong>年龄</strong></td>
                                              <td class="table-bordered td text-center "><strong>联系方式</strong></td>
                                              <td class="table-bordered td text-center "><strong>所属科室</strong></td>
                                           </tr>
                                           <tr>
                                              <td><asp:TextBox ID="user_num" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%" readonly="true"></asp:TextBox></td>
                                              <td><asp:TextBox ID="user_name" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%" readonly="true"></asp:TextBox></td>
                                              <td><asp:TextBox ID="user_password" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%" readonly="true"></asp:TextBox></td>
                                              <td><asp:TextBox ID="user_sex" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%" readonly="true"></asp:TextBox></td>
                                               <td><asp:TextBox ID="user_type" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%" readonly="true"></asp:TextBox></td>
                                              <td><asp:TextBox ID="user_age" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%" readonly="true"></asp:TextBox></td>
                                              <td><asp:TextBox ID="user_phone" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%" readonly="true"></asp:TextBox></td>
                                              <td><asp:TextBox ID="user_department" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%" readonly="true"></asp:TextBox></td>
                                           </tr>
                              
                                    </table>
                                    <div class="text-right">
                                        
                                        <asp:Button ID="update_user" runat="server" Text="修改"  class="btn btn-general btn-blue mr-3" OnClick="update_user_Click" /> 
                                        <asp:Button ID="delete_user" runat="server" Text="删除"  class="btn btn-general btn-blue mr-3" OnClick="delete_user_Click" /> 
                                        <asp:Button ID="ok_user" runat="server" Text="确定"  class="btn btn-general btn-blue mr-3" OnClick="ok_user_Click"/> 
                                    </div>
                                    <div>

                                        </div>
                                </div>
                            </div>
                        </div>
                    </div>
               
             </div>
   </div>
  </div>
 </div>
</div>
    <!--Global Javascript -->
    <script src="js/jquery.min.js"></script>
    <script src="js/popper/popper.min.js"></script>
    <script src="js/tether.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.cookie.js"></script>
    <script src="js/jquery.validate.min.js"></script>
    <script src="js/chart.min.js"></script> 
    <script src="js/front.js"></script> 
    
    <!--Core Javascript -->
    <script>
        new Chart(document.getElementById("myChart-nav").getContext('2d'), {
          type: 'doughnut',
          data: {
            labels: ["M", "T", "W", "T", "F", "S", "S"],
            datasets: [{
              backgroundColor: [
                "#2ecc71",
                "#3498db",
                "#95a5a6",
                "#9b59b6",
                "#f1c40f",
                "#e74c3c",
                "#34495e"
              ],
              data: [12, 19, 3, 17, 28, 24, 7]
            }]
          },
          options: {
              legend: { display: false },
              title: {
                display: true,
                text: ''
               } 
            }
        });
    function exampleSelect1_onclick() {

    }

    </script>
       </form>
</body>

</html>