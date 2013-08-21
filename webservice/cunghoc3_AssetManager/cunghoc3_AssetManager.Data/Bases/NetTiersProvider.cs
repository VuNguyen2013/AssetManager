#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using cunghoc3_AssetManager.Entities;

#endregion

namespace cunghoc3_AssetManager.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current UnitProviderBase instance.
		///</summary>
		public virtual UnitProviderBase UnitProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DepartmentUsedProviderBase instance.
		///</summary>
		public virtual DepartmentUsedProviderBase DepartmentUsedProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PartnerProviderBase instance.
		///</summary>
		public virtual PartnerProviderBase PartnerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ImageProviderBase instance.
		///</summary>
		public virtual ImageProviderBase ImageProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AssetProviderBase instance.
		///</summary>
		public virtual AssetProviderBase AssetProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UpDownReasonProviderBase instance.
		///</summary>
		public virtual UpDownReasonProviderBase UpDownReasonProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RepairAssetProviderBase instance.
		///</summary>
		public virtual RepairAssetProviderBase RepairAssetProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CheckOutProviderBase instance.
		///</summary>
		public virtual CheckOutProviderBase CheckOutProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AssetGroupTypeProviderBase instance.
		///</summary>
		public virtual AssetGroupTypeProviderBase AssetGroupTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AssetGroupProviderBase instance.
		///</summary>
		public virtual AssetGroupProviderBase AssetGroupProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AssetLiquidationProviderBase instance.
		///</summary>
		public virtual AssetLiquidationProviderBase AssetLiquidationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AuditProviderBase instance.
		///</summary>
		public virtual AuditProviderBase AuditProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CapitalProviderBase instance.
		///</summary>
		public virtual CapitalProviderBase CapitalProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current WarrantyAssetProviderBase instance.
		///</summary>
		public virtual WarrantyAssetProviderBase WarrantyAssetProvider{get {throw new NotImplementedException();}}
		
		
	}
}
