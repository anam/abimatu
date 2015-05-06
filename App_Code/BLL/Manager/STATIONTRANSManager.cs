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

public class STATIONTRANSManager
{
	public STATIONTRANSManager()
	{
	}

    public static List<STATIONTRANS> GetAllSTATIONTRANSs()
    {
        List<STATIONTRANS> sTATIONTRANSs = new List<STATIONTRANS>();
        SqlSTATIONTRANSProvider sqlSTATIONTRANSProvider = new SqlSTATIONTRANSProvider();
        sTATIONTRANSs = sqlSTATIONTRANSProvider.GetAllSTATIONTRANSs();
        return sTATIONTRANSs;
    }


    public static STATIONTRANS GetSTATIONTRANSByID(int id)
    {
        STATIONTRANS sTATIONTRANS = new STATIONTRANS();
        SqlSTATIONTRANSProvider sqlSTATIONTRANSProvider = new SqlSTATIONTRANSProvider();
        sTATIONTRANS = sqlSTATIONTRANSProvider.GetSTATIONTRANSByID(id);
        return sTATIONTRANS;
    }


    public static int InsertSTATIONTRANS(STATIONTRANS sTATIONTRANS)
    {
        SqlSTATIONTRANSProvider sqlSTATIONTRANSProvider = new SqlSTATIONTRANSProvider();
        return sqlSTATIONTRANSProvider.InsertSTATIONTRANS(sTATIONTRANS);
    }


    public static bool UpdateSTATIONTRANS(STATIONTRANS sTATIONTRANS)
    {
        SqlSTATIONTRANSProvider sqlSTATIONTRANSProvider = new SqlSTATIONTRANSProvider();
        return sqlSTATIONTRANSProvider.UpdateSTATIONTRANS(sTATIONTRANS);
    }

    public static bool DeleteSTATIONTRANS(int sTATIONTRANSID)
    {
        SqlSTATIONTRANSProvider sqlSTATIONTRANSProvider = new SqlSTATIONTRANSProvider();
        return sqlSTATIONTRANSProvider.DeleteSTATIONTRANS(sTATIONTRANSID);
    }
}
