using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WithoutMvpPatternAndNinject
{
    public partial class Employees : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities entities = new NorthwindEntities();

            this.EmployeesGridView.DataSource = entities.Employees.ToList();
            this.EmployeesGridView.DataBind();
        }
    }
}