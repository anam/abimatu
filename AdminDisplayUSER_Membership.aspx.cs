using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
 

public partial class AdminDisplayUSER_Membership : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
       USER_MembershipManager.LoadUSER_MembershipPage(gvUSER_Membership, rptPager, 1, ddlPageSize);
      }
    }
     protected void PageSize_Changed(object sender, EventArgs e)
    {
   USER_MembershipManager.LoadUSER_MembershipPage(gvUSER_Membership,rptPager, 1, ddlPageSize);
 }
  protected void Page_Changed(object sender, EventArgs e)
    {
       int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
    USER_MembershipManager.LoadUSER_MembershipPage(gvUSER_Membership, rptPager, pageIndex, ddlPageSize);
   }
	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminUSER_Membership.aspx?ID=0");
	}
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
        if (USER_MembershipManager.unlockUSER_Membership(linkButton.CommandArgument))
        {
            USER_MembershipManager.LoadUSER_MembershipPage(gvUSER_Membership, rptPager, 1, ddlPageSize);
        }
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		bool result = USER_MembershipManager.DeleteUSER_Membership(Convert.ToInt32(linkButton.CommandArgument));
       USER_MembershipManager.LoadUSER_MembershipPage(gvUSER_Membership, rptPager, 1, ddlPageSize);
  	}
}

