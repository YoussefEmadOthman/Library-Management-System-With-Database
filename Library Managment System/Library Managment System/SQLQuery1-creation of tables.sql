Create DATABASE Library_Management_System
Create TABLE Student_Faculty
(
User_ID	int ,

Password varchar(30),

Name varchar(50),

Gender varchar(10),

DoB varchar(50),

Email varchar(70),

Department varchar(40),
CONSTRAINT PK_id PRIMARY KEY (User_ID)
);
Create TABLE Genre
(

Name varchar(50),
CONSTRAINT PK_name PRIMARY KEY (Name)
);
Create TABLE Book
(
ISBN varchar(50) ,

Title varchar(100),

Publisher varchar(30),

Edition varchar(10),

G_Name varchar(50),

CONSTRAINT PK_ISBN PRIMARY KEY(ISBN), 
CONSTRAINT FK_Gname FOREIGN KEY (G_Name)REFERENCES Genre(Name)
);
Create TABLE Author
(
B_ISBN varchar(50),
Author_Name varchar(50) ,

CONSTRAINT PK_ISBN_Author PRIMARY KEY(B_ISBN, Author_Name),
CONSTRAINT FK_B_ISBN FOREIGN KEY (B_ISBN)REFERENCES Book(ISBN)
);
Create TABLE Keywords
(
Name varchar(50),	
Genre_Keys varchar(50),
CONSTRAINT PK_name_keys PRIMARY KEY(Name, Genre_Keys),

CONSTRAINT FK_name_keys	FOREIGN KEY(Name) REFERENCES Genre(Name)
);
Create TABLE Book_copy
(
Copy_no int ,

Is_checked_out Varchar(10),

Is_damaged Varchar(10),

BC_ISBN varchar(50) ,

CONSTRAINT PK_copy_ISBN PRIMARY KEY(Copy_no, BC_ISBN) ,
CONSTRAINT FK_BC_ISBN FOREIGN KEY (BC_ISBN)REFERENCES Book(ISBN)
);
Create TABLE Borrow
(
MM_User_Id int ,

Date_of_borrow date,

Return_date date,

Extension_date date,

Borrow_ID int,

MM_ISBN	varchar(50) ,

MM_copy_no int,

CONSTRAINT PK_Bid PRIMARY KEY(Borrow_ID) ,
CONSTRAINT FK_user FOREIGN KEY(MM_User_Id)REFERENCES Student_Faculty(User_ID),
CONSTRAINT FK_copy FOREIGN KEY(MM_copy_no,MM_ISBN)REFERENCES Book_copy(Copy_no,BC_ISBN)
);
