#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using cunghoc3_AssetManager.Entities;
using cunghoc3_AssetManager.Data;
using cunghoc3_AssetManager.Data.Bases;
using cunghoc3_AssetManager.Services;
#endregion

namespace cunghoc3_AssetManager.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.AssetProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AssetDataSourceDesigner))]
	public class AssetDataSource : ProviderDataSource<Asset, AssetKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetDataSource class.
		/// </summary>
		public AssetDataSource() : base(new AssetService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AssetDataSourceView used by the AssetDataSource.
		/// </summary>
		protected AssetDataSourceView AssetView
		{
			get { return ( View as AssetDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AssetDataSource control invokes to retrieve data.
		/// </summary>
		public AssetSelectMethod SelectMethod
		{
			get
			{
				AssetSelectMethod selectMethod = AssetSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AssetSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AssetDataSourceView class that is to be
		/// used by the AssetDataSource.
		/// </summary>
		/// <returns>An instance of the AssetDataSourceView class.</returns>
		protected override BaseDataSourceView<Asset, AssetKey> GetNewDataSourceView()
		{
			return new AssetDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the AssetDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AssetDataSourceView : ProviderDataSourceView<Asset, AssetKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AssetDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AssetDataSourceView(AssetDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AssetDataSource AssetOwner
		{
			get { return Owner as AssetDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AssetSelectMethod SelectMethod
		{
			get { return AssetOwner.SelectMethod; }
			set { AssetOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AssetService AssetProvider
		{
			get { return Provider as AssetService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Asset> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Asset> results = null;
			Asset item;
			count = 0;
			
			System.String _id;
			System.String _assetGroupId_nullable;
			System.String _departmentUsedId_nullable;
			System.String _unitId_nullable;

			switch ( SelectMethod )
			{
				case AssetSelectMethod.Get:
					AssetKey entityKey  = new AssetKey();
					entityKey.Load(values);
					item = AssetProvider.Get(entityKey);
					results = new TList<Asset>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AssetSelectMethod.GetAll:
                    results = AssetProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AssetSelectMethod.GetPaged:
					results = AssetProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AssetSelectMethod.Find:
					if ( FilterParameters != null )
						results = AssetProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AssetProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AssetSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = AssetProvider.GetById(_id);
					results = new TList<Asset>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case AssetSelectMethod.GetByAssetGroupId:
					_assetGroupId_nullable = (System.String) EntityUtil.ChangeType(values["AssetGroupId"], typeof(System.String));
					results = AssetProvider.GetByAssetGroupId(_assetGroupId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case AssetSelectMethod.GetByDepartmentUsedId:
					_departmentUsedId_nullable = (System.String) EntityUtil.ChangeType(values["DepartmentUsedId"], typeof(System.String));
					results = AssetProvider.GetByDepartmentUsedId(_departmentUsedId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case AssetSelectMethod.GetByUnitId:
					_unitId_nullable = (System.String) EntityUtil.ChangeType(values["UnitId"], typeof(System.String));
					results = AssetProvider.GetByUnitId(_unitId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == AssetSelectMethod.Get || SelectMethod == AssetSelectMethod.GetById )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				Asset entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AssetProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<Asset> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AssetProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AssetDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AssetDataSource class.
	/// </summary>
	public class AssetDataSourceDesigner : ProviderDataSourceDesigner<Asset, AssetKey>
	{
		/// <summary>
		/// Initializes a new instance of the AssetDataSourceDesigner class.
		/// </summary>
		public AssetDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AssetSelectMethod SelectMethod
		{
			get { return ((AssetDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new AssetDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AssetDataSourceActionList

	/// <summary>
	/// Supports the AssetDataSourceDesigner class.
	/// </summary>
	internal class AssetDataSourceActionList : DesignerActionList
	{
		private AssetDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AssetDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AssetDataSourceActionList(AssetDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AssetSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion AssetDataSourceActionList
	
	#endregion AssetDataSourceDesigner
	
	#region AssetSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AssetDataSource.SelectMethod property.
	/// </summary>
	public enum AssetSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetById method.
		/// </summary>
		GetById,
		/// <summary>
		/// Represents the GetByAssetGroupId method.
		/// </summary>
		GetByAssetGroupId,
		/// <summary>
		/// Represents the GetByDepartmentUsedId method.
		/// </summary>
		GetByDepartmentUsedId,
		/// <summary>
		/// Represents the GetByUnitId method.
		/// </summary>
		GetByUnitId
	}
	
	#endregion AssetSelectMethod

	#region AssetFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Asset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetFilter : SqlFilter<AssetColumn>
	{
	}
	
	#endregion AssetFilter

	#region AssetExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Asset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetExpressionBuilder : SqlExpressionBuilder<AssetColumn>
	{
	}
	
	#endregion AssetExpressionBuilder	

	#region AssetProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AssetChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Asset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetProperty : ChildEntityProperty<AssetChildEntityTypes>
	{
	}
	
	#endregion AssetProperty
}

