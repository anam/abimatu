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

public class SALESSTORESERVICESManager
{
	public SALESSTORESERVICESManager()
	{
	}

    public static List<SALESSTORESERVICES> GetAllSALESSTORESERVICESs()
    {
        List<SALESSTORESERVICES> sALESSTORESERVICESs = new List<SALESSTORESERVICES>();
        SqlSALESSTORESERVICESProvider sqlSALESSTORESERVICESProvider = new SqlSALESSTORESERVICESProvider();
        sALESSTORESERVICESs = sqlSALESSTORESERVICESProvider.GetAllSALESSTORESERVICESs();
        return sALESSTORESERVICESs;
    }


    public static SALESSTORESERVICES GetSALESSTORESERVICESByID(int id)
    {
        SALESSTORESERVICES sALESSTORESERVICES = new SALESSTORESERVICES();
        SqlSALESSTORESERVICESProvider sqlSALESSTORESERVICESProvider = new SqlSALESSTORESERVICESProvider();
        sALESSTORESERVICES = sqlSALESSTORESERVICESProvider.GetSALESSTORESERVICESByID(id);
        return sALESSTORESERVICES;
    }


    public static int InsertSALESSTORESERVICES(SALESSTORESERVICES sALESSTORESERVICES)
    {
        SqlSALESSTORESERVICESProvider sqlSALESSTORESERVICESProvider = new SqlSALESSTORESERVICESProvider();
        return sqlSALESSTORESERVICESProvider.InsertSALESSTORESERVICES(sALESSTORESERVICES);
    }


    public static bool UpdateSALESSTORESERVICES(SALESSTORESERVICES sALESSTORESERVICES)
    {
        SqlSALESSTORESERVICESProvider sqlSALESSTORESERVICESProvider = new SqlSALESSTORESERVICESProvider();
        return sqlSALESSTORESERVICESProvider.UpdateSALESSTORESERVICES(sALESSTORESERVICES);
    }

    public static bool DeleteSALESSTORESERVICES(int sALESSTORESERVICESID)
    {
        SqlSALESSTORESERVICESProvider sqlSALESSTORESERVICESProvider = new SqlSALESSTORESERVICESProvider();
        return sqlSALESSTORESERVICESProvider.DeleteSALESSTORESERVICES(sALESSTORESERVICESID);
    }
}
