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

public class AGENT
{
    public AGENT()
    {
    }

    public AGENT
        (
        int aGENTID, 
        string aGENTNAME, 
        string uSERNAME, 
        string aGENTLOCATION, 
        string aGENTADDRESS, 
        string aGENTCITY, 
        string aGENTSTATE, 
        string aGENTZIP, 
        string aGENTPHONE, 
        string aGENTACC, 
        int cREATEDBY, 
        DateTime cREATEDON, 
        int uPDATEDBY, 
        DateTime uPDATEDON
        )
    {
        this.AGENTID = aGENTID;
        this.AGENTNAME = aGENTNAME;
        this.USERNAME = uSERNAME;
        this.AGENTLOCATION = aGENTLOCATION;
        this.AGENTADDRESS = aGENTADDRESS;
        this.AGENTCITY = aGENTCITY;
        this.AGENTSTATE = aGENTSTATE;
        this.AGENTZIP = aGENTZIP;
        this.AGENTPHONE = aGENTPHONE;
        this.AGENTACC = aGENTACC;
        this.CREATEDBY = cREATEDBY;
        this.CREATEDON = cREATEDON;
        this.UPDATEDBY = uPDATEDBY;
        this.UPDATEDON = uPDATEDON;
    }


    private int _aGENTID;
    public int AGENTID
    {
        get { return _aGENTID; }
        set { _aGENTID = value; }
    }

    private string _aGENTNAME;
    public string AGENTNAME
    {
        get { return _aGENTNAME; }
        set { _aGENTNAME = value; }
    }

    private string _uSERNAME;
    public string USERNAME
    {
        get { return _uSERNAME; }
        set { _uSERNAME = value; }
    }

    private string _aGENTLOCATION;
    public string AGENTLOCATION
    {
        get { return _aGENTLOCATION; }
        set { _aGENTLOCATION = value; }
    }

    private string _aGENTADDRESS;
    public string AGENTADDRESS
    {
        get { return _aGENTADDRESS; }
        set { _aGENTADDRESS = value; }
    }

    private string _aGENTCITY;
    public string AGENTCITY
    {
        get { return _aGENTCITY; }
        set { _aGENTCITY = value; }
    }

    private string _aGENTSTATE;
    public string AGENTSTATE
    {
        get { return _aGENTSTATE; }
        set { _aGENTSTATE = value; }
    }

    private string _aGENTZIP;
    public string AGENTZIP
    {
        get { return _aGENTZIP; }
        set { _aGENTZIP = value; }
    }

    private string _aGENTPHONE;
    public string AGENTPHONE
    {
        get { return _aGENTPHONE; }
        set { _aGENTPHONE = value; }
    }

    private string _aGENTACC;
    public string AGENTACC
    {
        get { return _aGENTACC; }
        set { _aGENTACC = value; }
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
