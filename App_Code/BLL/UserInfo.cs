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

public class USERINFO
{
    public USERINFO()
    {
    }

    public USERINFO
        (
        int uSERINFOID, 
        DateTime addedDate, 
        string addedBy, 
        DateTime modifyDate, 
        string modifyBy, 
        string type, 
        string userName, 
        int agent_LocationID, 
        string firstName, 
        string lastName, 
        string middleName, 
        string address, 
        string city, 
        string state, 
        string country, 
        string postalCode, 
        DateTime expDate, 
        int status, 
        string homePhone, 
        string workPhone, 
        string mobile, 
        string comm
        )
    {
        this.USERINFOID = uSERINFOID;
        this.AddedDate = addedDate;
        this.AddedBy = addedBy;
        this.ModifyDate = modifyDate;
        this.ModifyBy = modifyBy;
        this.Type = type;
        this.UserName = userName;
        this.Agent_LocationID = agent_LocationID;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.MiddleName = middleName;
        this.Address = address;
        this.City = city;
        this.State = state;
        this.Country = country;
        this.PostalCode = postalCode;
        this.ExpDate = expDate;
        this.Status = status;
        this.HomePhone = homePhone;
        this.WorkPhone = workPhone;
        this.Mobile = mobile;
        this.Comm = comm;
    }


    private int _uSERINFOID;
    public int USERINFOID
    {
        get { return _uSERINFOID; }
        set { _uSERINFOID = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }

    private string _addedBy;
    public string AddedBy
    {
        get { return _addedBy; }
        set { _addedBy = value; }
    }

    private DateTime _modifyDate;
    public DateTime ModifyDate
    {
        get { return _modifyDate; }
        set { _modifyDate = value; }
    }

    private string _modifyBy;
    public string ModifyBy
    {
        get { return _modifyBy; }
        set { _modifyBy = value; }
    }

    private string _type;
    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }

    private string _userName;
    public string UserName
    {
        get { return _userName; }
        set { _userName = value; }
    }

    private int _agent_LocationID;
    public int Agent_LocationID
    {
        get { return _agent_LocationID; }
        set { _agent_LocationID = value; }
    }

    private string _firstName;
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    private string _lastName;
    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    private string _middleName;
    public string MiddleName
    {
        get { return _middleName; }
        set { _middleName = value; }
    }

    private string _address;
    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }

    private string _city;
    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    private string _country;
    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }

    private string _postalCode;
    public string PostalCode
    {
        get { return _postalCode; }
        set { _postalCode = value; }
    }

    private DateTime _expDate;
    public DateTime ExpDate
    {
        get { return _expDate; }
        set { _expDate = value; }
    }

    private int _status;
    public int Status
    {
        get { return _status; }
        set { _status = value; }
    }

    private string _homePhone;
    public string HomePhone
    {
        get { return _homePhone; }
        set { _homePhone = value; }
    }

    private string _workPhone;
    public string WorkPhone
    {
        get { return _workPhone; }
        set { _workPhone = value; }
    }

    private string _mobile;
    public string Mobile
    {
        get { return _mobile; }
        set { _mobile = value; }
    }

    private string _comm;
    public string Comm
    {
        get { return _comm; }
        set { _comm = value; }
    }
}
