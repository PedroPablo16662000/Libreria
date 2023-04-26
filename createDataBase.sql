CREATE DATABASE Libreria;
GO
USE Libreria;
GO
CREATE TABLE autores
(
	id int primary key identity(1,1),
	nombre varchar(45) not null,
	apellidos varchar(45) not null
);
CREATE TABLE editoriales
(
	id int primary key identity(1,1),
	nombre varchar(45) not null,
	sede varchar(45)
);
CREATE TABLE libros
(
	ISBN int primary key identity(1,1),
	editoriales_id int foreign key references editoriales(id),
	titulo varchar(45),
	sinopsis text,
	n_paginas varchar(45)
);
CREATE TABLE autores_has_libros
(
	autores_id int foreign key references autores(id) not null,
	libros_ISBN int foreign key references libros(ISBN) not null
);