using Microsoft.EntityFrameworkCore;
using MyVetAppoinment.Domain.Entities;
using MyVetAppointment.Infrastructure;

namespace MyVetAppoinment.IntegrationTest;
public class DbSeed
{
    public static void SeedClients(DatabaseContext context)
    {
        var users = new List<Client>
        {
            new(new Guid("3837a85c-fc53-40d9-b588-2fd95fa86518"), "oana",    "oana@yahoo.com",    "0123456789"),
            new("andreea", "andreea@yahoo.com", "0987654327"),
            new("victor",  "victor@yahoo.com",  "0647381993"),
            new("mihai",   "mihai@yahoo.com",   "0284372823")

        };

        context.Clients.AddRange(users);
        context.SaveChanges();
    }
}