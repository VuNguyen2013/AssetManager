﻿#region Imports...
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

public partial class AssetGroupEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AssetGroupEdit.aspx?{0}", AssetGroupDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AssetGroupEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AssetGroup.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewAsset1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewAsset1.SelectedDataKey.Values[0]);
		Response.Redirect("AssetEdit.aspx?" + urlParams, true);		
	}	
}


