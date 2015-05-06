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

public class ACTIVATIONManager
{
	public ACTIVATIONManager()
	{
	}

    public static List<ACTIVATION> GetAllACTIVATIONs()
    {
        List<ACTIVATION> aCTIVATIONs = new List<ACTIVATION>();
        SqlACTIVATIONProvider sqlACTIVATIONProvider = new SqlACTIVATIONProvider();
        aCTIVATIONs = sqlACTIVATIONProvider.GetAllACTIVATIONs();
        return aCTIVATIONs;
    }


    public static ACTIVATION GetACTIVATIONByID(int id)
    {
        ACTIVATION aCTIVATION = new ACTIVATION();
        SqlACTIVATIONProvider sqlACTIVATIONProvider = new SqlACTIVATIONProvider();
        aCTIVATION = sqlACTIVATIONProvider.GetACTIVATIONByID(id);
        return aCTIVATION;
    }


    public static int InsertACTIVATION(ACTIVATION aCTIVATION)
    {
        SqlACTIVATIONProvider sqlACTIVATIONProvider = new SqlACTIVATIONProvider();
        return sqlACTIVATIONProvider.InsertACTIVATION(aCTIVATION);
    }


    public static bool UpdateACTIVATION(ACTIVATION aCTIVATION)
    {
        SqlACTIVATIONProvider sqlACTIVATIONProvider = new SqlACTIVATIONProvider();
        return sqlACTIVATIONProvider.UpdateACTIVATION(aCTIVATION);
    }

    public static bool DeleteACTIVATION(int aCTIVATIONID)
    {
        SqlACTIVATIONProvider sqlACTIVATIONProvider = new SqlACTIVATIONProvider();
        return sqlACTIVATIONProvider.DeleteACTIVATION(aCTIVATIONID);
    }
}
