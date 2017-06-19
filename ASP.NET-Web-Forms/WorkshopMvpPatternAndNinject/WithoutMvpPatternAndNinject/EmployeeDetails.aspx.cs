using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WithoutMvpPatternAndNinject
{
    public partial class EmployeeDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities entities = new NorthwindEntities();

            int id = int.Parse(this.Request.QueryString["id"]);
            this.DetailsView.DataSource = entities.Employees.Where(em => em.EmployeeID == id).ToList();
            this.DetailsView.DataBind();
        }
    }
}