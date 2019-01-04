using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        int type;
        type = LoginService.indentifyUser(Request["username"].ToString(), Request["password"].ToString());
        if (type == -1)
        {
            Response.Write("<script>alert('用户或密码不正确！')</script>");
        }
        else if (type == 1)//住院部护士
        {
            Session["number"] = LoginService.returnName(Request["username"].ToString(), Request["password"].ToString());
            Response.Redirect("./admissionRegistration.aspx");
            //TO DO 第一类型，跳转至住院部护士首页

        }
          else if (type == 2)
        {
            Session["number"] = LoginService.returnName(Request["username"].ToString(), Request["password"].ToString());
            Response.Redirect("./addMedicine.aspx");
            //TO DO 第二类型，跳转至药房首页
        }
        else if(type ==3)
        {
            Session["number"] = LoginService.returnName(Request["username"].ToString(), Request["password"].ToString());
            Response.Redirect("./doctorMedicine.aspx");
            //第三类型 医生
        }
        else if (type ==4)
        {
            Session["number"] = LoginService.returnName(Request["username"].ToString(), Request["password"].ToString());
            Response.Redirect("./addDepartment.aspx");
            //第四类型 系统管理人员
        }
        else if (type ==5)
        {
            Session["number"] = LoginService.returnName(Request["username"].ToString(), Request["password"].ToString());
            Response.Redirect("./addDevice.aspx");
            //TO DO 第五类型，跳转至设备管理人员首页
        }
    }
}
