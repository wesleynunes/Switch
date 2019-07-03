CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Usuarios` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` longtext NULL,
    `Sobrenome` longtext NULL,
    `Email` longtext NULL,
    `Senha` longtext NULL,
    `DataNascimento` datetime(6) NOT NULL,
    `Sexo` int NOT NULL,
    `UrlFoto` longtext NULL,
    CONSTRAINT `PK_Usuarios` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190528172216_Inicio', '2.1.11-servicing-32099');

ALTER TABLE `Usuarios` MODIFY COLUMN `UrlFoto` varchar(400) NOT NULL;

ALTER TABLE `Usuarios` MODIFY COLUMN `Sobrenome` varchar(400) NOT NULL;

ALTER TABLE `Usuarios` MODIFY COLUMN `Senha` varchar(400) NOT NULL;

ALTER TABLE `Usuarios` MODIFY COLUMN `Nome` varchar(400) NOT NULL;

ALTER TABLE `Usuarios` MODIFY COLUMN `Email` varchar(400) NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190528205236_AdicionandoUsuarioConfiguration', '2.1.11-servicing-32099');

CREATE TABLE `Postagens` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DataPublicacao` datetime(6) NOT NULL,
    `Texto` longtext NULL,
    CONSTRAINT `PK_Postagens` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190703170217_AdicionadoClassPostagem', '2.1.11-servicing-32099');

CREATE TABLE `StatusRelacionamento` (
    `Id` int NOT NULL AUTO_INCREMENT,
    CONSTRAINT `PK_StatusRelacionamento` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190703171037_AdicionadoClassStatusRelacionamento', '2.1.11-servicing-32099');

