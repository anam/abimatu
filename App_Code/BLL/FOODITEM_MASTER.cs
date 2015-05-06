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

public class FOODITEM_MASTER
{
    public FOODITEM_MASTER()
    {
    }

    public FOODITEM_MASTER
        (
        int fOODITEM_MASTERID, 
        string iTEMCODE, 
        string iTEMNAME, 
        decimal rATE, 
        int aGENTID, 
        int sEQ
        )
    {
        this.FOODITEM_MASTERID = fOODITEM_MASTERID;
        this.ITEMCODE = iTEMCODE;
        this.ITEMNAME = iTEMNAME;
        this.RATE = rATE;
        this.AGENTID = aGENTID;
        this.SEQ = sEQ;
    }


    private int _fOODITEM_MASTERID;
    public int FOODITEM_MASTERID
    {
        get { return _fOODITEM_MASTERID; }
        set { _fOODITEM_MASTERID = value; }
    }

    private string _iTEMCODE;
    public string ITEMCODE
    {
        get { return _iTEMCODE; }
        set { _iTEMCODE = value; }
    }

    private string _iTEMNAME;
    public string ITEMNAME
    {
        get { return _iTEMNAME; }
        set { _iTEMNAME = value; }
    }

    private decimal _rATE;
    public decimal RATE
    {
        get { return _rATE; }
        set { _rATE = value; }
    }

    private int _aGENTID;
    public int AGENTID
    {
        get { return _aGENTID; }
        set { _aGENTID = value; }
    }

    private int _sEQ;
    public int SEQ
    {
        get { return _sEQ; }
        set { _sEQ = value; }
    }
}
