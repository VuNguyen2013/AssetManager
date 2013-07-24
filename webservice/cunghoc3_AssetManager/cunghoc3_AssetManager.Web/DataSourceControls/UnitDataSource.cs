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
	/// Represents the DataRepository.UnitProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(UnitDataSourceDesigner))]
	public class UnitDataSource : ProviderDataSource<Unit, UnitKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitDataSource class.
		/// </summary>
		public UnitDataSource() : base(new UnitService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the UnitDataSourceView used by the UnitDataSource.
		/// </summary>
		protected UnitDataSourceView UnitView
		{
			get { return ( View as UnitDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the UnitDataSource control invokes to retrieve data.
		/// </summary>
		public UnitSelectMethod SelectMethod
		{
			get
			{
				UnitSelectMethod selectMethod = UnitSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (UnitSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the UnitDataSourceView class that is to be
		/// used by the UnitDataSource.
		/// </summary>
		/// <returns>An instance of the UnitDataSourceView class.</returns>
		protected override BaseDataSourceView<Unit, UnitKey> GetNewDataSourceView()
		{
			return new UnitDataSourceView(this, DefaultViewName);
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
	/// Supports the UnitDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class UnitDataSourceView : ProviderDataSourceView<Unit, UnitKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the UnitDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public UnitDataSourceView(UnitDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal UnitDataSource UnitOwner
		{
			get { return Owner as UnitDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal UnitSelectMethod SelectMethod
		{
			get { return UnitOwner.SelectMethod; }
			set { UnitOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal UnitService UnitProvider
		{
			get { return Provider as UnitService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Unit> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Unit> results = null;
			Unit item;
			count = 0;
			
			System.String _id;

			switch ( SelectMethod )
			{
				case UnitSelectMethod.Get:
					UnitKey entityKey  = new UnitKey();
					entityKey.Load(values);
					item = UnitProvider.Get(entityKey);
					results = new TList<Unit>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case UnitSelectMethod.GetAll:
                    results = UnitProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case UnitSelectMethod.GetPaged:
					results = UnitProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case UnitSelectMethod.Find:
					if ( FilterParameters != null )
						results = UnitProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = UnitProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case UnitSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = UnitProvider.GetById(_id);
					results = new TList<Unit>();
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
			if ( SelectMethod == UnitSelectMethod.Get || SelectMethod == UnitSelectMethod.GetById )
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
				Unit entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					UnitProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Unit> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			UnitProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region UnitDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the UnitDataSource class.
	/// </summary>
	public class UnitDataSourceDesigner : ProviderDataSourceDesigner<Unit, UnitKey>
	{
		/// <summary>
		/// Initializes a new instance of the UnitDataSourceDesigner class.
		/// </summary>
		public UnitDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UnitSelectMethod SelectMethod
		{
			get { return ((UnitDataSource) DataSource).SelectMethod; }
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
				actions.Add(new UnitDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region UnitDataSourceActionList

	/// <summary>
	/// Supports the UnitDataSourceDesigner class.
	/// </summary>
	internal class UnitDataSourceActionList : DesignerActionList
	{
		private UnitDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the UnitDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public UnitDataSourceActionList(UnitDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UnitSelectMethod SelectMethod
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

	#endregion UnitDataSourceActionList
	
	#endregion UnitDataSourceDesigner
	
	#region UnitSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the UnitDataSource.SelectMethod property.
	/// </summary>
	public enum UnitSelectMethod
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
	
	#endregion UnitSelectMethod

	#region UnitFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Unit"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitFilter : SqlFilter<UnitColumn>
	{
	}
	
	#endregion UnitFilter

	#region UnitExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Unit"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitExpressionBuilder : SqlExpressionBuilder<UnitColumn>
	{
	}
	
	#endregion UnitExpressionBuilder	

	#region UnitProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;UnitChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Unit"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitProperty : ChildEntityProperty<UnitChildEntityTypes>
	{
	}
	
	#endregion UnitProperty
}

