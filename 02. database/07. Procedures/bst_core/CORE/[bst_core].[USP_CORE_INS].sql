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

	exec [bst_core].[USP_CORE_INS] 0, 100, 0	
*/

CREATE OR ALTER   PROCEDURE [bst_core].[USP_CORE_INS]
	@OWNER_ID INT,
	@COMPANY_ID INT,
	    
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
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID
			AND TRIM(CORE_NAME) = TRIM(@CORE_NAME) AND PARENT_ID = @PARENT_ID  )
			SELECT 0 AS STATUS, 'El nombre ya existe.' MESSAGE
				, '0' ID
	ELSE
	IF exists( SELECT 1 FROM [bst_core].[CORE] 
		WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID 
			AND TRIM(CODE) = TRIM(@CODE) AND PARENT_ID = @PARENT_ID )
			SELECT 0 AS STATUS, 'El código ya existe.' MESSAGE
				, '0' ID
	ELSE
	BEGIN

		DECLARE @CORE_ID INT, @MY_CODE VARCHAR(10),
				@CONSECUTIVE varchar(10) = '', @CORRELATIVE int = 0, @ID INT = 0

		set @CORE_ID = ISNULL( (SELECT max(CORE_ID) FROM [bst_core].[CORE] 
				WHERE OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND PARENT_ID = @PARENT_ID 
				), 0+@PARENT_ID ) + CASE WHEN @PARENT_ID = 0 THEN 1000 ELSE 1 END 

		if @PARENT_ID != 0 and @CODE = ''
		begin
			SET @MY_CODE = ISNULL( (
									select CODE from [bst_core].[CORE] 
									where OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID AND CORE_ID = @PARENT_ID
								), '' )

			-- generamos el correlativo
			set @CORRELATIVE = ISNULL(  ( select max( substring( CODE, len(@MY_CODE)+1, 3  ) ) from [bst_core].[CORE]  
					where 
						OWNER_ID = @OWNER_ID AND COMPANY_ID = @COMPANY_ID
						AND PARENT_ID = @PARENT_ID and 
							isnumeric( 
									substring( CODE, len(@MY_CODE)+1, 3  )   ) = 1
							), 0 )

			set @CORRELATIVE = @CORRELATIVE + 1
			set @CONSECUTIVE = right( '000'+CAST( @CORRELATIVE as varchar(3) ),  3 )
		 
			set @CODE = @MY_CODE + @CONSECUTIVE
		end    

		INSERT INTO [bst_core].[CORE]
		( [OWNER_ID], COMPANY_ID
			  , [CORE_ID], [CORE_NAME], [CODE], [ORDERING]

			  , [COLOR], [ICON], [DATA1], [DATA2], [ADDITIONAL], [OBSERVATION], [PARENT_ID]
		  
			  , [IS_ACTIVE], [HOST], [CREATION_USER_ID], [CREATION_DATE] )
		SELECT
			@OWNER_ID, @COMPANY_ID
				, @CORE_ID, @CORE_NAME, @CODE, @ORDERING

			  , @COLOR, @ICON, @DATA1, @DATA2, @ADDITIONAL, @OBSERVATION, @PARENT_ID		  		  

			  , 1, @HOST, @USER_ID, GETDATE() 
	
			SELECT 1 AS STATUS, 'Registro correcto '+cast (@CORE_ID as varchar(10) )+'.' MESSAGE
			, cast (@CORE_ID as varchar(10) ) ID
	END
END
