﻿if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName)
	values ('Clinton', 'Boamah'),
		   ('Jessica','Boahemaa'), 
		   ('Jason', 'Don');
end