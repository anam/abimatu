using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
public partial class UserRegistrationPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            
        }
    }

    protected void btnBackup_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://abimatu.net/databackup/" + ACC_AccountingCommonManager.ProcessDataBackup());
    }
}