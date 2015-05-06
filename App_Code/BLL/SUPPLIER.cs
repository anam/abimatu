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

public class SUPPLIER
{
    public SUPPLIER()
    {
    }

    public SUPPLIER
        (
        int sUPPLIERID, 
        string sUPPLIERNAME, 
        string sUPPLIERADDRESS1, 
        string sUPPLIERADDRESS2, 
        string sUPPLIERCITY, 
        char sUPPLIERSTATE, 
        string sUPPLIERZIP, 
        string sUPPLIERPHONE, 
        DateTime cREATED_ON, 
        string cREATED_BY, 
        DateTime uPDATED_ON, 
        string uPDATED_BY
        )
    {
        this.SUPPLIERID = sUPPLIERID;
        this.SUPPLIERNAME = sUPPLIERNAME;
        this.SUPPLIERADDRESS1 = sUPPLIERADDRESS1;
        this.SUPPLIERADDRESS2 = sUPPLIERADDRESS2;
        this.SUPPLIERCITY = sUPPLIERCITY;
        this.SUPPLIERSTATE = sUPPLIERSTATE;
        this.SUPPLIERZIP = sUPPLIERZIP;
        this.SUPPLIERPHONE = sUPPLIERPHONE;
        this.CREATED_ON = cREATED_ON;
        this.CREATED_BY = cREATED_BY;
        this.UPDATED_ON = uPDATED_ON;
        this.UPDATED_BY = uPDATED_BY;
    }


    private int _sUPPLIERID;
    public int SUPPLIERID
    {
        get { return _sUPPLIERID; }
        set { _sUPPLIERID = value; }
    }

    private string _sUPPLIERNAME;
    public string SUPPLIERNAME
    {
        get { return _sUPPLIERNAME; }
        set { _sUPPLIERNAME = value; }
    }

    private string _sUPPLIERADDRESS1;
    public string SUPPLIERADDRESS1
    {
        get { return _sUPPLIERADDRESS1; }
        set { _sUPPLIERADDRESS1 = value; }
    }

    private string _sUPPLIERADDRESS2;
    public string SUPPLIERADDRESS2
    {
        get { return _sUPPLIERADDRESS2; }
        set { _sUPPLIERADDRESS2 = value; }
    }

    private string _sUPPLIERCITY;
    public string SUPPLIERCITY
    {
        get { return _sUPPLIERCITY; }
        set { _sUPPLIERCITY = value; }
    }

    private char _sUPPLIERSTATE;
    public char SUPPLIERSTATE
    {
        get { return _sUPPLIERSTATE; }
        set { _sUPPLIERSTATE = value; }
    }

    private string _sUPPLIERZIP;
    public string SUPPLIERZIP
    {
        get { return _sUPPLIERZIP; }
        set { _sUPPLIERZIP = value; }
    }

    private string _sUPPLIERPHONE;
    public string SUPPLIERPHONE
    {
        get { return _sUPPLIERPHONE; }
        set { _sUPPLIERPHONE = value; }
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
}
