<%@ Control Language="C#" ClassName="ImageFields" %>

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
        <td class="literal"><asp:Label ID="lbldataImageUrl" runat="server" Text="Image Url:" AssociatedControlID="dataImageUrl" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataImageUrl" Text='<%# Bind("ImageUrl") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


