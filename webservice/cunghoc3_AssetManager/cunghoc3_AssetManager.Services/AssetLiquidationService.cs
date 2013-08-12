
#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using cunghoc3_AssetManager.Entities;
using cunghoc3_AssetManager.Entities.Validation;

using cunghoc3_AssetManager.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace cunghoc3_AssetManager.Services
{		
	/// <summary>
	/// An component type implementation of the 'AssetLiquidation' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class AssetLiquidationService : cunghoc3_AssetManager.Services.AssetLiquidationServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the AssetLiquidationService class.
		/// </summary>
		public AssetLiquidationService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
