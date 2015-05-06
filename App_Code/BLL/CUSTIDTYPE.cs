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

public class CUSTIDTYPE
{
    public CUSTIDTYPE()
    {
    }

    public CUSTIDTYPE
        (
        int cUSTIDTYPEID, 
        string cUSTIDTYPEName
        )
    {
        this.CUSTIDTYPEID = cUSTIDTYPEID;
        this.CUSTIDTYPEName = cUSTIDTYPEName;
    }


    private int _cUSTIDTYPEID;
    public int CUSTIDTYPEID
    {
        get { return _cUSTIDTYPEID; }
        set { _cUSTIDTYPEID = value; }
    }

    private string _cUSTIDTYPEName;
    public string CUSTIDTYPEName
    {
        get { return _cUSTIDTYPEName; }
        set { _cUSTIDTYPEName = value; }
    }
}
