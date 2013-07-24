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
	/// Represents the DataRepository.DepartmentUsedProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DepartmentUsedDataSourceDesigner))]
	public class DepartmentUsedDataSource : ProviderDataSource<DepartmentUsed, DepartmentUsedKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentUsedDataSource class.
		/// </summary>
		public DepartmentUsedDataSource() : base(new DepartmentUsedService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DepartmentUsedDataSourceView used by the DepartmentUsedDataSource.
		/// </summary>
		protected DepartmentUsedDataSourceView DepartmentUsedView
		{
			get { return ( View as DepartmentUsedDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DepartmentUsedDataSource control invokes to retrieve data.
		/// </summary>
		public DepartmentUsedSelectMethod SelectMethod
		{
			get
			{
				DepartmentUsedSelectMethod selectMethod = DepartmentUsedSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DepartmentUsedSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DepartmentUsedDataSourceView class that is to be
		/// used by the DepartmentUsedDataSource.
		/// </summary>
		/// <returns>An instance of the DepartmentUsedDataSourceView class.</returns>
		protected override BaseDataSourceView<DepartmentUsed, DepartmentUsedKey> GetNewDataSourceView()
		{
			return new DepartmentUsedDataSourceView(this, DefaultViewName);
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
	/// Supports the DepartmentUsedDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DepartmentUsedDataSourceView : ProviderDataSourceView<DepartmentUsed, DepartmentUsedKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentUsedDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DepartmentUsedDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DepartmentUsedDataSourceView(DepartmentUsedDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DepartmentUsedDataSource DepartmentUsedOwner
		{
			get { return Owner as DepartmentUsedDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DepartmentUsedSelectMethod SelectMethod
		{
			get { return DepartmentUsedOwner.SelectMethod; }
			set { DepartmentUsedOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DepartmentUsedService DepartmentUsedProvider
		{
			get { return Provider as DepartmentUsedService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DepartmentUsed> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DepartmentUsed> results = null;
			DepartmentUsed item;
			count = 0;
			
			System.String _id;

			switch ( SelectMethod )
			{
				case DepartmentUsedSelectMethod.Get:
					DepartmentUsedKey entityKey  = new DepartmentUsedKey();
					entityKey.Load(values);
					item = DepartmentUsedProvider.Get(entityKey);
					results = new TList<DepartmentUsed>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DepartmentUsedSelectMethod.GetAll:
                    results = DepartmentUsedProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DepartmentUsedSelectMethod.GetPaged:
					results = DepartmentUsedProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DepartmentUsedSelectMethod.Find:
					if ( FilterParameters != null )
						results = DepartmentUsedProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DepartmentUsedProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DepartmentUsedSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = DepartmentUsedProvider.GetById(_id);
					results = new TList<DepartmentUsed>();
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
			if ( SelectMethod == DepartmentUsedSelectMethod.Get || SelectMethod == DepartmentUsedSelectMethod.GetById )
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
				DepartmentUsed entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DepartmentUsedProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DepartmentUsed> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DepartmentUsedProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DepartmentUsedDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DepartmentUsedDataSource class.
	/// </summary>
	public class DepartmentUsedDataSourceDesigner : ProviderDataSourceDesigner<DepartmentUsed, DepartmentUsedKey>
	{
		/// <summary>
		/// Initializes a new instance of the DepartmentUsedDataSourceDesigner class.
		/// </summary>
		public DepartmentUsedDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DepartmentUsedSelectMethod SelectMethod
		{
			get { return ((DepartmentUsedDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DepartmentUsedDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DepartmentUsedDataSourceActionList

	/// <summary>
	/// Supports the DepartmentUsedDataSourceDesigner class.
	/// </summary>
	internal class DepartmentUsedDataSourceActionList : DesignerActionList
	{
		private DepartmentUsedDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DepartmentUsedDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DepartmentUsedDataSourceActionList(DepartmentUsedDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DepartmentUsedSelectMethod SelectMethod
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

	#endregion DepartmentUsedDataSourceActionList
	
	#endregion DepartmentUsedDataSourceDesigner
	
	#region DepartmentUsedSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DepartmentUsedDataSource.SelectMethod property.
	/// </summary>
	public enum DepartmentUsedSelectMethod
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
	
	#endregion DepartmentUsedSelectMethod

	#region DepartmentUsedFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DepartmentUsed"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentUsedFilter : SqlFilter<DepartmentUsedColumn>
	{
	}
	
	#endregion DepartmentUsedFilter

	#region DepartmentUsedExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DepartmentUsed"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentUsedExpressionBuilder : SqlExpressionBuilder<DepartmentUsedColumn>
	{
	}
	
	#endregion DepartmentUsedExpressionBuilder	

	#region DepartmentUsedProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DepartmentUsedChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DepartmentUsed"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentUsedProperty : ChildEntityProperty<DepartmentUsedChildEntityTypes>
	{
	}
	
	#endregion DepartmentUsedProperty
}

