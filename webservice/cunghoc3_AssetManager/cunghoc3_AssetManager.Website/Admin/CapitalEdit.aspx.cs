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

public partial class CapitalEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CapitalEdit.aspx?{0}", CapitalDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CapitalEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Capital.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
}


