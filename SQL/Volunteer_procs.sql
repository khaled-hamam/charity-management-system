create or replace procedure delete_volunteer
(ssn in number)

as 
begin
delete from volunteer
where employee_ssn = ssn; 

end;

create or replace procedure find_all_volunteers (volunteer out SYS_REFCURSOR) 
as 
begin
open volunteer
for
select *
from employee e, volunteer v
where e.ssn = v.employee_ssn;
end;


create or replace procedure find_volunteer
(column_name in varchar2, val in varchar2, Voulnteers out SYS_REFCURSOR)
as 
begin
open voulnteers for 
select *
from employee e, volunteer v
where column_name = val;
end;

create or replace procedure find_volunteer_by_id
(emp_ssn in VARCHAR2, ssn out VARCHAR2,
name out VARCHAR2, mobile out VARCHAR2, birth_date out DATE, gender out CHAR,
address_line1 out VARCHAR2, address_line2 out VARCHAR2, city out VARCHAR2, governorate out VARCHAR2,
email out VARCHAR2, branch_id out NUMBER, is_currently_working out number)
AS 
BEGIN
select e.ssn, e.name, e.mobile, e.birth_date, e.gender, e.address_line1, e.address_line2,
e.city, e.governorate, e.email, e.branch_id, v.is_currently_volunteering
into ssn, name, mobile, birth_date, gender, address_line1, address_line2, city, governorate,
email, branch_id, is_currently_working
from employee e, volunteer v
where e.ssn = v.employee_ssn;
end;


create or replace procedure save_volunteer
(ssn varchar2, volunteer_name varchar2 , volunteer_mobile varchar2, birth_date date,
gender char, address_line1 varchar2, address_line2 varchar2, city varchar2, governorate varchar2,
email varchar2, branch_id number, currently_working number)
as
begin 
insert all
into employee
values (ssn, volunteer_name, volunteer_mobile, birth_date, 
gender, address_line1, address_line2, city, governorate, email, branch_id)
into volunteer
values (ssn, currently_working)
select * from dual ;
end;

create or replace procedure update_volunteer
(ssn varchar2, volunteer_name varchar2 , volunteer_mobile varchar2, birth_date date,
gender char, address_line1 varchar2, address_line2 varchar2, city varchar2, governorate varchar2,
email varchar2, branch_id number, currently_working number)
as 
begin
update employee
set employee.name = volunteer_name, employee.mobile = volunteer_mobile, 
employee.birth_date = birth_date, employee.gender = gender, employee.address_line1 = address_line1, 
employee.address_line2 = address_line2,
employee.city = city, employee.governorate = governorate, employee.email = email, 
employee.branch_id = branch_id
where employee.ssn = ssn;

update volunteer
set volunteer.IS_CURRENTLY_VOLUNTEERING = currently_working
where volunteer.Employee_SSN = ssn;
end;