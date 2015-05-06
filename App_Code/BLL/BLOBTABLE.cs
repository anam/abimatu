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

public class BLOBTABLE
{
    public BLOBTABLE()
    {
    }

    public BLOBTABLE
        (
        int bLOBTABLEID, 
        string t
        )
    {
        this.BLOBTABLEID = bLOBTABLEID;
        this.T = t;
    }


    private int _bLOBTABLEID;
    public int BLOBTABLEID
    {
        get { return _bLOBTABLEID; }
        set { _bLOBTABLEID = value; }
    }

    private string _t;
    public string T
    {
        get { return _t; }
        set { _t = value; }
    }
}
