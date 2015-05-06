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

public class SHIFTManager
{
	public SHIFTManager()
	{
	}

    public static List<SHIFT> GetAllSHIFTs()
    {
        List<SHIFT> sHIFTs = new List<SHIFT>();
        SqlSHIFTProvider sqlSHIFTProvider = new SqlSHIFTProvider();
        sHIFTs = sqlSHIFTProvider.GetAllSHIFTs();
        return sHIFTs;
    }


    public static SHIFT GetSHIFTByID(int id)
    {
        SHIFT sHIFT = new SHIFT();
        SqlSHIFTProvider sqlSHIFTProvider = new SqlSHIFTProvider();
        sHIFT = sqlSHIFTProvider.GetSHIFTByID(id);
        return sHIFT;
    }


    public static int InsertSHIFT(SHIFT sHIFT)
    {
        SqlSHIFTProvider sqlSHIFTProvider = new SqlSHIFTProvider();
        return sqlSHIFTProvider.InsertSHIFT(sHIFT);
    }


    public static bool UpdateSHIFT(SHIFT sHIFT)
    {
        SqlSHIFTProvider sqlSHIFTProvider = new SqlSHIFTProvider();
        return sqlSHIFTProvider.UpdateSHIFT(sHIFT);
    }

    public static bool DeleteSHIFT(int sHIFTID)
    {
        SqlSHIFTProvider sqlSHIFTProvider = new SqlSHIFTProvider();
        return sqlSHIFTProvider.DeleteSHIFT(sHIFTID);
    }
}
