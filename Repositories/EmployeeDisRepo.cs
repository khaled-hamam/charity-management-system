using System;
using System.Collections.Generic;
using charity_management_system.Models;
using Oracle.DataAccess.Client;
using System.Data;
using charity_management_system.Utils;

namespace charity_management_system.Repositories
{
    public class EmployeeDisRepo : IRepository<Employee>
    {
        private OracleDataAdapter adapter;
        private OracleCommandBuilder cmdBuilder;
        private DataSet ds;
        public DataSet dataSet
        {
            get
            {
                return this.ds;
            }
        }

        public EmployeeDisRepo()
        {
            String connectionStr = DBManager.instance.connectionString;
            String cmdStr = "select * from employee";
            adapter = new OracleDataAdapter(cmdStr, connectionStr);
            ds = new DataSet();
            adapter.Fill(ds);
        }

        public bool delete(Employee model)
        {
            throw new NotImplementedException();
        }

        public List<Employee> find(string column, string value)
        {
            List<Employee> employees = new List<Employee>();

            foreach (DataRow row in this.ds.Tables[0].Rows)
            {
                if (row[column].ToString() == value)
                {
                    employees.Add(
                        new Employee()
                        {
                            SSN = row["SSN"].ToString(),
                            name = row["name"].ToString(),
                            mobile = row["mobile"].ToString(),
                            gender = row["gender"].ToString()[0],
                            addressLine1 = row["address_line1"].ToString(),
                            addressLine2 = row["address_line2"].ToString(),
                            governorate = row["governorate"].ToString(),
                            city = row["city"].ToString(),
                            email = row["email"].ToString()
                        }
                    );
                }
            }

            return employees;
        }

        public List<Employee> findAll()
        {
            throw new NotImplementedException();
        }

        public Employee findByID(string id)
        {
            throw new NotImplementedException();
        }

        public Employee save(Employee model)
        {
            throw new NotImplementedException();
        }

        public bool update(Employee newModel)
        {
            throw new NotImplementedException();
        }
    }
}
