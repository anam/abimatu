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

public class EMPLOYEEManager
{
	public EMPLOYEEManager()
	{
	}

    public static List<EMPLOYEE> GetAllEMPLOYEEs()
    {
        List<EMPLOYEE> eMPLOYEEs = new List<EMPLOYEE>();
        SqlEMPLOYEEProvider sqlEMPLOYEEProvider = new SqlEMPLOYEEProvider();
        eMPLOYEEs = sqlEMPLOYEEProvider.GetAllEMPLOYEEs();
        return eMPLOYEEs;
    }


    public static EMPLOYEE GetEMPLOYEEByID(int id)
    {
        EMPLOYEE eMPLOYEE = new EMPLOYEE();
        SqlEMPLOYEEProvider sqlEMPLOYEEProvider = new SqlEMPLOYEEProvider();
        eMPLOYEE = sqlEMPLOYEEProvider.GetEMPLOYEEByID(id);
        return eMPLOYEE;
    }


    public static int InsertEMPLOYEE(EMPLOYEE eMPLOYEE)
    {
        SqlEMPLOYEEProvider sqlEMPLOYEEProvider = new SqlEMPLOYEEProvider();
        return sqlEMPLOYEEProvider.InsertEMPLOYEE(eMPLOYEE);
    }


    public static bool UpdateEMPLOYEE(EMPLOYEE eMPLOYEE)
    {
        SqlEMPLOYEEProvider sqlEMPLOYEEProvider = new SqlEMPLOYEEProvider();
        return sqlEMPLOYEEProvider.UpdateEMPLOYEE(eMPLOYEE);
    }

    public static bool DeleteEMPLOYEE(int eMPLOYEEID)
    {
        SqlEMPLOYEEProvider sqlEMPLOYEEProvider = new SqlEMPLOYEEProvider();
        return sqlEMPLOYEEProvider.DeleteEMPLOYEE(eMPLOYEEID);
    }
}
