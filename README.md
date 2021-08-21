# QLSV_EntityFramework
* Change your ConnectionString in DAL.App.Config and GUI.App.Config 
## Contributing
  <connectionStrings>
  =====id and pw
    <add name="QlsvContext" connectionString="data source=localhost,1433;initial catalog=Your_name_DB_in_SQLServer;user id = sa; pwd =           your_pass;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
  ======
    <add name="QlsvContext" connectionString="data source=.;Initial Catalog=Your_name_DB_in_SQLServer;Integrated Security=True" providerName="System.Data.SqlClient" />
  </connectionStrings>
  
  if "data source=localhost,1433" not working => try: "data source=."
