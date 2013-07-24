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

public partial class AssetGroupTypeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AssetGroupTypeEdit.aspx?{0}", AssetGroupTypeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AssetGroupTypeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AssetGroupType.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewAssetGroup1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewAssetGroup1.SelectedDataKey.Values[0]);
		Response.Redirect("AssetGroupEdit.aspx?" + urlParams, true);		
	}	
}


