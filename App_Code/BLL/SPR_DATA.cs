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

public class SPR_DATA
{
    public SPR_DATA()
    {
    }

    public SPR_DATA
        (
        int sPR_DATAID, 
        string sTYPE, 
        string mRC, 
        int dCOMM
        )
    {
        this.SPR_DATAID = sPR_DATAID;
        this.STYPE = sTYPE;
        this.MRC = mRC;
        this.DCOMM = dCOMM;
    }


    private int _sPR_DATAID;
    public int SPR_DATAID
    {
        get { return _sPR_DATAID; }
        set { _sPR_DATAID = value; }
    }

    private string _sTYPE;
    public string STYPE
    {
        get { return _sTYPE; }
        set { _sTYPE = value; }
    }

    private string _mRC;
    public string MRC
    {
        get { return _mRC; }
        set { _mRC = value; }
    }

    private int _dCOMM;
    public int DCOMM
    {
        get { return _dCOMM; }
        set { _dCOMM = value; }
    }
}
