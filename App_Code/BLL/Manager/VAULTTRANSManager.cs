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

public class VAULTTRANSManager
{
	public VAULTTRANSManager()
	{
	}

    public static List<VAULTTRANS> GetAllVAULTTRANSs()
    {
        List<VAULTTRANS> vAULTTRANSs = new List<VAULTTRANS>();
        SqlVAULTTRANSProvider sqlVAULTTRANSProvider = new SqlVAULTTRANSProvider();
        vAULTTRANSs = sqlVAULTTRANSProvider.GetAllVAULTTRANSs();
        return vAULTTRANSs;
    }


    public static VAULTTRANS GetVAULTTRANSByID(int id)
    {
        VAULTTRANS vAULTTRANS = new VAULTTRANS();
        SqlVAULTTRANSProvider sqlVAULTTRANSProvider = new SqlVAULTTRANSProvider();
        vAULTTRANS = sqlVAULTTRANSProvider.GetVAULTTRANSByID(id);
        return vAULTTRANS;
    }


    public static int InsertVAULTTRANS(VAULTTRANS vAULTTRANS)
    {
        SqlVAULTTRANSProvider sqlVAULTTRANSProvider = new SqlVAULTTRANSProvider();
        return sqlVAULTTRANSProvider.InsertVAULTTRANS(vAULTTRANS);
    }


    public static bool UpdateVAULTTRANS(VAULTTRANS vAULTTRANS)
    {
        SqlVAULTTRANSProvider sqlVAULTTRANSProvider = new SqlVAULTTRANSProvider();
        return sqlVAULTTRANSProvider.UpdateVAULTTRANS(vAULTTRANS);
    }

    public static bool DeleteVAULTTRANS(int vAULTTRANSID)
    {
        SqlVAULTTRANSProvider sqlVAULTTRANSProvider = new SqlVAULTTRANSProvider();
        return sqlVAULTTRANSProvider.DeleteVAULTTRANS(vAULTTRANSID);
    }
}
