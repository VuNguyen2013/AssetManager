<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DepartmentUsedEdit.aspx.cs" Inherits="DepartmentUsedEdit" Title="DepartmentUsed Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Department Used - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="DepartmentUsedDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DepartmentUsedFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DepartmentUsedFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>DepartmentUsed not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:DepartmentUsedDataSource ID="DepartmentUsedDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:DepartmentUsedDataSource>
		
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
						<data:AssetFilter  Column="DepartmentUsedId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:AssetDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewWarrantyAsset2" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewWarrantyAsset2_SelectedIndexChanged"			 			 
			DataSourceID="WarrantyAssetDataSource2"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_WarrantyAsset.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Assset Id" DataNavigateUrlFormatString="AssetEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AsssetIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Department Used Id" DataNavigateUrlFormatString="DepartmentUsedEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DepartmentUsedIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Partner Id" DataNavigateUrlFormatString="PartnerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="PartnerIdSource" DataTextField="Name" />
				<asp:BoundField DataField="WarDateTime" HeaderText="War Date Time" SortExpression="[WarDateTime]" />				
				<asp:BoundField DataField="DeadlineWar" HeaderText="Deadline War" SortExpression="[DeadlineWar]" />				
				<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]" />				
				<asp:BoundField DataField="PersonWar" HeaderText="Person War" SortExpression="[PersonWar]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Warranty Asset Found! </b>
				<asp:HyperLink runat="server" ID="hypWarrantyAsset" NavigateUrl="~/admin/WarrantyAssetEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:WarrantyAssetDataSource ID="WarrantyAssetDataSource2" runat="server" SelectMethod="Find"
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
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:WarrantyAssetFilter  Column="DepartmentUsedId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:WarrantyAssetDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewAssetLiquidation3" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewAssetLiquidation3_SelectedIndexChanged"			 			 
			DataSourceID="AssetLiquidationDataSource3"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_AssetLiquidation.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Asset Id" DataNavigateUrlFormatString="AssetEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AssetIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="[Amount]" />				
				<data:HyperLinkField HeaderText="Department Used Id" DataNavigateUrlFormatString="DepartmentUsedEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DepartmentUsedIdSource" DataTextField="Name" />
				<asp:BoundField DataField="LiDateTime" HeaderText="Li Date Time" SortExpression="[LiDateTime]" />				
				<asp:BoundField DataField="LiPrice" HeaderText="Li Price" SortExpression="[LiPrice]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Asset Liquidation Found! </b>
				<asp:HyperLink runat="server" ID="hypAssetLiquidation" NavigateUrl="~/admin/AssetLiquidationEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:AssetLiquidationDataSource ID="AssetLiquidationDataSource3" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AssetLiquidationProperty Name="Asset"/> 
					<data:AssetLiquidationProperty Name="DepartmentUsed"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:AssetLiquidationFilter  Column="DepartmentUsedId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:AssetLiquidationDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewRepairAsset4" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewRepairAsset4_SelectedIndexChanged"			 			 
			DataSourceID="RepairAssetDataSource4"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_RepairAsset.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Asset Id" DataNavigateUrlFormatString="AssetEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AssetIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Department Used Id" DataNavigateUrlFormatString="DepartmentUsedEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DepartmentUsedIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="[Reason]" />				
				<data:HyperLinkField HeaderText="Partner Id" DataNavigateUrlFormatString="PartnerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="PartnerIdSource" DataTextField="Name" />
				<asp:BoundField DataField="RepairDate" HeaderText="Repair Date" SortExpression="[RepairDate]" />				
				<asp:BoundField DataField="Fee" HeaderText="Fee" SortExpression="[Fee]" />				
				<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Repair Asset Found! </b>
				<asp:HyperLink runat="server" ID="hypRepairAsset" NavigateUrl="~/admin/RepairAssetEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:RepairAssetDataSource ID="RepairAssetDataSource4" runat="server" SelectMethod="Find"
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
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:RepairAssetFilter  Column="DepartmentUsedId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:RepairAssetDataSource>		
		
		<br />
		

</asp:Content>

