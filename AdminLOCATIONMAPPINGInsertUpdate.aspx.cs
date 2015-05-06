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

public partial class AdminLOCATIONMAPPINGInsertUpdate : System.Web.UI.Page
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

            showLOCATIONMAPPINGGrid();
            loadLOCATIONGROUP();
            if (Request.QueryString["lOCATIONMAPPINGID"] != null)
            {
                int lOCATIONMAPPINGID = Int32.Parse(Request.QueryString["lOCATIONMAPPINGID"]);
                if (lOCATIONMAPPINGID == 0)
                {
                    //loadLOCATION();
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    loadLOCATIONAll();
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showLOCATIONMAPPINGData();
                }
            }
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        LOCATIONMAPPING lOCATIONMAPPING = new LOCATIONMAPPING();

        lOCATIONMAPPING.ADDEDDATE = DateTime.Now;
        lOCATIONMAPPING.LOCATIONID = Int32.Parse(ddlLOCATION.SelectedValue);
        lOCATIONMAPPING.LOCATIONGROUPID = Int32.Parse(ddlLOCATIONGROUP.SelectedValue);
        int resutl = LOCATIONMAPPINGManager.InsertLOCATIONMAPPING(lOCATIONMAPPING);
        //Response.Redirect("AdminLOCATIONMAPPINGDisplay.aspx");
        showLOCATIONMAPPINGGrid();
        btnClear_Click(this, new EventArgs());
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        LOCATIONMAPPING lOCATIONMAPPING = new LOCATIONMAPPING();
        lOCATIONMAPPING = LOCATIONMAPPINGManager.GetLOCATIONMAPPINGByID(Int32.Parse(Request.QueryString["lOCATIONMAPPINGID"]));
        LOCATIONMAPPING tempLOCATIONMAPPING = new LOCATIONMAPPING();
        tempLOCATIONMAPPING.LOCATIONMAPPINGID = lOCATIONMAPPING.LOCATIONMAPPINGID;

        tempLOCATIONMAPPING.ADDEDDATE = DateTime.Now;
        tempLOCATIONMAPPING.LOCATIONID = Int32.Parse(ddlLOCATION.SelectedValue);
        tempLOCATIONMAPPING.LOCATIONGROUPID = Int32.Parse(ddlLOCATIONGROUP.SelectedValue);
        bool result = LOCATIONMAPPINGManager.UpdateLOCATIONMAPPING(tempLOCATIONMAPPING);
        Response.Redirect("AdminLOCATIONMAPPINGDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {

        ddlLOCATION.SelectedIndex = 0;
        ddlLOCATIONGROUP.SelectedIndex = 0;
    }
    private void showLOCATIONMAPPINGData()
    {
        LOCATIONMAPPING lOCATIONMAPPING = new LOCATIONMAPPING();
        lOCATIONMAPPING = LOCATIONMAPPINGManager.GetLOCATIONMAPPINGByID(Int32.Parse(Request.QueryString["lOCATIONMAPPINGID"]));

        ddlLOCATION.SelectedValue = lOCATIONMAPPING.LOCATIONID.ToString();
        ddlLOCATIONGROUP.SelectedValue = lOCATIONMAPPING.LOCATIONGROUPID.ToString();
    }

    private void loadLOCATIONAll()
    {
        ListItem li = new ListItem("Select LOCATION...", "0");
        ddlLOCATION.Items.Add(li);

        List<LOCATION> lOCATIONs = new List<LOCATION>();
        lOCATIONs = LOCATIONManager.GetAllLOCATIONs();
        foreach (LOCATION lOCATION in lOCATIONs)
        {
            string loc = lOCATION.COUNTRY + " > " + lOCATION.CITY + " > " + lOCATION.BRANCH;
            ListItem item = new ListItem(loc, lOCATION.LOCATIONID.ToString());
            ddlLOCATION.Items.Add(item);
        }
    }
    private void loadLOCATION()
    {
        ListItem li = new ListItem("Select LOCATION...", "0");
        ddlLOCATION.Items.Add(li);

        List<LOCATION> lOCATIONs = new List<LOCATION>();
        //lOCATIONs = LOCATIONManager.GetAllLOCATIONsNotInGroup();
        lOCATIONs = LOCATIONManager.GetAllLOCATIONs();
        foreach (LOCATION lOCATION in lOCATIONs)
        {
            string loc = lOCATION.COUNTRY + " > " + lOCATION.CITY + " > " + lOCATION.BRANCH;
            ListItem item = new ListItem(loc, lOCATION.LOCATIONID.ToString());
            ddlLOCATION.Items.Add(item);
        }
    }
    private void loadLOCATIONGROUP()
    {
        ListItem li = new ListItem("Select LOCATIONGROUP...", "0");
        ddlLOCATIONGROUP.Items.Add(li);

        List<LOCATIONGROUP> lOCATIONGROUPs = new List<LOCATIONGROUP>();
        lOCATIONGROUPs = LOCATIONGROUPManager.GetAllLOCATIONGROUPs();
        foreach (LOCATIONGROUP lOCATIONGROUP in lOCATIONGROUPs)
        {
            ListItem item = new ListItem(lOCATIONGROUP.GROUPNAME.ToString(), lOCATIONGROUP.LOCATIONGROUPID.ToString());
            ddlLOCATIONGROUP.Items.Add(item);
        }
    }
    protected void ddlLOCATIONGROUP_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlLOCATION.Items.Clear();
        ListItem li = new ListItem("Select LOCATION...", "0");
        ddlLOCATION.Items.Add(li);

        if (ddlLOCATIONGROUP.SelectedValue != "0")
        {
            List<LOCATION> lOCATIONs = new List<LOCATION>();
            //lOCATIONs = LOCATIONManager.GetAllLOCATIONsNotInGroup();
            lOCATIONs = LOCATIONManager.GetAllLOCATIONsNotInGroupByGroupID(int.Parse(ddlLOCATIONGROUP.SelectedValue));
            foreach (LOCATION lOCATION in lOCATIONs)
            {
                string loc = lOCATION.COUNTRY + " > " + lOCATION.CITY + " > " + lOCATION.BRANCH + " > " + lOCATION.BRANCH_CODE;
                ListItem item = new ListItem(loc, lOCATION.LOCATIONID.ToString());
                ddlLOCATION.Items.Add(item);
            }
        }
    }


    /*
     Display loction and groups
     * 
     */
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminLOCATIONMAPPINGInsertUpdate.aspx?lOCATIONMAPPINGID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = LOCATIONMAPPINGManager.DeleteLOCATIONMAPPING(Convert.ToInt32(linkButton.CommandArgument));
        showLOCATIONMAPPINGGrid();
    }

    private void showLOCATIONMAPPINGGrid()
    {
        gvLOCATIONMAPPING.DataSource = LOCATIONMAPPINGManager.GetAllLOCATIONMAPPINGs();
        gvLOCATIONMAPPING.DataBind();
        foreach (GridViewRow gvr in gvLOCATIONMAPPING.Rows)
        {
            Label lblLOCATIONID = gvr.FindControl("lblLOCATIONID") as Label;
            Label lblLOCATIONGROUPID = gvr.FindControl("lblLOCATIONGROUPID") as Label;

            LOCATION location = LOCATIONManager.GetLOCATIONByID(int.Parse(lblLOCATIONID.Text));
            if (location != null)
            {
                lblLOCATIONID.Text = location.COUNTRY + ", " + location.CITY + ", " + location.BRANCH;
            }

            LOCATIONGROUP locationGroup = LOCATIONGROUPManager.GetLOCATIONGROUPByID(int.Parse(lblLOCATIONGROUPID.Text));
            if (locationGroup != null)
            {
                lblLOCATIONGROUPID.Text = locationGroup.GROUPNAME;
            }
        }
    }
}
