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

public class REPORTManager
{
	public REPORTManager()
	{
	}

    public static List<REPORT> GetAllREPORTs()
    {
        List<REPORT> rEPORTs = new List<REPORT>();
        SqlREPORTProvider sqlREPORTProvider = new SqlREPORTProvider();
        rEPORTs = sqlREPORTProvider.GetAllREPORTs();
        return rEPORTs;
    }


    public static REPORT GetREPORTByID(int id)
    {
        REPORT rEPORT = new REPORT();
        SqlREPORTProvider sqlREPORTProvider = new SqlREPORTProvider();
        rEPORT = sqlREPORTProvider.GetREPORTByID(id);
        return rEPORT;
    }


    public static int InsertREPORT(REPORT rEPORT)
    {
        SqlREPORTProvider sqlREPORTProvider = new SqlREPORTProvider();
        return sqlREPORTProvider.InsertREPORT(rEPORT);
    }


    public static bool UpdateREPORT(REPORT rEPORT)
    {
        SqlREPORTProvider sqlREPORTProvider = new SqlREPORTProvider();
        return sqlREPORTProvider.UpdateREPORT(rEPORT);
    }

    public static bool DeleteREPORT(int rEPORTID)
    {
        SqlREPORTProvider sqlREPORTProvider = new SqlREPORTProvider();
        return sqlREPORTProvider.DeleteREPORT(rEPORTID);
    }
}
