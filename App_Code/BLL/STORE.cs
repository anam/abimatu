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

public class STORE
{
    public STORE()
    {
    }

    public STORE
        (
        int sTOREID, 
        string sTORENAME, 
        string cOMPANYNAME, 
        string aDDRESS, 
        string cITY, 
        string sTATE, 
        string zIP, 
        string pHONE, 
        string aCCOUNTNO, 
        string rOUTINGNO, 
        string sSN, 
        string fTPSERVER, 
        int cREATEDBY, 
        DateTime cREATEDON, 
        int uPDATEDBY, 
        DateTime uPDATEDON
        )
    {
        this.STOREID = sTOREID;
        this.STORENAME = sTORENAME;
        this.COMPANYNAME = cOMPANYNAME;
        this.ADDRESS = aDDRESS;
        this.CITY = cITY;
        this.STATE = sTATE;
        this.ZIP = zIP;
        this.PHONE = pHONE;
        this.ACCOUNTNO = aCCOUNTNO;
        this.ROUTINGNO = rOUTINGNO;
        this.SSN = sSN;
        this.FTPSERVER = fTPSERVER;
        this.CREATEDBY = cREATEDBY;
        this.CREATEDON = cREATEDON;
        this.UPDATEDBY = uPDATEDBY;
        this.UPDATEDON = uPDATEDON;
    }


    private int _sTOREID;
    public int STOREID
    {
        get { return _sTOREID; }
        set { _sTOREID = value; }
    }

    private string _sTORENAME;
    public string STORENAME
    {
        get { return _sTORENAME; }
        set { _sTORENAME = value; }
    }

    private string _cOMPANYNAME;
    public string COMPANYNAME
    {
        get { return _cOMPANYNAME; }
        set { _cOMPANYNAME = value; }
    }

    private string _aDDRESS;
    public string ADDRESS
    {
        get { return _aDDRESS; }
        set { _aDDRESS = value; }
    }

    private string _cITY;
    public string CITY
    {
        get { return _cITY; }
        set { _cITY = value; }
    }

    private string _sTATE;
    public string STATE
    {
        get { return _sTATE; }
        set { _sTATE = value; }
    }

    private string _zIP;
    public string ZIP
    {
        get { return _zIP; }
        set { _zIP = value; }
    }

    private string _pHONE;
    public string PHONE
    {
        get { return _pHONE; }
        set { _pHONE = value; }
    }

    private string _aCCOUNTNO;
    public string ACCOUNTNO
    {
        get { return _aCCOUNTNO; }
        set { _aCCOUNTNO = value; }
    }

    private string _rOUTINGNO;
    public string ROUTINGNO
    {
        get { return _rOUTINGNO; }
        set { _rOUTINGNO = value; }
    }

    private string _sSN;
    public string SSN
    {
        get { return _sSN; }
        set { _sSN = value; }
    }

    private string _fTPSERVER;
    public string FTPSERVER
    {
        get { return _fTPSERVER; }
        set { _fTPSERVER = value; }
    }

    private int _cREATEDBY;
    public int CREATEDBY
    {
        get { return _cREATEDBY; }
        set { _cREATEDBY = value; }
    }

    private DateTime _cREATEDON;
    public DateTime CREATEDON
    {
        get { return _cREATEDON; }
        set { _cREATEDON = value; }
    }

    private int _uPDATEDBY;
    public int UPDATEDBY
    {
        get { return _uPDATEDBY; }
        set { _uPDATEDBY = value; }
    }

    private DateTime _uPDATEDON;
    public DateTime UPDATEDON
    {
        get { return _uPDATEDON; }
        set { _uPDATEDON = value; }
    }
}
