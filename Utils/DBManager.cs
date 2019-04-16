namespace charity_management_system.Utils
{
    class DBManager
    {
      private static DBManager _instance;

      private DBManager() {}

      public static DBManager instance {
        get {
          if (_instance == null) {
            _instance = new DBManager();
          }

          return _instance;
        }
      }
    }
}
