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

public partial class PartnerEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "PartnerEdit.aspx?{0}", PartnerDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "PartnerEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Partner.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewWarrantyAsset1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewWarrantyAsset1.SelectedDataKey.Values[0]);
		Response.Redirect("WarrantyAssetEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewRepairAsset2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewRepairAsset2.SelectedDataKey.Values[0]);
		Response.Redirect("RepairAssetEdit.aspx?" + urlParams, true);		
	}	
}


