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

public class CUSTOMER
{
    public CUSTOMER()
    {
    }

    public CUSTOMER
        (
        int cUSTOMERID, 
        string eMTID, 
        string uSERNAME, 
        string cUSTFNAME, 
        string cUSTMNAME, 
        string cUSTLNAME, 
        string cUSTADDRESS1, 
        string cUSTADDRESS2, 
        string cUSTCITY, 
        string cUSTSTATE, 
        string cUSTZIP, 
        string cUSTHPHONE, 
        string cUSTCPHONE, 
        string cUSTWPHONE, 
        string cUSTSSN,
        string cUSTDRIVINGLICENSE,
        int cUSTIDTYPE, 
        string cUSTIDNUMBER, 
        DateTime cUSTDOB, 
        DateTime cUSTISSUEDATE, 
        DateTime cUSTEXPIREDATE, 
        string iSOFACVERIFIED, 
        string cUSTREMARKS,
        string sCANURL, 
        int cREATEDBY, 
        DateTime cREATEDON, 
        int uPDATEDBY, 
        DateTime uPDATEDON
        )
    {
        this.CUSTOMERID = cUSTOMERID;
        this.EMTID = eMTID;
        this.USERNAME = uSERNAME;
        this.CUSTFNAME = cUSTFNAME;
        this.CUSTMNAME = cUSTMNAME;
        this.CUSTLNAME = cUSTLNAME;
        this.CUSTADDRESS1 = cUSTADDRESS1;
        this.CUSTADDRESS2 = cUSTADDRESS2;
        this.CUSTCITY = cUSTCITY;
        this.CUSTSTATE = cUSTSTATE;
        this.CUSTZIP = cUSTZIP;
        this.CUSTHPHONE = cUSTHPHONE;
        this.CUSTCPHONE = cUSTCPHONE;
        this.CUSTWPHONE = cUSTWPHONE;
        this.CUSTSSN = cUSTSSN;
        this.CUSTDRIVINGLICENSE = cUSTDRIVINGLICENSE;
        this.CUSTIDTYPE = cUSTIDTYPE;
        this.CUSTIDNUMBER = cUSTIDNUMBER;
        this.CUSTDOB = cUSTDOB;
        this.CUSTISSUEDATE = cUSTISSUEDATE;
        this.CUSTEXPIREDATE = cUSTEXPIREDATE;
        this.ISOFACVERIFIED = iSOFACVERIFIED;
        this.CUSTREMARKS = cUSTREMARKS;
        this.SCANURL = sCANURL;
        this.CREATEDBY = cREATEDBY;
        this.CREATEDON = cREATEDON;
        this.UPDATEDBY = uPDATEDBY;
        this.UPDATEDON = uPDATEDON;
    }


    private int _cUSTOMERID;
    public int CUSTOMERID
    {
        get { return _cUSTOMERID; }
        set { _cUSTOMERID = value; }
    }

    private string _eMTID;
    public string EMTID
    {
        get { return _eMTID; }
        set { _eMTID = value; }
    }

    private string _uSERNAME;
    public string USERNAME
    {
        get { return _uSERNAME; }
        set { _uSERNAME = value; }
    }

    private string _cUSTFNAME;
    public string CUSTFNAME
    {
        get { return _cUSTFNAME; }
        set { _cUSTFNAME = value; }
    }

    private string _cUSTMNAME;
    public string CUSTMNAME
    {
        get { return _cUSTMNAME; }
        set { _cUSTMNAME = value; }
    }

    private string _cUSTLNAME;
    public string CUSTLNAME
    {
        get { return _cUSTLNAME; }
        set { _cUSTLNAME = value; }
    }

    private string _cUSTADDRESS1;
    public string CUSTADDRESS1
    {
        get { return _cUSTADDRESS1; }
        set { _cUSTADDRESS1 = value; }
    }

    private string _cUSTADDRESS2;
    public string CUSTADDRESS2
    {
        get { return _cUSTADDRESS2; }
        set { _cUSTADDRESS2 = value; }
    }

    private string _cUSTCITY;
    public string CUSTCITY
    {
        get { return _cUSTCITY; }
        set { _cUSTCITY = value; }
    }

    private string _cUSTSTATE;
    public string CUSTSTATE
    {
        get { return _cUSTSTATE; }
        set { _cUSTSTATE = value; }
    }

    private string _cUSTZIP;
    public string CUSTZIP
    {
        get { return _cUSTZIP; }
        set { _cUSTZIP = value; }
    }

    private string _cUSTHPHONE;
    public string CUSTHPHONE
    {
        get { return _cUSTHPHONE; }
        set { _cUSTHPHONE = value; }
    }

    private string _cUSTCPHONE;
    public string CUSTCPHONE
    {
        get { return _cUSTCPHONE; }
        set { _cUSTCPHONE = value; }
    }

    private string _cUSTWPHONE;
    public string CUSTWPHONE
    {
        get { return _cUSTWPHONE; }
        set { _cUSTWPHONE = value; }
    }

    private string _cUSTSSN;
    public string CUSTSSN
    {
        get { return _cUSTSSN; }
        set { _cUSTSSN = value; }
    }

    private string _cUSTDRIVINGLICENSE;
    public string CUSTDRIVINGLICENSE
    {
        get { return _cUSTDRIVINGLICENSE; }
        set { _cUSTDRIVINGLICENSE = value; }
    }

    private int _cUSTIDTYPE;
    public int CUSTIDTYPE
    {
        get { return _cUSTIDTYPE; }
        set { _cUSTIDTYPE = value; }
    }

    private string _cUSTIDNUMBER;
    public string CUSTIDNUMBER
    {
        get { return _cUSTIDNUMBER; }
        set { _cUSTIDNUMBER = value; }
    }

    private DateTime _cUSTDOB;
    public DateTime CUSTDOB
    {
        get { return _cUSTDOB; }
        set { _cUSTDOB = value; }
    }

    private DateTime _cUSTISSUEDATE;
    public DateTime CUSTISSUEDATE
    {
        get { return _cUSTISSUEDATE; }
        set { _cUSTISSUEDATE = value; }
    }

    private DateTime _cUSTEXPIREDATE;
    public DateTime CUSTEXPIREDATE
    {
        get { return _cUSTEXPIREDATE; }
        set { _cUSTEXPIREDATE = value; }
    }

    private string _iSOFACVERIFIED;
    public string ISOFACVERIFIED
    {
        get { return _iSOFACVERIFIED; }
        set { _iSOFACVERIFIED = value; }
    }

    private string _cUSTREMARKS;
    public string CUSTREMARKS
    {
        get { return _cUSTREMARKS; }
        set { _cUSTREMARKS = value; }
    }



    private string _sCANURL;
    public string SCANURL
    {
        get { return _sCANURL; }
        set { _sCANURL = value; }
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
