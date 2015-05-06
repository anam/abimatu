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

public class RATEManager
{
	public RATEManager()
	{
	}

    public static List<RATE> GetAllRATEs()
    {
        List<RATE> rATEs = new List<RATE>();
        SqlRATEProvider sqlRATEProvider = new SqlRATEProvider();
        rATEs = sqlRATEProvider.GetAllRATEs();
        return rATEs;
    }


    public static RATE GetRATEByID(int id)
    {
        RATE rATE = new RATE();
        SqlRATEProvider sqlRATEProvider = new SqlRATEProvider();
        rATE = sqlRATEProvider.GetRATEByID(id);
        return rATE;
    }


    public static int InsertRATE(RATE rATE)
    {
        SqlRATEProvider sqlRATEProvider = new SqlRATEProvider();
        return sqlRATEProvider.InsertRATE(rATE);
    }


    public static bool UpdateRATE(RATE rATE)
    {
        SqlRATEProvider sqlRATEProvider = new SqlRATEProvider();
        return sqlRATEProvider.UpdateRATE(rATE);
    }

    public static bool DeleteRATE(int rATEID)
    {
        SqlRATEProvider sqlRATEProvider = new SqlRATEProvider();
        return sqlRATEProvider.DeleteRATE(rATEID);
    }
}
