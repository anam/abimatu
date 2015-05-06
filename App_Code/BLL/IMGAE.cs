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

public class IMGAE
{
    public IMGAE()
    {
    }

    public IMGAE
        (
        int iMGAEID, 
        string iMG
        )
    {
        this.IMGAEID = iMGAEID;
        this.IMG = iMG;
    }


    private int _iMGAEID;
    public int IMGAEID
    {
        get { return _iMGAEID; }
        set { _iMGAEID = value; }
    }

    private string _iMG;
    public string IMG
    {
        get { return _iMG; }
        set { _iMG = value; }
    }
}
