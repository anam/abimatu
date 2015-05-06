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

public class VAULT
{
    public VAULT()
    {
    }

    public VAULT
        (
        int vAULTID, 
        int vAULTAMOUNT
        )
    {
        this.VAULTID = vAULTID;
        this.VAULTAMOUNT = vAULTAMOUNT;
    }


    private int _vAULTID;
    public int VAULTID
    {
        get { return _vAULTID; }
        set { _vAULTID = value; }
    }

    private int _vAULTAMOUNT;
    public int VAULTAMOUNT
    {
        get { return _vAULTAMOUNT; }
        set { _vAULTAMOUNT = value; }
    }
}
