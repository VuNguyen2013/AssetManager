<%@ Control Language="C#" ClassName="CheckOutFields" %>

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
        <td class="literal"><asp:Label ID="lbldataCheckOutDate" runat="server" Text="Check Out Date:" AssociatedControlID="dataCheckOutDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCheckOutDate" Text='<%# Bind("CheckOutDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCheckOutDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
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
			<tr>
        <td class="literal"><asp:Label ID="lbldataStatus" runat="server" Text="Status:" AssociatedControlID="dataStatus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStatus" Text='<%# Bind("Status") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataStatus" runat="server" Display="Dynamic" ControlToValidate="dataStatus" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


