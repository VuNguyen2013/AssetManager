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
	/// Represents the DataRepository.AuditProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AuditDataSourceDesigner))]
	public class AuditDataSource : ProviderDataSource<Audit, AuditKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuditDataSource class.
		/// </summary>
		public AuditDataSource() : base(new AuditService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AuditDataSourceView used by the AuditDataSource.
		/// </summary>
		protected AuditDataSourceView AuditView
		{
			get { return ( View as AuditDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AuditDataSource control invokes to retrieve data.
		/// </summary>
		public AuditSelectMethod SelectMethod
		{
			get
			{
				AuditSelectMethod selectMethod = AuditSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AuditSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AuditDataSourceView class that is to be
		/// used by the AuditDataSource.
		/// </summary>
		/// <returns>An instance of the AuditDataSourceView class.</returns>
		protected override BaseDataSourceView<Audit, AuditKey> GetNewDataSourceView()
		{
			return new AuditDataSourceView(this, DefaultViewName);
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
	/// Supports the AuditDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AuditDataSourceView : ProviderDataSourceView<Audit, AuditKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuditDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AuditDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AuditDataSourceView(AuditDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AuditDataSource AuditOwner
		{
			get { return Owner as AuditDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AuditSelectMethod SelectMethod
		{
			get { return AuditOwner.SelectMethod; }
			set { AuditOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AuditService AuditProvider
		{
			get { return Provider as AuditService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Audit> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Audit> results = null;
			Audit item;
			count = 0;
			
			System.Int64 _id;

			switch ( SelectMethod )
			{
				case AuditSelectMethod.Get:
					AuditKey entityKey  = new AuditKey();
					entityKey.Load(values);
					item = AuditProvider.Get(entityKey);
					results = new TList<Audit>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AuditSelectMethod.GetAll:
                    results = AuditProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AuditSelectMethod.GetPaged:
					results = AuditProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AuditSelectMethod.Find:
					if ( FilterParameters != null )
						results = AuditProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AuditProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AuditSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["Id"], typeof(System.Int64)) : (long)0;
					item = AuditProvider.GetById(_id);
					results = new TList<Audit>();
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
			if ( SelectMethod == AuditSelectMethod.Get || SelectMethod == AuditSelectMethod.GetById )
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
				Audit entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AuditProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Audit> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AuditProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AuditDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AuditDataSource class.
	/// </summary>
	public class AuditDataSourceDesigner : ProviderDataSourceDesigner<Audit, AuditKey>
	{
		/// <summary>
		/// Initializes a new instance of the AuditDataSourceDesigner class.
		/// </summary>
		public AuditDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AuditSelectMethod SelectMethod
		{
			get { return ((AuditDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AuditDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AuditDataSourceActionList

	/// <summary>
	/// Supports the AuditDataSourceDesigner class.
	/// </summary>
	internal class AuditDataSourceActionList : DesignerActionList
	{
		private AuditDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AuditDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AuditDataSourceActionList(AuditDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AuditSelectMethod SelectMethod
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

	#endregion AuditDataSourceActionList
	
	#endregion AuditDataSourceDesigner
	
	#region AuditSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AuditDataSource.SelectMethod property.
	/// </summary>
	public enum AuditSelectMethod
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
	
	#endregion AuditSelectMethod

	#region AuditFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Audit"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuditFilter : SqlFilter<AuditColumn>
	{
	}
	
	#endregion AuditFilter

	#region AuditExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Audit"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuditExpressionBuilder : SqlExpressionBuilder<AuditColumn>
	{
	}
	
	#endregion AuditExpressionBuilder	

	#region AuditProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AuditChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Audit"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuditProperty : ChildEntityProperty<AuditChildEntityTypes>
	{
	}
	
	#endregion AuditProperty
}

