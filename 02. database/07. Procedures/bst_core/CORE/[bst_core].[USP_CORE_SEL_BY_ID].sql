USE [db_tekton_ecommerce]
GO

--  AUTOR                   :   JCASIANO
--  FECHA CREACIÓN          :   18/03/2024
--  DESCRIPCIÓN             :	Table by parent_id
--  REVISIONES              :
--  -----------------------------------------------------------------------------------------------------------------
--  VERSIÓN     FECHA MODIF.            USUARIO             DESCRIPCIÓN
--  -----------------------------------------------------------------------------------------------------------------
--  1.0.0       18/03/2024				JCASIANO			Tekton/Exam: Creation
--********************************************************************************************************************************************/

/*
	TEST:

	exec [bst_core].[USP_ORGANIZATION_CHART_SEL_BY_ID] 0, 100, 0	
*/

CREATE OR ALTER   PROCEDURE [bst_core].[USP_CORE_SEL_BY_ID]
	@OWNER_ID INT,
	@COMPANY_ID INT,

	@CORE_ID INT
AS
BEGIN
	SELECT [OWNER_ID]		  
		  ,[CORE_ID]
		  ,[CORE_NAME]
		  ,[CODE]
		  ,[ORDERING]
		  
		  ,[COLOR]
		  ,[ICON]
		  ,[DATA1]
		  ,[DATA2]
		  ,[ADDITIONAL]
		  ,[OBSERVATION]
		  ,[PARENT_ID]
		  ,CASE WHEN [PARENT_ID] = 0 THEN 'Table' else 'Registro' end CLASS_NAME
		  
		  ,[IS_ACTIVE]
		  ,[HOST]
		  ,[CREATION_USER_ID]
		  ,[CREATION_DATE]
		  ,[UPDATE_USER_ID]
		  ,[UPDATE_DATE]
	FROM [bst_core].[CORE] with(nolock)
	WHERE [OWNER_ID] = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND CORE_ID = @CORE_ID
	
END
