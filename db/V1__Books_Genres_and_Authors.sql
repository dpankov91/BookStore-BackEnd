CREATE TABLE Author(
	Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(75) NOT NULL
)

CREATE TABLE Genre(
	Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(75) NOT NULL
)

CREATE TABLE Book(
	Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(75) NOT NULL,
    PublishYear DateTime NOT NULL,
    AuthorId int NOT NULL,
    GenreId int NOT NULL

    CONSTRAINT FK_Book_Author FOREIGN KEY (AuthorId)     
    REFERENCES dbo.Author (AuthorId)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION

    CONSTRAINT FK_Book_Genre FOREIGN KEY (GenreId)     
    REFERENCES dbo.Genre (GenreId)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION
)

CREATE TABLE User(
	Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Username VARCHAR(75) NOT NULL,
    PasswordHash varbinary(max) NOT NULL,
    PasswordSalt varbinary(max) NOT NULL,
    IsAdmin boolean NOT NULL 
)