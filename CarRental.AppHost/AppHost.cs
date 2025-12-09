var builder = DistributedApplication.CreateBuilder(args);

var password = builder.AddParameter("DatabasePassword");
var mysql = builder.AddMySql("mysql")
                   .WithEnvironment("Password", password);

var carRentalDb = mysql.AddDatabase("CarRentalDb");

var api = builder.AddProject<Projects.CarRental_Api_Host>("api")
                 .WithReference(carRentalDb)
                 .WaitFor(carRentalDb);

var grpcClient = builder.AddProject<Projects.CarRental_Grpc_Producer>("producer")
                       .WithReference(api)
                       .WaitFor(api);

builder.Build().Run();