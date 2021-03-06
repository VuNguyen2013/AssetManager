﻿<%@ Control Language="C#" ClassName="AssetGroupFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataId" runat="server" Text="Id:" AssociatedControlID="dataId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataId" Text='<%# Bind("Id") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAssetGroupTypeId" runat="server" Text="Asset Group Type Id:" AssociatedControlID="dataAssetGroupTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataAssetGroupTypeId" DataSourceID="AssetGroupTypeIdAssetGroupTypeDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("AssetGroupTypeId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:AssetGroupTypeDataSource ID="AssetGroupTypeIdAssetGroupTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


