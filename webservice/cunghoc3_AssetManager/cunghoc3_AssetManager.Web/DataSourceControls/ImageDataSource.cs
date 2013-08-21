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
	/// Represents the DataRepository.ImageProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ImageDataSourceDesigner))]
	public class ImageDataSource : ProviderDataSource<Image, ImageKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ImageDataSource class.
		/// </summary>
		public ImageDataSource() : base(new ImageService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ImageDataSourceView used by the ImageDataSource.
		/// </summary>
		protected ImageDataSourceView ImageView
		{
			get { return ( View as ImageDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ImageDataSource control invokes to retrieve data.
		/// </summary>
		public ImageSelectMethod SelectMethod
		{
			get
			{
				ImageSelectMethod selectMethod = ImageSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ImageSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ImageDataSourceView class that is to be
		/// used by the ImageDataSource.
		/// </summary>
		/// <returns>An instance of the ImageDataSourceView class.</returns>
		protected override BaseDataSourceView<Image, ImageKey> GetNewDataSourceView()
		{
			return new ImageDataSourceView(this, DefaultViewName);
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
	/// Supports the ImageDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ImageDataSourceView : ProviderDataSourceView<Image, ImageKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ImageDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ImageDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ImageDataSourceView(ImageDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ImageDataSource ImageOwner
		{
			get { return Owner as ImageDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ImageSelectMethod SelectMethod
		{
			get { return ImageOwner.SelectMethod; }
			set { ImageOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ImageService ImageProvider
		{
			get { return Provider as ImageService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Image> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Image> results = null;
			Image item;
			count = 0;
			
			System.Int64 _id;

			switch ( SelectMethod )
			{
				case ImageSelectMethod.Get:
					ImageKey entityKey  = new ImageKey();
					entityKey.Load(values);
					item = ImageProvider.Get(entityKey);
					results = new TList<Image>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ImageSelectMethod.GetAll:
                    results = ImageProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ImageSelectMethod.GetPaged:
					results = ImageProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ImageSelectMethod.Find:
					if ( FilterParameters != null )
						results = ImageProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ImageProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ImageSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["Id"], typeof(System.Int64)) : (long)0;
					item = ImageProvider.GetById(_id);
					results = new TList<Image>();
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
			if ( SelectMethod == ImageSelectMethod.Get || SelectMethod == ImageSelectMethod.GetById )
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
				Image entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ImageProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Image> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ImageProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ImageDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ImageDataSource class.
	/// </summary>
	public class ImageDataSourceDesigner : ProviderDataSourceDesigner<Image, ImageKey>
	{
		/// <summary>
		/// Initializes a new instance of the ImageDataSourceDesigner class.
		/// </summary>
		public ImageDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ImageSelectMethod SelectMethod
		{
			get { return ((ImageDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ImageDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ImageDataSourceActionList

	/// <summary>
	/// Supports the ImageDataSourceDesigner class.
	/// </summary>
	internal class ImageDataSourceActionList : DesignerActionList
	{
		private ImageDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ImageDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ImageDataSourceActionList(ImageDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ImageSelectMethod SelectMethod
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

	#endregion ImageDataSourceActionList
	
	#endregion ImageDataSourceDesigner
	
	#region ImageSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ImageDataSource.SelectMethod property.
	/// </summary>
	public enum ImageSelectMethod
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
	
	#endregion ImageSelectMethod

	#region ImageFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Image"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ImageFilter : SqlFilter<ImageColumn>
	{
	}
	
	#endregion ImageFilter

	#region ImageExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Image"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ImageExpressionBuilder : SqlExpressionBuilder<ImageColumn>
	{
	}
	
	#endregion ImageExpressionBuilder	

	#region ImageProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ImageChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Image"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ImageProperty : ChildEntityProperty<ImageChildEntityTypes>
	{
	}
	
	#endregion ImageProperty
}

