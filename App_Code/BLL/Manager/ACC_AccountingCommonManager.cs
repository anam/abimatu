using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_AccountingCommonManager
{
    public ACC_AccountingCommonManager()
	{
	}

    

    public static string ProcessDataBackup()
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        return sqlACC_AccountingCommonProvider.ProcessDataBackup();
    }
}

