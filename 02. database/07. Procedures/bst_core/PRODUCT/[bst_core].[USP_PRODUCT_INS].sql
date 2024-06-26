USE [db_tekton_ecommerce]
GO

--  AUTOR                   :   JCASIANO
--  FECHA CREACIÓN          :   18/03/2024
--  DESCRIPCIÓN             :	Table by product
--  REVISIONES              :
--  -----------------------------------------------------------------------------------------------------------------
--  VERSIÓN     FECHA MODIF.            USUARIO             DESCRIPCIÓN
--  -----------------------------------------------------------------------------------------------------------------
--  1.0.0       18/03/2024				JCASIANO			Tekton/Exam: Creation
--********************************************************************************************************************************************/

/*
	TEST:

	exec [bst_core].[USP_PRODUCT_INS] 0, 100, 0	
*/

CREATE OR ALTER   PROCEDURE [bst_core].[USP_PRODUCT_INS]
	@OWNER_ID INT,
	@COMPANY_ID INT,
	    
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

	@USER_ID int,
    @HOST varchar(50)   

AS
BEGIN

	IF not exists( SELECT 1 FROM [bst_core].[CORE] 
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND CORE_ID = @BRAND_ID ) AND @BRAND_ID > 0
			SELECT 0 AS STATUS, 'El id de marca no existe.' MESSAGE
				, '0' ID
	ELSE
	IF exists( SELECT 1 FROM [bst_core].[PRODUCT] 
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID
			AND TRIM(PRODUCT_NAME) = TRIM(@PRODUCT_NAME)  )
			SELECT 0 AS STATUS, 'El nombre ya existe.' MESSAGE
				, '0' ID
	ELSE
	IF exists( SELECT 1 FROM [bst_core].[PRODUCT] 
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID 
			AND TRIM(CODE) = TRIM(@CODE) ) AND @CODE != ''
			SELECT 0 AS STATUS, 'El código ya existe.' MESSAGE
				, '0' ID
	ELSE
	BEGIN

		DECLARE @PRODUCT_ID INT

		set @PRODUCT_ID = ISNULL( (SELECT max(PRODUCT_ID) FROM [bst_core].[PRODUCT] 
				WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID ) , 0)+ 1

		INSERT INTO [bst_core].[PRODUCT]
		( [OWNER_ID], COMPANY_ID
			  , [PRODUCT_ID], [CODE], [EXTERNAL_CODE], [PRODUCT_NAME], [PRODUCT_DESCRIPTION] 
			  
			  , [ORDERING]

			  , [BARCODE], [BRAND_ID], [CATEGORY_ID], [SUBCATEGORY_ID], [STOCK], [PRICE]

			  , [COLOR], [ICON], [DATA1], [DATA2], [ADDITIONAL], [OBSERVATION], [STATUS]
		  
			  , [IS_ACTIVE], [HOST], [CREATION_USER_ID], [CREATION_DATE] )
		SELECT
			@OWNER_ID, @COMPANY_ID
				, @PRODUCT_ID, @CODE, @EXTERNAL_CODE, @PRODUCT_NAME, @PRODUCT_DESCRIPTION
				
				, @ORDERING

				, @BARCODE, @BRAND_ID, @CATEGORY_ID, @SUBCATEGORY_ID, @STOCK, @PRICE

			  , @COLOR, @ICON, @DATA1, @DATA2, @ADDITIONAL, @OBSERVATION, @STATUS

			  , 1, @HOST, @USER_ID, GETDATE() 
	
			SELECT 1 AS STATUS, 'Registro correcto '+cast (@PRODUCT_ID as varchar(10) )+'.' MESSAGE
			, cast (@PRODUCT_ID as varchar(10) ) ID
	END
END
