BEGIN TRANSACTION;
CREATE TABLE [TB_ESTADIOS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NULL,
    [Cidade] varchar(200) NULL,
    [Capacidade] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_TB_ESTADIOS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Cidade', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ESTADIOS]'))
    SET IDENTITY_INSERT [TB_ESTADIOS] ON;
INSERT INTO [TB_ESTADIOS] ([Id], [Capacidade], [Cidade], [Nome])
VALUES (1, 82500.0, 'East Rutherford (NY/NJ)', 'MetLife Stadium'),
(2, 70240.0, 'Los Angeles (CA)', 'SoFi Stadium'),
(3, 80000.0, 'Arlington (TX)', 'AT&T Stadium'),
(4, 71000.0, 'Atlanta (GA)', 'Mercedes-Benz Stadium'),
(5, 72220.0, 'Houston (TX)', 'NRG Stadium'),
(6, 68500.0, 'Santa Clara (CA)', 'Levi''s Stadium'),
(7, 68740.0, 'Seattle (WA)', 'Lumen Field'),
(8, 69596.0, 'Philadelphia (PA)', 'Lincoln Financial Field'),
(9, 65326.0, 'Miami (FL)', 'Hard Rock Stadium'),
(10, 76416.0, 'Kansas City (MO)', 'GEHA Field at Arrowhead Stadium'),
(11, 65878.0, 'Foxborough (MA)', 'Gillette Stadium'),
(12, 54500.0, 'Vancouver', 'BC Place'),
(13, 30000.0, 'Toronto', 'BMO Field'),
(14, 87000.0, 'Cidade do México', 'Estadio Azteca'),
(15, 53500.0, 'Monterrey', 'Estadio BBVA'),
(16, 49850.0, 'Guadalajara', 'Estadio Akron');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Cidade', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ESTADIOS]'))
    SET IDENTITY_INSERT [TB_ESTADIOS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260406005502_MigracaoEstadios', N'10.0.5');

COMMIT;
GO

