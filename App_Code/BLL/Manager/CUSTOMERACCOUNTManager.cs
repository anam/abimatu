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

public class CUSTOMERACCOUNTManager
{
	public CUSTOMERACCOUNTManager()
	{
	}

    public static List<CUSTOMERACCOUNT> GetAllCUSTOMERACCOUNTs()
    {
        List<CUSTOMERACCOUNT> cUSTOMERACCOUNTs = new List<CUSTOMERACCOUNT>();
        SqlCUSTOMERACCOUNTProvider sqlCUSTOMERACCOUNTProvider = new SqlCUSTOMERACCOUNTProvider();
        cUSTOMERACCOUNTs = sqlCUSTOMERACCOUNTProvider.GetAllCUSTOMERACCOUNTs();
        return cUSTOMERACCOUNTs;
    }


    public static CUSTOMERACCOUNT GetCUSTOMERACCOUNTByID(int id)
    {
        CUSTOMERACCOUNT cUSTOMERACCOUNT = new CUSTOMERACCOUNT();
        SqlCUSTOMERACCOUNTProvider sqlCUSTOMERACCOUNTProvider = new SqlCUSTOMERACCOUNTProvider();
        cUSTOMERACCOUNT = sqlCUSTOMERACCOUNTProvider.GetCUSTOMERACCOUNTByID(id);
        return cUSTOMERACCOUNT;
    }


    public static int InsertCUSTOMERACCOUNT(CUSTOMERACCOUNT cUSTOMERACCOUNT)
    {
        SqlCUSTOMERACCOUNTProvider sqlCUSTOMERACCOUNTProvider = new SqlCUSTOMERACCOUNTProvider();
        return sqlCUSTOMERACCOUNTProvider.InsertCUSTOMERACCOUNT(cUSTOMERACCOUNT);
    }


    public static bool UpdateCUSTOMERACCOUNT(CUSTOMERACCOUNT cUSTOMERACCOUNT)
    {
        SqlCUSTOMERACCOUNTProvider sqlCUSTOMERACCOUNTProvider = new SqlCUSTOMERACCOUNTProvider();
        return sqlCUSTOMERACCOUNTProvider.UpdateCUSTOMERACCOUNT(cUSTOMERACCOUNT);
    }

    public static bool DeleteCUSTOMERACCOUNT(int cUSTOMERACCOUNTID)
    {
        SqlCUSTOMERACCOUNTProvider sqlCUSTOMERACCOUNTProvider = new SqlCUSTOMERACCOUNTProvider();
        return sqlCUSTOMERACCOUNTProvider.DeleteCUSTOMERACCOUNT(cUSTOMERACCOUNTID);
    }
}
