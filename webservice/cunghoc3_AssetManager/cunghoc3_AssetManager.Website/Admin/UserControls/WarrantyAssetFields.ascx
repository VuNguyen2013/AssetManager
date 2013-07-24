<%@ Control Language="C#" ClassName="WarrantyAssetFields" %>

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
        <td class="literal"><asp:Label ID="lbldataAsssetId" runat="server" Text="Assset Id:" AssociatedControlID="dataAsssetId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataAsssetId" DataSourceID="AsssetIdAssetDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("AsssetId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:AssetDataSource ID="AsssetIdAssetDataSource" runat="server" SelectMethod="GetAll"  />
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
        <td class="literal"><asp:Label ID="lbldataPartnerId" runat="server" Text="Partner Id:" AssociatedControlID="dataPartnerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataPartnerId" DataSourceID="PartnerIdPartnerDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("PartnerId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:PartnerDataSource ID="PartnerIdPartnerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWarDateTime" runat="server" Text="War Date Time:" AssociatedControlID="dataWarDateTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWarDateTime" Text='<%# Bind("WarDateTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataWarDateTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataWarDateTime" runat="server" Display="Dynamic" ControlToValidate="dataWarDateTime" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDeadlineWar" runat="server" Text="Deadline War:" AssociatedControlID="dataDeadlineWar" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDeadlineWar" Text='<%# Bind("DeadlineWar", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDeadlineWar" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddress" runat="server" Text="Address:" AssociatedControlID="dataAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddress" Text='<%# Bind("Address") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAddress" runat="server" Display="Dynamic" ControlToValidate="dataAddress" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPersonWar" runat="server" Text="Person War:" AssociatedControlID="dataPersonWar" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPersonWar" Text='<%# Bind("PersonWar") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


