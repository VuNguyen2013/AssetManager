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
	/// This class is the base class for any <see cref="AuditProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AuditProviderBaseCore : EntityProviderBase<cunghoc3_AssetManager.Entities.Audit, cunghoc3_AssetManager.Entities.AuditKey>
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
		public override bool Delete(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.AuditKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _id)
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
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _id);		
		
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
		public override cunghoc3_AssetManager.Entities.Audit Get(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.AuditKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Audit__3214EC075441852A index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Audit"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Audit GetById(System.Int64 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Audit__3214EC075441852A index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Audit"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Audit GetById(System.Int64 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Audit__3214EC075441852A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Audit"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Audit GetById(TransactionManager transactionManager, System.Int64 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Audit__3214EC075441852A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Audit"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Audit GetById(TransactionManager transactionManager, System.Int64 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Audit__3214EC075441852A index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Audit"/> class.</returns>
		public cunghoc3_AssetManager.Entities.Audit GetById(System.Int64 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Audit__3214EC075441852A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.Audit"/> class.</returns>
		public abstract cunghoc3_AssetManager.Entities.Audit GetById(TransactionManager transactionManager, System.Int64 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Audit&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Audit&gt;"/></returns>
		public static TList<Audit> Fill(IDataReader reader, TList<Audit> rows, int start, int pageLength)
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
				
				cunghoc3_AssetManager.Entities.Audit c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Audit")
					.Append("|").Append((System.Int64)reader[((int)AuditColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Audit>(
					key.ToString(), // EntityTrackingKey
					"Audit",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new cunghoc3_AssetManager.Entities.Audit();
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
					c.Id = (System.Int64)reader[((int)AuditColumn.Id - 1)];
					c.AssetId = (reader.IsDBNull(((int)AuditColumn.AssetId - 1)))?null:(System.String)reader[((int)AuditColumn.AssetId - 1)];
					c.AuditDate = (reader.IsDBNull(((int)AuditColumn.AuditDate - 1)))?null:(System.DateTime?)reader[((int)AuditColumn.AuditDate - 1)];
					c.Comment = (reader.IsDBNull(((int)AuditColumn.Comment - 1)))?null:(System.String)reader[((int)AuditColumn.Comment - 1)];
					c.User = (reader.IsDBNull(((int)AuditColumn.User - 1)))?null:(System.String)reader[((int)AuditColumn.User - 1)];
					c.Computer = (reader.IsDBNull(((int)AuditColumn.Computer - 1)))?null:(System.String)reader[((int)AuditColumn.Computer - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="cunghoc3_AssetManager.Entities.Audit"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.Audit"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, cunghoc3_AssetManager.Entities.Audit entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int64)reader[((int)AuditColumn.Id - 1)];
			entity.AssetId = (reader.IsDBNull(((int)AuditColumn.AssetId - 1)))?null:(System.String)reader[((int)AuditColumn.AssetId - 1)];
			entity.AuditDate = (reader.IsDBNull(((int)AuditColumn.AuditDate - 1)))?null:(System.DateTime?)reader[((int)AuditColumn.AuditDate - 1)];
			entity.Comment = (reader.IsDBNull(((int)AuditColumn.Comment - 1)))?null:(System.String)reader[((int)AuditColumn.Comment - 1)];
			entity.User = (reader.IsDBNull(((int)AuditColumn.User - 1)))?null:(System.String)reader[((int)AuditColumn.User - 1)];
			entity.Computer = (reader.IsDBNull(((int)AuditColumn.Computer - 1)))?null:(System.String)reader[((int)AuditColumn.Computer - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="cunghoc3_AssetManager.Entities.Audit"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.Audit"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, cunghoc3_AssetManager.Entities.Audit entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int64)dataRow["Id"];
			entity.AssetId = Convert.IsDBNull(dataRow["AssetId"]) ? null : (System.String)dataRow["AssetId"];
			entity.AuditDate = Convert.IsDBNull(dataRow["AuditDate"]) ? null : (System.DateTime?)dataRow["AuditDate"];
			entity.Comment = Convert.IsDBNull(dataRow["Comment"]) ? null : (System.String)dataRow["Comment"];
			entity.User = Convert.IsDBNull(dataRow["User"]) ? null : (System.String)dataRow["User"];
			entity.Computer = Convert.IsDBNull(dataRow["Computer"]) ? null : (System.String)dataRow["Computer"];
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
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.Audit"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">cunghoc3_AssetManager.Entities.Audit Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.Audit entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the cunghoc3_AssetManager.Entities.Audit object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">cunghoc3_AssetManager.Entities.Audit instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">cunghoc3_AssetManager.Entities.Audit Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.Audit entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region AuditChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>cunghoc3_AssetManager.Entities.Audit</c>
	///</summary>
	public enum AuditChildEntityTypes
	{
	}
	
	#endregion AuditChildEntityTypes
	
	#region AuditFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AuditColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Audit"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuditFilterBuilder : SqlFilterBuilder<AuditColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuditFilterBuilder class.
		/// </summary>
		public AuditFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AuditFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AuditFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AuditFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AuditFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AuditFilterBuilder
	
	#region AuditParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AuditColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Audit"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuditParameterBuilder : ParameterizedSqlFilterBuilder<AuditColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuditParameterBuilder class.
		/// </summary>
		public AuditParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AuditParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AuditParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AuditParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AuditParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AuditParameterBuilder
	
	#region AuditSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AuditColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Audit"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AuditSortBuilder : SqlSortBuilder<AuditColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuditSqlSortBuilder class.
		/// </summary>
		public AuditSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AuditSortBuilder
	
} // end namespace
