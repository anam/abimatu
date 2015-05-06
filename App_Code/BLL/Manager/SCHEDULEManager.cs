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

public class SCHEDULEManager
{
	public SCHEDULEManager()
	{
	}

    public static List<SCHEDULE> GetAllSCHEDULEs()
    {
        List<SCHEDULE> sCHEDULEs = new List<SCHEDULE>();
        SqlSCHEDULEProvider sqlSCHEDULEProvider = new SqlSCHEDULEProvider();
        sCHEDULEs = sqlSCHEDULEProvider.GetAllSCHEDULEs();
        return sCHEDULEs;
    }


    public static SCHEDULE GetSCHEDULEByID(int id)
    {
        SCHEDULE sCHEDULE = new SCHEDULE();
        SqlSCHEDULEProvider sqlSCHEDULEProvider = new SqlSCHEDULEProvider();
        sCHEDULE = sqlSCHEDULEProvider.GetSCHEDULEByID(id);
        return sCHEDULE;
    }


    public static int InsertSCHEDULE(SCHEDULE sCHEDULE)
    {
        SqlSCHEDULEProvider sqlSCHEDULEProvider = new SqlSCHEDULEProvider();
        return sqlSCHEDULEProvider.InsertSCHEDULE(sCHEDULE);
    }


    public static bool UpdateSCHEDULE(SCHEDULE sCHEDULE)
    {
        SqlSCHEDULEProvider sqlSCHEDULEProvider = new SqlSCHEDULEProvider();
        return sqlSCHEDULEProvider.UpdateSCHEDULE(sCHEDULE);
    }

    public static bool DeleteSCHEDULE(int sCHEDULEID)
    {
        SqlSCHEDULEProvider sqlSCHEDULEProvider = new SqlSCHEDULEProvider();
        return sqlSCHEDULEProvider.DeleteSCHEDULE(sCHEDULEID);
    }
}
