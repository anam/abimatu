using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class LOCATIONManager
{
    public LOCATIONManager()
    {
    }

    public static List<LOCATION> GetAllLOCATIONs()
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONs();
        return lOCATIONs;
    }

    public static List<LOCATION> GetAllLOCATIONsFood()
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsFood();
        return lOCATIONs;
    }

    public static List<LOCATION> GetAllLOCATIONsNotInGroup()
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsNotInGroup();
        return lOCATIONs;
    }

    public static List<LOCATION> GetAllLOCATIONsByAgentID(int agentID)
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsByAgentID(agentID);
        return lOCATIONs;
    }

    public static List<LOCATION> GetAllLOCATIONsByAgentIDnGroupID(int agentID, int groupID)
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsByAgentIDnGroupID(agentID, groupID);
        return lOCATIONs;
    }

    public static List<LOCATION> GetAllLOCATIONsByGroupID(int groupID)
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsByGroupID(groupID);
        return lOCATIONs;
    }

    public static List<LOCATION> GetAllLOCATIONsNotInGroupByGroupID(int groupID)
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsNotInGroupByGroupID(groupID);
        return lOCATIONs;
    }

    public static List<LOCATION> GetAllLOCATIONsForSearchByID(int lOCATIONID)
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsForSearchByID(lOCATIONID);
        return lOCATIONs;
    }

    public static List<LOCATION> GetAllLOCATIONsCountry()
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsCountry();
        return lOCATIONs;
    }


    public static List<LOCATION> GetAllLOCATIONsForSearch(int agentID, string country, string city, string branch)
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsForSearch(agentID, country, city, branch);
        return lOCATIONs;
    }

    public static List<LOCATION> GetAllLOCATIONsForReportByDatenAmount(int agentID, string fromDate, string toDate, int amount)
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsByDatenAmount(agentID, fromDate, toDate, amount);
        return lOCATIONs;
    }

    public static List<LOCATION> GetAllLOCATIONsForReportByDatenAmountLocationIDs(string locationIDs, int agentID, string fromDate, string toDate, int amount)
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsByDatenAmountLocationIDs(locationIDs, agentID, fromDate, toDate, amount);
        return lOCATIONs;
    }

    public static List<LOCATION> GetAllLOCATIONsForReportByDatenAmountLocationIDsStatus(string status, string locationIDs, int agentID, string fromDate, string toDate, int amount)
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsByDatenAmountLocationIDsStatus(status, locationIDs, agentID, fromDate, toDate, amount);
        return lOCATIONs;
    }

    public static List<LOCATION> GetAllLOCATIONsForReportByDatenAmountCustomerIDs(string customerID, string receiverID, int agentID, string fromDate, string toDate, int amount)
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATIONs = sqlLOCATIONProvider.GetAllLOCATIONsForReportByDatenAmountCustomerIDs(customerID,receiverID, agentID, fromDate, toDate, amount);
        return lOCATIONs;
    }

    public static LOCATION GetLOCATIONByID(int id)
    {
        LOCATION lOCATION = new LOCATION();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATION = sqlLOCATIONProvider.GetLOCATIONByID(id);
        return lOCATION;
    }

    public static LOCATION GetLOCATIONByIDByAgentID(int id, int agentID)
    {
        LOCATION lOCATION = new LOCATION();
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        lOCATION = sqlLOCATIONProvider.GetLOCATIONByIDByAGNETID(id, agentID);
        return lOCATION;
    }

    public static int InsertLOCATION(LOCATION lOCATION)
    {
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        return sqlLOCATIONProvider.InsertLOCATION(lOCATION);
    }


    public static bool UpdateLOCATION(LOCATION lOCATION)
    {
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        return sqlLOCATIONProvider.UpdateLOCATION(lOCATION);
    }

    public static bool DeleteLOCATION(int lOCATIONID)
    {
        SqlLOCATIONProvider sqlLOCATIONProvider = new SqlLOCATIONProvider();
        return sqlLOCATIONProvider.DeleteLOCATION(lOCATIONID);
    }
}
