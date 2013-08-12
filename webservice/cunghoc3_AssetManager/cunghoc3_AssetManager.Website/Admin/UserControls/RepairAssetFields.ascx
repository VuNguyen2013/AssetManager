<%@ Control Language="C#" ClassName="RepairAssetFields" %>

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
        <td class="literal"><asp:Label ID="lbldataDepartmentUsedId" runat="server" Text="Department Used Id:" AssociatedControlID="dataDepartmentUsedId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDepartmentUsedId" DataSourceID="DepartmentUsedIdDepartmentUsedDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("DepartmentUsedId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:DepartmentUsedDataSource ID="DepartmentUsedIdDepartmentUsedDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReason" runat="server" Text="Reason:" AssociatedControlID="dataReason" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReason" Text='<%# Bind("Reason") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataReason" runat="server" Display="Dynamic" ControlToValidate="dataReason" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPartnerId" runat="server" Text="Partner Id:" AssociatedControlID="dataPartnerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataPartnerId" DataSourceID="PartnerIdPartnerDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("PartnerId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:PartnerDataSource ID="PartnerIdPartnerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRepairDate" runat="server" Text="Repair Date:" AssociatedControlID="dataRepairDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRepairDate" Text='<%# Bind("RepairDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataRepairDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataRepairDate" runat="server" Display="Dynamic" ControlToValidate="dataRepairDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFee" runat="server" Text="Fee:" AssociatedControlID="dataFee" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFee" Text='<%# Bind("Fee") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFee" runat="server" Display="Dynamic" ControlToValidate="dataFee" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataFee" runat="server" Display="Dynamic" ControlToValidate="dataFee" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddress" runat="server" Text="Address:" AssociatedControlID="dataAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddress" Text='<%# Bind("Address") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


