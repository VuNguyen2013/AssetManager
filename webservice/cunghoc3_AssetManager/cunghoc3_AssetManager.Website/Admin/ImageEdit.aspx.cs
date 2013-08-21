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

public partial class ImageEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ImageEdit.aspx?{0}", ImageDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ImageEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Image.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
}


