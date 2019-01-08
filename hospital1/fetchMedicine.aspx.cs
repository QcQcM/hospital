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




   /* protected void searchOrders_Click(object sender, EventArgs e)
    {
        notFetchOrders.DataSource = DatabaseTool.ExecSqlReturnDataSet(String.Format("select* from orders where patient_num=\"{0}\" and isfetch=0 and type=1",patientNum.Text));
        notFetchOrders.DataBind();
    }*/

  /*  protected void fetch_Click(object sender, EventArgs e)
    {
        List<FetchRecords> fetchRecords = new List<FetchRecords>();
        for(int i = 0; i < this.notFetchOrders.Rows.Count; i++)
        {
            if (((CheckBox)notFetchOrders.Rows[i].FindControl("select")).Checked)
            {
                FetchRecords f = new FetchRecords();
                f.PatientNum = notFetchOrders.Rows[i].Cells[1].Text.ToString();
                f.FetchTime = System.DateTime.Now.ToString();
                f.Person = fetchPerson.Text;
                f.medName = notFetchOrders.Rows[i].Cells[5].Text.ToString();
                f.Amount = Convert.ToInt32(notFetchOrders.Rows[i].Cells[4].Text);
                f.PatientName = DatabaseTool.ExeclSqlReturnItem(String.Format("select * from patient where p_number =\"{0}\" ", f.PatientName), "p_name").ToString();
                f.MedcineNum = notFetchOrders.Rows[i].Cells[6].Text.ToString();
                f.OrderNum = notFetchOrders.Rows[i].Cells[7].Text.ToString();
                fetchRecords.Add(f);
            }
        }
        if (FetchRecordService.AddFetchRecords(fetchRecords) > 0)
        {
            Response.Write("<script language=javascript>window.alert('取药成功！');</script>");
            notFetchOrders.DataSource = DatabaseTool.ExecSqlReturnDataSet(String.Format("select* from orders where patient_num=\"{0}\" and isfetch=0 and type=1", patientNum.Text));
            notFetchOrders.DataBind();
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('存在取药数量大于库存量失败的取药记录！');</script>");
            notFetchOrders.DataSource = DatabaseTool.ExecSqlReturnDataSet(String.Format("select* from orders where patient_num=\"{0}\" and isfetch=0 and type=1", patientNum.Text));
            notFetchOrders.DataBind();
        }
           
    }*/

    protected void searchOrders_Click1(object sender, EventArgs e)
    {
        notFetchOrders.DataSource = DatabaseTool.ExecSqlReturnDataSet(String.Format("select* from orders where patient_num=\"{0}\" and isfetch=0 and type=1", patientNum.Text));
        notFetchOrders.DataBind();
    }

    protected void fetch_Click1(object sender, EventArgs e)
    {
        List<FetchRecords> fetchRecords = new List<FetchRecords>();
        for (int i = 0; i < this.notFetchOrders.Rows.Count; i++)
        {
            if (((CheckBox)notFetchOrders.Rows[i].FindControl("select")).Checked)
            {
                FetchRecords f = new FetchRecords();
                f.PatientNum = notFetchOrders.Rows[i].Cells[1].Text.ToString();
                f.FetchTime = System.DateTime.Now.ToString();
                f.Person = fetchPerson.Text;
                f.medName = notFetchOrders.Rows[i].Cells[5].Text.ToString();
                f.Amount = Convert.ToInt32(notFetchOrders.Rows[i].Cells[4].Text);
                f.PatientName = DatabaseTool.ExeclSqlReturnItem(String.Format("select * from patient where p_number =\"{0}\" ", f.PatientName), "p_name").ToString();
                f.MedcineNum = notFetchOrders.Rows[i].Cells[6].Text.ToString();
                f.OrderNum = notFetchOrders.Rows[i].Cells[7].Text.ToString();
                fetchRecords.Add(f);
            }
        }
        if (FetchRecordService.AddFetchRecords(fetchRecords) > 0)
        {
            Response.Write("<script language=javascript>window.alert('取药成功！');</script>");
            notFetchOrders.DataSource = DatabaseTool.ExecSqlReturnDataSet(String.Format("select* from orders where patient_num=\"{0}\" and isfetch=0 and type=1", patientNum.Text));
            notFetchOrders.DataBind();
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('存在取药数量大于库存量失败的取药记录！');</script>");
            notFetchOrders.DataSource = DatabaseTool.ExecSqlReturnDataSet(String.Format("select* from orders where patient_num=\"{0}\" and isfetch=0 and type=1", patientNum.Text));
            notFetchOrders.DataBind();
        }

    }
}