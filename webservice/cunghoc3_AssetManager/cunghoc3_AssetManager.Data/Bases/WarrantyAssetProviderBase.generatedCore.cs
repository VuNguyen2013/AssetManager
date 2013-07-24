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
	/// This class is the base class for any <see cref="WarrantyAssetProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class WarrantyAssetProviderBaseCore : EntityProviderBase<cunghoc3_AssetManager.Entities.WarrantyAsset, cunghoc3_AssetManager.Entities.WarrantyAssetKey>
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
		public override bool Delete(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.WarrantyAssetKey key)
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
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Assse__4222D4EF key.
		///		FK__WarrantyA__Assse__4222D4EF Description: 
		/// </summary>
		/// <param name="_asssetId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public TList<WarrantyAsset> GetByAsssetId(System.String _asssetId)
		{
			int count = -1;
			return GetByAsssetId(_asssetId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Assse__4222D4EF key.
		///		FK__WarrantyA__Assse__4222D4EF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_asssetId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		/// <remarks></remarks>
		public TList<WarrantyAsset> GetByAsssetId(TransactionManager transactionManager, System.String _asssetId)
		{
			int count = -1;
			return GetByAsssetId(transactionManager, _asssetId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Assse__4222D4EF key.
		///		FK__WarrantyA__Assse__4222D4EF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_asssetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public TList<WarrantyAsset> GetByAsssetId(TransactionManager transactionManager, System.String _asssetId, int start, int pageLength)
		{
			int count = -1;
			return GetByAsssetId(transactionManager, _asssetId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Assse__4222D4EF key.
		///		fkWarrantyaAssse4222d4Ef Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_asssetId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public TList<WarrantyAsset> GetByAsssetId(System.String _asssetId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAsssetId(null, _asssetId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Assse__4222D4EF key.
		///		fkWarrantyaAssse4222d4Ef Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_asssetId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public TList<WarrantyAsset> GetByAsssetId(System.String _asssetId, int start, int pageLength,out int count)
		{
			return GetByAsssetId(null, _asssetId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Assse__4222D4EF key.
		///		FK__WarrantyA__Assse__4222D4EF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_asssetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public abstract TList<WarrantyAsset> GetByAsssetId(TransactionManager transactionManager, System.String _asssetId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Depar__4316F928 key.
		///		FK__WarrantyA__Depar__4316F928 Description: 
		/// </summary>
		/// <param name="_departmentUsedId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public TList<WarrantyAsset> GetByDepartmentUsedId(System.String _departmentUsedId)
		{
			int count = -1;
			return GetByDepartmentUsedId(_departmentUsedId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Depar__4316F928 key.
		///		FK__WarrantyA__Depar__4316F928 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentUsedId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		/// <remarks></remarks>
		public TList<WarrantyAsset> GetByDepartmentUsedId(TransactionManager transactionManager, System.String _departmentUsedId)
		{
			int count = -1;
			return GetByDepartmentUsedId(transactionManager, _departmentUsedId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Depar__4316F928 key.
		///		FK__WarrantyA__Depar__4316F928 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentUsedId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public TList<WarrantyAsset> GetByDepartmentUsedId(TransactionManager transactionManager, System.String _departmentUsedId, int start, int pageLength)
		{
			int count = -1;
			return GetByDepartmentUsedId(transactionManager, _departmentUsedId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Depar__4316F928 key.
		///		fkWarrantyaDepar4316f928 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_departmentUsedId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public TList<WarrantyAsset> GetByDepartmentUsedId(System.String _departmentUsedId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDepartmentUsedId(null, _departmentUsedId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Depar__4316F928 key.
		///		fkWarrantyaDepar4316f928 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_departmentUsedId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public TList<WarrantyAsset> GetByDepartmentUsedId(System.String _departmentUsedId, int start, int pageLength,out int count)
		{
			return GetByDepartmentUsedId(null, _departmentUsedId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Depar__4316F928 key.
		///		FK__WarrantyA__Depar__4316F928 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentUsedId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public abstract TList<WarrantyAsset> GetByDepartmentUsedId(TransactionManager transactionManager, System.String _departmentUsedId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Partn__440B1D61 key.
		///		FK__WarrantyA__Partn__440B1D61 Description: 
		/// </summary>
		/// <param name="_partnerId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public TList<WarrantyAsset> GetByPartnerId(System.String _partnerId)
		{
			int count = -1;
			return GetByPartnerId(_partnerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Partn__440B1D61 key.
		///		FK__WarrantyA__Partn__440B1D61 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_partnerId"></param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		/// <remarks></remarks>
		public TList<WarrantyAsset> GetByPartnerId(TransactionManager transactionManager, System.String _partnerId)
		{
			int count = -1;
			return GetByPartnerId(transactionManager, _partnerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Partn__440B1D61 key.
		///		FK__WarrantyA__Partn__440B1D61 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_partnerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public TList<WarrantyAsset> GetByPartnerId(TransactionManager transactionManager, System.String _partnerId, int start, int pageLength)
		{
			int count = -1;
			return GetByPartnerId(transactionManager, _partnerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Partn__440B1D61 key.
		///		fkWarrantyaPartn440b1d61 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_partnerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public TList<WarrantyAsset> GetByPartnerId(System.String _partnerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByPartnerId(null, _partnerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Partn__440B1D61 key.
		///		fkWarrantyaPartn440b1d61 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_partnerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public TList<WarrantyAsset> GetByPartnerId(System.String _partnerId, int start, int pageLength,out int count)
		{
			return GetByPartnerId(null, _partnerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WarrantyA__Partn__440B1D61 key.
		///		FK__WarrantyA__Partn__440B1D61 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_partnerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of cunghoc3_AssetManager.Entities.WarrantyAsset objects.</returns>
		public abstract TList<WarrantyAsset> GetByPartnerId(TransactionManager transactionManager, System.String _partnerId, int start, int pageLength, out int count);
		
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
		public override cunghoc3_AssetManager.Entities.WarrantyAsset Get(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.WarrantyAssetKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Warranty__3214EC07403A8C7D index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.WarrantyAsset"/> class.</returns>
		public cunghoc3_AssetManager.Entities.WarrantyAsset GetById(System.String _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Warranty__3214EC07403A8C7D index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.WarrantyAsset"/> class.</returns>
		public cunghoc3_AssetManager.Entities.WarrantyAsset GetById(System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Warranty__3214EC07403A8C7D index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.WarrantyAsset"/> class.</returns>
		public cunghoc3_AssetManager.Entities.WarrantyAsset GetById(TransactionManager transactionManager, System.String _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Warranty__3214EC07403A8C7D index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.WarrantyAsset"/> class.</returns>
		public cunghoc3_AssetManager.Entities.WarrantyAsset GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Warranty__3214EC07403A8C7D index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.WarrantyAsset"/> class.</returns>
		public cunghoc3_AssetManager.Entities.WarrantyAsset GetById(System.String _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Warranty__3214EC07403A8C7D index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.WarrantyAsset"/> class.</returns>
		public abstract cunghoc3_AssetManager.Entities.WarrantyAsset GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;WarrantyAsset&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;WarrantyAsset&gt;"/></returns>
		public static TList<WarrantyAsset> Fill(IDataReader reader, TList<WarrantyAsset> rows, int start, int pageLength)
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
				
				cunghoc3_AssetManager.Entities.WarrantyAsset c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("WarrantyAsset")
					.Append("|").Append((System.String)reader[((int)WarrantyAssetColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<WarrantyAsset>(
					key.ToString(), // EntityTrackingKey
					"WarrantyAsset",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new cunghoc3_AssetManager.Entities.WarrantyAsset();
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
					c.Id = (System.String)reader[((int)WarrantyAssetColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.AsssetId = (reader.IsDBNull(((int)WarrantyAssetColumn.AsssetId - 1)))?null:(System.String)reader[((int)WarrantyAssetColumn.AsssetId - 1)];
					c.DepartmentUsedId = (reader.IsDBNull(((int)WarrantyAssetColumn.DepartmentUsedId - 1)))?null:(System.String)reader[((int)WarrantyAssetColumn.DepartmentUsedId - 1)];
					c.PartnerId = (reader.IsDBNull(((int)WarrantyAssetColumn.PartnerId - 1)))?null:(System.String)reader[((int)WarrantyAssetColumn.PartnerId - 1)];
					c.WarDateTime = (System.DateTime)reader[((int)WarrantyAssetColumn.WarDateTime - 1)];
					c.DeadlineWar = (reader.IsDBNull(((int)WarrantyAssetColumn.DeadlineWar - 1)))?null:(System.DateTime?)reader[((int)WarrantyAssetColumn.DeadlineWar - 1)];
					c.Address = (System.String)reader[((int)WarrantyAssetColumn.Address - 1)];
					c.PersonWar = (reader.IsDBNull(((int)WarrantyAssetColumn.PersonWar - 1)))?null:(System.String)reader[((int)WarrantyAssetColumn.PersonWar - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="cunghoc3_AssetManager.Entities.WarrantyAsset"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.WarrantyAsset"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, cunghoc3_AssetManager.Entities.WarrantyAsset entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.String)reader[((int)WarrantyAssetColumn.Id - 1)];
			entity.OriginalId = (System.String)reader["Id"];
			entity.AsssetId = (reader.IsDBNull(((int)WarrantyAssetColumn.AsssetId - 1)))?null:(System.String)reader[((int)WarrantyAssetColumn.AsssetId - 1)];
			entity.DepartmentUsedId = (reader.IsDBNull(((int)WarrantyAssetColumn.DepartmentUsedId - 1)))?null:(System.String)reader[((int)WarrantyAssetColumn.DepartmentUsedId - 1)];
			entity.PartnerId = (reader.IsDBNull(((int)WarrantyAssetColumn.PartnerId - 1)))?null:(System.String)reader[((int)WarrantyAssetColumn.PartnerId - 1)];
			entity.WarDateTime = (System.DateTime)reader[((int)WarrantyAssetColumn.WarDateTime - 1)];
			entity.DeadlineWar = (reader.IsDBNull(((int)WarrantyAssetColumn.DeadlineWar - 1)))?null:(System.DateTime?)reader[((int)WarrantyAssetColumn.DeadlineWar - 1)];
			entity.Address = (System.String)reader[((int)WarrantyAssetColumn.Address - 1)];
			entity.PersonWar = (reader.IsDBNull(((int)WarrantyAssetColumn.PersonWar - 1)))?null:(System.String)reader[((int)WarrantyAssetColumn.PersonWar - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="cunghoc3_AssetManager.Entities.WarrantyAsset"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.WarrantyAsset"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, cunghoc3_AssetManager.Entities.WarrantyAsset entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.String)dataRow["Id"];
			entity.OriginalId = (System.String)dataRow["Id"];
			entity.AsssetId = Convert.IsDBNull(dataRow["AsssetId"]) ? null : (System.String)dataRow["AsssetId"];
			entity.DepartmentUsedId = Convert.IsDBNull(dataRow["DepartmentUsedId"]) ? null : (System.String)dataRow["DepartmentUsedId"];
			entity.PartnerId = Convert.IsDBNull(dataRow["PartnerId"]) ? null : (System.String)dataRow["PartnerId"];
			entity.WarDateTime = (System.DateTime)dataRow["WarDateTime"];
			entity.DeadlineWar = Convert.IsDBNull(dataRow["DeadlineWar"]) ? null : (System.DateTime?)dataRow["DeadlineWar"];
			entity.Address = (System.String)dataRow["Address"];
			entity.PersonWar = Convert.IsDBNull(dataRow["PersonWar"]) ? null : (System.String)dataRow["PersonWar"];
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
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.WarrantyAsset"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">cunghoc3_AssetManager.Entities.WarrantyAsset Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.WarrantyAsset entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AsssetIdSource	
			if (CanDeepLoad(entity, "Asset|AsssetIdSource", deepLoadType, innerList) 
				&& entity.AsssetIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AsssetId ?? string.Empty);
				Asset tmpEntity = EntityManager.LocateEntity<Asset>(EntityLocator.ConstructKeyFromPkItems(typeof(Asset), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AsssetIdSource = tmpEntity;
				else
					entity.AsssetIdSource = DataRepository.AssetProvider.GetById(transactionManager, (entity.AsssetId ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AsssetIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AsssetIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AssetProvider.DeepLoad(transactionManager, entity.AsssetIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AsssetIdSource

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

			#region PartnerIdSource	
			if (CanDeepLoad(entity, "Partner|PartnerIdSource", deepLoadType, innerList) 
				&& entity.PartnerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.PartnerId ?? string.Empty);
				Partner tmpEntity = EntityManager.LocateEntity<Partner>(EntityLocator.ConstructKeyFromPkItems(typeof(Partner), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PartnerIdSource = tmpEntity;
				else
					entity.PartnerIdSource = DataRepository.PartnerProvider.GetById(transactionManager, (entity.PartnerId ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PartnerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.PartnerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.PartnerProvider.DeepLoad(transactionManager, entity.PartnerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion PartnerIdSource
			
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
		/// Deep Save the entire object graph of the cunghoc3_AssetManager.Entities.WarrantyAsset object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">cunghoc3_AssetManager.Entities.WarrantyAsset instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">cunghoc3_AssetManager.Entities.WarrantyAsset Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.WarrantyAsset entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AsssetIdSource
			if (CanDeepSave(entity, "Asset|AsssetIdSource", deepSaveType, innerList) 
				&& entity.AsssetIdSource != null)
			{
				DataRepository.AssetProvider.Save(transactionManager, entity.AsssetIdSource);
				entity.AsssetId = entity.AsssetIdSource.Id;
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
			
			#region PartnerIdSource
			if (CanDeepSave(entity, "Partner|PartnerIdSource", deepSaveType, innerList) 
				&& entity.PartnerIdSource != null)
			{
				DataRepository.PartnerProvider.Save(transactionManager, entity.PartnerIdSource);
				entity.PartnerId = entity.PartnerIdSource.Id;
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
	
	#region WarrantyAssetChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>cunghoc3_AssetManager.Entities.WarrantyAsset</c>
	///</summary>
	public enum WarrantyAssetChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Asset</c> at AsssetIdSource
		///</summary>
		[ChildEntityType(typeof(Asset))]
		Asset,
		
		///<summary>
		/// Composite Property for <c>DepartmentUsed</c> at DepartmentUsedIdSource
		///</summary>
		[ChildEntityType(typeof(DepartmentUsed))]
		DepartmentUsed,
		
		///<summary>
		/// Composite Property for <c>Partner</c> at PartnerIdSource
		///</summary>
		[ChildEntityType(typeof(Partner))]
		Partner,
	}
	
	#endregion WarrantyAssetChildEntityTypes
	
	#region WarrantyAssetFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;WarrantyAssetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WarrantyAsset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WarrantyAssetFilterBuilder : SqlFilterBuilder<WarrantyAssetColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetFilterBuilder class.
		/// </summary>
		public WarrantyAssetFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WarrantyAssetFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WarrantyAssetFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WarrantyAssetFilterBuilder
	
	#region WarrantyAssetParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;WarrantyAssetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WarrantyAsset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WarrantyAssetParameterBuilder : ParameterizedSqlFilterBuilder<WarrantyAssetColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetParameterBuilder class.
		/// </summary>
		public WarrantyAssetParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WarrantyAssetParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WarrantyAssetParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WarrantyAssetParameterBuilder
	
	#region WarrantyAssetSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;WarrantyAssetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WarrantyAsset"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class WarrantyAssetSortBuilder : SqlSortBuilder<WarrantyAssetColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetSqlSortBuilder class.
		/// </summary>
		public WarrantyAssetSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion WarrantyAssetSortBuilder
	
} // end namespace
