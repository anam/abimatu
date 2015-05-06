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

public class FOODITEM_MASTERManager
{
	public FOODITEM_MASTERManager()
	{
	}

    public static List<FOODITEM_MASTER> GetAllFOODITEM_MASTERs()
    {
        List<FOODITEM_MASTER> fOODITEM_MASTERs = new List<FOODITEM_MASTER>();
        SqlFOODITEM_MASTERProvider sqlFOODITEM_MASTERProvider = new SqlFOODITEM_MASTERProvider();
        fOODITEM_MASTERs = sqlFOODITEM_MASTERProvider.GetAllFOODITEM_MASTERs();
        return fOODITEM_MASTERs;
    }


    public static FOODITEM_MASTER GetFOODITEM_MASTERByID(int id)
    {
        FOODITEM_MASTER fOODITEM_MASTER = new FOODITEM_MASTER();
        SqlFOODITEM_MASTERProvider sqlFOODITEM_MASTERProvider = new SqlFOODITEM_MASTERProvider();
        fOODITEM_MASTER = sqlFOODITEM_MASTERProvider.GetFOODITEM_MASTERByID(id);
        return fOODITEM_MASTER;
    }


    public static int InsertFOODITEM_MASTER(FOODITEM_MASTER fOODITEM_MASTER)
    {
        SqlFOODITEM_MASTERProvider sqlFOODITEM_MASTERProvider = new SqlFOODITEM_MASTERProvider();
        return sqlFOODITEM_MASTERProvider.InsertFOODITEM_MASTER(fOODITEM_MASTER);
    }


    public static bool UpdateFOODITEM_MASTER(FOODITEM_MASTER fOODITEM_MASTER)
    {
        SqlFOODITEM_MASTERProvider sqlFOODITEM_MASTERProvider = new SqlFOODITEM_MASTERProvider();
        return sqlFOODITEM_MASTERProvider.UpdateFOODITEM_MASTER(fOODITEM_MASTER);
    }

    public static bool DeleteFOODITEM_MASTER(int fOODITEM_MASTERID)
    {
        SqlFOODITEM_MASTERProvider sqlFOODITEM_MASTERProvider = new SqlFOODITEM_MASTERProvider();
        return sqlFOODITEM_MASTERProvider.DeleteFOODITEM_MASTER(fOODITEM_MASTERID);
    }
}
