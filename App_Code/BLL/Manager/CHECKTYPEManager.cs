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

public class CHECKTYPEManager
{
	public CHECKTYPEManager()
	{
	}

    public static List<CHECKTYPE> GetAllCHECKTYPEs()
    {
        List<CHECKTYPE> cHECKTYPEs = new List<CHECKTYPE>();
        SqlCHECKTYPEProvider sqlCHECKTYPEProvider = new SqlCHECKTYPEProvider();
        cHECKTYPEs = sqlCHECKTYPEProvider.GetAllCHECKTYPEs();
        return cHECKTYPEs;
    }


    public static CHECKTYPE GetCHECKTYPEByID(int id)
    {
        CHECKTYPE cHECKTYPE = new CHECKTYPE();
        SqlCHECKTYPEProvider sqlCHECKTYPEProvider = new SqlCHECKTYPEProvider();
        cHECKTYPE = sqlCHECKTYPEProvider.GetCHECKTYPEByID(id);
        return cHECKTYPE;
    }


    public static int InsertCHECKTYPE(CHECKTYPE cHECKTYPE)
    {
        SqlCHECKTYPEProvider sqlCHECKTYPEProvider = new SqlCHECKTYPEProvider();
        return sqlCHECKTYPEProvider.InsertCHECKTYPE(cHECKTYPE);
    }


    public static bool UpdateCHECKTYPE(CHECKTYPE cHECKTYPE)
    {
        SqlCHECKTYPEProvider sqlCHECKTYPEProvider = new SqlCHECKTYPEProvider();
        return sqlCHECKTYPEProvider.UpdateCHECKTYPE(cHECKTYPE);
    }

    public static bool DeleteCHECKTYPE(int cHECKTYPEID)
    {
        SqlCHECKTYPEProvider sqlCHECKTYPEProvider = new SqlCHECKTYPEProvider();
        return sqlCHECKTYPEProvider.DeleteCHECKTYPE(cHECKTYPEID);
    }
}
