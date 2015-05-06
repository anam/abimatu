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

public class IMGAEManager
{
	public IMGAEManager()
	{
	}

    public static List<IMGAE> GetAllIMGAEs()
    {
        List<IMGAE> iMGAEs = new List<IMGAE>();
        SqlIMGAEProvider sqlIMGAEProvider = new SqlIMGAEProvider();
        iMGAEs = sqlIMGAEProvider.GetAllIMGAEs();
        return iMGAEs;
    }


    public static IMGAE GetIMGAEByID(int id)
    {
        IMGAE iMGAE = new IMGAE();
        SqlIMGAEProvider sqlIMGAEProvider = new SqlIMGAEProvider();
        iMGAE = sqlIMGAEProvider.GetIMGAEByID(id);
        return iMGAE;
    }


    public static int InsertIMGAE(IMGAE iMGAE)
    {
        SqlIMGAEProvider sqlIMGAEProvider = new SqlIMGAEProvider();
        return sqlIMGAEProvider.InsertIMGAE(iMGAE);
    }


    public static bool UpdateIMGAE(IMGAE iMGAE)
    {
        SqlIMGAEProvider sqlIMGAEProvider = new SqlIMGAEProvider();
        return sqlIMGAEProvider.UpdateIMGAE(iMGAE);
    }

    public static bool DeleteIMGAE(int iMGAEID)
    {
        SqlIMGAEProvider sqlIMGAEProvider = new SqlIMGAEProvider();
        return sqlIMGAEProvider.DeleteIMGAE(iMGAEID);
    }
}
