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

public class MOMASTER
{
    public MOMASTER()
    {
    }

    public MOMASTER
        (
        int mOMASTERID, 
        int aGENTID, 
        int sTARTMO, 
        int eNDMO, 
        int cURRMO
        )
    {
        this.MOMASTERID = mOMASTERID;
        this.AGENTID = aGENTID;
        this.STARTMO = sTARTMO;
        this.ENDMO = eNDMO;
        this.CURRMO = cURRMO;
    }


    private int _mOMASTERID;
    public int MOMASTERID
    {
        get { return _mOMASTERID; }
        set { _mOMASTERID = value; }
    }

    private int _aGENTID;
    public int AGENTID
    {
        get { return _aGENTID; }
        set { _aGENTID = value; }
    }

    private int _sTARTMO;
    public int STARTMO
    {
        get { return _sTARTMO; }
        set { _sTARTMO = value; }
    }

    private int _eNDMO;
    public int ENDMO
    {
        get { return _eNDMO; }
        set { _eNDMO = value; }
    }

    private int _cURRMO;
    public int CURRMO
    {
        get { return _cURRMO; }
        set { _cURRMO = value; }
    }
}
