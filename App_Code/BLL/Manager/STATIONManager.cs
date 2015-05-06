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

public class STATIONManager
{
	public STATIONManager()
	{
	}

    public static List<STATION> GetAllSTATIONs()
    {
        List<STATION> sTATIONs = new List<STATION>();
        SqlSTATIONProvider sqlSTATIONProvider = new SqlSTATIONProvider();
        sTATIONs = sqlSTATIONProvider.GetAllSTATIONs();
        return sTATIONs;
    }


    public static STATION GetSTATIONByID(int id)
    {
        STATION sTATION = new STATION();
        SqlSTATIONProvider sqlSTATIONProvider = new SqlSTATIONProvider();
        sTATION = sqlSTATIONProvider.GetSTATIONByID(id);
        return sTATION;
    }


    public static int InsertSTATION(STATION sTATION)
    {
        SqlSTATIONProvider sqlSTATIONProvider = new SqlSTATIONProvider();
        return sqlSTATIONProvider.InsertSTATION(sTATION);
    }


    public static bool UpdateSTATION(STATION sTATION)
    {
        SqlSTATIONProvider sqlSTATIONProvider = new SqlSTATIONProvider();
        return sqlSTATIONProvider.UpdateSTATION(sTATION);
    }

    public static bool DeleteSTATION(int sTATIONID)
    {
        SqlSTATIONProvider sqlSTATIONProvider = new SqlSTATIONProvider();
        return sqlSTATIONProvider.DeleteSTATION(sTATIONID);
    }
}
