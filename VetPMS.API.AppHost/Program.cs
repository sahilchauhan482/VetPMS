var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.VetPMS_API>("vetpms-api");
builder.AddProject<Projects.VetPMS>("webfrontend").WithReference(apiService);


builder.Build().Run();
