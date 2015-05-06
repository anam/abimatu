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

public class RECEIVER
{
    public RECEIVER()
    {
    }

    public RECEIVER
        (
        int rECEIVERID, 
        string uSERNAME, 
        string rECEIVERFNAME, 
        string rECEIVERMNAME, 
        string rECEIVERLNAME, 
        string rECEIVERADDRESS1, 
        string rECEIVERADDRESS2, 
        string rECEIVERCITY, 
        string rECEIVERSTATE, 
        string rECEIVERZIP, 
        string rECEIVERPHONE,
          string sCANURL, 
        int cREATEDBY, 
        DateTime cREATEDON, 
        int uPDATEDBY, 
        DateTime uPDATEDON
        )
    {
        this.RECEIVERID = rECEIVERID;
        this.USERNAME = uSERNAME;
        this.RECEIVERFNAME = rECEIVERFNAME;
        this.RECEIVERMNAME = rECEIVERMNAME;
        this.RECEIVERLNAME = rECEIVERLNAME;
        this.RECEIVERADDRESS1 = rECEIVERADDRESS1;
        this.RECEIVERADDRESS2 = rECEIVERADDRESS2;
        this.RECEIVERCITY = rECEIVERCITY;
        this.RECEIVERSTATE = rECEIVERSTATE;
        this.RECEIVERZIP = rECEIVERZIP;
        this.RECEIVERPHONE = rECEIVERPHONE;
        this.SCANURL = sCANURL;
        this.CREATEDBY = cREATEDBY;
        this.CREATEDON = cREATEDON;
        this.UPDATEDBY = uPDATEDBY;
        this.UPDATEDON = uPDATEDON;
    }

    public RECEIVER
    (
    int cUSTID,
    int lOCATIONID,
    string bRANCH,
    int rECEIVERID,
    string uSERNAME,
    string rECEIVERFNAME,
    string rECEIVERMNAME,
    string rECEIVERLNAME,
    string rECEIVERADDRESS1,
    string rECEIVERADDRESS2,
    string rECEIVERCITY,
    string rECEIVERSTATE,
    string rECEIVERZIP,
    string rECEIVERPHONE,
      string sCANURL,
    int cREATEDBY,
    DateTime cREATEDON,
    int uPDATEDBY,
    DateTime uPDATEDON
    )
    {
        this.CUSTID = cUSTID;
        this.LOCATIONID = lOCATIONID;
        this.BRANCH = bRANCH;

        this.RECEIVERID = rECEIVERID;
        this.USERNAME = uSERNAME;
        this.RECEIVERFNAME = rECEIVERFNAME;
        this.RECEIVERMNAME = rECEIVERMNAME;
        this.RECEIVERLNAME = rECEIVERLNAME;
        this.RECEIVERADDRESS1 = rECEIVERADDRESS1;
        this.RECEIVERADDRESS2 = rECEIVERADDRESS2;
        this.RECEIVERCITY = rECEIVERCITY;
        this.RECEIVERSTATE = rECEIVERSTATE;
        this.RECEIVERZIP = rECEIVERZIP;
        this.RECEIVERPHONE = rECEIVERPHONE;
        this.SCANURL = sCANURL;
        this.CREATEDBY = cREATEDBY;
        this.CREATEDON = cREATEDON;
        this.UPDATEDBY = uPDATEDBY;
        this.UPDATEDON = uPDATEDON;
    }
    private int _rECEIVERID;
    public int RECEIVERID
    {
        get { return _rECEIVERID; }
        set { _rECEIVERID = value; }
    }

    private string _uSERNAME;
    public string USERNAME
    {
        get { return _uSERNAME; }
        set { _uSERNAME = value; }
    }

    private string _rECEIVERFNAME;
    public string RECEIVERFNAME
    {
        get { return _rECEIVERFNAME; }
        set { _rECEIVERFNAME = value; }
    }

    private string _rECEIVERMNAME;
    public string RECEIVERMNAME
    {
        get { return _rECEIVERMNAME; }
        set { _rECEIVERMNAME = value; }
    }

    private string _rECEIVERLNAME;
    public string RECEIVERLNAME
    {
        get { return _rECEIVERLNAME; }
        set { _rECEIVERLNAME = value; }
    }

    private string _rECEIVERADDRESS1;
    public string RECEIVERADDRESS1
    {
        get { return _rECEIVERADDRESS1; }
        set { _rECEIVERADDRESS1 = value; }
    }

    private string _rECEIVERADDRESS2;
    public string RECEIVERADDRESS2
    {
        get { return _rECEIVERADDRESS2; }
        set { _rECEIVERADDRESS2 = value; }
    }

    private string _rECEIVERCITY;
    public string RECEIVERCITY
    {
        get { return _rECEIVERCITY; }
        set { _rECEIVERCITY = value; }
    }

    private string _rECEIVERSTATE;
    public string RECEIVERSTATE
    {
        get { return _rECEIVERSTATE; }
        set { _rECEIVERSTATE = value; }
    }

    private string _rECEIVERZIP;
    public string RECEIVERZIP
    {
        get { return _rECEIVERZIP; }
        set { _rECEIVERZIP = value; }
    }

    private string _rECEIVERPHONE;
    public string RECEIVERPHONE
    {
        get { return _rECEIVERPHONE; }
        set { _rECEIVERPHONE = value; }
    }

    private string _sCANURL;
    public string SCANURL
    {
        get { return _sCANURL; }
        set { _sCANURL = value; }
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


    private int _cUSTID;
    public int CUSTID
    {
        get { return _cUSTID; }
        set { _cUSTID = value; }
    }

    private int _lOCATIONID;
    public int LOCATIONID
    {
        get { return _lOCATIONID; }
        set { _lOCATIONID = value; }
    }

    private string _bRANCH;
    public string BRANCH
    {
        get { return _bRANCH; }
        set { _bRANCH = value; }
    }

    private int _agentID;

    public int AgentID
    {
        get { return _agentID; }
        set { _agentID = value; }
    }
}
