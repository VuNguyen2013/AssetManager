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

public partial class DepartmentUsedEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DepartmentUsedEdit.aspx?{0}", DepartmentUsedDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DepartmentUsedEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "DepartmentUsed.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewAsset1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewAsset1.SelectedDataKey.Values[0]);
		Response.Redirect("AssetEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewWarrantyAsset2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewWarrantyAsset2.SelectedDataKey.Values[0]);
		Response.Redirect("WarrantyAssetEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewAssetLiquidation3_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewAssetLiquidation3.SelectedDataKey.Values[0]);
		Response.Redirect("AssetLiquidationEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewRepairAsset4_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewRepairAsset4.SelectedDataKey.Values[0]);
		Response.Redirect("RepairAssetEdit.aspx?" + urlParams, true);		
	}	
}


