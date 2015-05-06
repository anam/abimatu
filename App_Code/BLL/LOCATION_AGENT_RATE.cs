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

public class LOCATION_AGENT_RATE
{
    public LOCATION_AGENT_RATE()
    {
    }

    public LOCATION_AGENT_RATE
        (
        int lOCATION_AGENT_RATEID, 
        int lOCATIONID, 
        int aGENTID, 
        decimal rATE,
        string bRANCH,
        string aGENTNAME
        )
    {
        this.LOCATION_AGENT_RATEID = lOCATION_AGENT_RATEID;
        this.LOCATIONID = lOCATIONID;
        this.AGENTID = aGENTID;
        this.RATE = rATE;
        this.BRANCH = bRANCH;
        this.AGENTNAME = aGENTNAME;
    }


    private int _lOCATION_AGENT_RATEID;
    public int LOCATION_AGENT_RATEID
    {
        get { return _lOCATION_AGENT_RATEID; }
        set { _lOCATION_AGENT_RATEID = value; }
    }

    private string _bRANCH;

    public string BRANCH
    {
        get { return _bRANCH; }
        set { _bRANCH = value; }
    }

    private string _aGENTNAME;

    public string AGENTNAME
    {
        get { return _aGENTNAME; }
        set { _aGENTNAME = value; }
    }

    private int _lOCATIONID;
    public int LOCATIONID
    {
        get { return _lOCATIONID; }
        set { _lOCATIONID = value; }
    }

    private int _aGENTID;
    public int AGENTID
    {
        get { return _aGENTID; }
        set { _aGENTID = value; }
    }

    private decimal _rATE;
    public decimal RATE
    {
        get { return _rATE; }
        set { _rATE = value; }
    }
}
