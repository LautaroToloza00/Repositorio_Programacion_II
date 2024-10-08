CREATE DATABASE BANCO_DB
GO
USE BANCO_DB
GO

-- DDL (LENGUAJE DE DEFINICIÓN DE DATOS)
CREATE TABLE CLIENTES(
	ID INT IDENTITY(1,1),
	NOMBRE VARCHAR(75) NOT NULL,
	APELLIDO VARCHAR(75) NOT NULL,
	DNI VARCHAR(10) NOT NULL,
	CONSTRAINT pk_clientes PRIMARY KEY (ID)
);

CREATE TABLE TIPOS_CUENTA(
	ID INT IDENTITY(1,1),
	NOMBRE VARCHAR(45) NOT NULL,
	CONSTRAINT pk_tipos_cuenta PRIMARY KEY (ID)
);

CREATE TABLE CUENTAS(
	ID INT IDENTITY(1,1),
	CBU VARCHAR(25) NOT NULL,
	SALDO DECIMAL(18,2) NOT NULL,
	ULTIMO_MOVIMIENTO DATETIME NOT NULL,
	ID_CLIENTE INT,
	ID_TIPO_CUENTA INT,
	CONSTRAINT pk_cuentas PRIMARY KEY (ID),
	CONSTRAINT fk_cuentas_clientes FOREIGN KEY (ID_CLIENTE)
	REFERENCES CLIENTES (ID),
	CONSTRAINT fk_cuentas_tipos_cuenta FOREIGN KEY (ID_TIPO_CUENTA)
	REFERENCES TIPOS_CUENTA (ID)
);

-- INSERT
INSERT INTO CLIENTES(NOMBRE,APELLIDO,DNI)
VALUES( 'PEPE', 'PEPITO', '123456789'),
('Diego', 'Pineda', '23332'),
('ivan', 'jdjdjd', '454747'),
('nombre', 'apellido', '12345'),
('federico', 'ventanal', '43934543'),
('mateo', 'dellacqua', '42854808'),
('Eze', 'Miarka', '33478996'),
('paolo', 'pacheco', '43450796');

INSERT INTO TIPOS_CUENTA(NOMBRE)
VALUES ('CREDITO'),
('DEBITO'),
('CHEQUES'),
('MERCADOOOO');

INSERT INTO CUENTAS(CBU,SALDO,ULTIMO_MOVIMIENTO,ID_CLIENTE, ID_TIPO_CUENTA)
VALUES('12344343',2344.00,'27/08/2020 00:00:00',3,1),
('405817171',1500.50,'27/08/2024 14:09:46',1,1),
('405817171',1500.50,'27/08/2024 21:28:50',1,1),
('sdfsdfadas',0.50,'27/08/2024 12:28:50',7,1),
('agus-asdasda',500.50,'27/08/2024 21:28:50',7,2),
('paolin',700.50,'27/08/2024 05:00:50',8,1),
('968694',150.50,'27/08/2024 08:30:00',3,4),
('papa-123123asf',60.50,'27/08/2024 14:28:50',1,1),
('4056905',1568.59,'27/08/2024 15:40:35',1,1);



-- STORED PROCEDURE (PROCEDIMIENTOS ALMACENADOS)

SELECT * FROM CUENTAS

CREATE PROCEDURE ACTUALIZAR_CUENTAS
@ID INT,
@CBU VARCHAR(100),
@SALDO DECIMAL(18,2),
@ULTIMO_MOVIMIENTO DATETIME,
@TIPO_CUENTA_ID INT
AS
BEGIN
	UPDATE CUENTAS 
	SET CBU = @CBU , 
	ULTIMO_MOVIMIENTO = @ULTIMO_MOVIMIENTO,
	ID_TIPO_CUENTA  = @TIPO_CUENTA_ID
	WHERE ID = @ID
END
--
CREATE PROCEDURE CREAR_CLIENTE
@NOMBRE VARCHAR(100),
@APELLIDO VARCHAR(100),
@DNI VARCHAR(100)
AS
BEGIN
INSERT INTO  CLIENTES(NOMBRE,APELLIDO,
DNI)
VALUES(@NOMBRE,@APELLIDO,
@DNI)
END

CREATE PROCEDURE CREAR_CUENTA
@CBU VARCHAR(100),@SALDO DECIMAL(18,2),
@TIPO_CUENTA_ID INT,
@ULTIMO_MOVIMIENTO DATETIME,
@CLIENTE_ID INT
AS
BEGIN
INSERT INTO  CUENTAS(CBU,SALDO,
ID_TIPO_CUENTA,ULTIMO_MOVIMIENTO,ID_CLIENTE)
VALUES(@CBU,@SALDO,
@TIPO_CUENTA_ID,@ULTIMO_MOVIMIENTO,@CLIENTE_ID)
END

CREATE PROCEDURE OBTENER_CLIENTES
AS
BEGIN
SELECT ID,NOMBRE,APELLIDO,DNI
FROM CLIENTES
END

CREATE PROCEDURE OBTENER_CUENTAS
AS
BEGIN
SELECT CU.ID,CU.CBU,CU.SALDO,TP.NOMBRE,TP.ID 'ID_TIPO_CUENTA',
CU.ULTIMO_MOVIMIENTO,CU.ID_CLIENTE
FROM CUENTAS CU
JOIN TIPOS_CUENTA TP ON TP.ID = CU.ID_TIPO_CUENTA
END

CREATE PROCEDURE OBTENER_TIPOS_CUENTAS
AS
BEGIN
SELECT ID,NOMBRE
FROM TIPOS_CUENTA
END
