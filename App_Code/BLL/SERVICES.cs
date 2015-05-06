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

public class SERVICES
{
    public SERVICES()
    {
    }

    public SERVICES
        (
        int sERVICESID, 
        string sERVICETYPE, 
        string sERVICENAME, 
        int sERVICEFEE, 
        string iSQUICKACCESS, 
        string iSTAXABLE, 
        string pAYMENTMODE, 
        int iTEMINSTOCK, 
        int rEORDERLEVEL, 
        int cOSTPRICE, 
        int rETAILPRICE, 
        DateTime cREATEDON, 
        string cREATEDBY, 
        DateTime uPDATEDON, 
        string uPDATEDBY, 
        int cOMM, 
        string iSCOMMCOUNTED, 
        int sERVICECOMM, 
        int sTORECOMM, 
        string qUICKBOOKSERVICENAME, 
        string qUICKBOOKSERVICEACCOUNT
        )
    {
        this.SERVICESID = sERVICESID;
        this.SERVICETYPE = sERVICETYPE;
        this.SERVICENAME = sERVICENAME;
        this.SERVICEFEE = sERVICEFEE;
        this.ISQUICKACCESS = iSQUICKACCESS;
        this.ISTAXABLE = iSTAXABLE;
        this.PAYMENTMODE = pAYMENTMODE;
        this.ITEMINSTOCK = iTEMINSTOCK;
        this.REORDERLEVEL = rEORDERLEVEL;
        this.COSTPRICE = cOSTPRICE;
        this.RETAILPRICE = rETAILPRICE;
        this.CREATEDON = cREATEDON;
        this.CREATEDBY = cREATEDBY;
        this.UPDATEDON = uPDATEDON;
        this.UPDATEDBY = uPDATEDBY;
        this.COMM = cOMM;
        this.ISCOMMCOUNTED = iSCOMMCOUNTED;
        this.SERVICECOMM = sERVICECOMM;
        this.STORECOMM = sTORECOMM;
        this.QUICKBOOKSERVICENAME = qUICKBOOKSERVICENAME;
        this.QUICKBOOKSERVICEACCOUNT = qUICKBOOKSERVICEACCOUNT;
    }


    private int _sERVICESID;
    public int SERVICESID
    {
        get { return _sERVICESID; }
        set { _sERVICESID = value; }
    }

    private string _sERVICETYPE;
    public string SERVICETYPE
    {
        get { return _sERVICETYPE; }
        set { _sERVICETYPE = value; }
    }

    private string _sERVICENAME;
    public string SERVICENAME
    {
        get { return _sERVICENAME; }
        set { _sERVICENAME = value; }
    }

    private int _sERVICEFEE;
    public int SERVICEFEE
    {
        get { return _sERVICEFEE; }
        set { _sERVICEFEE = value; }
    }

    private string _iSQUICKACCESS;
    public string ISQUICKACCESS
    {
        get { return _iSQUICKACCESS; }
        set { _iSQUICKACCESS = value; }
    }

    private string _iSTAXABLE;
    public string ISTAXABLE
    {
        get { return _iSTAXABLE; }
        set { _iSTAXABLE = value; }
    }

    private string _pAYMENTMODE;
    public string PAYMENTMODE
    {
        get { return _pAYMENTMODE; }
        set { _pAYMENTMODE = value; }
    }

    private int _iTEMINSTOCK;
    public int ITEMINSTOCK
    {
        get { return _iTEMINSTOCK; }
        set { _iTEMINSTOCK = value; }
    }

    private int _rEORDERLEVEL;
    public int REORDERLEVEL
    {
        get { return _rEORDERLEVEL; }
        set { _rEORDERLEVEL = value; }
    }

    private int _cOSTPRICE;
    public int COSTPRICE
    {
        get { return _cOSTPRICE; }
        set { _cOSTPRICE = value; }
    }

    private int _rETAILPRICE;
    public int RETAILPRICE
    {
        get { return _rETAILPRICE; }
        set { _rETAILPRICE = value; }
    }

    private DateTime _cREATEDON;
    public DateTime CREATEDON
    {
        get { return _cREATEDON; }
        set { _cREATEDON = value; }
    }

    private string _cREATEDBY;
    public string CREATEDBY
    {
        get { return _cREATEDBY; }
        set { _cREATEDBY = value; }
    }

    private DateTime _uPDATEDON;
    public DateTime UPDATEDON
    {
        get { return _uPDATEDON; }
        set { _uPDATEDON = value; }
    }

    private string _uPDATEDBY;
    public string UPDATEDBY
    {
        get { return _uPDATEDBY; }
        set { _uPDATEDBY = value; }
    }

    private int _cOMM;
    public int COMM
    {
        get { return _cOMM; }
        set { _cOMM = value; }
    }

    private string _iSCOMMCOUNTED;
    public string ISCOMMCOUNTED
    {
        get { return _iSCOMMCOUNTED; }
        set { _iSCOMMCOUNTED = value; }
    }

    private int _sERVICECOMM;
    public int SERVICECOMM
    {
        get { return _sERVICECOMM; }
        set { _sERVICECOMM = value; }
    }

    private int _sTORECOMM;
    public int STORECOMM
    {
        get { return _sTORECOMM; }
        set { _sTORECOMM = value; }
    }

    private string _qUICKBOOKSERVICENAME;
    public string QUICKBOOKSERVICENAME
    {
        get { return _qUICKBOOKSERVICENAME; }
        set { _qUICKBOOKSERVICENAME = value; }
    }

    private string _qUICKBOOKSERVICEACCOUNT;
    public string QUICKBOOKSERVICEACCOUNT
    {
        get { return _qUICKBOOKSERVICEACCOUNT; }
        set { _qUICKBOOKSERVICEACCOUNT = value; }
    }
}
