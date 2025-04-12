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
create PROCEDURE [dbo].[uspSearchFilmsByActorId] 
    -- Add the parameters for the stored procedure here
    @ActorId int = 0
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
    -- Insert statements for procedure here
    SELECT f.title as Title, f.rating as Rating, f.release_year as Released, a.actor_id as Actor_Id
	from film f
	inner join film_actor fa on f.film_id=fa.film_id
	inner join actor a on fa.actor_id=a.actor_id
	where a.actor_id = @ActorId 
	group by a.actor_id, f.title, f.rating, f.release_year
END