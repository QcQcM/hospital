using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class doctorMedicine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
        }
        else         
        {
            session.Text = Session["number"].ToString();
        }
    }
    protected void sign_up_Click(object sender, EventArgs e)
    {
        Session["number"] = null;
        Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
    }

    protected void ok_Click(object sender, EventArgs e)
    {
        int i;
        int j = 1;//药品是1 手术是2 检查是3
        string[] patient_num = new string[] { patient_num1.Text, patient_num2.Text, patient_num3.Text, patient_num4.Text, patient_num5.Text, patient_num6.Text, patient_num7.Text, patient_num8.Text, patient_num9.Text, patient_num10.Text };
        string[] examination = new string[] { examination1.Text, examination2.Text, examination3.Text, examination4.Text, examination5.Text, examination6.Text, examination7.Text, examination8.Text, examination9.Text, examination10.Text };
        string[] examination_num = new string[] { examination_num1.Text, examination_num2.Text, examination_num3.Text, examination_num4.Text, examination_num5.Text, examination_num6.Text, examination_num7.Text, examination_num8.Text, examination_num9.Text, examination_num10.Text };
        string[] doctor = new string[] { doctor1.Text, doctor2.Text, doctor3.Text, doctor4.Text, doctor5.Text, doctor6.Text, doctor7.Text, doctor8.Text, doctor9.Text, doctor10.Text };
        string[] order = new string[] { order1.Text, order2.Text, order3.Text, order4.Text, order5.Text, order6.Text, order7.Text, order8.Text, order9.Text, order10.Text };
        string[] time = new string[] { time1.Text, time2.Text, time3.Text, time4.Text, time5.Text, time6.Text, time7.Text, time8.Text, time9.Text, time10.Text };

        int rowCount = 0;
        while(rowCount < 10)
        {
            if (patient_num[rowCount] == "")
            {
                break;
            }
            else
            {
                //先判断有没有空格
                if (examination[rowCount].Equals("") || doctor[rowCount].Equals("") || order[rowCount].Equals("") || time[rowCount].Equals("") || examination_num.Equals(""))
                {
                    Response.Write("<script language=javascript>window.alert('输入有空格！');window.location.href=('doctorMedicine.aspx');</script>");
                }
                //如果没有空格，可以检查主键是否冲突
                else
                {
                    if(OrderService.AddOrder(patient_num[rowCount], examination_num[rowCount], int.Parse(examination[rowCount]), doctor[rowCount], order[rowCount], j, time[rowCount])!=-1)
                    {
                        //如果主键不冲突，插入成功，当前插入行数加一，存入隐藏域
                        rowCount++;
                        message.Text ="输入的订单编号与数据库中重复，请重新输入，当前已成功插入"+ rowCount.ToString()+"行";
                    }
                    else
                    {
                        message.Visible = true;
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
    }
}