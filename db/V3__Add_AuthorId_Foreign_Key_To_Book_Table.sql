ALTER TABLE Book 
   ADD AuthorId INT
    CONSTRAINT FK_Book_Author
        FOREIGN KEY (AuthorId) 
        REFERENCES Author(Id)
        ;