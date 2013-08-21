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
	/// This class is the base class for any <see cref="CheckOutProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CheckOutProviderBaseCore : EntityProviderBase<cunghoc3_AssetManager.Entities.CheckOut, cunghoc3_AssetManager.Entities.CheckOutKey>
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
		public override bool Delete(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.CheckOutKey key)
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
		public override cunghoc3_AssetManager.Entities.CheckOut Get(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.CheckOutKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__CheckOut__3214EC075812160E index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.CheckOut"/> class.</returns>
		public cunghoc3_AssetManager.Entities.CheckOut GetById(System.Int64 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CheckOut__3214EC075812160E index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.CheckOut"/> class.</returns>
		public cunghoc3_AssetManager.Entities.CheckOut GetById(System.Int64 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CheckOut__3214EC075812160E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.CheckOut"/> class.</returns>
		public cunghoc3_AssetManager.Entities.CheckOut GetById(TransactionManager transactionManager, System.Int64 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CheckOut__3214EC075812160E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.CheckOut"/> class.</returns>
		public cunghoc3_AssetManager.Entities.CheckOut GetById(TransactionManager transactionManager, System.Int64 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CheckOut__3214EC075812160E index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.CheckOut"/> class.</returns>
		public cunghoc3_AssetManager.Entities.CheckOut GetById(System.Int64 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CheckOut__3214EC075812160E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="cunghoc3_AssetManager.Entities.CheckOut"/> class.</returns>
		public abstract cunghoc3_AssetManager.Entities.CheckOut GetById(TransactionManager transactionManager, System.Int64 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CheckOut&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CheckOut&gt;"/></returns>
		public static TList<CheckOut> Fill(IDataReader reader, TList<CheckOut> rows, int start, int pageLength)
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
				
				cunghoc3_AssetManager.Entities.CheckOut c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CheckOut")
					.Append("|").Append((System.Int64)reader[((int)CheckOutColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CheckOut>(
					key.ToString(), // EntityTrackingKey
					"CheckOut",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new cunghoc3_AssetManager.Entities.CheckOut();
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
					c.Id = (System.Int64)reader[((int)CheckOutColumn.Id - 1)];
					c.AssetId = (reader.IsDBNull(((int)CheckOutColumn.AssetId - 1)))?null:(System.String)reader[((int)CheckOutColumn.AssetId - 1)];
					c.CheckOutDate = (reader.IsDBNull(((int)CheckOutColumn.CheckOutDate - 1)))?null:(System.DateTime?)reader[((int)CheckOutColumn.CheckOutDate - 1)];
					c.Comment = (reader.IsDBNull(((int)CheckOutColumn.Comment - 1)))?null:(System.String)reader[((int)CheckOutColumn.Comment - 1)];
					c.User = (reader.IsDBNull(((int)CheckOutColumn.User - 1)))?null:(System.String)reader[((int)CheckOutColumn.User - 1)];
					c.Computer = (reader.IsDBNull(((int)CheckOutColumn.Computer - 1)))?null:(System.String)reader[((int)CheckOutColumn.Computer - 1)];
					c.Status = (reader.IsDBNull(((int)CheckOutColumn.Status - 1)))?null:(System.Int16?)reader[((int)CheckOutColumn.Status - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="cunghoc3_AssetManager.Entities.CheckOut"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.CheckOut"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, cunghoc3_AssetManager.Entities.CheckOut entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int64)reader[((int)CheckOutColumn.Id - 1)];
			entity.AssetId = (reader.IsDBNull(((int)CheckOutColumn.AssetId - 1)))?null:(System.String)reader[((int)CheckOutColumn.AssetId - 1)];
			entity.CheckOutDate = (reader.IsDBNull(((int)CheckOutColumn.CheckOutDate - 1)))?null:(System.DateTime?)reader[((int)CheckOutColumn.CheckOutDate - 1)];
			entity.Comment = (reader.IsDBNull(((int)CheckOutColumn.Comment - 1)))?null:(System.String)reader[((int)CheckOutColumn.Comment - 1)];
			entity.User = (reader.IsDBNull(((int)CheckOutColumn.User - 1)))?null:(System.String)reader[((int)CheckOutColumn.User - 1)];
			entity.Computer = (reader.IsDBNull(((int)CheckOutColumn.Computer - 1)))?null:(System.String)reader[((int)CheckOutColumn.Computer - 1)];
			entity.Status = (reader.IsDBNull(((int)CheckOutColumn.Status - 1)))?null:(System.Int16?)reader[((int)CheckOutColumn.Status - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="cunghoc3_AssetManager.Entities.CheckOut"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.CheckOut"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, cunghoc3_AssetManager.Entities.CheckOut entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int64)dataRow["Id"];
			entity.AssetId = Convert.IsDBNull(dataRow["AssetId"]) ? null : (System.String)dataRow["AssetId"];
			entity.CheckOutDate = Convert.IsDBNull(dataRow["CheckOutDate"]) ? null : (System.DateTime?)dataRow["CheckOutDate"];
			entity.Comment = Convert.IsDBNull(dataRow["Comment"]) ? null : (System.String)dataRow["Comment"];
			entity.User = Convert.IsDBNull(dataRow["User"]) ? null : (System.String)dataRow["User"];
			entity.Computer = Convert.IsDBNull(dataRow["Computer"]) ? null : (System.String)dataRow["Computer"];
			entity.Status = Convert.IsDBNull(dataRow["Status"]) ? null : (System.Int16?)dataRow["Status"];
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
		/// <param name="entity">The <see cref="cunghoc3_AssetManager.Entities.CheckOut"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">cunghoc3_AssetManager.Entities.CheckOut Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.CheckOut entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the cunghoc3_AssetManager.Entities.CheckOut object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">cunghoc3_AssetManager.Entities.CheckOut instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">cunghoc3_AssetManager.Entities.CheckOut Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, cunghoc3_AssetManager.Entities.CheckOut entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region CheckOutChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>cunghoc3_AssetManager.Entities.CheckOut</c>
	///</summary>
	public enum CheckOutChildEntityTypes
	{
	}
	
	#endregion CheckOutChildEntityTypes
	
	#region CheckOutFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CheckOutColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CheckOut"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CheckOutFilterBuilder : SqlFilterBuilder<CheckOutColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CheckOutFilterBuilder class.
		/// </summary>
		public CheckOutFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CheckOutFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CheckOutFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CheckOutFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CheckOutFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CheckOutFilterBuilder
	
	#region CheckOutParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CheckOutColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CheckOut"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CheckOutParameterBuilder : ParameterizedSqlFilterBuilder<CheckOutColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CheckOutParameterBuilder class.
		/// </summary>
		public CheckOutParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CheckOutParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CheckOutParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CheckOutParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CheckOutParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CheckOutParameterBuilder
	
	#region CheckOutSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CheckOutColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CheckOut"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CheckOutSortBuilder : SqlSortBuilder<CheckOutColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CheckOutSqlSortBuilder class.
		/// </summary>
		public CheckOutSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CheckOutSortBuilder
	
} // end namespace
