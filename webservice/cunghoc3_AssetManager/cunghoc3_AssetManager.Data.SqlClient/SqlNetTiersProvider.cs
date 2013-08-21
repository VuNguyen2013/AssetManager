#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using cunghoc3_AssetManager.Entities;
using cunghoc3_AssetManager.Data;
using cunghoc3_AssetManager.Data.Bases;

#endregion

namespace cunghoc3_AssetManager.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : cunghoc3_AssetManager.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <see cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "UnitProvider"
			
		private SqlUnitProvider innerSqlUnitProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Unit"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UnitProviderBase UnitProvider
		{
			get
			{
				if (innerSqlUnitProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUnitProvider == null)
						{
							this.innerSqlUnitProvider = new SqlUnitProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUnitProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlUnitProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUnitProvider SqlUnitProvider
		{
			get {return UnitProvider as SqlUnitProvider;}
		}
		
		#endregion
		
		
		#region "DepartmentUsedProvider"
			
		private SqlDepartmentUsedProvider innerSqlDepartmentUsedProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DepartmentUsed"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DepartmentUsedProviderBase DepartmentUsedProvider
		{
			get
			{
				if (innerSqlDepartmentUsedProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDepartmentUsedProvider == null)
						{
							this.innerSqlDepartmentUsedProvider = new SqlDepartmentUsedProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDepartmentUsedProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlDepartmentUsedProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDepartmentUsedProvider SqlDepartmentUsedProvider
		{
			get {return DepartmentUsedProvider as SqlDepartmentUsedProvider;}
		}
		
		#endregion
		
		
		#region "PartnerProvider"
			
		private SqlPartnerProvider innerSqlPartnerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Partner"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PartnerProviderBase PartnerProvider
		{
			get
			{
				if (innerSqlPartnerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPartnerProvider == null)
						{
							this.innerSqlPartnerProvider = new SqlPartnerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPartnerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlPartnerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPartnerProvider SqlPartnerProvider
		{
			get {return PartnerProvider as SqlPartnerProvider;}
		}
		
		#endregion
		
		
		#region "ImageProvider"
			
		private SqlImageProvider innerSqlImageProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Image"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ImageProviderBase ImageProvider
		{
			get
			{
				if (innerSqlImageProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlImageProvider == null)
						{
							this.innerSqlImageProvider = new SqlImageProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlImageProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlImageProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlImageProvider SqlImageProvider
		{
			get {return ImageProvider as SqlImageProvider;}
		}
		
		#endregion
		
		
		#region "AssetProvider"
			
		private SqlAssetProvider innerSqlAssetProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Asset"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AssetProviderBase AssetProvider
		{
			get
			{
				if (innerSqlAssetProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAssetProvider == null)
						{
							this.innerSqlAssetProvider = new SqlAssetProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAssetProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAssetProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAssetProvider SqlAssetProvider
		{
			get {return AssetProvider as SqlAssetProvider;}
		}
		
		#endregion
		
		
		#region "UpDownReasonProvider"
			
		private SqlUpDownReasonProvider innerSqlUpDownReasonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="UpDownReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UpDownReasonProviderBase UpDownReasonProvider
		{
			get
			{
				if (innerSqlUpDownReasonProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUpDownReasonProvider == null)
						{
							this.innerSqlUpDownReasonProvider = new SqlUpDownReasonProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUpDownReasonProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlUpDownReasonProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUpDownReasonProvider SqlUpDownReasonProvider
		{
			get {return UpDownReasonProvider as SqlUpDownReasonProvider;}
		}
		
		#endregion
		
		
		#region "RepairAssetProvider"
			
		private SqlRepairAssetProvider innerSqlRepairAssetProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="RepairAsset"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RepairAssetProviderBase RepairAssetProvider
		{
			get
			{
				if (innerSqlRepairAssetProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRepairAssetProvider == null)
						{
							this.innerSqlRepairAssetProvider = new SqlRepairAssetProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRepairAssetProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlRepairAssetProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRepairAssetProvider SqlRepairAssetProvider
		{
			get {return RepairAssetProvider as SqlRepairAssetProvider;}
		}
		
		#endregion
		
		
		#region "CheckOutProvider"
			
		private SqlCheckOutProvider innerSqlCheckOutProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CheckOut"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CheckOutProviderBase CheckOutProvider
		{
			get
			{
				if (innerSqlCheckOutProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCheckOutProvider == null)
						{
							this.innerSqlCheckOutProvider = new SqlCheckOutProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCheckOutProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCheckOutProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCheckOutProvider SqlCheckOutProvider
		{
			get {return CheckOutProvider as SqlCheckOutProvider;}
		}
		
		#endregion
		
		
		#region "AssetGroupTypeProvider"
			
		private SqlAssetGroupTypeProvider innerSqlAssetGroupTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AssetGroupType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AssetGroupTypeProviderBase AssetGroupTypeProvider
		{
			get
			{
				if (innerSqlAssetGroupTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAssetGroupTypeProvider == null)
						{
							this.innerSqlAssetGroupTypeProvider = new SqlAssetGroupTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAssetGroupTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAssetGroupTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAssetGroupTypeProvider SqlAssetGroupTypeProvider
		{
			get {return AssetGroupTypeProvider as SqlAssetGroupTypeProvider;}
		}
		
		#endregion
		
		
		#region "AssetGroupProvider"
			
		private SqlAssetGroupProvider innerSqlAssetGroupProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AssetGroup"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AssetGroupProviderBase AssetGroupProvider
		{
			get
			{
				if (innerSqlAssetGroupProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAssetGroupProvider == null)
						{
							this.innerSqlAssetGroupProvider = new SqlAssetGroupProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAssetGroupProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAssetGroupProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAssetGroupProvider SqlAssetGroupProvider
		{
			get {return AssetGroupProvider as SqlAssetGroupProvider;}
		}
		
		#endregion
		
		
		#region "AssetLiquidationProvider"
			
		private SqlAssetLiquidationProvider innerSqlAssetLiquidationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AssetLiquidation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AssetLiquidationProviderBase AssetLiquidationProvider
		{
			get
			{
				if (innerSqlAssetLiquidationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAssetLiquidationProvider == null)
						{
							this.innerSqlAssetLiquidationProvider = new SqlAssetLiquidationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAssetLiquidationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAssetLiquidationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAssetLiquidationProvider SqlAssetLiquidationProvider
		{
			get {return AssetLiquidationProvider as SqlAssetLiquidationProvider;}
		}
		
		#endregion
		
		
		#region "AuditProvider"
			
		private SqlAuditProvider innerSqlAuditProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Audit"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AuditProviderBase AuditProvider
		{
			get
			{
				if (innerSqlAuditProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAuditProvider == null)
						{
							this.innerSqlAuditProvider = new SqlAuditProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAuditProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAuditProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAuditProvider SqlAuditProvider
		{
			get {return AuditProvider as SqlAuditProvider;}
		}
		
		#endregion
		
		
		#region "CapitalProvider"
			
		private SqlCapitalProvider innerSqlCapitalProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Capital"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CapitalProviderBase CapitalProvider
		{
			get
			{
				if (innerSqlCapitalProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCapitalProvider == null)
						{
							this.innerSqlCapitalProvider = new SqlCapitalProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCapitalProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCapitalProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCapitalProvider SqlCapitalProvider
		{
			get {return CapitalProvider as SqlCapitalProvider;}
		}
		
		#endregion
		
		
		#region "WarrantyAssetProvider"
			
		private SqlWarrantyAssetProvider innerSqlWarrantyAssetProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="WarrantyAsset"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override WarrantyAssetProviderBase WarrantyAssetProvider
		{
			get
			{
				if (innerSqlWarrantyAssetProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlWarrantyAssetProvider == null)
						{
							this.innerSqlWarrantyAssetProvider = new SqlWarrantyAssetProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlWarrantyAssetProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlWarrantyAssetProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlWarrantyAssetProvider SqlWarrantyAssetProvider
		{
			get {return WarrantyAssetProvider as SqlWarrantyAssetProvider;}
		}
		
		#endregion
		
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
