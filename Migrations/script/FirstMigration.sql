IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Usuario] (
    [Id_usuario] int NOT NULL IDENTITY,
    [Nome] nvarchar(50) NOT NULL,
    [Sobrenome] nvarchar(50) NOT NULL,
    [Email] nvarchar(50) NOT NULL,
    [Sexo] nvarchar(9) NOT NULL,
    [Senha] nvarchar(12) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id_usuario])
);
GO

CREATE TABLE [Telefone] (
    [Id_tel] int NOT NULL IDENTITY,
    [Id_usuario] int NOT NULL,
    [Celeluar] char(11) NULL,
    CONSTRAINT [PK_Telefone] PRIMARY KEY ([Id_tel]),
    CONSTRAINT [FK_Telefone_Usuario_Id_usuario] FOREIGN KEY ([Id_usuario]) REFERENCES [Usuario] ([Id_usuario]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Telefone_Id_usuario] ON [Telefone] ([Id_usuario]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220112210757_FirstMigration', N'5.0.13');
GO

COMMIT;
GO

