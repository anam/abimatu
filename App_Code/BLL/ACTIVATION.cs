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

public class ACTIVATION
{
    public ACTIVATION()
    {
    }

    public ACTIVATION
        (
        int aCTIVATIONID, 
        int cUST_ID, 
        string cARRIERTYPE, 
        string aCTIVATIONTYPE, 
        string aCCOUNTNO, 
        string oRDERNO, 
        string dEALERCODE, 
        DateTime aCTIVATIONDATE, 
        string mOBILENO, 
        string sIMM, 
        string iMEI, 
        string rATEPLAN, 
        int cOMMAMOUNT, 
        int sPIFF, 
        int rEBATE, 
        char iSACTIVE, 
        int cREATEDBY, 
        DateTime cREATEDON, 
        int uPDATEDBY, 
        DateTime uPDATEDON
        )
    {
        this.ACTIVATIONID = aCTIVATIONID;
        this.CUST_ID = cUST_ID;
        this.CARRIERTYPE = cARRIERTYPE;
        this.ACTIVATIONTYPE = aCTIVATIONTYPE;
        this.ACCOUNTNO = aCCOUNTNO;
        this.ORDERNO = oRDERNO;
        this.DEALERCODE = dEALERCODE;
        this.ACTIVATIONDATE = aCTIVATIONDATE;
        this.MOBILENO = mOBILENO;
        this.SIMM = sIMM;
        this.IMEI = iMEI;
        this.RATEPLAN = rATEPLAN;
        this.COMMAMOUNT = cOMMAMOUNT;
        this.SPIFF = sPIFF;
        this.REBATE = rEBATE;
        this.ISACTIVE = iSACTIVE;
        this.CREATEDBY = cREATEDBY;
        this.CREATEDON = cREATEDON;
        this.UPDATEDBY = uPDATEDBY;
        this.UPDATEDON = uPDATEDON;
    }


    private int _aCTIVATIONID;
    public int ACTIVATIONID
    {
        get { return _aCTIVATIONID; }
        set { _aCTIVATIONID = value; }
    }

    private int _cUST_ID;
    public int CUST_ID
    {
        get { return _cUST_ID; }
        set { _cUST_ID = value; }
    }

    private string _cARRIERTYPE;
    public string CARRIERTYPE
    {
        get { return _cARRIERTYPE; }
        set { _cARRIERTYPE = value; }
    }

    private string _aCTIVATIONTYPE;
    public string ACTIVATIONTYPE
    {
        get { return _aCTIVATIONTYPE; }
        set { _aCTIVATIONTYPE = value; }
    }

    private string _aCCOUNTNO;
    public string ACCOUNTNO
    {
        get { return _aCCOUNTNO; }
        set { _aCCOUNTNO = value; }
    }

    private string _oRDERNO;
    public string ORDERNO
    {
        get { return _oRDERNO; }
        set { _oRDERNO = value; }
    }

    private string _dEALERCODE;
    public string DEALERCODE
    {
        get { return _dEALERCODE; }
        set { _dEALERCODE = value; }
    }

    private DateTime _aCTIVATIONDATE;
    public DateTime ACTIVATIONDATE
    {
        get { return _aCTIVATIONDATE; }
        set { _aCTIVATIONDATE = value; }
    }

    private string _mOBILENO;
    public string MOBILENO
    {
        get { return _mOBILENO; }
        set { _mOBILENO = value; }
    }

    private string _sIMM;
    public string SIMM
    {
        get { return _sIMM; }
        set { _sIMM = value; }
    }

    private string _iMEI;
    public string IMEI
    {
        get { return _iMEI; }
        set { _iMEI = value; }
    }

    private string _rATEPLAN;
    public string RATEPLAN
    {
        get { return _rATEPLAN; }
        set { _rATEPLAN = value; }
    }

    private int _cOMMAMOUNT;
    public int COMMAMOUNT
    {
        get { return _cOMMAMOUNT; }
        set { _cOMMAMOUNT = value; }
    }

    private int _sPIFF;
    public int SPIFF
    {
        get { return _sPIFF; }
        set { _sPIFF = value; }
    }

    private int _rEBATE;
    public int REBATE
    {
        get { return _rEBATE; }
        set { _rEBATE = value; }
    }

    private char _iSACTIVE;
    public char ISACTIVE
    {
        get { return _iSACTIVE; }
        set { _iSACTIVE = value; }
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
