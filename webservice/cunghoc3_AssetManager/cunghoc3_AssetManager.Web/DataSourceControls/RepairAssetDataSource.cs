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
	/// Represents the DataRepository.RepairAssetProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(RepairAssetDataSourceDesigner))]
	public class RepairAssetDataSource : ProviderDataSource<RepairAsset, RepairAssetKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RepairAssetDataSource class.
		/// </summary>
		public RepairAssetDataSource() : base(new RepairAssetService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the RepairAssetDataSourceView used by the RepairAssetDataSource.
		/// </summary>
		protected RepairAssetDataSourceView RepairAssetView
		{
			get { return ( View as RepairAssetDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the RepairAssetDataSource control invokes to retrieve data.
		/// </summary>
		public RepairAssetSelectMethod SelectMethod
		{
			get
			{
				RepairAssetSelectMethod selectMethod = RepairAssetSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (RepairAssetSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the RepairAssetDataSourceView class that is to be
		/// used by the RepairAssetDataSource.
		/// </summary>
		/// <returns>An instance of the RepairAssetDataSourceView class.</returns>
		protected override BaseDataSourceView<RepairAsset, RepairAssetKey> GetNewDataSourceView()
		{
			return new RepairAssetDataSourceView(this, DefaultViewName);
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
	/// Supports the RepairAssetDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class RepairAssetDataSourceView : ProviderDataSourceView<RepairAsset, RepairAssetKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RepairAssetDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the RepairAssetDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public RepairAssetDataSourceView(RepairAssetDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal RepairAssetDataSource RepairAssetOwner
		{
			get { return Owner as RepairAssetDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal RepairAssetSelectMethod SelectMethod
		{
			get { return RepairAssetOwner.SelectMethod; }
			set { RepairAssetOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal RepairAssetService RepairAssetProvider
		{
			get { return Provider as RepairAssetService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<RepairAsset> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<RepairAsset> results = null;
			RepairAsset item;
			count = 0;
			
			System.String _id;
			System.String _assetId_nullable;
			System.String _departmentUsedId_nullable;
			System.String _partnerId_nullable;

			switch ( SelectMethod )
			{
				case RepairAssetSelectMethod.Get:
					RepairAssetKey entityKey  = new RepairAssetKey();
					entityKey.Load(values);
					item = RepairAssetProvider.Get(entityKey);
					results = new TList<RepairAsset>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case RepairAssetSelectMethod.GetAll:
                    results = RepairAssetProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case RepairAssetSelectMethod.GetPaged:
					results = RepairAssetProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case RepairAssetSelectMethod.Find:
					if ( FilterParameters != null )
						results = RepairAssetProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = RepairAssetProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case RepairAssetSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = RepairAssetProvider.GetById(_id);
					results = new TList<RepairAsset>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case RepairAssetSelectMethod.GetByAssetId:
					_assetId_nullable = (System.String) EntityUtil.ChangeType(values["AssetId"], typeof(System.String));
					results = RepairAssetProvider.GetByAssetId(_assetId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case RepairAssetSelectMethod.GetByDepartmentUsedId:
					_departmentUsedId_nullable = (System.String) EntityUtil.ChangeType(values["DepartmentUsedId"], typeof(System.String));
					results = RepairAssetProvider.GetByDepartmentUsedId(_departmentUsedId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case RepairAssetSelectMethod.GetByPartnerId:
					_partnerId_nullable = (System.String) EntityUtil.ChangeType(values["PartnerId"], typeof(System.String));
					results = RepairAssetProvider.GetByPartnerId(_partnerId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == RepairAssetSelectMethod.Get || SelectMethod == RepairAssetSelectMethod.GetById )
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
				RepairAsset entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					RepairAssetProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<RepairAsset> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			RepairAssetProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region RepairAssetDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the RepairAssetDataSource class.
	/// </summary>
	public class RepairAssetDataSourceDesigner : ProviderDataSourceDesigner<RepairAsset, RepairAssetKey>
	{
		/// <summary>
		/// Initializes a new instance of the RepairAssetDataSourceDesigner class.
		/// </summary>
		public RepairAssetDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RepairAssetSelectMethod SelectMethod
		{
			get { return ((RepairAssetDataSource) DataSource).SelectMethod; }
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
				actions.Add(new RepairAssetDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region RepairAssetDataSourceActionList

	/// <summary>
	/// Supports the RepairAssetDataSourceDesigner class.
	/// </summary>
	internal class RepairAssetDataSourceActionList : DesignerActionList
	{
		private RepairAssetDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the RepairAssetDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public RepairAssetDataSourceActionList(RepairAssetDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RepairAssetSelectMethod SelectMethod
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

	#endregion RepairAssetDataSourceActionList
	
	#endregion RepairAssetDataSourceDesigner
	
	#region RepairAssetSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the RepairAssetDataSource.SelectMethod property.
	/// </summary>
	public enum RepairAssetSelectMethod
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
		/// Represents the GetByAssetId method.
		/// </summary>
		GetByAssetId,
		/// <summary>
		/// Represents the GetByDepartmentUsedId method.
		/// </summary>
		GetByDepartmentUsedId,
		/// <summary>
		/// Represents the GetByPartnerId method.
		/// </summary>
		GetByPartnerId
	}
	
	#endregion RepairAssetSelectMethod

	#region RepairAssetFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RepairAsset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RepairAssetFilter : SqlFilter<RepairAssetColumn>
	{
	}
	
	#endregion RepairAssetFilter

	#region RepairAssetExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RepairAsset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RepairAssetExpressionBuilder : SqlExpressionBuilder<RepairAssetColumn>
	{
	}
	
	#endregion RepairAssetExpressionBuilder	

	#region RepairAssetProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;RepairAssetChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="RepairAsset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RepairAssetProperty : ChildEntityProperty<RepairAssetChildEntityTypes>
	{
	}
	
	#endregion RepairAssetProperty
}

