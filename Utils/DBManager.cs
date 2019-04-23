using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;

namespace charity_management_system.Utils
{
    class DBManager
    {
        private static DBManager _instance;

        private Dictionary<String, String> _config = new Dictionary<String, String>();
        public OracleConnection connection;
        public String connectionString
        {
            get
            {
                return $"Data source = {_config["DataSource"]}; User Id = {_config["UserId"]}; Password = {_config["Password"]};";
            }
        }
 
        private DBManager() { }

        public static DBManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBManager();
                    _instance.config();
                }

                return _instance;
            }
        }

        private void config()
        {
            _config.Add("UserId", "charity_dba");
            _config.Add("Password", "charity_dba");
            _config.Add("HOST", "0.tcp.ngrok.io");
            _config.Add("PORT", "18176");
            _config.Add("DataSource", $"(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)" +
                $"(HOST = {_config["HOST"]})(PORT = {_config["PORT"]}))) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orcl)))");
            this.connection = new OracleConnection(connectionString);
            this.connection.Open();
        }

        ~DBManager() {
            this.connection.Dispose();
        }
    }
}
