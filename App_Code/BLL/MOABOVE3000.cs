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

public class MOABOVE3000
{
    public MOABOVE3000()
    {
    }

    public MOABOVE3000
        (
        int mOABOVE3000ID, 
        DateTime dT, 
        string cUST_ID, 
        string sTARTNO, 
        string eNDNO, 
        int aMOUNT, 
        int eMP_ID, 
        int sTATION_ID, 
        int sHIFT_ID
        )
    {
        this.MOABOVE3000ID = mOABOVE3000ID;
        this.DT = dT;
        this.CUST_ID = cUST_ID;
        this.STARTNO = sTARTNO;
        this.ENDNO = eNDNO;
        this.AMOUNT = aMOUNT;
        this.EMP_ID = eMP_ID;
        this.STATION_ID = sTATION_ID;
        this.SHIFT_ID = sHIFT_ID;
    }


    private int _mOABOVE3000ID;
    public int MOABOVE3000ID
    {
        get { return _mOABOVE3000ID; }
        set { _mOABOVE3000ID = value; }
    }

    private DateTime _dT;
    public DateTime DT
    {
        get { return _dT; }
        set { _dT = value; }
    }

    private string _cUST_ID;
    public string CUST_ID
    {
        get { return _cUST_ID; }
        set { _cUST_ID = value; }
    }

    private string _sTARTNO;
    public string STARTNO
    {
        get { return _sTARTNO; }
        set { _sTARTNO = value; }
    }

    private string _eNDNO;
    public string ENDNO
    {
        get { return _eNDNO; }
        set { _eNDNO = value; }
    }

    private int _aMOUNT;
    public int AMOUNT
    {
        get { return _aMOUNT; }
        set { _aMOUNT = value; }
    }

    private int _eMP_ID;
    public int EMP_ID
    {
        get { return _eMP_ID; }
        set { _eMP_ID = value; }
    }

    private int _sTATION_ID;
    public int STATION_ID
    {
        get { return _sTATION_ID; }
        set { _sTATION_ID = value; }
    }

    private int _sHIFT_ID;
    public int SHIFT_ID
    {
        get { return _sHIFT_ID; }
        set { _sHIFT_ID = value; }
    }
}
