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

public class SPR_COMMISSION
{
    public SPR_COMMISSION()
    {
    }

    public SPR_COMMISSION
        (
        int sPR_COMMISSIONID, 
        string sTYPE, 
        string sPLAN, 
        string sASL, 
        int sYEAR, 
        int bASECOMM, 
        int aSLCOMM, 
        int tYPECOMM, 
        int yEARCOMM
        )
    {
        this.SPR_COMMISSIONID = sPR_COMMISSIONID;
        this.STYPE = sTYPE;
        this.SPLAN = sPLAN;
        this.SASL = sASL;
        this.SYEAR = sYEAR;
        this.BASECOMM = bASECOMM;
        this.ASLCOMM = aSLCOMM;
        this.TYPECOMM = tYPECOMM;
        this.YEARCOMM = yEARCOMM;
    }


    private int _sPR_COMMISSIONID;
    public int SPR_COMMISSIONID
    {
        get { return _sPR_COMMISSIONID; }
        set { _sPR_COMMISSIONID = value; }
    }

    private string _sTYPE;
    public string STYPE
    {
        get { return _sTYPE; }
        set { _sTYPE = value; }
    }

    private string _sPLAN;
    public string SPLAN
    {
        get { return _sPLAN; }
        set { _sPLAN = value; }
    }

    private string _sASL;
    public string SASL
    {
        get { return _sASL; }
        set { _sASL = value; }
    }

    private int _sYEAR;
    public int SYEAR
    {
        get { return _sYEAR; }
        set { _sYEAR = value; }
    }

    private int _bASECOMM;
    public int BASECOMM
    {
        get { return _bASECOMM; }
        set { _bASECOMM = value; }
    }

    private int _aSLCOMM;
    public int ASLCOMM
    {
        get { return _aSLCOMM; }
        set { _aSLCOMM = value; }
    }

    private int _tYPECOMM;
    public int TYPECOMM
    {
        get { return _tYPECOMM; }
        set { _tYPECOMM = value; }
    }

    private int _yEARCOMM;
    public int YEARCOMM
    {
        get { return _yEARCOMM; }
        set { _yEARCOMM = value; }
    }
}
