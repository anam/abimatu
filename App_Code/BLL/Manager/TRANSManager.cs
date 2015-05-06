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

public class TRANSManager
{
	public TRANSManager()
	{
	}

    public static List<TRANS> GetAllTRANSs()
    {
        List<TRANS> tRANSs = new List<TRANS>();
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        tRANSs = sqlTRANSProvider.GetAllTRANSs();
        return tRANSs;
    }

    public static List<TRANS> GetAllTRANSsByCustomerID(int customerID)
    {
        List<TRANS> tRANSs = new List<TRANS>();
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        tRANSs = sqlTRANSProvider.GetAllTRANSsByCustomerID(customerID);
        return tRANSs;
    }

    public static List<TRANS> GetTRANSsByAGENTID(int aGENTID)
    {
        List<TRANS> tRANSs = new List<TRANS>();
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        tRANSs = sqlTRANSProvider.GetTRANSByAgnetID(aGENTID);
        return tRANSs;
    }



    public static List<TRANS> GetAllTRANSsByTRANSDT_CUSTOMER(int cUSTOMERID, DateTime tRANSDT)
    {
        List<TRANS> tRANSs = new List<TRANS>();
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        tRANSs = sqlTRANSProvider.GetAllTRANSsByTRANSDT_CUSTOMER(cUSTOMERID, tRANSDT);
        return tRANSs;
    }


    public static List<TRANS> GetTRANSsByAGENTIDByDateNAmount(int aGENTID,string fromDate, string toDate, int amount)
    {
        List<TRANS> tRANSs = new List<TRANS>();
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        tRANSs = sqlTRANSProvider.GetTRANSByAgnetIDByDateNAmount(aGENTID,fromDate,  toDate, amount);
        return tRANSs;
    }


    public static List<TRANS> GetAllSARFromTransBYDate(DateTime fromDate, DateTime toDate)
    {
        List<TRANS> tRANSs = new List<TRANS>();
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        tRANSs = sqlTRANSProvider.GetAllSARFromTransBYDate(fromDate, toDate);
        return tRANSs;
    }

    public static List<TRANS> GetTRANSByAgnetIDnLocationIDByDateNAmount(int locationID,int aGENTID, string fromDate, string toDate, int amount)
    {
        List<TRANS> tRANSs = new List<TRANS>();
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        tRANSs = sqlTRANSProvider.GetTRANSByAgnetIDnLocationIDByDateNAmount(locationID, aGENTID, fromDate, toDate, amount);
        return tRANSs;
    }

    public static List<TRANS> GetTRANSByAgnetIDnLocationIDByDateNAmountStatus(string status, int locationID, int aGENTID, string fromDate, string toDate, int amount)
    {
        List<TRANS> tRANSs = new List<TRANS>();
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        tRANSs = sqlTRANSProvider.GetTRANSByAgnetIDnLocationIDByDateNAmountStatus(status, locationID, aGENTID, fromDate, toDate, amount);
        return tRANSs;
    }

    public static List<TRANS> GetTRANSByAgnetIDnLocationIDByDateNAmountCustomerID(string customerIDs, string receiverIDs, int locationID, int aGENTID, string fromDate, string toDate, int amount)
    {
        List<TRANS> tRANSs = new List<TRANS>();
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        tRANSs = sqlTRANSProvider.GetTRANSByAgnetIDnLocationIDByDateNAmountCustomerID(customerIDs, receiverIDs,locationID, aGENTID, fromDate, toDate, amount);
        return tRANSs;
    }

    public static List<TRANS> GetTRANSByAgnetIDnLocationIDsByDateNAmount(string locationIDs, int aGENTID, string fromDate, string toDate, int amount)
    {
        List<TRANS> tRANSs = new List<TRANS>();
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        tRANSs = sqlTRANSProvider.GetTRANSByAgnetIDnLocationIDsByDateNAmount(locationIDs, aGENTID, fromDate, toDate, amount);
        return tRANSs;
    }

    public static TRANS GetTRANSByID(int id)
    {
        TRANS tRANS = new TRANS();
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        tRANS = sqlTRANSProvider.GetTRANSByID(id);
        return tRANS;
    }

    public static TRANS GetTRANSByRefCode(string refCode)
    {
        TRANS tRANS = new TRANS();
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        tRANS = sqlTRANSProvider.GetTRANSByRefCode(refCode);
        return tRANS;
    }

    public static int InsertTRANS(TRANS tRANS)
    {
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        return sqlTRANSProvider.InsertTRANS(tRANS);
    }


    public static bool UpdateTRANS(TRANS tRANS)
    {
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        return sqlTRANSProvider.UpdateTRANS(tRANS);
    }

    public static bool UpdateTRANS_Paid(TRANS tRANS)
    {
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        return sqlTRANSProvider.UpdateTRANS_Paid(tRANS);
    }

    public static bool DeleteTRANS(int tRANSID)
    {
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        return sqlTRANSProvider.DeleteTRANS(tRANSID);
    }


    public static bool UpdateTRANSByCustomerID(int previousCustomerID ,int newCustomerID)
    {
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        return sqlTRANSProvider.UpdateTRANSByCustomerID(previousCustomerID, newCustomerID);
    }

    public static bool UpdateTRANSByReceiverID(int previousReceiverID, int newReceiverID)
    {
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        return sqlTRANSProvider.UpdateTRANSByReceiverID(previousReceiverID, newReceiverID);
    }

    public static bool UpdateTRANSByLocationID(int previousLocationID, int newLocationID)
    {
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        return sqlTRANSProvider.UpdateTRANSByLocationID(previousLocationID, newLocationID);
    }

    public static bool UpdateTRANSByAgentID(int previousAgentID, int newAgentID)
    {
        SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
        return sqlTRANSProvider.UpdateTRANSByAgentID(previousAgentID, newAgentID);
    }
}
