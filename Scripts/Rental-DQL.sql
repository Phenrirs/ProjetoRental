--DQL M_Rental

USE M_Rental

SELECT * FROM Veiculo

--listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro
SELECT Inicio,Fim,nomeCliente,nomeModelo FROM Aluguel
RIGHT JOIN Cliente
ON Aluguel.idCliente = Cliente.idCliente
RIGHT JOIN Veiculo
ON Aluguel.idVeiculo = Veiculo.idVeiculo
RIGHT JOIN Modelo
ON Veiculo.idModelo = Modelo.idModelo

SELECT * FROM Aluguel
RIGHT JOIN Cliente
ON Aluguel.idCliente = Cliente.idCliente
RIGHT JOIN Veiculo
ON Aluguel.idVeiculo = Veiculo.idVeiculo
RIGHT JOIN Modelo
ON Veiculo.idModelo = Modelo.idModelo

--listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro
SELECT Preco,Inicio,Fim,nomeCliente FROM Aluguel
INNER JOIN Cliente
ON Aluguel.idCliente = Cliente.idCliente
WHERE Cliente.idCliente = 3;

SELECT * FROM Aluguel

--Aqui o apelido nos ids serviu para delimitar a quantidade de ids que se repetem referentes a mesma tabela, como por exemplo a Empresa e a Modelo!
SELECT idVeiculo, Mo.idModelo, Em.idEmpresa, Placa, nomeModelo, nomeEmpresa, Endereco FROM Veiculo V
RIGHT JOIN Modelo Mo ON V.idModelo = Mo.idModelo
RIGHT JOIN Empresa Em ON V.idEmpresa = Em.idEmpresa






