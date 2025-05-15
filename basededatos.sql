-- Usuarios
CREATE TABLE Usuarios (
  idUsuario INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL,
  apellidos VARCHAR(100) NOT NULL,
  correo VARCHAR(100) NOT NULL UNIQUE,
  contrasena VARCHAR(255) NOT NULL,
  rol ENUM('Administrador','Operativo') NOT NULL DEFAULT 'Operativo',
  fechaNacimiento DATE NOT NULL,
  telefonoCasa VARCHAR(20),
  telefonoCelular VARCHAR(20)
) ENGINE=InnoDB;

-- Hoteles
CREATE TABLE Hoteles (
  idHotel INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(100) NOT NULL,
  pais VARCHAR(50) NOT NULL,
  estado VARCHAR(50) NOT NULL,
  ciudad VARCHAR(50) NOT NULL,
  direccion VARCHAR(150) NOT NULL,
  numeroPisos INT NOT NULL,
  caracteristicas TEXT,
  amenidades TEXT,
  cantidadAmenidades INT,
  zonaTuristica ENUM('Si','No') NOT NULL DEFAULT 'No',
  frentePlaya ENUM('Si','No') NOT NULL DEFAULT 'No',
  cantidadPiscinas INT NOT NULL DEFAULT 0,
  salonesEventos ENUM('Si','No') NOT NULL DEFAULT 'No',
  idUsuarioRegistra INT NOT NULL,
  fechaRegistro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (idUsuarioRegistra) REFERENCES Usuarios(idUsuario)
    ON UPDATE CASCADE
    ON DELETE RESTRICT
) ENGINE=InnoDB;

-- Habitaciones
CREATE TABLE Habitaciones (
  idHabitacion INT AUTO_INCREMENT PRIMARY KEY,
  idHotel INT NOT NULL,
  numero VARCHAR(10) NOT NULL,
  tipo VARCHAR(50) NOT NULL,
  precio DECIMAL(10,2) NOT NULL,
  estado VARCHAR(20) NOT NULL,
  numeroCamas INT NOT NULL,
  tipoCama ENUM('individual','matrimonial','queen size','king size') NOT NULL,
  precioNochePersona DECIMAL(10,2) NOT NULL,
  capacidadPersonas INT NOT NULL,
  nivelHabitacion ENUM('Estandar','De Lujo','Suite','Otros') NOT NULL,
  ubicacion ENUM('Frente a Piscina','Frente al Jardin','Frente a la Playa','Otros') NOT NULL,
  caracteristicas TEXT,
  amenidades TEXT,
  fechaRegistro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  idUsuarioRegistra INT NOT NULL,
  FOREIGN KEY (idHotel) REFERENCES Hoteles(idHotel)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  FOREIGN KEY (idUsuarioRegistra) REFERENCES Usuarios(idUsuario)
    ON UPDATE CASCADE
    ON DELETE RESTRICT
) ENGINE=InnoDB;

-- Clientes
CREATE TABLE Clientes (
  idCliente INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL,
  apellidos VARCHAR(100) NOT NULL,
  correo VARCHAR(100) NOT NULL UNIQUE,
  telefono VARCHAR(20) NOT NULL
) ENGINE=InnoDB;

-- Reservaciones
CREATE TABLE Reservaciones (
  idReservacion INT AUTO_INCREMENT PRIMARY KEY,
  idCliente INT NOT NULL,
  idHabitacion INT NOT NULL,
  fechaInicio DATE NOT NULL,
  fechaFin DATE NOT NULL,
  estado VARCHAR(20) NOT NULL,
  FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  FOREIGN KEY (idHabitacion) REFERENCES Habitaciones(idHabitacion)
    ON UPDATE CASCADE
    ON DELETE RESTRICT
) ENGINE=InnoDB;

-- Cancelaciones
CREATE TABLE Cancelaciones (
  idCancelacion INT AUTO_INCREMENT PRIMARY KEY,
  idReservacion INT NOT NULL UNIQUE,
  fecha DATE NOT NULL,
  hora TIME NOT NULL,
  idUsuario INT NOT NULL,
  FOREIGN KEY (idReservacion) REFERENCES Reservaciones(idReservacion)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
  FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
    ON UPDATE CASCADE
    ON DELETE RESTRICT
) ENGINE=InnoDB;

-- Ventas
CREATE TABLE Ventas (
  idVenta INT AUTO_INCREMENT PRIMARY KEY,
  idReservacion INT NOT NULL,
  fecha DATE NOT NULL,
  hora TIME NOT NULL,
  idUsuario INT NOT NULL,
  idHotel INT NOT NULL,
  idHabitacion INT NOT NULL,
  FOREIGN KEY (idReservacion) REFERENCES Reservaciones(idReservacion)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  FOREIGN KEY (idHotel) REFERENCES Hoteles(idHotel)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  FOREIGN KEY (idHabitacion) REFERENCES Habitaciones(idHabitacion)
    ON UPDATE CASCADE
    ON DELETE RESTRICT
) ENGINE=InnoDB;

-- Reportes
CREATE TABLE Reportes (
  idReporte INT AUTO_INCREMENT PRIMARY KEY,
  idReservacion INT NOT NULL,
  fecha DATE NOT NULL,
  hora TIME NOT NULL,
  idUsuario INT NOT NULL,
  FOREIGN KEY (idReservacion) REFERENCES Reservaciones(idReservacion)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
    ON UPDATE CASCADE
    ON DELETE RESTRICT
) ENGINE=InnoDB;
