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

public class AGENTManager
{
	public AGENTManager()
	{
	}

    public static List<AGENT> GetAllAGENTs()
    {
        List<AGENT> aGENTs = new List<AGENT>();
        SqlAGENTProvider sqlAGENTProvider = new SqlAGENTProvider();
        aGENTs = sqlAGENTProvider.GetAllAGENTs();
        return aGENTs;
    }

    public static List<AGENT> GetAllAGENTsForSearchByID(int agentID)
    {
        List<AGENT> aGENTs = new List<AGENT>();
        SqlAGENTProvider sqlAGENTProvider = new SqlAGENTProvider();
        aGENTs = sqlAGENTProvider.GetAllAGENTsForSearchByID(agentID);
        return aGENTs;
    }

    public static List<AGENT> GetAllAGENTsForReport()
    {
        List<AGENT> aGENTs = new List<AGENT>();
        SqlAGENTProvider sqlAGENTProvider = new SqlAGENTProvider();
        aGENTs = sqlAGENTProvider.GetAllAGENTsForReport();
        return aGENTs;
    }

    public static List<AGENT> GetAllAGENTsForReportByDatenAmount(string fromDate, string toDate, int amount)
    {
        List<AGENT> aGENTs = new List<AGENT>();
        SqlAGENTProvider sqlAGENTProvider = new SqlAGENTProvider();
        aGENTs = sqlAGENTProvider.GetAllAGENTsForReportByDatenAmount(fromDate,toDate, amount);
        return aGENTs;
    }

    public static List<AGENT> GetAllAGENTsForReportByDatenAmountnLocations(string locationIDs,string fromDate, string toDate, int amount)
    {
        List<AGENT> aGENTs = new List<AGENT>();
        SqlAGENTProvider sqlAGENTProvider = new SqlAGENTProvider();
        aGENTs = sqlAGENTProvider.GetAllAGENTsForReportByDatenAmountnLocationIDs(locationIDs, fromDate, toDate, amount);
        return aGENTs;
    }

    public static AGENT GetAGENTByID(int id)
    {
        AGENT aGENT = new AGENT();
        SqlAGENTProvider sqlAGENTProvider = new SqlAGENTProvider();
        aGENT = sqlAGENTProvider.GetAGENTByID(id);
        return aGENT;
    }

    public static AGENT GetAGENTByUserName(string userName)
    {
        AGENT aGENT = new AGENT();
        SqlAGENTProvider sqlAGENTProvider = new SqlAGENTProvider();
        aGENT = sqlAGENTProvider.GetAGENTByUserName(userName);
        return aGENT;
    }

    public static int InsertAGENT(AGENT aGENT)
    {
        SqlAGENTProvider sqlAGENTProvider = new SqlAGENTProvider();
        return sqlAGENTProvider.InsertAGENT(aGENT);
    }


    public static bool UpdateAGENT(AGENT aGENT)
    {
        SqlAGENTProvider sqlAGENTProvider = new SqlAGENTProvider();
        return sqlAGENTProvider.UpdateAGENT(aGENT);
    }

    public static bool DeleteAGENT(int aGENTID)
    {
        SqlAGENTProvider sqlAGENTProvider = new SqlAGENTProvider();
        return sqlAGENTProvider.DeleteAGENT(aGENTID);
    }
}
