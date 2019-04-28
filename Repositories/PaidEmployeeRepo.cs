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
            command = new OracleCommand();
            command.Connection = connection;

            command.CommandText = "FIND_PAID_EMPLOYEE_BY_ID";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("emp_ssn", id);
            command.Parameters.Add("ssn", ParameterDirection.Output);
            command.Parameters.Add("name", ParameterDirection.Output);
            command.Parameters.Add("mobile", ParameterDirection.Output);
            command.Parameters.Add("birth_date", ParameterDirection.Output);
            command.Parameters.Add("gender", ParameterDirection.Output);
            command.Parameters.Add("address_line1", ParameterDirection.Output);
            command.Parameters.Add("address_line2", ParameterDirection.Output);
            command.Parameters.Add("city", ParameterDirection.Output);
            command.Parameters.Add("governorate", ParameterDirection.Output);
            command.Parameters.Add("email", ParameterDirection.Output);
            command.Parameters.Add("branch_id", ParameterDirection.Output);
            command.Parameters.Add("salary", ParameterDirection.Output);
            command.Parameters.Add("department_name", ParameterDirection.Output);

            OracleDataReader reader = command.ExecuteReader();
            PaidEmployee paidEmployee;
            if (reader.Read()) {
                paidEmployee = new PaidEmployee
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
            }
            else {
                reader.Close();
                return null;
            }
            reader.Close();
            return paidEmployee;

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

        public bool update(PaidEmployee Model)
        {
            command = new OracleCommand();
            command.Connection = connection;

            command.CommandText = "UPDATE_PAID_EMPLOYEE";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("ssn", Model.SSN);
            command.Parameters.Add("name", Model.name);
            command.Parameters.Add("mobile", Model.mobile);
            command.Parameters.Add("birth_date", Model.birthDate);
            command.Parameters.Add("gender", Model.gender);
            command.Parameters.Add("address_line1", Model.addressLine1);
            command.Parameters.Add("address_line2", Model.addressLine2);
            command.Parameters.Add("city", Model.city);
            command.Parameters.Add("governorate", Model.governorate);
            command.Parameters.Add("email", Model.email);
            command.Parameters.Add("branch_id", Model.branch.id);
            command.Parameters.Add("Department_name", Model.department.name);
            int ret = command.ExecuteNonQuery();
            if (ret != -1)
            {
                return true;
            }
            return false;

        }
    }
}
