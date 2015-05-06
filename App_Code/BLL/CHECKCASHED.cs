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

public class CHECKCASHED
{
    public CHECKCASHED()
    {
    }

    public CHECKCASHED
        (
        int cHECKCASHEDID, 
        DateTime cHKDT, 
        int cUSTID, 
        int mAKERID, 
        string cHKTYPE, 
        string cHKNO, 
        int cHKAMOUNT, 
        int cHKFEES, 
        int cHKAMOUNTOWE, 
        char iSDEPOSITED, 
        string eMP_ID, 
        string sHIFT_ID, 
        string sTATION_ID, 
        string cREATEDBY, 
        DateTime cREATEDON, 
        char iSBAD, 
        int bADCHECKAMOUNTOWE, 
        string bADCHECKREMARKS
        )
    {
        this.CHECKCASHEDID = cHECKCASHEDID;
        this.CHKDT = cHKDT;
        this.CUSTID = cUSTID;
        this.MAKERID = mAKERID;
        this.CHKTYPE = cHKTYPE;
        this.CHKNO = cHKNO;
        this.CHKAMOUNT = cHKAMOUNT;
        this.CHKFEES = cHKFEES;
        this.CHKAMOUNTOWE = cHKAMOUNTOWE;
        this.ISDEPOSITED = iSDEPOSITED;
        this.EMP_ID = eMP_ID;
        this.SHIFT_ID = sHIFT_ID;
        this.STATION_ID = sTATION_ID;
        this.CREATEDBY = cREATEDBY;
        this.CREATEDON = cREATEDON;
        this.ISBAD = iSBAD;
        this.BADCHECKAMOUNTOWE = bADCHECKAMOUNTOWE;
        this.BADCHECKREMARKS = bADCHECKREMARKS;
    }


    private int _cHECKCASHEDID;
    public int CHECKCASHEDID
    {
        get { return _cHECKCASHEDID; }
        set { _cHECKCASHEDID = value; }
    }

    private DateTime _cHKDT;
    public DateTime CHKDT
    {
        get { return _cHKDT; }
        set { _cHKDT = value; }
    }

    private int _cUSTID;
    public int CUSTID
    {
        get { return _cUSTID; }
        set { _cUSTID = value; }
    }

    private int _mAKERID;
    public int MAKERID
    {
        get { return _mAKERID; }
        set { _mAKERID = value; }
    }

    private string _cHKTYPE;
    public string CHKTYPE
    {
        get { return _cHKTYPE; }
        set { _cHKTYPE = value; }
    }

    private string _cHKNO;
    public string CHKNO
    {
        get { return _cHKNO; }
        set { _cHKNO = value; }
    }

    private int _cHKAMOUNT;
    public int CHKAMOUNT
    {
        get { return _cHKAMOUNT; }
        set { _cHKAMOUNT = value; }
    }

    private int _cHKFEES;
    public int CHKFEES
    {
        get { return _cHKFEES; }
        set { _cHKFEES = value; }
    }

    private int _cHKAMOUNTOWE;
    public int CHKAMOUNTOWE
    {
        get { return _cHKAMOUNTOWE; }
        set { _cHKAMOUNTOWE = value; }
    }

    private char _iSDEPOSITED;
    public char ISDEPOSITED
    {
        get { return _iSDEPOSITED; }
        set { _iSDEPOSITED = value; }
    }

    private string _eMP_ID;
    public string EMP_ID
    {
        get { return _eMP_ID; }
        set { _eMP_ID = value; }
    }

    private string _sHIFT_ID;
    public string SHIFT_ID
    {
        get { return _sHIFT_ID; }
        set { _sHIFT_ID = value; }
    }

    private string _sTATION_ID;
    public string STATION_ID
    {
        get { return _sTATION_ID; }
        set { _sTATION_ID = value; }
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

    private char _iSBAD;
    public char ISBAD
    {
        get { return _iSBAD; }
        set { _iSBAD = value; }
    }

    private int _bADCHECKAMOUNTOWE;
    public int BADCHECKAMOUNTOWE
    {
        get { return _bADCHECKAMOUNTOWE; }
        set { _bADCHECKAMOUNTOWE = value; }
    }

    private string _bADCHECKREMARKS;
    public string BADCHECKREMARKS
    {
        get { return _bADCHECKREMARKS; }
        set { _bADCHECKREMARKS = value; }
    }
}
