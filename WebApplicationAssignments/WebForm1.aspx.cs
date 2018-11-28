using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibraryAssignmentTakingSystem;

namespace WebApplicationAssignments
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SQLAssignmentRepository Obj = new SQLAssignmentRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillGrid();
                DropDownList1.DataSource = Obj.GetAssignment();
                DropDownList1.DataTextField = "AssignmentName";
                DropDownList1.DataValueField = "AssignmentId";
                DataBind();
            }
        }

        private void FillGrid()
        {
            if(!IsPostBack)
            { 
            gvAssignment.DataSource = Obj.GetAssignment();
            DataBind();
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            
            //Assignment a = new Assignment();
            //var a = Obj.FindAssignment(Int32.Parse(txtId.ToString()));
            //txtAssignmentName.Text = a.AssignmentName;
            //txtEmployeeName.Text = a.EmployeeName;
            //txtDate.Text = a.Date.ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = Obj.FindAssignment(Int32.Parse(DropDownList1.SelectedValue.ToString()));
            txtAssignmentName.Text = a.AssignmentName;
            txtEmployeeName.Text = a.EmployeeName;
            txtDate.Text = a.Date.ToString();
            FillGrid();
            btnSave.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Assignment a = new Assignment
            {
                AssignmentName = txtAssignmentName.Text,
                EmployeeName = txtEmployeeName.Text,
                Date = Convert.ToDateTime( txtDate.Text)
            };

            Obj.Insert(a);
            FillGrid();
            Response.Write("Record inserted");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            txtAssignmentName.Text = "";
            txtEmployeeName.Text = "";
            txtDate.Text = "";
        }
    }
}