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

public class SQLPLUS_PRODUCT_PROFILE
{
    public SQLPLUS_PRODUCT_PROFILE()
    {
    }

    public SQLPLUS_PRODUCT_PROFILE
        (
        int sQLPLUS_PRODUCT_PROFILEID, 
        string pRODUCT, 
        int uSERID, 
        string aTTRIBUTE, 
        string sCOPE, 
        int nUMERIC_VALUE, 
        string cHAR_VALUE, 
        DateTime dATE_VALUE, 
        int lONG_VALUE
        )
    {
        this.SQLPLUS_PRODUCT_PROFILEID = sQLPLUS_PRODUCT_PROFILEID;
        this.PRODUCT = pRODUCT;
        this.USERID = uSERID;
        this.ATTRIBUTE = aTTRIBUTE;
        this.SCOPE = sCOPE;
        this.NUMERIC_VALUE = nUMERIC_VALUE;
        this.CHAR_VALUE = cHAR_VALUE;
        this.DATE_VALUE = dATE_VALUE;
        this.LONG_VALUE = lONG_VALUE;
    }


    private int _sQLPLUS_PRODUCT_PROFILEID;
    public int SQLPLUS_PRODUCT_PROFILEID
    {
        get { return _sQLPLUS_PRODUCT_PROFILEID; }
        set { _sQLPLUS_PRODUCT_PROFILEID = value; }
    }

    private string _pRODUCT;
    public string PRODUCT
    {
        get { return _pRODUCT; }
        set { _pRODUCT = value; }
    }

    private int _uSERID;
    public int USERID
    {
        get { return _uSERID; }
        set { _uSERID = value; }
    }

    private string _aTTRIBUTE;
    public string ATTRIBUTE
    {
        get { return _aTTRIBUTE; }
        set { _aTTRIBUTE = value; }
    }

    private string _sCOPE;
    public string SCOPE
    {
        get { return _sCOPE; }
        set { _sCOPE = value; }
    }

    private int _nUMERIC_VALUE;
    public int NUMERIC_VALUE
    {
        get { return _nUMERIC_VALUE; }
        set { _nUMERIC_VALUE = value; }
    }

    private string _cHAR_VALUE;
    public string CHAR_VALUE
    {
        get { return _cHAR_VALUE; }
        set { _cHAR_VALUE = value; }
    }

    private DateTime _dATE_VALUE;
    public DateTime DATE_VALUE
    {
        get { return _dATE_VALUE; }
        set { _dATE_VALUE = value; }
    }

    private int _lONG_VALUE;
    public int LONG_VALUE
    {
        get { return _lONG_VALUE; }
        set { _lONG_VALUE = value; }
    }
}
