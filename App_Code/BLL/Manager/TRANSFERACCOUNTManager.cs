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

public class TRANSFERACCOUNTManager
{
	public TRANSFERACCOUNTManager()
	{
	}

    public static List<TRANSFERACCOUNT> GetAllTRANSFERACCOUNTs()
    {
        List<TRANSFERACCOUNT> tRANSFERACCOUNTs = new List<TRANSFERACCOUNT>();
        SqlTRANSFERACCOUNTProvider sqlTRANSFERACCOUNTProvider = new SqlTRANSFERACCOUNTProvider();
        tRANSFERACCOUNTs = sqlTRANSFERACCOUNTProvider.GetAllTRANSFERACCOUNTs();
        return tRANSFERACCOUNTs;
    }


    public static TRANSFERACCOUNT GetTRANSFERACCOUNTByID(int id)
    {
        TRANSFERACCOUNT tRANSFERACCOUNT = new TRANSFERACCOUNT();
        SqlTRANSFERACCOUNTProvider sqlTRANSFERACCOUNTProvider = new SqlTRANSFERACCOUNTProvider();
        tRANSFERACCOUNT = sqlTRANSFERACCOUNTProvider.GetTRANSFERACCOUNTByID(id);
        return tRANSFERACCOUNT;
    }


    public static int InsertTRANSFERACCOUNT(TRANSFERACCOUNT tRANSFERACCOUNT)
    {
        SqlTRANSFERACCOUNTProvider sqlTRANSFERACCOUNTProvider = new SqlTRANSFERACCOUNTProvider();
        return sqlTRANSFERACCOUNTProvider.InsertTRANSFERACCOUNT(tRANSFERACCOUNT);
    }


    public static bool UpdateTRANSFERACCOUNT(TRANSFERACCOUNT tRANSFERACCOUNT)
    {
        SqlTRANSFERACCOUNTProvider sqlTRANSFERACCOUNTProvider = new SqlTRANSFERACCOUNTProvider();
        return sqlTRANSFERACCOUNTProvider.UpdateTRANSFERACCOUNT(tRANSFERACCOUNT);
    }

    public static bool DeleteTRANSFERACCOUNT(int tRANSFERACCOUNTID)
    {
        SqlTRANSFERACCOUNTProvider sqlTRANSFERACCOUNTProvider = new SqlTRANSFERACCOUNTProvider();
        return sqlTRANSFERACCOUNTProvider.DeleteTRANSFERACCOUNT(tRANSFERACCOUNTID);
    }
}
