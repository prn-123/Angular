using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibraryAssignmentTakingSystem;

namespace WebApplicationAssignment
{
    public partial class WebFormAssignment : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLAssignmentRepository Obj = new SQLAssignmentRepository();
            gvAssignment.DataSource = Obj.GetAssignment();
            DataBind();
        }
    }
}