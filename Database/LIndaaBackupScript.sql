--Create Database lindaa

USE [lindaa]
GO
/****** Object:  Table [dbo].[custumer]    Script Date: 29-Aug-20 11:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[custumer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](200) NULL,
	[EmailId] [varchar](200) NULL,
	[Addres] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[custumer] ON 
GO
INSERT [dbo].[custumer] ([Id], [FirstName], [EmailId], [Addres]) VALUES (4, N'Rohan1', N'rohan1@gmail.com', N'Rohan1 Addresss')
GO
INSERT [dbo].[custumer] ([Id], [FirstName], [EmailId], [Addres]) VALUES (5, N'Ram1', N'ram1@gmail.com', N'Ram1 Addresss')
GO
INSERT [dbo].[custumer] ([Id], [FirstName], [EmailId], [Addres]) VALUES (6, N'Ram1', N'ram1@gmail.com', N'Ram Addresss')
GO
INSERT [dbo].[custumer] ([Id], [FirstName], [EmailId], [Addres]) VALUES (7, N'ramesh', N'ramesh@gmail.com', N'Ramesh Addresss')
GO
SET IDENTITY_INSERT [dbo].[custumer] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_custumer]    Script Date: 29-Aug-20 11:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec [dbo].[sp_custumer] 'Add','TestName','Testt@gmail.com','TestAddress'


CREATE PROCEDURE [dbo].[sp_custumer]
@mode nvarchar(max),
@Id int = null,
@Name nvarchar(max) = null,
@Emailid nvarchar(max)= null,
@Addres nvarchar(max)=null


AS
BEGIN
	
	set nocount on;

if(@mode='List')
begin

SELECT [Id]
      ,[FirstName]
      ,[EmailId]
      ,[Addres]
  FROM [lindaa].[dbo].[custumer]


end

if(@mode='Add')
BEGIN
INSERT INTO [dbo].[custumer]
           ([FirstName]
           ,[EmailId]
           ,[Addres])
     VALUES
           (@Name
           ,@Emailid
           ,@Addres)

END
    
	if(@mode='GetById')
	begin

		SELECT [Id]
			  ,[FirstName]
			  ,[EmailId]
			  ,[Addres]
		  FROM [lindaa].[dbo].[custumer]
		  Where Id=@Id
	END

	    
	if(@mode='Update')
	BEGIN
	    UPDATE custumer Set 
		FirstName=@Name,
		EmailId = @Emailid,
		Addres = @Addres
		Where Id=@Id
		
	END


	if(@mode='delete')
	BEGIN
	    delete from custumer 
		where id=@Id
	END
END
GO
