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

public class MAKER
{
    public MAKER()
    {
    }

    public MAKER
        (
        int mAKERID, 
        string mAKERNAME, 
        string mAKERADDRESS1, 
        string mAKERADDRESS2, 
        string mAKERCITY, 
        char mAKERSTATE, 
        string mAKERZIP, 
        string mAKERPHONE1, 
        string mAKERPHONE2, 
        string mANAGER, 
        string aCCOUNTNO, 
        string rOUTINGNO, 
        int cHECKCOUNT, 
        int cHECKAMOUNT, 
        int bADCHECKCOUNT, 
        int bADCHECKAMOUNT, 
        int aMOUNTDUE, 
        string cREATEDBY, 
        DateTime cREATEDON, 
        string uPDATEDBY, 
        DateTime uPDATEDON, 
        char iSOFACVERIFIED, 
        string mAKERREMARKS
        )
    {
        this.MAKERID = mAKERID;
        this.MAKERNAME = mAKERNAME;
        this.MAKERADDRESS1 = mAKERADDRESS1;
        this.MAKERADDRESS2 = mAKERADDRESS2;
        this.MAKERCITY = mAKERCITY;
        this.MAKERSTATE = mAKERSTATE;
        this.MAKERZIP = mAKERZIP;
        this.MAKERPHONE1 = mAKERPHONE1;
        this.MAKERPHONE2 = mAKERPHONE2;
        this.MANAGER = mANAGER;
        this.ACCOUNTNO = aCCOUNTNO;
        this.ROUTINGNO = rOUTINGNO;
        this.CHECKCOUNT = cHECKCOUNT;
        this.CHECKAMOUNT = cHECKAMOUNT;
        this.BADCHECKCOUNT = bADCHECKCOUNT;
        this.BADCHECKAMOUNT = bADCHECKAMOUNT;
        this.AMOUNTDUE = aMOUNTDUE;
        this.CREATEDBY = cREATEDBY;
        this.CREATEDON = cREATEDON;
        this.UPDATEDBY = uPDATEDBY;
        this.UPDATEDON = uPDATEDON;
        this.ISOFACVERIFIED = iSOFACVERIFIED;
        this.MAKERREMARKS = mAKERREMARKS;
    }


    private int _mAKERID;
    public int MAKERID
    {
        get { return _mAKERID; }
        set { _mAKERID = value; }
    }

    private string _mAKERNAME;
    public string MAKERNAME
    {
        get { return _mAKERNAME; }
        set { _mAKERNAME = value; }
    }

    private string _mAKERADDRESS1;
    public string MAKERADDRESS1
    {
        get { return _mAKERADDRESS1; }
        set { _mAKERADDRESS1 = value; }
    }

    private string _mAKERADDRESS2;
    public string MAKERADDRESS2
    {
        get { return _mAKERADDRESS2; }
        set { _mAKERADDRESS2 = value; }
    }

    private string _mAKERCITY;
    public string MAKERCITY
    {
        get { return _mAKERCITY; }
        set { _mAKERCITY = value; }
    }

    private char _mAKERSTATE;
    public char MAKERSTATE
    {
        get { return _mAKERSTATE; }
        set { _mAKERSTATE = value; }
    }

    private string _mAKERZIP;
    public string MAKERZIP
    {
        get { return _mAKERZIP; }
        set { _mAKERZIP = value; }
    }

    private string _mAKERPHONE1;
    public string MAKERPHONE1
    {
        get { return _mAKERPHONE1; }
        set { _mAKERPHONE1 = value; }
    }

    private string _mAKERPHONE2;
    public string MAKERPHONE2
    {
        get { return _mAKERPHONE2; }
        set { _mAKERPHONE2 = value; }
    }

    private string _mANAGER;
    public string MANAGER
    {
        get { return _mANAGER; }
        set { _mANAGER = value; }
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

    private int _cHECKCOUNT;
    public int CHECKCOUNT
    {
        get { return _cHECKCOUNT; }
        set { _cHECKCOUNT = value; }
    }

    private int _cHECKAMOUNT;
    public int CHECKAMOUNT
    {
        get { return _cHECKAMOUNT; }
        set { _cHECKAMOUNT = value; }
    }

    private int _bADCHECKCOUNT;
    public int BADCHECKCOUNT
    {
        get { return _bADCHECKCOUNT; }
        set { _bADCHECKCOUNT = value; }
    }

    private int _bADCHECKAMOUNT;
    public int BADCHECKAMOUNT
    {
        get { return _bADCHECKAMOUNT; }
        set { _bADCHECKAMOUNT = value; }
    }

    private int _aMOUNTDUE;
    public int AMOUNTDUE
    {
        get { return _aMOUNTDUE; }
        set { _aMOUNTDUE = value; }
    }

    private string _cREATEDBY;
    public string CREATEDBY
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

    private string _uPDATEDBY;
    public string UPDATEDBY
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

    private char _iSOFACVERIFIED;
    public char ISOFACVERIFIED
    {
        get { return _iSOFACVERIFIED; }
        set { _iSOFACVERIFIED = value; }
    }

    private string _mAKERREMARKS;
    public string MAKERREMARKS
    {
        get { return _mAKERREMARKS; }
        set { _mAKERREMARKS = value; }
    }
}
