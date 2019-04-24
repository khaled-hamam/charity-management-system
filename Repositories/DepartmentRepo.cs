using System;
using System.Collections.Generic;
using charity_management_system.Models;
using charity_management_system.Utils;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace charity_management_system.Repositories
{
    class DepartmentRepo : IRepository<Department>
    {
        private String connectionString;
        private OracleDataAdapter adapter;
        private OracleCommandBuilder builder;
        private DataSet ds;
        private String command;

        public DepartmentRepo()
        {
            connectionString = DBManager.instance.connectionString;
            command = "select * from department";
            adapter = new OracleDataAdapter(command, connectionString);
            ds = new DataSet();
            adapter.Fill(ds);
        }
        public bool delete(Department model)
        {
            DataRow row = null;
            bool found = false;
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                if(model.name == r[0].ToString())
                {
                    row = r;
                    found = true;
                    break;
                }
            }
            if(found)
            ds.Tables[0].Rows.Remove(row);
            return found;
        }

        public List<Department> find(string column, string value)
        {
            throw new NotImplementedException();
        }

        public List<Department> findAll()
        {
            List<Department> departments = new List<Department>();
            int i = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Department dep = new Department(row["name"].ToString());
                departments.Add(dep);
                i++;
            }
            return departments;
        }

        public Department findByID(string id)
        {
            Department department = new Department();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row[0].ToString() == id)
                {
                    department.name = row[0].ToString();
                    break;
                }
            }
            return department;
        }
        //insert
        public Department save(Department model)
        {
            DataRow row = ds.Tables[0].NewRow();
            row[0] = model.name;
            ds.Tables[0].Rows.Add(row);
            return null;
        }
        //edit
        public bool update(Department newModel)
        {
            return false;
        }
    }
}
