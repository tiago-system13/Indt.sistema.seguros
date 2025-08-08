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

IF SCHEMA_ID(N'idtsistemaseguro') IS NULL EXEC(N'CREATE SCHEMA [idtsistemaseguro];');
GO

CREATE TABLE [idtsistemaseguro].[Tb_Contrato] (
    [Id] uniqueidentifier NOT NULL,
    [DataDeCriacao] DateTime NOT NULL,
    [DataDeAlteracao] DateTime NULL,
    [Numero] int NOT NULL,
    [PropostaId] uniqueidentifier NOT NULL,
    [DataInicial] DateTime NOT NULL,
    [DataFinal] DateTime NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [Prazo] int NOT NULL,
    CONSTRAINT [PK_Tb_Contrato] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [idtsistemaseguro].[Tb_Parcela] (
    [Id] uniqueidentifier NOT NULL,
    [DataDeCriacao] DateTime NOT NULL,
    [DataDeAlteracao] DateTime NULL,
    [Valor] decimal(18,2) NOT NULL,
    [Data] DateTime NOT NULL,
    [Numero] int NOT NULL,
    [ContratoId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Tb_Parcela] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tb_Parcela_Tb_Contrato_ContratoId] FOREIGN KEY ([ContratoId]) REFERENCES [idtsistemaseguro].[Tb_Contrato] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [idtsistemaseguro].[Tb_Proposta] (
    [Id] uniqueidentifier NOT NULL,
    [DataDeCriacao] DateTime NOT NULL,
    [DataDeAlteracao] DateTime NULL,
    [Numero] int NOT NULL,
    [TipoSeguro] int NOT NULL,
    [DataInicio] DateTimeOffset NOT NULL,
    [DataFim] DateTimeOffset NOT NULL,
    [StatusProposta] int NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [Prazo] int NOT NULL,
    [DocumentoCliente] varchar(20) NOT NULL,
    [NomeCliente] varchar(80) NOT NULL,
    [DataNascimentoCliente] DateTime NOT NULL,
    [NumeroEnderecoCliente] int NOT NULL,
    [LogradouroEnderecoCliente] varchar(80) NOT NULL,
    [CepEnderecoCliente] varchar(9) NOT NULL,
    [BairroEnderecoCliente] varchar(60) NOT NULL,
    [CidadeEnderecoCliente] varchar(60) NOT NULL,
    [EstadoEnderecoCliente] varchar(2) NOT NULL,
    [NumeroContatoCliente] varchar(10) NOT NULL,
    [DddContatoCliente] varchar(3) NOT NULL,
    [EmailContatoCliente] varchar(60) NOT NULL,
    [MarcaBem] varchar(30) NOT NULL,
    [AnoFabricacaoBem] varchar(4) NOT NULL,
    [PlacaBem] varchar(10) NOT NULL,
    [CategoriaBem] int NOT NULL,
    [UtilizacaoBem] varchar(255) NOT NULL,
    [CorBem] varchar(20) NOT NULL,
    [ChassiBem] varchar(30) NOT NULL,
    [DescricaoCobertura] varchar(255) NOT NULL,
    [LimiteIdenizacaoCobertura] varchar(80) NOT NULL,
    [PremioCobertura] decimal(18,2) NOT NULL,
    [FranquiaCobertura] bit NOT NULL,
    [ValorFranquiaCobertura] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Tb_Proposta] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tb_Proposta_Tb_Contrato_Id] FOREIGN KEY ([Id]) REFERENCES [idtsistemaseguro].[Tb_Contrato] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Tb_Parcela_ContratoId] ON [idtsistemaseguro].[Tb_Parcela] ([ContratoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250804003718_CriandoTabelaSistemaSeguro', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[idtsistemaseguro].[Tb_Contrato]') AND [c].[name] = N'DataInicial');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [idtsistemaseguro].[Tb_Contrato] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [idtsistemaseguro].[Tb_Contrato] ALTER COLUMN [DataInicial] DateTimeOffset NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[idtsistemaseguro].[Tb_Contrato]') AND [c].[name] = N'DataFinal');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [idtsistemaseguro].[Tb_Contrato] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [idtsistemaseguro].[Tb_Contrato] ALTER COLUMN [DataFinal] DateTimeOffset NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250806233905_AtualizandoBaseDeDados', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [idtsistemaseguro].[Tb_Proposta] DROP CONSTRAINT [FK_Tb_Proposta_Tb_Contrato_Id];
GO

ALTER TABLE [idtsistemaseguro].[Tb_Contrato] ADD CONSTRAINT [FK_Tb_Contrato_Tb_Proposta_Id] FOREIGN KEY ([Id]) REFERENCES [idtsistemaseguro].[Tb_Proposta] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250807142355_AtualizandoRelacionamentoPropostaContrato', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250808163746_AtualizandoRelacionamentoContratoParcelas', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [idtsistemaseguro].[Tb_Contrato] DROP CONSTRAINT [FK_Tb_Contrato_Tb_Proposta_Id];
GO

CREATE UNIQUE INDEX [IX_Tb_Contrato_PropostaId] ON [idtsistemaseguro].[Tb_Contrato] ([PropostaId]);
GO

ALTER TABLE [idtsistemaseguro].[Tb_Contrato] ADD CONSTRAINT [FK_Tb_Contrato_Tb_Proposta_PropostaId] FOREIGN KEY ([PropostaId]) REFERENCES [idtsistemaseguro].[Tb_Proposta] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250808172719_AjustandoRelacionamentoContratoProposta', N'8.0.4');
GO

COMMIT;
GO

