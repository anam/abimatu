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

public class SCHEDULE
{
    public SCHEDULE()
    {
    }

    public SCHEDULE
        (
        int sCHEDULEID, 
        int eMP_ID, 
        DateTime sTDT, 
        DateTime eNDDT, 
        string mON, 
        string tUE, 
        string wED, 
        string tHS, 
        string fRI, 
        string sAT, 
        string sUN
        )
    {
        this.SCHEDULEID = sCHEDULEID;
        this.EMP_ID = eMP_ID;
        this.STDT = sTDT;
        this.ENDDT = eNDDT;
        this.MON = mON;
        this.TUE = tUE;
        this.WED = wED;
        this.THS = tHS;
        this.FRI = fRI;
        this.SAT = sAT;
        this.SUN = sUN;
    }


    private int _sCHEDULEID;
    public int SCHEDULEID
    {
        get { return _sCHEDULEID; }
        set { _sCHEDULEID = value; }
    }

    private int _eMP_ID;
    public int EMP_ID
    {
        get { return _eMP_ID; }
        set { _eMP_ID = value; }
    }

    private DateTime _sTDT;
    public DateTime STDT
    {
        get { return _sTDT; }
        set { _sTDT = value; }
    }

    private DateTime _eNDDT;
    public DateTime ENDDT
    {
        get { return _eNDDT; }
        set { _eNDDT = value; }
    }

    private string _mON;
    public string MON
    {
        get { return _mON; }
        set { _mON = value; }
    }

    private string _tUE;
    public string TUE
    {
        get { return _tUE; }
        set { _tUE = value; }
    }

    private string _wED;
    public string WED
    {
        get { return _wED; }
        set { _wED = value; }
    }

    private string _tHS;
    public string THS
    {
        get { return _tHS; }
        set { _tHS = value; }
    }

    private string _fRI;
    public string FRI
    {
        get { return _fRI; }
        set { _fRI = value; }
    }

    private string _sAT;
    public string SAT
    {
        get { return _sAT; }
        set { _sAT = value; }
    }

    private string _sUN;
    public string SUN
    {
        get { return _sUN; }
        set { _sUN = value; }
    }
}
