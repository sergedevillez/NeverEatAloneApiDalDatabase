﻿CREATE PROCEDURE [dbo].[DeleteMeeting]
	@UserId int,
	@MeetingId int
AS
Begin
	DELETE m FROM [Meeting] m
	Left join User_Meeting um ON m.MeetingId = um.MeetingId
	WHERE um.[Role] = 1 and m.MeetingId = @MeetingId
End