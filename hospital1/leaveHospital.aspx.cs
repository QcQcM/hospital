using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leaveHospital : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        admissionDay.Visible = false;
        dischargeDay.Visible = false;
        lengthStay.Visible = false;
        diagnose.Visible = false;
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        //搜索
        Label1.Visible = true;
        Label2.Visible = true;
        Label3.Visible = true;
        Label4.Visible = true;
        Label5.Visible = true;
        Label6.Visible = true;

        List<PatientPart> patient_affirm_part = new List<PatientPart>();
        patient_affirm_part = PatientService.SearchPartInformation(Request["patientId"].ToString());
        Name.Text = patient_affirm_part[0].Name.ToString();
        Tel.Text = patient_affirm_part[0].Tel.ToString();
        Age.Text = patient_affirm_part[0].Age.ToString();
        Id.Text = Request["patientId"].ToString();
        Sex.Text = patient_affirm_part[0].Sex.ToString();
        Department.Text = patient_affirm_part[0].Department.ToString();
    }
     public void addAdvices(List<DoctorsAdvice> list){
        //将已知的医嘱list动态输出至页面
        if(list == null)
        {
            return;
        }
        for(int i = 0; i < list.Count; i++)
        {
            //添加第一列：医生编号
            int tableRowNumber= i + 1; //表明当前行数
            TableRow tableRow = new TableRow();
            TableCell tableCell = new TableCell();
            Label docNum = new Label();
            tableCell.Controls.Add(docNum);
            tableRow.Cells.Add(tableCell);
            docNum.Text = list[i].DoctorNum.ToString();
            //添加第二列：患者编号
            tableCell = new TableCell();
            Label patientNum = new Label();
            tableCell.Controls.Add(patientNum);
            tableRow.Cells.Add(tableCell);
            patientNum.Text = list[i].PatientNum.ToString();
            //添加第三列：时间
            tableCell = new TableCell();
            Label time = new Label();
            tableCell.Controls.Add(time);
            tableRow.Cells.Add(tableCell);
            time.Text = list[i].Time.ToString();
            //添加第四列：医嘱内容
            tableCell = new TableCell();
            Label content = new Label();
            tableCell.Controls.Add(content);
            tableRow.Cells.Add(tableCell);
            content.Text = list[i].Content.ToString();
            doctorAdvices.Rows.Add(tableRow);
            //添加第五列：医嘱类型
            tableCell = new TableCell();
            Label type = new Label();
            tableCell.Controls.Add(type);
            tableRow.Cells.Add(tableCell);
            if (list[i].Type == 0)
            {
                type.Text = "治疗医嘱";
            }
            else if (list[i].Type == 1)
            {
                type.Text = "出院医嘱";
            }
            else
            {
                type.Text = "未知医嘱类型";
            }
            //添加第六列：医生姓名
            tableCell = new TableCell();
            Label patientName = new Label();
            tableCell.Controls.Add(patientName);
            tableRow.Cells.Add(tableCell);
            patientName.Text = list[i].DoctorName.ToString();
            doctorAdvices.Rows.Add(tableRow);
        }

    }
    public void addOrders(List<Order> list)
    {
        if (list == null)
        {
            return;
        }
        for (int i = 0; i < list.Count; i++)
        {
            //添加第一列:订单编号
            int tableRowNumber = i + 1; //表明当前行数
            TableRow tableRow = new TableRow();
            TableCell tableCell = new TableCell();
            Label orderNum = new Label();
            tableCell.Controls.Add(orderNum);
            tableRow.Cells.Add(tableCell);
            orderNum.Text = list[i].orderNum.ToString();
            //添加第二列：医生编号
            tableCell = new TableCell();
            Label doctorNum = new Label();
            tableCell.Controls.Add(doctorNum);
            tableRow.Cells.Add(tableCell);
            doctorNum.Text = list[i].doctorNum.ToString();
            //添加第三列：数量
            tableCell = new TableCell();
            Label amount = new Label();
            tableCell.Controls.Add(amount);
            tableRow.Cells.Add(tableCell);
            amount.Text = list[i].Amount.ToString();
            //添加第四列：订单类型
            tableCell = new TableCell();
            Label type = new Label();
            tableCell.Controls.Add(type);
            tableRow.Cells.Add(tableCell);
            if (list[i].type ==1)
            {
                type.Text = "药品";
            }
            else if (list[i].type ==2)
            {
                type.Text = "手术";
            }
            else
            {
                type.Text = "检查";
            }
            //添加第五列：订单时间
            tableCell = new TableCell();
            Label orderTime = new Label();
            tableCell.Controls.Add(orderTime);
            tableRow.Cells.Add(tableCell);
            orderTime.Text = list[i].orderTime.ToString();
            //添加第六列：该手术或检查使用时间
            tableCell = new TableCell();
            Label useTime = new Label();
            tableCell.Controls.Add(useTime);
            tableRow.Cells.Add(tableCell);
            useTime.Text = list[i].useTime.ToString();
            //添加第六列：订单使用的药品或仪器名称
            tableCell = new TableCell();
            Label useName = new Label();
            tableCell.Controls.Add(useName);
            tableRow.Cells.Add(tableCell);
            useName.Text = list[i].useName.ToString();
            Table1.Rows.Add(tableRow);
                }
        }
   
        protected void Button1_Click(object sender, EventArgs e)
    {
        admissionDay.Visible = true;
        dischargeDay.Visible = true;
        lengthStay.Visible = true;
        diagnose.Visible = true;
        admissionDay1.Visible = true;
        dischargeDay1.Visible = true;
        lengthStay1.Visible = true;
        diagnose1.Visible = true;
        Table1.Visible = true;
        doctorAdvices.Visible = true;
       

        //打印出出院信息
        //获得其余出院信息
        LeaveInformation all_messages = new LeaveInformation();
        all_messages = PatientService.LeaveHospital(Request["patientId"].ToString());

        //补充其他个人信息
        admissionDay.Text = all_messages.Information.AdmissionTime.ToString();
        dischargeDay.Text = all_messages.Information.DischargeTime.ToString();
        diagnose.Text = all_messages.Information.Diagnose.ToString();

        //获得医生编号、建议、类型、治疗时间
        addAdvices(all_messages.Advices);
       

        //获得住院时长
        lengthStay.Text = all_messages.LengthStay.ToString();

        //全部订单信息
        addOrders(all_messages.Orders);
     
        //总费用
        totalprice.Text = all_messages.TotalPrice.ToString();
    }
}