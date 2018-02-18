# ASP.NET Core Identity Playground

This project to test to improve my knowledge on Identity and user management

## Project description and main subjects

### Connection to a database in VS2017 and .NET CORE, CRUD op.

INSTALL: Microsoft.AspnetCore.Identity.EntityFramework

//LD STEP001
  - add a "DbContext"
  - add "Car.cs"
  - add "ICarData.cs"
  - add "SqlCarData : ICarData"

//LD STEP002
  - set "startup.cs"

    ```
    services.AddScoped<ICarData, SqlCarData>();
    services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LdConnectionString")));
    ```

//LD STEP003
  - set up connection string in "appsettings.json"
   
   ```
   "ConnectionStrings": {
"LdConnectionString": "Data Source=LUCA;Database='DbForIdentityTestProject';Integrated Security=False;User ID=sa;Password=Luca111q;Connect  Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
   }
   ```

//LD STEP004
  - set the "migrations"
    - "Add-Migration start -Context ProjectDbContext" (for a specific context)
    - "Update-Database -Context ProjectDbContext" (for a specific context)

if I have a property called "Id", entity framework will assume that is the "Primary Key".


### Implement Identity - preparation

//LD STEP1
  - add the "ApplicationUser" class

//LD STEP2
  - I want that an istance of "ApplicationUser" is part of the "IdentityDbContext", so I create:

  ```
  public class ImplementIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>public class ImplementIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
  ```

//LD STEP3
  - setting of "Configure" method in "startup.cs" class

//LD STEP4
  - setting of "ConfigureService" method in "startup.cs" class

As the concept of Dependency Injection is central to ASP.NET Core Application, we register context, identity and policy to Dependency Injection during the application start up. Thus, we register these as a Service in the ConfigureServices method of the StartUp class, as per the code snippet given below.
    
    ```
    services.AddDbContext<ImplementIdentityDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("LdConnectionString")));
    services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ImplementIdentityDbContext>()
        .AddDefaultTokenProviders();
    services.AddMvc();
    ```

I need to build and register the policy. The claims requirements are policy based. We create policy which can contain one and more than one claims. The authenticate user has these claims then he/she authorises to access the resources.
In this case the AddEditUser policy checks for the presence of an “Add User” and “Edit User” claims on the current identity.

      services.AddAuthorization(options =>
      {
          options.AddPolicy("AddEditUser", policy => {
              policy.RequireClaim("Add User", "Add User");
              policy.RequireClaim("Edit User", "Edit User");
          });
          options.AddPolicy("DeleteUser", policy => policy.RequireClaim("Delete User", "Delete User"));
      });

//LD STEP5
  - add-migration and update database
   
   ```
   Add-Migration addIdentityTables -Context ImplementIdentityDbContext
   Update-Database -Context ImplementIdentityDbContext
   ```

### Implement Identity - CRUD

This section demonstrates that how to create, edit and delete the identity users and how to assign the claims to a user. There is UserManager, which exposes the user related APIs. This creates the user in the Application and is stored in the database.

//LD STEP6
  - now I have to declare a class with the possible CLAIM to assign to an user

    ```
    public static class ClaimData
    {
    public static List<string> UserClaims { get; set; } = new List<string>
                                                        {
                                                            "Add User",
                                                            "Edit User",
                                                            "Delete User"
                                                        };
    }
    ```
   
//LD STEP7
  - declare a controller "UserController.cs" with the "crud" operations, where i declare an "user manager"

    ```
    private readonly UserManager<ApplicationUser> userManager;
    public UserController(UserManager<ApplicationUser> userManager)
    {
        this.userManager = userManager;
    }
    ```

//LD STEP8
  - now I add the View Model

//LD STEP9
  - now I add the Views

### Implement Identity - Authentication and Authorisation

//LD STEP10
  - add the "AccountController.cs"

#
I can find in "UserController.cs" the settings for the CLAIM BASED

As we created two policies based on the claims in this application. The AddEditUser policy contains two claims one is “Add User” and another is “Edit User”. The DeleteUser policy contains “Delete User” claim. We used these policies on the action method of the UserController controller. If a user doesn’t have one of the claims which include in AddEditUser policy then the authenticated user doesn’t authorize to access that action method on which policy has been implemented.
#

//LD STEP11
  - add the cide in "_Layout.cshtml" to manage the unhautorized requestes


MAIN RESOURCES:

- https://code.msdn.microsoft.com/ASPNET-Core-MVC-Authenticat-39b4b103
- https://andrewlock.net/custom-authorisation-policies-and-requirements-in-asp-net-core/
- https://andrewlock.net/introduction-to-authentication-with-asp-net-core/
- https://andrewlock.net/introduction-to-authorisation-in-asp-net-core/
- https://andrewlock.net/modifying-the-ui-based-on-user-authorisation-in-asp-net-core/
- https://www.simple-talk.com/dotnet/asp-net/model-binding-asp-net-core/
- https://docs.microsoft.com/en-us/aspnet/core/security/authorization/claims
- https://social.technet.microsoft.com/wiki/contents/articles/36959.asp-net-core-mvc-authentication-and-claim-based-authorisation-with-asp-net-identity-core.aspx