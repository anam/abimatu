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

public class FOODITEM_TRANSMASTER
{
    public FOODITEM_TRANSMASTER()
    {
    }

    public FOODITEM_TRANSMASTER
        (
        int fOODITEM_TRANSMASTERID,
        DateTime tDATE,
        int cID,
        int lID,
        int aID,
        decimal tOTALAMT,
        string tRANSSTATUS,
        string rEFCODE,
        int rECID,
        DateTime rECDATE,
        int sTOREID,
        DateTime cREATEDON,
        int cREATEDBY,
        DateTime uPDATEDON,
        int uPDATEDBY
        )
    {
        this.FOODITEM_TRANSMASTERID = fOODITEM_TRANSMASTERID;
        this.TDATE = tDATE;
        this.CID = cID;
        this.LID = lID;
        this.AID = aID;
        this.TOTALAMT = tOTALAMT;
        this.TRANSSTATUS = tRANSSTATUS;
        this.REFCODE = rEFCODE;
        this.RECID = rECID;
        this.RECDATE = rECDATE;
        this.STOREID = sTOREID;
        this.CREATEDON = cREATEDON;
        this.CREATEDBY = cREATEDBY;
        this.UPDATEDON = uPDATEDON;
        this.UPDATEDBY = uPDATEDBY;
    }



    public FOODITEM_TRANSMASTER
    (
    int fOODITEM_TRANSMASTERID,
    DateTime tDATE,
    int cID,
    int lID,
    int aID,
    decimal tOTALAMT,
    string tRANSSTATUS,
    string rEFCODE,
    int rECID,
    DateTime rECDATE,
    int sTOREID,
    DateTime cREATEDON,
    int cREATEDBY,
    DateTime uPDATEDON,
    int uPDATEDBY,
        string cOUNTRY,
        string cITY,
        string bRANCH,
        string bRANCH_CODE,
        string cUSTOMERFULLNAME,
        string rECEIVERFULLNAME
        )
    {
        this.FOODITEM_TRANSMASTERID = fOODITEM_TRANSMASTERID;
        this.TDATE = tDATE;
        this.CID = cID;
        this.LID = lID;
        this.AID = aID;
        this.TOTALAMT = tOTALAMT;
        this.TRANSSTATUS = tRANSSTATUS;
        this.REFCODE = rEFCODE;
        this.RECID = rECID;
        this.RECDATE = rECDATE;
        this.STOREID = sTOREID;
        this.CREATEDON = cREATEDON;
        this.CREATEDBY = cREATEDBY;
        this.UPDATEDON = uPDATEDON;
        this.UPDATEDBY = uPDATEDBY;
        this.COUNTRY = cOUNTRY;
        this.CITY = cITY;
        this.BRANCH = bRANCH;
        this.BRANCH_CODE = bRANCH_CODE;
        this.CUSTOMERFULLNAME = cUSTOMERFULLNAME;
        this.RECEIVERFULLNAME = rECEIVERFULLNAME;
    }


    private int _fOODITEM_TRANSMASTERID;
    public int FOODITEM_TRANSMASTERID
    {
        get { return _fOODITEM_TRANSMASTERID; }
        set { _fOODITEM_TRANSMASTERID = value; }
    }

    private DateTime _tDATE;
    public DateTime TDATE
    {
        get { return _tDATE; }
        set { _tDATE = value; }
    }

    private int _cID;
    public int CID
    {
        get { return _cID; }
        set { _cID = value; }
    }

    private int _lID;
    public int LID
    {
        get { return _lID; }
        set { _lID = value; }
    }

    private int _aID;
    public int AID
    {
        get { return _aID; }
        set { _aID = value; }
    }

    private decimal _tOTALAMT;
    public decimal TOTALAMT
    {
        get { return _tOTALAMT; }
        set { _tOTALAMT = value; }
    }

    private string _tRANSSTATUS;
    public string TRANSSTATUS
    {
        get { return _tRANSSTATUS; }
        set { _tRANSSTATUS = value; }
    }

    private string _rEFCODE;
    public string REFCODE
    {
        get { return _rEFCODE; }
        set { _rEFCODE = value; }
    }

    private int _rECID;
    public int RECID
    {
        get { return _rECID; }
        set { _rECID = value; }
    }

    private DateTime _rECDATE;
    public DateTime RECDATE
    {
        get { return _rECDATE; }
        set { _rECDATE = value; }
    }

    private int _sTOREID;
    public int STOREID
    {
        get { return _sTOREID; }
        set { _sTOREID = value; }
    }

    private DateTime _cREATEDON;
    public DateTime CREATEDON
    {
        get { return _cREATEDON; }
        set { _cREATEDON = value; }
    }

    private int _cREATEDBY;
    public int CREATEDBY
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

    private int _uPDATEDBY;
    public int UPDATEDBY
    {
        get { return _uPDATEDBY; }
        set { _uPDATEDBY = value; }
    }


    private string _cOUNTRY;
    public string COUNTRY
    {
        get { return _cOUNTRY; }
        set { _cOUNTRY = value; }
    }

    private string _cITY;
    public string CITY
    {
        get { return _cITY; }
        set { _cITY = value; }
    }

    private string _bRANCH;
    public string BRANCH
    {
        get { return _bRANCH; }
        set { _bRANCH = value; }
    }

    private string _bRANCH_CODE;
    public string BRANCH_CODE
    {
        get { return _bRANCH_CODE; }
        set { _bRANCH_CODE = value; }
    }

    private string _cUSTOMERFULLNAME;
    public string CUSTOMERFULLNAME
    {
        get { return _cUSTOMERFULLNAME; }
        set { _cUSTOMERFULLNAME = value; }
    }


    private string _rECEIVERFULLNAME;
    public string RECEIVERFULLNAME
    {
        get { return _rECEIVERFULLNAME; }
        set { _rECEIVERFULLNAME = value; }
    }

    private bool _isAmountVisible;

    public bool IsAmountVisible
    {
        get { return _isAmountVisible; }
        set { _isAmountVisible = value; }
    }

}
