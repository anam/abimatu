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

public class VAULTTRANS
{
    public VAULTTRANS()
    {
    }

    public VAULTTRANS
        (
        int vAULTTRANSID, 
        DateTime dT, 
        int sTATIONID, 
        int aMOUNT
        )
    {
        this.VAULTTRANSID = vAULTTRANSID;
        this.DT = dT;
        this.STATIONID = sTATIONID;
        this.AMOUNT = aMOUNT;
    }


    private int _vAULTTRANSID;
    public int VAULTTRANSID
    {
        get { return _vAULTTRANSID; }
        set { _vAULTTRANSID = value; }
    }

    private DateTime _dT;
    public DateTime DT
    {
        get { return _dT; }
        set { _dT = value; }
    }

    private int _sTATIONID;
    public int STATIONID
    {
        get { return _sTATIONID; }
        set { _sTATIONID = value; }
    }

    private int _aMOUNT;
    public int AMOUNT
    {
        get { return _aMOUNT; }
        set { _aMOUNT = value; }
    }
}
