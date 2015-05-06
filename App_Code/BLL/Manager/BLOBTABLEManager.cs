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

public class BLOBTABLEManager
{
	public BLOBTABLEManager()
	{
	}

    public static List<BLOBTABLE> GetAllBLOBTABLEs()
    {
        List<BLOBTABLE> bLOBTABLEs = new List<BLOBTABLE>();
        SqlBLOBTABLEProvider sqlBLOBTABLEProvider = new SqlBLOBTABLEProvider();
        bLOBTABLEs = sqlBLOBTABLEProvider.GetAllBLOBTABLEs();
        return bLOBTABLEs;
    }


    public static BLOBTABLE GetBLOBTABLEByID(int id)
    {
        BLOBTABLE bLOBTABLE = new BLOBTABLE();
        SqlBLOBTABLEProvider sqlBLOBTABLEProvider = new SqlBLOBTABLEProvider();
        bLOBTABLE = sqlBLOBTABLEProvider.GetBLOBTABLEByID(id);
        return bLOBTABLE;
    }


    public static int InsertBLOBTABLE(BLOBTABLE bLOBTABLE)
    {
        SqlBLOBTABLEProvider sqlBLOBTABLEProvider = new SqlBLOBTABLEProvider();
        return sqlBLOBTABLEProvider.InsertBLOBTABLE(bLOBTABLE);
    }


    public static bool UpdateBLOBTABLE(BLOBTABLE bLOBTABLE)
    {
        SqlBLOBTABLEProvider sqlBLOBTABLEProvider = new SqlBLOBTABLEProvider();
        return sqlBLOBTABLEProvider.UpdateBLOBTABLE(bLOBTABLE);
    }

    public static bool DeleteBLOBTABLE(int bLOBTABLEID)
    {
        SqlBLOBTABLEProvider sqlBLOBTABLEProvider = new SqlBLOBTABLEProvider();
        return sqlBLOBTABLEProvider.DeleteBLOBTABLE(bLOBTABLEID);
    }
}
