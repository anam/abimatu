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

public class LOCATION_AGENT_RATEManager
{
	public LOCATION_AGENT_RATEManager()
	{
	}

    public static List<LOCATION_AGENT_RATE> GetAllLOCATION_AGENT_RATEs()
    {
        List<LOCATION_AGENT_RATE> lOCATION_AGENT_RATEs = new List<LOCATION_AGENT_RATE>();
        SqlLOCATION_AGENT_RATEProvider sqlLOCATION_AGENT_RATEProvider = new SqlLOCATION_AGENT_RATEProvider();
        lOCATION_AGENT_RATEs = sqlLOCATION_AGENT_RATEProvider.GetAllLOCATION_AGENT_RATEs();
        return lOCATION_AGENT_RATEs;
    }

    public static List<LOCATION_AGENT_RATE> GetAllLOCATION_AGENT_RATEsLOCATIONID(int locationID)
    {
        List<LOCATION_AGENT_RATE> lOCATION_AGENT_RATEs = new List<LOCATION_AGENT_RATE>();
        SqlLOCATION_AGENT_RATEProvider sqlLOCATION_AGENT_RATEProvider = new SqlLOCATION_AGENT_RATEProvider();
        lOCATION_AGENT_RATEs = sqlLOCATION_AGENT_RATEProvider.GetAllLOCATION_AGENT_RATEsByLOCATIONID(locationID);
        return lOCATION_AGENT_RATEs;
    }

    public static List<LOCATION_AGENT_RATE> GetAllLOCATION_AGENT_RATEsByAGENTID(int agentID)
    {
        List<LOCATION_AGENT_RATE> lOCATION_AGENT_RATEs = new List<LOCATION_AGENT_RATE>();
        SqlLOCATION_AGENT_RATEProvider sqlLOCATION_AGENT_RATEProvider = new SqlLOCATION_AGENT_RATEProvider();
        lOCATION_AGENT_RATEs = sqlLOCATION_AGENT_RATEProvider.GetAllLOCATION_AGENT_RATEsByAGENTID(agentID);
        return lOCATION_AGENT_RATEs;
    }

    public static LOCATION_AGENT_RATE GetLOCATION_AGENT_RATEByID(int id)
    {
        LOCATION_AGENT_RATE lOCATION_AGENT_RATE = new LOCATION_AGENT_RATE();
        SqlLOCATION_AGENT_RATEProvider sqlLOCATION_AGENT_RATEProvider = new SqlLOCATION_AGENT_RATEProvider();
        lOCATION_AGENT_RATE = sqlLOCATION_AGENT_RATEProvider.GetLOCATION_AGENT_RATEByID(id);
        return lOCATION_AGENT_RATE;
    }


    public static int InsertLOCATION_AGENT_RATE(LOCATION_AGENT_RATE lOCATION_AGENT_RATE)
    {
        SqlLOCATION_AGENT_RATEProvider sqlLOCATION_AGENT_RATEProvider = new SqlLOCATION_AGENT_RATEProvider();
        return sqlLOCATION_AGENT_RATEProvider.InsertLOCATION_AGENT_RATE(lOCATION_AGENT_RATE);
    }


    public static bool UpdateLOCATION_AGENT_RATE(LOCATION_AGENT_RATE lOCATION_AGENT_RATE)
    {
        SqlLOCATION_AGENT_RATEProvider sqlLOCATION_AGENT_RATEProvider = new SqlLOCATION_AGENT_RATEProvider();
        return sqlLOCATION_AGENT_RATEProvider.UpdateLOCATION_AGENT_RATE(lOCATION_AGENT_RATE);
    }

    public static bool DeleteLOCATION_AGENT_RATE(int lOCATION_AGENT_RATEID)
    {
        SqlLOCATION_AGENT_RATEProvider sqlLOCATION_AGENT_RATEProvider = new SqlLOCATION_AGENT_RATEProvider();
        return sqlLOCATION_AGENT_RATEProvider.DeleteLOCATION_AGENT_RATE(lOCATION_AGENT_RATEID);
    }
}
