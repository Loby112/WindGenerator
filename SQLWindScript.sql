Drop Table WindData
Create Table WindData (
	Id int primary key identity(1,1) not null,
	Speed int not null,
	Direction varchar(255) not null
)