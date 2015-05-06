using System;
using System.Collections;
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

public partial class AdminLOCATIONGROUPDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (!User.Identity.IsAuthenticated)
            {
                Session.RemoveAll(); Response.Redirect("LogInPage.aspx");
            }
            else
            {
                reLoadSession();
            }
            showLOCATIONGROUPGrid();
        }
    }
    private void reLoadSession()
    {
        if (Session["userType"] == null || Session["aGENT"] != null || Session["lOCATION"] != null)
        {
            USERINFO userInfo = new USERINFO();
            userInfo = USERINFOManager.GetUSERINFOByUserNameType("Agent", User.Identity.Name);//"Agent" is dami in database i have not use the

            if (userInfo != null)
            {
                Session["userType"] = userInfo.Type.ToString();
                Session["userInfoID"] = userInfo.USERINFOID.ToString();
                Session["userName"] = userInfo.UserName.ToString();

                //if (userInfo.Agent_LocationID.ToString() == ddlAgent.SelectedItem.Value.ToString())
                if (userInfo.Type == "Agent")
                {
                    Session["aGENT"] = AGENTManager.GetAGENTByID(userInfo.Agent_LocationID);
                    Session["role"] = "Agent";
                }
                else if (userInfo.Type == "Location")
                {
                    Session["lOCATION"] = LOCATIONGROUPManager.GetLOCATIONGROUPByID(userInfo.Agent_LocationID);
                    Session["role"] = "Location";
                }

            }
        }
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton linkButton = new LinkButton();
            linkButton = (LinkButton)sender;
            int id;
            id = Convert.ToInt32(linkButton.CommandArgument);
            LOCATIONGROUP locationGroup = LOCATIONGROUPManager.GetLOCATIONGROUPByID(id);
            if (locationGroup != null)
            {
                txtGROUPNAME.Text = locationGroup.GROUPNAME;
                hdnGroupID.Value = locationGroup.LOCATIONGROUPID.ToString();
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
            }
        }
        catch { }
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = LOCATIONGROUPManager.DeleteLOCATIONGROUP(Convert.ToInt32(linkButton.CommandArgument));
        showLOCATIONGROUPGrid();
    }

    private void showLOCATIONGROUPGrid()
    {
        gvLOCATIONGROUP.DataSource = LOCATIONGROUPManager.GetAllLOCATIONGROUPs();
        gvLOCATIONGROUP.DataBind();
        btnUpdate.Visible = false;
        btnAdd.Visible = true;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            LOCATIONGROUP lOCATIONGROUP = new LOCATIONGROUP();

            lOCATIONGROUP.ADDEDDATE = DateTime.Now;
            lOCATIONGROUP.GROUPNAME = txtGROUPNAME.Text;
            int resutl = LOCATIONGROUPManager.InsertLOCATIONGROUP(lOCATIONGROUP);
            if (resutl > 0)
            {
                lblErr.Text = "successfully added!";
                btnClear_Click(null, null);
                showLOCATIONGROUPGrid();
            }
        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message;
        }

        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
        LOCATIONGROUP lOCATIONGROUP = new LOCATIONGROUP();
        lOCATIONGROUP = LOCATIONGROUPManager.GetLOCATIONGROUPByID(Int32.Parse(hdnGroupID.Value));
        LOCATIONGROUP tempLOCATIONGROUP = new LOCATIONGROUP();
        tempLOCATIONGROUP.LOCATIONGROUPID = lOCATIONGROUP.LOCATIONGROUPID;

        tempLOCATIONGROUP.ADDEDDATE = DateTime.Now;
        tempLOCATIONGROUP.GROUPNAME = txtGROUPNAME.Text;
        bool result = LOCATIONGROUPManager.UpdateLOCATIONGROUP(tempLOCATIONGROUP);
        if (result == true)
        {
            lblErr.Text = "successfully updated!";
            btnClear_Click(null, null);
            showLOCATIONGROUPGrid();
        }
        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {      
        txtGROUPNAME.Text = string.Empty;
    }
}
