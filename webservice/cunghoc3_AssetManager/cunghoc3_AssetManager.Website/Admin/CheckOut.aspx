<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CheckOut.aspx.cs" Inherits="CheckOut" Title="CheckOut List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Check Out List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CheckOutDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CheckOut.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="AssetId" HeaderText="Asset Id" SortExpression="[AssetId]"  />
				<asp:BoundField DataField="CheckOutDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Check Out Date" SortExpression="[CheckOutDate]"  />
				<asp:BoundField DataField="Comment" HeaderText="Comment" SortExpression=""  />
				<asp:BoundField DataField="User" HeaderText="User" SortExpression="[User]"  />
				<asp:BoundField DataField="Computer" HeaderText="Computer" SortExpression="[Computer]"  />
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="[Status]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No CheckOut Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCheckOut" OnClientClick="javascript:location.href='CheckOutEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:CheckOutDataSource ID="CheckOutDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CheckOutDataSource>
	    		
</asp:Content>



