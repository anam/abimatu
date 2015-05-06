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

public class GTRANS
{
    public GTRANS()
    {
    }

    public GTRANS
        (
        int gTRANSID, 
        string uTILITYID, 
        string cUSTID, 
        string sTOREID, 
        string lOCATIONID, 
        DateTime tRANSDATE, 
        string tRANSACC, 
        int tRANSAMT, 
        int tRANSFEES, 
        int tRANSCASH, 
        int tRANSCHECK, 
        string aUTHCODE, 
        string eMPID, 
        string sTATIONID, 
        string sHIFTID, 
        char vOIDFLAG, 
        string vOIDAUTHORIZATION
        )
    {
        this.GTRANSID = gTRANSID;
        this.UTILITYID = uTILITYID;
        this.CUSTID = cUSTID;
        this.STOREID = sTOREID;
        this.LOCATIONID = lOCATIONID;
        this.TRANSDATE = tRANSDATE;
        this.TRANSACC = tRANSACC;
        this.TRANSAMT = tRANSAMT;
        this.TRANSFEES = tRANSFEES;
        this.TRANSCASH = tRANSCASH;
        this.TRANSCHECK = tRANSCHECK;
        this.AUTHCODE = aUTHCODE;
        this.EMPID = eMPID;
        this.STATIONID = sTATIONID;
        this.SHIFTID = sHIFTID;
        this.VOIDFLAG = vOIDFLAG;
        this.VOIDAUTHORIZATION = vOIDAUTHORIZATION;
    }


    private int _gTRANSID;
    public int GTRANSID
    {
        get { return _gTRANSID; }
        set { _gTRANSID = value; }
    }

    private string _uTILITYID;
    public string UTILITYID
    {
        get { return _uTILITYID; }
        set { _uTILITYID = value; }
    }

    private string _cUSTID;
    public string CUSTID
    {
        get { return _cUSTID; }
        set { _cUSTID = value; }
    }

    private string _sTOREID;
    public string STOREID
    {
        get { return _sTOREID; }
        set { _sTOREID = value; }
    }

    private string _lOCATIONID;
    public string LOCATIONID
    {
        get { return _lOCATIONID; }
        set { _lOCATIONID = value; }
    }

    private DateTime _tRANSDATE;
    public DateTime TRANSDATE
    {
        get { return _tRANSDATE; }
        set { _tRANSDATE = value; }
    }

    private string _tRANSACC;
    public string TRANSACC
    {
        get { return _tRANSACC; }
        set { _tRANSACC = value; }
    }

    private int _tRANSAMT;
    public int TRANSAMT
    {
        get { return _tRANSAMT; }
        set { _tRANSAMT = value; }
    }

    private int _tRANSFEES;
    public int TRANSFEES
    {
        get { return _tRANSFEES; }
        set { _tRANSFEES = value; }
    }

    private int _tRANSCASH;
    public int TRANSCASH
    {
        get { return _tRANSCASH; }
        set { _tRANSCASH = value; }
    }

    private int _tRANSCHECK;
    public int TRANSCHECK
    {
        get { return _tRANSCHECK; }
        set { _tRANSCHECK = value; }
    }

    private string _aUTHCODE;
    public string AUTHCODE
    {
        get { return _aUTHCODE; }
        set { _aUTHCODE = value; }
    }

    private string _eMPID;
    public string EMPID
    {
        get { return _eMPID; }
        set { _eMPID = value; }
    }

    private string _sTATIONID;
    public string STATIONID
    {
        get { return _sTATIONID; }
        set { _sTATIONID = value; }
    }

    private string _sHIFTID;
    public string SHIFTID
    {
        get { return _sHIFTID; }
        set { _sHIFTID = value; }
    }

    private char _vOIDFLAG;
    public char VOIDFLAG
    {
        get { return _vOIDFLAG; }
        set { _vOIDFLAG = value; }
    }

    private string _vOIDAUTHORIZATION;
    public string VOIDAUTHORIZATION
    {
        get { return _vOIDAUTHORIZATION; }
        set { _vOIDAUTHORIZATION = value; }
    }
}
