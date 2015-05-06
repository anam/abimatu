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

public class MAKERManager
{
	public MAKERManager()
	{
	}

    public static List<MAKER> GetAllMAKERs()
    {
        List<MAKER> mAKERs = new List<MAKER>();
        SqlMAKERProvider sqlMAKERProvider = new SqlMAKERProvider();
        mAKERs = sqlMAKERProvider.GetAllMAKERs();
        return mAKERs;
    }


    public static MAKER GetMAKERByID(int id)
    {
        MAKER mAKER = new MAKER();
        SqlMAKERProvider sqlMAKERProvider = new SqlMAKERProvider();
        mAKER = sqlMAKERProvider.GetMAKERByID(id);
        return mAKER;
    }


    public static int InsertMAKER(MAKER mAKER)
    {
        SqlMAKERProvider sqlMAKERProvider = new SqlMAKERProvider();
        return sqlMAKERProvider.InsertMAKER(mAKER);
    }


    public static bool UpdateMAKER(MAKER mAKER)
    {
        SqlMAKERProvider sqlMAKERProvider = new SqlMAKERProvider();
        return sqlMAKERProvider.UpdateMAKER(mAKER);
    }

    public static bool DeleteMAKER(int mAKERID)
    {
        SqlMAKERProvider sqlMAKERProvider = new SqlMAKERProvider();
        return sqlMAKERProvider.DeleteMAKER(mAKERID);
    }
}
