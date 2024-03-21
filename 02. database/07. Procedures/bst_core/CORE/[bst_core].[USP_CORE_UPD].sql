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

	exec [bst_core].[USP_CORE_UPD] 0, 100, 0	
*/

CREATE OR ALTER   PROCEDURE [bst_core].[USP_CORE_UPD]
	@OWNER_ID INT,
	@COMPANY_ID INT,

    @CORE_ID int,
    @CODE varchar(10),
    @ORDERING varchar(10),
    @CORE_NAME varchar(100),

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

	IF not exists( SELECT 1 FROM [bst_core].[CORE] 
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND CORE_ID = @PARENT_ID ) AND @PARENT_ID > 0
			SELECT 0 AS STATUS, 'El id padre no existe.' MESSAGE
				, '0' ID
	ELSE
	IF exists( SELECT 1 FROM [bst_core].[CORE] 
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND CORE_ID <> @CORE_ID
			AND TRIM(CORE_NAME) = TRIM(@CORE_NAME)  AND PARENT_ID = @PARENT_ID )
			SELECT 0 AS STATUS, 'El nombre ya existe.' MESSAGE
				, '0' ID
	ELSE
	IF exists( SELECT 1 FROM [bst_core].[CORE] 
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND CORE_ID <> @CORE_ID
			AND TRIM(CODE) = TRIM(@CODE) AND PARENT_ID = @PARENT_ID )
			SELECT 0 AS STATUS, 'El código ya existe.' MESSAGE
				, '0' ID
	ELSE
	BEGIN
		UPDATE [bst_core].[CORE]
			SET 					  
			   [CORE_NAME] = @CORE_NAME
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
		WHERE [OWNER_ID] = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND CORE_ID = @CORE_ID
			SELECT 1 AS STATUS, 'Registro actualizado '+cast (@CORE_ID as varchar(10) )+'.' MESSAGE
				, cast (@CORE_ID as varchar(10) ) ID
	END

END
