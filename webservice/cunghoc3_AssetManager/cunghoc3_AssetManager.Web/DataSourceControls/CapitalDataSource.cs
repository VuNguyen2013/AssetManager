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
	/// Represents the DataRepository.CapitalProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CapitalDataSourceDesigner))]
	public class CapitalDataSource : ProviderDataSource<Capital, CapitalKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CapitalDataSource class.
		/// </summary>
		public CapitalDataSource() : base(new CapitalService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CapitalDataSourceView used by the CapitalDataSource.
		/// </summary>
		protected CapitalDataSourceView CapitalView
		{
			get { return ( View as CapitalDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CapitalDataSource control invokes to retrieve data.
		/// </summary>
		public CapitalSelectMethod SelectMethod
		{
			get
			{
				CapitalSelectMethod selectMethod = CapitalSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CapitalSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CapitalDataSourceView class that is to be
		/// used by the CapitalDataSource.
		/// </summary>
		/// <returns>An instance of the CapitalDataSourceView class.</returns>
		protected override BaseDataSourceView<Capital, CapitalKey> GetNewDataSourceView()
		{
			return new CapitalDataSourceView(this, DefaultViewName);
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
	/// Supports the CapitalDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CapitalDataSourceView : ProviderDataSourceView<Capital, CapitalKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CapitalDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CapitalDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CapitalDataSourceView(CapitalDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CapitalDataSource CapitalOwner
		{
			get { return Owner as CapitalDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CapitalSelectMethod SelectMethod
		{
			get { return CapitalOwner.SelectMethod; }
			set { CapitalOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CapitalService CapitalProvider
		{
			get { return Provider as CapitalService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Capital> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Capital> results = null;
			Capital item;
			count = 0;
			
			System.String _id;

			switch ( SelectMethod )
			{
				case CapitalSelectMethod.Get:
					CapitalKey entityKey  = new CapitalKey();
					entityKey.Load(values);
					item = CapitalProvider.Get(entityKey);
					results = new TList<Capital>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CapitalSelectMethod.GetAll:
                    results = CapitalProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CapitalSelectMethod.GetPaged:
					results = CapitalProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CapitalSelectMethod.Find:
					if ( FilterParameters != null )
						results = CapitalProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CapitalProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CapitalSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = CapitalProvider.GetById(_id);
					results = new TList<Capital>();
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
			if ( SelectMethod == CapitalSelectMethod.Get || SelectMethod == CapitalSelectMethod.GetById )
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
				Capital entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CapitalProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Capital> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CapitalProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CapitalDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CapitalDataSource class.
	/// </summary>
	public class CapitalDataSourceDesigner : ProviderDataSourceDesigner<Capital, CapitalKey>
	{
		/// <summary>
		/// Initializes a new instance of the CapitalDataSourceDesigner class.
		/// </summary>
		public CapitalDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CapitalSelectMethod SelectMethod
		{
			get { return ((CapitalDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CapitalDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CapitalDataSourceActionList

	/// <summary>
	/// Supports the CapitalDataSourceDesigner class.
	/// </summary>
	internal class CapitalDataSourceActionList : DesignerActionList
	{
		private CapitalDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CapitalDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CapitalDataSourceActionList(CapitalDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CapitalSelectMethod SelectMethod
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

	#endregion CapitalDataSourceActionList
	
	#endregion CapitalDataSourceDesigner
	
	#region CapitalSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CapitalDataSource.SelectMethod property.
	/// </summary>
	public enum CapitalSelectMethod
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
	
	#endregion CapitalSelectMethod

	#region CapitalFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Capital"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CapitalFilter : SqlFilter<CapitalColumn>
	{
	}
	
	#endregion CapitalFilter

	#region CapitalExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Capital"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CapitalExpressionBuilder : SqlExpressionBuilder<CapitalColumn>
	{
	}
	
	#endregion CapitalExpressionBuilder	

	#region CapitalProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CapitalChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Capital"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CapitalProperty : ChildEntityProperty<CapitalChildEntityTypes>
	{
	}
	
	#endregion CapitalProperty
}

