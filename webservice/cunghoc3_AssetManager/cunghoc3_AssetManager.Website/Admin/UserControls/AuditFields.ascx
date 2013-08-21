<%@ Control Language="C#" ClassName="AuditFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAssetId" runat="server" Text="Asset Id:" AssociatedControlID="dataAssetId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAssetId" Text='<%# Bind("AssetId") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAuditDate" runat="server" Text="Audit Date:" AssociatedControlID="dataAuditDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAuditDate" Text='<%# Bind("AuditDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataAuditDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataComment" runat="server" Text="Comment:" AssociatedControlID="dataComment" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataComment" Text='<%# Bind("Comment") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUser" runat="server" Text="User:" AssociatedControlID="dataUser" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUser" Text='<%# Bind("User") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataComputer" runat="server" Text="Computer:" AssociatedControlID="dataComputer" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataComputer" Text='<%# Bind("Computer") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


