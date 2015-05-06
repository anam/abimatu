using System;
using System.Collections.Generic;
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

public class SPR_VOICEManager
{
	public SPR_VOICEManager()
	{
	}

    public static List<SPR_VOICE> GetAllSPR_VOICEs()
    {
        List<SPR_VOICE> sPR_VOICEs = new List<SPR_VOICE>();
        SqlSPR_VOICEProvider sqlSPR_VOICEProvider = new SqlSPR_VOICEProvider();
        sPR_VOICEs = sqlSPR_VOICEProvider.GetAllSPR_VOICEs();
        return sPR_VOICEs;
    }


    public static SPR_VOICE GetSPR_VOICEByID(int id)
    {
        SPR_VOICE sPR_VOICE = new SPR_VOICE();
        SqlSPR_VOICEProvider sqlSPR_VOICEProvider = new SqlSPR_VOICEProvider();
        sPR_VOICE = sqlSPR_VOICEProvider.GetSPR_VOICEByID(id);
        return sPR_VOICE;
    }


    public static int InsertSPR_VOICE(SPR_VOICE sPR_VOICE)
    {
        SqlSPR_VOICEProvider sqlSPR_VOICEProvider = new SqlSPR_VOICEProvider();
        return sqlSPR_VOICEProvider.InsertSPR_VOICE(sPR_VOICE);
    }


    public static bool UpdateSPR_VOICE(SPR_VOICE sPR_VOICE)
    {
        SqlSPR_VOICEProvider sqlSPR_VOICEProvider = new SqlSPR_VOICEProvider();
        return sqlSPR_VOICEProvider.UpdateSPR_VOICE(sPR_VOICE);
    }

    public static bool DeleteSPR_VOICE(int sPR_VOICEID)
    {
        SqlSPR_VOICEProvider sqlSPR_VOICEProvider = new SqlSPR_VOICEProvider();
        return sqlSPR_VOICEProvider.DeleteSPR_VOICE(sPR_VOICEID);
    }
}
