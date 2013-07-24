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
	/// Represents the DataRepository.AssetLiquidationProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AssetLiquidationDataSourceDesigner))]
	public class AssetLiquidationDataSource : ProviderDataSource<AssetLiquidation, AssetLiquidationKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationDataSource class.
		/// </summary>
		public AssetLiquidationDataSource() : base(new AssetLiquidationService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AssetLiquidationDataSourceView used by the AssetLiquidationDataSource.
		/// </summary>
		protected AssetLiquidationDataSourceView AssetLiquidationView
		{
			get { return ( View as AssetLiquidationDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AssetLiquidationDataSource control invokes to retrieve data.
		/// </summary>
		public AssetLiquidationSelectMethod SelectMethod
		{
			get
			{
				AssetLiquidationSelectMethod selectMethod = AssetLiquidationSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AssetLiquidationSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AssetLiquidationDataSourceView class that is to be
		/// used by the AssetLiquidationDataSource.
		/// </summary>
		/// <returns>An instance of the AssetLiquidationDataSourceView class.</returns>
		protected override BaseDataSourceView<AssetLiquidation, AssetLiquidationKey> GetNewDataSourceView()
		{
			return new AssetLiquidationDataSourceView(this, DefaultViewName);
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
	/// Supports the AssetLiquidationDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AssetLiquidationDataSourceView : ProviderDataSourceView<AssetLiquidation, AssetLiquidationKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AssetLiquidationDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AssetLiquidationDataSourceView(AssetLiquidationDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AssetLiquidationDataSource AssetLiquidationOwner
		{
			get { return Owner as AssetLiquidationDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AssetLiquidationSelectMethod SelectMethod
		{
			get { return AssetLiquidationOwner.SelectMethod; }
			set { AssetLiquidationOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AssetLiquidationService AssetLiquidationProvider
		{
			get { return Provider as AssetLiquidationService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AssetLiquidation> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AssetLiquidation> results = null;
			AssetLiquidation item;
			count = 0;
			
			System.String _id;
			System.String _assetId_nullable;
			System.String _departmentUsedId_nullable;

			switch ( SelectMethod )
			{
				case AssetLiquidationSelectMethod.Get:
					AssetLiquidationKey entityKey  = new AssetLiquidationKey();
					entityKey.Load(values);
					item = AssetLiquidationProvider.Get(entityKey);
					results = new TList<AssetLiquidation>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AssetLiquidationSelectMethod.GetAll:
                    results = AssetLiquidationProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AssetLiquidationSelectMethod.GetPaged:
					results = AssetLiquidationProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AssetLiquidationSelectMethod.Find:
					if ( FilterParameters != null )
						results = AssetLiquidationProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AssetLiquidationProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AssetLiquidationSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = AssetLiquidationProvider.GetById(_id);
					results = new TList<AssetLiquidation>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case AssetLiquidationSelectMethod.GetByAssetId:
					_assetId_nullable = (System.String) EntityUtil.ChangeType(values["AssetId"], typeof(System.String));
					results = AssetLiquidationProvider.GetByAssetId(_assetId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case AssetLiquidationSelectMethod.GetByDepartmentUsedId:
					_departmentUsedId_nullable = (System.String) EntityUtil.ChangeType(values["DepartmentUsedId"], typeof(System.String));
					results = AssetLiquidationProvider.GetByDepartmentUsedId(_departmentUsedId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AssetLiquidationSelectMethod.Get || SelectMethod == AssetLiquidationSelectMethod.GetById )
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
				AssetLiquidation entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AssetLiquidationProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AssetLiquidation> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AssetLiquidationProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AssetLiquidationDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AssetLiquidationDataSource class.
	/// </summary>
	public class AssetLiquidationDataSourceDesigner : ProviderDataSourceDesigner<AssetLiquidation, AssetLiquidationKey>
	{
		/// <summary>
		/// Initializes a new instance of the AssetLiquidationDataSourceDesigner class.
		/// </summary>
		public AssetLiquidationDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AssetLiquidationSelectMethod SelectMethod
		{
			get { return ((AssetLiquidationDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AssetLiquidationDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AssetLiquidationDataSourceActionList

	/// <summary>
	/// Supports the AssetLiquidationDataSourceDesigner class.
	/// </summary>
	internal class AssetLiquidationDataSourceActionList : DesignerActionList
	{
		private AssetLiquidationDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AssetLiquidationDataSourceActionList(AssetLiquidationDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AssetLiquidationSelectMethod SelectMethod
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

	#endregion AssetLiquidationDataSourceActionList
	
	#endregion AssetLiquidationDataSourceDesigner
	
	#region AssetLiquidationSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AssetLiquidationDataSource.SelectMethod property.
	/// </summary>
	public enum AssetLiquidationSelectMethod
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
		GetByDepartmentUsedId
	}
	
	#endregion AssetLiquidationSelectMethod

	#region AssetLiquidationFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AssetLiquidation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetLiquidationFilter : SqlFilter<AssetLiquidationColumn>
	{
	}
	
	#endregion AssetLiquidationFilter

	#region AssetLiquidationExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AssetLiquidation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetLiquidationExpressionBuilder : SqlExpressionBuilder<AssetLiquidationColumn>
	{
	}
	
	#endregion AssetLiquidationExpressionBuilder	

	#region AssetLiquidationProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AssetLiquidationChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AssetLiquidation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetLiquidationProperty : ChildEntityProperty<AssetLiquidationChildEntityTypes>
	{
	}
	
	#endregion AssetLiquidationProperty
}

