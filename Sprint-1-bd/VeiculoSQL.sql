CREATE database Veiculo
USE Veiculo

--Veiculo Area de DML

CREATE TABLE Veiculo
(
	IdVeiculo INT PRIMARY KEY IDENTITY,
	IdFabricante INT FOREIGN KEY REFERENCES Fabricante (IdFabricante),
	Modelo VARCHAR(100) NOT NULL,
	AnoFabricacao VARCHAR(100) NOT NULL,
	Cor VARCHAR(100) NOT NULL,
	Preco CHAR(100) NOT NULL
)

CREATE TABLE Fabricante
(
	IdFabricante INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100) NOT NULL,
	PaisOrigem VARCHAR(100) NOT NULL,
	CPF CHAR (100) NOT NULL
)

--Area do Select

SELECT * FROM Veiculo
SELECT * FROM Fabricante

--Veiculo Area de DDL

INSERT INTO Veiculo (IdFabricante, Modelo, AnoFabricacao, Cor, Preco)
VALUES ('1','BMW iX M60','2021','Preto','800.000')

INSERT INTO Fabricante (Nome, PaisOrigem, CPF)
VALUES ('Karl Rapp','Alemanha','12345678912')

--Veiculo DQL

Select


Fabricante.Nome,
Veiculo.Modelo

FROM Fabricante

Inner Join Veiculo ON Veiculo.IdFabricante = Fabricante.IdFabricante
