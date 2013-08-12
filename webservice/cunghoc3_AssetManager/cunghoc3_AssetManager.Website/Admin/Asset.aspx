<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Asset.aspx.cs" Inherits="Asset" Title="Asset List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Asset List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AssetDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Asset.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="[Id]" ReadOnly="True" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<data:HyperLinkField HeaderText="Asset Group Id" DataNavigateUrlFormatString="AssetGroupEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AssetGroupIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Unit Id" DataNavigateUrlFormatString="UnitEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="UnitIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="[Amount]"  />
				<asp:BoundField DataField="CounPro" HeaderText="Coun Pro" SortExpression="[CounPro]"  />
				<asp:BoundField DataField="YearPro" HeaderText="Year Pro" SortExpression="[YearPro]"  />
				<data:HyperLinkField HeaderText="Department Used Id" DataNavigateUrlFormatString="DepartmentUsedEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DepartmentUsedIdSource" DataTextField="Name" />
				<asp:BoundField DataField="TotalPrice" HeaderText="Total Price" SortExpression="[TotalPrice]"  />
				<asp:BoundField DataField="BudgetPrice" HeaderText="Budget Price" SortExpression="[BudgetPrice]"  />
				<asp:BoundField DataField="OwnPrice" HeaderText="Own Price" SortExpression="[OwnPrice]"  />
				<asp:BoundField DataField="VenturePrice" HeaderText="Venture Price" SortExpression="[VenturePrice]"  />
				<asp:BoundField DataField="AnotherPrice" HeaderText="Another Price" SortExpression="[AnotherPrice]"  />
				<asp:BoundField DataField="TotalDepreciation" HeaderText="Total Depreciation" SortExpression="[TotalDepreciation]"  />
				<asp:BoundField DataField="BudgetDepreciation" HeaderText="Budget Depreciation" SortExpression="[BudgetDepreciation]"  />
				<asp:BoundField DataField="OwnDepreciation" HeaderText="Own Depreciation" SortExpression="[OwnDepreciation]"  />
				<asp:BoundField DataField="VentureDepreciation" HeaderText="Venture Depreciation" SortExpression="[VentureDepreciation]"  />
				<asp:BoundField DataField="AnotherDepreciation" HeaderText="Another Depreciation" SortExpression="[AnotherDepreciation]"  />
				<asp:BoundField DataField="BudgetRemain" HeaderText="Budget Remain" SortExpression="[BudgetRemain]"  />
				<asp:BoundField DataField="OwnRemain" HeaderText="Own Remain" SortExpression="[OwnRemain]"  />
				<asp:BoundField DataField="VentureRemain" HeaderText="Venture Remain" SortExpression="[VentureRemain]"  />
				<asp:BoundField DataField="AnotherRemain" HeaderText="Another Remain" SortExpression="[AnotherRemain]"  />
				<asp:BoundField DataField="TotalReamain" HeaderText="Total Reamain" SortExpression="[TotalReamain]"  />
				<asp:BoundField DataField="UpDownCode" HeaderText="Up Down Code" SortExpression="[UpDownCode]"  />
				<asp:BoundField DataField="InputDateTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Input Date Time" SortExpression="[InputDateTime]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Asset Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAsset" OnClientClick="javascript:location.href='AssetEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AssetDataSource ID="AssetDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AssetProperty Name="AssetGroup"/> 
					<data:AssetProperty Name="DepartmentUsed"/> 
					<data:AssetProperty Name="Unit"/> 
					<%--<data:AssetProperty Name="WarrantyAssetCollection" />--%>
					<%--<data:AssetProperty Name="AssetLiquidationCollection" />--%>
					<%--<data:AssetProperty Name="RepairAssetCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AssetDataSource>
	    		
</asp:Content>



