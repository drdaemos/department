﻿CREATE TABLE [dbo].[UserAccounts] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max),
    [Login] [nvarchar](max),
    CONSTRAINT [PK_dbo.UserAccounts] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Schedules] (
    [Id] [int] NOT NULL IDENTITY,
    [Term] [int] NOT NULL,
    [LecturesSum] [int] NOT NULL,
    [LabsSum] [int] NOT NULL,
    [PracticesSum] [int] NOT NULL,
    [ExamWorksSum] [int] NOT NULL,
    [Classroom] [nvarchar](max),
    [Discipline_Id] [int],
    [UserAccount_Id] [int],
    CONSTRAINT [PK_dbo.Schedules] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Discipline_Id] ON [dbo].[Schedules]([Discipline_Id])
CREATE INDEX [IX_UserAccount_Id] ON [dbo].[Schedules]([UserAccount_Id])
CREATE TABLE [dbo].[ScheduleWeeks] (
    [Id] [int] NOT NULL IDENTITY,
    [Lectures] [int] NOT NULL,
    [Labs] [int] NOT NULL,
    [Practices] [int] NOT NULL,
    [ExamWorks] [int] NOT NULL,
    [WeekNumber] [int] NOT NULL,
    [Schedule_Id] [int],
    CONSTRAINT [PK_dbo.ScheduleWeeks] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Schedule_Id] ON [dbo].[ScheduleWeeks]([Schedule_Id])
CREATE TABLE [dbo].[Groups] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max),
    [Course] [int] NOT NULL,
    [Specialty_Id] [int],
    [Schedule_Id] [int],
    CONSTRAINT [PK_dbo.Groups] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Specialty_Id] ON [dbo].[Groups]([Specialty_Id])
CREATE INDEX [IX_Schedule_Id] ON [dbo].[Groups]([Schedule_Id])
CREATE TABLE [dbo].[Specialties] (
    [Id] [int] NOT NULL IDENTITY,
    [GlobalId] [nvarchar](max),
    [Name] [nvarchar](max),
    CONSTRAINT [PK_dbo.Specialties] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Plans] (
    [Id] [int] NOT NULL,
    [File] [nvarchar](max),
    CONSTRAINT [PK_dbo.Plans] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Id] ON [dbo].[Plans]([Id])
CREATE TABLE [dbo].[Disciplines] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max),
    CONSTRAINT [PK_dbo.Disciplines] PRIMARY KEY ([Id])
)
ALTER TABLE [dbo].[Schedules] ADD CONSTRAINT [FK_dbo.Schedules_dbo.Disciplines_Discipline_Id] FOREIGN KEY ([Discipline_Id]) REFERENCES [dbo].[Disciplines] ([Id])
ALTER TABLE [dbo].[Schedules] ADD CONSTRAINT [FK_dbo.Schedules_dbo.UserAccounts_UserAccount_Id] FOREIGN KEY ([UserAccount_Id]) REFERENCES [dbo].[UserAccounts] ([Id])
ALTER TABLE [dbo].[ScheduleWeeks] ADD CONSTRAINT [FK_dbo.ScheduleWeeks_dbo.Schedules_Schedule_Id] FOREIGN KEY ([Schedule_Id]) REFERENCES [dbo].[Schedules] ([Id])
ALTER TABLE [dbo].[Groups] ADD CONSTRAINT [FK_dbo.Groups_dbo.Specialties_Specialty_Id] FOREIGN KEY ([Specialty_Id]) REFERENCES [dbo].[Specialties] ([Id])
ALTER TABLE [dbo].[Groups] ADD CONSTRAINT [FK_dbo.Groups_dbo.Schedules_Schedule_Id] FOREIGN KEY ([Schedule_Id]) REFERENCES [dbo].[Schedules] ([Id])
ALTER TABLE [dbo].[Plans] ADD CONSTRAINT [FK_dbo.Plans_dbo.Specialties_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Specialties] ([Id])
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](255) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId])
)
BEGIN TRY
    EXEC sp_MS_marksystemobject 'dbo.__MigrationHistory'
END TRY
BEGIN CATCH
END CATCH
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201311032219309_Initial', 0x1F8B0800000000000400DD5DCD6EDC3610BE17E83B2C746A0B74D7497B6883758B746D07416B27C8BAE9D1A0257A2D44A2548932EC67EBA18FD45728A95FFE8BA224AF924B118BE47038F3CD7048CE6CFFFBE7DFEDAF8F71B47A80591E26E8D47BB13EF15610F94910A2C3A957E0BBEF7FF27EFDE5EBAFB6E741FCB8FAD8F4FB81F62323517EEADD639CBEDA6C72FF1EC6205FC7A19F25797287D77E126F40906C5E9E9CFCBC79F1620309098FD05AADB61F0A84C318967F903F7709F2618A0B105D26018CF2FA3B69D9975457572086790A7C78EA5D7EDC9DC11464388608AFABFEDEEA751402C2CB1E4677DE2AFDF1D59F39DCE32C41877D0A7008A2EBA71492F63B10E5B0E6FC55FAA32DF3272F29F31B80508209B904392DDE6B974516764E04809F285BE5E24E3DC271F6DAF7132219B623E9FA3B7CE23E904FEFB32485197EFA00EFEAE16F036FB5E1C76DC481ED30660CE580FC0BE11F5E7AABAB228AC06D045B411149EE7192C13710C10C6018BC0718C30CD1B1B05C8134AB3007FD6F330BD1088195B7BA081F61F00744077CDFCE74091E9B2FE49FDEEA4F1412149241382B20CB59F5B779D23F924388E69FF50A3C8487120FC2FC14B5411191111F605476C8EFC3B482E7BA69BC6135BEBAC892F843123183D9F69B6B901D20E9769D183AED9322F30536B79B0E6946FCB53C7F41E0BB8659DC374B0F92A08F8B0CE6FB622C21703B9EC8FB0CF838F42760E7FC11C47F25D9A7F1947611C8F32C49E205D8DB5F107E32DA1CED70D359A76C745C07ADD5F1BD546667E2F64D9614A992CDB245C91FDF223126340FE5E82CCCFD308D42A4F6585DB3923745B3C4A0AACF502E397F3995636D98303AD66635A31C6B09CE2FC8B936AE71BC5F9CC8294EE411C791A15ABE2AE25B980DA4332E9818E8D874A857BB3F27D8575EEE0BC2FB5122D91D51540E2783520A7D7218A26B5561A969BDA9772806457C93BC310AED435DBB11E3D6BBA2886ACDA6E9E6C55BD17D41907E1325B720EA667A36583F8F2D69E1F63E02480935DA70C358490735BE453200A179BA907080514A4E5D63B44EF82F45B618E89BD1751146C74497D9CB5A434C54A706814EDA6402FEC5E8F473D9A1DD36318733940800D339CB0605AFF33C21E0A18C298E261D5BFC72CF51B0B20A252BB18B412991761161CAB64F583AF5BE93E4D93741EB6AE50944E227EBF50B5116CCAACDC2100C53C7A4CE4A3BEEAADDA58F331351D5923B8FC15396C912438519B51810ED08067106428465AB0E114113888C1C08A32CBD01157B4B5F6C39832944D4A08DF2749FB8A52F38A83EA90C408AB8276BF1ACDBA02DD4DA03186D40DE91AEE305A3F90D58B41085EB18D385E4C3F832917C2E7FA0F2D83A168DEEBBE393BD671BA46EE3155BBF1CDCB5AEBC53EBF3DFEA0BB6C16CF6D3568880BBFB734643B581123F8189978059734544BF86309704403BEF2196EF29F794BB6E3756F128AD9827D6AC5B4DA993A42519BAB59A49559B760FB9D224D5746AF3EEE3A7F15F1A663AB7D843886E1F6A1AD536DC33BC332C3511D66205520C74D47266023DA6AFF1E24EDCCD6C83AF76590A4D4B5BA46DC0A520AA20C8D91069B71092780492A5638AC56CA23186F51620063968C22F56001C5E474B403AD52B00620A32ACC20C4BF6ADE20A865667FBA3C520DEECC95230451D36718705DF36B1C66CA6A03C16CA62E88D45ACA311662582EF3348C5147ECC261AF5739EDE93EA4314FB20C56E31F68109434F8C0AACE5D31CE7DB68A46DDB6EAAF4A8FAC376A3C9A3DA5E82340DD181C9ABAABFACF65552D5EEFBFDF094A6B8A2B1F173456653CB6D3B134E327080422B7DE108E04598E5F80C60700BE8FDCC2E88A56E7DB157338D320493B5D76CF3CD30FAEF6AA82ABF6C6D805627CC0BB23E3AA85C2A54AB5E1EBDA2496E200299E2C26C9744458CF4A75DFDE8EA2A8C1D5F7DB1A750E750B124EA4F328DED461081742A97242EA05FD4A3959659131DAD629D5FB5D0AF7EE83CCAADD29AD8F1D59701CA65D39A3815B30D03E835D94D1CADE6A33D1D3EC18925C6B7D853E4139D588A7C8B3D4526E18925C77C5E9C81346781C98C44CE6529E9D91A8A7AF83CC6D2A5A9A8703E14E432C29DE0ADC1B613B035A81E428B4D5A6189B1DF1703EA368E1F8D66E5C1CA02C69A714BDDC99B1C12CE5BD5DF16A355EE843ADE4FE9AE0E6C9C947EEC3C1AEEB230581ADDD739B072242D379731A3152CA72358E9563D6C1EB5565908ECF8EACB6294C19FFF47AB44975360A518D3E063FBD5B9D5C39FFCF5111C734334204C63460D09C7E80D8721CB5EBA0792A566A5B3968CFA319761C2953FED83B233A68C6CED121484E503DADB9C2692B4492796AB162F82862346BC5AB6DD2A9BFE56D18E4AFCEA6B685760B4D4A64086FA567B5998302C783428C48B769BC0D8E0386C21A1BE4D5F80AB50BF162C0B0F33FA08E5AB83F5F66EB1A35860C3F048E1A80786E2041031BC792C0A27C6558FDF4D948F3096E1073F6804564C6F2C8ECA60294D187BA85E95160517F3BAFBF122BD46895DDA68B97D95125E9FB6F54B507FA9BFF4345475F15644020F61409F85F64F3986F19A7658EFFF8E76510829D69A0E9700857730C7D7C927884EBD9727273F09BF15E050C7BFC9F3205A70317FD85A9B29957A604E7D7538AA26400F20F3EF41F64D0C1EBF1D559B3F80D26750C83E8BE0D91AF67282F115EC4E64F8FA751712AAEA75173AAADA75173A52E5FA285C0BFBB0922D1B3AA283B624F4999423CF62226225B22BBE2701F724C81E4344AE4076A1C21D3FA6C6E0916A8397BD31F2A5BE4E3AE3AE109C3DD0ACAA3F621DED2CEA174B684741C0114B0B2FE27481325BC23987248E5900B92437645F2BE8560E334DF90B7F4935B88AC4A920CEF89C3579159C21FB4C9EABF7A2EB396AE08614064997472EC53A4747843909F4B890E8BFCE7A464C0C2B2776ACE453D2AA8A979C4B919D6031484F136142937F27CFD7F368B2C462D949EA6399B7CF6165A76E1030A41B4D8E015DD69A42F93D6FA8CFA07DCBAAE1297DC133ABFE19AD7F80E68F6EF696BFA630D0EAFB7E43C1ED7718966FF39A74B7A3FD2682F006D4DE6088A53CA2AEB485D27D55D2D5CBCFA917DC2644C7D56986E920653B6B0BA08D45D4AA599A56FB29AA58433B4DD56C9A8AF6E89FAEF66AD23C4D1A8F6282B2C962219DF9C9ABE8DA944BA89B430B7955F629CD507D5611A72DFD64D953A6449C6D544DD1B5CB131DA3805353B0695591A82C675C6E61A6C21B48D5734B58F66CA5FD568C1B8E3DBACCCEA596ABAB2BD4FBCBB3E5AAEE6595A2BBEB73BEE54DF8930B63F4C7BAFC2E217F965A6839CB84C43BCCFF7682C4587978E848D0F419047D2ED269FBBC457749136C091C355D84FBD84B884140C2A0D7190EEF808F49B30FF3BCFC4DBA8F202A4897F3F816066FD1BB02A705264B86F16DC4898F066EA6F9CB826F9EE7EDBBB4FCE1B9299640D80CC912E03BF45B114641CBF7857C1FAD234123C2FA929BEA12D3CBEEC3534BE92A11B7321DA15A7C6D207B0DE33422C4F277680F1EA09EB77E19F212DB9E85E0908138AF6974E3C99F047E41FCF8CBFF30488C6A38650000, '5.0.0.net45')
