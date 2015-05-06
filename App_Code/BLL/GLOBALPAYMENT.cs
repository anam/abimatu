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

public class GLOBALPAYMENT
{
    public GLOBALPAYMENT()
    {
    }

    public GLOBALPAYMENT
        (
        int gLOBALPAYMENTID, 
        string iD, 
        string uTILITYNAME, 
        int uTILITYFEES, 
        int sTORECOMM, 
        int gLOBALCOMM, 
        int aCCOUNTLENGTH, 
        int aCCOUNTSTART, 
        int sCALELINEFROMBOTTON, 
        int sCALELINEWIDTH
        )
    {
        this.GLOBALPAYMENTID = gLOBALPAYMENTID;
        this.ID = iD;
        this.UTILITYNAME = uTILITYNAME;
        this.UTILITYFEES = uTILITYFEES;
        this.STORECOMM = sTORECOMM;
        this.GLOBALCOMM = gLOBALCOMM;
        this.ACCOUNTLENGTH = aCCOUNTLENGTH;
        this.ACCOUNTSTART = aCCOUNTSTART;
        this.SCALELINEFROMBOTTON = sCALELINEFROMBOTTON;
        this.SCALELINEWIDTH = sCALELINEWIDTH;
    }


    private int _gLOBALPAYMENTID;
    public int GLOBALPAYMENTID
    {
        get { return _gLOBALPAYMENTID; }
        set { _gLOBALPAYMENTID = value; }
    }

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _uTILITYNAME;
    public string UTILITYNAME
    {
        get { return _uTILITYNAME; }
        set { _uTILITYNAME = value; }
    }

    private int _uTILITYFEES;
    public int UTILITYFEES
    {
        get { return _uTILITYFEES; }
        set { _uTILITYFEES = value; }
    }

    private int _sTORECOMM;
    public int STORECOMM
    {
        get { return _sTORECOMM; }
        set { _sTORECOMM = value; }
    }

    private int _gLOBALCOMM;
    public int GLOBALCOMM
    {
        get { return _gLOBALCOMM; }
        set { _gLOBALCOMM = value; }
    }

    private int _aCCOUNTLENGTH;
    public int ACCOUNTLENGTH
    {
        get { return _aCCOUNTLENGTH; }
        set { _aCCOUNTLENGTH = value; }
    }

    private int _aCCOUNTSTART;
    public int ACCOUNTSTART
    {
        get { return _aCCOUNTSTART; }
        set { _aCCOUNTSTART = value; }
    }

    private int _sCALELINEFROMBOTTON;
    public int SCALELINEFROMBOTTON
    {
        get { return _sCALELINEFROMBOTTON; }
        set { _sCALELINEFROMBOTTON = value; }
    }

    private int _sCALELINEWIDTH;
    public int SCALELINEWIDTH
    {
        get { return _sCALELINEWIDTH; }
        set { _sCALELINEWIDTH = value; }
    }
}
