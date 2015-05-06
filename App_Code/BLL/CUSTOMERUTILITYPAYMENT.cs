using System;
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

public class CUSTOMERUTILITYPAYMENT
{
    public CUSTOMERUTILITYPAYMENT()
    {
    }

    public CUSTOMERUTILITYPAYMENT
        (
        int cUSTOMERUTILITYPAYMENTID, 
        string cUSTID, 
        string uTILITYID, 
        string aCCOUNTNUMBER
        )
    {
        this.CUSTOMERUTILITYPAYMENTID = cUSTOMERUTILITYPAYMENTID;
        this.CUSTID = cUSTID;
        this.UTILITYID = uTILITYID;
        this.ACCOUNTNUMBER = aCCOUNTNUMBER;
    }


    private int _cUSTOMERUTILITYPAYMENTID;
    public int CUSTOMERUTILITYPAYMENTID
    {
        get { return _cUSTOMERUTILITYPAYMENTID; }
        set { _cUSTOMERUTILITYPAYMENTID = value; }
    }

    private string _cUSTID;
    public string CUSTID
    {
        get { return _cUSTID; }
        set { _cUSTID = value; }
    }

    private string _uTILITYID;
    public string UTILITYID
    {
        get { return _uTILITYID; }
        set { _uTILITYID = value; }
    }

    private string _aCCOUNTNUMBER;
    public string ACCOUNTNUMBER
    {
        get { return _aCCOUNTNUMBER; }
        set { _aCCOUNTNUMBER = value; }
    }
}
