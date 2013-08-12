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
	/// Represents the DataRepository.AssetGroupTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AssetGroupTypeDataSourceDesigner))]
	public class AssetGroupTypeDataSource : ProviderDataSource<AssetGroupType, AssetGroupTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetGroupTypeDataSource class.
		/// </summary>
		public AssetGroupTypeDataSource() : base(new AssetGroupTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AssetGroupTypeDataSourceView used by the AssetGroupTypeDataSource.
		/// </summary>
		protected AssetGroupTypeDataSourceView AssetGroupTypeView
		{
			get { return ( View as AssetGroupTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AssetGroupTypeDataSource control invokes to retrieve data.
		/// </summary>
		public AssetGroupTypeSelectMethod SelectMethod
		{
			get
			{
				AssetGroupTypeSelectMethod selectMethod = AssetGroupTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AssetGroupTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AssetGroupTypeDataSourceView class that is to be
		/// used by the AssetGroupTypeDataSource.
		/// </summary>
		/// <returns>An instance of the AssetGroupTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<AssetGroupType, AssetGroupTypeKey> GetNewDataSourceView()
		{
			return new AssetGroupTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the AssetGroupTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AssetGroupTypeDataSourceView : ProviderDataSourceView<AssetGroupType, AssetGroupTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetGroupTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AssetGroupTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AssetGroupTypeDataSourceView(AssetGroupTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AssetGroupTypeDataSource AssetGroupTypeOwner
		{
			get { return Owner as AssetGroupTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AssetGroupTypeSelectMethod SelectMethod
		{
			get { return AssetGroupTypeOwner.SelectMethod; }
			set { AssetGroupTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AssetGroupTypeService AssetGroupTypeProvider
		{
			get { return Provider as AssetGroupTypeService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AssetGroupType> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AssetGroupType> results = null;
			AssetGroupType item;
			count = 0;
			
			System.String _id;

			switch ( SelectMethod )
			{
				case AssetGroupTypeSelectMethod.Get:
					AssetGroupTypeKey entityKey  = new AssetGroupTypeKey();
					entityKey.Load(values);
					item = AssetGroupTypeProvider.Get(entityKey);
					results = new TList<AssetGroupType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AssetGroupTypeSelectMethod.GetAll:
                    results = AssetGroupTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AssetGroupTypeSelectMethod.GetPaged:
					results = AssetGroupTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AssetGroupTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = AssetGroupTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AssetGroupTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AssetGroupTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = AssetGroupTypeProvider.GetById(_id);
					results = new TList<AssetGroupType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == AssetGroupTypeSelectMethod.Get || SelectMethod == AssetGroupTypeSelectMethod.GetById )
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
				AssetGroupType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AssetGroupTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AssetGroupType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AssetGroupTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AssetGroupTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AssetGroupTypeDataSource class.
	/// </summary>
	public class AssetGroupTypeDataSourceDesigner : ProviderDataSourceDesigner<AssetGroupType, AssetGroupTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the AssetGroupTypeDataSourceDesigner class.
		/// </summary>
		public AssetGroupTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AssetGroupTypeSelectMethod SelectMethod
		{
			get { return ((AssetGroupTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AssetGroupTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AssetGroupTypeDataSourceActionList

	/// <summary>
	/// Supports the AssetGroupTypeDataSourceDesigner class.
	/// </summary>
	internal class AssetGroupTypeDataSourceActionList : DesignerActionList
	{
		private AssetGroupTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AssetGroupTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AssetGroupTypeDataSourceActionList(AssetGroupTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AssetGroupTypeSelectMethod SelectMethod
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

	#endregion AssetGroupTypeDataSourceActionList
	
	#endregion AssetGroupTypeDataSourceDesigner
	
	#region AssetGroupTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AssetGroupTypeDataSource.SelectMethod property.
	/// </summary>
	public enum AssetGroupTypeSelectMethod
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
		GetById
	}
	
	#endregion AssetGroupTypeSelectMethod

	#region AssetGroupTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AssetGroupType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetGroupTypeFilter : SqlFilter<AssetGroupTypeColumn>
	{
	}
	
	#endregion AssetGroupTypeFilter

	#region AssetGroupTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AssetGroupType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetGroupTypeExpressionBuilder : SqlExpressionBuilder<AssetGroupTypeColumn>
	{
	}
	
	#endregion AssetGroupTypeExpressionBuilder	

	#region AssetGroupTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AssetGroupTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AssetGroupType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetGroupTypeProperty : ChildEntityProperty<AssetGroupTypeChildEntityTypes>
	{
	}
	
	#endregion AssetGroupTypeProperty
}

