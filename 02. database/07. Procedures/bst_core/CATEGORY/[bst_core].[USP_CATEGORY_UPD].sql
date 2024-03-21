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

	exec [bst_core].[USP_CATEGORY_UPD] 0, 100, 0	
*/

CREATE OR ALTER   PROCEDURE [bst_core].[USP_CATEGORY_UPD]
	@OWNER_ID INT,
	@COMPANY_ID INT,

    @CATEGORY_ID int,
    @CODE varchar(10),
    @ORDERING varchar(10),
    @CATEGORY_NAME varchar(100),

	@COLOR varchar(50),
    @ICON varchar(100),
    @DATA1 varchar(100),
    @DATA2 varchar(100),
    @ADDITIONAL varchar(100),
    @OBSERVATION varchar(100),

    @PARENT_ID int,
    @IS_ACTIVE bit,

	@USER_ID int,
    @HOST varchar(50)   

AS
BEGIN

	IF not exists( SELECT 1 FROM [bst_core].[CATEGORY]  
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND CATEGORY_ID = @PARENT_ID ) AND @PARENT_ID > 0
			SELECT 0 AS STATUS, 'El id padre no existe.' MESSAGE
				, '0' ID
	ELSE
	IF exists( SELECT 1 FROM [bst_core].[CATEGORY]  
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND CATEGORY_ID <> @CATEGORY_ID
			AND TRIM(CATEGORY_NAME) = TRIM(@CATEGORY_NAME)  AND PARENT_ID = @PARENT_ID )
			SELECT 0 AS STATUS, 'El nombre ya existe.' MESSAGE
				, '0' ID
	ELSE
	IF exists( SELECT 1 FROM [bst_core].[CATEGORY]  
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND CATEGORY_ID <> @CATEGORY_ID
			AND TRIM(CODE) = TRIM(@CODE) AND PARENT_ID = @PARENT_ID )
			SELECT 0 AS STATUS, 'El código ya existe.' MESSAGE
				, '0' ID
	ELSE
	BEGIN
		UPDATE [bst_core].[CATEGORY] 
			SET 					  
			   [CATEGORY_NAME] = @CATEGORY_NAME
			  ,[CODE] = @CODE
			  ,[ORDERING] = @ORDERING
			  ,[COLOR] = @COLOR
			  ,[ICON] = @ICON
			  ,[DATA1] = @DATA1
			  ,[DATA2] = @DATA2
			  ,[ADDITIONAL] = @ADDITIONAL
			  ,[OBSERVATION] = @OBSERVATION
			  ,[PARENT_ID] = @PARENT_ID		  		  
			  ,[IS_ACTIVE] = @IS_ACTIVE		  
			  ,[UPDATE_USER_ID] = @USER_ID
			  ,[UPDATE_DATE] = GETDATE()
		WHERE [OWNER_ID] = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND CATEGORY_ID = @CATEGORY_ID
			SELECT 1 AS STATUS, 'Registro actualizado '+cast (@CATEGORY_ID as varchar(10) )+'.' MESSAGE
				, cast (@CATEGORY_ID as varchar(10) ) ID
	END

END
