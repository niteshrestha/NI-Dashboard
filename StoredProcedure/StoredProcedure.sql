USE [NIDashboard-Dev]
GO

CREATE PROCEDURE [dbo].[spGetSections]
AS
BEGIN
    SELECT * FROM Sections;
END

GO

CREATE PROCEDURE [dbo].[spCreatePost]
    @Id nvarchar(MAX),
	@Title nvarchar(MAX),
	@Content nvarchar(MAX),
	@Created datetime2(7),
	@Tags nvarchar(MAX),
	@UserId nvarchar(450),
	@SecionId int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [Posts] ([Id], [Title], [Content], [Created], [Tags], [UserId], [SectionId])
	VALUES (@Id, @Title, @Content, @Created, @Tags, @UserId, @SecionId);
END

GO

CREATE PROCEDURE [dbo].[spCreateSection]
	@Title nvarchar(MAX),
	@Description nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [Sections] ([Title], [Description])
	VALUES (@Title, @Description);
END

GO

CREATE PROCEDURE [dbo].[spDeleteSection]
	@sId int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Sections
	WHERE Id = @sId;
END

GO

CREATE PROCEDURE [dbo].[spDeletePost]
	@pId int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Posts
	WHERE Id = @pId;
END

GO

CREATE PROCEDURE [dbo].[spGetLatestPost]
    @n int
AS
BEGIN
    SELECT TOP(@n) [post].[Id], [post].[Created], [post].[SectionId], [post].[Title], [post.Section].[Title] AS [SectionTitle], [t].[FirstName], [t].[LastName]
    FROM [Posts] AS [post]
    LEFT JOIN [Sections] AS [post.Section] ON [post].[SectionId] = [post.Section].[Id]
    LEFT JOIN (
        SELECT [post.User].*
        FROM [AspNetUsers] AS [post.User]
        WHERE [post.User].[Discriminator] = 'ApplicationUser'
    ) AS [t] ON [post].[UserId] = [t].[Id]
    ORDER BY [post].[Created] DESC;
END

GO

CREATE PROCEDURE [dbo].[spGetPostDetail]
    @pId nvarchar(MAX)
AS
BEGIN
    SELECT TOP(1) [post].[Id], [post].[Content], [post].[Created], [post].[SectionId], [post].[Tags], [post].[Title], [post.Section].[Title] AS [SectionTitle], [t].[FirstName], [t].[LastName]
    FROM [Posts] AS [post]
    LEFT JOIN [Sections] AS [post.Section] ON [post].[SectionId] = [post.Section].[Id]
    LEFT JOIN (
        SELECT [post.User].*
        FROM [AspNetUsers] AS [post.User]
        WHERE [post.User].[Discriminator] = 'ApplicationUser'
    ) AS [t] ON [post].[UserId] = [t].[Id]
    WHERE [post].[Id] = @pId;
END

GO