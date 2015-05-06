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

public class TRANS
{
    public TRANS()
    {
    }

    public TRANS
        (
        int tRANSID, 
        int cUSTID, 
        int rECEIVERID, 
        int lOCATIONID, 
        DateTime tRANSDT, 
        decimal tRANSAMOUNT,
        decimal tRANSFEES,
        decimal tRANSOTHERFEES, 
        string cAUSETRANSOTHERFEES,
        string tRANSPROMOCODE, 
        int tRANSPROMO,
        decimal tRANSTOTALAMOUNT, 
        char fLAG_SM_RECEIVER, 
        string sM_RECEIVER, 
        char fLAG_CALL_RECEIVER, 
        string rECEIVERPHONENO, 
        char fLAG_DD, 
        char fLAG_TESTQUESTION, 
        string tESTQUESTION, 
        string tESTANSWER, 
        char fLAG_CALLSENDER, 
        char fLAG_SMSSENDER, 
        char fLAG_EMAILSENDER, 
        string sENDEREMAILADDRESS, 
        string tRANSSTATUS, 
        string tRANSRECEIVEDID, 
        DateTime tRANSRECEIVEDATE, 
        int cREATEDBY, 
        DateTime cREATEDON, 
        int uPDATEDBY, 
        DateTime uPDATEDON, 
        int aGENTID, 
        string rEFCODE
        )
    {
        this.TRANSID = tRANSID;
        this.CUSTID = cUSTID;
        this.RECEIVERID = rECEIVERID;
        this.LOCATIONID = lOCATIONID;
        this.TRANSDT = tRANSDT;
        this.TRANSAMOUNT = tRANSAMOUNT;
        this.TRANSFEES = tRANSFEES;
        this.TRANSOTHERFEES = tRANSOTHERFEES;
        this.CAUSETRANSOTHERFEES = cAUSETRANSOTHERFEES;
        this.TRANSPROMOCODE = tRANSPROMOCODE;
        this.TRANSPROMO = tRANSPROMO;
        this.TRANSTOTALAMOUNT = tRANSTOTALAMOUNT;
        this.FLAG_SM_RECEIVER = fLAG_SM_RECEIVER;
        this.SM_RECEIVER = sM_RECEIVER;
        this.FLAG_CALL_RECEIVER = fLAG_CALL_RECEIVER;
        this.RECEIVERPHONENO = rECEIVERPHONENO;
        this.FLAG_DD = fLAG_DD;
        this.FLAG_TESTQUESTION = fLAG_TESTQUESTION;
        this.TESTQUESTION = tESTQUESTION;
        this.TESTANSWER = tESTANSWER;
        this.FLAG_CALLSENDER = fLAG_CALLSENDER;
        this.FLAG_SMSSENDER = fLAG_SMSSENDER;
        this.FLAG_EMAILSENDER = fLAG_EMAILSENDER;
        this.SENDEREMAILADDRESS = sENDEREMAILADDRESS;
        this.TRANSSTATUS = tRANSSTATUS;
        this.TRANSRECEIVEDID = tRANSRECEIVEDID;
        this.TRANSRECEIVEDATE = tRANSRECEIVEDATE;
        this.CREATEDBY = cREATEDBY;
        this.CREATEDON = cREATEDON;
        this.UPDATEDBY = uPDATEDBY;
        this.UPDATEDON = uPDATEDON;
        this.AGENTID = aGENTID;
        this.REFCODE = rEFCODE;
    }

    public TRANS
    (
    int cUSTID,
    DateTime tRANSDT,
    decimal tRANSTOTALAMOUNT
    )
    {

        this.CUSTID = cUSTID;
        //this.TRANSACDT = tRANSACDT;
        this.TRANSDT = tRANSDT;
        this.TRANSTOTALAMOUNT = tRANSTOTALAMOUNT;
       
    }


    //private string tRANSACDT;
    //public string TRANSACDT
    //{
    //    get { return tRANSACDT; }
    //    set { tRANSACDT = value; }
    //}

    public string USERNAME
    {
        get;
        set;
    }

    private int _tRANSID;
    public int TRANSID
    {
        get { return _tRANSID; }
        set { _tRANSID = value; }
    }

    private int _cUSTID;
    public int CUSTID
    {
        get { return _cUSTID; }
        set { _cUSTID = value; }
    }

    private string _cUSTDETAIL;

    public string CUSTDETAIL
    {
        get { return _cUSTDETAIL; }
        set { _cUSTDETAIL = value; }
    }

    private int _rECEIVERID;
    public int RECEIVERID
    {
        get { return _rECEIVERID; }
        set { _rECEIVERID = value; }
    }

    private string _rECEIVERDETAIL;

    public string RECEIVERDETAIL
    {
        get { return _rECEIVERDETAIL; }
        set { _rECEIVERDETAIL = value; }
    }

    private int _lOCATIONID;
    public int LOCATIONID
    {
        get { return _lOCATIONID; }
        set { _lOCATIONID = value; }
    }

    private string _lOCATIONDETAIL;

    public string LOCATIONDETAIL
    {
        get { return _lOCATIONDETAIL; }
        set { _lOCATIONDETAIL = value; }
    }

    private DateTime _tRANSDT;
    public DateTime TRANSDT
    {
        get { return _tRANSDT; }
        set { _tRANSDT = value; }
    }

    /// <summary>
    /// Basically TRANSAMOUNT= the amount client wants to send
    /// Total_fee= TRANSFEES+TRANSOTHERFEES
    /// TRANSPROMO= is the discount
    /// TRANSTOTALAMOUNT = (TRANSAMOUNT- TRANSPROMO) + Total_fee
    /// here the fee will be unchanged TRANSPROMO will affect the the TRANSAMOUNT
    /// </summary>

    private decimal _tRANSAMOUNT;
    public decimal TRANSAMOUNT
    {
        get { return _tRANSAMOUNT; }
        set { _tRANSAMOUNT = value; }
    }

    private decimal _totalAmountWitinLastTenDays;

    public decimal TotalAmountWitinLastTenDays
    {
        get { return _totalAmountWitinLastTenDays; }
        set { _totalAmountWitinLastTenDays = value; }
    }

    private string _totalAmountWitinLastTenDaysText;

    public string TotalAmountWitinLastTenDaysText
    {
        get { return _totalAmountWitinLastTenDaysText; }
        set { _totalAmountWitinLastTenDaysText = value; }
    }

    private decimal _tRANSFEES;
    public decimal TRANSFEES
    {
        get { return _tRANSFEES; }
        set { _tRANSFEES = value; }
    }

    private decimal _tRANSOTHERFEES;
    public decimal TRANSOTHERFEES
    {
        get { return _tRANSOTHERFEES; }
        set { _tRANSOTHERFEES = value; }
    }


    private string _cAUSETRANSOTHERFEES;
    public string CAUSETRANSOTHERFEES
    {
        get { return _cAUSETRANSOTHERFEES; }
        set { _cAUSETRANSOTHERFEES = value; }
    }

    private string _tRANSPROMOCODE;
    public string TRANSPROMOCODE
    {
        get { return _tRANSPROMOCODE; }
        set { _tRANSPROMOCODE = value; }
    }

    private int _tRANSPROMO;
    public int TRANSPROMO
    {
        get { return _tRANSPROMO; }
        set { _tRANSPROMO = value; }
    }

    private decimal _tRANSTOTALAMOUNT;
    public decimal TRANSTOTALAMOUNT
    {
        get { return _tRANSTOTALAMOUNT; }
        set { _tRANSTOTALAMOUNT = value; }
    }

    private char _fLAG_SM_RECEIVER;
    public char FLAG_SM_RECEIVER
    {
        get { return _fLAG_SM_RECEIVER; }
        set { _fLAG_SM_RECEIVER = value; }
    }

    private string _sM_RECEIVER;
    public string SM_RECEIVER
    {
        get { return _sM_RECEIVER; }
        set { _sM_RECEIVER = value; }
    }

    private char _fLAG_CALL_RECEIVER;
    public char FLAG_CALL_RECEIVER
    {
        get { return _fLAG_CALL_RECEIVER; }
        set { _fLAG_CALL_RECEIVER = value; }
    }

    private string _rECEIVERPHONENO;
    public string RECEIVERPHONENO
    {
        get { return _rECEIVERPHONENO; }
        set { _rECEIVERPHONENO = value; }
    }

    private char _fLAG_DD;
    public char FLAG_DD
    {
        get { return _fLAG_DD; }
        set { _fLAG_DD = value; }
    }

    private char _fLAG_TESTQUESTION;
    public char FLAG_TESTQUESTION
    {
        get { return _fLAG_TESTQUESTION; }
        set { _fLAG_TESTQUESTION = value; }
    }

    private string _tESTQUESTION;
    public string TESTQUESTION
    {
        get { return _tESTQUESTION; }
        set { _tESTQUESTION = value; }
    }

    private string _tESTANSWER;
    public string TESTANSWER
    {
        get { return _tESTANSWER; }
        set { _tESTANSWER = value; }
    }

    private char _fLAG_CALLSENDER;
    public char FLAG_CALLSENDER
    {
        get { return _fLAG_CALLSENDER; }
        set { _fLAG_CALLSENDER = value; }
    }

    private char _fLAG_SMSSENDER;
    public char FLAG_SMSSENDER
    {
        get { return _fLAG_SMSSENDER; }
        set { _fLAG_SMSSENDER = value; }
    }

    private char _fLAG_EMAILSENDER;
    public char FLAG_EMAILSENDER
    {
        get { return _fLAG_EMAILSENDER; }
        set { _fLAG_EMAILSENDER = value; }
    }

    private string _sENDEREMAILADDRESS;
    public string SENDEREMAILADDRESS
    {
        get { return _sENDEREMAILADDRESS; }
        set { _sENDEREMAILADDRESS = value; }
    }

    private string _tRANSSTATUS;
    public string TRANSSTATUS
    {
        get { return _tRANSSTATUS; }
        set { _tRANSSTATUS = value; }
    }

    private bool isPending;

    public bool IsPending
    {
        get { return isPending; }
        set { isPending = value; }
    }

    private bool isEdit;

    public bool IsEdit
    {
        get { return isEdit; }
        set { isEdit = value; }
    }

    private string _tRANSRECEIVEDID;
    public string TRANSRECEIVEDID
    {
        get { return _tRANSRECEIVEDID; }
        set { _tRANSRECEIVEDID = value; }
    }

    private DateTime _tRANSRECEIVEDATE;
    public DateTime TRANSRECEIVEDATE
    {
        get { return _tRANSRECEIVEDATE; }
        set { _tRANSRECEIVEDATE = value; }
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

    private int _aGENTID;
    public int AGENTID
    {
        get { return _aGENTID; }
        set { _aGENTID = value; }
    }

    private string _rEFCODE;
    public string REFCODE
    {
        get { return _rEFCODE; }
        set { _rEFCODE = value; }
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

    public bool IsSUS
    { get; set; }

    public bool IsNotSUS
    { get; set; }
}
