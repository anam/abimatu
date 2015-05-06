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

public class ENDREPORT
{
    public ENDREPORT()
    {
    }

    public ENDREPORT
        (
        int eNDREPORTID, 
        DateTime dT, 
        int bEGININGBALANCE, 
        int cASHFROM1, 
        string cASHFROM1REMARKS, 
        int cASHFROM2, 
        string cASHFROM2REMARKS, 
        int cASHFROM3, 
        string cASHFROM3REMARKS, 
        int cASHFROM4, 
        string cASHFROM4REMARKS, 
        int cASHFROM5, 
        string cASHFROM5REMARKS, 
        int cASHFROM6, 
        string cASHFROM6REMARKS, 
        int cASHFROM7, 
        string cASHFROM7REMARKS, 
        int cASHFROM8, 
        string cASHFROM8REMARKS, 
        int cASHFROM9, 
        string cASHFROM9REMARKS, 
        int cASHFROM10, 
        string cASHFROM10REMARKS, 
        int cASHFROM11, 
        string cASHFROM11REMARKS, 
        int cASHFROM12, 
        string cASHFROM12REMARKS, 
        int wU, 
        int wUCOUNT, 
        int cONVPAY, 
        int cONVPAYCOUNT, 
        int mO, 
        int mOCOMM, 
        int mOCOUNT, 
        int fEDILITY, 
        int fEDILITYCOMM, 
        int fEDILITYCOUNT, 
        int gLOBALEXPRESS, 
        int gLOBALEXPRESSCOMM, 
        int gLOBALEXPRESSCOUNT, 
        int cHECKFREEPAY, 
        int cHECKFREEPAYCOMM, 
        int cHECKFREEPAYCOUNT, 
        int pRECASH, 
        int pRECASHCOMM, 
        int pRECASHCOUNT, 
        int pHONECARD, 
        int iDCARD, 
        int iDCARDCOUNT, 
        int cHECKCOMM, 
        int cHECKCOUNT, 
        int tOTALCASHIN, 
        int cASHDEPOSIT1, 
        int cASHDEPOSIT2, 
        int cASHDEPOSIT3, 
        int cASHDEPOSIT4, 
        int cASHDEPOSIT5, 
        int cHECKDEPOSIT1, 
        int cHECKDEPOSIT2, 
        int cHECKDEPOSIT3, 
        int cHECKDEPOSIT4, 
        int cHECKDEPOSIT5, 
        int cHECKDEPOSIT6, 
        int cHECKDEPOSIT7, 
        int cHECKDEPOSIT8, 
        int cHECKDEPOSIT9, 
        int cHECKDEPOSIT10, 
        int cHECKDEPOSIT11, 
        int cHECKDEPOSIT12, 
        int cASHTRANSFER1, 
        string cASHTRANSFER1REMARKS, 
        int cASHTRANSFER2, 
        string cASHTRANSFER2REMARKS, 
        int cASHTRANSFER3, 
        string cASHTRANSFER3REMARKS, 
        int cASHTRANSFER4, 
        string cASHTRANSFER4REMARKS, 
        int cASHTRANSFER5, 
        string cASHTRANSFER5REMARKS, 
        int cASHTRANSFER6, 
        string cASHTRANSFER6REMARKS, 
        int cASHTRANSFER7, 
        string cASHTRANSFER7REMARKS, 
        int cASHTRANSFER8, 
        string cASHTRANSFER8REMARKS, 
        int fEDILITYDEPOSIT, 
        int cHECKFREEPAYDEPOSIT, 
        int cONVPAYDEPOSIT, 
        int wUPAYOUT, 
        int cREDITCARD, 
        int eXPENSES, 
        int tOTALCASHOUT, 
        int tOTALBALANCE, 
        int aCTUALBALACE, 
        int sHORTOVER
        )
    {
        this.ENDREPORTID = eNDREPORTID;
        this.DT = dT;
        this.BEGININGBALANCE = bEGININGBALANCE;
        this.CASHFROM1 = cASHFROM1;
        this.CASHFROM1REMARKS = cASHFROM1REMARKS;
        this.CASHFROM2 = cASHFROM2;
        this.CASHFROM2REMARKS = cASHFROM2REMARKS;
        this.CASHFROM3 = cASHFROM3;
        this.CASHFROM3REMARKS = cASHFROM3REMARKS;
        this.CASHFROM4 = cASHFROM4;
        this.CASHFROM4REMARKS = cASHFROM4REMARKS;
        this.CASHFROM5 = cASHFROM5;
        this.CASHFROM5REMARKS = cASHFROM5REMARKS;
        this.CASHFROM6 = cASHFROM6;
        this.CASHFROM6REMARKS = cASHFROM6REMARKS;
        this.CASHFROM7 = cASHFROM7;
        this.CASHFROM7REMARKS = cASHFROM7REMARKS;
        this.CASHFROM8 = cASHFROM8;
        this.CASHFROM8REMARKS = cASHFROM8REMARKS;
        this.CASHFROM9 = cASHFROM9;
        this.CASHFROM9REMARKS = cASHFROM9REMARKS;
        this.CASHFROM10 = cASHFROM10;
        this.CASHFROM10REMARKS = cASHFROM10REMARKS;
        this.CASHFROM11 = cASHFROM11;
        this.CASHFROM11REMARKS = cASHFROM11REMARKS;
        this.CASHFROM12 = cASHFROM12;
        this.CASHFROM12REMARKS = cASHFROM12REMARKS;
        this.WU = wU;
        this.WUCOUNT = wUCOUNT;
        this.CONVPAY = cONVPAY;
        this.CONVPAYCOUNT = cONVPAYCOUNT;
        this.MO = mO;
        this.MOCOMM = mOCOMM;
        this.MOCOUNT = mOCOUNT;
        this.FEDILITY = fEDILITY;
        this.FEDILITYCOMM = fEDILITYCOMM;
        this.FEDILITYCOUNT = fEDILITYCOUNT;
        this.GLOBALEXPRESS = gLOBALEXPRESS;
        this.GLOBALEXPRESSCOMM = gLOBALEXPRESSCOMM;
        this.GLOBALEXPRESSCOUNT = gLOBALEXPRESSCOUNT;
        this.CHECKFREEPAY = cHECKFREEPAY;
        this.CHECKFREEPAYCOMM = cHECKFREEPAYCOMM;
        this.CHECKFREEPAYCOUNT = cHECKFREEPAYCOUNT;
        this.PRECASH = pRECASH;
        this.PRECASHCOMM = pRECASHCOMM;
        this.PRECASHCOUNT = pRECASHCOUNT;
        this.PHONECARD = pHONECARD;
        this.IDCARD = iDCARD;
        this.IDCARDCOUNT = iDCARDCOUNT;
        this.CHECKCOMM = cHECKCOMM;
        this.CHECKCOUNT = cHECKCOUNT;
        this.TOTALCASHIN = tOTALCASHIN;
        this.CASHDEPOSIT1 = cASHDEPOSIT1;
        this.CASHDEPOSIT2 = cASHDEPOSIT2;
        this.CASHDEPOSIT3 = cASHDEPOSIT3;
        this.CASHDEPOSIT4 = cASHDEPOSIT4;
        this.CASHDEPOSIT5 = cASHDEPOSIT5;
        this.CHECKDEPOSIT1 = cHECKDEPOSIT1;
        this.CHECKDEPOSIT2 = cHECKDEPOSIT2;
        this.CHECKDEPOSIT3 = cHECKDEPOSIT3;
        this.CHECKDEPOSIT4 = cHECKDEPOSIT4;
        this.CHECKDEPOSIT5 = cHECKDEPOSIT5;
        this.CHECKDEPOSIT6 = cHECKDEPOSIT6;
        this.CHECKDEPOSIT7 = cHECKDEPOSIT7;
        this.CHECKDEPOSIT8 = cHECKDEPOSIT8;
        this.CHECKDEPOSIT9 = cHECKDEPOSIT9;
        this.CHECKDEPOSIT10 = cHECKDEPOSIT10;
        this.CHECKDEPOSIT11 = cHECKDEPOSIT11;
        this.CHECKDEPOSIT12 = cHECKDEPOSIT12;
        this.CASHTRANSFER1 = cASHTRANSFER1;
        this.CASHTRANSFER1REMARKS = cASHTRANSFER1REMARKS;
        this.CASHTRANSFER2 = cASHTRANSFER2;
        this.CASHTRANSFER2REMARKS = cASHTRANSFER2REMARKS;
        this.CASHTRANSFER3 = cASHTRANSFER3;
        this.CASHTRANSFER3REMARKS = cASHTRANSFER3REMARKS;
        this.CASHTRANSFER4 = cASHTRANSFER4;
        this.CASHTRANSFER4REMARKS = cASHTRANSFER4REMARKS;
        this.CASHTRANSFER5 = cASHTRANSFER5;
        this.CASHTRANSFER5REMARKS = cASHTRANSFER5REMARKS;
        this.CASHTRANSFER6 = cASHTRANSFER6;
        this.CASHTRANSFER6REMARKS = cASHTRANSFER6REMARKS;
        this.CASHTRANSFER7 = cASHTRANSFER7;
        this.CASHTRANSFER7REMARKS = cASHTRANSFER7REMARKS;
        this.CASHTRANSFER8 = cASHTRANSFER8;
        this.CASHTRANSFER8REMARKS = cASHTRANSFER8REMARKS;
        this.FEDILITYDEPOSIT = fEDILITYDEPOSIT;
        this.CHECKFREEPAYDEPOSIT = cHECKFREEPAYDEPOSIT;
        this.CONVPAYDEPOSIT = cONVPAYDEPOSIT;
        this.WUPAYOUT = wUPAYOUT;
        this.CREDITCARD = cREDITCARD;
        this.EXPENSES = eXPENSES;
        this.TOTALCASHOUT = tOTALCASHOUT;
        this.TOTALBALANCE = tOTALBALANCE;
        this.ACTUALBALACE = aCTUALBALACE;
        this.SHORTOVER = sHORTOVER;
    }


    private int _eNDREPORTID;
    public int ENDREPORTID
    {
        get { return _eNDREPORTID; }
        set { _eNDREPORTID = value; }
    }

    private DateTime _dT;
    public DateTime DT
    {
        get { return _dT; }
        set { _dT = value; }
    }

    private int _bEGININGBALANCE;
    public int BEGININGBALANCE
    {
        get { return _bEGININGBALANCE; }
        set { _bEGININGBALANCE = value; }
    }

    private int _cASHFROM1;
    public int CASHFROM1
    {
        get { return _cASHFROM1; }
        set { _cASHFROM1 = value; }
    }

    private string _cASHFROM1REMARKS;
    public string CASHFROM1REMARKS
    {
        get { return _cASHFROM1REMARKS; }
        set { _cASHFROM1REMARKS = value; }
    }

    private int _cASHFROM2;
    public int CASHFROM2
    {
        get { return _cASHFROM2; }
        set { _cASHFROM2 = value; }
    }

    private string _cASHFROM2REMARKS;
    public string CASHFROM2REMARKS
    {
        get { return _cASHFROM2REMARKS; }
        set { _cASHFROM2REMARKS = value; }
    }

    private int _cASHFROM3;
    public int CASHFROM3
    {
        get { return _cASHFROM3; }
        set { _cASHFROM3 = value; }
    }

    private string _cASHFROM3REMARKS;
    public string CASHFROM3REMARKS
    {
        get { return _cASHFROM3REMARKS; }
        set { _cASHFROM3REMARKS = value; }
    }

    private int _cASHFROM4;
    public int CASHFROM4
    {
        get { return _cASHFROM4; }
        set { _cASHFROM4 = value; }
    }

    private string _cASHFROM4REMARKS;
    public string CASHFROM4REMARKS
    {
        get { return _cASHFROM4REMARKS; }
        set { _cASHFROM4REMARKS = value; }
    }

    private int _cASHFROM5;
    public int CASHFROM5
    {
        get { return _cASHFROM5; }
        set { _cASHFROM5 = value; }
    }

    private string _cASHFROM5REMARKS;
    public string CASHFROM5REMARKS
    {
        get { return _cASHFROM5REMARKS; }
        set { _cASHFROM5REMARKS = value; }
    }

    private int _cASHFROM6;
    public int CASHFROM6
    {
        get { return _cASHFROM6; }
        set { _cASHFROM6 = value; }
    }

    private string _cASHFROM6REMARKS;
    public string CASHFROM6REMARKS
    {
        get { return _cASHFROM6REMARKS; }
        set { _cASHFROM6REMARKS = value; }
    }

    private int _cASHFROM7;
    public int CASHFROM7
    {
        get { return _cASHFROM7; }
        set { _cASHFROM7 = value; }
    }

    private string _cASHFROM7REMARKS;
    public string CASHFROM7REMARKS
    {
        get { return _cASHFROM7REMARKS; }
        set { _cASHFROM7REMARKS = value; }
    }

    private int _cASHFROM8;
    public int CASHFROM8
    {
        get { return _cASHFROM8; }
        set { _cASHFROM8 = value; }
    }

    private string _cASHFROM8REMARKS;
    public string CASHFROM8REMARKS
    {
        get { return _cASHFROM8REMARKS; }
        set { _cASHFROM8REMARKS = value; }
    }

    private int _cASHFROM9;
    public int CASHFROM9
    {
        get { return _cASHFROM9; }
        set { _cASHFROM9 = value; }
    }

    private string _cASHFROM9REMARKS;
    public string CASHFROM9REMARKS
    {
        get { return _cASHFROM9REMARKS; }
        set { _cASHFROM9REMARKS = value; }
    }

    private int _cASHFROM10;
    public int CASHFROM10
    {
        get { return _cASHFROM10; }
        set { _cASHFROM10 = value; }
    }

    private string _cASHFROM10REMARKS;
    public string CASHFROM10REMARKS
    {
        get { return _cASHFROM10REMARKS; }
        set { _cASHFROM10REMARKS = value; }
    }

    private int _cASHFROM11;
    public int CASHFROM11
    {
        get { return _cASHFROM11; }
        set { _cASHFROM11 = value; }
    }

    private string _cASHFROM11REMARKS;
    public string CASHFROM11REMARKS
    {
        get { return _cASHFROM11REMARKS; }
        set { _cASHFROM11REMARKS = value; }
    }

    private int _cASHFROM12;
    public int CASHFROM12
    {
        get { return _cASHFROM12; }
        set { _cASHFROM12 = value; }
    }

    private string _cASHFROM12REMARKS;
    public string CASHFROM12REMARKS
    {
        get { return _cASHFROM12REMARKS; }
        set { _cASHFROM12REMARKS = value; }
    }

    private int _wU;
    public int WU
    {
        get { return _wU; }
        set { _wU = value; }
    }

    private int _wUCOUNT;
    public int WUCOUNT
    {
        get { return _wUCOUNT; }
        set { _wUCOUNT = value; }
    }

    private int _cONVPAY;
    public int CONVPAY
    {
        get { return _cONVPAY; }
        set { _cONVPAY = value; }
    }

    private int _cONVPAYCOUNT;
    public int CONVPAYCOUNT
    {
        get { return _cONVPAYCOUNT; }
        set { _cONVPAYCOUNT = value; }
    }

    private int _mO;
    public int MO
    {
        get { return _mO; }
        set { _mO = value; }
    }

    private int _mOCOMM;
    public int MOCOMM
    {
        get { return _mOCOMM; }
        set { _mOCOMM = value; }
    }

    private int _mOCOUNT;
    public int MOCOUNT
    {
        get { return _mOCOUNT; }
        set { _mOCOUNT = value; }
    }

    private int _fEDILITY;
    public int FEDILITY
    {
        get { return _fEDILITY; }
        set { _fEDILITY = value; }
    }

    private int _fEDILITYCOMM;
    public int FEDILITYCOMM
    {
        get { return _fEDILITYCOMM; }
        set { _fEDILITYCOMM = value; }
    }

    private int _fEDILITYCOUNT;
    public int FEDILITYCOUNT
    {
        get { return _fEDILITYCOUNT; }
        set { _fEDILITYCOUNT = value; }
    }

    private int _gLOBALEXPRESS;
    public int GLOBALEXPRESS
    {
        get { return _gLOBALEXPRESS; }
        set { _gLOBALEXPRESS = value; }
    }

    private int _gLOBALEXPRESSCOMM;
    public int GLOBALEXPRESSCOMM
    {
        get { return _gLOBALEXPRESSCOMM; }
        set { _gLOBALEXPRESSCOMM = value; }
    }

    private int _gLOBALEXPRESSCOUNT;
    public int GLOBALEXPRESSCOUNT
    {
        get { return _gLOBALEXPRESSCOUNT; }
        set { _gLOBALEXPRESSCOUNT = value; }
    }

    private int _cHECKFREEPAY;
    public int CHECKFREEPAY
    {
        get { return _cHECKFREEPAY; }
        set { _cHECKFREEPAY = value; }
    }

    private int _cHECKFREEPAYCOMM;
    public int CHECKFREEPAYCOMM
    {
        get { return _cHECKFREEPAYCOMM; }
        set { _cHECKFREEPAYCOMM = value; }
    }

    private int _cHECKFREEPAYCOUNT;
    public int CHECKFREEPAYCOUNT
    {
        get { return _cHECKFREEPAYCOUNT; }
        set { _cHECKFREEPAYCOUNT = value; }
    }

    private int _pRECASH;
    public int PRECASH
    {
        get { return _pRECASH; }
        set { _pRECASH = value; }
    }

    private int _pRECASHCOMM;
    public int PRECASHCOMM
    {
        get { return _pRECASHCOMM; }
        set { _pRECASHCOMM = value; }
    }

    private int _pRECASHCOUNT;
    public int PRECASHCOUNT
    {
        get { return _pRECASHCOUNT; }
        set { _pRECASHCOUNT = value; }
    }

    private int _pHONECARD;
    public int PHONECARD
    {
        get { return _pHONECARD; }
        set { _pHONECARD = value; }
    }

    private int _iDCARD;
    public int IDCARD
    {
        get { return _iDCARD; }
        set { _iDCARD = value; }
    }

    private int _iDCARDCOUNT;
    public int IDCARDCOUNT
    {
        get { return _iDCARDCOUNT; }
        set { _iDCARDCOUNT = value; }
    }

    private int _cHECKCOMM;
    public int CHECKCOMM
    {
        get { return _cHECKCOMM; }
        set { _cHECKCOMM = value; }
    }

    private int _cHECKCOUNT;
    public int CHECKCOUNT
    {
        get { return _cHECKCOUNT; }
        set { _cHECKCOUNT = value; }
    }

    private int _tOTALCASHIN;
    public int TOTALCASHIN
    {
        get { return _tOTALCASHIN; }
        set { _tOTALCASHIN = value; }
    }

    private int _cASHDEPOSIT1;
    public int CASHDEPOSIT1
    {
        get { return _cASHDEPOSIT1; }
        set { _cASHDEPOSIT1 = value; }
    }

    private int _cASHDEPOSIT2;
    public int CASHDEPOSIT2
    {
        get { return _cASHDEPOSIT2; }
        set { _cASHDEPOSIT2 = value; }
    }

    private int _cASHDEPOSIT3;
    public int CASHDEPOSIT3
    {
        get { return _cASHDEPOSIT3; }
        set { _cASHDEPOSIT3 = value; }
    }

    private int _cASHDEPOSIT4;
    public int CASHDEPOSIT4
    {
        get { return _cASHDEPOSIT4; }
        set { _cASHDEPOSIT4 = value; }
    }

    private int _cASHDEPOSIT5;
    public int CASHDEPOSIT5
    {
        get { return _cASHDEPOSIT5; }
        set { _cASHDEPOSIT5 = value; }
    }

    private int _cHECKDEPOSIT1;
    public int CHECKDEPOSIT1
    {
        get { return _cHECKDEPOSIT1; }
        set { _cHECKDEPOSIT1 = value; }
    }

    private int _cHECKDEPOSIT2;
    public int CHECKDEPOSIT2
    {
        get { return _cHECKDEPOSIT2; }
        set { _cHECKDEPOSIT2 = value; }
    }

    private int _cHECKDEPOSIT3;
    public int CHECKDEPOSIT3
    {
        get { return _cHECKDEPOSIT3; }
        set { _cHECKDEPOSIT3 = value; }
    }

    private int _cHECKDEPOSIT4;
    public int CHECKDEPOSIT4
    {
        get { return _cHECKDEPOSIT4; }
        set { _cHECKDEPOSIT4 = value; }
    }

    private int _cHECKDEPOSIT5;
    public int CHECKDEPOSIT5
    {
        get { return _cHECKDEPOSIT5; }
        set { _cHECKDEPOSIT5 = value; }
    }

    private int _cHECKDEPOSIT6;
    public int CHECKDEPOSIT6
    {
        get { return _cHECKDEPOSIT6; }
        set { _cHECKDEPOSIT6 = value; }
    }

    private int _cHECKDEPOSIT7;
    public int CHECKDEPOSIT7
    {
        get { return _cHECKDEPOSIT7; }
        set { _cHECKDEPOSIT7 = value; }
    }

    private int _cHECKDEPOSIT8;
    public int CHECKDEPOSIT8
    {
        get { return _cHECKDEPOSIT8; }
        set { _cHECKDEPOSIT8 = value; }
    }

    private int _cHECKDEPOSIT9;
    public int CHECKDEPOSIT9
    {
        get { return _cHECKDEPOSIT9; }
        set { _cHECKDEPOSIT9 = value; }
    }

    private int _cHECKDEPOSIT10;
    public int CHECKDEPOSIT10
    {
        get { return _cHECKDEPOSIT10; }
        set { _cHECKDEPOSIT10 = value; }
    }

    private int _cHECKDEPOSIT11;
    public int CHECKDEPOSIT11
    {
        get { return _cHECKDEPOSIT11; }
        set { _cHECKDEPOSIT11 = value; }
    }

    private int _cHECKDEPOSIT12;
    public int CHECKDEPOSIT12
    {
        get { return _cHECKDEPOSIT12; }
        set { _cHECKDEPOSIT12 = value; }
    }

    private int _cASHTRANSFER1;
    public int CASHTRANSFER1
    {
        get { return _cASHTRANSFER1; }
        set { _cASHTRANSFER1 = value; }
    }

    private string _cASHTRANSFER1REMARKS;
    public string CASHTRANSFER1REMARKS
    {
        get { return _cASHTRANSFER1REMARKS; }
        set { _cASHTRANSFER1REMARKS = value; }
    }

    private int _cASHTRANSFER2;
    public int CASHTRANSFER2
    {
        get { return _cASHTRANSFER2; }
        set { _cASHTRANSFER2 = value; }
    }

    private string _cASHTRANSFER2REMARKS;
    public string CASHTRANSFER2REMARKS
    {
        get { return _cASHTRANSFER2REMARKS; }
        set { _cASHTRANSFER2REMARKS = value; }
    }

    private int _cASHTRANSFER3;
    public int CASHTRANSFER3
    {
        get { return _cASHTRANSFER3; }
        set { _cASHTRANSFER3 = value; }
    }

    private string _cASHTRANSFER3REMARKS;
    public string CASHTRANSFER3REMARKS
    {
        get { return _cASHTRANSFER3REMARKS; }
        set { _cASHTRANSFER3REMARKS = value; }
    }

    private int _cASHTRANSFER4;
    public int CASHTRANSFER4
    {
        get { return _cASHTRANSFER4; }
        set { _cASHTRANSFER4 = value; }
    }

    private string _cASHTRANSFER4REMARKS;
    public string CASHTRANSFER4REMARKS
    {
        get { return _cASHTRANSFER4REMARKS; }
        set { _cASHTRANSFER4REMARKS = value; }
    }

    private int _cASHTRANSFER5;
    public int CASHTRANSFER5
    {
        get { return _cASHTRANSFER5; }
        set { _cASHTRANSFER5 = value; }
    }

    private string _cASHTRANSFER5REMARKS;
    public string CASHTRANSFER5REMARKS
    {
        get { return _cASHTRANSFER5REMARKS; }
        set { _cASHTRANSFER5REMARKS = value; }
    }

    private int _cASHTRANSFER6;
    public int CASHTRANSFER6
    {
        get { return _cASHTRANSFER6; }
        set { _cASHTRANSFER6 = value; }
    }

    private string _cASHTRANSFER6REMARKS;
    public string CASHTRANSFER6REMARKS
    {
        get { return _cASHTRANSFER6REMARKS; }
        set { _cASHTRANSFER6REMARKS = value; }
    }

    private int _cASHTRANSFER7;
    public int CASHTRANSFER7
    {
        get { return _cASHTRANSFER7; }
        set { _cASHTRANSFER7 = value; }
    }

    private string _cASHTRANSFER7REMARKS;
    public string CASHTRANSFER7REMARKS
    {
        get { return _cASHTRANSFER7REMARKS; }
        set { _cASHTRANSFER7REMARKS = value; }
    }

    private int _cASHTRANSFER8;
    public int CASHTRANSFER8
    {
        get { return _cASHTRANSFER8; }
        set { _cASHTRANSFER8 = value; }
    }

    private string _cASHTRANSFER8REMARKS;
    public string CASHTRANSFER8REMARKS
    {
        get { return _cASHTRANSFER8REMARKS; }
        set { _cASHTRANSFER8REMARKS = value; }
    }

    private int _fEDILITYDEPOSIT;
    public int FEDILITYDEPOSIT
    {
        get { return _fEDILITYDEPOSIT; }
        set { _fEDILITYDEPOSIT = value; }
    }

    private int _cHECKFREEPAYDEPOSIT;
    public int CHECKFREEPAYDEPOSIT
    {
        get { return _cHECKFREEPAYDEPOSIT; }
        set { _cHECKFREEPAYDEPOSIT = value; }
    }

    private int _cONVPAYDEPOSIT;
    public int CONVPAYDEPOSIT
    {
        get { return _cONVPAYDEPOSIT; }
        set { _cONVPAYDEPOSIT = value; }
    }

    private int _wUPAYOUT;
    public int WUPAYOUT
    {
        get { return _wUPAYOUT; }
        set { _wUPAYOUT = value; }
    }

    private int _cREDITCARD;
    public int CREDITCARD
    {
        get { return _cREDITCARD; }
        set { _cREDITCARD = value; }
    }

    private int _eXPENSES;
    public int EXPENSES
    {
        get { return _eXPENSES; }
        set { _eXPENSES = value; }
    }

    private int _tOTALCASHOUT;
    public int TOTALCASHOUT
    {
        get { return _tOTALCASHOUT; }
        set { _tOTALCASHOUT = value; }
    }

    private int _tOTALBALANCE;
    public int TOTALBALANCE
    {
        get { return _tOTALBALANCE; }
        set { _tOTALBALANCE = value; }
    }

    private int _aCTUALBALACE;
    public int ACTUALBALACE
    {
        get { return _aCTUALBALACE; }
        set { _aCTUALBALACE = value; }
    }

    private int _sHORTOVER;
    public int SHORTOVER
    {
        get { return _sHORTOVER; }
        set { _sHORTOVER = value; }
    }
}
