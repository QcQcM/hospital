using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class admissionRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
        }
        session.Text = Session["number"].ToString();
        //为籍贯和出生地的省下拉框绑定数据源
        DataTable dt = DatabaseTool.ExecSqlReturnTable("select * from province");
           NativeProvinceList.DataSource = dt;
           NativeProvinceList.DataTextField = "provinceName";
          NativeProvinceList.DataValueField = "provinceNum";
           NativeProvinceList.DataBind();
            BirthProvince.DataSource = dt;
            BirthProvince.DataTextField = "provinceName";
        BirthProvince.DataValueField = "provinceNum";
        BirthProvince.DataBind();

        //为籍贯和出生地的城市的下拉框绑定数据源
        dt = DatabaseTool.ExecSqlReturnTable("select * from city");
        NativeCityList.DataSource = dt;
        NativeCityList.DataTextField = "city_name";
        NativeCityList.DataValueField = "city_num";
        NativeCityList.DataBind();
        BirthCity.DataSource = dt;
        BirthCity.DataTextField = "city_name";
        BirthCity.DataValueField = "city_num";
        BirthCity.DataBind();

        //为这五个下拉框添加item0
        BirthCity.Items.Insert(0, "请选择市");
        NativeProvinceList.Items.Insert(0, "请选择省或直辖市");
        department.Items.Insert(0, "请选择科室");
        BirthProvince.Items.Insert(0, "请选择省或直辖市");
        NativeCityList.Items.Insert(0, "请选择市");

        //为科室下拉框绑定数据源
        dt = DatabaseTool.ExecSqlReturnTable("select * from department");
        department.DataSource = dt;
        department.DataTextField = "d_name";
        department.DataBind();
        
        
    }
    protected void sign_up_Click(object sender, EventArgs e)
    {
        Session["number"] = null;
        Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
    }
    protected void NativeProvinceList_SelectedIndexChanged(object sender, EventArgs e)
    {
       // Response.Write("<script>alert('我响应了！')</script>");
        String proID = this.NativeProvinceList.SelectedValue;
        this.NativeCityList.DataSource = DatabaseTool.ExecSqlReturnTable("select * from city where province_num= " + proID);
        this.NativeCityList.DataTextField = "city_name";
        this.NativeCityList.DataValueField = "number";
        NativeCityList.DataBind();
    }

    protected void NativeProvinceList_TextChanged(object sender, EventArgs e)
    {
    }

    protected void ok_Click(object sender, EventArgs e)
    {
        Patient patient = new Patient();
        patient.Id = this.patientNum.Text;
        patient.Name = this.name.Text;
        patient.Sex = this.sex.SelectedItem.ToString();
        patient.Age = Convert.ToInt32(this.Age.Text);
        patient.Tel = this.Tel.Text;
        patient.Department = this.department.Text;
        patient.DrugAllergy = this.allergicCondition.Text;
        patient.MedicalHistory = this.illHistory.Text;
        patient.RoomNum = roomNumber.Text;
        patient.BedNum = bedNumber.Text;
        patient.PhysicanNum = physician.Text;
        patient.AdmissionTime = adimissionDate.Text;
        patient.IDNum = idNum.Text;
        patient.BirthDate = birthDate.Text;
        patient.Nation = nation.Text;
        patient.Country = nationality.Text;
        patient.Marriage = MarriageList.Text;
        patient.Occupation = job.Text;
        patient.NativePlace = this.NativeProvinceList.Text + this.NativeCityList.Text;
        patient.BirthPlace = this.BirthProvince.Text + BirthCity.Text;
        patient.Address = livingAddress.Text;
        patient.WorkingPlace = workingAddress.Text;
        patient.WorkingTel = workingTel.Text;
        patient.Diagonse = diagnosis.Text;
        //邮编没有输入框，传了一个空字符串过去
        if (PatientService.AddPatient(patient) != -1)
        {
            Response.Write("<script language=javascript>window.alert('病人入院登记成功！');</script>");
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('该病人编号已存在，请输入其他编号！');</script>");
        }
    }
    
}