CREATE TABLE [dbo].[Modelos] (
    [id]      UNIQUEIDENTIFIER NOT NULL,
    [idMarca] UNIQUEIDENTIFIER NOT NULL,
    [Nombre]  VARCHAR (MAX)    NOT NULL,
    CONSTRAINT [PK_Modelos] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Modelos_Marcas] FOREIGN KEY ([idMarca]) REFERENCES [dbo].[Marcas] ([id])
);

