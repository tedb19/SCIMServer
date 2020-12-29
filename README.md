# SCIM Server Implementation:

## Running the app locally:
- `dotnet dev-certs https --trust` - To trust the locally generated SSL certificate, so we can use `HTTPS` locally
- `dotnet watch run` - To watch for file changes and recompile
- `dotnet run` - To simply compile and run the app

## Resources:
[Building a REST API using ASP.NET Core Web API](https://www.freecodecamp.org/news/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28/)

[SCIM 2.0 RFC](https://tools.ietf.org/html/rfc7643)

[SCIM 2.0 high level design](https://tools.ietf.org/html/rfc7643)

[Azure AD SCIM Implementation](https://docs.microsoft.com/en-us/azure/active-directory/app-provisioning/use-scim-to-provision-users-and-groups#step-2-understand-the-azure-ad-scim-implementation)