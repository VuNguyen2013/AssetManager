#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using cunghoc3_AssetManager.Entities;
using cunghoc3_AssetManager.Data;

#endregion

namespace cunghoc3_AssetManager.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ImageProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ImageProviderBase : ImageProviderBaseCore
	{
	} // end class
} // end namespace
