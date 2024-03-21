USE db_tekton_ecommerce

PRINT (N'Create schema [bst_system]')
GO

IF SCHEMA_ID(N'bst_system') IS NULL
EXEC sp_executesql N'CREATE SCHEMA bst_system'
GO

PRINT (N'Create schema [bst_core]')
GO

IF SCHEMA_ID(N'bst_core') IS NULL
EXEC sp_executesql N'CREATE SCHEMA bst_core'
GO

PRINT (N'Create schema [bst_setting]')
GO
IF SCHEMA_ID(N'bst_setting') IS NULL
EXEC sp_executesql N'CREATE SCHEMA bst_setting'
GO

PRINT (N'Create schema [bst_security]')
GO
IF SCHEMA_ID(N'bst_security') IS NULL
EXEC sp_executesql N'CREATE SCHEMA bst_security'
GO

PRINT (N'Create schema [bst_log]')
GO
IF SCHEMA_ID(N'bst_log') IS NULL
EXEC sp_executesql N'CREATE SCHEMA bst_log'
GO

PRINT (N'Create schema [bst_transactional')
GO
IF SCHEMA_ID(N'bst_transactional') IS NULL
EXEC sp_executesql N'CREATE SCHEMA bst_transactional'
GO
