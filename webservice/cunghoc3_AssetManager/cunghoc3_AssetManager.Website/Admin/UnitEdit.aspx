<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="UnitEdit.aspx.cs" Inherits="UnitEdit" Title="Unit Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Unit - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="UnitDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UnitFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UnitFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Unit not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:UnitDataSource ID="UnitDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:UnitDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewAsset1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewAsset1_SelectedIndexChanged"			 			 
			DataSourceID="AssetDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Asset.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<data:HyperLinkField HeaderText="Asset Group Id" DataNavigateUrlFormatString="AssetGroupEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AssetGroupIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Unit Id" DataNavigateUrlFormatString="UnitEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="UnitIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="[Amount]" />				
				<asp:BoundField DataField="CounPro" HeaderText="Coun Pro" SortExpression="[CounPro]" />				
				<asp:BoundField DataField="YearPro" HeaderText="Year Pro" SortExpression="[YearPro]" />				
				<data:HyperLinkField HeaderText="Department Used Id" DataNavigateUrlFormatString="DepartmentUsedEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DepartmentUsedIdSource" DataTextField="Name" />
				<asp:BoundField DataField="TotalPrice" HeaderText="Total Price" SortExpression="[TotalPrice]" />				
				<asp:BoundField DataField="BudgetPrice" HeaderText="Budget Price" SortExpression="[BudgetPrice]" />				
				<asp:BoundField DataField="OwnPrice" HeaderText="Own Price" SortExpression="[OwnPrice]" />				
				<asp:BoundField DataField="VenturePrice" HeaderText="Venture Price" SortExpression="[VenturePrice]" />				
				<asp:BoundField DataField="AnotherPrice" HeaderText="Another Price" SortExpression="[AnotherPrice]" />				
				<asp:BoundField DataField="TotalDepreciation" HeaderText="Total Depreciation" SortExpression="[TotalDepreciation]" />				
				<asp:BoundField DataField="BudgetDepreciation" HeaderText="Budget Depreciation" SortExpression="[BudgetDepreciation]" />				
				<asp:BoundField DataField="OwnDepreciation" HeaderText="Own Depreciation" SortExpression="[OwnDepreciation]" />				
				<asp:BoundField DataField="VentureDepreciation" HeaderText="Venture Depreciation" SortExpression="[VentureDepreciation]" />				
				<asp:BoundField DataField="AnotherDepreciation" HeaderText="Another Depreciation" SortExpression="[AnotherDepreciation]" />				
				<asp:BoundField DataField="BudgetRemain" HeaderText="Budget Remain" SortExpression="[BudgetRemain]" />				
				<asp:BoundField DataField="OwnRemain" HeaderText="Own Remain" SortExpression="[OwnRemain]" />				
				<asp:BoundField DataField="VentureRemain" HeaderText="Venture Remain" SortExpression="[VentureRemain]" />				
				<asp:BoundField DataField="AnotherRemain" HeaderText="Another Remain" SortExpression="[AnotherRemain]" />				
				<asp:BoundField DataField="TotalReamain" HeaderText="Total Reamain" SortExpression="[TotalReamain]" />				
				<asp:BoundField DataField="UpDownCode" HeaderText="Up Down Code" SortExpression="[UpDownCode]" />				
				<asp:BoundField DataField="InputDateTime" HeaderText="Input Date Time" SortExpression="[InputDateTime]" />				
				<asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" SortExpression="[Manufacturer]" />				
				<asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="[Brand]" />				
				<asp:BoundField DataField="Model" HeaderText="Model" SortExpression="[Model]" />				
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="[Status]" />				
				<asp:BoundField DataField="DueDate" HeaderText="Due Date" SortExpression="[DueDate]" />				
				<asp:BoundField DataField="Note" HeaderText="Note" SortExpression="[Note]" />				
				<asp:BoundField DataField="SeriesNumber" HeaderText="Series Number" SortExpression="[SeriesNumber]" />				
				<asp:BoundField DataField="Condition" HeaderText="Condition" SortExpression="[Condition]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Asset Found! </b>
				<asp:HyperLink runat="server" ID="hypAsset" NavigateUrl="~/admin/AssetEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:AssetDataSource ID="AssetDataSource1" runat="server" SelectMethod="Find"
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
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:AssetFilter  Column="UnitId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:AssetDataSource>		
		
		<br />
		

</asp:Content>

