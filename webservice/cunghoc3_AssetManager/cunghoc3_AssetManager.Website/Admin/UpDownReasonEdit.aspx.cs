#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using cunghoc3_AssetManager.Web.UI;
#endregion

public partial class UpDownReasonEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "UpDownReasonEdit.aspx?{0}", UpDownReasonDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "UpDownReasonEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "UpDownReason.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
}


