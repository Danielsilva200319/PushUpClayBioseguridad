CREATE TABLE `PersonType`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Description` VARCHAR(255) NOT NULL
);
CREATE TABLE `PersonAddress`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Address` VARCHAR(255) NOT NULL,
    `IdPerson` INT NOT NULL,
    `IdAddressType` INT NOT NULL,
    CONSTRAINT `personaddress_idperson_foreign` FOREIGN KEY(`IdPerson`) REFERENCES `Person`(`Id`),
    CONSTRAINT `personaddress_idaddresstype_foreign` FOREIGN KEY(`IdAddressType`) REFERENCES `AddressType`(`Id`)
);
CREATE TABLE `AddressType`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Description` VARCHAR(255) NOT NULL
);
CREATE TABLE `PersonContact`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Description` VARCHAR(255) NOT NULL,
    `IdPerson` INT NOT NULL,
    `IdContactType` INT NOT NULL,
    CONSTRAINT `personcontact_idperson_foreign` FOREIGN KEY(`IdPerson`) REFERENCES `Person`(`Id`),
    CONSTRAINT `personcontact_idcontacttype_foreign` FOREIGN KEY(`IdContactType`) REFERENCES `ContactType`(`Id`)
);
ALTER TABLE
    `PersonContact` ADD UNIQUE `personcontact_description_unique`(`Description`);
CREATE TABLE `Shifts`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `ShiftName` VARCHAR(50) NOT NULL,
    `TimeShiftStart` TIME NOT NULL,
    `TimeShiftEnd` TIME NOT NULL
);
CREATE TABLE `PersonCategory`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `NameCategory` BIGINT NOT NULL
);
CREATE TABLE `Department`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` VARCHAR(50) NOT NULL,
    `IdCountry` INT NOT NULL,
    CONSTRAINT `department_idcountry_foreign` FOREIGN KEY(`IdCountry`) REFERENCES `Country`(`Id`)
);
CREATE TABLE `ContactType`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Description` VARCHAR(255) NOT NULL
);
CREATE TABLE `Country`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` VARCHAR(50) NOT NULL
);
CREATE TABLE `Programming`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `IdContract` INT NOT NULL,
    `IdShifts` INT NOT NULL,
    `IdEmployee` INT NOT NULL,
    CONSTRAINT `programming_idcontract_foreign` FOREIGN KEY(`IdContract`) REFERENCES `Contract`(`Id`),
    CONSTRAINT `programming_idshifts_foreign` FOREIGN KEY(`IdShifts`) REFERENCES `Shifts`(`Id`),
    CONSTRAINT `programming_idemployee_foreign` FOREIGN KEY(`IdEmployee`) REFERENCES `Person`(`Id`)
);
CREATE TABLE `Estado`(
    `Id` BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Description` VARCHAR(255) NOT NULL
);
CREATE TABLE `Person`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `IdPerson` INT NOT NULL,
    `Name` VARCHAR(50) NOT NULL,
    `DateReg` DATE NOT NULL,
    `IdPersonType` INT NOT NULL,
    `IdCategory` INT NOT NULL,
    `IdCity` INT NOT NULL,
    CONSTRAINT `person_idpersontype_foreign` FOREIGN KEY(`IdPersonType`) REFERENCES `PersonType`(`Id`),
    CONSTRAINT `person_idcategory_foreign` FOREIGN KEY(`IdCategory`) REFERENCES `PersonCategory`(`Id`),
    CONSTRAINT `person_idcity_foreign` FOREIGN KEY(`IdCity`) REFERENCES `City`(`Id`)
);
ALTER TABLE
    `Person` ADD UNIQUE `person_idperson_unique`(`IdPerson`);
CREATE TABLE `Contract`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `DateContract` DATE NOT NULL,
    `DateEnd` DATE NOT NULL,
    `IdClient` INT NOT NULL,
    `IdEmployee` INT NOT NULL,
    `IdState` INT NOT NULL,
    CONSTRAINT `contract_idclient_foreign` FOREIGN KEY(`IdClient`) REFERENCES `Person`(`Id`),
    CONSTRAINT `contract_idemployee_foreign` FOREIGN KEY(`IdEmployee`) REFERENCES `Person`(`Id`),
    CONSTRAINT `contract_idstate_foreign` FOREIGN KEY(`IdState`) REFERENCES `Estado`(`Id`)
);
CREATE TABLE `City`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` VARCHAR(50) NOT NULL,
    `IdDepartment` INT NOT NULL,
    CONSTRAINT `city_iddepartment_foreign` FOREIGN KEY(`IdDepartment`) REFERENCES `Department`(`Id`)
);