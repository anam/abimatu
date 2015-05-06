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

public class STORETRANS
{
    public STORETRANS()
    {
    }

    public STORETRANS
        (
        int sTORETRANSID, 
        DateTime dT, 
        int eMP_ID, 
        int sHIFT_ID, 
        int sTATION_ID, 
        int cURRREG, 
        int rEGOPEN, 
        int rEGCLOSE, 
        char rEGOPENSTATUS, 
        char rEGCLOSESTATUS, 
        DateTime cLOSEDT, 
        string tOTTIME, 
        int tOTSECONDS, 
        int dIFF
        )
    {
        this.STORETRANSID = sTORETRANSID;
        this.DT = dT;
        this.EMP_ID = eMP_ID;
        this.SHIFT_ID = sHIFT_ID;
        this.STATION_ID = sTATION_ID;
        this.CURRREG = cURRREG;
        this.REGOPEN = rEGOPEN;
        this.REGCLOSE = rEGCLOSE;
        this.REGOPENSTATUS = rEGOPENSTATUS;
        this.REGCLOSESTATUS = rEGCLOSESTATUS;
        this.CLOSEDT = cLOSEDT;
        this.TOTTIME = tOTTIME;
        this.TOTSECONDS = tOTSECONDS;
        this.DIFF = dIFF;
    }


    private int _sTORETRANSID;
    public int STORETRANSID
    {
        get { return _sTORETRANSID; }
        set { _sTORETRANSID = value; }
    }

    private DateTime _dT;
    public DateTime DT
    {
        get { return _dT; }
        set { _dT = value; }
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

    private int _sTATION_ID;
    public int STATION_ID
    {
        get { return _sTATION_ID; }
        set { _sTATION_ID = value; }
    }

    private int _cURRREG;
    public int CURRREG
    {
        get { return _cURRREG; }
        set { _cURRREG = value; }
    }

    private int _rEGOPEN;
    public int REGOPEN
    {
        get { return _rEGOPEN; }
        set { _rEGOPEN = value; }
    }

    private int _rEGCLOSE;
    public int REGCLOSE
    {
        get { return _rEGCLOSE; }
        set { _rEGCLOSE = value; }
    }

    private char _rEGOPENSTATUS;
    public char REGOPENSTATUS
    {
        get { return _rEGOPENSTATUS; }
        set { _rEGOPENSTATUS = value; }
    }

    private char _rEGCLOSESTATUS;
    public char REGCLOSESTATUS
    {
        get { return _rEGCLOSESTATUS; }
        set { _rEGCLOSESTATUS = value; }
    }

    private DateTime _cLOSEDT;
    public DateTime CLOSEDT
    {
        get { return _cLOSEDT; }
        set { _cLOSEDT = value; }
    }

    private string _tOTTIME;
    public string TOTTIME
    {
        get { return _tOTTIME; }
        set { _tOTTIME = value; }
    }

    private int _tOTSECONDS;
    public int TOTSECONDS
    {
        get { return _tOTSECONDS; }
        set { _tOTSECONDS = value; }
    }

    private int _dIFF;
    public int DIFF
    {
        get { return _dIFF; }
        set { _dIFF = value; }
    }
}
