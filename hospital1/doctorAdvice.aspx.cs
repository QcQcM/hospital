using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class doctorAdvice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Session["number"] == null)
            {
                Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
            }
        session.Text = Session["number"].ToString();
    }

    protected void ok_Click(object sender, EventArgs e)
    {
        int i, j;//i是type，0是治疗医嘱，1是出院医嘱
        if (type.SelectedItem.ToString().Equals("治疗医嘱"))
        {
            i = 0;
            j = DoctorsAdviceService.InsertDoctorsAdvice(doctor_num.Text, patient_num.Text, content.Text, i, doctor_name.Text);
            if (j != -1)
            {
                Response.Write("<script language=javascript>window.alert('成功插入医嘱！');</script>");
            }
        }
        else
        {
            i = 1;
            j = DoctorsAdviceService.InsertDoctorsAdvice(doctor_num.Text, patient_num.Text, content.Text, i, doctor_name.Text);
            if (j != -1)
            {
                Response.Write("<script language=javascript>window.alert('成功插入医嘱！');</script>");
            }
        }

    }
}