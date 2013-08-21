<%@ Control Language="C#" ClassName="AssetFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCondition" runat="server" Text="Condition:" AssociatedControlID="dataCondition" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCondition" Text='<%# Bind("Condition") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataCondition" runat="server" Display="Dynamic" ControlToValidate="dataCondition" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataId" runat="server" Text="Id:" AssociatedControlID="dataId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataId" Text='<%# Bind("Id") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAssetGroupId" runat="server" Text="Asset Group Id:" AssociatedControlID="dataAssetGroupId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataAssetGroupId" DataSourceID="AssetGroupIdAssetGroupDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("AssetGroupId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:AssetGroupDataSource ID="AssetGroupIdAssetGroupDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUnitId" runat="server" Text="Unit Id:" AssociatedControlID="dataUnitId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataUnitId" DataSourceID="UnitIdUnitDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("UnitId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:UnitDataSource ID="UnitIdUnitDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAmount" runat="server" Text="Amount:" AssociatedControlID="dataAmount" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAmount" Text='<%# Bind("Amount") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAmount" runat="server" Display="Dynamic" ControlToValidate="dataAmount" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataAmount" runat="server" Display="Dynamic" ControlToValidate="dataAmount" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCounPro" runat="server" Text="Coun Pro:" AssociatedControlID="dataCounPro" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCounPro" Text='<%# Bind("CounPro") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCounPro" runat="server" Display="Dynamic" ControlToValidate="dataCounPro" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataYearPro" runat="server" Text="Year Pro:" AssociatedControlID="dataYearPro" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataYearPro" Text='<%# Bind("YearPro") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataYearPro" runat="server" Display="Dynamic" ControlToValidate="dataYearPro" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataYearPro" runat="server" Display="Dynamic" ControlToValidate="dataYearPro" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDepartmentUsedId" runat="server" Text="Department Used Id:" AssociatedControlID="dataDepartmentUsedId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDepartmentUsedId" DataSourceID="DepartmentUsedIdDepartmentUsedDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("DepartmentUsedId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:DepartmentUsedDataSource ID="DepartmentUsedIdDepartmentUsedDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalPrice" runat="server" Text="Total Price:" AssociatedControlID="dataTotalPrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalPrice" Text='<%# Bind("TotalPrice") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTotalPrice" runat="server" Display="Dynamic" ControlToValidate="dataTotalPrice" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataTotalPrice" runat="server" Display="Dynamic" ControlToValidate="dataTotalPrice" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBudgetPrice" runat="server" Text="Budget Price:" AssociatedControlID="dataBudgetPrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBudgetPrice" Text='<%# Bind("BudgetPrice") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataBudgetPrice" runat="server" Display="Dynamic" ControlToValidate="dataBudgetPrice" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataBudgetPrice" runat="server" Display="Dynamic" ControlToValidate="dataBudgetPrice" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOwnPrice" runat="server" Text="Own Price:" AssociatedControlID="dataOwnPrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOwnPrice" Text='<%# Bind("OwnPrice") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataOwnPrice" runat="server" Display="Dynamic" ControlToValidate="dataOwnPrice" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataOwnPrice" runat="server" Display="Dynamic" ControlToValidate="dataOwnPrice" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataVenturePrice" runat="server" Text="Venture Price:" AssociatedControlID="dataVenturePrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataVenturePrice" Text='<%# Bind("VenturePrice") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataVenturePrice" runat="server" Display="Dynamic" ControlToValidate="dataVenturePrice" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataVenturePrice" runat="server" Display="Dynamic" ControlToValidate="dataVenturePrice" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAnotherPrice" runat="server" Text="Another Price:" AssociatedControlID="dataAnotherPrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAnotherPrice" Text='<%# Bind("AnotherPrice") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAnotherPrice" runat="server" Display="Dynamic" ControlToValidate="dataAnotherPrice" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataAnotherPrice" runat="server" Display="Dynamic" ControlToValidate="dataAnotherPrice" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalDepreciation" runat="server" Text="Total Depreciation:" AssociatedControlID="dataTotalDepreciation" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalDepreciation" Text='<%# Bind("TotalDepreciation") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTotalDepreciation" runat="server" Display="Dynamic" ControlToValidate="dataTotalDepreciation" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataTotalDepreciation" runat="server" Display="Dynamic" ControlToValidate="dataTotalDepreciation" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBudgetDepreciation" runat="server" Text="Budget Depreciation:" AssociatedControlID="dataBudgetDepreciation" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBudgetDepreciation" Text='<%# Bind("BudgetDepreciation") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataBudgetDepreciation" runat="server" Display="Dynamic" ControlToValidate="dataBudgetDepreciation" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataBudgetDepreciation" runat="server" Display="Dynamic" ControlToValidate="dataBudgetDepreciation" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOwnDepreciation" runat="server" Text="Own Depreciation:" AssociatedControlID="dataOwnDepreciation" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOwnDepreciation" Text='<%# Bind("OwnDepreciation") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataOwnDepreciation" runat="server" Display="Dynamic" ControlToValidate="dataOwnDepreciation" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataOwnDepreciation" runat="server" Display="Dynamic" ControlToValidate="dataOwnDepreciation" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataVentureDepreciation" runat="server" Text="Venture Depreciation:" AssociatedControlID="dataVentureDepreciation" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataVentureDepreciation" Text='<%# Bind("VentureDepreciation") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataVentureDepreciation" runat="server" Display="Dynamic" ControlToValidate="dataVentureDepreciation" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataVentureDepreciation" runat="server" Display="Dynamic" ControlToValidate="dataVentureDepreciation" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAnotherDepreciation" runat="server" Text="Another Depreciation:" AssociatedControlID="dataAnotherDepreciation" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAnotherDepreciation" Text='<%# Bind("AnotherDepreciation") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAnotherDepreciation" runat="server" Display="Dynamic" ControlToValidate="dataAnotherDepreciation" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataAnotherDepreciation" runat="server" Display="Dynamic" ControlToValidate="dataAnotherDepreciation" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBudgetRemain" runat="server" Text="Budget Remain:" AssociatedControlID="dataBudgetRemain" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBudgetRemain" Text='<%# Bind("BudgetRemain") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataBudgetRemain" runat="server" Display="Dynamic" ControlToValidate="dataBudgetRemain" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataBudgetRemain" runat="server" Display="Dynamic" ControlToValidate="dataBudgetRemain" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOwnRemain" runat="server" Text="Own Remain:" AssociatedControlID="dataOwnRemain" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOwnRemain" Text='<%# Bind("OwnRemain") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataOwnRemain" runat="server" Display="Dynamic" ControlToValidate="dataOwnRemain" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataOwnRemain" runat="server" Display="Dynamic" ControlToValidate="dataOwnRemain" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataVentureRemain" runat="server" Text="Venture Remain:" AssociatedControlID="dataVentureRemain" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataVentureRemain" Text='<%# Bind("VentureRemain") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataVentureRemain" runat="server" Display="Dynamic" ControlToValidate="dataVentureRemain" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataVentureRemain" runat="server" Display="Dynamic" ControlToValidate="dataVentureRemain" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAnotherRemain" runat="server" Text="Another Remain:" AssociatedControlID="dataAnotherRemain" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAnotherRemain" Text='<%# Bind("AnotherRemain") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAnotherRemain" runat="server" Display="Dynamic" ControlToValidate="dataAnotherRemain" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataAnotherRemain" runat="server" Display="Dynamic" ControlToValidate="dataAnotherRemain" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalReamain" runat="server" Text="Total Reamain:" AssociatedControlID="dataTotalReamain" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalReamain" Text='<%# Bind("TotalReamain") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTotalReamain" runat="server" Display="Dynamic" ControlToValidate="dataTotalReamain" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataTotalReamain" runat="server" Display="Dynamic" ControlToValidate="dataTotalReamain" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpDownCode" runat="server" Text="Up Down Code:" AssociatedControlID="dataUpDownCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpDownCode" Text='<%# Bind("UpDownCode") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataInputDateTime" runat="server" Text="Input Date Time:" AssociatedControlID="dataInputDateTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataInputDateTime" Text='<%# Bind("InputDateTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataInputDateTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataInputDateTime" runat="server" Display="Dynamic" ControlToValidate="dataInputDateTime" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataManufacturer" runat="server" Text="Manufacturer:" AssociatedControlID="dataManufacturer" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataManufacturer" Text='<%# Bind("Manufacturer") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBrand" runat="server" Text="Brand:" AssociatedControlID="dataBrand" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBrand" Text='<%# Bind("Brand") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModel" runat="server" Text="Model:" AssociatedControlID="dataModel" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModel" Text='<%# Bind("Model") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStatus" runat="server" Text="Status:" AssociatedControlID="dataStatus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStatus" Text='<%# Bind("Status") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataStatus" runat="server" Display="Dynamic" ControlToValidate="dataStatus" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDueDate" runat="server" Text="Due Date:" AssociatedControlID="dataDueDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDueDate" Text='<%# Bind("DueDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDueDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNote" runat="server" Text="Note:" AssociatedControlID="dataNote" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNote" Text='<%# Bind("Note") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSeriesNumber" runat="server" Text="Series Number:" AssociatedControlID="dataSeriesNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSeriesNumber" Text='<%# Bind("SeriesNumber") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


