<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="RepairAsset.aspx.cs" Inherits="RepairAsset" Title="RepairAsset List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Repair Asset List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="RepairAssetDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_RepairAsset.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="[Id]" ReadOnly="True" />
				<data:HyperLinkField HeaderText="Asset Id" DataNavigateUrlFormatString="AssetEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AssetIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Department Used Id" DataNavigateUrlFormatString="DepartmentUsedEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DepartmentUsedIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="[Reason]"  />
				<data:HyperLinkField HeaderText="Partner Id" DataNavigateUrlFormatString="PartnerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="PartnerIdSource" DataTextField="Name" />
				<asp:BoundField DataField="RepairDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Repair Date" SortExpression="[RepairDate]"  />
				<asp:BoundField DataField="Fee" HeaderText="Fee" SortExpression="[Fee]"  />
				<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No RepairAsset Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnRepairAsset" OnClientClick="javascript:location.href='RepairAssetEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:RepairAssetDataSource ID="RepairAssetDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:RepairAssetProperty Name="Asset"/> 
					<data:RepairAssetProperty Name="DepartmentUsed"/> 
					<data:RepairAssetProperty Name="Partner"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:RepairAssetDataSource>
	    		
</asp:Content>



