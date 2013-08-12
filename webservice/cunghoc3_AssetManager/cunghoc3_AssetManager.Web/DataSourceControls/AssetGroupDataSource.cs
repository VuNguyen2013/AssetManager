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
	/// Represents the DataRepository.AssetGroupProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AssetGroupDataSourceDesigner))]
	public class AssetGroupDataSource : ProviderDataSource<AssetGroup, AssetGroupKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetGroupDataSource class.
		/// </summary>
		public AssetGroupDataSource() : base(new AssetGroupService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AssetGroupDataSourceView used by the AssetGroupDataSource.
		/// </summary>
		protected AssetGroupDataSourceView AssetGroupView
		{
			get { return ( View as AssetGroupDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AssetGroupDataSource control invokes to retrieve data.
		/// </summary>
		public AssetGroupSelectMethod SelectMethod
		{
			get
			{
				AssetGroupSelectMethod selectMethod = AssetGroupSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AssetGroupSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AssetGroupDataSourceView class that is to be
		/// used by the AssetGroupDataSource.
		/// </summary>
		/// <returns>An instance of the AssetGroupDataSourceView class.</returns>
		protected override BaseDataSourceView<AssetGroup, AssetGroupKey> GetNewDataSourceView()
		{
			return new AssetGroupDataSourceView(this, DefaultViewName);
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
	/// Supports the AssetGroupDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AssetGroupDataSourceView : ProviderDataSourceView<AssetGroup, AssetGroupKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetGroupDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AssetGroupDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AssetGroupDataSourceView(AssetGroupDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AssetGroupDataSource AssetGroupOwner
		{
			get { return Owner as AssetGroupDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AssetGroupSelectMethod SelectMethod
		{
			get { return AssetGroupOwner.SelectMethod; }
			set { AssetGroupOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AssetGroupService AssetGroupProvider
		{
			get { return Provider as AssetGroupService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AssetGroup> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AssetGroup> results = null;
			AssetGroup item;
			count = 0;
			
			System.String _id;
			System.String _assetGroupTypeId_nullable;

			switch ( SelectMethod )
			{
				case AssetGroupSelectMethod.Get:
					AssetGroupKey entityKey  = new AssetGroupKey();
					entityKey.Load(values);
					item = AssetGroupProvider.Get(entityKey);
					results = new TList<AssetGroup>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AssetGroupSelectMethod.GetAll:
                    results = AssetGroupProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AssetGroupSelectMethod.GetPaged:
					results = AssetGroupProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AssetGroupSelectMethod.Find:
					if ( FilterParameters != null )
						results = AssetGroupProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AssetGroupProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AssetGroupSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = AssetGroupProvider.GetById(_id);
					results = new TList<AssetGroup>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case AssetGroupSelectMethod.GetByAssetGroupTypeId:
					_assetGroupTypeId_nullable = (System.String) EntityUtil.ChangeType(values["AssetGroupTypeId"], typeof(System.String));
					results = AssetGroupProvider.GetByAssetGroupTypeId(_assetGroupTypeId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AssetGroupSelectMethod.Get || SelectMethod == AssetGroupSelectMethod.GetById )
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
				AssetGroup entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AssetGroupProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AssetGroup> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AssetGroupProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AssetGroupDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AssetGroupDataSource class.
	/// </summary>
	public class AssetGroupDataSourceDesigner : ProviderDataSourceDesigner<AssetGroup, AssetGroupKey>
	{
		/// <summary>
		/// Initializes a new instance of the AssetGroupDataSourceDesigner class.
		/// </summary>
		public AssetGroupDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AssetGroupSelectMethod SelectMethod
		{
			get { return ((AssetGroupDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AssetGroupDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AssetGroupDataSourceActionList

	/// <summary>
	/// Supports the AssetGroupDataSourceDesigner class.
	/// </summary>
	internal class AssetGroupDataSourceActionList : DesignerActionList
	{
		private AssetGroupDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AssetGroupDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AssetGroupDataSourceActionList(AssetGroupDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AssetGroupSelectMethod SelectMethod
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

	#endregion AssetGroupDataSourceActionList
	
	#endregion AssetGroupDataSourceDesigner
	
	#region AssetGroupSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AssetGroupDataSource.SelectMethod property.
	/// </summary>
	public enum AssetGroupSelectMethod
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
		/// Represents the GetByAssetGroupTypeId method.
		/// </summary>
		GetByAssetGroupTypeId
	}
	
	#endregion AssetGroupSelectMethod

	#region AssetGroupFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AssetGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetGroupFilter : SqlFilter<AssetGroupColumn>
	{
	}
	
	#endregion AssetGroupFilter

	#region AssetGroupExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AssetGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetGroupExpressionBuilder : SqlExpressionBuilder<AssetGroupColumn>
	{
	}
	
	#endregion AssetGroupExpressionBuilder	

	#region AssetGroupProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AssetGroupChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AssetGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetGroupProperty : ChildEntityProperty<AssetGroupChildEntityTypes>
	{
	}
	
	#endregion AssetGroupProperty
}

