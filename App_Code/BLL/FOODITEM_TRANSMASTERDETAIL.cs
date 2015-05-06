using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FOODITEM_TRANSMASTERDETAIL
/// </summary>
public class FOODITEM_TRANSMASTERDETAIL
{
	public FOODITEM_TRANSMASTERDETAIL()
	{
		//
		// TODO: Add constructor logic here
		//
	}


        public FOODITEM_TRANSMASTERDETAIL
        (

            int fID,
            decimal fRATE, 
            int fQTY,
            decimal sUBTOTAL, 
            int cUSTID, 
            int lOCATIONID, 
            int rRECEIVERID, 
            decimal tOTALAMT

        )
    {

            this.FID = fID;
            this.FRATE = fRATE;
            this.FQTY = fQTY;
            this.CUSTID = cUSTID;
            this.LOCATIONID = lOCATIONID;
            this.SUBTOTAL = sUBTOTAL;
            this.TOTALAMT = tOTALAMT;
            this.RECEIVERID = rRECEIVERID;

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


    private decimal _tOTALAMT;
    public decimal TOTALAMT
    {
        get { return _tOTALAMT; }
        set { _tOTALAMT = value; }
    }



    private decimal _sUBTOTAL;
    public decimal SUBTOTAL
    {
        get { return _sUBTOTAL; }
        set { _sUBTOTAL = value; }
    }

    private int _rECEIVERID;
    public int RECEIVERID
    {
        get { return _rECEIVERID; }
        set { _rECEIVERID = value; }
    }


    private bool _isAgent;

    public bool IsAgent
    {
        get { return _isAgent; }
        set { _isAgent = value; }
    }

}