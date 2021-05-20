ALTER TABLE Book 
   ADD GenreId INT
    CONSTRAINT FK_Book_Genre
        FOREIGN KEY (GenreId) 
        REFERENCES Genre(Id)
        ;