
/****** Object:  StoredProcedure [dbo].[M_LOC_G]    Script Date: 9/24/2024 3:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC M_LOC_G 4

ALTER PROCEDURE [dbo].[M_LOC_G] 
@RequestTypeId INT
AS
BEGIN
	
	IF @RequestTypeId = 52 
		BEGIN
			SELECT CategoryID,CategoryName
			FROM M_CategorySubCategory
			WHERE CategoryID IN (105,108,118,128,134,140,145,150,154,171,186,192,197) AND IsActive=1
		END
	ELSE
		BEGIN
			SELECT CategoryID,CategoryName
			FROM M_CategorySubCategory
			WHERE RequestTypeId=@RequestTypeId OR CategoryID IN (186,192,197) AND IsActive=1
		END
	


END
































