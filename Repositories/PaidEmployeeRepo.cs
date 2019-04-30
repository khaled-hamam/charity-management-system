using charity_management_system.Models;
using charity_management_system.Utils;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Repositories
{
    public class PaidEmployeeRepo : IRepository<PaidEmployee>
    {
        private OracleConnection connection;
        private OracleCommand command;

        public PaidEmployeeRepo()
        {
            connection = DBManager.instance.connection;
            command = new OracleCommand();
            command.Connection = connection;
        }
        public bool delete(PaidEmployee model)
        {
            command = new OracleCommand();
            command.Connection = connection;

            command.CommandText = "DELETE_PAID_EMPLOYEE";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("emp_ssn", model.SSN);
            int check = command.ExecuteNonQuery();
            if (check == -1)
            {
                return false;
            }
            return true;
        }

        public List<PaidEmployee> find(string column, string value)
        {
            throw new NotImplementedException();
        }

        public List<PaidEmployee> findAll()
        {
            command = new OracleCommand();
            command.Connection = connection;
                
            command.CommandText = "FIND_ALL_PAID_EMPLOYEE";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("paidEmployee", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader reader = command.ExecuteReader();
            List<PaidEmployee> paidEmployees = new List<PaidEmployee>();
            while (reader.Read())
            {
                PaidEmployee paidEmployee = new PaidEmployee
                {
                    SSN = reader["ssn"].ToString(),
                    name = reader["name"].ToString(),
                    mobile = reader["mobile"].ToString(),
                    birthDate = Convert.ToDateTime(reader["birth_date"]),
                    gender = char.Parse(reader["gender"].ToString()),
                    addressLine1 = reader["address_line1"].ToString(),
                    addressLine2 = reader["address_line2"].ToString(),
                    city = reader["city"].ToString(),
                    governorate = reader["governorate"].ToString(),
                    email = reader["email"].ToString(),
                    salary = float.Parse(reader["salary"].ToString()),
                    branch = new Branch { id = int.Parse(reader["branch_id"].ToString()) },
                    department = new Department { name = reader["department_name"].ToString() }
                };
                paidEmployees.Add(paidEmployee);
            }
            reader.Close();
            return paidEmployees;
        }

        public PaidEmployee findByID(string id)
        {
            try
            {
                command = new OracleCommand();
                command.Connection = connection;

                command.BindByName = true;
                command.CommandText = "FIND_PAID_EMPLOYEE_BY_ID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("emp_ssn", id);
                command.Parameters.Add("ssn", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("name", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("mobile", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("birth_date", OracleDbType.Date).Direction = ParameterDirection.Output;
                command.Parameters.Add("gender", OracleDbType.Char, 1).Direction = ParameterDirection.Output;
                command.Parameters.Add("address_line1", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("address_line2", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("city", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("governorate", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("email", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("branch_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                command.Parameters.Add("salary", OracleDbType.Int32).Direction = ParameterDirection.Output;
                command.Parameters.Add("department_name", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
                PaidEmployee paidEmployee = new PaidEmployee
                {
                    SSN = command.Parameters["ssn"].Value.ToString(),
                    name = command.Parameters["name"].Value.ToString(),
                    mobile = command.Parameters["mobile"].Value.ToString(),
                    birthDate = Convert.ToDateTime(command.Parameters["birth_date"].Value.ToString()),
                    gender = char.Parse(command.Parameters["gender"].Value.ToString()),
                    addressLine1 = command.Parameters["address_line1"].Value.ToString(),
                    addressLine2 = command.Parameters["address_line2"].Value.ToString(),
                    city = command.Parameters["city"].Value.ToString(),
                    governorate = command.Parameters["governorate"].Value.ToString(),
                    email = command.Parameters["email"].Value.ToString(),
                    salary = float.Parse(command.Parameters["salary"].Value.ToString()),
                    branch = new Branch { id = int.Parse(command.Parameters["branch_id"].Value.ToString()) },
                    department = new Department { name = command.Parameters["department_name"].Value.ToString() }
                };
                return paidEmployee;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public PaidEmployee save(PaidEmployee model)
        {

            command = new OracleCommand();
            command.Connection = connection;

            command.CommandText = "SAVE_PAID_EMPLOYEE";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("ssn", model.SSN);
            command.Parameters.Add("name", model.name);
            command.Parameters.Add("mobile", model.mobile);

            OracleParameter p = new OracleParameter(":birth_date", OracleDbType.Date);
            p.Value = model.birthDate;
            command.Parameters.Add(p);

            p = new OracleParameter(":gender", OracleDbType.Char);
            p.Value = model.gender;
            command.Parameters.Add(p);

            command.Parameters.Add("address_line1", model.addressLine1);
            command.Parameters.Add("address_line2", model.addressLine2);
            command.Parameters.Add("city", model.city);
            command.Parameters.Add("governorate", model.governorate);
            command.Parameters.Add("email", model.email);

            p = new OracleParameter(":branch_id", OracleDbType.Decimal);
            p.Value = model.branch.id;
            command.Parameters.Add(p);


            p = new OracleParameter(":salary", OracleDbType.Decimal);
            p.Value = model.salary;
            command.Parameters.Add(p);

            command.Parameters.Add("department_name", model.department.name);
            int ret = command.ExecuteNonQuery();
            if (ret != -1)
            {
                //return paid_employee;
            }
            return null;
        }

        public bool update(PaidEmployee model)
        {

            command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE_PAID_EMPLOYEE";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("ssn", model.SSN);
            command.Parameters.Add("name", model.name);
            command.Parameters.Add("mobile", model.mobile);

            OracleParameter p = new OracleParameter(":birth_date", OracleDbType.Date);
            p.Value = model.birthDate;
            command.Parameters.Add(p);

            p = new OracleParameter(":gender", OracleDbType.Char);
            p.Value = model.gender;
            command.Parameters.Add(p);

            command.Parameters.Add("address_line1", model.addressLine1);
            command.Parameters.Add("address_line2", model.addressLine2);
            command.Parameters.Add("city", model.city);
            command.Parameters.Add("governorate", model.governorate);
            command.Parameters.Add("email", model.email);

            p = new OracleParameter(":branch_id", OracleDbType.Decimal);
            p.Value = model.branch.id;
            command.Parameters.Add(p);

            command.Parameters.Add("department_name", model.department.name);

            p = new OracleParameter(":salary", OracleDbType.Decimal);
            p.Value = model.salary;
            command.Parameters.Add(p);

            int ret = command.ExecuteNonQuery();
            if (ret != -1)
            {
                //return paid_employee;
            }
            return false;
        }
    }
}
