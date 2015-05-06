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

public class LOCATIONGROUPManager
{
	public LOCATIONGROUPManager()
	{
	}

    public static List<LOCATIONGROUP> GetAllLOCATIONGROUPs()
    {
        List<LOCATIONGROUP> lOCATIONGROUPs = new List<LOCATIONGROUP>();
        SqlLOCATIONGROUPProvider sqlLOCATIONGROUPProvider = new SqlLOCATIONGROUPProvider();
        lOCATIONGROUPs = sqlLOCATIONGROUPProvider.GetAllLOCATIONGROUPs();
        return lOCATIONGROUPs;
    }

    public static List<LOCATIONGROUP> GetAllLOCATIONGROUPsFood()
    {
        List<LOCATIONGROUP> lOCATIONGROUPs = new List<LOCATIONGROUP>();
        SqlLOCATIONGROUPProvider sqlLOCATIONGROUPProvider = new SqlLOCATIONGROUPProvider();
        lOCATIONGROUPs = sqlLOCATIONGROUPProvider.GetAllLOCATIONGROUPsFood();
        return lOCATIONGROUPs;
    }


    public static LOCATIONGROUP GetLOCATIONGROUPByID(int id)
    {
        LOCATIONGROUP lOCATIONGROUP = new LOCATIONGROUP();
        SqlLOCATIONGROUPProvider sqlLOCATIONGROUPProvider = new SqlLOCATIONGROUPProvider();
        lOCATIONGROUP = sqlLOCATIONGROUPProvider.GetLOCATIONGROUPByID(id);
        return lOCATIONGROUP;
    }


    public static int InsertLOCATIONGROUP(LOCATIONGROUP lOCATIONGROUP)
    {
        SqlLOCATIONGROUPProvider sqlLOCATIONGROUPProvider = new SqlLOCATIONGROUPProvider();
        return sqlLOCATIONGROUPProvider.InsertLOCATIONGROUP(lOCATIONGROUP);
    }


    public static bool UpdateLOCATIONGROUP(LOCATIONGROUP lOCATIONGROUP)
    {
        SqlLOCATIONGROUPProvider sqlLOCATIONGROUPProvider = new SqlLOCATIONGROUPProvider();
        return sqlLOCATIONGROUPProvider.UpdateLOCATIONGROUP(lOCATIONGROUP);
    }

    public static bool DeleteLOCATIONGROUP(int lOCATIONGROUPID)
    {
        SqlLOCATIONGROUPProvider sqlLOCATIONGROUPProvider = new SqlLOCATIONGROUPProvider();
        return sqlLOCATIONGROUPProvider.DeleteLOCATIONGROUP(lOCATIONGROUPID);
    }
}
