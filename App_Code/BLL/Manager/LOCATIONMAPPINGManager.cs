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

public class LOCATIONMAPPINGManager
{
	public LOCATIONMAPPINGManager()
	{
	}

    public static List<LOCATIONMAPPING> GetAllLOCATIONMAPPINGs()
    {
        List<LOCATIONMAPPING> lOCATIONMAPPINGs = new List<LOCATIONMAPPING>();
        SqlLOCATIONMAPPINGProvider sqlLOCATIONMAPPINGProvider = new SqlLOCATIONMAPPINGProvider();
        lOCATIONMAPPINGs = sqlLOCATIONMAPPINGProvider.GetAllLOCATIONMAPPINGs();
        return lOCATIONMAPPINGs;
    }

    public static List<LOCATIONMAPPING> GetLOCATIONMAPPINGByLOCATIONID(int locationID)
    {
        List<LOCATIONMAPPING> lOCATIONMAPPINGs = new List<LOCATIONMAPPING>();
        SqlLOCATIONMAPPINGProvider sqlLOCATIONMAPPINGProvider = new SqlLOCATIONMAPPINGProvider();
        lOCATIONMAPPINGs = sqlLOCATIONMAPPINGProvider.GetLOCATIONMAPPINGByLOCATIONID(locationID);
        return lOCATIONMAPPINGs;
    }
    public static List<LOCATIONMAPPING> GetLOCATIONMAPPINGByLOCATIONGROUPID(int groupID)
    {
        List<LOCATIONMAPPING> lOCATIONMAPPINGs = new List<LOCATIONMAPPING>();
        SqlLOCATIONMAPPINGProvider sqlLOCATIONMAPPINGProvider = new SqlLOCATIONMAPPINGProvider();
        lOCATIONMAPPINGs = sqlLOCATIONMAPPINGProvider.GetLOCATIONMAPPINGByLOCATIONGROUPID(groupID);
        return lOCATIONMAPPINGs;
    }
    public static LOCATIONMAPPING GetLOCATIONMAPPINGByID(int id)
    {
        LOCATIONMAPPING lOCATIONMAPPING = new LOCATIONMAPPING();
        SqlLOCATIONMAPPINGProvider sqlLOCATIONMAPPINGProvider = new SqlLOCATIONMAPPINGProvider();
        lOCATIONMAPPING = sqlLOCATIONMAPPINGProvider.GetLOCATIONMAPPINGByID(id);
        return lOCATIONMAPPING;
    }


    public static int InsertLOCATIONMAPPING(LOCATIONMAPPING lOCATIONMAPPING)
    {
        SqlLOCATIONMAPPINGProvider sqlLOCATIONMAPPINGProvider = new SqlLOCATIONMAPPINGProvider();
        return sqlLOCATIONMAPPINGProvider.InsertLOCATIONMAPPING(lOCATIONMAPPING);
    }


    public static bool UpdateLOCATIONMAPPING(LOCATIONMAPPING lOCATIONMAPPING)
    {
        SqlLOCATIONMAPPINGProvider sqlLOCATIONMAPPINGProvider = new SqlLOCATIONMAPPINGProvider();
        return sqlLOCATIONMAPPINGProvider.UpdateLOCATIONMAPPING(lOCATIONMAPPING);
    }

    public static bool DeleteLOCATIONMAPPING(int lOCATIONMAPPINGID)
    {
        SqlLOCATIONMAPPINGProvider sqlLOCATIONMAPPINGProvider = new SqlLOCATIONMAPPINGProvider();
        return sqlLOCATIONMAPPINGProvider.DeleteLOCATIONMAPPING(lOCATIONMAPPINGID);
    }
}
