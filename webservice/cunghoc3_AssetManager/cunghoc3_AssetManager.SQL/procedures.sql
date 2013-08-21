
USE [cunghoc3_AssetManager]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Unit table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_Get_List

AS


				
				SELECT
					[Id],
					[Name],
					[Note]
				FROM
					[dbo].[Unit]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Unit table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Note]'
				SET @SQL = @SQL + ' FROM [dbo].[Unit]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Note]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Unit]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Unit table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_Insert
(

	@Id varchar (10)  ,

	@Name nvarchar (50)  ,

	@Note nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[Unit]
					(
					[Id]
					,[Name]
					,[Note]
					)
				VALUES
					(
					@Id
					,@Name
					,@Note
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Unit table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_Update
(

	@Id varchar (10)  ,

	@OriginalId varchar (10)  ,

	@Name nvarchar (50)  ,

	@Note nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Unit]
				SET
					[Id] = @Id
					,[Name] = @Name
					,[Note] = @Note
				WHERE
[Id] = @OriginalId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Unit table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_Delete
(

	@Id varchar (10)  
)
AS


				DELETE FROM [dbo].[Unit] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Unit table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_GetById
(

	@Id varchar (10)  
)
AS


				SELECT
					[Id],
					[Name],
					[Note]
				FROM
					[dbo].[Unit]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Unit table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_Find
(

	@SearchUsingOR bit   = null ,

	@Id varchar (10)  = null ,

	@Name nvarchar (50)  = null ,

	@Note nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [Note]
    FROM
	[dbo].[Unit]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Note] = @Note OR @Note IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [Note]
    FROM
	[dbo].[Unit]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Note] = @Note AND @Note is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DepartmentUsed_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DepartmentUsed_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DepartmentUsed_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DepartmentUsed table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DepartmentUsed_Get_List

AS


				
				SELECT
					[Id],
					[Name],
					[Phone],
					[Representative],
					[Address]
				FROM
					[dbo].[DepartmentUsed]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DepartmentUsed_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DepartmentUsed_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DepartmentUsed_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DepartmentUsed table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DepartmentUsed_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ', [Representative]'
				SET @SQL = @SQL + ', [Address]'
				SET @SQL = @SQL + ' FROM [dbo].[DepartmentUsed]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Phone],'
				SET @SQL = @SQL + ' [Representative],'
				SET @SQL = @SQL + ' [Address]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DepartmentUsed]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DepartmentUsed_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DepartmentUsed_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DepartmentUsed_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DepartmentUsed table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DepartmentUsed_Insert
(

	@Id varchar (10)  ,

	@Name nvarchar (50)  ,

	@Phone varchar (15)  ,

	@Representative nvarchar (50)  ,

	@Address nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[DepartmentUsed]
					(
					[Id]
					,[Name]
					,[Phone]
					,[Representative]
					,[Address]
					)
				VALUES
					(
					@Id
					,@Name
					,@Phone
					,@Representative
					,@Address
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DepartmentUsed_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DepartmentUsed_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DepartmentUsed_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DepartmentUsed table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DepartmentUsed_Update
(

	@Id varchar (10)  ,

	@OriginalId varchar (10)  ,

	@Name nvarchar (50)  ,

	@Phone varchar (15)  ,

	@Representative nvarchar (50)  ,

	@Address nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DepartmentUsed]
				SET
					[Id] = @Id
					,[Name] = @Name
					,[Phone] = @Phone
					,[Representative] = @Representative
					,[Address] = @Address
				WHERE
[Id] = @OriginalId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DepartmentUsed_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DepartmentUsed_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DepartmentUsed_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DepartmentUsed table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DepartmentUsed_Delete
(

	@Id varchar (10)  
)
AS


				DELETE FROM [dbo].[DepartmentUsed] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DepartmentUsed_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DepartmentUsed_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DepartmentUsed_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DepartmentUsed table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DepartmentUsed_GetById
(

	@Id varchar (10)  
)
AS


				SELECT
					[Id],
					[Name],
					[Phone],
					[Representative],
					[Address]
				FROM
					[dbo].[DepartmentUsed]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DepartmentUsed_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DepartmentUsed_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DepartmentUsed_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DepartmentUsed table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DepartmentUsed_Find
(

	@SearchUsingOR bit   = null ,

	@Id varchar (10)  = null ,

	@Name nvarchar (50)  = null ,

	@Phone varchar (15)  = null ,

	@Representative nvarchar (50)  = null ,

	@Address nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [Phone]
	, [Representative]
	, [Address]
    FROM
	[dbo].[DepartmentUsed]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Representative] = @Representative OR @Representative IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [Phone]
	, [Representative]
	, [Address]
    FROM
	[dbo].[DepartmentUsed]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Representative] = @Representative AND @Representative is not null)
	OR ([Address] = @Address AND @Address is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Partner table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_Get_List

AS


				
				SELECT
					[Id],
					[Name],
					[Address],
					[Phone],
					[TaxCode]
				FROM
					[dbo].[Partner]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Partner table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Address]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ', [TaxCode]'
				SET @SQL = @SQL + ' FROM [dbo].[Partner]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Address],'
				SET @SQL = @SQL + ' [Phone],'
				SET @SQL = @SQL + ' [TaxCode]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Partner]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Partner table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_Insert
(

	@Id varchar (10)  ,

	@Name nvarchar (50)  ,

	@Address nvarchar (50)  ,

	@Phone varchar (15)  ,

	@TaxCode varchar (10)  
)
AS


				
				INSERT INTO [dbo].[Partner]
					(
					[Id]
					,[Name]
					,[Address]
					,[Phone]
					,[TaxCode]
					)
				VALUES
					(
					@Id
					,@Name
					,@Address
					,@Phone
					,@TaxCode
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Partner table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_Update
(

	@Id varchar (10)  ,

	@OriginalId varchar (10)  ,

	@Name nvarchar (50)  ,

	@Address nvarchar (50)  ,

	@Phone varchar (15)  ,

	@TaxCode varchar (10)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Partner]
				SET
					[Id] = @Id
					,[Name] = @Name
					,[Address] = @Address
					,[Phone] = @Phone
					,[TaxCode] = @TaxCode
				WHERE
[Id] = @OriginalId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Partner table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_Delete
(

	@Id varchar (10)  
)
AS


				DELETE FROM [dbo].[Partner] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Partner table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_GetById
(

	@Id varchar (10)  
)
AS


				SELECT
					[Id],
					[Name],
					[Address],
					[Phone],
					[TaxCode]
				FROM
					[dbo].[Partner]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Partner table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_Find
(

	@SearchUsingOR bit   = null ,

	@Id varchar (10)  = null ,

	@Name nvarchar (50)  = null ,

	@Address nvarchar (50)  = null ,

	@Phone varchar (15)  = null ,

	@TaxCode varchar (10)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [Address]
	, [Phone]
	, [TaxCode]
    FROM
	[dbo].[Partner]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([TaxCode] = @TaxCode OR @TaxCode IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [Address]
	, [Phone]
	, [TaxCode]
    FROM
	[dbo].[Partner]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([TaxCode] = @TaxCode AND @TaxCode is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Image_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Image_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Image_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Image table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Image_Get_List

AS


				
				SELECT
					[Id],
					[AssetId],
					[ImageURL]
				FROM
					[cunghoc3_AssetManager].[Image]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Image_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Image_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Image_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Image table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Image_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [AssetId]'
				SET @SQL = @SQL + ', [ImageURL]'
				SET @SQL = @SQL + ' FROM [cunghoc3_AssetManager].[Image]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [AssetId],'
				SET @SQL = @SQL + ' [ImageURL]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [cunghoc3_AssetManager].[Image]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Image_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Image_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Image_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Image table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Image_Insert
(

	@Id bigint    OUTPUT,

	@AssetId nvarchar (10)  ,

	@ImageUrl nvarchar (256)  
)
AS


				
				INSERT INTO [cunghoc3_AssetManager].[Image]
					(
					[AssetId]
					,[ImageURL]
					)
				VALUES
					(
					@AssetId
					,@ImageUrl
					)
				
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Image_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Image_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Image_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Image table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Image_Update
(

	@Id bigint   ,

	@AssetId nvarchar (10)  ,

	@ImageUrl nvarchar (256)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[cunghoc3_AssetManager].[Image]
				SET
					[AssetId] = @AssetId
					,[ImageURL] = @ImageUrl
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Image_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Image_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Image_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Image table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Image_Delete
(

	@Id bigint   
)
AS


				DELETE FROM [cunghoc3_AssetManager].[Image] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Image_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Image_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Image_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Image table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Image_GetById
(

	@Id bigint   
)
AS


				SELECT
					[Id],
					[AssetId],
					[ImageURL]
				FROM
					[cunghoc3_AssetManager].[Image]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Image_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Image_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Image_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Image table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Image_Find
(

	@SearchUsingOR bit   = null ,

	@Id bigint   = null ,

	@AssetId nvarchar (10)  = null ,

	@ImageUrl nvarchar (256)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [AssetId]
	, [ImageURL]
    FROM
	[cunghoc3_AssetManager].[Image]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([AssetId] = @AssetId OR @AssetId IS NULL)
	AND ([ImageURL] = @ImageUrl OR @ImageUrl IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [AssetId]
	, [ImageURL]
    FROM
	[cunghoc3_AssetManager].[Image]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([AssetId] = @AssetId AND @AssetId is not null)
	OR ([ImageURL] = @ImageUrl AND @ImageUrl is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Asset_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Asset_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Asset_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Asset table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Asset_Get_List

AS


				
				SELECT
					[Id],
					[Name],
					[AssetGroupId],
					[UnitId],
					[Amount],
					[CounPro],
					[YearPro],
					[DepartmentUsedId],
					[TotalPrice],
					[BudgetPrice],
					[OwnPrice],
					[VenturePrice],
					[AnotherPrice],
					[TotalDepreciation],
					[BudgetDepreciation],
					[OwnDepreciation],
					[VentureDepreciation],
					[AnotherDepreciation],
					[BudgetRemain],
					[OwnRemain],
					[VentureRemain],
					[AnotherRemain],
					[TotalReamain],
					[UpDownCode],
					[InputDateTime],
					[Manufacturer],
					[Brand],
					[Model],
					[Status],
					[DueDate],
					[Note],
					[SeriesNumber],
					[Condition]
				FROM
					[dbo].[Asset]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Asset_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Asset_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Asset_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Asset table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Asset_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [AssetGroupId]'
				SET @SQL = @SQL + ', [UnitId]'
				SET @SQL = @SQL + ', [Amount]'
				SET @SQL = @SQL + ', [CounPro]'
				SET @SQL = @SQL + ', [YearPro]'
				SET @SQL = @SQL + ', [DepartmentUsedId]'
				SET @SQL = @SQL + ', [TotalPrice]'
				SET @SQL = @SQL + ', [BudgetPrice]'
				SET @SQL = @SQL + ', [OwnPrice]'
				SET @SQL = @SQL + ', [VenturePrice]'
				SET @SQL = @SQL + ', [AnotherPrice]'
				SET @SQL = @SQL + ', [TotalDepreciation]'
				SET @SQL = @SQL + ', [BudgetDepreciation]'
				SET @SQL = @SQL + ', [OwnDepreciation]'
				SET @SQL = @SQL + ', [VentureDepreciation]'
				SET @SQL = @SQL + ', [AnotherDepreciation]'
				SET @SQL = @SQL + ', [BudgetRemain]'
				SET @SQL = @SQL + ', [OwnRemain]'
				SET @SQL = @SQL + ', [VentureRemain]'
				SET @SQL = @SQL + ', [AnotherRemain]'
				SET @SQL = @SQL + ', [TotalReamain]'
				SET @SQL = @SQL + ', [UpDownCode]'
				SET @SQL = @SQL + ', [InputDateTime]'
				SET @SQL = @SQL + ', [Manufacturer]'
				SET @SQL = @SQL + ', [Brand]'
				SET @SQL = @SQL + ', [Model]'
				SET @SQL = @SQL + ', [Status]'
				SET @SQL = @SQL + ', [DueDate]'
				SET @SQL = @SQL + ', [Note]'
				SET @SQL = @SQL + ', [SeriesNumber]'
				SET @SQL = @SQL + ', [Condition]'
				SET @SQL = @SQL + ' FROM [dbo].[Asset]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [AssetGroupId],'
				SET @SQL = @SQL + ' [UnitId],'
				SET @SQL = @SQL + ' [Amount],'
				SET @SQL = @SQL + ' [CounPro],'
				SET @SQL = @SQL + ' [YearPro],'
				SET @SQL = @SQL + ' [DepartmentUsedId],'
				SET @SQL = @SQL + ' [TotalPrice],'
				SET @SQL = @SQL + ' [BudgetPrice],'
				SET @SQL = @SQL + ' [OwnPrice],'
				SET @SQL = @SQL + ' [VenturePrice],'
				SET @SQL = @SQL + ' [AnotherPrice],'
				SET @SQL = @SQL + ' [TotalDepreciation],'
				SET @SQL = @SQL + ' [BudgetDepreciation],'
				SET @SQL = @SQL + ' [OwnDepreciation],'
				SET @SQL = @SQL + ' [VentureDepreciation],'
				SET @SQL = @SQL + ' [AnotherDepreciation],'
				SET @SQL = @SQL + ' [BudgetRemain],'
				SET @SQL = @SQL + ' [OwnRemain],'
				SET @SQL = @SQL + ' [VentureRemain],'
				SET @SQL = @SQL + ' [AnotherRemain],'
				SET @SQL = @SQL + ' [TotalReamain],'
				SET @SQL = @SQL + ' [UpDownCode],'
				SET @SQL = @SQL + ' [InputDateTime],'
				SET @SQL = @SQL + ' [Manufacturer],'
				SET @SQL = @SQL + ' [Brand],'
				SET @SQL = @SQL + ' [Model],'
				SET @SQL = @SQL + ' [Status],'
				SET @SQL = @SQL + ' [DueDate],'
				SET @SQL = @SQL + ' [Note],'
				SET @SQL = @SQL + ' [SeriesNumber],'
				SET @SQL = @SQL + ' [Condition]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Asset]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Asset_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Asset_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Asset_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Asset table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Asset_Insert
(

	@Id varchar (10)  ,

	@Name nvarchar (50)  ,

	@AssetGroupId varchar (10)  ,

	@UnitId varchar (10)  ,

	@Amount int   ,

	@CounPro nvarchar (50)  ,

	@YearPro int   ,

	@DepartmentUsedId varchar (10)  ,

	@TotalPrice bigint   ,

	@BudgetPrice bigint   ,

	@OwnPrice bigint   ,

	@VenturePrice bigint   ,

	@AnotherPrice bigint   ,

	@TotalDepreciation bigint   ,

	@BudgetDepreciation bigint   ,

	@OwnDepreciation bigint   ,

	@VentureDepreciation bigint   ,

	@AnotherDepreciation bigint   ,

	@BudgetRemain bigint   ,

	@OwnRemain bigint   ,

	@VentureRemain bigint   ,

	@AnotherRemain bigint   ,

	@TotalReamain bigint   ,

	@UpDownCode varchar (10)  ,

	@InputDateTime datetime   ,

	@Manufacturer nvarchar (50)  ,

	@Brand nvarchar (50)  ,

	@Model nvarchar (50)  ,

	@Status smallint   ,

	@DueDate datetime   ,

	@Note ntext   ,

	@SeriesNumber nvarchar (10)  ,

	@Condition smallint   
)
AS


				
				INSERT INTO [dbo].[Asset]
					(
					[Id]
					,[Name]
					,[AssetGroupId]
					,[UnitId]
					,[Amount]
					,[CounPro]
					,[YearPro]
					,[DepartmentUsedId]
					,[TotalPrice]
					,[BudgetPrice]
					,[OwnPrice]
					,[VenturePrice]
					,[AnotherPrice]
					,[TotalDepreciation]
					,[BudgetDepreciation]
					,[OwnDepreciation]
					,[VentureDepreciation]
					,[AnotherDepreciation]
					,[BudgetRemain]
					,[OwnRemain]
					,[VentureRemain]
					,[AnotherRemain]
					,[TotalReamain]
					,[UpDownCode]
					,[InputDateTime]
					,[Manufacturer]
					,[Brand]
					,[Model]
					,[Status]
					,[DueDate]
					,[Note]
					,[SeriesNumber]
					,[Condition]
					)
				VALUES
					(
					@Id
					,@Name
					,@AssetGroupId
					,@UnitId
					,@Amount
					,@CounPro
					,@YearPro
					,@DepartmentUsedId
					,@TotalPrice
					,@BudgetPrice
					,@OwnPrice
					,@VenturePrice
					,@AnotherPrice
					,@TotalDepreciation
					,@BudgetDepreciation
					,@OwnDepreciation
					,@VentureDepreciation
					,@AnotherDepreciation
					,@BudgetRemain
					,@OwnRemain
					,@VentureRemain
					,@AnotherRemain
					,@TotalReamain
					,@UpDownCode
					,@InputDateTime
					,@Manufacturer
					,@Brand
					,@Model
					,@Status
					,@DueDate
					,@Note
					,@SeriesNumber
					,@Condition
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Asset_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Asset_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Asset_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Asset table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Asset_Update
(

	@Id varchar (10)  ,

	@OriginalId varchar (10)  ,

	@Name nvarchar (50)  ,

	@AssetGroupId varchar (10)  ,

	@UnitId varchar (10)  ,

	@Amount int   ,

	@CounPro nvarchar (50)  ,

	@YearPro int   ,

	@DepartmentUsedId varchar (10)  ,

	@TotalPrice bigint   ,

	@BudgetPrice bigint   ,

	@OwnPrice bigint   ,

	@VenturePrice bigint   ,

	@AnotherPrice bigint   ,

	@TotalDepreciation bigint   ,

	@BudgetDepreciation bigint   ,

	@OwnDepreciation bigint   ,

	@VentureDepreciation bigint   ,

	@AnotherDepreciation bigint   ,

	@BudgetRemain bigint   ,

	@OwnRemain bigint   ,

	@VentureRemain bigint   ,

	@AnotherRemain bigint   ,

	@TotalReamain bigint   ,

	@UpDownCode varchar (10)  ,

	@InputDateTime datetime   ,

	@Manufacturer nvarchar (50)  ,

	@Brand nvarchar (50)  ,

	@Model nvarchar (50)  ,

	@Status smallint   ,

	@DueDate datetime   ,

	@Note ntext   ,

	@SeriesNumber nvarchar (10)  ,

	@Condition smallint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Asset]
				SET
					[Id] = @Id
					,[Name] = @Name
					,[AssetGroupId] = @AssetGroupId
					,[UnitId] = @UnitId
					,[Amount] = @Amount
					,[CounPro] = @CounPro
					,[YearPro] = @YearPro
					,[DepartmentUsedId] = @DepartmentUsedId
					,[TotalPrice] = @TotalPrice
					,[BudgetPrice] = @BudgetPrice
					,[OwnPrice] = @OwnPrice
					,[VenturePrice] = @VenturePrice
					,[AnotherPrice] = @AnotherPrice
					,[TotalDepreciation] = @TotalDepreciation
					,[BudgetDepreciation] = @BudgetDepreciation
					,[OwnDepreciation] = @OwnDepreciation
					,[VentureDepreciation] = @VentureDepreciation
					,[AnotherDepreciation] = @AnotherDepreciation
					,[BudgetRemain] = @BudgetRemain
					,[OwnRemain] = @OwnRemain
					,[VentureRemain] = @VentureRemain
					,[AnotherRemain] = @AnotherRemain
					,[TotalReamain] = @TotalReamain
					,[UpDownCode] = @UpDownCode
					,[InputDateTime] = @InputDateTime
					,[Manufacturer] = @Manufacturer
					,[Brand] = @Brand
					,[Model] = @Model
					,[Status] = @Status
					,[DueDate] = @DueDate
					,[Note] = @Note
					,[SeriesNumber] = @SeriesNumber
					,[Condition] = @Condition
				WHERE
[Id] = @OriginalId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Asset_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Asset_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Asset_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Asset table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Asset_Delete
(

	@Id varchar (10)  
)
AS


				DELETE FROM [dbo].[Asset] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Asset_GetByAssetGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Asset_GetByAssetGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Asset_GetByAssetGroupId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Asset table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Asset_GetByAssetGroupId
(

	@AssetGroupId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[Name],
					[AssetGroupId],
					[UnitId],
					[Amount],
					[CounPro],
					[YearPro],
					[DepartmentUsedId],
					[TotalPrice],
					[BudgetPrice],
					[OwnPrice],
					[VenturePrice],
					[AnotherPrice],
					[TotalDepreciation],
					[BudgetDepreciation],
					[OwnDepreciation],
					[VentureDepreciation],
					[AnotherDepreciation],
					[BudgetRemain],
					[OwnRemain],
					[VentureRemain],
					[AnotherRemain],
					[TotalReamain],
					[UpDownCode],
					[InputDateTime],
					[Manufacturer],
					[Brand],
					[Model],
					[Status],
					[DueDate],
					[Note],
					[SeriesNumber],
					[Condition]
				FROM
					[dbo].[Asset]
				WHERE
					[AssetGroupId] = @AssetGroupId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Asset_GetByDepartmentUsedId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Asset_GetByDepartmentUsedId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Asset_GetByDepartmentUsedId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Asset table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Asset_GetByDepartmentUsedId
(

	@DepartmentUsedId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[Name],
					[AssetGroupId],
					[UnitId],
					[Amount],
					[CounPro],
					[YearPro],
					[DepartmentUsedId],
					[TotalPrice],
					[BudgetPrice],
					[OwnPrice],
					[VenturePrice],
					[AnotherPrice],
					[TotalDepreciation],
					[BudgetDepreciation],
					[OwnDepreciation],
					[VentureDepreciation],
					[AnotherDepreciation],
					[BudgetRemain],
					[OwnRemain],
					[VentureRemain],
					[AnotherRemain],
					[TotalReamain],
					[UpDownCode],
					[InputDateTime],
					[Manufacturer],
					[Brand],
					[Model],
					[Status],
					[DueDate],
					[Note],
					[SeriesNumber],
					[Condition]
				FROM
					[dbo].[Asset]
				WHERE
					[DepartmentUsedId] = @DepartmentUsedId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Asset_GetByUnitId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Asset_GetByUnitId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Asset_GetByUnitId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Asset table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Asset_GetByUnitId
(

	@UnitId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[Name],
					[AssetGroupId],
					[UnitId],
					[Amount],
					[CounPro],
					[YearPro],
					[DepartmentUsedId],
					[TotalPrice],
					[BudgetPrice],
					[OwnPrice],
					[VenturePrice],
					[AnotherPrice],
					[TotalDepreciation],
					[BudgetDepreciation],
					[OwnDepreciation],
					[VentureDepreciation],
					[AnotherDepreciation],
					[BudgetRemain],
					[OwnRemain],
					[VentureRemain],
					[AnotherRemain],
					[TotalReamain],
					[UpDownCode],
					[InputDateTime],
					[Manufacturer],
					[Brand],
					[Model],
					[Status],
					[DueDate],
					[Note],
					[SeriesNumber],
					[Condition]
				FROM
					[dbo].[Asset]
				WHERE
					[UnitId] = @UnitId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Asset_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Asset_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Asset_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Asset table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Asset_GetById
(

	@Id varchar (10)  
)
AS


				SELECT
					[Id],
					[Name],
					[AssetGroupId],
					[UnitId],
					[Amount],
					[CounPro],
					[YearPro],
					[DepartmentUsedId],
					[TotalPrice],
					[BudgetPrice],
					[OwnPrice],
					[VenturePrice],
					[AnotherPrice],
					[TotalDepreciation],
					[BudgetDepreciation],
					[OwnDepreciation],
					[VentureDepreciation],
					[AnotherDepreciation],
					[BudgetRemain],
					[OwnRemain],
					[VentureRemain],
					[AnotherRemain],
					[TotalReamain],
					[UpDownCode],
					[InputDateTime],
					[Manufacturer],
					[Brand],
					[Model],
					[Status],
					[DueDate],
					[Note],
					[SeriesNumber],
					[Condition]
				FROM
					[dbo].[Asset]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Asset_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Asset_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Asset_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Asset table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Asset_Find
(

	@SearchUsingOR bit   = null ,

	@Id varchar (10)  = null ,

	@Name nvarchar (50)  = null ,

	@AssetGroupId varchar (10)  = null ,

	@UnitId varchar (10)  = null ,

	@Amount int   = null ,

	@CounPro nvarchar (50)  = null ,

	@YearPro int   = null ,

	@DepartmentUsedId varchar (10)  = null ,

	@TotalPrice bigint   = null ,

	@BudgetPrice bigint   = null ,

	@OwnPrice bigint   = null ,

	@VenturePrice bigint   = null ,

	@AnotherPrice bigint   = null ,

	@TotalDepreciation bigint   = null ,

	@BudgetDepreciation bigint   = null ,

	@OwnDepreciation bigint   = null ,

	@VentureDepreciation bigint   = null ,

	@AnotherDepreciation bigint   = null ,

	@BudgetRemain bigint   = null ,

	@OwnRemain bigint   = null ,

	@VentureRemain bigint   = null ,

	@AnotherRemain bigint   = null ,

	@TotalReamain bigint   = null ,

	@UpDownCode varchar (10)  = null ,

	@InputDateTime datetime   = null ,

	@Manufacturer nvarchar (50)  = null ,

	@Brand nvarchar (50)  = null ,

	@Model nvarchar (50)  = null ,

	@Status smallint   = null ,

	@DueDate datetime   = null ,

	@Note ntext   = null ,

	@SeriesNumber nvarchar (10)  = null ,

	@Condition smallint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [AssetGroupId]
	, [UnitId]
	, [Amount]
	, [CounPro]
	, [YearPro]
	, [DepartmentUsedId]
	, [TotalPrice]
	, [BudgetPrice]
	, [OwnPrice]
	, [VenturePrice]
	, [AnotherPrice]
	, [TotalDepreciation]
	, [BudgetDepreciation]
	, [OwnDepreciation]
	, [VentureDepreciation]
	, [AnotherDepreciation]
	, [BudgetRemain]
	, [OwnRemain]
	, [VentureRemain]
	, [AnotherRemain]
	, [TotalReamain]
	, [UpDownCode]
	, [InputDateTime]
	, [Manufacturer]
	, [Brand]
	, [Model]
	, [Status]
	, [DueDate]
	, [Note]
	, [SeriesNumber]
	, [Condition]
    FROM
	[dbo].[Asset]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([AssetGroupId] = @AssetGroupId OR @AssetGroupId IS NULL)
	AND ([UnitId] = @UnitId OR @UnitId IS NULL)
	AND ([Amount] = @Amount OR @Amount IS NULL)
	AND ([CounPro] = @CounPro OR @CounPro IS NULL)
	AND ([YearPro] = @YearPro OR @YearPro IS NULL)
	AND ([DepartmentUsedId] = @DepartmentUsedId OR @DepartmentUsedId IS NULL)
	AND ([TotalPrice] = @TotalPrice OR @TotalPrice IS NULL)
	AND ([BudgetPrice] = @BudgetPrice OR @BudgetPrice IS NULL)
	AND ([OwnPrice] = @OwnPrice OR @OwnPrice IS NULL)
	AND ([VenturePrice] = @VenturePrice OR @VenturePrice IS NULL)
	AND ([AnotherPrice] = @AnotherPrice OR @AnotherPrice IS NULL)
	AND ([TotalDepreciation] = @TotalDepreciation OR @TotalDepreciation IS NULL)
	AND ([BudgetDepreciation] = @BudgetDepreciation OR @BudgetDepreciation IS NULL)
	AND ([OwnDepreciation] = @OwnDepreciation OR @OwnDepreciation IS NULL)
	AND ([VentureDepreciation] = @VentureDepreciation OR @VentureDepreciation IS NULL)
	AND ([AnotherDepreciation] = @AnotherDepreciation OR @AnotherDepreciation IS NULL)
	AND ([BudgetRemain] = @BudgetRemain OR @BudgetRemain IS NULL)
	AND ([OwnRemain] = @OwnRemain OR @OwnRemain IS NULL)
	AND ([VentureRemain] = @VentureRemain OR @VentureRemain IS NULL)
	AND ([AnotherRemain] = @AnotherRemain OR @AnotherRemain IS NULL)
	AND ([TotalReamain] = @TotalReamain OR @TotalReamain IS NULL)
	AND ([UpDownCode] = @UpDownCode OR @UpDownCode IS NULL)
	AND ([InputDateTime] = @InputDateTime OR @InputDateTime IS NULL)
	AND ([Manufacturer] = @Manufacturer OR @Manufacturer IS NULL)
	AND ([Brand] = @Brand OR @Brand IS NULL)
	AND ([Model] = @Model OR @Model IS NULL)
	AND ([Status] = @Status OR @Status IS NULL)
	AND ([DueDate] = @DueDate OR @DueDate IS NULL)
	AND ([SeriesNumber] = @SeriesNumber OR @SeriesNumber IS NULL)
	AND ([Condition] = @Condition OR @Condition IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [AssetGroupId]
	, [UnitId]
	, [Amount]
	, [CounPro]
	, [YearPro]
	, [DepartmentUsedId]
	, [TotalPrice]
	, [BudgetPrice]
	, [OwnPrice]
	, [VenturePrice]
	, [AnotherPrice]
	, [TotalDepreciation]
	, [BudgetDepreciation]
	, [OwnDepreciation]
	, [VentureDepreciation]
	, [AnotherDepreciation]
	, [BudgetRemain]
	, [OwnRemain]
	, [VentureRemain]
	, [AnotherRemain]
	, [TotalReamain]
	, [UpDownCode]
	, [InputDateTime]
	, [Manufacturer]
	, [Brand]
	, [Model]
	, [Status]
	, [DueDate]
	, [Note]
	, [SeriesNumber]
	, [Condition]
    FROM
	[dbo].[Asset]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([AssetGroupId] = @AssetGroupId AND @AssetGroupId is not null)
	OR ([UnitId] = @UnitId AND @UnitId is not null)
	OR ([Amount] = @Amount AND @Amount is not null)
	OR ([CounPro] = @CounPro AND @CounPro is not null)
	OR ([YearPro] = @YearPro AND @YearPro is not null)
	OR ([DepartmentUsedId] = @DepartmentUsedId AND @DepartmentUsedId is not null)
	OR ([TotalPrice] = @TotalPrice AND @TotalPrice is not null)
	OR ([BudgetPrice] = @BudgetPrice AND @BudgetPrice is not null)
	OR ([OwnPrice] = @OwnPrice AND @OwnPrice is not null)
	OR ([VenturePrice] = @VenturePrice AND @VenturePrice is not null)
	OR ([AnotherPrice] = @AnotherPrice AND @AnotherPrice is not null)
	OR ([TotalDepreciation] = @TotalDepreciation AND @TotalDepreciation is not null)
	OR ([BudgetDepreciation] = @BudgetDepreciation AND @BudgetDepreciation is not null)
	OR ([OwnDepreciation] = @OwnDepreciation AND @OwnDepreciation is not null)
	OR ([VentureDepreciation] = @VentureDepreciation AND @VentureDepreciation is not null)
	OR ([AnotherDepreciation] = @AnotherDepreciation AND @AnotherDepreciation is not null)
	OR ([BudgetRemain] = @BudgetRemain AND @BudgetRemain is not null)
	OR ([OwnRemain] = @OwnRemain AND @OwnRemain is not null)
	OR ([VentureRemain] = @VentureRemain AND @VentureRemain is not null)
	OR ([AnotherRemain] = @AnotherRemain AND @AnotherRemain is not null)
	OR ([TotalReamain] = @TotalReamain AND @TotalReamain is not null)
	OR ([UpDownCode] = @UpDownCode AND @UpDownCode is not null)
	OR ([InputDateTime] = @InputDateTime AND @InputDateTime is not null)
	OR ([Manufacturer] = @Manufacturer AND @Manufacturer is not null)
	OR ([Brand] = @Brand AND @Brand is not null)
	OR ([Model] = @Model AND @Model is not null)
	OR ([Status] = @Status AND @Status is not null)
	OR ([DueDate] = @DueDate AND @DueDate is not null)
	OR ([SeriesNumber] = @SeriesNumber AND @SeriesNumber is not null)
	OR ([Condition] = @Condition AND @Condition is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UpDownReason_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UpDownReason_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UpDownReason_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the UpDownReason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UpDownReason_Get_List

AS


				
				SELECT
					[Id],
					[Name],
					[Type]
				FROM
					[dbo].[UpDownReason]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UpDownReason_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UpDownReason_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UpDownReason_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the UpDownReason table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UpDownReason_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Type]'
				SET @SQL = @SQL + ' FROM [dbo].[UpDownReason]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Type]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[UpDownReason]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UpDownReason_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UpDownReason_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UpDownReason_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the UpDownReason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UpDownReason_Insert
(

	@Id varchar (10)  ,

	@Name nvarchar (50)  ,

	@Type nvarchar (10)  
)
AS


				
				INSERT INTO [dbo].[UpDownReason]
					(
					[Id]
					,[Name]
					,[Type]
					)
				VALUES
					(
					@Id
					,@Name
					,@Type
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UpDownReason_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UpDownReason_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UpDownReason_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the UpDownReason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UpDownReason_Update
(

	@Id varchar (10)  ,

	@OriginalId varchar (10)  ,

	@Name nvarchar (50)  ,

	@Type nvarchar (10)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[UpDownReason]
				SET
					[Id] = @Id
					,[Name] = @Name
					,[Type] = @Type
				WHERE
[Id] = @OriginalId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UpDownReason_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UpDownReason_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UpDownReason_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the UpDownReason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UpDownReason_Delete
(

	@Id varchar (10)  
)
AS


				DELETE FROM [dbo].[UpDownReason] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UpDownReason_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UpDownReason_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UpDownReason_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the UpDownReason table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UpDownReason_GetById
(

	@Id varchar (10)  
)
AS


				SELECT
					[Id],
					[Name],
					[Type]
				FROM
					[dbo].[UpDownReason]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UpDownReason_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UpDownReason_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UpDownReason_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the UpDownReason table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UpDownReason_Find
(

	@SearchUsingOR bit   = null ,

	@Id varchar (10)  = null ,

	@Name nvarchar (50)  = null ,

	@Type nvarchar (10)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [Type]
    FROM
	[dbo].[UpDownReason]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Type] = @Type OR @Type IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [Type]
    FROM
	[dbo].[UpDownReason]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Type] = @Type AND @Type is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RepairAsset_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RepairAsset_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RepairAsset_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the RepairAsset table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RepairAsset_Get_List

AS


				
				SELECT
					[Id],
					[AssetId],
					[DepartmentUsedId],
					[Reason],
					[PartnerId],
					[RepairDate],
					[Fee],
					[Address]
				FROM
					[dbo].[RepairAsset]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RepairAsset_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RepairAsset_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RepairAsset_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the RepairAsset table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RepairAsset_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [AssetId]'
				SET @SQL = @SQL + ', [DepartmentUsedId]'
				SET @SQL = @SQL + ', [Reason]'
				SET @SQL = @SQL + ', [PartnerId]'
				SET @SQL = @SQL + ', [RepairDate]'
				SET @SQL = @SQL + ', [Fee]'
				SET @SQL = @SQL + ', [Address]'
				SET @SQL = @SQL + ' FROM [dbo].[RepairAsset]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [AssetId],'
				SET @SQL = @SQL + ' [DepartmentUsedId],'
				SET @SQL = @SQL + ' [Reason],'
				SET @SQL = @SQL + ' [PartnerId],'
				SET @SQL = @SQL + ' [RepairDate],'
				SET @SQL = @SQL + ' [Fee],'
				SET @SQL = @SQL + ' [Address]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[RepairAsset]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RepairAsset_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RepairAsset_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RepairAsset_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the RepairAsset table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RepairAsset_Insert
(

	@Id varchar (10)  ,

	@AssetId varchar (10)  ,

	@DepartmentUsedId varchar (10)  ,

	@Reason nvarchar (50)  ,

	@PartnerId varchar (10)  ,

	@RepairDate date   ,

	@Fee bigint   ,

	@Address nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[RepairAsset]
					(
					[Id]
					,[AssetId]
					,[DepartmentUsedId]
					,[Reason]
					,[PartnerId]
					,[RepairDate]
					,[Fee]
					,[Address]
					)
				VALUES
					(
					@Id
					,@AssetId
					,@DepartmentUsedId
					,@Reason
					,@PartnerId
					,@RepairDate
					,@Fee
					,@Address
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RepairAsset_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RepairAsset_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RepairAsset_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the RepairAsset table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RepairAsset_Update
(

	@Id varchar (10)  ,

	@OriginalId varchar (10)  ,

	@AssetId varchar (10)  ,

	@DepartmentUsedId varchar (10)  ,

	@Reason nvarchar (50)  ,

	@PartnerId varchar (10)  ,

	@RepairDate date   ,

	@Fee bigint   ,

	@Address nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[RepairAsset]
				SET
					[Id] = @Id
					,[AssetId] = @AssetId
					,[DepartmentUsedId] = @DepartmentUsedId
					,[Reason] = @Reason
					,[PartnerId] = @PartnerId
					,[RepairDate] = @RepairDate
					,[Fee] = @Fee
					,[Address] = @Address
				WHERE
[Id] = @OriginalId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RepairAsset_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RepairAsset_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RepairAsset_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the RepairAsset table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RepairAsset_Delete
(

	@Id varchar (10)  
)
AS


				DELETE FROM [dbo].[RepairAsset] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RepairAsset_GetByAssetId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RepairAsset_GetByAssetId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RepairAsset_GetByAssetId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the RepairAsset table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RepairAsset_GetByAssetId
(

	@AssetId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[AssetId],
					[DepartmentUsedId],
					[Reason],
					[PartnerId],
					[RepairDate],
					[Fee],
					[Address]
				FROM
					[dbo].[RepairAsset]
				WHERE
					[AssetId] = @AssetId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RepairAsset_GetByDepartmentUsedId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RepairAsset_GetByDepartmentUsedId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RepairAsset_GetByDepartmentUsedId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the RepairAsset table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RepairAsset_GetByDepartmentUsedId
(

	@DepartmentUsedId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[AssetId],
					[DepartmentUsedId],
					[Reason],
					[PartnerId],
					[RepairDate],
					[Fee],
					[Address]
				FROM
					[dbo].[RepairAsset]
				WHERE
					[DepartmentUsedId] = @DepartmentUsedId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RepairAsset_GetByPartnerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RepairAsset_GetByPartnerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RepairAsset_GetByPartnerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the RepairAsset table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RepairAsset_GetByPartnerId
(

	@PartnerId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[AssetId],
					[DepartmentUsedId],
					[Reason],
					[PartnerId],
					[RepairDate],
					[Fee],
					[Address]
				FROM
					[dbo].[RepairAsset]
				WHERE
					[PartnerId] = @PartnerId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RepairAsset_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RepairAsset_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RepairAsset_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the RepairAsset table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RepairAsset_GetById
(

	@Id varchar (10)  
)
AS


				SELECT
					[Id],
					[AssetId],
					[DepartmentUsedId],
					[Reason],
					[PartnerId],
					[RepairDate],
					[Fee],
					[Address]
				FROM
					[dbo].[RepairAsset]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RepairAsset_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RepairAsset_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RepairAsset_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the RepairAsset table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RepairAsset_Find
(

	@SearchUsingOR bit   = null ,

	@Id varchar (10)  = null ,

	@AssetId varchar (10)  = null ,

	@DepartmentUsedId varchar (10)  = null ,

	@Reason nvarchar (50)  = null ,

	@PartnerId varchar (10)  = null ,

	@RepairDate date   = null ,

	@Fee bigint   = null ,

	@Address nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [AssetId]
	, [DepartmentUsedId]
	, [Reason]
	, [PartnerId]
	, [RepairDate]
	, [Fee]
	, [Address]
    FROM
	[dbo].[RepairAsset]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([AssetId] = @AssetId OR @AssetId IS NULL)
	AND ([DepartmentUsedId] = @DepartmentUsedId OR @DepartmentUsedId IS NULL)
	AND ([Reason] = @Reason OR @Reason IS NULL)
	AND ([PartnerId] = @PartnerId OR @PartnerId IS NULL)
	AND ([RepairDate] = @RepairDate OR @RepairDate IS NULL)
	AND ([Fee] = @Fee OR @Fee IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [AssetId]
	, [DepartmentUsedId]
	, [Reason]
	, [PartnerId]
	, [RepairDate]
	, [Fee]
	, [Address]
    FROM
	[dbo].[RepairAsset]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([AssetId] = @AssetId AND @AssetId is not null)
	OR ([DepartmentUsedId] = @DepartmentUsedId AND @DepartmentUsedId is not null)
	OR ([Reason] = @Reason AND @Reason is not null)
	OR ([PartnerId] = @PartnerId AND @PartnerId is not null)
	OR ([RepairDate] = @RepairDate AND @RepairDate is not null)
	OR ([Fee] = @Fee AND @Fee is not null)
	OR ([Address] = @Address AND @Address is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.CheckOut_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.CheckOut_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.CheckOut_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the CheckOut table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.CheckOut_Get_List

AS


				
				SELECT
					[Id],
					[AssetId],
					[CheckOutDate],
					[Comment],
					[User],
					[Computer],
					[Status]
				FROM
					[cunghoc3_AssetManager].[CheckOut]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.CheckOut_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.CheckOut_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.CheckOut_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the CheckOut table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.CheckOut_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [AssetId]'
				SET @SQL = @SQL + ', [CheckOutDate]'
				SET @SQL = @SQL + ', [Comment]'
				SET @SQL = @SQL + ', [User]'
				SET @SQL = @SQL + ', [Computer]'
				SET @SQL = @SQL + ', [Status]'
				SET @SQL = @SQL + ' FROM [cunghoc3_AssetManager].[CheckOut]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [AssetId],'
				SET @SQL = @SQL + ' [CheckOutDate],'
				SET @SQL = @SQL + ' [Comment],'
				SET @SQL = @SQL + ' [User],'
				SET @SQL = @SQL + ' [Computer],'
				SET @SQL = @SQL + ' [Status]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [cunghoc3_AssetManager].[CheckOut]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.CheckOut_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.CheckOut_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.CheckOut_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the CheckOut table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.CheckOut_Insert
(

	@Id bigint    OUTPUT,

	@AssetId nvarchar (10)  ,

	@CheckOutDate datetime   ,

	@Comment ntext   ,

	@User nvarchar (50)  ,

	@Computer nvarchar (50)  ,

	@Status smallint   
)
AS


				
				INSERT INTO [cunghoc3_AssetManager].[CheckOut]
					(
					[AssetId]
					,[CheckOutDate]
					,[Comment]
					,[User]
					,[Computer]
					,[Status]
					)
				VALUES
					(
					@AssetId
					,@CheckOutDate
					,@Comment
					,@User
					,@Computer
					,@Status
					)
				
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.CheckOut_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.CheckOut_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.CheckOut_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the CheckOut table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.CheckOut_Update
(

	@Id bigint   ,

	@AssetId nvarchar (10)  ,

	@CheckOutDate datetime   ,

	@Comment ntext   ,

	@User nvarchar (50)  ,

	@Computer nvarchar (50)  ,

	@Status smallint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[cunghoc3_AssetManager].[CheckOut]
				SET
					[AssetId] = @AssetId
					,[CheckOutDate] = @CheckOutDate
					,[Comment] = @Comment
					,[User] = @User
					,[Computer] = @Computer
					,[Status] = @Status
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.CheckOut_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.CheckOut_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.CheckOut_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the CheckOut table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.CheckOut_Delete
(

	@Id bigint   
)
AS


				DELETE FROM [cunghoc3_AssetManager].[CheckOut] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.CheckOut_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.CheckOut_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.CheckOut_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CheckOut table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.CheckOut_GetById
(

	@Id bigint   
)
AS


				SELECT
					[Id],
					[AssetId],
					[CheckOutDate],
					[Comment],
					[User],
					[Computer],
					[Status]
				FROM
					[cunghoc3_AssetManager].[CheckOut]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.CheckOut_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.CheckOut_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.CheckOut_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the CheckOut table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.CheckOut_Find
(

	@SearchUsingOR bit   = null ,

	@Id bigint   = null ,

	@AssetId nvarchar (10)  = null ,

	@CheckOutDate datetime   = null ,

	@Comment ntext   = null ,

	@User nvarchar (50)  = null ,

	@Computer nvarchar (50)  = null ,

	@Status smallint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [AssetId]
	, [CheckOutDate]
	, [Comment]
	, [User]
	, [Computer]
	, [Status]
    FROM
	[cunghoc3_AssetManager].[CheckOut]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([AssetId] = @AssetId OR @AssetId IS NULL)
	AND ([CheckOutDate] = @CheckOutDate OR @CheckOutDate IS NULL)
	AND ([User] = @User OR @User IS NULL)
	AND ([Computer] = @Computer OR @Computer IS NULL)
	AND ([Status] = @Status OR @Status IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [AssetId]
	, [CheckOutDate]
	, [Comment]
	, [User]
	, [Computer]
	, [Status]
    FROM
	[cunghoc3_AssetManager].[CheckOut]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([AssetId] = @AssetId AND @AssetId is not null)
	OR ([CheckOutDate] = @CheckOutDate AND @CheckOutDate is not null)
	OR ([User] = @User AND @User is not null)
	OR ([Computer] = @Computer AND @Computer is not null)
	OR ([Status] = @Status AND @Status is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroupType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroupType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroupType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the AssetGroupType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroupType_Get_List

AS


				
				SELECT
					[Id],
					[Name]
				FROM
					[dbo].[AssetGroupType]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroupType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroupType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroupType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the AssetGroupType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroupType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ' FROM [dbo].[AssetGroupType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [Name]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[AssetGroupType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroupType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroupType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroupType_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the AssetGroupType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroupType_Insert
(

	@Id varchar (10)  ,

	@Name nvarchar (30)  
)
AS


				
				INSERT INTO [dbo].[AssetGroupType]
					(
					[Id]
					,[Name]
					)
				VALUES
					(
					@Id
					,@Name
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroupType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroupType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroupType_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the AssetGroupType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroupType_Update
(

	@Id varchar (10)  ,

	@OriginalId varchar (10)  ,

	@Name nvarchar (30)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[AssetGroupType]
				SET
					[Id] = @Id
					,[Name] = @Name
				WHERE
[Id] = @OriginalId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroupType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroupType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroupType_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the AssetGroupType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroupType_Delete
(

	@Id varchar (10)  
)
AS


				DELETE FROM [dbo].[AssetGroupType] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroupType_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroupType_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroupType_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AssetGroupType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroupType_GetById
(

	@Id varchar (10)  
)
AS


				SELECT
					[Id],
					[Name]
				FROM
					[dbo].[AssetGroupType]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroupType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroupType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroupType_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the AssetGroupType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroupType_Find
(

	@SearchUsingOR bit   = null ,

	@Id varchar (10)  = null ,

	@Name nvarchar (30)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [Name]
    FROM
	[dbo].[AssetGroupType]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [Name]
    FROM
	[dbo].[AssetGroupType]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroup_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroup_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroup_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the AssetGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroup_Get_List

AS


				
				SELECT
					[Id],
					[Name],
					[AssetGroupTypeId]
				FROM
					[dbo].[AssetGroup]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroup_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroup_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroup_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the AssetGroup table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroup_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [AssetGroupTypeId]'
				SET @SQL = @SQL + ' FROM [dbo].[AssetGroup]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [AssetGroupTypeId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[AssetGroup]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroup_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroup_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroup_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the AssetGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroup_Insert
(

	@Id varchar (10)  ,

	@Name nvarchar (50)  ,

	@AssetGroupTypeId varchar (10)  
)
AS


				
				INSERT INTO [dbo].[AssetGroup]
					(
					[Id]
					,[Name]
					,[AssetGroupTypeId]
					)
				VALUES
					(
					@Id
					,@Name
					,@AssetGroupTypeId
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroup_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroup_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroup_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the AssetGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroup_Update
(

	@Id varchar (10)  ,

	@OriginalId varchar (10)  ,

	@Name nvarchar (50)  ,

	@AssetGroupTypeId varchar (10)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[AssetGroup]
				SET
					[Id] = @Id
					,[Name] = @Name
					,[AssetGroupTypeId] = @AssetGroupTypeId
				WHERE
[Id] = @OriginalId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroup_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroup_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroup_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the AssetGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroup_Delete
(

	@Id varchar (10)  
)
AS


				DELETE FROM [dbo].[AssetGroup] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroup_GetByAssetGroupTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroup_GetByAssetGroupTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroup_GetByAssetGroupTypeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AssetGroup table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroup_GetByAssetGroupTypeId
(

	@AssetGroupTypeId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[Name],
					[AssetGroupTypeId]
				FROM
					[dbo].[AssetGroup]
				WHERE
					[AssetGroupTypeId] = @AssetGroupTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroup_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroup_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroup_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AssetGroup table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroup_GetById
(

	@Id varchar (10)  
)
AS


				SELECT
					[Id],
					[Name],
					[AssetGroupTypeId]
				FROM
					[dbo].[AssetGroup]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetGroup_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetGroup_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetGroup_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the AssetGroup table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetGroup_Find
(

	@SearchUsingOR bit   = null ,

	@Id varchar (10)  = null ,

	@Name nvarchar (50)  = null ,

	@AssetGroupTypeId varchar (10)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [AssetGroupTypeId]
    FROM
	[dbo].[AssetGroup]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([AssetGroupTypeId] = @AssetGroupTypeId OR @AssetGroupTypeId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [AssetGroupTypeId]
    FROM
	[dbo].[AssetGroup]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([AssetGroupTypeId] = @AssetGroupTypeId AND @AssetGroupTypeId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetLiquidation_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetLiquidation_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetLiquidation_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the AssetLiquidation table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetLiquidation_Get_List

AS


				
				SELECT
					[Id],
					[AssetId],
					[Amount],
					[DepartmentUsedId],
					[LiDateTime],
					[LiPrice]
				FROM
					[dbo].[AssetLiquidation]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetLiquidation_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetLiquidation_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetLiquidation_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the AssetLiquidation table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetLiquidation_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [AssetId]'
				SET @SQL = @SQL + ', [Amount]'
				SET @SQL = @SQL + ', [DepartmentUsedId]'
				SET @SQL = @SQL + ', [LiDateTime]'
				SET @SQL = @SQL + ', [LiPrice]'
				SET @SQL = @SQL + ' FROM [dbo].[AssetLiquidation]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [AssetId],'
				SET @SQL = @SQL + ' [Amount],'
				SET @SQL = @SQL + ' [DepartmentUsedId],'
				SET @SQL = @SQL + ' [LiDateTime],'
				SET @SQL = @SQL + ' [LiPrice]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[AssetLiquidation]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetLiquidation_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetLiquidation_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetLiquidation_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the AssetLiquidation table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetLiquidation_Insert
(

	@Id varchar (10)  ,

	@AssetId varchar (10)  ,

	@Amount int   ,

	@DepartmentUsedId varchar (10)  ,

	@LiDateTime datetime   ,

	@LiPrice bigint   
)
AS


				
				INSERT INTO [dbo].[AssetLiquidation]
					(
					[Id]
					,[AssetId]
					,[Amount]
					,[DepartmentUsedId]
					,[LiDateTime]
					,[LiPrice]
					)
				VALUES
					(
					@Id
					,@AssetId
					,@Amount
					,@DepartmentUsedId
					,@LiDateTime
					,@LiPrice
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetLiquidation_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetLiquidation_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetLiquidation_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the AssetLiquidation table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetLiquidation_Update
(

	@Id varchar (10)  ,

	@OriginalId varchar (10)  ,

	@AssetId varchar (10)  ,

	@Amount int   ,

	@DepartmentUsedId varchar (10)  ,

	@LiDateTime datetime   ,

	@LiPrice bigint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[AssetLiquidation]
				SET
					[Id] = @Id
					,[AssetId] = @AssetId
					,[Amount] = @Amount
					,[DepartmentUsedId] = @DepartmentUsedId
					,[LiDateTime] = @LiDateTime
					,[LiPrice] = @LiPrice
				WHERE
[Id] = @OriginalId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetLiquidation_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetLiquidation_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetLiquidation_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the AssetLiquidation table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetLiquidation_Delete
(

	@Id varchar (10)  
)
AS


				DELETE FROM [dbo].[AssetLiquidation] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetLiquidation_GetByAssetId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetLiquidation_GetByAssetId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetLiquidation_GetByAssetId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AssetLiquidation table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetLiquidation_GetByAssetId
(

	@AssetId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[AssetId],
					[Amount],
					[DepartmentUsedId],
					[LiDateTime],
					[LiPrice]
				FROM
					[dbo].[AssetLiquidation]
				WHERE
					[AssetId] = @AssetId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetLiquidation_GetByDepartmentUsedId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetLiquidation_GetByDepartmentUsedId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetLiquidation_GetByDepartmentUsedId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AssetLiquidation table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetLiquidation_GetByDepartmentUsedId
(

	@DepartmentUsedId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[AssetId],
					[Amount],
					[DepartmentUsedId],
					[LiDateTime],
					[LiPrice]
				FROM
					[dbo].[AssetLiquidation]
				WHERE
					[DepartmentUsedId] = @DepartmentUsedId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetLiquidation_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetLiquidation_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetLiquidation_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AssetLiquidation table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetLiquidation_GetById
(

	@Id varchar (10)  
)
AS


				SELECT
					[Id],
					[AssetId],
					[Amount],
					[DepartmentUsedId],
					[LiDateTime],
					[LiPrice]
				FROM
					[dbo].[AssetLiquidation]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AssetLiquidation_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AssetLiquidation_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AssetLiquidation_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the AssetLiquidation table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AssetLiquidation_Find
(

	@SearchUsingOR bit   = null ,

	@Id varchar (10)  = null ,

	@AssetId varchar (10)  = null ,

	@Amount int   = null ,

	@DepartmentUsedId varchar (10)  = null ,

	@LiDateTime datetime   = null ,

	@LiPrice bigint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [AssetId]
	, [Amount]
	, [DepartmentUsedId]
	, [LiDateTime]
	, [LiPrice]
    FROM
	[dbo].[AssetLiquidation]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([AssetId] = @AssetId OR @AssetId IS NULL)
	AND ([Amount] = @Amount OR @Amount IS NULL)
	AND ([DepartmentUsedId] = @DepartmentUsedId OR @DepartmentUsedId IS NULL)
	AND ([LiDateTime] = @LiDateTime OR @LiDateTime IS NULL)
	AND ([LiPrice] = @LiPrice OR @LiPrice IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [AssetId]
	, [Amount]
	, [DepartmentUsedId]
	, [LiDateTime]
	, [LiPrice]
    FROM
	[dbo].[AssetLiquidation]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([AssetId] = @AssetId AND @AssetId is not null)
	OR ([Amount] = @Amount AND @Amount is not null)
	OR ([DepartmentUsedId] = @DepartmentUsedId AND @DepartmentUsedId is not null)
	OR ([LiDateTime] = @LiDateTime AND @LiDateTime is not null)
	OR ([LiPrice] = @LiPrice AND @LiPrice is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Audit_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Audit_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Audit_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Audit table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Audit_Get_List

AS


				
				SELECT
					[Id],
					[AssetId],
					[AuditDate],
					[Comment],
					[User],
					[Computer]
				FROM
					[cunghoc3_AssetManager].[Audit]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Audit_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Audit_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Audit_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Audit table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Audit_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [AssetId]'
				SET @SQL = @SQL + ', [AuditDate]'
				SET @SQL = @SQL + ', [Comment]'
				SET @SQL = @SQL + ', [User]'
				SET @SQL = @SQL + ', [Computer]'
				SET @SQL = @SQL + ' FROM [cunghoc3_AssetManager].[Audit]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [AssetId],'
				SET @SQL = @SQL + ' [AuditDate],'
				SET @SQL = @SQL + ' [Comment],'
				SET @SQL = @SQL + ' [User],'
				SET @SQL = @SQL + ' [Computer]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [cunghoc3_AssetManager].[Audit]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Audit_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Audit_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Audit_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Audit table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Audit_Insert
(

	@Id bigint    OUTPUT,

	@AssetId nvarchar (10)  ,

	@AuditDate datetime   ,

	@Comment ntext   ,

	@User nvarchar (50)  ,

	@Computer nvarchar (50)  
)
AS


				
				INSERT INTO [cunghoc3_AssetManager].[Audit]
					(
					[AssetId]
					,[AuditDate]
					,[Comment]
					,[User]
					,[Computer]
					)
				VALUES
					(
					@AssetId
					,@AuditDate
					,@Comment
					,@User
					,@Computer
					)
				
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Audit_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Audit_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Audit_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Audit table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Audit_Update
(

	@Id bigint   ,

	@AssetId nvarchar (10)  ,

	@AuditDate datetime   ,

	@Comment ntext   ,

	@User nvarchar (50)  ,

	@Computer nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[cunghoc3_AssetManager].[Audit]
				SET
					[AssetId] = @AssetId
					,[AuditDate] = @AuditDate
					,[Comment] = @Comment
					,[User] = @User
					,[Computer] = @Computer
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Audit_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Audit_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Audit_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Audit table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Audit_Delete
(

	@Id bigint   
)
AS


				DELETE FROM [cunghoc3_AssetManager].[Audit] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Audit_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Audit_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Audit_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Audit table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Audit_GetById
(

	@Id bigint   
)
AS


				SELECT
					[Id],
					[AssetId],
					[AuditDate],
					[Comment],
					[User],
					[Computer]
				FROM
					[cunghoc3_AssetManager].[Audit]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the cunghoc3_AssetManager.Audit_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'cunghoc3_AssetManager.Audit_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE cunghoc3_AssetManager.Audit_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Audit table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE cunghoc3_AssetManager.Audit_Find
(

	@SearchUsingOR bit   = null ,

	@Id bigint   = null ,

	@AssetId nvarchar (10)  = null ,

	@AuditDate datetime   = null ,

	@Comment ntext   = null ,

	@User nvarchar (50)  = null ,

	@Computer nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [AssetId]
	, [AuditDate]
	, [Comment]
	, [User]
	, [Computer]
    FROM
	[cunghoc3_AssetManager].[Audit]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([AssetId] = @AssetId OR @AssetId IS NULL)
	AND ([AuditDate] = @AuditDate OR @AuditDate IS NULL)
	AND ([User] = @User OR @User IS NULL)
	AND ([Computer] = @Computer OR @Computer IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [AssetId]
	, [AuditDate]
	, [Comment]
	, [User]
	, [Computer]
    FROM
	[cunghoc3_AssetManager].[Audit]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([AssetId] = @AssetId AND @AssetId is not null)
	OR ([AuditDate] = @AuditDate AND @AuditDate is not null)
	OR ([User] = @User AND @User is not null)
	OR ([Computer] = @Computer AND @Computer is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Capital_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Capital_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Capital_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Capital table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Capital_Get_List

AS


				
				SELECT
					[Id],
					[Name],
					[Note]
				FROM
					[dbo].[Capital]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Capital_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Capital_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Capital_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Capital table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Capital_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Note]'
				SET @SQL = @SQL + ' FROM [dbo].[Capital]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Note]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Capital]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Capital_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Capital_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Capital_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Capital table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Capital_Insert
(

	@Id varchar (10)  ,

	@Name nvarchar (50)  ,

	@Note nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[Capital]
					(
					[Id]
					,[Name]
					,[Note]
					)
				VALUES
					(
					@Id
					,@Name
					,@Note
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Capital_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Capital_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Capital_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Capital table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Capital_Update
(

	@Id varchar (10)  ,

	@OriginalId varchar (10)  ,

	@Name nvarchar (50)  ,

	@Note nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Capital]
				SET
					[Id] = @Id
					,[Name] = @Name
					,[Note] = @Note
				WHERE
[Id] = @OriginalId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Capital_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Capital_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Capital_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Capital table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Capital_Delete
(

	@Id varchar (10)  
)
AS


				DELETE FROM [dbo].[Capital] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Capital_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Capital_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Capital_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Capital table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Capital_GetById
(

	@Id varchar (10)  
)
AS


				SELECT
					[Id],
					[Name],
					[Note]
				FROM
					[dbo].[Capital]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Capital_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Capital_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Capital_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Capital table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Capital_Find
(

	@SearchUsingOR bit   = null ,

	@Id varchar (10)  = null ,

	@Name nvarchar (50)  = null ,

	@Note nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [Note]
    FROM
	[dbo].[Capital]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Note] = @Note OR @Note IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [Note]
    FROM
	[dbo].[Capital]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Note] = @Note AND @Note is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.WarrantyAsset_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.WarrantyAsset_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.WarrantyAsset_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the WarrantyAsset table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.WarrantyAsset_Get_List

AS


				
				SELECT
					[Id],
					[AsssetId],
					[DepartmentUsedId],
					[PartnerId],
					[WarDateTime],
					[DeadlineWar],
					[Address],
					[PersonWar]
				FROM
					[dbo].[WarrantyAsset]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.WarrantyAsset_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.WarrantyAsset_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.WarrantyAsset_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the WarrantyAsset table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.WarrantyAsset_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [AsssetId]'
				SET @SQL = @SQL + ', [DepartmentUsedId]'
				SET @SQL = @SQL + ', [PartnerId]'
				SET @SQL = @SQL + ', [WarDateTime]'
				SET @SQL = @SQL + ', [DeadlineWar]'
				SET @SQL = @SQL + ', [Address]'
				SET @SQL = @SQL + ', [PersonWar]'
				SET @SQL = @SQL + ' FROM [dbo].[WarrantyAsset]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [AsssetId],'
				SET @SQL = @SQL + ' [DepartmentUsedId],'
				SET @SQL = @SQL + ' [PartnerId],'
				SET @SQL = @SQL + ' [WarDateTime],'
				SET @SQL = @SQL + ' [DeadlineWar],'
				SET @SQL = @SQL + ' [Address],'
				SET @SQL = @SQL + ' [PersonWar]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[WarrantyAsset]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.WarrantyAsset_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.WarrantyAsset_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.WarrantyAsset_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the WarrantyAsset table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.WarrantyAsset_Insert
(

	@Id varchar (10)  ,

	@AsssetId varchar (10)  ,

	@DepartmentUsedId varchar (10)  ,

	@PartnerId varchar (10)  ,

	@WarDateTime datetime   ,

	@DeadlineWar datetime   ,

	@Address nvarchar (50)  ,

	@PersonWar nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[WarrantyAsset]
					(
					[Id]
					,[AsssetId]
					,[DepartmentUsedId]
					,[PartnerId]
					,[WarDateTime]
					,[DeadlineWar]
					,[Address]
					,[PersonWar]
					)
				VALUES
					(
					@Id
					,@AsssetId
					,@DepartmentUsedId
					,@PartnerId
					,@WarDateTime
					,@DeadlineWar
					,@Address
					,@PersonWar
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.WarrantyAsset_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.WarrantyAsset_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.WarrantyAsset_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the WarrantyAsset table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.WarrantyAsset_Update
(

	@Id varchar (10)  ,

	@OriginalId varchar (10)  ,

	@AsssetId varchar (10)  ,

	@DepartmentUsedId varchar (10)  ,

	@PartnerId varchar (10)  ,

	@WarDateTime datetime   ,

	@DeadlineWar datetime   ,

	@Address nvarchar (50)  ,

	@PersonWar nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[WarrantyAsset]
				SET
					[Id] = @Id
					,[AsssetId] = @AsssetId
					,[DepartmentUsedId] = @DepartmentUsedId
					,[PartnerId] = @PartnerId
					,[WarDateTime] = @WarDateTime
					,[DeadlineWar] = @DeadlineWar
					,[Address] = @Address
					,[PersonWar] = @PersonWar
				WHERE
[Id] = @OriginalId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.WarrantyAsset_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.WarrantyAsset_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.WarrantyAsset_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the WarrantyAsset table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.WarrantyAsset_Delete
(

	@Id varchar (10)  
)
AS


				DELETE FROM [dbo].[WarrantyAsset] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.WarrantyAsset_GetByAsssetId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.WarrantyAsset_GetByAsssetId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.WarrantyAsset_GetByAsssetId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the WarrantyAsset table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.WarrantyAsset_GetByAsssetId
(

	@AsssetId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[AsssetId],
					[DepartmentUsedId],
					[PartnerId],
					[WarDateTime],
					[DeadlineWar],
					[Address],
					[PersonWar]
				FROM
					[dbo].[WarrantyAsset]
				WHERE
					[AsssetId] = @AsssetId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.WarrantyAsset_GetByDepartmentUsedId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.WarrantyAsset_GetByDepartmentUsedId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.WarrantyAsset_GetByDepartmentUsedId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the WarrantyAsset table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.WarrantyAsset_GetByDepartmentUsedId
(

	@DepartmentUsedId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[AsssetId],
					[DepartmentUsedId],
					[PartnerId],
					[WarDateTime],
					[DeadlineWar],
					[Address],
					[PersonWar]
				FROM
					[dbo].[WarrantyAsset]
				WHERE
					[DepartmentUsedId] = @DepartmentUsedId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.WarrantyAsset_GetByPartnerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.WarrantyAsset_GetByPartnerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.WarrantyAsset_GetByPartnerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the WarrantyAsset table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.WarrantyAsset_GetByPartnerId
(

	@PartnerId varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[AsssetId],
					[DepartmentUsedId],
					[PartnerId],
					[WarDateTime],
					[DeadlineWar],
					[Address],
					[PersonWar]
				FROM
					[dbo].[WarrantyAsset]
				WHERE
					[PartnerId] = @PartnerId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.WarrantyAsset_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.WarrantyAsset_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.WarrantyAsset_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the WarrantyAsset table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.WarrantyAsset_GetById
(

	@Id varchar (10)  
)
AS


				SELECT
					[Id],
					[AsssetId],
					[DepartmentUsedId],
					[PartnerId],
					[WarDateTime],
					[DeadlineWar],
					[Address],
					[PersonWar]
				FROM
					[dbo].[WarrantyAsset]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.WarrantyAsset_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.WarrantyAsset_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.WarrantyAsset_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the WarrantyAsset table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.WarrantyAsset_Find
(

	@SearchUsingOR bit   = null ,

	@Id varchar (10)  = null ,

	@AsssetId varchar (10)  = null ,

	@DepartmentUsedId varchar (10)  = null ,

	@PartnerId varchar (10)  = null ,

	@WarDateTime datetime   = null ,

	@DeadlineWar datetime   = null ,

	@Address nvarchar (50)  = null ,

	@PersonWar nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [AsssetId]
	, [DepartmentUsedId]
	, [PartnerId]
	, [WarDateTime]
	, [DeadlineWar]
	, [Address]
	, [PersonWar]
    FROM
	[dbo].[WarrantyAsset]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([AsssetId] = @AsssetId OR @AsssetId IS NULL)
	AND ([DepartmentUsedId] = @DepartmentUsedId OR @DepartmentUsedId IS NULL)
	AND ([PartnerId] = @PartnerId OR @PartnerId IS NULL)
	AND ([WarDateTime] = @WarDateTime OR @WarDateTime IS NULL)
	AND ([DeadlineWar] = @DeadlineWar OR @DeadlineWar IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([PersonWar] = @PersonWar OR @PersonWar IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [AsssetId]
	, [DepartmentUsedId]
	, [PartnerId]
	, [WarDateTime]
	, [DeadlineWar]
	, [Address]
	, [PersonWar]
    FROM
	[dbo].[WarrantyAsset]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([AsssetId] = @AsssetId AND @AsssetId is not null)
	OR ([DepartmentUsedId] = @DepartmentUsedId AND @DepartmentUsedId is not null)
	OR ([PartnerId] = @PartnerId AND @PartnerId is not null)
	OR ([WarDateTime] = @WarDateTime AND @WarDateTime is not null)
	OR ([DeadlineWar] = @DeadlineWar AND @DeadlineWar is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([PersonWar] = @PersonWar AND @PersonWar is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

