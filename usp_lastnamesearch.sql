USE [Sakila]
GO
/****** Object:  StoredProcedure [dbo].[uspSearchForActors_FirstName]    Script Date: 2025-04-12 12:08:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:   	 Maja
-- Create date: 
-- Description:    
ALTER PROCEDURE [dbo].[uspSearchForActors_LastName] 
    -- Add the parameters for the stored procedure here
    @LastName varchar(45) = '',
	@ActorId int = 0
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
    -- Insert statements for procedure here
    SELECT a.first_name as FirstName, a.last_name as LastName, a.actor_id as Actor_Id
	from actor a 
	where a.last_name = @LastName 
	group by a.actor_id, a.first_name, a.last_name
	order by a.actor_id, a.first_name, a.last_name

END