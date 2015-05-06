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

public class SERVICESManager
{
	public SERVICESManager()
	{
	}

    public static List<SERVICES> GetAllSERVICESs()
    {
        List<SERVICES> sERVICESs = new List<SERVICES>();
        SqlSERVICESProvider sqlSERVICESProvider = new SqlSERVICESProvider();
        sERVICESs = sqlSERVICESProvider.GetAllSERVICESs();
        return sERVICESs;
    }


    public static SERVICES GetSERVICESByID(int id)
    {
        SERVICES sERVICES = new SERVICES();
        SqlSERVICESProvider sqlSERVICESProvider = new SqlSERVICESProvider();
        sERVICES = sqlSERVICESProvider.GetSERVICESByID(id);
        return sERVICES;
    }


    public static int InsertSERVICES(SERVICES sERVICES)
    {
        SqlSERVICESProvider sqlSERVICESProvider = new SqlSERVICESProvider();
        return sqlSERVICESProvider.InsertSERVICES(sERVICES);
    }


    public static bool UpdateSERVICES(SERVICES sERVICES)
    {
        SqlSERVICESProvider sqlSERVICESProvider = new SqlSERVICESProvider();
        return sqlSERVICESProvider.UpdateSERVICES(sERVICES);
    }

    public static bool DeleteSERVICES(int sERVICESID)
    {
        SqlSERVICESProvider sqlSERVICESProvider = new SqlSERVICESProvider();
        return sqlSERVICESProvider.DeleteSERVICES(sERVICESID);
    }
}
