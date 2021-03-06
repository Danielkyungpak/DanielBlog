USE [master]
GO
/****** Object:  Database [DanielBlog]    Script Date: 8/15/2017 9:17:44 AM ******/
CREATE DATABASE [DanielBlog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DanielBlog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DanielBlog.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DanielBlog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DanielBlog_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DanielBlog] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DanielBlog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DanielBlog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DanielBlog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DanielBlog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DanielBlog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DanielBlog] SET ARITHABORT OFF 
GO
ALTER DATABASE [DanielBlog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DanielBlog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DanielBlog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DanielBlog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DanielBlog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DanielBlog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DanielBlog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DanielBlog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DanielBlog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DanielBlog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DanielBlog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DanielBlog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DanielBlog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DanielBlog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DanielBlog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DanielBlog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DanielBlog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DanielBlog] SET RECOVERY FULL 
GO
ALTER DATABASE [DanielBlog] SET  MULTI_USER 
GO
ALTER DATABASE [DanielBlog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DanielBlog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DanielBlog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DanielBlog] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DanielBlog] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DanielBlog', N'ON'
GO
USE [DanielBlog]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blog]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[AuthorGuid] [nvarchar](128) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogComment]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogComment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BlogID] [int] NOT NULL,
	[ParentCommentID] [int] NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_BlogComment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 8/15/2017 9:17:44 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 8/15/2017 9:17:44 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 8/15/2017 9:17:44 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 8/15/2017 9:17:44 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 8/15/2017 9:17:44 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 8/15/2017 9:17:44 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/****** Object:  StoredProcedure [dbo].[Blog_Delete]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Blog_Delete]
	@ID int
As
Delete [dbo].[Blog]
Where [ID] = @ID


GO
/****** Object:  StoredProcedure [dbo].[Blog_Insert]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Blog_Insert]
	@ID int Output
	,@Title nvarchar(100)
	,@Content nvarchar(max)
	,@AuthorGuid nvarchar(128)
As
	Declare @Today datetime = GetUTCDate()
	Insert dbo.[Blog] (
		[Title]
		,[Content]
		,[AuthorGuid]
		,[DateCreated]
		,[DateModified]
	)
	Values (
	@Title
	, @Content
	, @AuthorGuid
	, @Today
	, @Today
	);

	Set @ID = SCOPE_IDENTITY()

Return 0

GO
/****** Object:  StoredProcedure [dbo].[Blog_SelectAll]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Blog_SelectAll]
As
Select
		[ID]
		,[Title]
		,[Content]
		,[AuthorGuid]
		,[DateCreated]
		,[DateModified]
		From [dbo].[Blog]
GO
/****** Object:  StoredProcedure [dbo].[Blog_SelectById]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Blog_SelectById]
	@Id int
As

Select * from dbo.Blog
where @Id = id
GO
/****** Object:  StoredProcedure [dbo].[Blog_Update]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Blog_Update]
	@ID int
	,@Title nvarchar(100)
	,@Content nvarchar(max)
As
	Declare @Today datetime = GetUTCDate()

	Update	[dbo].[Blog]
	Set		[Title] = @Title
			,[Content] = @Content
			,[DateModified] = @Today
	Where ID = @ID

GO
/****** Object:  StoredProcedure [dbo].[BlogComment_Delete]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[BlogComment_Delete]
	@ID int
As
	Delete	[dbo].[BlogComment]
	Where	[ID] = @ID



GO
/****** Object:  StoredProcedure [dbo].[BlogComment_Insert]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[BlogComment_Insert]
	@ID int Output
	,@BlogID int
	,@ParentCommentID int = null
	,@Title nvarchar(100)
	,@Content nvarchar(max)
	,@UserName nvarchar(100)
As
/*
Declare 
	@ID int
	,@BlogID int
	,@ParentCommentID int
	,@Title nvarchar(100)
	,@Content nvarchar(max)
	,@UserName nvarchar(100)

Exec dbo.BlogComment_Insert
	@ID Output
	, @BlogID = 1
	, @ParentCommentId = null
	, @Title = 'First Comment Title'
	, @Content = 'First Comment Content'
	, @UserName = 'Daniel'

*/
	Declare @Today datetime = GetUTCDate()
	Insert [dbo].[BlogComment] (
		[BlogID]
		,[ParentCommentID]
		,[Title]
		,[Content]
		,[UserName]
		,[DateCreated]
		,[DateModified]
	)
	Values (
	@BlogID
	, @ParentCommentId
	, @Title
	, @Content
	, @UserName
	, @Today
	, @Today
	);

	Set @ID = SCOPE_IDENTITY()


GO
/****** Object:  StoredProcedure [dbo].[BlogComment_SelectByBlogId]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[BlogComment_SelectByBlogId]
	@BlogID int
As
	Select	[ID]
			,[BlogID]
			,[ParentCommentID]
			,[Title]
			,[Content]
			,[UserName]
			,[DateCreated]
			,[DateModified]
	From	[dbo].[BlogComment]
	Where	[BlogID] = @BlogID 
	AND		[ParentCommentId] is null

GO
/****** Object:  StoredProcedure [dbo].[BlogComment_SelectById]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[BlogComment_SelectById]
	@Id int
As
	Select	[ID]
			,[Title]
			,[Content]
	From	[dbo].[BlogComment]
	Where	Id = @Id


GO
/****** Object:  StoredProcedure [dbo].[BlogComment_SelectByParentCommentId]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[BlogComment_SelectByParentCommentId]
	@ParentCommentId int
As
	Select	[ID]
			,[BlogID]
			,[ParentCommentId]
			,[Title]
			,[Content]
			,[UserName]
			,[DateCreated]
			,[DateModified]
	From	[dbo].[BlogComment]
	Where	[ParentCommentId] = @ParentCommentId

Return 0

GO
/****** Object:  StoredProcedure [dbo].[BlogComment_Update]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[BlogComment_Update]
	@ID int
	,@Title nvarchar(100)
	,@Content nvarchar(max)
As
	Declare @Today datetime = GetUTCDate()
	Update	[dbo].[BlogComment]
	Set		[Title] = @Title
			,[Content] = @Content
			,[DateModified] = @Today
	Where	ID = @ID


GO
/****** Object:  StoredProcedure [dbo].[People_Delete]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[People_Delete]
	@Id int


As
/*
Exec people_delete
@ID = 1

select * from people
*/
Begin
Delete people
where Id = @Id
End

GO
/****** Object:  StoredProcedure [dbo].[People_Insert]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[People_Insert]
	@Id int output
	,@FirstName nvarchar(50)
	,@LastName nvarchar(50)

As
/*

Declare
@Id int
,@firstName nvarchar(50) = 'Daniel'
,@LastName nvarchar(50) = 'Pak'

Exec people_insert
@ID Output
,@FirstName
,@LastName
*/
Begin
Insert people (
[FirstName]
,[LastName]
)
Values (
@FirstName
,@LastName
)
Set @Id = scope_Identity()
End

GO
/****** Object:  StoredProcedure [dbo].[People_SelectAll]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[People_SelectAll]
As
/*
Exec people_selectall

*/
Begin
Select * from people

End

GO
/****** Object:  StoredProcedure [dbo].[People_SelectById]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[People_SelectById]
@Id int
As
/*
Exec people_selectById
@Id = 2

*/
Begin
Select * from people
where Id = @Id

End

GO
/****** Object:  StoredProcedure [dbo].[People_Update]    Script Date: 8/15/2017 9:17:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[People_Update]
	@Id int output
	,@FirstName nvarchar(50)
	,@LastName nvarchar(50)

As
/*

Exec people_update
@ID = 1
,@FirstName ='jeffrey'
,@LastName = 'chin'

select * from people
*/
Begin
Update people
Set [FirstName] = @FirstName
	,[LastName] = @LastName
	where Id = @Id

End

GO
USE [master]
GO
ALTER DATABASE [DanielBlog] SET  READ_WRITE 
GO
