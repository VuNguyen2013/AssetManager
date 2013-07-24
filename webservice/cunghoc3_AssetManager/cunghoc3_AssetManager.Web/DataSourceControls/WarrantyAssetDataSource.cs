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
	/// Represents the DataRepository.WarrantyAssetProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(WarrantyAssetDataSourceDesigner))]
	public class WarrantyAssetDataSource : ProviderDataSource<WarrantyAsset, WarrantyAssetKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetDataSource class.
		/// </summary>
		public WarrantyAssetDataSource() : base(new WarrantyAssetService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the WarrantyAssetDataSourceView used by the WarrantyAssetDataSource.
		/// </summary>
		protected WarrantyAssetDataSourceView WarrantyAssetView
		{
			get { return ( View as WarrantyAssetDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the WarrantyAssetDataSource control invokes to retrieve data.
		/// </summary>
		public WarrantyAssetSelectMethod SelectMethod
		{
			get
			{
				WarrantyAssetSelectMethod selectMethod = WarrantyAssetSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (WarrantyAssetSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the WarrantyAssetDataSourceView class that is to be
		/// used by the WarrantyAssetDataSource.
		/// </summary>
		/// <returns>An instance of the WarrantyAssetDataSourceView class.</returns>
		protected override BaseDataSourceView<WarrantyAsset, WarrantyAssetKey> GetNewDataSourceView()
		{
			return new WarrantyAssetDataSourceView(this, DefaultViewName);
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
	/// Supports the WarrantyAssetDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class WarrantyAssetDataSourceView : ProviderDataSourceView<WarrantyAsset, WarrantyAssetKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the WarrantyAssetDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public WarrantyAssetDataSourceView(WarrantyAssetDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal WarrantyAssetDataSource WarrantyAssetOwner
		{
			get { return Owner as WarrantyAssetDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal WarrantyAssetSelectMethod SelectMethod
		{
			get { return WarrantyAssetOwner.SelectMethod; }
			set { WarrantyAssetOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal WarrantyAssetService WarrantyAssetProvider
		{
			get { return Provider as WarrantyAssetService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<WarrantyAsset> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<WarrantyAsset> results = null;
			WarrantyAsset item;
			count = 0;
			
			System.String _id;
			System.String _asssetId_nullable;
			System.String _departmentUsedId_nullable;
			System.String _partnerId_nullable;

			switch ( SelectMethod )
			{
				case WarrantyAssetSelectMethod.Get:
					WarrantyAssetKey entityKey  = new WarrantyAssetKey();
					entityKey.Load(values);
					item = WarrantyAssetProvider.Get(entityKey);
					results = new TList<WarrantyAsset>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case WarrantyAssetSelectMethod.GetAll:
                    results = WarrantyAssetProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case WarrantyAssetSelectMethod.GetPaged:
					results = WarrantyAssetProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case WarrantyAssetSelectMethod.Find:
					if ( FilterParameters != null )
						results = WarrantyAssetProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = WarrantyAssetProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case WarrantyAssetSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = WarrantyAssetProvider.GetById(_id);
					results = new TList<WarrantyAsset>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case WarrantyAssetSelectMethod.GetByAsssetId:
					_asssetId_nullable = (System.String) EntityUtil.ChangeType(values["AsssetId"], typeof(System.String));
					results = WarrantyAssetProvider.GetByAsssetId(_asssetId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case WarrantyAssetSelectMethod.GetByDepartmentUsedId:
					_departmentUsedId_nullable = (System.String) EntityUtil.ChangeType(values["DepartmentUsedId"], typeof(System.String));
					results = WarrantyAssetProvider.GetByDepartmentUsedId(_departmentUsedId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case WarrantyAssetSelectMethod.GetByPartnerId:
					_partnerId_nullable = (System.String) EntityUtil.ChangeType(values["PartnerId"], typeof(System.String));
					results = WarrantyAssetProvider.GetByPartnerId(_partnerId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == WarrantyAssetSelectMethod.Get || SelectMethod == WarrantyAssetSelectMethod.GetById )
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
				WarrantyAsset entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					WarrantyAssetProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<WarrantyAsset> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			WarrantyAssetProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region WarrantyAssetDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the WarrantyAssetDataSource class.
	/// </summary>
	public class WarrantyAssetDataSourceDesigner : ProviderDataSourceDesigner<WarrantyAsset, WarrantyAssetKey>
	{
		/// <summary>
		/// Initializes a new instance of the WarrantyAssetDataSourceDesigner class.
		/// </summary>
		public WarrantyAssetDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WarrantyAssetSelectMethod SelectMethod
		{
			get { return ((WarrantyAssetDataSource) DataSource).SelectMethod; }
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
				actions.Add(new WarrantyAssetDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region WarrantyAssetDataSourceActionList

	/// <summary>
	/// Supports the WarrantyAssetDataSourceDesigner class.
	/// </summary>
	internal class WarrantyAssetDataSourceActionList : DesignerActionList
	{
		private WarrantyAssetDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public WarrantyAssetDataSourceActionList(WarrantyAssetDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WarrantyAssetSelectMethod SelectMethod
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

	#endregion WarrantyAssetDataSourceActionList
	
	#endregion WarrantyAssetDataSourceDesigner
	
	#region WarrantyAssetSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the WarrantyAssetDataSource.SelectMethod property.
	/// </summary>
	public enum WarrantyAssetSelectMethod
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
		/// Represents the GetByAsssetId method.
		/// </summary>
		GetByAsssetId,
		/// <summary>
		/// Represents the GetByDepartmentUsedId method.
		/// </summary>
		GetByDepartmentUsedId,
		/// <summary>
		/// Represents the GetByPartnerId method.
		/// </summary>
		GetByPartnerId
	}
	
	#endregion WarrantyAssetSelectMethod

	#region WarrantyAssetFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WarrantyAsset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WarrantyAssetFilter : SqlFilter<WarrantyAssetColumn>
	{
	}
	
	#endregion WarrantyAssetFilter

	#region WarrantyAssetExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WarrantyAsset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WarrantyAssetExpressionBuilder : SqlExpressionBuilder<WarrantyAssetColumn>
	{
	}
	
	#endregion WarrantyAssetExpressionBuilder	

	#region WarrantyAssetProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;WarrantyAssetChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="WarrantyAsset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WarrantyAssetProperty : ChildEntityProperty<WarrantyAssetChildEntityTypes>
	{
	}
	
	#endregion WarrantyAssetProperty
}

