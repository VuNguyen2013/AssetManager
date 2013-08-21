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
	/// Represents the DataRepository.CheckOutProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CheckOutDataSourceDesigner))]
	public class CheckOutDataSource : ProviderDataSource<CheckOut, CheckOutKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CheckOutDataSource class.
		/// </summary>
		public CheckOutDataSource() : base(new CheckOutService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CheckOutDataSourceView used by the CheckOutDataSource.
		/// </summary>
		protected CheckOutDataSourceView CheckOutView
		{
			get { return ( View as CheckOutDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CheckOutDataSource control invokes to retrieve data.
		/// </summary>
		public CheckOutSelectMethod SelectMethod
		{
			get
			{
				CheckOutSelectMethod selectMethod = CheckOutSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CheckOutSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CheckOutDataSourceView class that is to be
		/// used by the CheckOutDataSource.
		/// </summary>
		/// <returns>An instance of the CheckOutDataSourceView class.</returns>
		protected override BaseDataSourceView<CheckOut, CheckOutKey> GetNewDataSourceView()
		{
			return new CheckOutDataSourceView(this, DefaultViewName);
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
	/// Supports the CheckOutDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CheckOutDataSourceView : ProviderDataSourceView<CheckOut, CheckOutKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CheckOutDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CheckOutDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CheckOutDataSourceView(CheckOutDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CheckOutDataSource CheckOutOwner
		{
			get { return Owner as CheckOutDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CheckOutSelectMethod SelectMethod
		{
			get { return CheckOutOwner.SelectMethod; }
			set { CheckOutOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CheckOutService CheckOutProvider
		{
			get { return Provider as CheckOutService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CheckOut> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CheckOut> results = null;
			CheckOut item;
			count = 0;
			
			System.Int64 _id;

			switch ( SelectMethod )
			{
				case CheckOutSelectMethod.Get:
					CheckOutKey entityKey  = new CheckOutKey();
					entityKey.Load(values);
					item = CheckOutProvider.Get(entityKey);
					results = new TList<CheckOut>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CheckOutSelectMethod.GetAll:
                    results = CheckOutProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CheckOutSelectMethod.GetPaged:
					results = CheckOutProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CheckOutSelectMethod.Find:
					if ( FilterParameters != null )
						results = CheckOutProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CheckOutProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CheckOutSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["Id"], typeof(System.Int64)) : (long)0;
					item = CheckOutProvider.GetById(_id);
					results = new TList<CheckOut>();
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
			if ( SelectMethod == CheckOutSelectMethod.Get || SelectMethod == CheckOutSelectMethod.GetById )
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
				CheckOut entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CheckOutProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CheckOut> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CheckOutProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CheckOutDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CheckOutDataSource class.
	/// </summary>
	public class CheckOutDataSourceDesigner : ProviderDataSourceDesigner<CheckOut, CheckOutKey>
	{
		/// <summary>
		/// Initializes a new instance of the CheckOutDataSourceDesigner class.
		/// </summary>
		public CheckOutDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CheckOutSelectMethod SelectMethod
		{
			get { return ((CheckOutDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CheckOutDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CheckOutDataSourceActionList

	/// <summary>
	/// Supports the CheckOutDataSourceDesigner class.
	/// </summary>
	internal class CheckOutDataSourceActionList : DesignerActionList
	{
		private CheckOutDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CheckOutDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CheckOutDataSourceActionList(CheckOutDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CheckOutSelectMethod SelectMethod
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

	#endregion CheckOutDataSourceActionList
	
	#endregion CheckOutDataSourceDesigner
	
	#region CheckOutSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CheckOutDataSource.SelectMethod property.
	/// </summary>
	public enum CheckOutSelectMethod
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
	
	#endregion CheckOutSelectMethod

	#region CheckOutFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CheckOut"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CheckOutFilter : SqlFilter<CheckOutColumn>
	{
	}
	
	#endregion CheckOutFilter

	#region CheckOutExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CheckOut"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CheckOutExpressionBuilder : SqlExpressionBuilder<CheckOutColumn>
	{
	}
	
	#endregion CheckOutExpressionBuilder	

	#region CheckOutProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CheckOutChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CheckOut"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CheckOutProperty : ChildEntityProperty<CheckOutChildEntityTypes>
	{
	}
	
	#endregion CheckOutProperty
}

