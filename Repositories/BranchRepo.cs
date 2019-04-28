using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Data;
using charity_management_system.Utils;
using charity_management_system.Models;

namespace charity_management_system.Repositories
{
    class BranchRepo : IRepository<Branch>
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
  
        public BranchRepo()
        {
            String connectionStr = DBManager.instance.connectionString;
            String cmdStr = "select * from branch";
            adapter = new OracleDataAdapter(cmdStr, connectionStr);
            ds = new DataSet();
            adapter.Fill(ds);
        }

        public bool delete(Branch model)
        {
            DataRow dr = ds.Tables[0].Select("id= " + model.id).First();
            ds.Tables[0].Rows.Remove(dr);
           
            return true;
        }

        public List<Branch> find(string column, string value)
        {
            DataRow[] dr = ds.Tables[0].Select(column+"=" + value);
            List<Branch> branches =  dr.AsEnumerable().Select(
                DataRow => new Branch
                    (
                        //  DataRow.Field<int>("id"),
                        DataRow.Field<String>("address_line1"),
                        DataRow.Field<String>("city"),
                        DataRow.Field<String>("governorate")
                    )
                ).ToList();
           
            return branches;
        }

        public List<Branch> findAll()
        {
            List<Branch> branches = ds.Tables[0].AsEnumerable().Select(
                    DataRow => new Branch
                    { 
                        id = (int)DataRow.Field<Decimal>("id"),
                        addressLine1 =    DataRow.Field<String>("address_line1"),
                        addressLine2 = DataRow.Field<String>("address_line2"),
                        city =   DataRow.Field<String>("city"),
                        governorate =   DataRow.Field<String>("governorate")
                    }
                ).ToList();
            return branches;
        }

        public Branch findByID(string id)
        {
             DataRow dr =  ds.Tables[0].Select("id= " + id).First();

            Branch branch = new Branch
            {
                id = (int)dr["id"],
                addressLine1 = dr["addressLine1"].ToString(),
                addressLine2 = dr["addressLine2"].ToString(),
                city = dr["city"].ToString(),
                governorate = dr["governorate"].ToString()
            };
              
            return branch;
        }

        public Branch save(Branch model)
        {
            //insert
            ds.Tables[0].Rows.Add(model);

            //cmdBuilder = new OracleCommandBuilder(adapter);
            //adapter.Update(ds.Tables[0]);
            return null;
        }

        public bool update(Branch newModel)
        {

            DataRow dr = ds.Tables[0].Select("id= " + newModel.id).First();
               int i = ds.Tables[0].Rows.IndexOf(dr);

            ds.Tables[0].Rows[i]["addressLine1"] = newModel.addressLine1;
            ds.Tables[0].Rows[i]["city"] = newModel.city;
            ds.Tables[0].Rows[i]["governorate"] = newModel.governorate;
            ds.Tables[0].Rows[i]["addressLine2"] = newModel.addressLine2;

            return true;
        }

        public bool saveData()
        {
            cmdBuilder = new OracleCommandBuilder(adapter);
             int ret =  adapter.Update(ds.Tables[0]);
            return true;
        }

        public void populate(List<Branch> branches)
        {
            branches.ForEach(branch =>
            {
                var empRepo = new EmployeeDisRepo();
                branch.employees.AddRange(empRepo.find("branch_id", branch.id.ToString()));
            });
        }
    }
}
