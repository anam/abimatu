using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvTRANS.DataSource = TRANSManager.GetAllTRANSsByTRANSDT_CUSTOMER(780, DateTime.Parse("16/01/2009"));
            gvTRANS.DataBind();
        }
    }
}