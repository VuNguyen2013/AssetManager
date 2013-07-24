#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using cunghoc3_AssetManager.Entities;
using cunghoc3_AssetManager.Data;
using cunghoc3_AssetManager.Data.Bases;

#endregion

namespace cunghoc3_AssetManager.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("cunghoc3_AssetManager.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.10.0");
			
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
					// use default ConnectionStrings if _section has already been discovered
					if ( _config == null && _section != null )
					{
						return WebConfigurationManager.ConnectionStrings;
					}
					
					return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region DepartmentUsedProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DepartmentUsed"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DepartmentUsedProviderBase DepartmentUsedProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DepartmentUsedProvider;
			}
		}
		
		#endregion
		
		#region UnitProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Unit"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UnitProviderBase UnitProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UnitProvider;
			}
		}
		
		#endregion
		
		#region UpDownReasonProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="UpDownReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UpDownReasonProviderBase UpDownReasonProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UpDownReasonProvider;
			}
		}
		
		#endregion
		
		#region AssetGroupTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AssetGroupType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AssetGroupTypeProviderBase AssetGroupTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AssetGroupTypeProvider;
			}
		}
		
		#endregion
		
		#region AssetGroupProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AssetGroup"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AssetGroupProviderBase AssetGroupProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AssetGroupProvider;
			}
		}
		
		#endregion
		
		#region PartnerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Partner"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PartnerProviderBase PartnerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PartnerProvider;
			}
		}
		
		#endregion
		
		#region AssetProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Asset"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AssetProviderBase AssetProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AssetProvider;
			}
		}
		
		#endregion
		
		#region AssetLiquidationProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AssetLiquidation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AssetLiquidationProviderBase AssetLiquidationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AssetLiquidationProvider;
			}
		}
		
		#endregion
		
		#region CapitalProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Capital"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CapitalProviderBase CapitalProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CapitalProvider;
			}
		}
		
		#endregion
		
		#region WarrantyAssetProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="WarrantyAsset"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static WarrantyAssetProviderBase WarrantyAssetProvider
		{
			get 
			{
				LoadProviders();
				return _provider.WarrantyAssetProvider;
			}
		}
		
		#endregion
		
		#region RepairAssetProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="RepairAsset"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static RepairAssetProviderBase RepairAssetProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RepairAssetProvider;
			}
		}
		
		#endregion
		
		
		#endregion
	}
	
	#region Query/Filters
		
	#region DepartmentUsedFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DepartmentUsed"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentUsedFilters : DepartmentUsedFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentUsedFilters class.
		/// </summary>
		public DepartmentUsedFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentUsedFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentUsedFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentUsedFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentUsedFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentUsedFilters
	
	#region DepartmentUsedQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DepartmentUsedParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DepartmentUsed"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentUsedQuery : DepartmentUsedParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentUsedQuery class.
		/// </summary>
		public DepartmentUsedQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentUsedQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentUsedQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentUsedQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentUsedQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentUsedQuery
		
	#region UnitFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Unit"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitFilters : UnitFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitFilters class.
		/// </summary>
		public UnitFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UnitFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UnitFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UnitFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UnitFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UnitFilters
	
	#region UnitQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UnitParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Unit"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitQuery : UnitParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitQuery class.
		/// </summary>
		public UnitQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UnitQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UnitQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UnitQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UnitQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UnitQuery
		
	#region UpDownReasonFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UpDownReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UpDownReasonFilters : UpDownReasonFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UpDownReasonFilters class.
		/// </summary>
		public UpDownReasonFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UpDownReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UpDownReasonFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UpDownReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UpDownReasonFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UpDownReasonFilters
	
	#region UpDownReasonQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UpDownReasonParameterBuilder"/> class
	/// that is used exclusively with a <see cref="UpDownReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UpDownReasonQuery : UpDownReasonParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UpDownReasonQuery class.
		/// </summary>
		public UpDownReasonQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UpDownReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UpDownReasonQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UpDownReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UpDownReasonQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UpDownReasonQuery
		
	#region AssetGroupTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AssetGroupType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetGroupTypeFilters : AssetGroupTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetGroupTypeFilters class.
		/// </summary>
		public AssetGroupTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AssetGroupTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AssetGroupTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AssetGroupTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AssetGroupTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AssetGroupTypeFilters
	
	#region AssetGroupTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AssetGroupTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AssetGroupType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetGroupTypeQuery : AssetGroupTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetGroupTypeQuery class.
		/// </summary>
		public AssetGroupTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AssetGroupTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AssetGroupTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AssetGroupTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AssetGroupTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AssetGroupTypeQuery
		
	#region AssetGroupFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AssetGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetGroupFilters : AssetGroupFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetGroupFilters class.
		/// </summary>
		public AssetGroupFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AssetGroupFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AssetGroupFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AssetGroupFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AssetGroupFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AssetGroupFilters
	
	#region AssetGroupQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AssetGroupParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AssetGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetGroupQuery : AssetGroupParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetGroupQuery class.
		/// </summary>
		public AssetGroupQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AssetGroupQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AssetGroupQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AssetGroupQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AssetGroupQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AssetGroupQuery
		
	#region PartnerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Partner"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PartnerFilters : PartnerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PartnerFilters class.
		/// </summary>
		public PartnerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PartnerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PartnerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PartnerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PartnerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PartnerFilters
	
	#region PartnerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PartnerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Partner"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PartnerQuery : PartnerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PartnerQuery class.
		/// </summary>
		public PartnerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PartnerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PartnerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PartnerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PartnerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PartnerQuery
		
	#region AssetFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Asset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetFilters : AssetFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetFilters class.
		/// </summary>
		public AssetFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AssetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AssetFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AssetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AssetFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AssetFilters
	
	#region AssetQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AssetParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Asset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetQuery : AssetParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetQuery class.
		/// </summary>
		public AssetQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AssetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AssetQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AssetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AssetQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AssetQuery
		
	#region AssetLiquidationFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AssetLiquidation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetLiquidationFilters : AssetLiquidationFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationFilters class.
		/// </summary>
		public AssetLiquidationFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AssetLiquidationFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AssetLiquidationFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AssetLiquidationFilters
	
	#region AssetLiquidationQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AssetLiquidationParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AssetLiquidation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AssetLiquidationQuery : AssetLiquidationParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationQuery class.
		/// </summary>
		public AssetLiquidationQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AssetLiquidationQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AssetLiquidationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AssetLiquidationQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AssetLiquidationQuery
		
	#region CapitalFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Capital"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CapitalFilters : CapitalFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CapitalFilters class.
		/// </summary>
		public CapitalFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CapitalFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CapitalFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CapitalFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CapitalFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CapitalFilters
	
	#region CapitalQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CapitalParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Capital"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CapitalQuery : CapitalParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CapitalQuery class.
		/// </summary>
		public CapitalQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CapitalQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CapitalQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CapitalQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CapitalQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CapitalQuery
		
	#region WarrantyAssetFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WarrantyAsset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WarrantyAssetFilters : WarrantyAssetFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetFilters class.
		/// </summary>
		public WarrantyAssetFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WarrantyAssetFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WarrantyAssetFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WarrantyAssetFilters
	
	#region WarrantyAssetQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="WarrantyAssetParameterBuilder"/> class
	/// that is used exclusively with a <see cref="WarrantyAsset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WarrantyAssetQuery : WarrantyAssetParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetQuery class.
		/// </summary>
		public WarrantyAssetQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WarrantyAssetQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WarrantyAssetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WarrantyAssetQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WarrantyAssetQuery
		
	#region RepairAssetFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RepairAsset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RepairAssetFilters : RepairAssetFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RepairAssetFilters class.
		/// </summary>
		public RepairAssetFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the RepairAssetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RepairAssetFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RepairAssetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RepairAssetFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RepairAssetFilters
	
	#region RepairAssetQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="RepairAssetParameterBuilder"/> class
	/// that is used exclusively with a <see cref="RepairAsset"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RepairAssetQuery : RepairAssetParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RepairAssetQuery class.
		/// </summary>
		public RepairAssetQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the RepairAssetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RepairAssetQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RepairAssetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RepairAssetQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RepairAssetQuery
	#endregion

	
}
