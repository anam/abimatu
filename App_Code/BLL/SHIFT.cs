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

public class SHIFT
{
    public SHIFT()
    {
    }

    public SHIFT
        (
        int sHIFTID, 
        string sHIFTNAME, 
        DateTime sHIFTSTART, 
        DateTime sHIFTEND, 
        DateTime cREATEDON, 
        string cREATEDBY, 
        DateTime uPDATEDON, 
        string uPDATEDBY, 
        string sHIFTTIME
        )
    {
        this.SHIFTID = sHIFTID;
        this.SHIFTNAME = sHIFTNAME;
        this.SHIFTSTART = sHIFTSTART;
        this.SHIFTEND = sHIFTEND;
        this.CREATEDON = cREATEDON;
        this.CREATEDBY = cREATEDBY;
        this.UPDATEDON = uPDATEDON;
        this.UPDATEDBY = uPDATEDBY;
        this.SHIFTTIME = sHIFTTIME;
    }


    private int _sHIFTID;
    public int SHIFTID
    {
        get { return _sHIFTID; }
        set { _sHIFTID = value; }
    }

    private string _sHIFTNAME;
    public string SHIFTNAME
    {
        get { return _sHIFTNAME; }
        set { _sHIFTNAME = value; }
    }

    private DateTime _sHIFTSTART;
    public DateTime SHIFTSTART
    {
        get { return _sHIFTSTART; }
        set { _sHIFTSTART = value; }
    }

    private DateTime _sHIFTEND;
    public DateTime SHIFTEND
    {
        get { return _sHIFTEND; }
        set { _sHIFTEND = value; }
    }

    private DateTime _cREATEDON;
    public DateTime CREATEDON
    {
        get { return _cREATEDON; }
        set { _cREATEDON = value; }
    }

    private string _cREATEDBY;
    public string CREATEDBY
    {
        get { return _cREATEDBY; }
        set { _cREATEDBY = value; }
    }

    private DateTime _uPDATEDON;
    public DateTime UPDATEDON
    {
        get { return _uPDATEDON; }
        set { _uPDATEDON = value; }
    }

    private string _uPDATEDBY;
    public string UPDATEDBY
    {
        get { return _uPDATEDBY; }
        set { _uPDATEDBY = value; }
    }

    private string _sHIFTTIME;
    public string SHIFTTIME
    {
        get { return _sHIFTTIME; }
        set { _sHIFTTIME = value; }
    }
}
