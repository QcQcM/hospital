using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class fetchMedicine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
        }
        session.Text = Session["number"].ToString();
    }
    protected void sign_up_Click(object sender, EventArgs e)
    {
        Session["number"] = null;
        Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
    }

    protected void ok_Click1(object sender, EventArgs e)
    {
        int i;
        string[] patient_num = new string[] { patient_num1.Text, patient_num2.Text, patient_num3.Text, patient_num4.Text, patient_num5.Text, patient_num6.Text, patient_num7.Text, patient_num8.Text, patient_num9.Text, patient_num10.Text };
        string[] examination = new string[] { examination1.Text, examination2.Text, examination3.Text, examination4.Text, examination5.Text, examination6.Text, examination7.Text, examination8.Text, examination9.Text, examination10.Text };
        string[] examination_num = new string[] { examination_num1.Text, examination_num2.Text, examination_num3.Text, examination_num4.Text, examination_num5.Text, examination_num6.Text, examination_num7.Text, examination_num8.Text, examination_num9.Text, examination_num10.Text };
        string[] doctor = new string[] { doctor1.Text, doctor2.Text, doctor3.Text, doctor4.Text, doctor5.Text, doctor6.Text, doctor7.Text, doctor8.Text, doctor9.Text, doctor10.Text };
        string[] order = new string[] { order1.Text, order2.Text, order3.Text, order4.Text, order5.Text, order6.Text, order7.Text, order8.Text, order9.Text, order10.Text };
        string[] time = new string[] { time1.Text, time2.Text, time3.Text, time4.Text, time5.Text, time6.Text, time7.Text, time8.Text, time9.Text, time10.Text };
        string[] medNum = new string[] { med_num1.Text, med_num2.Text, med_num3.Text, med_num4.Text, med_num5.Text, med_num6.Text, med_num7.Text, med_num8.Text, med_num9.Text, med_num10.Text };

        for (i = 0; i < 10; i++)
        {
            if (patient_num[i] == "")
            {
                break;
            }
            else
            {
                if (examination[i].Equals("") || examination_num[i].Equals("") || doctor[i].Equals("") || order[i].Equals("") || time[i].Equals(""))
                {
                    Response.Write("<script language=javascript>window.alert('输入有空格！');window.location.href=('fetchMedicine.aspx');</script>");
                }
                else
                {
                    if (FetchRecordService.AddFetchRecords(patient_num[i], examination_num[i], examination[i], doctor[i], int.Parse(order[i]), time[i], medNum[i]) < 0)
                    {
                        Response.Write("<script language=javascript>window.alert('药品库存小于取药数量！取药失败');</script>");
                    }
                    else
                    {
                        Response.Write("<script language=javascript>window.alert('添加取药记录成功');</script>");
                    }
                }
            }
        }

        //清空数据
        patient_num1.Text = ""; patient_num2.Text = ""; patient_num3.Text = ""; patient_num4.Text = ""; patient_num5.Text = ""; patient_num6.Text = ""; patient_num7.Text = ""; patient_num8.Text = ""; patient_num9.Text = ""; patient_num10.Text = "";
        examination1.Text = ""; examination2.Text = ""; examination3.Text = ""; examination4.Text = ""; examination5.Text = ""; examination6.Text = ""; examination7.Text = ""; examination8.Text = ""; examination9.Text = ""; examination10.Text = "";
        examination_num1.Text = ""; examination_num2.Text = ""; examination_num3.Text = ""; examination_num4.Text = ""; examination_num5.Text = ""; examination_num6.Text = ""; examination_num7.Text = ""; examination_num8.Text = ""; examination_num9.Text = ""; examination_num10.Text = "";
        doctor1.Text = ""; doctor2.Text = ""; doctor3.Text = ""; doctor4.Text = ""; doctor5.Text = ""; doctor6.Text = ""; doctor7.Text = ""; doctor8.Text = ""; doctor9.Text = ""; doctor10.Text = "";
        order1.Text = ""; order2.Text = ""; order3.Text = ""; order4.Text = ""; order5.Text = ""; order6.Text = ""; order7.Text = ""; order8.Text = ""; order9.Text = ""; order10.Text = "";
        time1.Text = ""; time2.Text = ""; time3.Text = ""; time4.Text = ""; time5.Text = ""; time6.Text = ""; time7.Text = ""; time8.Text = ""; time9.Text = ""; time10.Text = "";
        med_num1.Text = ""; med_num2.Text = ""; med_num3.Text = ""; med_num4.Text = ""; med_num5.Text = ""; med_num6.Text = ""; med_num7.Text = ""; med_num8.Text = ""; med_num9.Text = ""; med_num10.Text = "";


    }
}