<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="PartnerEdit.aspx.cs" Inherits="PartnerEdit" Title="Partner Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Partner - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="PartnerDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PartnerFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PartnerFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Partner not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:PartnerDataSource ID="PartnerDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:PartnerDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewWarrantyAsset1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewWarrantyAsset1_SelectedIndexChanged"			 			 
			DataSourceID="WarrantyAssetDataSource1"
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
		
		<data:WarrantyAssetDataSource ID="WarrantyAssetDataSource1" runat="server" SelectMethod="Find"
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
						<data:WarrantyAssetFilter  Column="PartnerId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:WarrantyAssetDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewRepairAsset2" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewRepairAsset2_SelectedIndexChanged"			 			 
			DataSourceID="RepairAssetDataSource2"
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
		
		<data:RepairAssetDataSource ID="RepairAssetDataSource2" runat="server" SelectMethod="Find"
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
						<data:RepairAssetFilter  Column="PartnerId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:RepairAssetDataSource>		
		
		<br />
		

</asp:Content>

