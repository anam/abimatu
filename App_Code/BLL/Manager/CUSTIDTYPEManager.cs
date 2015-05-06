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

public class CUSTIDTYPEManager
{
	public CUSTIDTYPEManager()
	{
	}

    public static List<CUSTIDTYPE> GetAllCUSTIDTYPEs()
    {
        List<CUSTIDTYPE> cUSTIDTYPEs = new List<CUSTIDTYPE>();
        SqlCUSTIDTYPEProvider sqlCUSTIDTYPEProvider = new SqlCUSTIDTYPEProvider();
        cUSTIDTYPEs = sqlCUSTIDTYPEProvider.GetAllCUSTIDTYPEs();
        return cUSTIDTYPEs;
    }


    public static CUSTIDTYPE GetCUSTIDTYPEByID(int id)
    {
        CUSTIDTYPE cUSTIDTYPE = new CUSTIDTYPE();
        SqlCUSTIDTYPEProvider sqlCUSTIDTYPEProvider = new SqlCUSTIDTYPEProvider();
        cUSTIDTYPE = sqlCUSTIDTYPEProvider.GetCUSTIDTYPEByID(id);
        return cUSTIDTYPE;
    }


    public static int InsertCUSTIDTYPE(CUSTIDTYPE cUSTIDTYPE)
    {
        SqlCUSTIDTYPEProvider sqlCUSTIDTYPEProvider = new SqlCUSTIDTYPEProvider();
        return sqlCUSTIDTYPEProvider.InsertCUSTIDTYPE(cUSTIDTYPE);
    }


    public static bool UpdateCUSTIDTYPE(CUSTIDTYPE cUSTIDTYPE)
    {
        SqlCUSTIDTYPEProvider sqlCUSTIDTYPEProvider = new SqlCUSTIDTYPEProvider();
        return sqlCUSTIDTYPEProvider.UpdateCUSTIDTYPE(cUSTIDTYPE);
    }

    public static bool DeleteCUSTIDTYPE(int cUSTIDTYPEID)
    {
        SqlCUSTIDTYPEProvider sqlCUSTIDTYPEProvider = new SqlCUSTIDTYPEProvider();
        return sqlCUSTIDTYPEProvider.DeleteCUSTIDTYPE(cUSTIDTYPEID);
    }
}
