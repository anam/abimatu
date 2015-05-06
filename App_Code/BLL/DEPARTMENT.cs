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

public class DEPARTMENT
{
    public DEPARTMENT()
    {
    }

    public DEPARTMENT
        (
        int dEPARTMENTID, 
        string dEPTNAME
        )
    {
        this.DEPARTMENTID = dEPARTMENTID;
        this.DEPTNAME = dEPTNAME;
    }


    private int _dEPARTMENTID;
    public int DEPARTMENTID
    {
        get { return _dEPARTMENTID; }
        set { _dEPARTMENTID = value; }
    }

    private string _dEPTNAME;
    public string DEPTNAME
    {
        get { return _dEPTNAME; }
        set { _dEPTNAME = value; }
    }
}
