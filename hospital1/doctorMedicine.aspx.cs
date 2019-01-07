using System;
using System.Collections.Generic;
using System.Data;
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
        DataTable dt = DatabaseTool.ExecSqlReturnTable("select * from medicine");
        examination_num1.DataSource = dt;
        examination_num1.DataTextField = "m_num";
        examination_num1.DataBind();
        examination_num2.DataSource = dt;
        examination_num2.DataTextField = "m_num";
        examination_num2.DataBind();
        examination_num3.DataSource = dt;
        examination_num3.DataTextField = "m_num";
        examination_num3.DataBind();
        examination_num4.DataSource = dt;
        examination_num4.DataTextField = "m_num";
        examination_num4.DataBind();
        examination_num5.DataSource = dt;
        examination_num5.DataTextField = "m_num";
        examination_num5.DataBind();
        examination_num6.DataSource = dt;
        examination_num6.DataTextField = "m_num";
        examination_num6.DataBind();
        examination_num7.DataSource = dt;
        examination_num7.DataTextField = "m_num";
        examination_num7.DataBind();
        examination_num8.DataSource = dt;
        examination_num8.DataTextField = "m_num";
        examination_num8.DataBind();
        examination_num9.DataSource = dt;
        examination_num9.DataTextField = "m_num";
        examination_num9.DataBind();
        examination_num10.DataSource = dt;
        examination_num10.DataTextField = "m_num";
        examination_num10.DataBind();
        //不可编辑的医生编号从session中获取，即当前用户的编号
        doctor1.Text = Session["doctorNum"].ToString();
        doctor2.Text = Session["doctorNum"].ToString();
        doctor3.Text = Session["doctorNum"].ToString();
        doctor4.Text = Session["doctorNum"].ToString();
        doctor5.Text = Session["doctorNum"].ToString();
        doctor6.Text = Session["doctorNum"].ToString();
        doctor7.Text = Session["doctorNum"].ToString();
        doctor8.Text = Session["doctorNum"].ToString();
        doctor9.Text = Session["doctorNum"].ToString();
        doctor10.Text = Session["doctorNum"].ToString();

    }
    protected void sign_up_Click(object sender, EventArgs e)
    {
        Session["number"] = null;
        Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
    }

    protected void ok_Click(object sender, EventArgs e)
    {
        int i=0,k;
        int j = 1;//药品是1 手术是2 检查是3
        string[] patient_num = new string[] { patient_num1.Text, patient_num2.Text, patient_num3.Text, patient_num4.Text, patient_num5.Text, patient_num6.Text, patient_num7.Text, patient_num8.Text, patient_num9.Text, patient_num10.Text };
        string[] examination = new string[] { examination1.Text, examination2.Text, examination3.Text, examination4.Text, examination5.Text, examination6.Text, examination7.Text, examination8.Text, examination9.Text, examination10.Text };
        string[] examination_num = new string[] { examination_num1.Text, examination_num2.Text, examination_num3.Text, examination_num4.Text, examination_num5.Text, examination_num6.Text, examination_num7.Text, examination_num8.Text, examination_num9.Text, examination_num10.Text };
        string[] doctor = new string[] { doctor1.Text, doctor2.Text, doctor3.Text, doctor4.Text, doctor5.Text, doctor6.Text, doctor7.Text, doctor8.Text, doctor9.Text, doctor10.Text };
        string[] order = new string[] { order1.Text, order2.Text, order3.Text, order4.Text, order5.Text, order6.Text, order7.Text, order8.Text, order9.Text, order10.Text };
        string[] time = new string[] { time1.Text, time2.Text, time3.Text, time4.Text, time5.Text, time6.Text, time7.Text, time8.Text, time9.Text, time10.Text };

        int rowCount = 0;
        for(rowCount =0;rowCount <10;rowCount ++)
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
                    /* if(OrderService.JudgeOrderDuplicate(order [rowCount])==-1)//-1有冲突
                     {
                         i = 1;break;
                     }
                     else
                     {
                         i = 0;//没冲突
                     }*/
                    OrderService.AddOrder(patient_num[rowCount ], examination_num[rowCount ], int.Parse(examination[rowCount ]), doctor[rowCount ], order[rowCount ], j, time[rowCount ]);
                    patient_num1.Text = ""; patient_num2.Text = ""; patient_num3.Text = ""; patient_num4.Text = ""; patient_num5.Text = ""; patient_num6.Text = ""; patient_num7.Text = ""; patient_num8.Text = ""; patient_num9.Text = ""; patient_num10.Text = "";
                    examination1.Text = ""; examination2.Text = ""; examination3.Text = ""; examination4.Text = ""; examination5.Text = ""; examination6.Text = ""; examination7.Text = ""; examination8.Text = ""; examination9.Text = ""; examination10.Text = "";
                    examination_num1.Text = ""; examination_num2.Text = ""; examination_num3.Text = ""; examination_num4.Text = ""; examination_num5.Text = ""; examination_num6.Text = ""; examination_num7.Text = ""; examination_num8.Text = ""; examination_num9.Text = ""; examination_num10.Text = "";
                    doctor1.Text = ""; doctor2.Text = ""; doctor3.Text = ""; doctor4.Text = ""; doctor5.Text = ""; doctor6.Text = ""; doctor7.Text = ""; doctor8.Text = ""; doctor9.Text = ""; doctor10.Text = "";
                    order1.Text = ""; order2.Text = ""; order3.Text = ""; order4.Text = ""; order5.Text = ""; order6.Text = ""; order7.Text = ""; order8.Text = ""; order9.Text = ""; order10.Text = "";
                    time1.Text = ""; time2.Text = ""; time3.Text = ""; time4.Text = ""; time5.Text = ""; time6.Text = ""; time7.Text = ""; time8.Text = ""; time9.Text = ""; time10.Text = "";
                }
            }
            
        }
        /*if(i==1)
        {
            Response.Write("<script language=javascript>window.alert('当前输入订单编号已存在，请重新检查！');</script>");
        }
        else
        {
            for(k=0;k<10;k++)
            {
                OrderService.AddOrder(patient_num[k], examination_num[k], int.Parse(examination[k]), doctor[k], order[k], j, time[k]);
                patient_num1.Text = ""; patient_num2.Text = ""; patient_num3.Text = ""; patient_num4.Text = ""; patient_num5.Text = ""; patient_num6.Text = ""; patient_num7.Text = ""; patient_num8.Text = ""; patient_num9.Text = ""; patient_num10.Text = "";
                examination1.Text = ""; examination2.Text = ""; examination3.Text = ""; examination4.Text = ""; examination5.Text = ""; examination6.Text = ""; examination7.Text = ""; examination8.Text = ""; examination9.Text = ""; examination10.Text = "";
                examination_num1.Text = ""; examination_num2.Text = ""; examination_num3.Text = ""; examination_num4.Text = ""; examination_num5.Text = ""; examination_num6.Text = ""; examination_num7.Text = ""; examination_num8.Text = ""; examination_num9.Text = ""; examination_num10.Text = "";
                doctor1.Text = ""; doctor2.Text = ""; doctor3.Text = ""; doctor4.Text = ""; doctor5.Text = ""; doctor6.Text = ""; doctor7.Text = ""; doctor8.Text = ""; doctor9.Text = ""; doctor10.Text = "";
                order1.Text = ""; order2.Text = ""; order3.Text = ""; order4.Text = ""; order5.Text = ""; order6.Text = ""; order7.Text = ""; order8.Text = ""; order9.Text = ""; order10.Text = "";
                time1.Text = ""; time2.Text = ""; time3.Text = ""; time4.Text = ""; time5.Text = ""; time6.Text = ""; time7.Text = ""; time8.Text = ""; time9.Text = ""; time10.Text = "";
            }
        }*/
       
        //清空数据
        
    }
}