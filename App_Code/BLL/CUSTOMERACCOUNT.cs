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

public class CUSTOMERACCOUNT
{
    public CUSTOMERACCOUNT()
    {
    }

    public CUSTOMERACCOUNT
        (
        int cUSTOMERACCOUNTID, 
        string aCCOUNTNO, 
        int sERVICEID, 
        int cUST_ID
        )
    {
        this.CUSTOMERACCOUNTID = cUSTOMERACCOUNTID;
        this.ACCOUNTNO = aCCOUNTNO;
        this.SERVICEID = sERVICEID;
        this.CUST_ID = cUST_ID;
    }


    private int _cUSTOMERACCOUNTID;
    public int CUSTOMERACCOUNTID
    {
        get { return _cUSTOMERACCOUNTID; }
        set { _cUSTOMERACCOUNTID = value; }
    }

    private string _aCCOUNTNO;
    public string ACCOUNTNO
    {
        get { return _aCCOUNTNO; }
        set { _aCCOUNTNO = value; }
    }

    private int _sERVICEID;
    public int SERVICEID
    {
        get { return _sERVICEID; }
        set { _sERVICEID = value; }
    }

    private int _cUST_ID;
    public int CUST_ID
    {
        get { return _cUST_ID; }
        set { _cUST_ID = value; }
    }
}
