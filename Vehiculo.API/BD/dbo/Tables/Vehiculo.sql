CREATE TABLE [dbo].[Vehiculo] (
    [id]                  UNIQUEIDENTIFIER NOT NULL,
    [idmodelo]            UNIQUEIDENTIFIER NOT NULL,
    [placa]               VARCHAR (MAX)    NOT NULL,
    [color]               VARCHAR (MAX)    NOT NULL,
    [anio]                INT              NOT NULL,
    [precio]              DECIMAL (18)     NOT NULL,
    [correoPropietario]   VARCHAR (MAX)    NOT NULL,
    [telefonoPropietario] VARCHAR (MAX)    NOT NULL,
    CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Vehiculo_Modelos] FOREIGN KEY ([idmodelo]) REFERENCES [dbo].[Modelos] ([id])
);

