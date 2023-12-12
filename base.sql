CREATE DATABASE bioseguridad;
USE bioseguridad; 

CREATE TABLE `Country`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` VARCHAR(50) NOT NULL
);
INSERT INTO `Country` (`Name`) VALUES
('United States'),
('Canada'),
('United Kingdom'),
('Germany'),
('France'),
('Australia'),
('Brazil'),
('Japan'),
('South Africa'),
('India');


CREATE TABLE `Department`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` VARCHAR(50) NOT NULL,
    `IdCountry` INT NOT NULL,
    CONSTRAINT `department_idcountry_foreign` FOREIGN KEY(`IdCountry`) REFERENCES `Country`(`Id`)
);
INSERT INTO `Department` (`Name`, `IdCountry`) VALUES
('New York', 1),                    -- New York state in the United States (assuming 1 is the Id for the United States)
('Ontario', 2),                     -- Ontario state in Canada
('London', 3),                      -- London state in the United Kingdom
('Bavaria', 4),                     -- Bavaria state in Germany
('Île-de-France', 5),               -- Île-de-France state in France
('California', 1),                  -- California state in the United States
('Texas', 1),                       -- Texas state in the United States
('Quebec', 2),                      -- Quebec state in Canada
('Alberta', 2),                     -- Alberta state in Canada
('Scotland', 3),                    -- Scotland state in the United Kingdom
('Wales', 3),                       -- Wales state in the United Kingdom
('Bavaria', 4),                     -- Bavaria state in Germany
('Hesse', 4),                       -- Hesse state in Germany
('Provence-Alpes-Côte d''Azur', 5), -- Île-de-France state in France
('New South Wales', 6),           -- New South Wales state in Australia
('São Paulo', 7),                 -- São Paulo state in Brazil
('Tokyo', 8),                     -- Tokyo state in Japan
('Gauteng', 9),                   -- Gauteng state in South Africa
('Maharashtra', 10), 
('Queensland', 6),                -- Queensland state in Australia
('Victoria', 6),                  -- Victoria state in Australia
('Rio de Janeiro', 7),            -- Rio de Janeiro state in Brazil
('Minas Gerais', 7),              -- Minas Gerais state in Brazil
('Osaka', 8),                     -- Osaka state in Japan
('Hokkaido', 8),                  -- Hokkaido state in Japan
('Western Cape', 9),              -- Western Cape state in South Africa
('KwaZulu-Natal', 9),             -- KwaZulu-Natal state in South Africa
('Maharashtra', 10),              -- Maharashtra state in India
('Tamil Nadu', 10); 

CREATE TABLE `City`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` VARCHAR(50) NOT NULL,
    `IdDepartment` INT NOT NULL,
    CONSTRAINT `city_iddepartment_foreign` FOREIGN KEY(`IdDepartment`) REFERENCES `Department`(`Id`)
);

CREATE TABLE `State`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Description` VARCHAR(255) NOT NULL
);

CREATE TABLE `PersonType`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Description` VARCHAR(255) NOT NULL
);

CREATE TABLE `ContactType`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Description` VARCHAR(255) NOT NULL
);

CREATE TABLE `AddressType`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Description` VARCHAR(255) NOT NULL
);

CREATE TABLE `PersonCategory`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `NameCategory` VARCHAR(255) NOT NULL
);

CREATE TABLE `Shifts`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `ShiftName` VARCHAR(50) NOT NULL,
    `TimeShiftStart` TIME NOT NULL,
    `TimeShiftEnd` TIME NOT NULL
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

CREATE TABLE `PersonAddress`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Address` VARCHAR(255) NOT NULL,
    `IdPerson` INT NOT NULL,
    `IdAddressType` INT NOT NULL,
    CONSTRAINT `personaddress_idperson_foreign` FOREIGN KEY(`IdPerson`) REFERENCES `Person`(`Id`),
    CONSTRAINT `personaddress_idaddresstype_foreign` FOREIGN KEY(`IdAddressType`) REFERENCES `AddressType`(`Id`)
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

CREATE TABLE `Contract`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `DateContract` DATE NOT NULL,
    `DateEnd` DATE NOT NULL,
    `IdClient` INT NOT NULL,
    `IdEmployee` INT NOT NULL,
    `IdState` INT NOT NULL,
    CONSTRAINT `contract_idclient_foreign` FOREIGN KEY(`IdClient`) REFERENCES `Person`(`Id`),
    CONSTRAINT `contract_idemployee_foreign` FOREIGN KEY(`IdEmployee`) REFERENCES `Person`(`Id`),
    CONSTRAINT `contract_idstate_foreign` FOREIGN KEY(`IdState`) REFERENCES `State`(`Id`)
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