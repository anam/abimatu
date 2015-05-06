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

public class PRODUCTMASTER
{
    public PRODUCTMASTER()
    {
    }

    public PRODUCTMASTER
        (
        int pRODUCTMASTERID, 
        string pROD_NAME, 
        string pROD_DESC, 
        int sUPPLIERID, 
        string pROD_UPCCODE, 
        int pROD_RETAILPRICE, 
        int pROD_STOCKINHAND, 
        int pROD_REORDERLEVEL, 
        DateTime cREATED_ON, 
        string cREATED_BY, 
        DateTime uPDATED_ON, 
        string uPDATED_BY, 
        char iS_TAXABLE, 
        int pROD_COSTPRICE, 
        int dEPT_ID, 
        int aGENTID
        )
    {
        this.PRODUCTMASTERID = pRODUCTMASTERID;
        this.PROD_NAME = pROD_NAME;
        this.PROD_DESC = pROD_DESC;
        this.SUPPLIERID = sUPPLIERID;
        this.PROD_UPCCODE = pROD_UPCCODE;
        this.PROD_RETAILPRICE = pROD_RETAILPRICE;
        this.PROD_STOCKINHAND = pROD_STOCKINHAND;
        this.PROD_REORDERLEVEL = pROD_REORDERLEVEL;
        this.CREATED_ON = cREATED_ON;
        this.CREATED_BY = cREATED_BY;
        this.UPDATED_ON = uPDATED_ON;
        this.UPDATED_BY = uPDATED_BY;
        this.IS_TAXABLE = iS_TAXABLE;
        this.PROD_COSTPRICE = pROD_COSTPRICE;
        this.DEPT_ID = dEPT_ID;
        this.AGENTID = aGENTID;
    }


    private int _pRODUCTMASTERID;
    public int PRODUCTMASTERID
    {
        get { return _pRODUCTMASTERID; }
        set { _pRODUCTMASTERID = value; }
    }

    private string _pROD_NAME;
    public string PROD_NAME
    {
        get { return _pROD_NAME; }
        set { _pROD_NAME = value; }
    }

    private string _pROD_DESC;
    public string PROD_DESC
    {
        get { return _pROD_DESC; }
        set { _pROD_DESC = value; }
    }

    private int _sUPPLIERID;
    public int SUPPLIERID
    {
        get { return _sUPPLIERID; }
        set { _sUPPLIERID = value; }
    }

    private string _pROD_UPCCODE;
    public string PROD_UPCCODE
    {
        get { return _pROD_UPCCODE; }
        set { _pROD_UPCCODE = value; }
    }

    private int _pROD_RETAILPRICE;
    public int PROD_RETAILPRICE
    {
        get { return _pROD_RETAILPRICE; }
        set { _pROD_RETAILPRICE = value; }
    }

    private int _pROD_STOCKINHAND;
    public int PROD_STOCKINHAND
    {
        get { return _pROD_STOCKINHAND; }
        set { _pROD_STOCKINHAND = value; }
    }

    private int _pROD_REORDERLEVEL;
    public int PROD_REORDERLEVEL
    {
        get { return _pROD_REORDERLEVEL; }
        set { _pROD_REORDERLEVEL = value; }
    }

    private DateTime _cREATED_ON;
    public DateTime CREATED_ON
    {
        get { return _cREATED_ON; }
        set { _cREATED_ON = value; }
    }

    private string _cREATED_BY;
    public string CREATED_BY
    {
        get { return _cREATED_BY; }
        set { _cREATED_BY = value; }
    }

    private DateTime _uPDATED_ON;
    public DateTime UPDATED_ON
    {
        get { return _uPDATED_ON; }
        set { _uPDATED_ON = value; }
    }

    private string _uPDATED_BY;
    public string UPDATED_BY
    {
        get { return _uPDATED_BY; }
        set { _uPDATED_BY = value; }
    }

    private char _iS_TAXABLE;
    public char IS_TAXABLE
    {
        get { return _iS_TAXABLE; }
        set { _iS_TAXABLE = value; }
    }

    private int _pROD_COSTPRICE;
    public int PROD_COSTPRICE
    {
        get { return _pROD_COSTPRICE; }
        set { _pROD_COSTPRICE = value; }
    }

    private int _dEPT_ID;
    public int DEPT_ID
    {
        get { return _dEPT_ID; }
        set { _dEPT_ID = value; }
    }

    private int _aGENTID;
    public int AGENTID
    {
        get { return _aGENTID; }
        set { _aGENTID = value; }
    }
}
