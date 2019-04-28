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
            _config.Add("UserId", "SCOTT");
            _config.Add("Password", "tiger");
            _config.Add("HOST", "localhost");
            _config.Add("PORT", "1521");
            _config.Add("DataSource", $"(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)" +
                $"(HOST = {_config["HOST"]})(PORT = {_config["PORT"]}))) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orclk)))");
            this.connection = new OracleConnection(connectionString);
            this.connection.Open();
        }

        ~DBManager() {
            this.connection.Dispose();
        }
    }
}
