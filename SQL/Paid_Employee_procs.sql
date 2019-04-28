create or replace PROCEDURE FIND_PAID_EMPLOYEE_BY_ID (emp_ssn in VARCHAR2, ssn out VARCHAR2,
name out VARCHAR2, mobile out VARCHAR2, birth_date out DATE, gender out CHAR,
address_line1 out VARCHAR2, address_line2 out VARCHAR2, city out VARCHAR2, governorate out VARCHAR2,
email out VARCHAR2, branch_id out NUMBER, salary out NUMBER, department_name out VARCHAR2)
AS 
BEGIN
select e.ssn, e.name, e.mobile, e.birth_date, e.gender, e.address_line1, e.address_line2,
e.city, e.governorate, e.email, e.branch_id, pe.salary, pe.department_name
into ssn, name, mobile, birth_date, gender, address_line1, address_line2, city, governorate,
email, branch_id, salary, department_name
from employee e, paid_employee pe
where e.ssn = pe.employee_ssn;
END FIND_PAID_EMPLOYEE_BY_ID;



create or replace PROCEDURE SAVE_PAID_EMPLOYEE 
(ssn in VARCHAR2, name in VARCHAR2, mobile in VARCHAR2, birth_date in DATE, gender in CHAR,
address_line1 in VARCHAR2, address_line2 in VARCHAR2, city in VARCHAR2, governorate in VARCHAR2,
email in VARCHAR2, branch_id in NUMBER, salary in NUMBER, department_name in VARCHAR2)
AS 
BEGIN
INSERT ALL 
into employee
values (ssn, name, mobile, birth_date, gender, address_line1, address_line2, city, 
governorate, email, branch_id)
into paid_employee 
values (ssn,salary, department_name)
SELECT * FROM dual;
END SAVE_PAID_EMPLOYEE;


create or replace PROCEDURE FIND_ALL_PAID_EMPLOYEE (paidEmployee out SYS_REFCURSOR) 
AS 
BEGIN
open paidEmployee for
select *
from employee e, paid_employee pe
where e.ssn = pe.employee_ssn;
END FIND_ALL_PAID_EMPLOYEE;

create or replace PROCEDURE DELETE_PAID_EMPLOYEE ( emp_ssn in VARCHAR2)
AS 
BEGIN
    delete from employee
    where ssn = emp_ssn;
    delete from paid_employee
    where employee_ssn = emp_ssn;
END DELETE_PAID_EMPLOYEE;

create or replace PROCEDURE UPDATE_PAID_EMPLOYEE
(ssn varchar2, name varchar2 , mobile varchar2, birth_date date,
gender char, address_line1 varchar2, address_line2 varchar2, city varchar2, governorate varchar2,
email varchar2, branch_id number, Department_name varchar2, salary NUMBER)
AS 
BEGIN
update employee
set employee.name = name, employee.mobile = mobile, 
employee.birth_date = birth_date, employee.gender = gender, employee.address_line1 = address_line1, 
employee.address_line2 = address_line2,
employee.city = city, employee.governorate = governorate, employee.email = email, 
employee.branch_id = branch_id
where employee.ssn = ssn;

update paid_employee
set paid_employee.salary = salary, paid_employee.department_name = Department_name
where paid_employee.employee_ssn = ssn;
END UPDATE_PAID_EMPLOYEE;