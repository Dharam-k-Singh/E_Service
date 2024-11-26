USE [LFZ_EservicePortal]
GO
/****** Object:  StoredProcedure [dbo].[TrackDoc_CU]    Script Date: 11/26/2024 18:51:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TrackDoc_CU]
@TDocId INT,
@SenderOrgName VARCHAR(150),
@DocType INT,
@OtherDocType VARCHAR(150),
@Subject VARCHAR(200),
@DocSummary VARCHAR(200),
@RecipientMailId INT,
@DetailDescp VARCHAR(500),
@DocStatus INT,
@ReqAction INT,
@ActionDate DATE,
@ReceivedDate DATE,
@ReqAttention INT,
@OtherReqAttention VARCHAR(200),
@UploadDoc VARCHAR(200),
@ChangedById INT,
@OutId INT = -1 OUTPUT,
@OutUserMssg VARCHAR(100) = '' OUTPUT,
@OutDevMssg VARCHAR(100) = '' OUTPUT,
@OutIsSuccess BIT = 0 OUTPUT

AS
BEGIN
	
	DECLARE @RoleId TINYINT
	SET @RoleId = (SELECT RoleId FROM Map_UserRole WHERE UDID = @ChangedById)

	IF NOT EXISTS (SELECT 1 FROM M_TrackDocument WHERE TrackDocId = @TDocId)
		BEGIN

				INSERT INTO M_TrackDocument(SenderOrgName, DocType, [Subject], DocSummary, RecipientMailId, ActionDate
											, DetailedDescription, DocumentStatus, RequiredAction, RequiredAttention
											, OtherDocType, OthersReqAttention
											, ReceivedDate, UploadDoc, ChangedBy, CreatedBy, CreatedDate, IsActive)
									VALUES(@SenderOrgName, @DocType, @Subject, @DocSummary, @RecipientMailId, @ActionDate
											, @DetailDescp, @DocStatus, @ReqAction, @ReqAttention
											, @OtherDocType, @OtherReqAttention
											, @ReceivedDate, @UploadDoc, @ChangedById, @ChangedById, GETDATE(), 1)

						SET @OutId = SCOPE_IDENTITY()

						INSERT INTO Map_TrackDoc_History(TrackDocId, RoleId, StatusId, CreatedBy)
								VALUES (@OutId, @RoleId, @DocStatus, @ChangedById)

		END
	ELSE
		BEGIN
				UPDATE M_TrackDocument SET
					 DocumentStatus = CASE 
											WHEN @RoleId = 10 THEN @DocStatus 
											ELSE DocumentStatus 
									  END
				, RequiredAction = CASE 
										WHEN @RoleId != 10 THEN @ReqAction 
										ELSE RequiredAction 
									END
				, ChangedBy = @ChangedById
				, ChangedDate = GETDATE()
				, ModifiedBy = @ChangedById	
				, ModifiedDate = GETDATE()
				WHERE TrackDocId = @TDocId AND IsActive = 1

				INSERT INTO Map_TrackDoc_History(TrackDocId, RoleId, CreatedBy
												, StatusId)
										 VALUES (@TDocId, @RoleId, @ChangedById
												, CASE 
													WHEN @RoleId = 10 THEN @DocStatus
													WHEN @RoleId != 10 THEN @ReqAction
												  END)

				SET @OutId = @TDocId 
		END

		SET @OutUserMssg = 'Document Tracking-Id generated Successfully'
		SET @OutDevMssg = @OutUserMssg
		SET @OutIsSuccess = IIF(@OutId > 0, 1, 0)
END

GO
/****** Object:  StoredProcedure [dbo].[TrackDoc_D]    Script Date: 11/26/2024 18:51:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TrackDoc_D]
@ChangedId INT,
@TrackDocId INT,
@OutId INT = -1 OUTPUT,
@OutUserMssg VARCHAR(100) = '' OUTPUT,
@OutDevMssg VARCHAR(100) = '' OUTPUT,
@OutIsSuccess BIT = 0 OUTPUT
AS
BEGIN
	
	UPDATE M_TrackDocument 
	SET IsActive = 0
	  , ChangedBy = @ChangedId
	  , ChangedDate = GETDATE()
	  , ModifiedBy = @ChangedId
	  , ModifiedDate = GETDATE()
	WHERE TrackDocId = @TrackDocId

	UPDATE Map_TrackDoc_History 
	SET IsActive = 0
      , CreatedBy = @ChangedId
	  , CreatedDate = GETDATE()
	WHERE TrackDocId = @TrackDocId 

	SET @OutId = @TrackDocId
	SET @OutUserMssg = 'Data Removed Successfully'
	SET @OutDevMssg = @OutUserMssg
	SET @OutIsSuccess = 1

END
GO
/****** Object:  StoredProcedure [dbo].[TrackDoc_G_Id]    Script Date: 11/26/2024 18:51:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TrackDoc_G_Id]
@TrackDocId INT
AS
BEGIN
		SET NOCOUNT ON;

		SELECT TrackDocId, SenderOrgName, DocSummary, DocType, docType.LOVName AS DocTypeName
				, OtherDocType, [Subject], RecipientMailId 
				, (SELECT EmailId FROM UserDetails WHERE UDID = RecipientMailId) AS ToMailIds
				, DetailedDescription, DocumentStatus, docStaus.LOVName AS DocStatusName
				, ReceivedDate, RequiredAction, reqAction.LOVName AS ReqActionName, RequiredAttention, OthersReqAttention
				, IIF(td.RequiredAttention = 51, (SELECT EmailId FROM UserDetails WHERE UDID = td.RequiredAttention), reqAtten.LOVName) AS ReqAttentionName, ActionDate
				, UploadDoc, ChangedBy
			
		FROM M_TrackDocument td

		INNER JOIN M_ListOfValues docStaus
		ON DocStaus.LOVId = td.DocumentStatus

		INNER JOIN M_ListOfValues docType
		ON docType.LOVId = td.DocType

		INNER JOIN M_ListOfValues reqAction
		ON reqAction.LOVId = td.RequiredAction
		
		INNER JOIN M_ListOfValues reqAtten 
		ON reqAtten.LOVId = td.RequiredAttention 

		LEFT JOIN UserDetails ud1
		ON ud1.UDID = td.ChangedBy

		WHERE td.IsActive = 1 AND td.TrackDocId = @TrackDocId

END
GO
/****** Object:  StoredProcedure [dbo].[TrackDocHistory_G_Id]    Script Date: 11/26/2024 18:51:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[TrackDocHistory_G_Id]
@TrackDocId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT tdh.TDocHId, tdh.StatusId, lov.LOVName AS StatusName, ud.EmployeeName, tdh.CreatedBy AS ChangedById
		, tdh.CreatedDate
	FROM Map_TrackDoc_History tdh

	INNER JOIN UserDetails ud
	ON ud.UDID = tdh.CreatedBy

	INNER JOIN M_ListOfValues lov
	ON lov.LOVId = tdh.StatusId
	
	WHERE tdh.TrackDocId = @TrackDocId AND tdh.IsActive = 1 AND ud.IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[TrackDocList_G]    Script Date: 11/26/2024 18:51:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TrackDocList_G]
AS
BEGIN
		SET NOCOUNT ON;

		SELECT TrackDocId, SenderOrgName, DocSummary, DocType, docType.LOVName AS DocTypeName
				, OtherDocType, [Subject], RecipientMailId
				, (SELECT EmailId FROM UserDetails WHERE UDID = RecipientMailId) AS ToMailIds
				, DetailedDescription, DocumentStatus, docStaus.LOVName AS DocStatusName
				, ReceivedDate, RequiredAction, reqAction.LOVName AS ReqActionName, RequiredAttention, OthersReqAttention
				, IIF(td.RequiredAttention = 51, (SELECT EmailId FROM UserDetails WHERE UDID = td.RequiredAttention), reqAtten.LOVName) AS ReqAttentionName, ActionDate
				, UploadDoc, ChangedBy
			
		FROM M_TrackDocument td

		INNER JOIN M_ListOfValues docStaus
		ON DocStaus.LOVId = td.DocumentStatus

		INNER JOIN M_ListOfValues docType
		ON docType.LOVId = td.DocType

		INNER JOIN M_ListOfValues reqAction
		ON reqAction.LOVId = td.RequiredAction
		
		INNER JOIN M_ListOfValues reqAtten 
		ON reqAtten.LOVId = td.RequiredAttention 

		LEFT JOIN UserDetails ud1
		ON ud1.UDID = td.ChangedBy

		WHERE td.IsActive = 1

END
GO
