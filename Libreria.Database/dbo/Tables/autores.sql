CREATE TABLE [dbo].[autores] (
    [id]        INT          IDENTITY (1, 1) NOT NULL,
    [nombre]    VARCHAR (45) NOT NULL,
    [apellidos] VARCHAR (45) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

