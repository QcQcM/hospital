<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admissionRegistration.aspx.cs" Inherits="admissionRegistration" %>


<!DOCTYPE html>
<html>

<head>
    
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="robots" content="all,follow">

    <title>入院登记 </title>
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
    
<!--====================================================
                     MAIN NAVBAR
======================================================-->
<form runat="server">
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
                    <li class="nav-item d-flex align-items-center"><a id="menu-toggle-right" class="nav-link" href="#"><i class="fa fa-bars"></i></a>
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
                    </li>
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
                <asp:ImageButton runat="server" ID="sign_up" style="background-image:url(./img/logout/zhuxiao.png);margin-left:20px;margin-bottom:7px" OnClick="sign_up_Click"  CausesValidation="false"/>
            </div>
            <hr>
            <!-- Sidebar Navidation Menus-->
            <ul class="list-unstyled">
                <li> <a href="admissionRegistration.aspx"><i class="icon-home"></i>入院登记</a></li>
                <li>
                    <a href="#apps" aria-expanded="false" data-toggle="collapse">
                        <i class="icon-interface-windows"></i>查询病人记录 </a>
                    <ul id="apps" class="collapse list-unstyled">
                        <li><a href="searchPatientInformation.aspx">查询病人病例信息</a></li>
                        <li><a href="searchFetchMedicine.aspx">取药记录</a></li>
                    </ul>
                </li>
               <li> <a href="leaveHospital.aspx"> <i class="fa fa-bar-chart"></i>出院计费 </a></li>
            </ul>
        </nav>

        <div class="content-inner form-cont">
            <div class="row">
                <div class="col-md-12">

                    <!--***** 个人信息 *****-->
                       
                    <div class="card form" >
                        <div class="card-header">
                            <h3>个人信息</h3>
                        </div>
                        <br />
                        <div class="row" style="padding-left:20px">
                            <div class="col-md-6">
                                <div class="form-group row">
                                    <label for="name" style="width: 85px;" class=" col-form-label">姓名</label>
                                    <div class="col-9">
                                        <asp:TextBox ID="name" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Re1" ControlToValidate ="name"  runat ="server" ErrorMessage="必须填写姓名" Display ="Dynamic" ForeColor="Red"/>
                                    </div>
                                </div>
                                   <div class="form-group row">
                                    <label for="sex" style="width: 85px;" class=" col-form-label">性别</label>
                                    <div class="col-9">
                                        <asp:DropDownList ID="sex" runat="server" >
                                            <asp:ListItem>男</asp:ListItem>
                                            <asp:ListItem>女</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                       <asp:RequiredFieldValidator ID="Re5" ControlToValidate ="sex"  runat ="server" ErrorMessage="必须填写性别" Display ="Dynamic" ForeColor="Red"/>
                                </div>
                                <div class="form-group row">
                                    <label for="job" style="width: 85px;" class=" col-form-label">职业</label>
                                    <div class="col-9">
                                        <asp:TextBox ID="job" runat="server"  CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="minzu" style="width: 85px;" class=" col-form-label">民族</label>
                                    <div class="col-9">
                                        <asp:TextBox ID="nation" runat="server"  CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="tel" style="width: 85px;" class=" col-form-label">手机</label>
                                    <div class="col-9">
                                        <asp:TextBox ID="Tel" runat="server"  CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate ="Tel"  runat ="server" ErrorMessage="必须填写手机号" Font-Bold ="true" Display ="Dynamic"/>
                                        
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="id" style="width: 85px;" class=" col-form-label">身份证号</label>
                                    <div class="col-9">
                                        <asp:TextBox ID="idNum" runat="server"  CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req2" ControlToValidate ="idNum"  runat ="server" ErrorMessage="必须填写身份证号"  Display ="Dynamic" ForeColor="Red"/>
                                           <asp:RegularExpressionValidator  ID="RegularExpressionValidator1" runat="server"  ControlToValidate="idNum" Display="Dynamic" ValidationExpression="^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$" ErrorMessage="请输入格式正确的身份证号" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                 <div class="form-group row">
                                    <label for="age" style="width: 85px;" class=" col-form-label">年龄</label>
                                    <div class="col-9">
                                        <asp:TextBox ID="Age" runat="server"  CssClass="form-control"></asp:TextBox>
                                       <asp:RangeValidator ID="rev2" runat ="server" Type="Integer"  Display ="Dynamic" ForeColor="Red" ErrorMessage ="年龄必须在1-120之间" ControlToValidate ="Age" MaximumValue ="150" MinimumValue ="1" />
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="nationality" style="width: 85px;" class=" col-form-label">国籍</label>
                                    <div class="col-9">
                                       <asp:TextBox ID="nationality" runat="server"  CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="marriage" style="width: 85px;" class=" col-form-label">婚姻状况</label>
                                    <div class="col-9">
                                        <asp:DropDownList ID="MarriageList" runat="server" >
                                            <asp:ListItem>已婚</asp:ListItem>
                                            <asp:ListItem>未婚</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Re4" ControlToValidate ="MarriageList"  runat ="server" ErrorMessage="必须填写婚姻状况" Display ="Dynamic" ForeColor="Red"/>
                                    </div>
                                </div>   
                            </div>
                            <div class="col-md-6">
                                 <div class="form-group row">
                                    <label for="jiguan" style="width: 85px;" class=" col-form-label">籍贯</label>
                                    <div class="col-9">
                                        <asp:DropDownList ID="NativeProvinceList" runat="server"  style="width: 74px" >
                                        </asp:DropDownList>
                                        <label for="sheng" style="width: 20px;">省</label>
                                        <asp:RequiredFieldValidator ID="Rev5" ControlToValidate ="NativeProvinceList"  runat ="server" ErrorMessage="必须填写籍贯" Display ="Dynamic" ForeColor="Red"/>

                                        <asp:DropDownList ID="NativeCityList" runat="server" >
                                        </asp:DropDownList>

                                        <label for="shi" style="width: 20px;">市</label>
                                        <asp:RequiredFieldValidator ID="Re6" ControlToValidate ="NativeCityList"  runat ="server" ErrorMessage="必须填写籍贯" Display ="Dynamic" ForeColor="Red"/>
                                    </div>
                                </div>
                                 <div class="form-group row">
                                    <label for="example-datetime-local-input" style="width: 85px;" class=" col-form-label">出生日期</label>
                                    <div class="col-9">
                                        <asp:TextBox TextMode="Date" runat="server" ID="birthDate" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="example-text-input" style="width: 85px;" class=" col-form-label">出生地</label>
                                    <div class="col-9">
                                        <asp:DropDownList ID="BirthProvince" runat="server"  >
                                            <asp:ListItem>江西</asp:ListItem>
                                            <asp:ListItem>直辖</asp:ListItem>
                                        </asp:DropDownList>
                                        
                                        <label for="sheng" style="width: 20px;">省</label>
                                        <asp:DropDownList ID="BirthCity" runat="server" >
                                            <asp:ListItem>天津</asp:ListItem>
                                            <asp:ListItem>景德镇</asp:ListItem>
                                        </asp:DropDownList>
                                       
                                </div>
                                <div class="form-group row">
                                    <label for="example-month-input" style="width: 85px;" class=" col-form-label">现住址</label>
                                    <div class="col-9">
                                      <asp:TextBox ID="livingAddress" runat="server" TextMode="MultiLine" Width="350px" CssClass="form-control"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="Re9" ControlToValidate ="livingAddress"  runat ="server" ErrorMessage="必须填写现住址" Display ="Dynamic" ForeColor="Red"/>
                                    </div>
                                </div>  
                                <div class="form-group row">
                                    <label for="example-color-input" style="width: 85px;" class=" col-form-label">单位电话</label>
                                    <div class="col-9">
                                     <asp:TextBox ID="workingTel" runat="server" Width="350px" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>                             
                                <div class="form-group row">
                                    <label for="example-month-input" style="width: 85px;" class=" col-form-label"  >工作单位及地址</label>
                                    <div class="col-9">
                                        <asp:TextBox ID="workingAddress" runat="server" TextMode="MultiLine" Width="350px" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                                <div class="form-group row">
                                    <label for="example-month-input" style="width: 85px;" class=" col-form-label"  >编号</label>
                                    <div class="col-9">
                                        <asp:TextBox ID="patientNum" runat="server" Width="350px" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Re10" ControlToValidate ="patientNum"  runat ="server" ErrorMessage="必须填写病人编号" Display ="Dynamic" ForeColor="Red"/>
                                </div>
                            </div>
                        </div>
                        </div>        
                     </div>   
                     
                      <div class="card form" >
                        <div class="card-header">
                            <h3>入院信息</h3>
                        </div> 
                             
                                <div class="form-group row" style="margin-top:80px">
                                    <label for="example-datetime-local-input" style="width: 250px;" class=" col-form-label">主治医师</label>
                                    <div class="col-9">
                                        <asp:DropDownList ID="physician" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate ="physician"  runat ="server" ErrorMessage="必须填写主治医师" Display ="Dynamic" ForeColor="Red"/>
                                    </div>
                                </div>                                
                                <div class="form-group row">
                                    <label for="example-color-input" style="width: 250px;" class=" col-form-label">过往病史</label>
                                    <div class="col-9">
                                        <asp:TextBox ID="illHistory" runat="server"  CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate ="illHistory"  runat ="server" ErrorMessage="必须填写过往病史" Display ="Dynamic" ForeColor="Red"/>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="example-color-input" style="width: 250px;" class=" col-form-label">入院诊断</label>
                                    <div class="col-9">
                                        <asp:TextBox ID="diagnosis" runat="server" CssClass="form-control" ></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="Req4" ControlToValidate ="diagnosis"  runat ="server" ErrorMessage="必须填写入院诊断" Display ="Dynamic" ForeColor="Red"/>
                                    </div>
                                </div>

                            </div>
                             <div class="form-group row" style="margin-top:80px;margin-left:15px">
                                    <label for="example-search-input" style="width: 250px;" class=" col-form-label">入院科室</label>
                                    <div class="col-9">
                                        <asp:DropDownList ID="department" runat="server" border-color="white">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate ="department"  runat ="server" ErrorMessage="必须选择入院科室" Display ="Dynamic" ForeColor="Red"/>
                                    </div>
                                </div>
                                
                                <div class="form-group row" style="margin-left:15px">
                                    <label for="example-datetime-local-input" style="width: 250px;" class=" col-form-label">病房号</label>
                                    <div class="col-9">
                                        <asp:DropDownList ID="roomNumber" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate ="roomNumber"  runat ="server" ErrorMessage="必须填写病房号" Display ="Dynamic" ForeColor="Red"/>
                                    </div>
                                </div>
                                <div class="form-group row" style="margin-left:15px">
                                    <label for="example-datetime-local-input"style="width: 250px;" class=" col-form-label">病床号</label>
                                    <div class="col-9">
                                       <asp:DropDownList ID="bedNumber" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate ="bedNumber"  runat ="server" ErrorMessage="必须填写病床号" Display ="Dynamic" ForeColor="Red"/>
                                    </div>
                                </div>
                                <div class="form-group row" style="margin-left:15px">
                                    <label for="example-color-input" style="width: 250px;" class=" col-form-label">药物过敏情况</label>
                                    <div class="col-9">
                                        <asp:TextBox ID="allergicCondition" runat="server"  TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate ="allergicCondition"  runat ="server" ErrorMessage="必须填写药物过敏情况" Display ="Dynamic" ForeColor="Red"/>
                                    </div>
                                </div>              
                            </div>
                        </div>                      
                     </div> 
                    
                        <div style="position:relative;padding-left:600px">
                         <asp:Button runat="server" ID="ok" Text="确认登记" class="btn btn-primary" OnClick="ok_Click"  />
                            
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                    </div>
                 
                </div>
           


        </div>
    </div>
        </div>
 </form>
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
    </script>
   
</body>

</html>