using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace cunghoc3_AssetManager.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>AssetRepeater</c>
    /// </summary>
	public class AssetRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AssetRepeaterDesigner"/> class.
        /// </summary>
		public AssetRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is AssetRepeater))
			{ 
				throw new ArgumentException("Component is not a AssetRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			AssetRepeater z = (AssetRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="AssetRepeater"/> Type.
    /// </summary>
	[Designer(typeof(AssetRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:AssetRepeater runat=\"server\"></{0}:AssetRepeater>")]
	public class AssetRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AssetRepeater"/> class.
        /// </summary>
		public AssetRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(AssetItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(AssetItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}

		private ITemplate m_seperatorTemplate;
        /// <summary>
        /// Gets or sets the Seperator Template
        /// </summary>
        [Browsable(false)]
        [TemplateContainer(typeof(AssetItem))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public ITemplate SeperatorTemplate
        {
            get { return m_seperatorTemplate; }
            set { m_seperatorTemplate = value; }
        }
			
		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(AssetItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(AssetItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//      {
//         if (ChildControlsCreated)
//         {
//            return;
//         }

//         Controls.Clear();

//         //Instantiate the Header template (if exists)
//         if (m_headerTemplate != null)
//         {
//            Control headerItem = new Control();
//            m_headerTemplate.InstantiateIn(headerItem);
//            Controls.Add(headerItem);
//         }

//         //Instantiate the Footer template (if exists)
//         if (m_footerTemplate != null)
//         {
//            Control footerItem = new Control();
//            m_footerTemplate.InstantiateIn(footerItem);
//            Controls.Add(footerItem);
//         }
//
//         ChildControlsCreated = true;
//      }
	
		/// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            
        }

        /// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
                
        }		
		
		/// <summary>
      	/// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      	/// </summary>
		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
      	{
         int pos = 0;

         if (dataBinding)
         {
            //Instantiate the Header template (if exists)
            if (m_headerTemplate != null)
            {
                Control headerItem = new Control();
                m_headerTemplate.InstantiateIn(headerItem);
                Controls.Add(headerItem);
            }
			if (dataSource != null)
			{
				foreach (object o in dataSource)
				{
						cunghoc3_AssetManager.Entities.Asset entity = o as cunghoc3_AssetManager.Entities.Asset;
						AssetItem container = new AssetItem(entity);
	
						if (m_itemTemplate != null && (pos % 2) == 0)
						{
							m_itemTemplate.InstantiateIn(container);
							
							if (m_seperatorTemplate != null)
							{
								m_seperatorTemplate.InstantiateIn(container);
							}
						}
						else
						{
							if (m_altenateItemTemplate != null)
							{
								m_altenateItemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
								
							}
							else if (m_itemTemplate != null)
							{
								m_itemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
							}
							else
							{
								// no template !!!
							}
						}
						Controls.Add(container);
						
						container.DataBind();
						
						pos++;
				}
			}
            //Instantiate the Footer template (if exists)
            if (m_footerTemplate != null)
            {
                Control footerItem = new Control();
                m_footerTemplate.InstantiateIn(footerItem);
                Controls.Add(footerItem);
            }

		}
			
			return pos;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class AssetItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private cunghoc3_AssetManager.Entities.Asset _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AssetItem"/> class.
        /// </summary>
		public AssetItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AssetItem"/> class.
        /// </summary>
		public AssetItem(cunghoc3_AssetManager.Entities.Asset entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the Id
        /// </summary>
        /// <value>The Id.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Id
		{
			get { return _entity.Id; }
		}
        /// <summary>
        /// Gets the Name
        /// </summary>
        /// <value>The Name.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Name
		{
			get { return _entity.Name; }
		}
        /// <summary>
        /// Gets the AssetGroupId
        /// </summary>
        /// <value>The AssetGroupId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AssetGroupId
		{
			get { return _entity.AssetGroupId; }
		}
        /// <summary>
        /// Gets the UnitId
        /// </summary>
        /// <value>The UnitId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UnitId
		{
			get { return _entity.UnitId; }
		}
        /// <summary>
        /// Gets the Amount
        /// </summary>
        /// <value>The Amount.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Amount
		{
			get { return _entity.Amount; }
		}
        /// <summary>
        /// Gets the CounPro
        /// </summary>
        /// <value>The CounPro.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CounPro
		{
			get { return _entity.CounPro; }
		}
        /// <summary>
        /// Gets the YearPro
        /// </summary>
        /// <value>The YearPro.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 YearPro
		{
			get { return _entity.YearPro; }
		}
        /// <summary>
        /// Gets the DepartmentUsedId
        /// </summary>
        /// <value>The DepartmentUsedId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DepartmentUsedId
		{
			get { return _entity.DepartmentUsedId; }
		}
        /// <summary>
        /// Gets the TotalPrice
        /// </summary>
        /// <value>The TotalPrice.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 TotalPrice
		{
			get { return _entity.TotalPrice; }
		}
        /// <summary>
        /// Gets the BudgetPrice
        /// </summary>
        /// <value>The BudgetPrice.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 BudgetPrice
		{
			get { return _entity.BudgetPrice; }
		}
        /// <summary>
        /// Gets the OwnPrice
        /// </summary>
        /// <value>The OwnPrice.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 OwnPrice
		{
			get { return _entity.OwnPrice; }
		}
        /// <summary>
        /// Gets the VenturePrice
        /// </summary>
        /// <value>The VenturePrice.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 VenturePrice
		{
			get { return _entity.VenturePrice; }
		}
        /// <summary>
        /// Gets the AnotherPrice
        /// </summary>
        /// <value>The AnotherPrice.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 AnotherPrice
		{
			get { return _entity.AnotherPrice; }
		}
        /// <summary>
        /// Gets the TotalDepreciation
        /// </summary>
        /// <value>The TotalDepreciation.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 TotalDepreciation
		{
			get { return _entity.TotalDepreciation; }
		}
        /// <summary>
        /// Gets the BudgetDepreciation
        /// </summary>
        /// <value>The BudgetDepreciation.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 BudgetDepreciation
		{
			get { return _entity.BudgetDepreciation; }
		}
        /// <summary>
        /// Gets the OwnDepreciation
        /// </summary>
        /// <value>The OwnDepreciation.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 OwnDepreciation
		{
			get { return _entity.OwnDepreciation; }
		}
        /// <summary>
        /// Gets the VentureDepreciation
        /// </summary>
        /// <value>The VentureDepreciation.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 VentureDepreciation
		{
			get { return _entity.VentureDepreciation; }
		}
        /// <summary>
        /// Gets the AnotherDepreciation
        /// </summary>
        /// <value>The AnotherDepreciation.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 AnotherDepreciation
		{
			get { return _entity.AnotherDepreciation; }
		}
        /// <summary>
        /// Gets the BudgetRemain
        /// </summary>
        /// <value>The BudgetRemain.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 BudgetRemain
		{
			get { return _entity.BudgetRemain; }
		}
        /// <summary>
        /// Gets the OwnRemain
        /// </summary>
        /// <value>The OwnRemain.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 OwnRemain
		{
			get { return _entity.OwnRemain; }
		}
        /// <summary>
        /// Gets the VentureRemain
        /// </summary>
        /// <value>The VentureRemain.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 VentureRemain
		{
			get { return _entity.VentureRemain; }
		}
        /// <summary>
        /// Gets the AnotherRemain
        /// </summary>
        /// <value>The AnotherRemain.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 AnotherRemain
		{
			get { return _entity.AnotherRemain; }
		}
        /// <summary>
        /// Gets the TotalReamain
        /// </summary>
        /// <value>The TotalReamain.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 TotalReamain
		{
			get { return _entity.TotalReamain; }
		}
        /// <summary>
        /// Gets the UpDownCode
        /// </summary>
        /// <value>The UpDownCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UpDownCode
		{
			get { return _entity.UpDownCode; }
		}
        /// <summary>
        /// Gets the InputDateTime
        /// </summary>
        /// <value>The InputDateTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime InputDateTime
		{
			get { return _entity.InputDateTime; }
		}
        /// <summary>
        /// Gets the Manufacturer
        /// </summary>
        /// <value>The Manufacturer.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Manufacturer
		{
			get { return _entity.Manufacturer; }
		}
        /// <summary>
        /// Gets the Brand
        /// </summary>
        /// <value>The Brand.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Brand
		{
			get { return _entity.Brand; }
		}
        /// <summary>
        /// Gets the Model
        /// </summary>
        /// <value>The Model.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Model
		{
			get { return _entity.Model; }
		}
        /// <summary>
        /// Gets the Status
        /// </summary>
        /// <value>The Status.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int16? Status
		{
			get { return _entity.Status; }
		}
        /// <summary>
        /// Gets the DueDate
        /// </summary>
        /// <value>The DueDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? DueDate
		{
			get { return _entity.DueDate; }
		}
        /// <summary>
        /// Gets the Note
        /// </summary>
        /// <value>The Note.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Note
		{
			get { return _entity.Note; }
		}
        /// <summary>
        /// Gets the SeriesNumber
        /// </summary>
        /// <value>The SeriesNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SeriesNumber
		{
			get { return _entity.SeriesNumber; }
		}
        /// <summary>
        /// Gets the Condition
        /// </summary>
        /// <value>The Condition.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int16? Condition
		{
			get { return _entity.Condition; }
		}

        /// <summary>
        /// Gets a <see cref="T:cunghoc3_AssetManager.Entities.Asset"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public cunghoc3_AssetManager.Entities.Asset Entity
        {
            get { return _entity; }
        }
	}
}
