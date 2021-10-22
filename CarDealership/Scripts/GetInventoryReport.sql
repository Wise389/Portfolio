USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetInventoryReport]    Script Date: 9/10/2021 2:31:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetInventoryReport]
    @ConditionID int 
AS
	SELECT v.[Year], ma.MakeName, mo.ModelName, COUNT(*) AS [Count], SUM(v.MSRP) AS 'Stock Value'
	FROM Vehicles AS v
	JOIN Make AS ma ON ma.MakeId = v.MakeId
	JOIN Model AS mo ON mo.ModelId = v.ModelId
	WHERE v.ConditionId = @ConditionID
	GROUP BY v.[Year], ma.MakeName, mo.ModelName

GO

