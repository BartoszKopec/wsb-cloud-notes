CREATE TABLE [Notes]
(
	ID int IDENTITY(1,1) PRIMARY KEY,
    Title varchar(max) NOT NULL,
    Description varchar(max) NOT NULL,
    Modification datetime NOT NULL
)

select * from [Notes];