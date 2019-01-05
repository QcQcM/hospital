using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class searchFetchMedicine : System.Web.UI.Page
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
    public void addFetchRecords(List<FetchRecords> list)
    {
        //将已知的医嘱list动态输出至页面
        if (list == null)
        {
            return;
        }
        for (int i = 0; i < list.Count; i++)
        {
            //添加第一列：取药编号
            int tableRowNumber = i + 1; //表明当前行数
            TableRow tableRow = new TableRow();
            TableCell tableCell = new TableCell();
            Label fetchNum = new Label();
            tableCell.Controls.Add(fetchNum);
            tableRow.Cells.Add(tableCell);
            fetchNum.Text = list[i].Number.ToString();
            //添加第二列：取药人
            tableCell = new TableCell();
            Label person = new Label();
            tableCell.Controls.Add(person);
            tableRow.Cells.Add(tableCell);
            person.Text = list[i].Person.ToString();
            //添加第三列：所取药品名称
            tableCell = new TableCell();
            Label medNum = new Label();
            tableCell.Controls.Add(medNum);
            tableRow.Cells.Add(tableCell);
            medNum.Text = list[i].Name.ToString();
            //添加第四列：患者名
            tableCell = new TableCell();
            Label patientName = new Label();
            tableCell.Controls.Add(patientName);
            tableRow.Cells.Add(tableCell);
            patientName.Text = list[i].PatientName.ToString();
            //添加第五列：所取药品数量
            tableCell = new TableCell();
            Label amount = new Label();
            tableCell.Controls.Add(amount);
            tableRow.Cells.Add(tableCell);
            amount.Text = list[i].Amount.ToString();
            //添加第六列：患者编号
            tableCell = new TableCell();
            Label patientNum = new Label();
            tableCell.Controls.Add(patientNum);
            tableRow.Cells.Add(tableCell);
            patientNum.Text = list[i].PatientNum.ToString();
            Table1.Rows.Add(tableRow);
        }
    }

        protected void Button2_Click1(object sender, EventArgs e)
    {
        List<FetchRecords> fetchRecords = new List<FetchRecords>();
        fetchRecords = FetchRecordService.QueryFetchByNum(patientId.Text);
        addFetchRecords(fetchRecords);
    }
}