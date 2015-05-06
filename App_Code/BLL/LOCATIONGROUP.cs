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

public class LOCATIONGROUP
{
    public LOCATIONGROUP()
    {
    }

    public LOCATIONGROUP
        (
        int lOCATIONGROUPID, 
        DateTime aDDEDDATE, 
        string gROUPNAME
        )
    {
        this.LOCATIONGROUPID = lOCATIONGROUPID;
        this.ADDEDDATE = aDDEDDATE;
        this.GROUPNAME = gROUPNAME;
    }


    private int _lOCATIONGROUPID;
    public int LOCATIONGROUPID
    {
        get { return _lOCATIONGROUPID; }
        set { _lOCATIONGROUPID = value; }
    }

    private DateTime _aDDEDDATE;
    public DateTime ADDEDDATE
    {
        get { return _aDDEDDATE; }
        set { _aDDEDDATE = value; }
    }

    private string _gROUPNAME;
    public string GROUPNAME
    {
        get { return _gROUPNAME; }
        set { _gROUPNAME = value; }
    }
}
