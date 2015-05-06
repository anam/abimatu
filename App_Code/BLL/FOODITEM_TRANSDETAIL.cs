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

public class FOODITEM_TRANSDETAIL
{
    public FOODITEM_TRANSDETAIL()
    {
    }

    public FOODITEM_TRANSDETAIL
        (
        int fOODITEM_TRANSDETAILID, 
        int tID, 
        int fID, 
        decimal fRATE, 
        int fQTY, 
        DateTime cREATEDON, 
        int cREATEDBY, 
        DateTime uPDATEDON, 
        int uPDATEDBY
        )
    {
        this.FOODITEM_TRANSDETAILID = fOODITEM_TRANSDETAILID;
        this.TID = tID;
        this.FID = fID;
        this.FRATE = fRATE;
        this.FQTY = fQTY;
        this.CREATEDON = cREATEDON;
        this.CREATEDBY = cREATEDBY;
        this.UPDATEDON = uPDATEDON;
        this.UPDATEDBY = uPDATEDBY;
    }



    public FOODITEM_TRANSDETAIL
    (
    int fID,
    decimal fRATE,
    int fQTY
    )
    {

        this.FID = fID;
        this.FRATE = fRATE;
        this.FQTY = fQTY;
    }

    private int _fOODITEM_TRANSDETAILID;
    public int FOODITEM_TRANSDETAILID
    {
        get { return _fOODITEM_TRANSDETAILID; }
        set { _fOODITEM_TRANSDETAILID = value; }
    }

    private int _tID;
    public int TID
    {
        get { return _tID; }
        set { _tID = value; }
    }

    private int _fID;
    public int FID
    {
        get { return _fID; }
        set { _fID = value; }
    }

    private decimal _fRATE;
    public decimal FRATE
    {
        get { return _fRATE; }
        set { _fRATE = value; }
    }

    private int _fQTY;
    public int FQTY
    {
        get { return _fQTY; }
        set { _fQTY = value; }
    }

    private DateTime _cREATEDON;
    public DateTime CREATEDON
    {
        get { return _cREATEDON; }
        set { _cREATEDON = value; }
    }

    private int _cREATEDBY;
    public int CREATEDBY
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

    private int _uPDATEDBY;
    public int UPDATEDBY
    {
        get { return _uPDATEDBY; }
        set { _uPDATEDBY = value; }
    }
}
