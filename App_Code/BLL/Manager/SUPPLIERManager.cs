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

public class SUPPLIERManager
{
	public SUPPLIERManager()
	{
	}

    public static List<SUPPLIER> GetAllSUPPLIERs()
    {
        List<SUPPLIER> sUPPLIERs = new List<SUPPLIER>();
        SqlSUPPLIERProvider sqlSUPPLIERProvider = new SqlSUPPLIERProvider();
        sUPPLIERs = sqlSUPPLIERProvider.GetAllSUPPLIERs();
        return sUPPLIERs;
    }


    public static SUPPLIER GetSUPPLIERByID(int id)
    {
        SUPPLIER sUPPLIER = new SUPPLIER();
        SqlSUPPLIERProvider sqlSUPPLIERProvider = new SqlSUPPLIERProvider();
        sUPPLIER = sqlSUPPLIERProvider.GetSUPPLIERByID(id);
        return sUPPLIER;
    }


    public static int InsertSUPPLIER(SUPPLIER sUPPLIER)
    {
        SqlSUPPLIERProvider sqlSUPPLIERProvider = new SqlSUPPLIERProvider();
        return sqlSUPPLIERProvider.InsertSUPPLIER(sUPPLIER);
    }


    public static bool UpdateSUPPLIER(SUPPLIER sUPPLIER)
    {
        SqlSUPPLIERProvider sqlSUPPLIERProvider = new SqlSUPPLIERProvider();
        return sqlSUPPLIERProvider.UpdateSUPPLIER(sUPPLIER);
    }

    public static bool DeleteSUPPLIER(int sUPPLIERID)
    {
        SqlSUPPLIERProvider sqlSUPPLIERProvider = new SqlSUPPLIERProvider();
        return sqlSUPPLIERProvider.DeleteSUPPLIER(sUPPLIERID);
    }
}
