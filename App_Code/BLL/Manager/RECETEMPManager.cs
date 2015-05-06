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

public class RECETEMPManager
{
	public RECETEMPManager()
	{
	}

    public static List<RECETEMP> GetAllRECETEMPs()
    {
        List<RECETEMP> rECETEMPs = new List<RECETEMP>();
        SqlRECETEMPProvider sqlRECETEMPProvider = new SqlRECETEMPProvider();
        rECETEMPs = sqlRECETEMPProvider.GetAllRECETEMPs();
        return rECETEMPs;
    }


    public static RECETEMP GetRECETEMPByID(int id)
    {
        RECETEMP rECETEMP = new RECETEMP();
        SqlRECETEMPProvider sqlRECETEMPProvider = new SqlRECETEMPProvider();
        rECETEMP = sqlRECETEMPProvider.GetRECETEMPByID(id);
        return rECETEMP;
    }


    public static int InsertRECETEMP(RECETEMP rECETEMP)
    {
        SqlRECETEMPProvider sqlRECETEMPProvider = new SqlRECETEMPProvider();
        return sqlRECETEMPProvider.InsertRECETEMP(rECETEMP);
    }


    public static bool UpdateRECETEMP(RECETEMP rECETEMP)
    {
        SqlRECETEMPProvider sqlRECETEMPProvider = new SqlRECETEMPProvider();
        return sqlRECETEMPProvider.UpdateRECETEMP(rECETEMP);
    }

    public static bool DeleteRECETEMP(int rECETEMPID)
    {
        SqlRECETEMPProvider sqlRECETEMPProvider = new SqlRECETEMPProvider();
        return sqlRECETEMPProvider.DeleteRECETEMP(rECETEMPID);
    }
}
