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

CREATE TABLE [Profissionais] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(40) NOT NULL,
    [CNPJ] int NOT NULL,
    [Registro] nvarchar(30) NOT NULL,
    [Telefone] nvarchar(15) NOT NULL,
    [DataNasc] date NOT NULL,
    [Cidade] nvarchar(20) NOT NULL,
    [Especialidade] nvarchar(40) NOT NULL,
    [Email] nvarchar(40) NOT NULL,
    [Senha] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Profissionais] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(40) NOT NULL,
    [CPF] int NOT NULL,
    [Cidade] nvarchar(30) NOT NULL,
    [Telefone] nvarchar(15) NOT NULL,
    [DataNasc] date NOT NULL,
    [Orientacao] nvarchar(20) NOT NULL,
    [Email] nvarchar(40) NOT NULL,
    [Senha] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220109180203_FirstMigration', N'6.0.1');
GO

COMMIT;
GO

