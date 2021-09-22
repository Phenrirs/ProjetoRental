USE M_Rental;
GO

INSERT INTO Empresa(nomeEmpresa,Endereco)
VALUES('Rental','Rua. 123Abd')

INSERT INTO Cliente(nomeCliente, sobreNome)
VALUES('João','Cleber'),('Carlos','Magno'),('Lucas','Coelho'),('Saulo','Picolo')

INSERT INTO Marca(nomenclatura)
VALUES('Toyota'),('Chevrolet'),('Jeep'),('Honda')

INSERT INTO Modelo(idMarca,nomeModelo)
VALUES(4,'HR-V'),(2,'Celta'),(2,'Camaro'),(3,'Compass')

INSERT INTO Veiculo(idModelo,idEmpresa,Placa)
VALUES(4,1,'5555'),(3,1,'6666'),(2,1,'4444'),(1,1,'7777')

INSERT INTO Aluguel(idVeiculo,idCliente,Preco,Inicio,Fim)
VALUES(3,1,'200,00','11/08/2020','22/08/2020'),(2,3,'600,00','05/08/2020','15/08/2020'),
(4,2,'400,00','30/08/2020','10/09/2020'),(1,4,'700,00','10/09/2020','20/09/2020')

