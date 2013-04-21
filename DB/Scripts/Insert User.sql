select * from Clinic
where Name like N'%Hoàng mai%'


select * from [User]
insert into [User] (ClinicId,Name,Role,UserName,Password,Active,CreatedDate,CrearedUser,LastUpdatedDate,LastUpdatedUser,Version)
values(12,N'Lai Minh Chau', 2, 'pkhoangmai','123456',1,'2013-04-15',1,'2013-04-15',1,0)

update [User]
set Role = 2
where Id= 46