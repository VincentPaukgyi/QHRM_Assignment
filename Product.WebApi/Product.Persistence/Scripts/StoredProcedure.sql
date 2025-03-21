USE [ProductDb]
GO
/****** Object:  StoredProcedure [dbo].[CreateProduct]    Script Date: 19/03/2025 17:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[CreateProduct]
	-- Add the parameters for the stored procedure here
	@id Uniqueidentifier,
	@name nvarchar(max),
	@description nvarchar(max),
	@price decimal(18,2),
	@createdDate datetime
AS
BEGIN
	SET NOCOUNT ON;

   INSERT INTO Products VALUES (@id, @name, @description, @price, @createdDate,null);
   SELECT @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductById]    Script Date: 19/03/2025 17:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[DeleteProductById]
	-- Add the parameters for the stored procedure here
	@id uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;
	 
  DELETE Products
   WHERE Id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProduct]    Script Date: 19/03/2025 17:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[GetAllProduct]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	SET NOCOUNT ON;
	 
   SELECT Id, Name, Description, Price, CreatedDate, UpdatedDate 
   FROM Products
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductById]    Script Date: 19/03/2025 17:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[GetProductById]
	-- Add the parameters for the stored procedure here
	@id uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;
	 
   SELECT Id, Name, Description, Price, CreatedDate, UpdatedDate 
   FROM Products
   WHERE Id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 19/03/2025 17:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[UpdateProduct]
	-- Add the parameters for the stored procedure here
	@id Uniqueidentifier,
	@name nvarchar(max),
	@description nvarchar(max),
	@price decimal(18,2),
	@updatedDate datetime
AS
BEGIN
	SET NOCOUNT ON;

   UPDATE Products
   SET Name=@name,
   description=@description,
   Price=@price,
   UpdatedDate=@updatedDate
   WHERE Id=@id
   SELECT @id;
END
GO
