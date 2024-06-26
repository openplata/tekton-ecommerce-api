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

CREATE OR ALTER   PROCEDURE [bst_core].[USP_PRODUCT_UPD]
	@OWNER_ID INT,
	@COMPANY_ID INT,

    @PRODUCT_ID int,
    @CODE varchar(10),
	@EXTERNAL_CODE varchar(50),
	@PRODUCT_NAME varchar(100),
	@PRODUCT_DESCRIPTION varchar(100),

    @ORDERING varchar(10),
    
	@BARCODE varchar(50),
	@BRAND_ID INT,
	@CATEGORY_ID INT,
	@SUBCATEGORY_ID INT,

	@STOCK INT,
	@PRICE DECIMAL(11, 2),

	@COLOR varchar(50),
    @ICON varchar(100),
    @DATA1 varchar(100),
    @DATA2 varchar(100),
    @ADDITIONAL varchar(100),
    @OBSERVATION varchar(100),
	
	@STATUS smallint,

    @IS_ACTIVE bit,

	@USER_ID int,
    @HOST varchar(50)   

AS
BEGIN

	IF not exists( SELECT 1 FROM [bst_core].[CORE] 
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND CORE_ID = @BRAND_ID ) AND @BRAND_ID > 0
			SELECT 0 AS STATUS, 'El id marca no existe.' MESSAGE
				, '0' ID
	ELSE
	IF exists( SELECT 1 FROM [bst_core].[PRODUCT] 
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND PRODUCT_ID <> @PRODUCT_ID
			AND TRIM(PRODUCT_NAME) = TRIM(@PRODUCT_NAME) )
			SELECT 0 AS STATUS, 'El nombre ya existe.' MESSAGE
				, '0' ID
	ELSE
	IF exists( SELECT 1 FROM [bst_core].[PRODUCT] 
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND PRODUCT_ID <> @PRODUCT_ID
			AND TRIM(CODE) = TRIM(@CODE) )
			SELECT 0 AS STATUS, 'El código ya existe.' MESSAGE
				, '0' ID
	ELSE
	BEGIN
		UPDATE [bst_core].[PRODUCT]
			SET 					  
			   [CODE] = @CODE
			  ,[EXTERNAL_CODE] = @EXTERNAL_CODE
			  ,[PRODUCT_NAME] = @PRODUCT_NAME
			  ,[PRODUCT_DESCRIPTION] = @PRODUCT_DESCRIPTION

			  ,[ORDERING] = @ORDERING

			  ,[BARCODE] = @BARCODE
			  ,[BRAND_ID] = @BRAND_ID
			  ,[CATEGORY_ID] = @CATEGORY_ID
			  ,[SUBCATEGORY_ID] = @SUBCATEGORY_ID

			  ,[STOCK] = @STOCK
			  ,[PRICE] = @PRICE

			  ,[COLOR] = @COLOR
			  ,[ICON] = @ICON
			  ,[DATA1] = @DATA1
			  ,[DATA2] = @DATA2
			  ,[ADDITIONAL] = @ADDITIONAL
			  ,[OBSERVATION] = @OBSERVATION

			  ,[STATUS] = @STATUS 
			  
			  ,[IS_ACTIVE] = @IS_ACTIVE		  
			  ,[UPDATE_USER_ID] = @USER_ID
			  ,[UPDATE_DATE] = GETDATE()
		WHERE [OWNER_ID] = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND PRODUCT_ID = @PRODUCT_ID

		SELECT 1 AS STATUS, 'Registro actualizado '+cast (@PRODUCT_ID as varchar(10) )+'.' MESSAGE
				, cast (@PRODUCT_ID as varchar(10) ) ID
	END

END
