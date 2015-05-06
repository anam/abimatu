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

public class TRANSFERACCOUNT
{
    public TRANSFERACCOUNT()
    {
    }

    public TRANSFERACCOUNT
        (
        int tRANSFERACCOUNTID, 
        char aCCTYPE, 
        string aCCNAME
        )
    {
        this.TRANSFERACCOUNTID = tRANSFERACCOUNTID;
        this.ACCTYPE = aCCTYPE;
        this.ACCNAME = aCCNAME;
    }


    private int _tRANSFERACCOUNTID;
    public int TRANSFERACCOUNTID
    {
        get { return _tRANSFERACCOUNTID; }
        set { _tRANSFERACCOUNTID = value; }
    }

    private char _aCCTYPE;
    public char ACCTYPE
    {
        get { return _aCCTYPE; }
        set { _aCCTYPE = value; }
    }

    private string _aCCNAME;
    public string ACCNAME
    {
        get { return _aCCNAME; }
        set { _aCCNAME = value; }
    }
}
