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

public class LOCATIONMAPPING
{
    public LOCATIONMAPPING()
    {
    }

    public LOCATIONMAPPING
        (
        int lOCATIONMAPPINGID, 
        DateTime aDDEDDATE, 
        int lOCATIONID, 
        int lOCATIONGROUPID
        )
    {
        this.LOCATIONMAPPINGID = lOCATIONMAPPINGID;
        this.ADDEDDATE = aDDEDDATE;
        this.LOCATIONID = lOCATIONID;
        this.LOCATIONGROUPID = lOCATIONGROUPID;
    }


    private int _lOCATIONMAPPINGID;
    public int LOCATIONMAPPINGID
    {
        get { return _lOCATIONMAPPINGID; }
        set { _lOCATIONMAPPINGID = value; }
    }

    private DateTime _aDDEDDATE;
    public DateTime ADDEDDATE
    {
        get { return _aDDEDDATE; }
        set { _aDDEDDATE = value; }
    }

    private int _lOCATIONID;
    public int LOCATIONID
    {
        get { return _lOCATIONID; }
        set { _lOCATIONID = value; }
    }

    private int _lOCATIONGROUPID;
    public int LOCATIONGROUPID
    {
        get { return _lOCATIONGROUPID; }
        set { _lOCATIONGROUPID = value; }
    }
}
