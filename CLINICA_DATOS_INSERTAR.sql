USE CLINICA_ANTHONYRV_BD
GO

--Datos para la tabla de pacientes
INSERT INTO PACIENTES (NOMBRE_PACIENTE, APELLIDO1, APELLIDO2, CEDULA, TELEFONO, CORREO)
	VALUES
	('Juan', 'Gomez', 'Lopez', '1234567890', '555-1234', 'juan.gomez@example.com'),
	('Maria', 'Rodriguez', 'Martinez', '0987654321', '555-5678', 'maria.rodriguez@example.com'),
	('Carlos', 'Perez', 'Garcia', '9876543210', '555-9876', 'carlos.perez@example.com'),
	('Laura', 'Lopez', 'Hernandez', '2345678901', '555-4321', 'laura.lopez@example.com'),
	('Pedro', 'Fernandez', 'Diaz', '8765432109', '555-8765', 'pedro.fernandez@example.com'),
	('Ana', 'Garcia', 'Sanchez', '3456789012', '555-2345', 'ana.garcia@example.com'),
	('Luis', 'Martinez', 'Vargas', '7654321098', '555-7654', 'luis.martinez@example.com'),
	('Marta', 'Hernandez', 'Jimenez', '4567890123', '555-3456', 'marta.hernandez@example.com'),
	('Roberto', 'Diaz', 'Torres', '6543210987', '555-6543', 'roberto.diaz@example.com'),
	('Sofia', 'Sanchez', 'Luna', '5432109876', '555-9876', 'sofia.sanchez@example.com');

 --Datos para la tabla de especialidades
  INSERT INTO ESPECIALIDADES (NOMBRE_ESPECIALIDAD)
	VALUES
	('Dermatologia'),
	('Cardiologia'),
	('Ortopedia'),
	('Oftalmologia'),
	('Ginecologia'),
	('Neurologia'),
	('Odontologia')

--Datos para la tabla de medicos
 INSERT INTO MEDICOS_ESPECIALISTAS (ID_ESPECIALIDAD, NOMBRE_MEDICO, APELLIDO1, APELLIDO2, CEDULA, TELEFONO, CORREO, EXPERIENCIA)
	VALUES
	(1, 'Juan', 'Gomez', 'Lopez', '1234567890', '555-1234', 'juan.gomez@example.com', 5),
	(1, 'Maria', 'Rodriguez', 'Martinez', '0987654321', '555-5678', 'maria.rodriguez@example.com', 7),
	(2, 'Carlos', 'Perez', 'Garcia', '9876543210', '555-9876', 'carlos.perez@example.com', 3),
	(2, 'Laura', 'Lopez', 'Hernandez', '2345678901', '555-4321', 'laura.lopez@example.com', 6),
	(3, 'Pedro', 'Fernandez', 'Diaz', '8765432109', '555-8765', 'pedro.fernandez@example.com', 4),
	(3, 'Ana', 'Garcia', 'Sanchez', '3456789012', '555-2345', 'ana.garcia@example.com', 8),
	(4, 'Luis', 'Martinez', 'Vargas', '7654321098', '555-7654', 'luis.martinez@example.com', 2),
	(4, 'Marta', 'Hernandez', 'Jimenez', '4567890123', '555-3456', 'marta.hernandez@example.com', 9),
	(5, 'Roberto', 'Diaz', 'Torres', '6543210987', '555-6543', 'roberto.diaz@example.com', 6),
	(5, 'Sofia', 'Sanchez', 'Luna', '5432109876', '555-9876', 'sofia.sanchez@example.com', 3),
	(6, 'Eduardo', 'Gonzalez', 'Rios', '8901234567', '555-3210', 'eduardo.gonzalez@example.com', 5),
	(6, 'Patricia', 'Lopez', 'Silva', '2109876543', '555-6789', 'patricia.lopez@example.com', 4),
	(7, 'Mario', 'Ramirez', 'Navarro', '4321098765', '555-8901', 'mario.ramirez@example.com', 7),
	(7, 'Sara', 'Torres', 'Guerra', '6789012345', '555-5678', 'sara.torres@example.com', 6);

--Datos para la tabla de agenda
INSERT INTO AGENDA_WEB (ID_MEDICO, HORA_INICIO, HORA_FIN, ID_ESPECIALIDAD)
VALUES
  (1, '2023-07-01 09:00:00', '2023-07-01 14:00:00', 1),
  (2, '2023-07-01 15:00:00', '2023-07-01 20:00:00', 1),
  (3, '2023-07-01 10:00:00', '2023-07-01 15:00:00', 2),
  (4, '2023-07-01 16:00:00', '2023-07-01 21:00:00', 2),
  (5, '2023-07-01 11:00:00', '2023-07-01 16:00:00', 3),
  (6, '2023-07-01 17:00:00', '2023-07-01 22:00:00', 3),
  (7, '2023-07-01 12:00:00', '2023-07-01 17:00:00', 4),
  (8, '2023-07-01 18:00:00', '2023-07-01 23:00:00', 4),
  (9, '2023-07-01 13:00:00', '2023-07-01 18:00:00', 5),
  (10, '2023-07-01 19:00:00', '2023-07-01 00:00:00', 5),
  (11, '2023-07-01 14:00:00', '2023-07-01 19:00:00', 6),
  (12, '2023-07-01 20:00:00', '2023-07-02 01:00:00', 6),
  (13, '2023-07-01 15:00:00', '2023-07-01 20:00:00', 7),
  (14, '2023-07-01 21:00:00', '2023-07-02 02:00:00', 7);

