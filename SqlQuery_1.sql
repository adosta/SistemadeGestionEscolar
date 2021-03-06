﻿CREATE TABLE [dbo].[Alumnoes] (
    [numeroMatricula] [int] NOT NULL IDENTITY,
    [nombre] [nvarchar](max) NOT NULL,
    [apellidoPaterno] [nvarchar](max) NOT NULL,
    [apellidoMaterno] [nvarchar](max) NOT NULL,
    [fechaDeNacimiento] [datetime] NOT NULL,
    [grupoID] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Alumnoes] PRIMARY KEY ([numeroMatricula])
)
CREATE INDEX [IX_grupoID] ON [dbo].[Alumnoes]([grupoID])
CREATE TABLE [dbo].[Grupoes] (
    [grupoID] [int] NOT NULL IDENTITY,
    [nombreGrupo] [nvarchar](max),
    [carrera] [nvarchar](max),
    CONSTRAINT [PK_dbo.Grupoes] PRIMARY KEY ([grupoID])
)
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] [nvarchar](128) NOT NULL,
    [Name] [nvarchar](256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]([Name])
CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] [nvarchar](128) NOT NULL,
    [RoleId] [nvarchar](128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId])
)
CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]([UserId])
CREATE INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]([RoleId])
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] [nvarchar](128) NOT NULL,
    [Email] [nvarchar](256),
    [EmailConfirmed] [bit] NOT NULL,
    [PasswordHash] [nvarchar](max),
    [SecurityStamp] [nvarchar](max),
    [PhoneNumber] [nvarchar](max),
    [PhoneNumberConfirmed] [bit] NOT NULL,
    [TwoFactorEnabled] [bit] NOT NULL,
    [LockoutEndDateUtc] [datetime],
    [LockoutEnabled] [bit] NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [UserName] [nvarchar](256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [UserNameIndex] ON [dbo].[AspNetUsers]([UserName])
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] [int] NOT NULL IDENTITY,
    [UserId] [nvarchar](128) NOT NULL,
    [ClaimType] [nvarchar](max),
    [ClaimValue] [nvarchar](max),
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]([UserId])
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] [nvarchar](128) NOT NULL,
    [ProviderKey] [nvarchar](128) NOT NULL,
    [UserId] [nvarchar](128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey], [UserId])
)
CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]([UserId])
ALTER TABLE [dbo].[Alumnoes] ADD CONSTRAINT [FK_dbo.Alumnoes_dbo.Grupoes_grupoID] FOREIGN KEY ([grupoID]) REFERENCES [dbo].[Grupoes] ([grupoID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AspNetUserClaims] ADD CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AspNetUserLogins] ADD CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201610300238484_Initial', N'SistemadeGestionEscolar.Migrations.Configuration',  0x1F8B0800000000000400DD5D5B6FE3B8157E2FD0FF20E8A92DB2762E9DC134B07791CD651A749C04E3CCA26F035AA21D61244A2B51D904C5FEB27DE84FEA5F282951175E75B16C2B83010689487E3C3CFC489E73C4A3FCEF8FFFCE7E7A097CEB19C68917A2B97D3239B62D889CD0F5D0666EA778FDC307FBA71FFFFCA7D9B51BBC58BF14F5CE683DD2122573FB09E3E87C3A4D9C2718806412784E1C26E11A4F9C309802379C9E1E1FFF637A72328504C226589635FB9C22EC0530FB85FC7A192207463805FE2274A19FB0E7A46499A15A77208049041C38B7975E82C923177E840926C25C274EE8837892B7B4AD0BDF0344AA25F4D7B605100A31A0D5CEBF247089E3106D96117900FCC7D708927A6BE027908DE5BCAADE7658C7A77458D3AA6101E5A4090E838E8027674C4F53B1792F6DDBA51E8926AF89C6F12B1D75A6CDB97DE1A7010A6D4BECEAFCD28F69B526554F7280234B53EDA8A40B6115FD77645DA63E4E63384730C531F08FAC8774E57BCEBFE0EB63F80DA2394A7DBF2E34119B94710FC8A387388C608C5F3FC3351B0A4A0318870B8063CF497D605B531E642AA294183A805C01B7089F9DDAD61D110BAC7C58B2A5A6AC250E633270046380A1FB0030863199EC5B1766FA9644113B0E83550C8BFE0841C9BAB3AD0578F904D1063FCD6DF2A36DDD782FD02D9E3019BE208F2C53D208C72954C868EE1744D0F73D3724021379C3C309B03894006BE83C812B78071C2FF0C86495225C11891EC9E6D4197113A751787BD5441E01E40E3C7B9B8C4B2A38DBFA0CFDAC3479F2A27C5B9B7CA4255F41B6FCC88E771387C1E790F6C0157C7D04F10662224EA82A5D8669EC08E2CCA6D52E61DC3B3EE6B2F5DE3AB2F663D839CA39EBBA63B49CECA1770AA6F8AD178BB92F07C4311173F87EB4642FC9DC9FEE05A1D5742F16432FBA177344814DAC5F94A7F14512DD413C291A4E72C89B98C0FD16C6DF2675C423AB75BB6A659CB65D196727ABF5D98777EF817BF6FEEFF0EC5D9F5572EB765F20B48D963E27A71F76B1A7D3FF0DBD9EBE7B3F48AF5A16131B335673B83EDF5F59B58AC872A9C466459541284DA186A775813A7E6A5349657A2BABD201F559094517FB5E0D85BCBBEDB735E32EA2884C5E462DAA916D1C0F1E690C76C45BD921AF03E0F9036C912D7A214EFDDA8B03588EF2E7901012A0CE323F8024213B84FB4F903CEDDCF45942278D0971971804D1CE7B7B780A11BC4B83155D0FFBEB6BB0A979FC2DBC010E316CAF116DB535DEA7D0F916A6F81AB9D40BFB821DD9296B09308838178E0393E4869019BA97618A7047DF4E71101CDA44B9F48117A86D14615BFD5A54ADEC14750DC956D15453D92B26513F851B0FB513B5A8AA1735AFD1282AABD655540AD64E5256532F6856A151CEBCD66016603643C39B8019ECF86DC0ED0EEFDDBBFE873220B3E9A39DEEFC6CCA7AFA85F8EA4377D56B35649BC0F0AB21831DFF6AC8C4248F9F3D975A252D1CA3A232816F555FED7335AF3941B27D2F076E98FBEE7C3F7B806EB95C2449E878D92AA84780CBA01C2F3A31DF2C63842E1F4319DB23E320BCF6E80947FA2643B1450EDDA32BE8430CAD0B277F9976091287F87B328748DFED8429A3E39530C51B315E9ABF499D1026C398AE59409D9C84AC440F6199F61E72BC08F82655088DBA84A8E960CB3EC4922B184144B715D3D0B7ECBCEC43988126EDCCA635369949A6889AE926D71442AB66980FE4EE857586C09D42B02A1CB71312EAB5D4860CCA38597B12EA35D1A67375F46D4F44D4B846BA396FF2936A5B8E1814DB0B271B1C340D2F9993B013629A35B607729A55D246006D24F91004650E715B0288DEF1D8082AB8E51A8232BB7D2F04E535760082F22A797304CDE3206DE75F088A8C8D9E7C3466FFC7BA515D07E026A78F9151337770481B4C5AC058A6E7D58A16C217AC8800103959102061FE9448110ABE8458BCD650B95582AF31350364F6B7AA3D739C1A9AB368A3D49AB7831B4044129B002BA23780B277E0B25EC405DD41B822606D948E59311D608BE0B211969D3D026C8D8315B6709FA5564779E1455C124DDE7539948A3DD2B26A728A6B18A59CE2FEC88FADC5B8557720E4C137F97C6DBDBEDA1018690D5A303869351CC542D85A29BA972EB262DAF8205DBC90DAC0D8641814D4E0316894540C66702D154BB2594B2A43B88B29BC959604B355A3A56230836B8971B459490A63AC8339B6958A78D369A0C5568431CB53BE2C9B4DF38C02F66036D5A41ECC16208A3CB4A9A522B027D632CF43B8FC61D9FD527E90634C1D4EDBA24D52F684C3186CA0504ABA2692DE787182AF00062B4083B8976E205553DA349A63AFE892375BE4692C4EC0A23EFD995D9C68932CA0300619D20D1969402DCAEC5D598D07BA86164D0E01A487A6ABFC97214568952860C46537F53938F6AC3D8A74EFBE0E271576C75D987017DD7115B7E4EBC88AE2F6D8656CB98EA80D38D3C52A70457216247E4A2E1D4FF7568B81195103AE85DC76EFBE1434ED86D2AF99F9CCE190E9AFF4444C78E5EDF23A56F97034F3AE3B147B4F3BE774759F7D73739DB2A9575DD7B3CACBD6B7CE6F2BD5DBE74F463349B295B083092B9DDAFE93A687D0A9BE0889D495AF0B93E8518AB7267514DD9B94834DA2CECBEB6F6C0841841E564713C26ED61BBB9E5B07608F3A62D46E784A60B5B2F6A8FC25DC3A265FD21E51B8695B87148A3A4859BF4FCB09592FE885A7D1A8BA46FB1EE41BB47574B9B43DB2E22E6D1D5A51DC035B21B358D61E5571DDB60EAC286E8F5DDDBD1537D4119F68DA10CF20475A1E09DDEE4CD360EC66771CE648ACDD6AAC03D51E77C462F7162530F67C94CCD286C50661561E0CDF8E591A0CFD8EC4DD0DE43724E385463D2677E18FDBF44D171EF578DDF8BB5396481132B14AD97B192913226233169D6AFE628714AECAABD856A146C2AD57CAAD09AD3059FEEA5FFA349850555800E4AD09EBF24BAEF6E9F1C9A9F0A18FF17C74639A24AEAF88EEC95FDEE067EBA01FBAF0A8B61B6FA977BCB2CA7FDB023D83D87902F15F02F0F2D7A1BE57310CE8624850ED77255CD20B1EE0BB12D95C496FA66F910B5FE6F67FB236E7D6EDBFBFB26647D67D4C96D0B9756CFD3E542AA72210B5DFCF2DEC90AFDC1716B454E8F115850E58FD3E4CD0633EB6CB7C294624DF43DF226FBF026DE2381D34FD297B7C64DD265F90F76B4A0A1E894229D9C5BCBA61C86F0EE98C34EBBCBD56C9CE9137E5378E2D6798CF45EF244DDE740B697A67A8BFDD05C5A5792B518505D13FAB7BE5E14132BAB7DA6A9559DB5B212A32B387C21B4485BACCEB3E58DAAC6B95C9D266B0EA2CEC3EA26933B0330B60CBFCEBF6DB50D1F280478D22D2B28F2D692796D6B8CE2629CD75AB852EA7B2EED2F0D3444ABECB4CCFC14E474522E760D887A4F64EB2370F96AE59DC90DE6B82E6DE3232B5F7A1BE931CCCB1A45D5617D20F9B6DB9CF044BC37D85EF2AAF720499408ACC82C3674FEE9B6BBA1789234F41EB96233932B2B17C93C36742EE9B6CBA778B23275BA77CC79171ED50E7E78199D6FA083D78F6A29C10204E2B9FDD56D8D195BB2018D8F91BDAB9EDAEA8019E3B1C7999220F4344674E8204CE9EABB0B3A216D0BC2129F5C0172B07917D72499D4FA2EBAC62B9B6C3AA8ABE537D228B343DE28A97E749AC61EEB6DB5899A5621C2CAB63EE5693FE65EA9B1D5CC6BE591D73DF9AA4AA3D246472594C9ACBF10A37B77EF9549D1B3CBA8C4B65BE962AFBB7E16431DD977E4B1996FC249A13999BBC08E37DBBB79450398852B86D417355ECEDE44F0EA29221974E877C49F9D617B1666A7FCD89585489B7A920E8DF7642D0E1EC98B2CE2D5A8785392548545411C2AB0B88814B8C9C8B187B6BE060524C5F10651FC3CB82EEF435E50ABAB7E83EC5518AC99061B0F2B9683535CB4CFD6749A1BCCCB3FB88FE960C310422A6475FACDDA39F53CF774BB96F14015D0D04B5F7D8EB183A9798BE96D9BC964877216A09C4D4579AA98F30887C0296DCA32578867D6423F4FB0437C079ADC2F73A90E689E0D53EBBF2C0260641C230AAF6E457C2613778F9F1FF4C0B7F2CD46C0000 , N'6.1.3-40302')

