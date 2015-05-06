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

public class STATION
{
    public STATION()
    {
    }

    public STATION
        (
        int sTATIONID, 
        string sTATIONNAME, 
        string sTATIONLOCATION
        )
    {
        this.STATIONID = sTATIONID;
        this.STATIONNAME = sTATIONNAME;
        this.STATIONLOCATION = sTATIONLOCATION;
    }


    private int _sTATIONID;
    public int STATIONID
    {
        get { return _sTATIONID; }
        set { _sTATIONID = value; }
    }

    private string _sTATIONNAME;
    public string STATIONNAME
    {
        get { return _sTATIONNAME; }
        set { _sTATIONNAME = value; }
    }

    private string _sTATIONLOCATION;
    public string STATIONLOCATION
    {
        get { return _sTATIONLOCATION; }
        set { _sTATIONLOCATION = value; }
    }
}
