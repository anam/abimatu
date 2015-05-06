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

public class STATIONTRANS
{
    public STATIONTRANS()
    {
    }

    public STATIONTRANS
        (
        int sTATIONTRANSID, 
        DateTime dT, 
        string sTATIONFROM, 
        string sTATIONTO, 
        int aMOUNT, 
        char iSACCEPTED, 
        int eMP_ID, 
        int sHIFT_ID, 
        int tRANSFER_EMP_ID
        )
    {
        this.STATIONTRANSID = sTATIONTRANSID;
        this.DT = dT;
        this.STATIONFROM = sTATIONFROM;
        this.STATIONTO = sTATIONTO;
        this.AMOUNT = aMOUNT;
        this.ISACCEPTED = iSACCEPTED;
        this.EMP_ID = eMP_ID;
        this.SHIFT_ID = sHIFT_ID;
        this.TRANSFER_EMP_ID = tRANSFER_EMP_ID;
    }


    private int _sTATIONTRANSID;
    public int STATIONTRANSID
    {
        get { return _sTATIONTRANSID; }
        set { _sTATIONTRANSID = value; }
    }

    private DateTime _dT;
    public DateTime DT
    {
        get { return _dT; }
        set { _dT = value; }
    }

    private string _sTATIONFROM;
    public string STATIONFROM
    {
        get { return _sTATIONFROM; }
        set { _sTATIONFROM = value; }
    }

    private string _sTATIONTO;
    public string STATIONTO
    {
        get { return _sTATIONTO; }
        set { _sTATIONTO = value; }
    }

    private int _aMOUNT;
    public int AMOUNT
    {
        get { return _aMOUNT; }
        set { _aMOUNT = value; }
    }

    private char _iSACCEPTED;
    public char ISACCEPTED
    {
        get { return _iSACCEPTED; }
        set { _iSACCEPTED = value; }
    }

    private int _eMP_ID;
    public int EMP_ID
    {
        get { return _eMP_ID; }
        set { _eMP_ID = value; }
    }

    private int _sHIFT_ID;
    public int SHIFT_ID
    {
        get { return _sHIFT_ID; }
        set { _sHIFT_ID = value; }
    }

    private int _tRANSFER_EMP_ID;
    public int TRANSFER_EMP_ID
    {
        get { return _tRANSFER_EMP_ID; }
        set { _tRANSFER_EMP_ID = value; }
    }
}
