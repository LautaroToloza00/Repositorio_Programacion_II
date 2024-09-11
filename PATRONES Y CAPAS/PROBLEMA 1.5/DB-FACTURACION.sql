CREATE DATABASE FACTURACION
GO
USE FACTURACION
GO

--DDL (LENGUAJE DE DEFINICION DE DATOS)

CREATE TABLE FORMAS_PAGO(
ID INT IDENTITY(1,1),
FORMA_PAGO VARCHAR(75)
CONSTRAINT pk_formas_pago PRIMARY KEY (ID)
)

CREATE TABLE ARTICULOS(
ID INT IDENTITY(1,1),
ARTICULO VARCHAR(75),
PRE_UNITARIO DECIMAL(12,2)
CONSTRAINT pk_articulos PRIMARY KEY (ID)
)

CREATE TABLE FACTURAS(
NRO_FACTURA INT IDENTITY(1,1),
FECHA DATETIME,
id_forma_pago INT,
cliente varchar(75),
CONSTRAINT pk_facturas PRIMARY KEY (NRO_FACTURA),
CONSTRAINT fk_facturas_formas_pago FOREIGN KEY (id_forma_pago)
REFERENCES formas_pago (id)
)


CREATE TABLE DETALLE_FACTURAS(
ID_DETALLE INT ,
NRO_FACTURA INT,
ID_ARTICULO INT,
CANTIDAD INT
CONSTRAINT pk_detalle_facturas PRIMARY KEY (ID_DETALLE,NRO_FACTURA),
CONSTRAINT fk_detalle_facturas_facturas FOREIGN KEY (NRO_FACTURA)
REFERENCES facturas (NRO_FACTURA),
CONSTRAINT fk_detalle_facturas_articulos FOREIGN KEY (ID_ARTICULO)
REFERENCES ARTICULOS (ID)
)

--DML (LENGUAJE DE MANIPULACION DE DATOS)

INSERT INTO FORMAS_PAGO(FORMA_PAGO)
VALUES('Efectivo'),
('Transferencia'),
('Tarjeta de d�bito'),
('Tarjeta de credito');

INSERT INTO ARTICULOS(ARTICULO,PRE_UNITARIO)
VALUES('Silla Gamer',300000),
('Teclado Mec�nico',35000),
('Mouse con luces led',32500),
('Monitor de 24"',78300);

INSERT INTO FACTURAS(FECHA,id_forma_pago,cliente)
VALUES('1/9/2024 13:05:35',1,'Lucas Perez'),
('1/9/2024 15:10:05',4,'Carla Munin'),
('1/9/2024 19:18:00',2,'Paulo Dybala');

INSERT INTO DETALLE_FACTURAS(ID_DETALLE,NRO_FACTURA,ID_ARTICULO,CANTIDAD)
VALUES(1,1,2,1),
(1,2,1,3),
(1,3,1,4),
(2,3,4,5),
(3,3,2,4);


--SP (PROCEDIMIENTOS ALMACENADOS)
GO
CREATE PROCEDURE SP_INSERTAR_MAESTRO
	@id_forma_pago int,
	@cliente varchar(75),
	@id int output
AS
BEGIN
	INSERT INTO FACTURAS(FECHA,ID_FORMA_PAGO,CLIENTE)
	VALUES(GETDATE(),@id_forma_pago,@cliente)
	SET @id = SCOPE_IDENTITY()
END;

GO

CREATE PROCEDURE SP_INSERTAR_DETALLE
	@id_detalle int,
	@nro_factura int,
	@id_articulo int,
	@cantidad int
AS
BEGIN
	--INSERT INTO DETALLES_PRESUPUESTO(ID_DETALLE,ID_PRESUPUESTO,ID_PRODUCTO,CANTIDAD,PRECIO)
	--VALUES (@id_detalle, @presupuesto, @producto, @cantidad, @precio);
	INSERT INTO DETALLE_FACTURAS(ID_DETALLE,NRO_FACTURA,ID_ARTICULO,CANTIDAD)
	VALUES(@id_detalle,@nro_factura,@id_articulo,@cantidad)
END;

GO

CREATE PROCEDURE SP_OBTENER_ARTICULOS
AS
BEGIN
	SELECT ID,ARTICULO,PRE_UNITARIO
	FROM ARTICULOS
END

GO
 --NUEVO PROCEDIMIENTO
CREATE PROCEDURE SP_GUARDAR_ARTICULO
@articulo varchar(75),
@precio decimal(12,2),
@codigo int
AS
BEGIN
	IF @codigo = 0
		BEGIN
			INSERT INTO ARTICULOS(ARTICULO,PRE_UNITARIO)
			VALUES(@articulo,@precio)
		END
	ELSE
		BEGIN
			UPDATE ARTICULOS
			SET ARTICULO = @articulo, PRE_UNITARIO = @precio
			WHERE ID = @codigo
		END
END;

GO

CREATE PROCEDURE SP_ELIMINAR_ARTICULO
@id int
AS
BEGIN 
	DELETE ARTICULOS
	WHERE ID = @id
END

