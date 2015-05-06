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

public class USERINFOManager
{
	public USERINFOManager()
	{
	}

    public static List<USERINFO> GetAllUSERINFOs()
    {
        List<USERINFO> uSERINFOs = new List<USERINFO>();
        SqlUSERINFOProvider sqlUSERINFOProvider = new SqlUSERINFOProvider();
        uSERINFOs = sqlUSERINFOProvider.GetAllUSERINFOs();
        return uSERINFOs;
    }

    public static List<USERINFO> GetAllUSERINFOsByType(string type)
    {
        List<USERINFO> uSERINFOs = new List<USERINFO>();
        SqlUSERINFOProvider sqlUSERINFOProvider = new SqlUSERINFOProvider();
        uSERINFOs = sqlUSERINFOProvider.GetAllUSERINFOsByType(type);
        return uSERINFOs;
    }
    public static USERINFO GetUSERINFOByID(int id)
    {
        USERINFO uSERINFO = new USERINFO();
        SqlUSERINFOProvider sqlUSERINFOProvider = new SqlUSERINFOProvider();
        uSERINFO = sqlUSERINFOProvider.GetUSERINFOByID(id);
        return uSERINFO;
    }

    public static USERINFO GetUSERINFOByUserNameType(string type, string userName)
    {
        USERINFO uSERINFO = new USERINFO();
        SqlUSERINFOProvider sqlUSERINFOProvider = new SqlUSERINFOProvider();
        uSERINFO = sqlUSERINFOProvider.GetUSERINFOByUserNameType(type, userName);
        return uSERINFO;
    }

    public static int InsertUSERINFO(USERINFO uSERINFO)
    {
        SqlUSERINFOProvider sqlUSERINFOProvider = new SqlUSERINFOProvider();
        return sqlUSERINFOProvider.InsertUSERINFO(uSERINFO);
    }


    public static bool UpdateUSERINFO(USERINFO uSERINFO)
    {
        SqlUSERINFOProvider sqlUSERINFOProvider = new SqlUSERINFOProvider();
        return sqlUSERINFOProvider.UpdateUSERINFO(uSERINFO);
    }

    public static bool DeleteUSERINFO(int uSERINFOID)
    {
        SqlUSERINFOProvider sqlUSERINFOProvider = new SqlUSERINFOProvider();
        return sqlUSERINFOProvider.DeleteUSERINFO(uSERINFOID);
    }
}
