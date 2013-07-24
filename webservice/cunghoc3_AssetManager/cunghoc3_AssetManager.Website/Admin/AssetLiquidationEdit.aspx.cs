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

public partial class AssetLiquidationEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AssetLiquidationEdit.aspx?{0}", AssetLiquidationDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AssetLiquidationEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AssetLiquidation.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
}


