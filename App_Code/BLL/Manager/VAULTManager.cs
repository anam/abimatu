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

public class VAULTManager
{
	public VAULTManager()
	{
	}

    public static List<VAULT> GetAllVAULTs()
    {
        List<VAULT> vAULTs = new List<VAULT>();
        SqlVAULTProvider sqlVAULTProvider = new SqlVAULTProvider();
        vAULTs = sqlVAULTProvider.GetAllVAULTs();
        return vAULTs;
    }


    public static VAULT GetVAULTByID(int id)
    {
        VAULT vAULT = new VAULT();
        SqlVAULTProvider sqlVAULTProvider = new SqlVAULTProvider();
        vAULT = sqlVAULTProvider.GetVAULTByID(id);
        return vAULT;
    }


    public static int InsertVAULT(VAULT vAULT)
    {
        SqlVAULTProvider sqlVAULTProvider = new SqlVAULTProvider();
        return sqlVAULTProvider.InsertVAULT(vAULT);
    }


    public static bool UpdateVAULT(VAULT vAULT)
    {
        SqlVAULTProvider sqlVAULTProvider = new SqlVAULTProvider();
        return sqlVAULTProvider.UpdateVAULT(vAULT);
    }

    public static bool DeleteVAULT(int vAULTID)
    {
        SqlVAULTProvider sqlVAULTProvider = new SqlVAULTProvider();
        return sqlVAULTProvider.DeleteVAULT(vAULTID);
    }
}
