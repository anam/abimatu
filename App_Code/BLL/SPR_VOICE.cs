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

public class SPR_VOICE
{
    public SPR_VOICE()
    {
    }

    public SPR_VOICE
        (
        int sPR_VOICEID, 
        string sTYPE, 
        string mRC, 
        int vCOMM
        )
    {
        this.SPR_VOICEID = sPR_VOICEID;
        this.STYPE = sTYPE;
        this.MRC = mRC;
        this.VCOMM = vCOMM;
    }


    private int _sPR_VOICEID;
    public int SPR_VOICEID
    {
        get { return _sPR_VOICEID; }
        set { _sPR_VOICEID = value; }
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

    private int _vCOMM;
    public int VCOMM
    {
        get { return _vCOMM; }
        set { _vCOMM = value; }
    }
}
