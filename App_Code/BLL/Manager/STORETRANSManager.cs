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

public class STORETRANSManager
{
	public STORETRANSManager()
	{
	}

    public static List<STORETRANS> GetAllSTORETRANSs()
    {
        List<STORETRANS> sTORETRANSs = new List<STORETRANS>();
        SqlSTORETRANSProvider sqlSTORETRANSProvider = new SqlSTORETRANSProvider();
        sTORETRANSs = sqlSTORETRANSProvider.GetAllSTORETRANSs();
        return sTORETRANSs;
    }


    public static STORETRANS GetSTORETRANSByID(int id)
    {
        STORETRANS sTORETRANS = new STORETRANS();
        SqlSTORETRANSProvider sqlSTORETRANSProvider = new SqlSTORETRANSProvider();
        sTORETRANS = sqlSTORETRANSProvider.GetSTORETRANSByID(id);
        return sTORETRANS;
    }


    public static int InsertSTORETRANS(STORETRANS sTORETRANS)
    {
        SqlSTORETRANSProvider sqlSTORETRANSProvider = new SqlSTORETRANSProvider();
        return sqlSTORETRANSProvider.InsertSTORETRANS(sTORETRANS);
    }


    public static bool UpdateSTORETRANS(STORETRANS sTORETRANS)
    {
        SqlSTORETRANSProvider sqlSTORETRANSProvider = new SqlSTORETRANSProvider();
        return sqlSTORETRANSProvider.UpdateSTORETRANS(sTORETRANS);
    }

    public static bool DeleteSTORETRANS(int sTORETRANSID)
    {
        SqlSTORETRANSProvider sqlSTORETRANSProvider = new SqlSTORETRANSProvider();
        return sqlSTORETRANSProvider.DeleteSTORETRANS(sTORETRANSID);
    }
}
