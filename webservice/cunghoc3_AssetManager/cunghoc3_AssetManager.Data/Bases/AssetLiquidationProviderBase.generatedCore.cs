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
	/// This class is the base class for any <see cref="AssetLiquidationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AssetLiquidationProviderBaseCore : EntityProviderBase<cunghoc3_AssetManager.Entities.AssetLiquidation, cunghoc3_AssetManager.Entities.AssetLiquidationKey>
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
		public override bool Delete(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.AssetLiquidationKey key)
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
		/// 	Gets rows from the datasource based on the FK__AssetLiqu__Asset__31EC6D26 key.
		///		FK__AssetLiqu__Asset__31EC6D26 Description: 
		/// </summary>
		/// <param name="_assetId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.AssetLiquidation objects.</returns>
		public TList<AssetLiquidation> GetByAssetId(System.String _assetId)
		{
			int count = -1;
			return GetByAssetId(_assetId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__AssetLiqu__Asset__31EC6D26 key.
		///		FK__AssetLiqu__Asset__31EC6D26 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_assetId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.AssetLiquidation objects.</returns>
		/// <remarks></remarks>
		public TList<AssetLiquidation> GetByAssetId(TransactionManager transactionManager, System.String _assetId)
		{
			int count = -1;
			return GetByAssetId(transactionManager, _assetId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__AssetLiqu__Asset__31EC6D26 key.
		///		FK__AssetLiqu__Asset__31EC6D26 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_assetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.AssetLiquidation objects.</returns>
		public TList<AssetLiquidation> GetByAssetId(TransactionManager transactionManager, System.String _assetId, int start, int pageLength)
		{
			int count = -1;
			return GetByAssetId(transactionManager, _assetId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__AssetLiqu__Asset__31EC6D26 key.
		///		fkAssetLiquAsset31Ec6d26 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_assetId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.AssetLiquidation objects.</returns>
		public TList<AssetLiquidation> GetByAssetId(System.String _assetId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAssetId(null, _assetId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__AssetLiqu__Asset__31EC6D26 key.
		///		fkAssetLiquAsset31Ec6d26 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_assetId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.AssetLiquidation objects.</returns>
		public TList<AssetLiquidation> GetByAssetId(System.String _assetId, int start, int pageLength,out int count)
		{
			return GetByAssetId(null, _assetId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__AssetLiqu__Asset__31EC6D26 key.
		///		FK__AssetLiqu__Asset__31EC6D26 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_assetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.AssetLiquidation objects.</returns>
		public abstract TList<AssetLiquidation> GetByAssetId(TransactionManager transactionManager, System.String _assetId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__AssetLiqu__Depar__32E0915F key.
		///		FK__AssetLiqu__Depar__32E0915F Description: 
		/// </summary>
		/// <param name="_departmentUsedId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.AssetLiquidation objects.</returns>
		public TList<AssetLiquidation> GetByDepartmentUsedId(System.String _departmentUsedId)
		{
			int count = -1;
			return GetByDepartmentUsedId(_departmentUsedId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__AssetLiqu__Depar__32E0915F key.
		///		FK__AssetLiqu__Depar__32E0915F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentUsedId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.AssetLiquidation objects.</returns>
		/// <remarks></remarks>
		public TList<AssetLiquidation> GetByDepartmentUsedId(TransactionManager transactionManager, System.String _departmentUsedId)
		{
			int count = -1;
			return GetByDepartmentUsedId(transactionManager, _departmentUsedId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__AssetLiqu__Depar__32E0915F key.
		///		FK__AssetLiqu__Depar__32E0915F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentUsedId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.AssetLiquidation objects.</returns>
		public TList<AssetLiquidation> GetByDepartmentUsedId(TransactionManager transactionManager, System.String _departmentUsedId, int start, int pageLength)
		{
			int count = -1;
			return GetByDepartmentUsedId(transactionManager, _departmentUsedId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__AssetLiqu__Depar__32E0915F key.
		///		fkAssetLiquDepar32e0915f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_departmentUsedId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.AssetLiquidation objects.</returns>
		public TList<AssetLiquidation> GetByDepartmentUsedId(System.String _departmentUsedId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDepartmentUsedId(null, _departmentUsedId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__AssetLiqu__Depar__32E0915F key.
		///		fkAssetLiquDepar32e0915f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_departmentUsedId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.AssetLiquidation objects.</returns>
		public TList<AssetLiquidation> GetByDepartmentUsedId(System.String _departmentUsedId, int start, int pageLength,out int count)
		{
			return GetByDepartmentUsedId(null, _departmentUsedId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__AssetLiqu__Depar__32E0915F key.
		///		FK__AssetLiqu__Depar__32E0915F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentUsedId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.AssetLiquidation objects.</returns>
		public abstract TList<AssetLiquidation> GetByDepartmentUsedId(TransactionManager transactionManager, System.String _departmentUsedId, int start, int pageLength, out int count);
		
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
		public override cunghoc3_AssetManager.Entities.AssetLiquidation Get(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.AssetLiquidationKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__AssetLiq__3214EC07300424B4 index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.AssetLiquidation"/> class.</returns>
		public cunghoc3_AssetManager.Entities.AssetLiquidation GetById(System.String _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AssetLiq__3214EC07300424B4 index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.AssetLiquidation"/> class.</returns>
		public cunghoc3_AssetManager.Entities.AssetLiquidation GetById(System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AssetLiq__3214EC07300424B4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.AssetLiquidation"/> class.</returns>
		public cunghoc3_AssetManager.Entities.AssetLiquidation GetById(TransactionManager transactionManager, System.String _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AssetLiq__3214EC07300424B4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.AssetLiquidation"/> class.</returns>
		public cunghoc3_AssetManager.Entities.AssetLiquidation GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AssetLiq__3214EC07300424B4 index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.AssetLiquidation"/> class.</returns>
		public cunghoc3_AssetManager.Entities.AssetLiquidation GetById(System.String _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AssetLiq__3214EC07300424B4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.AssetLiquidation"/> class.</returns>
		public abstract cunghoc3_AssetManager.Entities.AssetLiquidation GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AssetLiquidation&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AssetLiquidation&gt;"/></returns>
		public static TList<AssetLiquidation> Fill(IDataReader reader, TList<AssetLiquidation> rows, int start, int pageLength)
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
				
				cunghoc3_AssetManager.Entities.AssetLiquidation c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AssetLiquidation")
					.Append("|").Append((System.String)reader[((int)AssetLiquidationColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AssetLiquidation>(
					key.ToString(), // EntityTrackingKey
					"AssetLiquidation",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new cunghoc3_AssetManager.Entities.AssetLiquidation();
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
					c.Id = (System.String)reader[((int)AssetLiquidationColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.AssetId = (reader.IsDBNull(((int)AssetLiquidationColumn.AssetId - 1)))?null:(System.String)reader[((int)AssetLiquidationColumn.AssetId - 1)];
					c.Amount = (System.Int32)reader[((int)AssetLiquidationColumn.Amount - 1)];
					c.DepartmentUsedId = (reader.IsDBNull(((int)AssetLiquidationColumn.DepartmentUsedId - 1)))?null:(System.String)reader[((int)AssetLiquidationColumn.DepartmentUsedId - 1)];
					c.LiDateTime = (System.DateTime)reader[((int)AssetLiquidationColumn.LiDateTime - 1)];
					c.LiPrice = (System.Int64)reader[((int)AssetLiquidationColumn.LiPrice - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="cunghoc3_AssetManager.Entities.AssetLiquidation"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.AssetLiquidation"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, cunghoc3_AssetManager.Entities.AssetLiquidation entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.String)reader[((int)AssetLiquidationColumn.Id - 1)];
			entity.OriginalId = (System.String)reader["Id"];
			entity.AssetId = (reader.IsDBNull(((int)AssetLiquidationColumn.AssetId - 1)))?null:(System.String)reader[((int)AssetLiquidationColumn.AssetId - 1)];
			entity.Amount = (System.Int32)reader[((int)AssetLiquidationColumn.Amount - 1)];
			entity.DepartmentUsedId = (reader.IsDBNull(((int)AssetLiquidationColumn.DepartmentUsedId - 1)))?null:(System.String)reader[((int)AssetLiquidationColumn.DepartmentUsedId - 1)];
			entity.LiDateTime = (System.DateTime)reader[((int)AssetLiquidationColumn.LiDateTime - 1)];
			entity.LiPrice = (System.Int64)reader[((int)AssetLiquidationColumn.LiPrice - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="cunghoc3_AssetManager.Entities.AssetLiquidation"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.AssetLiquidation"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, cunghoc3_AssetManager.Entities.AssetLiquidation entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.String)dataRow["Id"];
			entity.OriginalId = (System.String)dataRow["Id"];
			entity.AssetId = Convert.IsDBNull(dataRow["AssetId"]) ? null : (System.String)dataRow["AssetId"];
			entity.Amount = (System.Int32)dataRow["Amount"];
			entity.DepartmentUsedId = Convert.IsDBNull(dataRow["DepartmentUsedId"]) ? null : (System.String)dataRow["DepartmentUsedId"];
			entity.LiDateTime = (System.DateTime)dataRow["LiDateTime"];
			entity.LiPrice = (System.Int64)dataRow["LiPrice"];
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
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.AssetLiquidation"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">cunghoc3_AssetManager.Entities.AssetLiquidation Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.AssetLiquidation entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AssetIdSource	
			if (CanDeepLoad(entity, "Asset|AssetIdSource", deepLoadType, innerList) 
				&& entity.AssetIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AssetId ?? string.Empty);
				Asset tmpEntity = EntityManager.LocateEntity<Asset>(EntityLocator.ConstructKeyFromPkItems(typeof(Asset), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AssetIdSource = tmpEntity;
				else
					entity.AssetIdSource = DataRepository.AssetProvider.GetById(transactionManager, (entity.AssetId ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AssetIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AssetIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AssetProvider.DeepLoad(transactionManager, entity.AssetIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AssetIdSource

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
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the cunghoc3_AssetManager.Entities.AssetLiquidation object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">cunghoc3_AssetManager.Entities.AssetLiquidation instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">cunghoc3_AssetManager.Entities.AssetLiquidation Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.AssetLiquidation entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AssetIdSource
			if (CanDeepSave(entity, "Asset|AssetIdSource", deepSaveType, innerList) 
				&& entity.AssetIdSource != null)
			{
				DataRepository.AssetProvider.Save(transactionManager, entity.AssetIdSource);
				entity.AssetId = entity.AssetIdSource.Id;
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
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
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
	
	#region AssetLiquidationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>cunghoc3_AssetManager.Entities.AssetLiquidation</c>
	///</summary>
	public enum AssetLiquidationChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Asset</c> at AssetIdSource
		///</summary>
		[ChildEntityType(typeof(Asset))]
		Asset,
		
		///<summary>
		/// Composite Property for <c>DepartmentUsed</c> at DepartmentUsedIdSource
		///</summary>
		[ChildEntityType(typeof(DepartmentUsed))]
		DepartmentUsed,
	}
	
	#endregion AssetLiquidationChildEntityTypes
	
	#region AssetLiquidationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AssetLiquidationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AssetLiquidation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetLiquidationFilterBuilder : SqlFilterBuilder<AssetLiquidationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationFilterBuilder class.
		/// </summary>
		public AssetLiquidationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AssetLiquidationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AssetLiquidationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AssetLiquidationFilterBuilder
	
	#region AssetLiquidationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AssetLiquidationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AssetLiquidation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetLiquidationParameterBuilder : ParameterizedSqlFilterBuilder<AssetLiquidationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationParameterBuilder class.
		/// </summary>
		public AssetLiquidationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AssetLiquidationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AssetLiquidationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AssetLiquidationParameterBuilder
	
	#region AssetLiquidationSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AssetLiquidationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AssetLiquidation"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AssetLiquidationSortBuilder : SqlSortBuilder<AssetLiquidationColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationSqlSortBuilder class.
		/// </summary>
		public AssetLiquidationSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AssetLiquidationSortBuilder
	
} // end namespace
