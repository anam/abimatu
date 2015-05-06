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

public class CHECKTYPE
{
    public CHECKTYPE()
    {
    }

    public CHECKTYPE
        (
        int cHECKTYPEID, 
        string cHKTYPE, 
        int cHKRATE, 
        string cHKROUTING, 
        string cHKACCOUNT
        )
    {
        this.CHECKTYPEID = cHECKTYPEID;
        this.CHKTYPE = cHKTYPE;
        this.CHKRATE = cHKRATE;
        this.CHKROUTING = cHKROUTING;
        this.CHKACCOUNT = cHKACCOUNT;
    }


    private int _cHECKTYPEID;
    public int CHECKTYPEID
    {
        get { return _cHECKTYPEID; }
        set { _cHECKTYPEID = value; }
    }

    private string _cHKTYPE;
    public string CHKTYPE
    {
        get { return _cHKTYPE; }
        set { _cHKTYPE = value; }
    }

    private int _cHKRATE;
    public int CHKRATE
    {
        get { return _cHKRATE; }
        set { _cHKRATE = value; }
    }

    private string _cHKROUTING;
    public string CHKROUTING
    {
        get { return _cHKROUTING; }
        set { _cHKROUTING = value; }
    }

    private string _cHKACCOUNT;
    public string CHKACCOUNT
    {
        get { return _cHKACCOUNT; }
        set { _cHKACCOUNT = value; }
    }
}
