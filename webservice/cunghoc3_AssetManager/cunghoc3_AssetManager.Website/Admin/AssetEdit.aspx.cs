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

public partial class AssetEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AssetEdit.aspx?{0}", AssetDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AssetEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Asset.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewWarrantyAsset1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewWarrantyAsset1.SelectedDataKey.Values[0]);
		Response.Redirect("WarrantyAssetEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewAssetLiquidation2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewAssetLiquidation2.SelectedDataKey.Values[0]);
		Response.Redirect("AssetLiquidationEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewRepairAsset3_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewRepairAsset3.SelectedDataKey.Values[0]);
		Response.Redirect("RepairAssetEdit.aspx?" + urlParams, true);		
	}	
}


