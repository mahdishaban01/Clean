
using Clean.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence.Sql.DbContext;

public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<User, Role, Guid>(options) { }
