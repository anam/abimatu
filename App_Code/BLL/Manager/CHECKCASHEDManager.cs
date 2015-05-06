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

public class CHECKCASHEDManager
{
	public CHECKCASHEDManager()
	{
	}

    public static List<CHECKCASHED> GetAllCHECKCASHEDs()
    {
        List<CHECKCASHED> cHECKCASHEDs = new List<CHECKCASHED>();
        SqlCHECKCASHEDProvider sqlCHECKCASHEDProvider = new SqlCHECKCASHEDProvider();
        cHECKCASHEDs = sqlCHECKCASHEDProvider.GetAllCHECKCASHEDs();
        return cHECKCASHEDs;
    }


    public static CHECKCASHED GetCHECKCASHEDByID(int id)
    {
        CHECKCASHED cHECKCASHED = new CHECKCASHED();
        SqlCHECKCASHEDProvider sqlCHECKCASHEDProvider = new SqlCHECKCASHEDProvider();
        cHECKCASHED = sqlCHECKCASHEDProvider.GetCHECKCASHEDByID(id);
        return cHECKCASHED;
    }


    public static int InsertCHECKCASHED(CHECKCASHED cHECKCASHED)
    {
        SqlCHECKCASHEDProvider sqlCHECKCASHEDProvider = new SqlCHECKCASHEDProvider();
        return sqlCHECKCASHEDProvider.InsertCHECKCASHED(cHECKCASHED);
    }


    public static bool UpdateCHECKCASHED(CHECKCASHED cHECKCASHED)
    {
        SqlCHECKCASHEDProvider sqlCHECKCASHEDProvider = new SqlCHECKCASHEDProvider();
        return sqlCHECKCASHEDProvider.UpdateCHECKCASHED(cHECKCASHED);
    }

    public static bool DeleteCHECKCASHED(int cHECKCASHEDID)
    {
        SqlCHECKCASHEDProvider sqlCHECKCASHEDProvider = new SqlCHECKCASHEDProvider();
        return sqlCHECKCASHEDProvider.DeleteCHECKCASHED(cHECKCASHEDID);
    }
}
