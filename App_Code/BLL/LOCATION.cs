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

public class LOCATION
{
    public LOCATION()
    {
    }

    public LOCATION
        (
        int lOCATIONID, 
        string cOUNTRY, 
        string cITY, 
        string bRANCH, 
        string bRANCH_CODE, 
        int sEQUENCE, 
        int aGENTID, 
        decimal aGENTRATE
        )
    {
        this.LOCATIONID = lOCATIONID;
        this.COUNTRY = cOUNTRY;
        this.CITY = cITY;
        this.BRANCH = bRANCH;
        this.BRANCH_CODE = bRANCH_CODE;
        this.SEQUENCE = sEQUENCE;
        this.AGENTID = aGENTID;
        this.AGENTRATE = aGENTRATE;
    }


    private int _lOCATIONID;
    public int LOCATIONID
    {
        get { return _lOCATIONID; }
        set { _lOCATIONID = value; }
    }

    private string _cOUNTRY;
    public string COUNTRY
    {
        get { return _cOUNTRY; }
        set { _cOUNTRY = value; }
    }

    private string _cITY;
    public string CITY
    {
        get { return _cITY; }
        set { _cITY = value; }
    }

    private string _bRANCH;
    public string BRANCH
    {
        get { return _bRANCH; }
        set { _bRANCH = value; }
    }

    private string _bRANCH_CODE;
    public string BRANCH_CODE
    {
        get { return _bRANCH_CODE; }
        set { _bRANCH_CODE = value; }
    }

    private int _sEQUENCE;
    public int SEQUENCE
    {
        get { return _sEQUENCE; }
        set { _sEQUENCE = value; }
    }

    private int _aGENTID;
    public int AGENTID
    {
        get { return _aGENTID; }
        set { _aGENTID = value; }
    }

    private decimal _aGENTRATE;
    public decimal AGENTRATE
    {
        get { return _aGENTRATE; }
        set { _aGENTRATE = value; }
    }
}
