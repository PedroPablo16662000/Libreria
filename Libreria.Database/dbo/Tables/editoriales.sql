CREATE TABLE [dbo].[editoriales] (
    [id]     INT          IDENTITY (1, 1) NOT NULL,
    [nombre] VARCHAR (45) NOT NULL,
    [sede]   VARCHAR (45) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

