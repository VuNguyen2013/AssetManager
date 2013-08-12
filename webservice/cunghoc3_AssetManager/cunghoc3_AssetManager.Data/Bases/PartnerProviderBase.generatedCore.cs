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
	/// This class is the base class for any <see cref="PartnerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PartnerProviderBaseCore : EntityProviderBase<cunghoc3_AssetManager.Entities.Partner, cunghoc3_AssetManager.Entities.PartnerKey>
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
		public override bool Delete(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.PartnerKey key)
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
		public override cunghoc3_AssetManager.Entities.Partner Get(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.PartnerKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Partner__3214EC07286302EC index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Partner"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Partner GetById(System.String _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Partner__3214EC07286302EC index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Partner"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Partner GetById(System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Partner__3214EC07286302EC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Partner"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Partner GetById(TransactionManager transactionManager, System.String _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Partner__3214EC07286302EC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Partner"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Partner GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Partner__3214EC07286302EC index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Partner"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Partner GetById(System.String _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Partner__3214EC07286302EC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Partner"/> class.</returns>
		public abstract cunghoc3_AssetManager.Entities.Partner GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Partner&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Partner&gt;"/></returns>
		public static TList<Partner> Fill(IDataReader reader, TList<Partner> rows, int start, int pageLength)
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
				
				cunghoc3_AssetManager.Entities.Partner c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Partner")
					.Append("|").Append((System.String)reader[((int)PartnerColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Partner>(
					key.ToString(), // EntityTrackingKey
					"Partner",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new cunghoc3_AssetManager.Entities.Partner();
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
					c.Id = (System.String)reader[((int)PartnerColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.Name = (System.String)reader[((int)PartnerColumn.Name - 1)];
					c.Address = (reader.IsDBNull(((int)PartnerColumn.Address - 1)))?null:(System.String)reader[((int)PartnerColumn.Address - 1)];
					c.Phone = (reader.IsDBNull(((int)PartnerColumn.Phone - 1)))?null:(System.String)reader[((int)PartnerColumn.Phone - 1)];
					c.TaxCode = (reader.IsDBNull(((int)PartnerColumn.TaxCode - 1)))?null:(System.String)reader[((int)PartnerColumn.TaxCode - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="cunghoc3_AssetManager.Entities.Partner"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.Partner"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, cunghoc3_AssetManager.Entities.Partner entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.String)reader[((int)PartnerColumn.Id - 1)];
			entity.OriginalId = (System.String)reader["Id"];
			entity.Name = (System.String)reader[((int)PartnerColumn.Name - 1)];
			entity.Address = (reader.IsDBNull(((int)PartnerColumn.Address - 1)))?null:(System.String)reader[((int)PartnerColumn.Address - 1)];
			entity.Phone = (reader.IsDBNull(((int)PartnerColumn.Phone - 1)))?null:(System.String)reader[((int)PartnerColumn.Phone - 1)];
			entity.TaxCode = (reader.IsDBNull(((int)PartnerColumn.TaxCode - 1)))?null:(System.String)reader[((int)PartnerColumn.TaxCode - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="cunghoc3_AssetManager.Entities.Partner"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.Partner"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, cunghoc3_AssetManager.Entities.Partner entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.String)dataRow["Id"];
			entity.OriginalId = (System.String)dataRow["Id"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (System.String)dataRow["Phone"];
			entity.TaxCode = Convert.IsDBNull(dataRow["TaxCode"]) ? null : (System.String)dataRow["TaxCode"];
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
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.Partner"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">cunghoc3_AssetManager.Entities.Partner Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.Partner entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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

				entity.WarrantyAssetCollection = DataRepository.WarrantyAssetProvider.GetByPartnerId(transactionManager, entity.Id);

				if (deep && entity.WarrantyAssetCollection.Count > 0)
				{
					deepHandles.Add("WarrantyAssetCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<WarrantyAsset>) DataRepository.WarrantyAssetProvider.DeepLoad,
						new object[] { transactionManager, entity.WarrantyAssetCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.RepairAssetCollection = DataRepository.RepairAssetProvider.GetByPartnerId(transactionManager, entity.Id);

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
		/// Deep Save the entire object graph of the cunghoc3_AssetManager.Entities.Partner object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">cunghoc3_AssetManager.Entities.Partner instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">cunghoc3_AssetManager.Entities.Partner Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.Partner entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
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
						if(child.PartnerIdSource != null)
						{
							child.PartnerId = child.PartnerIdSource.Id;
						}
						else
						{
							child.PartnerId = entity.Id;
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
				
	
			#region List<RepairAsset>
				if (CanDeepSave(entity.RepairAssetCollection, "List<RepairAsset>|RepairAssetCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RepairAsset child in entity.RepairAssetCollection)
					{
						if(child.PartnerIdSource != null)
						{
							child.PartnerId = child.PartnerIdSource.Id;
						}
						else
						{
							child.PartnerId = entity.Id;
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
	
	#region PartnerChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>cunghoc3_AssetManager.Entities.Partner</c>
	///</summary>
	public enum PartnerChildEntityTypes
	{
		///<summary>
		/// Collection of <c>Partner</c> as OneToMany for WarrantyAssetCollection
		///</summary>
		[ChildEntityType(typeof(TList<WarrantyAsset>))]
		WarrantyAssetCollection,
		///<summary>
		/// Collection of <c>Partner</c> as OneToMany for RepairAssetCollection
		///</summary>
		[ChildEntityType(typeof(TList<RepairAsset>))]
		RepairAssetCollection,
	}
	
	#endregion PartnerChildEntityTypes
	
	#region PartnerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;PartnerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Partner"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PartnerFilterBuilder : SqlFilterBuilder<PartnerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PartnerFilterBuilder class.
		/// </summary>
		public PartnerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PartnerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PartnerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PartnerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PartnerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PartnerFilterBuilder
	
	#region PartnerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;PartnerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Partner"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PartnerParameterBuilder : ParameterizedSqlFilterBuilder<PartnerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PartnerParameterBuilder class.
		/// </summary>
		public PartnerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PartnerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PartnerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PartnerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PartnerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PartnerParameterBuilder
	
	#region PartnerSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;PartnerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Partner"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class PartnerSortBuilder : SqlSortBuilder<PartnerColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PartnerSqlSortBuilder class.
		/// </summary>
		public PartnerSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion PartnerSortBuilder
	
} // end namespace
