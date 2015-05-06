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

public partial class AdminFOODITEM_MASTERInsertUpdate : System.Web.UI.Page
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
            loadLocation();
            loadAGENT();
            if (Request.QueryString["fOODITEM_MASTERID"] != null)
            {
                int fOODITEM_MASTERID = Int32.Parse(Request.QueryString["fOODITEM_MASTERID"]);
                if (fOODITEM_MASTERID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showFOODITEM_MASTERData();
                }
            }
        }
    }

    private void loadLocation()
    {

        List<LOCATIONGROUP> lOCATIONs = new List<LOCATIONGROUP>();
        lOCATIONs = LOCATIONGROUPManager.GetAllLOCATIONGROUPsFood();
        foreach (LOCATIONGROUP lOCATION in lOCATIONs)
        {
            ListItem litems = new ListItem(lOCATION.GROUPNAME.ToString(), lOCATION.LOCATIONGROUPID.ToString());
            ddlLocation.Items.Add(litems);
        }
        ddlLocation.DataBind();
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        FOODITEM_MASTER fOODITEM_MASTER = new FOODITEM_MASTER();

        fOODITEM_MASTER.ITEMCODE = txtITEMCODE.Text;
        fOODITEM_MASTER.ITEMNAME = txtITEMNAME.Text;
        fOODITEM_MASTER.RATE = decimal.Parse(txtRATE.Text);
        fOODITEM_MASTER.AGENTID = 4;
        fOODITEM_MASTER.SEQ = Int32.Parse(ddlLocation.SelectedValue);
        int resutl = FOODITEM_MASTERManager.InsertFOODITEM_MASTER(fOODITEM_MASTER);
        Response.Redirect("AdminFOODITEM_MASTERDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        FOODITEM_MASTER fOODITEM_MASTER = new FOODITEM_MASTER();
        fOODITEM_MASTER = FOODITEM_MASTERManager.GetFOODITEM_MASTERByID(Int32.Parse(Request.QueryString["fOODITEM_MASTERID"]));
        FOODITEM_MASTER tempFOODITEM_MASTER = new FOODITEM_MASTER();
        tempFOODITEM_MASTER.FOODITEM_MASTERID = fOODITEM_MASTER.FOODITEM_MASTERID;

        tempFOODITEM_MASTER.ITEMCODE = txtITEMCODE.Text;
        tempFOODITEM_MASTER.ITEMNAME = txtITEMNAME.Text;
        tempFOODITEM_MASTER.RATE = decimal.Parse(txtRATE.Text);
        tempFOODITEM_MASTER.AGENTID = 4;
        tempFOODITEM_MASTER.SEQ = Int32.Parse(ddlLocation.SelectedValue);
        bool result = FOODITEM_MASTERManager.UpdateFOODITEM_MASTER(tempFOODITEM_MASTER);
        Response.Redirect("AdminFOODITEM_MASTERDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtITEMCODE.Text = "";
        txtITEMNAME.Text = "";
        txtRATE.Text = "";
        
        txtSEQ.Text = "";
    }
    private void showFOODITEM_MASTERData()
    {
        FOODITEM_MASTER fOODITEM_MASTER = new FOODITEM_MASTER();
        fOODITEM_MASTER = FOODITEM_MASTERManager.GetFOODITEM_MASTERByID(Int32.Parse(Request.QueryString["fOODITEM_MASTERID"]));

        txtITEMCODE.Text = fOODITEM_MASTER.ITEMCODE;
        txtITEMNAME.Text = fOODITEM_MASTER.ITEMNAME;
        txtRATE.Text = fOODITEM_MASTER.RATE.ToString();
        
        ddlLocation.SelectedValue = fOODITEM_MASTER.SEQ.ToString();
    }
    private void loadAGENT()
    {
        
    }
}
