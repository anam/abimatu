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

public class EMPLOYEE
{
    public EMPLOYEE()
    {
    }

    public EMPLOYEE
        (
        int eMPLOYEEID, 
        string eMPNAME, 
        string eMPADDRESS1, 
        string eMPADDRESS2, 
        string eMPCITY, 
        string eMPSTATE, 
        string eMPZIP, 
        string eMPHPHONE, 
        string eMPCPHONE, 
        string eMPSTORE, 
        string eMPPASSWORD, 
        string iSACTIVE, 
        string iSMANAGER, 
        string iSCOMPLIANCEOFFICER, 
        int cREATEDBY, 
        DateTime cREATEDON, 
        int uPDATEDBY, 
        DateTime uPDATEDON
        )
    {
        this.EMPLOYEEID = eMPLOYEEID;
        this.EMPNAME = eMPNAME;
        this.EMPADDRESS1 = eMPADDRESS1;
        this.EMPADDRESS2 = eMPADDRESS2;
        this.EMPCITY = eMPCITY;
        this.EMPSTATE = eMPSTATE;
        this.EMPZIP = eMPZIP;
        this.EMPHPHONE = eMPHPHONE;
        this.EMPCPHONE = eMPCPHONE;
        this.EMPSTORE = eMPSTORE;
        this.EMPPASSWORD = eMPPASSWORD;
        this.ISACTIVE = iSACTIVE;
        this.ISMANAGER = iSMANAGER;
        this.ISCOMPLIANCEOFFICER = iSCOMPLIANCEOFFICER;
        this.CREATEDBY = cREATEDBY;
        this.CREATEDON = cREATEDON;
        this.UPDATEDBY = uPDATEDBY;
        this.UPDATEDON = uPDATEDON;
    }


    private int _eMPLOYEEID;
    public int EMPLOYEEID
    {
        get { return _eMPLOYEEID; }
        set { _eMPLOYEEID = value; }
    }

    private string _eMPNAME;
    public string EMPNAME
    {
        get { return _eMPNAME; }
        set { _eMPNAME = value; }
    }

    private string _eMPADDRESS1;
    public string EMPADDRESS1
    {
        get { return _eMPADDRESS1; }
        set { _eMPADDRESS1 = value; }
    }

    private string _eMPADDRESS2;
    public string EMPADDRESS2
    {
        get { return _eMPADDRESS2; }
        set { _eMPADDRESS2 = value; }
    }

    private string _eMPCITY;
    public string EMPCITY
    {
        get { return _eMPCITY; }
        set { _eMPCITY = value; }
    }

    private string _eMPSTATE;
    public string EMPSTATE
    {
        get { return _eMPSTATE; }
        set { _eMPSTATE = value; }
    }

    private string _eMPZIP;
    public string EMPZIP
    {
        get { return _eMPZIP; }
        set { _eMPZIP = value; }
    }

    private string _eMPHPHONE;
    public string EMPHPHONE
    {
        get { return _eMPHPHONE; }
        set { _eMPHPHONE = value; }
    }

    private string _eMPCPHONE;
    public string EMPCPHONE
    {
        get { return _eMPCPHONE; }
        set { _eMPCPHONE = value; }
    }

    private string _eMPSTORE;
    public string EMPSTORE
    {
        get { return _eMPSTORE; }
        set { _eMPSTORE = value; }
    }

    private string _eMPPASSWORD;
    public string EMPPASSWORD
    {
        get { return _eMPPASSWORD; }
        set { _eMPPASSWORD = value; }
    }

    private string _iSACTIVE;
    public string ISACTIVE
    {
        get { return _iSACTIVE; }
        set { _iSACTIVE = value; }
    }

    private string _iSMANAGER;
    public string ISMANAGER
    {
        get { return _iSMANAGER; }
        set { _iSMANAGER = value; }
    }

    private string _iSCOMPLIANCEOFFICER;
    public string ISCOMPLIANCEOFFICER
    {
        get { return _iSCOMPLIANCEOFFICER; }
        set { _iSCOMPLIANCEOFFICER = value; }
    }

    private int _cREATEDBY;
    public int CREATEDBY
    {
        get { return _cREATEDBY; }
        set { _cREATEDBY = value; }
    }

    private DateTime _cREATEDON;
    public DateTime CREATEDON
    {
        get { return _cREATEDON; }
        set { _cREATEDON = value; }
    }

    private int _uPDATEDBY;
    public int UPDATEDBY
    {
        get { return _uPDATEDBY; }
        set { _uPDATEDBY = value; }
    }

    private DateTime _uPDATEDON;
    public DateTime UPDATEDON
    {
        get { return _uPDATEDON; }
        set { _uPDATEDON = value; }
    }
}
