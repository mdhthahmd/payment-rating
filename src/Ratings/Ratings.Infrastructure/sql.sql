IF SCHEMA_ID(N'rating') IS NULL EXEC(N'CREATE SCHEMA [rating];');
GO


CREATE SEQUENCE [rating].[employerseq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
GO


CREATE SEQUENCE [rating].[paymentseq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
GO


CREATE TABLE [rating].[ranking] (
    [id] int NOT NULL DEFAULT 1,
    [name] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_ranking] PRIMARY KEY ([id])
);
GO


CREATE TABLE [rating].[employers] (
    [id] int NOT NULL,
    [name] nvarchar(200) NOT NULL,
    [points] int NOT NULL,
    [ranking_id] int NOT NULL,
    CONSTRAINT [PK_employers] PRIMARY KEY ([id]),
    CONSTRAINT [FK_employers_ranking_ranking_id] FOREIGN KEY ([ranking_id]) REFERENCES [rating].[ranking] ([id]) ON DELETE CASCADE
);
GO


CREATE TABLE [rating].[payments] (
    [id] int NOT NULL,
    [employer_id] int NOT NULL,
    [contribution_month] datetime2 NOT NULL,
    [due_date] datetime2 NOT NULL,
    [paid_amount] decimal(16,2) NOT NULL,
    [payment_date] datetime2 NOT NULL,
    [status] bit NOT NULL,
    CONSTRAINT [PK_payments] PRIMARY KEY ([id]),
    CONSTRAINT [FK_payments_employers_employer_id] FOREIGN KEY ([employer_id]) REFERENCES [rating].[employers] ([id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_employers_ranking_id] ON [rating].[employers] ([ranking_id]);
GO


CREATE INDEX [IX_payments_employer_id] ON [rating].[payments] ([employer_id]);
GO



