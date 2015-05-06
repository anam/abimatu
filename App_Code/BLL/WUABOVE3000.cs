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

public class WUABOVE3000
{
    public WUABOVE3000()
    {
    }

    public WUABOVE3000
        (
        int wUABOVE3000ID, 
        DateTime dT, 
        string cUST_ID, 
        string sENDERNAME, 
        string sENDERADDRESS, 
        string sENDERCITY, 
        char sENDERSTATE, 
        string sENDERZIP, 
        int aMOUNT, 
        string mTCN, 
        int eMP_ID, 
        int sTATION_ID, 
        int sHIFT_ID
        )
    {
        this.WUABOVE3000ID = wUABOVE3000ID;
        this.DT = dT;
        this.CUST_ID = cUST_ID;
        this.SENDERNAME = sENDERNAME;
        this.SENDERADDRESS = sENDERADDRESS;
        this.SENDERCITY = sENDERCITY;
        this.SENDERSTATE = sENDERSTATE;
        this.SENDERZIP = sENDERZIP;
        this.AMOUNT = aMOUNT;
        this.MTCN = mTCN;
        this.EMP_ID = eMP_ID;
        this.STATION_ID = sTATION_ID;
        this.SHIFT_ID = sHIFT_ID;
    }


    private int _wUABOVE3000ID;
    public int WUABOVE3000ID
    {
        get { return _wUABOVE3000ID; }
        set { _wUABOVE3000ID = value; }
    }

    private DateTime _dT;
    public DateTime DT
    {
        get { return _dT; }
        set { _dT = value; }
    }

    private string _cUST_ID;
    public string CUST_ID
    {
        get { return _cUST_ID; }
        set { _cUST_ID = value; }
    }

    private string _sENDERNAME;
    public string SENDERNAME
    {
        get { return _sENDERNAME; }
        set { _sENDERNAME = value; }
    }

    private string _sENDERADDRESS;
    public string SENDERADDRESS
    {
        get { return _sENDERADDRESS; }
        set { _sENDERADDRESS = value; }
    }

    private string _sENDERCITY;
    public string SENDERCITY
    {
        get { return _sENDERCITY; }
        set { _sENDERCITY = value; }
    }

    private char _sENDERSTATE;
    public char SENDERSTATE
    {
        get { return _sENDERSTATE; }
        set { _sENDERSTATE = value; }
    }

    private string _sENDERZIP;
    public string SENDERZIP
    {
        get { return _sENDERZIP; }
        set { _sENDERZIP = value; }
    }

    private int _aMOUNT;
    public int AMOUNT
    {
        get { return _aMOUNT; }
        set { _aMOUNT = value; }
    }

    private string _mTCN;
    public string MTCN
    {
        get { return _mTCN; }
        set { _mTCN = value; }
    }

    private int _eMP_ID;
    public int EMP_ID
    {
        get { return _eMP_ID; }
        set { _eMP_ID = value; }
    }

    private int _sTATION_ID;
    public int STATION_ID
    {
        get { return _sTATION_ID; }
        set { _sTATION_ID = value; }
    }

    private int _sHIFT_ID;
    public int SHIFT_ID
    {
        get { return _sHIFT_ID; }
        set { _sHIFT_ID = value; }
    }
}
