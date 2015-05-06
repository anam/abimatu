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

public class FOODITEM_TRANSMASTERManager
{
	public FOODITEM_TRANSMASTERManager()
	{
	}

    public static List<FOODITEM_TRANSMASTER> GetAllFOODITEM_TRANSMASTERs()
    {
        List<FOODITEM_TRANSMASTER> fOODITEM_TRANSMASTERs = new List<FOODITEM_TRANSMASTER>();
        SqlFOODITEM_TRANSMASTERProvider sqlFOODITEM_TRANSMASTERProvider = new SqlFOODITEM_TRANSMASTERProvider();
        fOODITEM_TRANSMASTERs = sqlFOODITEM_TRANSMASTERProvider.GetAllFOODITEM_TRANSMASTERs();
        return fOODITEM_TRANSMASTERs;
    }

    public static List<FOODITEM_TRANSMASTER> GetAllFOODITEM_TRANSMASTERsForReport(string status, string locationIDs, int agentID, string fromDate, string toDate, int amount)
    {
        List<FOODITEM_TRANSMASTER> fOODITEM_TRANSMASTERs = new List<FOODITEM_TRANSMASTER>();
        SqlFOODITEM_TRANSMASTERProvider sqlFOODITEM_TRANSMASTERProvider = new SqlFOODITEM_TRANSMASTERProvider();
        fOODITEM_TRANSMASTERs = sqlFOODITEM_TRANSMASTERProvider.GetAllFOODITEM_TRANSMASTERsForReport(status, locationIDs, agentID, fromDate, toDate, amount);
        return fOODITEM_TRANSMASTERs;
    }
    public static FOODITEM_TRANSMASTER GetFOODITEM_TRANSMASTERByID(int id)
    {
        FOODITEM_TRANSMASTER fOODITEM_TRANSMASTER = new FOODITEM_TRANSMASTER();
        SqlFOODITEM_TRANSMASTERProvider sqlFOODITEM_TRANSMASTERProvider = new SqlFOODITEM_TRANSMASTERProvider();
        fOODITEM_TRANSMASTER = sqlFOODITEM_TRANSMASTERProvider.GetFOODITEM_TRANSMASTERByID(id);
        return fOODITEM_TRANSMASTER;
    }

    public static FOODITEM_TRANSMASTER GetFOODITEM_TRANSMASTERByRefCode(string refCode)
    {
        FOODITEM_TRANSMASTER fOODITEM_TRANSMASTER = new FOODITEM_TRANSMASTER();
        SqlFOODITEM_TRANSMASTERProvider sqlFOODITEM_TRANSMASTERProvider = new SqlFOODITEM_TRANSMASTERProvider();
        fOODITEM_TRANSMASTER = sqlFOODITEM_TRANSMASTERProvider.GetFOODITEM_TRANSMASTERByRefCode(refCode);
        return fOODITEM_TRANSMASTER;
    }
    public static int InsertFOODITEM_TRANSMASTER(FOODITEM_TRANSMASTER fOODITEM_TRANSMASTER)
    {
        SqlFOODITEM_TRANSMASTERProvider sqlFOODITEM_TRANSMASTERProvider = new SqlFOODITEM_TRANSMASTERProvider();
        return sqlFOODITEM_TRANSMASTERProvider.InsertFOODITEM_TRANSMASTER(fOODITEM_TRANSMASTER);
    }


    public static bool UpdateFOODITEM_TRANSMASTER(FOODITEM_TRANSMASTER fOODITEM_TRANSMASTER)
    {
        SqlFOODITEM_TRANSMASTERProvider sqlFOODITEM_TRANSMASTERProvider = new SqlFOODITEM_TRANSMASTERProvider();
        return sqlFOODITEM_TRANSMASTERProvider.UpdateFOODITEM_TRANSMASTER(fOODITEM_TRANSMASTER);
    }

    public static bool DeleteFOODITEM_TRANSMASTER(int fOODITEM_TRANSMASTERID)
    {
        SqlFOODITEM_TRANSMASTERProvider sqlFOODITEM_TRANSMASTERProvider = new SqlFOODITEM_TRANSMASTERProvider();
        return sqlFOODITEM_TRANSMASTERProvider.DeleteFOODITEM_TRANSMASTER(fOODITEM_TRANSMASTERID);
    }
}
