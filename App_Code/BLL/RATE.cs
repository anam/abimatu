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

public class RATE
{
    public RATE()
    {
    }

    public RATE
        (
        int rATEID, 
        int mINAMT, 
        int mAXAMT, 
        int rATEVALUE, 
        int pOINTS, 
        int pOINTSVALUE
        )
    {
        this.RATEID = rATEID;
        this.MINAMT = mINAMT;
        this.MAXAMT = mAXAMT;
        this.RATEVALUE = rATEVALUE;
        this.POINTS = pOINTS;
        this.POINTSVALUE = pOINTSVALUE;
    }


    private int _rATEID;
    public int RATEID
    {
        get { return _rATEID; }
        set { _rATEID = value; }
    }

    private int _mINAMT;
    public int MINAMT
    {
        get { return _mINAMT; }
        set { _mINAMT = value; }
    }

    private int _mAXAMT;
    public int MAXAMT
    {
        get { return _mAXAMT; }
        set { _mAXAMT = value; }
    }

    private int _rATEVALUE;
    public int RATEVALUE
    {
        get { return _rATEVALUE; }
        set { _rATEVALUE = value; }
    }

    private int _pOINTS;
    public int POINTS
    {
        get { return _pOINTS; }
        set { _pOINTS = value; }
    }

    private int _pOINTSVALUE;
    public int POINTSVALUE
    {
        get { return _pOINTSVALUE; }
        set { _pOINTSVALUE = value; }
    }
}
