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
	/// Represents the DataRepository.PartnerProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(PartnerDataSourceDesigner))]
	public class PartnerDataSource : ProviderDataSource<Partner, PartnerKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PartnerDataSource class.
		/// </summary>
		public PartnerDataSource() : base(new PartnerService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the PartnerDataSourceView used by the PartnerDataSource.
		/// </summary>
		protected PartnerDataSourceView PartnerView
		{
			get { return ( View as PartnerDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the PartnerDataSource control invokes to retrieve data.
		/// </summary>
		public PartnerSelectMethod SelectMethod
		{
			get
			{
				PartnerSelectMethod selectMethod = PartnerSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (PartnerSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the PartnerDataSourceView class that is to be
		/// used by the PartnerDataSource.
		/// </summary>
		/// <returns>An instance of the PartnerDataSourceView class.</returns>
		protected override BaseDataSourceView<Partner, PartnerKey> GetNewDataSourceView()
		{
			return new PartnerDataSourceView(this, DefaultViewName);
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
	/// Supports the PartnerDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class PartnerDataSourceView : ProviderDataSourceView<Partner, PartnerKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PartnerDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the PartnerDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public PartnerDataSourceView(PartnerDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal PartnerDataSource PartnerOwner
		{
			get { return Owner as PartnerDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal PartnerSelectMethod SelectMethod
		{
			get { return PartnerOwner.SelectMethod; }
			set { PartnerOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal PartnerService PartnerProvider
		{
			get { return Provider as PartnerService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Partner> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Partner> results = null;
			Partner item;
			count = 0;
			
			System.String _id;

			switch ( SelectMethod )
			{
				case PartnerSelectMethod.Get:
					PartnerKey entityKey  = new PartnerKey();
					entityKey.Load(values);
					item = PartnerProvider.Get(entityKey);
					results = new TList<Partner>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case PartnerSelectMethod.GetAll:
                    results = PartnerProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case PartnerSelectMethod.GetPaged:
					results = PartnerProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case PartnerSelectMethod.Find:
					if ( FilterParameters != null )
						results = PartnerProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = PartnerProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case PartnerSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = PartnerProvider.GetById(_id);
					results = new TList<Partner>();
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
			if ( SelectMethod == PartnerSelectMethod.Get || SelectMethod == PartnerSelectMethod.GetById )
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
				Partner entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					PartnerProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Partner> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			PartnerProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region PartnerDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the PartnerDataSource class.
	/// </summary>
	public class PartnerDataSourceDesigner : ProviderDataSourceDesigner<Partner, PartnerKey>
	{
		/// <summary>
		/// Initializes a new instance of the PartnerDataSourceDesigner class.
		/// </summary>
		public PartnerDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PartnerSelectMethod SelectMethod
		{
			get { return ((PartnerDataSource) DataSource).SelectMethod; }
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
				actions.Add(new PartnerDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region PartnerDataSourceActionList

	/// <summary>
	/// Supports the PartnerDataSourceDesigner class.
	/// </summary>
	internal class PartnerDataSourceActionList : DesignerActionList
	{
		private PartnerDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the PartnerDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public PartnerDataSourceActionList(PartnerDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PartnerSelectMethod SelectMethod
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

	#endregion PartnerDataSourceActionList
	
	#endregion PartnerDataSourceDesigner
	
	#region PartnerSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the PartnerDataSource.SelectMethod property.
	/// </summary>
	public enum PartnerSelectMethod
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
	
	#endregion PartnerSelectMethod

	#region PartnerFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Partner"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PartnerFilter : SqlFilter<PartnerColumn>
	{
	}
	
	#endregion PartnerFilter

	#region PartnerExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Partner"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PartnerExpressionBuilder : SqlExpressionBuilder<PartnerColumn>
	{
	}
	
	#endregion PartnerExpressionBuilder	

	#region PartnerProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;PartnerChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Partner"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PartnerProperty : ChildEntityProperty<PartnerChildEntityTypes>
	{
	}
	
	#endregion PartnerProperty
}

