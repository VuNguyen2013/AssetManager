
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
	/// An component type implementation of the 'DepartmentUsed' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class DepartmentUsedService : cunghoc3_AssetManager.Services.DepartmentUsedServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the DepartmentUsedService class.
		/// </summary>
		public DepartmentUsedService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
