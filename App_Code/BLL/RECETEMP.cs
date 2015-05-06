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

public class RECETEMP
{
    public RECETEMP()
    {
    }

    public RECETEMP
        (
        int rECETEMPID, 
        int rECEID
        )
    {
        this.RECETEMPID = rECETEMPID;
        this.RECEID = rECEID;
    }


    private int _rECETEMPID;
    public int RECETEMPID
    {
        get { return _rECETEMPID; }
        set { _rECETEMPID = value; }
    }

    private int _rECEID;
    public int RECEID
    {
        get { return _rECEID; }
        set { _rECEID = value; }
    }
}
