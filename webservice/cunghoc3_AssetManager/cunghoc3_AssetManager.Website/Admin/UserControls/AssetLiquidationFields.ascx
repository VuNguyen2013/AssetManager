<%@ Control Language="C#" ClassName="AssetLiquidationFields" %>

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
        <td class="literal"><asp:Label ID="lbldataAssetId" runat="server" Text="Asset Id:" AssociatedControlID="dataAssetId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataAssetId" DataSourceID="AssetIdAssetDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("AssetId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:AssetDataSource ID="AssetIdAssetDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAmount" runat="server" Text="Amount:" AssociatedControlID="dataAmount" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAmount" Text='<%# Bind("Amount") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAmount" runat="server" Display="Dynamic" ControlToValidate="dataAmount" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataAmount" runat="server" Display="Dynamic" ControlToValidate="dataAmount" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDepartmentUsedId" runat="server" Text="Department Used Id:" AssociatedControlID="dataDepartmentUsedId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDepartmentUsedId" DataSourceID="DepartmentUsedIdDepartmentUsedDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("DepartmentUsedId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:DepartmentUsedDataSource ID="DepartmentUsedIdDepartmentUsedDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLiDateTime" runat="server" Text="Li Date Time:" AssociatedControlID="dataLiDateTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLiDateTime" Text='<%# Bind("LiDateTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLiDateTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLiDateTime" runat="server" Display="Dynamic" ControlToValidate="dataLiDateTime" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLiPrice" runat="server" Text="Li Price:" AssociatedControlID="dataLiPrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLiPrice" Text='<%# Bind("LiPrice") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLiPrice" runat="server" Display="Dynamic" ControlToValidate="dataLiPrice" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataLiPrice" runat="server" Display="Dynamic" ControlToValidate="dataLiPrice" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


