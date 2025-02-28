var builder = DistributedApplication.CreateBuilder(args);

var password = builder.AddParameter("password", secret: true);
var sql = builder.AddSqlServer("mssql", password)
                 .WithDataVolume();
var db = sql.AddDatabase("CRM");

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.ChellengeAspireApp_ApiService>("apiservice")
                        .WithReference(db)
                        .WaitFor(db);

builder.AddProject<Projects.ChellengeAspireApp_Web>("webfrontend")
       .WithExternalHttpEndpoints()
       .WithReference(cache)
       .WaitFor(cache)
       .WithReference(apiService)
       .WaitFor(apiService);

builder.Build().Run();
