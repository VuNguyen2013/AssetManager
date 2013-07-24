<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="WarrantyAsset.aspx.cs" Inherits="WarrantyAsset" Title="WarrantyAsset List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Warranty Asset List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="WarrantyAssetDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_WarrantyAsset.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="[Id]" ReadOnly="True" />
				<data:HyperLinkField HeaderText="Assset Id" DataNavigateUrlFormatString="AssetEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AsssetIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Department Used Id" DataNavigateUrlFormatString="DepartmentUsedEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DepartmentUsedIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Partner Id" DataNavigateUrlFormatString="PartnerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="PartnerIdSource" DataTextField="Name" />
				<asp:BoundField DataField="WarDateTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="War Date Time" SortExpression="[WarDateTime]"  />
				<asp:BoundField DataField="DeadlineWar" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Deadline War" SortExpression="[DeadlineWar]"  />
				<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]"  />
				<asp:BoundField DataField="PersonWar" HeaderText="Person War" SortExpression="[PersonWar]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No WarrantyAsset Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnWarrantyAsset" OnClientClick="javascript:location.href='WarrantyAssetEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:WarrantyAssetDataSource ID="WarrantyAssetDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:WarrantyAssetProperty Name="Asset"/> 
					<data:WarrantyAssetProperty Name="DepartmentUsed"/> 
					<data:WarrantyAssetProperty Name="Partner"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:WarrantyAssetDataSource>
	    		
</asp:Content>



