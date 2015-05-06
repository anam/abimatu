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

public class GTRANSManager
{
	public GTRANSManager()
	{
	}

    public static List<GTRANS> GetAllGTRANSs()
    {
        List<GTRANS> gTRANSs = new List<GTRANS>();
        SqlGTRANSProvider sqlGTRANSProvider = new SqlGTRANSProvider();
        gTRANSs = sqlGTRANSProvider.GetAllGTRANSs();
        return gTRANSs;
    }


    public static GTRANS GetGTRANSByID(int id)
    {
        GTRANS gTRANS = new GTRANS();
        SqlGTRANSProvider sqlGTRANSProvider = new SqlGTRANSProvider();
        gTRANS = sqlGTRANSProvider.GetGTRANSByID(id);
        return gTRANS;
    }


    public static int InsertGTRANS(GTRANS gTRANS)
    {
        SqlGTRANSProvider sqlGTRANSProvider = new SqlGTRANSProvider();
        return sqlGTRANSProvider.InsertGTRANS(gTRANS);
    }


    public static bool UpdateGTRANS(GTRANS gTRANS)
    {
        SqlGTRANSProvider sqlGTRANSProvider = new SqlGTRANSProvider();
        return sqlGTRANSProvider.UpdateGTRANS(gTRANS);
    }

    public static bool DeleteGTRANS(int gTRANSID)
    {
        SqlGTRANSProvider sqlGTRANSProvider = new SqlGTRANSProvider();
        return sqlGTRANSProvider.DeleteGTRANS(gTRANSID);
    }
}
