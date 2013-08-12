#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using cunghoc3_AssetManager.Entities;
using cunghoc3_AssetManager.Data;

#endregion

namespace cunghoc3_AssetManager.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="AssetProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AssetProviderBaseCore : EntityProviderBase<cunghoc3_AssetManager.Entities.Asset, cunghoc3_AssetManager.Entities.AssetKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.AssetKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _id)
		{
			return Delete(null, _id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _id);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__AssetGrou__15502E78 key.
		///		FK__Asset__AssetGrou__15502E78 Description: 
		/// </summary>
		/// <param name="_assetGroupId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public TList<Asset> GetByAssetGroupId(System.String _assetGroupId)
		{
			int count = -1;
			return GetByAssetGroupId(_assetGroupId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__AssetGrou__15502E78 key.
		///		FK__Asset__AssetGrou__15502E78 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_assetGroupId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		/// <remarks></remarks>
		public TList<Asset> GetByAssetGroupId(TransactionManager transactionManager, System.String _assetGroupId)
		{
			int count = -1;
			return GetByAssetGroupId(transactionManager, _assetGroupId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__AssetGrou__15502E78 key.
		///		FK__Asset__AssetGrou__15502E78 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_assetGroupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public TList<Asset> GetByAssetGroupId(TransactionManager transactionManager, System.String _assetGroupId, int start, int pageLength)
		{
			int count = -1;
			return GetByAssetGroupId(transactionManager, _assetGroupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__AssetGrou__15502E78 key.
		///		fkAssetAssetGrou15502e78 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_assetGroupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public TList<Asset> GetByAssetGroupId(System.String _assetGroupId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAssetGroupId(null, _assetGroupId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__AssetGrou__15502E78 key.
		///		fkAssetAssetGrou15502e78 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_assetGroupId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public TList<Asset> GetByAssetGroupId(System.String _assetGroupId, int start, int pageLength,out int count)
		{
			return GetByAssetGroupId(null, _assetGroupId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__AssetGrou__15502E78 key.
		///		FK__Asset__AssetGrou__15502E78 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_assetGroupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public abstract TList<Asset> GetByAssetGroupId(TransactionManager transactionManager, System.String _assetGroupId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__Departmen__173876EA key.
		///		FK__Asset__Departmen__173876EA Description: 
		/// </summary>
		/// <param name="_departmentUsedId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public TList<Asset> GetByDepartmentUsedId(System.String _departmentUsedId)
		{
			int count = -1;
			return GetByDepartmentUsedId(_departmentUsedId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__Departmen__173876EA key.
		///		FK__Asset__Departmen__173876EA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentUsedId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		/// <remarks></remarks>
		public TList<Asset> GetByDepartmentUsedId(TransactionManager transactionManager, System.String _departmentUsedId)
		{
			int count = -1;
			return GetByDepartmentUsedId(transactionManager, _departmentUsedId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__Departmen__173876EA key.
		///		FK__Asset__Departmen__173876EA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentUsedId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public TList<Asset> GetByDepartmentUsedId(TransactionManager transactionManager, System.String _departmentUsedId, int start, int pageLength)
		{
			int count = -1;
			return GetByDepartmentUsedId(transactionManager, _departmentUsedId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__Departmen__173876EA key.
		///		fkAssetDepartmen173876Ea Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_departmentUsedId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public TList<Asset> GetByDepartmentUsedId(System.String _departmentUsedId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDepartmentUsedId(null, _departmentUsedId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__Departmen__173876EA key.
		///		fkAssetDepartmen173876Ea Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_departmentUsedId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public TList<Asset> GetByDepartmentUsedId(System.String _departmentUsedId, int start, int pageLength,out int count)
		{
			return GetByDepartmentUsedId(null, _departmentUsedId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__Departmen__173876EA key.
		///		FK__Asset__Departmen__173876EA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentUsedId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public abstract TList<Asset> GetByDepartmentUsedId(TransactionManager transactionManager, System.String _departmentUsedId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__UnitId__164452B1 key.
		///		FK__Asset__UnitId__164452B1 Description: 
		/// </summary>
		/// <param name="_unitId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public TList<Asset> GetByUnitId(System.String _unitId)
		{
			int count = -1;
			return GetByUnitId(_unitId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__UnitId__164452B1 key.
		///		FK__Asset__UnitId__164452B1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		/// <remarks></remarks>
		public TList<Asset> GetByUnitId(TransactionManager transactionManager, System.String _unitId)
		{
			int count = -1;
			return GetByUnitId(transactionManager, _unitId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__UnitId__164452B1 key.
		///		FK__Asset__UnitId__164452B1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public TList<Asset> GetByUnitId(TransactionManager transactionManager, System.String _unitId, int start, int pageLength)
		{
			int count = -1;
			return GetByUnitId(transactionManager, _unitId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__UnitId__164452B1 key.
		///		fkAssetUnitId164452b1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_unitId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public TList<Asset> GetByUnitId(System.String _unitId, int start, int pageLength)
		{
			int count =  -1;
			return GetByUnitId(null, _unitId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__UnitId__164452B1 key.
		///		fkAssetUnitId164452b1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_unitId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public TList<Asset> GetByUnitId(System.String _unitId, int start, int pageLength,out int count)
		{
			return GetByUnitId(null, _unitId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Asset__UnitId__164452B1 key.
		///		FK__Asset__UnitId__164452B1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.Asset objects.</returns>
		public abstract TList<Asset> GetByUnitId(TransactionManager transactionManager, System.String _unitId, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override cunghoc3_AssetManager.Entities.Asset Get(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.AssetKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Asset__3214EC071367E606 index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Asset"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Asset GetById(System.String _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Asset__3214EC071367E606 index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Asset"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Asset GetById(System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Asset__3214EC071367E606 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Asset"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Asset GetById(TransactionManager transactionManager, System.String _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Asset__3214EC071367E606 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Asset"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Asset GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Asset__3214EC071367E606 index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Asset"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Asset GetById(System.String _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Asset__3214EC071367E606 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Asset"/> class.</returns>
		public abstract cunghoc3_AssetManager.Entities.Asset GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Asset&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Asset&gt;"/></returns>
		public static TList<Asset> Fill(IDataReader reader, TList<Asset> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				cunghoc3_AssetManager.Entities.Asset c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Asset")
					.Append("|").Append((System.String)reader[((int)AssetColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Asset>(
					key.ToString(), // EntityTrackingKey
					"Asset",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new cunghoc3_AssetManager.Entities.Asset();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.Id = (System.String)reader[((int)AssetColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.Name = (System.String)reader[((int)AssetColumn.Name - 1)];
					c.AssetGroupId = (reader.IsDBNull(((int)AssetColumn.AssetGroupId - 1)))?null:(System.String)reader[((int)AssetColumn.AssetGroupId - 1)];
					c.UnitId = (reader.IsDBNull(((int)AssetColumn.UnitId - 1)))?null:(System.String)reader[((int)AssetColumn.UnitId - 1)];
					c.Amount = (System.Int32)reader[((int)AssetColumn.Amount - 1)];
					c.CounPro = (System.String)reader[((int)AssetColumn.CounPro - 1)];
					c.YearPro = (System.Int32)reader[((int)AssetColumn.YearPro - 1)];
					c.DepartmentUsedId = (reader.IsDBNull(((int)AssetColumn.DepartmentUsedId - 1)))?null:(System.String)reader[((int)AssetColumn.DepartmentUsedId - 1)];
					c.TotalPrice = (System.Int64)reader[((int)AssetColumn.TotalPrice - 1)];
					c.BudgetPrice = (System.Int64)reader[((int)AssetColumn.BudgetPrice - 1)];
					c.OwnPrice = (System.Int64)reader[((int)AssetColumn.OwnPrice - 1)];
					c.VenturePrice = (System.Int64)reader[((int)AssetColumn.VenturePrice - 1)];
					c.AnotherPrice = (System.Int64)reader[((int)AssetColumn.AnotherPrice - 1)];
					c.TotalDepreciation = (System.Int64)reader[((int)AssetColumn.TotalDepreciation - 1)];
					c.BudgetDepreciation = (System.Int64)reader[((int)AssetColumn.BudgetDepreciation - 1)];
					c.OwnDepreciation = (System.Int64)reader[((int)AssetColumn.OwnDepreciation - 1)];
					c.VentureDepreciation = (System.Int64)reader[((int)AssetColumn.VentureDepreciation - 1)];
					c.AnotherDepreciation = (System.Int64)reader[((int)AssetColumn.AnotherDepreciation - 1)];
					c.BudgetRemain = (System.Int64)reader[((int)AssetColumn.BudgetRemain - 1)];
					c.OwnRemain = (System.Int64)reader[((int)AssetColumn.OwnRemain - 1)];
					c.VentureRemain = (System.Int64)reader[((int)AssetColumn.VentureRemain - 1)];
					c.AnotherRemain = (System.Int64)reader[((int)AssetColumn.AnotherRemain - 1)];
					c.TotalReamain = (System.Int64)reader[((int)AssetColumn.TotalReamain - 1)];
					c.UpDownCode = (reader.IsDBNull(((int)AssetColumn.UpDownCode - 1)))?null:(System.String)reader[((int)AssetColumn.UpDownCode - 1)];
					c.InputDateTime = (System.DateTime)reader[((int)AssetColumn.InputDateTime - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="cunghoc3_AssetManager.Entities.Asset"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.Asset"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, cunghoc3_AssetManager.Entities.Asset entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.String)reader[((int)AssetColumn.Id - 1)];
			entity.OriginalId = (System.String)reader["Id"];
			entity.Name = (System.String)reader[((int)AssetColumn.Name - 1)];
			entity.AssetGroupId = (reader.IsDBNull(((int)AssetColumn.AssetGroupId - 1)))?null:(System.String)reader[((int)AssetColumn.AssetGroupId - 1)];
			entity.UnitId = (reader.IsDBNull(((int)AssetColumn.UnitId - 1)))?null:(System.String)reader[((int)AssetColumn.UnitId - 1)];
			entity.Amount = (System.Int32)reader[((int)AssetColumn.Amount - 1)];
			entity.CounPro = (System.String)reader[((int)AssetColumn.CounPro - 1)];
			entity.YearPro = (System.Int32)reader[((int)AssetColumn.YearPro - 1)];
			entity.DepartmentUsedId = (reader.IsDBNull(((int)AssetColumn.DepartmentUsedId - 1)))?null:(System.String)reader[((int)AssetColumn.DepartmentUsedId - 1)];
			entity.TotalPrice = (System.Int64)reader[((int)AssetColumn.TotalPrice - 1)];
			entity.BudgetPrice = (System.Int64)reader[((int)AssetColumn.BudgetPrice - 1)];
			entity.OwnPrice = (System.Int64)reader[((int)AssetColumn.OwnPrice - 1)];
			entity.VenturePrice = (System.Int64)reader[((int)AssetColumn.VenturePrice - 1)];
			entity.AnotherPrice = (System.Int64)reader[((int)AssetColumn.AnotherPrice - 1)];
			entity.TotalDepreciation = (System.Int64)reader[((int)AssetColumn.TotalDepreciation - 1)];
			entity.BudgetDepreciation = (System.Int64)reader[((int)AssetColumn.BudgetDepreciation - 1)];
			entity.OwnDepreciation = (System.Int64)reader[((int)AssetColumn.OwnDepreciation - 1)];
			entity.VentureDepreciation = (System.Int64)reader[((int)AssetColumn.VentureDepreciation - 1)];
			entity.AnotherDepreciation = (System.Int64)reader[((int)AssetColumn.AnotherDepreciation - 1)];
			entity.BudgetRemain = (System.Int64)reader[((int)AssetColumn.BudgetRemain - 1)];
			entity.OwnRemain = (System.Int64)reader[((int)AssetColumn.OwnRemain - 1)];
			entity.VentureRemain = (System.Int64)reader[((int)AssetColumn.VentureRemain - 1)];
			entity.AnotherRemain = (System.Int64)reader[((int)AssetColumn.AnotherRemain - 1)];
			entity.TotalReamain = (System.Int64)reader[((int)AssetColumn.TotalReamain - 1)];
			entity.UpDownCode = (reader.IsDBNull(((int)AssetColumn.UpDownCode - 1)))?null:(System.String)reader[((int)AssetColumn.UpDownCode - 1)];
			entity.InputDateTime = (System.DateTime)reader[((int)AssetColumn.InputDateTime - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="cunghoc3_AssetManager.Entities.Asset"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.Asset"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, cunghoc3_AssetManager.Entities.Asset entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.String)dataRow["Id"];
			entity.OriginalId = (System.String)dataRow["Id"];
			entity.Name = (System.String)dataRow["Name"];
			entity.AssetGroupId = Convert.IsDBNull(dataRow["AssetGroupId"]) ? null : (System.String)dataRow["AssetGroupId"];
			entity.UnitId = Convert.IsDBNull(dataRow["UnitId"]) ? null : (System.String)dataRow["UnitId"];
			entity.Amount = (System.Int32)dataRow["Amount"];
			entity.CounPro = (System.String)dataRow["CounPro"];
			entity.YearPro = (System.Int32)dataRow["YearPro"];
			entity.DepartmentUsedId = Convert.IsDBNull(dataRow["DepartmentUsedId"]) ? null : (System.String)dataRow["DepartmentUsedId"];
			entity.TotalPrice = (System.Int64)dataRow["TotalPrice"];
			entity.BudgetPrice = (System.Int64)dataRow["BudgetPrice"];
			entity.OwnPrice = (System.Int64)dataRow["OwnPrice"];
			entity.VenturePrice = (System.Int64)dataRow["VenturePrice"];
			entity.AnotherPrice = (System.Int64)dataRow["AnotherPrice"];
			entity.TotalDepreciation = (System.Int64)dataRow["TotalDepreciation"];
			entity.BudgetDepreciation = (System.Int64)dataRow["BudgetDepreciation"];
			entity.OwnDepreciation = (System.Int64)dataRow["OwnDepreciation"];
			entity.VentureDepreciation = (System.Int64)dataRow["VentureDepreciation"];
			entity.AnotherDepreciation = (System.Int64)dataRow["AnotherDepreciation"];
			entity.BudgetRemain = (System.Int64)dataRow["BudgetRemain"];
			entity.OwnRemain = (System.Int64)dataRow["OwnRemain"];
			entity.VentureRemain = (System.Int64)dataRow["VentureRemain"];
			entity.AnotherRemain = (System.Int64)dataRow["AnotherRemain"];
			entity.TotalReamain = (System.Int64)dataRow["TotalReamain"];
			entity.UpDownCode = Convert.IsDBNull(dataRow["UpDownCode"]) ? null : (System.String)dataRow["UpDownCode"];
			entity.InputDateTime = (System.DateTime)dataRow["InputDateTime"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.Asset"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">cunghoc3_AssetManager.Entities.Asset Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.Asset entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AssetGroupIdSource	
			if (CanDeepLoad(entity, "AssetGroup|AssetGroupIdSource", deepLoadType, innerList) 
				&& entity.AssetGroupIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AssetGroupId ?? string.Empty);
				AssetGroup tmpEntity = EntityManager.LocateEntity<AssetGroup>(EntityLocator.ConstructKeyFromPkItems(typeof(AssetGroup), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AssetGroupIdSource = tmpEntity;
				else
					entity.AssetGroupIdSource = DataRepository.AssetGroupProvider.GetById(transactionManager, (entity.AssetGroupId ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AssetGroupIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AssetGroupIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AssetGroupProvider.DeepLoad(transactionManager, entity.AssetGroupIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AssetGroupIdSource

			#region DepartmentUsedIdSource	
			if (CanDeepLoad(entity, "DepartmentUsed|DepartmentUsedIdSource", deepLoadType, innerList) 
				&& entity.DepartmentUsedIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DepartmentUsedId ?? string.Empty);
				DepartmentUsed tmpEntity = EntityManager.LocateEntity<DepartmentUsed>(EntityLocator.ConstructKeyFromPkItems(typeof(DepartmentUsed), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DepartmentUsedIdSource = tmpEntity;
				else
					entity.DepartmentUsedIdSource = DataRepository.DepartmentUsedProvider.GetById(transactionManager, (entity.DepartmentUsedId ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DepartmentUsedIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DepartmentUsedIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DepartmentUsedProvider.DeepLoad(transactionManager, entity.DepartmentUsedIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DepartmentUsedIdSource

			#region UnitIdSource	
			if (CanDeepLoad(entity, "Unit|UnitIdSource", deepLoadType, innerList) 
				&& entity.UnitIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.UnitId ?? string.Empty);
				Unit tmpEntity = EntityManager.LocateEntity<Unit>(EntityLocator.ConstructKeyFromPkItems(typeof(Unit), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UnitIdSource = tmpEntity;
				else
					entity.UnitIdSource = DataRepository.UnitProvider.GetById(transactionManager, (entity.UnitId ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UnitIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UnitIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UnitProvider.DeepLoad(transactionManager, entity.UnitIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion UnitIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region WarrantyAssetCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<WarrantyAsset>|WarrantyAssetCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WarrantyAssetCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.WarrantyAssetCollection = DataRepository.WarrantyAssetProvider.GetByAsssetId(transactionManager, entity.Id);

				if (deep && entity.WarrantyAssetCollection.Count > 0)
				{
					deepHandles.Add("WarrantyAssetCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<WarrantyAsset>) DataRepository.WarrantyAssetProvider.DeepLoad,
						new object[] { transactionManager, entity.WarrantyAssetCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AssetLiquidationCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AssetLiquidation>|AssetLiquidationCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AssetLiquidationCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AssetLiquidationCollection = DataRepository.AssetLiquidationProvider.GetByAssetId(transactionManager, entity.Id);

				if (deep && entity.AssetLiquidationCollection.Count > 0)
				{
					deepHandles.Add("AssetLiquidationCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AssetLiquidation>) DataRepository.AssetLiquidationProvider.DeepLoad,
						new object[] { transactionManager, entity.AssetLiquidationCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region RepairAssetCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RepairAsset>|RepairAssetCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RepairAssetCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.RepairAssetCollection = DataRepository.RepairAssetProvider.GetByAssetId(transactionManager, entity.Id);

				if (deep && entity.RepairAssetCollection.Count > 0)
				{
					deepHandles.Add("RepairAssetCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<RepairAsset>) DataRepository.RepairAssetProvider.DeepLoad,
						new object[] { transactionManager, entity.RepairAssetCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the cunghoc3_AssetManager.Entities.Asset object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">cunghoc3_AssetManager.Entities.Asset instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">cunghoc3_AssetManager.Entities.Asset Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.Asset entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AssetGroupIdSource
			if (CanDeepSave(entity, "AssetGroup|AssetGroupIdSource", deepSaveType, innerList) 
				&& entity.AssetGroupIdSource != null)
			{
				DataRepository.AssetGroupProvider.Save(transactionManager, entity.AssetGroupIdSource);
				entity.AssetGroupId = entity.AssetGroupIdSource.Id;
			}
			#endregion 
			
			#region DepartmentUsedIdSource
			if (CanDeepSave(entity, "DepartmentUsed|DepartmentUsedIdSource", deepSaveType, innerList) 
				&& entity.DepartmentUsedIdSource != null)
			{
				DataRepository.DepartmentUsedProvider.Save(transactionManager, entity.DepartmentUsedIdSource);
				entity.DepartmentUsedId = entity.DepartmentUsedIdSource.Id;
			}
			#endregion 
			
			#region UnitIdSource
			if (CanDeepSave(entity, "Unit|UnitIdSource", deepSaveType, innerList) 
				&& entity.UnitIdSource != null)
			{
				DataRepository.UnitProvider.Save(transactionManager, entity.UnitIdSource);
				entity.UnitId = entity.UnitIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<WarrantyAsset>
				if (CanDeepSave(entity.WarrantyAssetCollection, "List<WarrantyAsset>|WarrantyAssetCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(WarrantyAsset child in entity.WarrantyAssetCollection)
					{
						if(child.AsssetIdSource != null)
						{
							child.AsssetId = child.AsssetIdSource.Id;
						}
						else
						{
							child.AsssetId = entity.Id;
						}

					}

					if (entity.WarrantyAssetCollection.Count > 0 || entity.WarrantyAssetCollection.DeletedItems.Count > 0)
					{
						//DataRepository.WarrantyAssetProvider.Save(transactionManager, entity.WarrantyAssetCollection);
						
						deepHandles.Add("WarrantyAssetCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< WarrantyAsset >) DataRepository.WarrantyAssetProvider.DeepSave,
							new object[] { transactionManager, entity.WarrantyAssetCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<AssetLiquidation>
				if (CanDeepSave(entity.AssetLiquidationCollection, "List<AssetLiquidation>|AssetLiquidationCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AssetLiquidation child in entity.AssetLiquidationCollection)
					{
						if(child.AssetIdSource != null)
						{
							child.AssetId = child.AssetIdSource.Id;
						}
						else
						{
							child.AssetId = entity.Id;
						}

					}

					if (entity.AssetLiquidationCollection.Count > 0 || entity.AssetLiquidationCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AssetLiquidationProvider.Save(transactionManager, entity.AssetLiquidationCollection);
						
						deepHandles.Add("AssetLiquidationCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AssetLiquidation >) DataRepository.AssetLiquidationProvider.DeepSave,
							new object[] { transactionManager, entity.AssetLiquidationCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<RepairAsset>
				if (CanDeepSave(entity.RepairAssetCollection, "List<RepairAsset>|RepairAssetCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RepairAsset child in entity.RepairAssetCollection)
					{
						if(child.AssetIdSource != null)
						{
							child.AssetId = child.AssetIdSource.Id;
						}
						else
						{
							child.AssetId = entity.Id;
						}

					}

					if (entity.RepairAssetCollection.Count > 0 || entity.RepairAssetCollection.DeletedItems.Count > 0)
					{
						//DataRepository.RepairAssetProvider.Save(transactionManager, entity.RepairAssetCollection);
						
						deepHandles.Add("RepairAssetCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< RepairAsset >) DataRepository.RepairAssetProvider.DeepSave,
							new object[] { transactionManager, entity.RepairAssetCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region AssetChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>cunghoc3_AssetManager.Entities.Asset</c>
	///</summary>
	public enum AssetChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AssetGroup</c> at AssetGroupIdSource
		///</summary>
		[ChildEntityType(typeof(AssetGroup))]
		AssetGroup,
		
		///<summary>
		/// Composite Property for <c>DepartmentUsed</c> at DepartmentUsedIdSource
		///</summary>
		[ChildEntityType(typeof(DepartmentUsed))]
		DepartmentUsed,
		
		///<summary>
		/// Composite Property for <c>Unit</c> at UnitIdSource
		///</summary>
		[ChildEntityType(typeof(Unit))]
		Unit,
		///<summary>
		/// Collection of <c>Asset</c> as OneToMany for WarrantyAssetCollection
		///</summary>
		[ChildEntityType(typeof(TList<WarrantyAsset>))]
		WarrantyAssetCollection,
		///<summary>
		/// Collection of <c>Asset</c> as OneToMany for AssetLiquidationCollection
		///</summary>
		[ChildEntityType(typeof(TList<AssetLiquidation>))]
		AssetLiquidationCollection,
		///<summary>
		/// Collection of <c>Asset</c> as OneToMany for RepairAssetCollection
		///</summary>
		[ChildEntityType(typeof(TList<RepairAsset>))]
		RepairAssetCollection,
	}
	
	#endregion AssetChildEntityTypes
	
	#region AssetFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AssetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Asset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetFilterBuilder : SqlFilterBuilder<AssetColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetFilterBuilder class.
		/// </summary>
		public AssetFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AssetFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AssetFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AssetFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AssetFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AssetFilterBuilder
	
	#region AssetParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AssetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Asset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetParameterBuilder : ParameterizedSqlFilterBuilder<AssetColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetParameterBuilder class.
		/// </summary>
		public AssetParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AssetParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AssetParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AssetParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AssetParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AssetParameterBuilder
	
	#region AssetSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AssetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Asset"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AssetSortBuilder : SqlSortBuilder<AssetColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetSqlSortBuilder class.
		/// </summary>
		public AssetSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AssetSortBuilder
	
} // end namespace
