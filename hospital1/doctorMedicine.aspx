<%@ Page Language="C#" AutoEventWireup="true" CodeFile="doctorMedicine.aspx.cs" Inherits="doctorMedicine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="robots" content="all,follow">

    <title>开药界面</title>
    <link rel="shortcut icon" href="img/favicon.ico">
    
    <!-- global stylesheets -->
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed" rel="stylesheet">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="font-awesome-4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="css/font-icon-style.css">
    <link rel="stylesheet" href="css/style.default.css" id="theme-stylesheet">

    <!-- Core stylesheets -->
    <link rel="stylesheet" href="css/apps/calendar.css">
</head>

<body> 
     <form runat ="server" >
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
                        <a href="index.html" class="navbar-brand">
                            <div class="brand-text brand-big hidden-lg-down"><img src="img/logo-white.png" alt="Logo" class="img-fluid"></div>
                            <div class="brand-text brand-small"><img src="img/logo-icon.png" alt="Logo" class="img-fluid"></div>
                        </a>
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
                                        <canvas class="ct-chart" id="myChart4" height="250"></canvas>
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
               
                <li> <a href="doctorAdvice.aspx"> <i class="icon-grid"></i>书写医嘱</a></li> 

                <li> <a href="doctorMedicine.aspx"> <i class="fa fa-bar-chart"></i>开药</a></li>
                
                <li> <a href="doctorOperation.aspx"> <i class="fa fa-map-o"></i>安排手术</a></li>
                
                <li> <a href="doctorExamin.aspx"> <i class="icon-grid"></i>安排检查</a></li> 

                 
            </ul>
            
        </nav>

        <div class="content-inner form-cont">
            <div class="row">
                <div class="col-md-12">

                    <!--***** BASIC FORM *****-->
                    <div class="card form" id="form1">
                        <div class="card-header">
                            <h3>开药</h3>
                        </div>
                     <div class="col-md-12">
                        <div class="panel panel-default" >
                          
                         
                                <div class="table-responsive">
                                    <table class="table-responsive" style ="width:900px;height:400px" cellpadding="0">
                                            <tr class="bg-info text-white">
                                              <td class="table-bordered td text-center "><strong>病人编号</strong></td>
                                              <td class="table-bordered td text-center "><strong>药品编号</strong></td>
                                              <td class="table-bordered td text-center "><strong>数量</strong></td>
                                              <td class="table-bordered td text-center "><strong>医生编号</strong></td>
                                              <td class="table-bordered td text-center "><strong>订单编号</strong></td>
                                              <td class="table-bordered td text-center "><strong>药品名</strong></td>
                                           </tr>
                                          <tr>
                                              <td><asp:TextBox ID="patient_num1" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination_num1" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination1" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                               <td><asp:TextBox ID="doctor1" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="order1" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="time1" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                           </tr>
                                            <tr>
                                              <td><asp:TextBox ID="patient_num2" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination_num2" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination2" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                               <td><asp:TextBox ID="doctor2" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="order2" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="time2" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                           </tr>
  <tr>
                                              <td><asp:TextBox ID="patient_num3" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination_num3" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination3" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                               <td><asp:TextBox ID="doctor3" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="order3" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="time3" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                           </tr>
  <tr>
                                              <td><asp:TextBox ID="patient_num4" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination_num4" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination4" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                               <td><asp:TextBox ID="doctor4" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="order4" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="time4" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                           </tr>
  <tr>
                                              <td><asp:TextBox ID="patient_num5" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination_num5" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination5" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                               <td><asp:TextBox ID="doctor5" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="order5" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="time5" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                           </tr>
  <tr>
                                              <td><asp:TextBox ID="patient_num6" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination_num6" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination6" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                               <td><asp:TextBox ID="doctor6" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="order6" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="time6" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                           </tr>
  <tr>
                                              <td><asp:TextBox ID="patient_num7" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination_num7" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination7" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                               <td><asp:TextBox ID="doctor7" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="order7" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="time7" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                           </tr>
  <tr>
                                              <td><asp:TextBox ID="patient_num8" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination_num8" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination8" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                               <td><asp:TextBox ID="doctor8" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="order8" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="time8" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                           </tr>
  <tr>
                                              <td><asp:TextBox ID="patient_num9" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination_num9" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination9" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                               <td><asp:TextBox ID="doctor9" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="order9" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="time9" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                           </tr>
  <tr>
                                              <td><asp:TextBox ID="patient_num10" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination_num10" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="examination10" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                               <td><asp:TextBox ID="doctor10" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="order10" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                              <td><asp:TextBox ID="time10" runat="server" class="table-bordered td text-center" Width ="100%" Height ="100%"></asp:TextBox></td>
                                           </tr>
                                        
                                    </table>
                                    <br/>
                                    <div style ="margin-left :350px;margin-bottom :2cm">
                                        <asp:Button  ID="ok" runat="server" text="确定" class="btn btn-outline-primary" OnClick="ok_Click"/>
                                       
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
        new Chart(document.getElementById("myChart4").getContext('2d'), {
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
    </script>
    
    <script>
      var d = new Date();
      var todaysDate = d.getDate();
      var target = $('#calendar .week .day .date');

      target.each(function() {
          var day = $(this).html();
          if (todaysDate == day) {
              $(this).addClass('today');
          }
          if (todaysDate < day) {
              $(this).parent().addClass('future');
          }
          if (todaysDate >= day) {
              $(this).parent().addClass('past')
          }
      });

      // handle clicks on days

      $('.day').click(function() {
          if ($(this).hasClass('future')) {
              $('#modal').addClass('active');
              $('#modal .wrapper .content .box').html("<h2>Naughty, naughty.</h2> <p>You can't look early! Check back on that day to see what I've left for you.</p>");
          }
          if ($(this).hasClass('past')) {
              var content = $(this).children('.surprise').html();
              $('#modal').addClass('active');
              $('#modal .wrapper .content .box').html('');
              $('#modal .wrapper .content .box').html(content);
          }
      })

      // close modal

      $('.close').click(function() {
          var ultimateParent = $(this).parent().parent().parent();
          ultimateParent.addClass('moveOut');
          setTimeout(function() {
              ultimateParent.removeClass('moveOut').removeClass('active');
          }, 250);
      })

      // snow effect customizations

      $(document).snowfall({ flakeCount: 100, collection: '.collectonme', maxSpeed: 10 });
    </script> 
         </form>
</body>
</html>
