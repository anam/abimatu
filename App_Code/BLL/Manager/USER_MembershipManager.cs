using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class USER_MembershipManager
{
	public USER_MembershipManager()
	{
	}

    public static DataSet  GetAllUSER_Memberships()
    {
       DataSet uSER_Memberships = new DataSet();
        SqlUSER_MembershipProvider sqlUSER_MembershipProvider = new SqlUSER_MembershipProvider();
        uSER_Memberships = sqlUSER_MembershipProvider.GetAllUSER_Memberships();
        return uSER_Memberships;
    }

	public static void uSER_MembershipsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
		{
		double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
		int pageCount = (int)Math.Ceiling(dblPageCount);
		List<ListItem> pages = new List<ListItem>();
		if (pageCount > 0)
		{
 		pages.Add(new ListItem("First", "1", currentPage > 1));
		for (int i = 1; i <= pageCount; i++)
		{
		 pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
		}
		pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
		}
		rptPager.DataSource = pages;
		rptPager.DataBind();
		}
 	public static void LoadUSER_MembershipPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlUSER_MembershipProvider sqlUSER_MembershipProvider = new SqlUSER_MembershipProvider();
		DataSet ds =  sqlUSER_MembershipProvider.GetUSER_MembershipPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 uSER_MembershipsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllUSER_Membership()
    {
       DataSet uSER_Memberships = new DataSet();
        SqlUSER_MembershipProvider sqlUSER_MembershipProvider = new SqlUSER_MembershipProvider();
        uSER_Memberships = sqlUSER_MembershipProvider.GetDropDownLisAllUSER_Membership();
        return uSER_Memberships;
    }


    public static USER_Membership GetUserRowStatusByRowStatusID(int RowStatusID)
    {
        USER_Membership uSER_Membership = new USER_Membership();
        SqlUSER_MembershipProvider sqlUSER_MembershipProvider = new SqlUSER_MembershipProvider();
        uSER_Membership = sqlUSER_MembershipProvider.GetUSER_MembershipByRowStatusID(RowStatusID);
        return uSER_Membership;
    }


    public static USER_Membership GetUSER_MembershipByRoleID(int RoleID)
    {
        USER_Membership uSER_Membership = new USER_Membership();
        SqlUSER_MembershipProvider sqlUSER_MembershipProvider = new SqlUSER_MembershipProvider();
        uSER_Membership = sqlUSER_MembershipProvider.GetUSER_MembershipByRoleID(RoleID);
        return uSER_Membership;
    }

    public static DataSet GetUSER_MembershipByID(string id)
    {
        DataSet uSER_Membership = new DataSet();
        SqlUSER_MembershipProvider sqlUSER_MembershipProvider = new SqlUSER_MembershipProvider();
        uSER_Membership = sqlUSER_MembershipProvider.GetUSER_MembershipByID(id);
        return uSER_Membership;
    }



    public static int InsertUSER_Membership(USER_Membership uSER_Membership)
    {
        SqlUSER_MembershipProvider sqlUSER_MembershipProvider = new SqlUSER_MembershipProvider();
        return sqlUSER_MembershipProvider.InsertUSER_Membership(uSER_Membership);
    }


    public static bool UpdateUSER_Membership(USER_Membership uSER_Membership)
    {
        SqlUSER_MembershipProvider sqlUSER_MembershipProvider = new SqlUSER_MembershipProvider();
        return sqlUSER_MembershipProvider.UpdateUSER_Membership(uSER_Membership);
    }

    public static bool DeleteUSER_Membership(int uSER_MembershipID)
    {
        SqlUSER_MembershipProvider sqlUSER_MembershipProvider = new SqlUSER_MembershipProvider();
        return sqlUSER_MembershipProvider.DeleteUSER_Membership(uSER_MembershipID);
    }

    public static bool unlockUSER_Membership(string userID)
    {
        SqlUSER_MembershipProvider sqlUSER_MembershipProvider = new SqlUSER_MembershipProvider();
        return sqlUSER_MembershipProvider.UnlockUSER_Membership(userID);
    }
}

