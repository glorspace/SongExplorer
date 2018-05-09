DELETE FROM [Status]

SET IDENTITY_INSERT [dbo].[Status] ON
INSERT INTO [dbo].[Status] ([Id], [Name]) VALUES (1, N'Active')
INSERT INTO [dbo].[Status] ([Id], [Name]) VALUES (2, N'Occasional')
INSERT INTO [dbo].[Status] ([Id], [Name]) VALUES (3, N'Retired')
INSERT INTO [dbo].[Status] ([Id], [Name]) VALUES (4, N'Seasonal')
SET IDENTITY_INSERT [dbo].[Status] OFF