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
    
      public static void SeedCabinets(DatabaseContext context)
    {
        var cabinets = new List<Cabinet>
        {
            new(new Guid("3937a85c-fc53-40d9-b588-2fd95fa86518"),"GreenVet","Strada Podu de Piatra 5"),
            new("ProVet", "Strada Smardan 84"),
            new("MofturiciVet",  "Sos. Nicolina Nr. 62")
        };

        context.Cabinets.AddRange(cabinets);
        context.SaveChanges();
    }
    public static void SeedDrugs(DatabaseContext context)
    {
        var drugs = new List<Drug>
        {
            new(new Guid("fe1bdfc5-5424-4410-ab46-3cf1f98ac59a"), "Corpet","Supliment nutritional cu rol paliativ antitumoral si de sustinere a sistemului imunitar.",
            98,130,"pastile",90,"pastile"),
            new("NeuroVet", "este indicat pentru tratamentul adjuvant al neuropatiilor",50,169, "comprimate",
            60,"comprimate"),
            new("RX Onco Support",  "pentru sustinerea functiilor in cazul afectiunilor cronice si / sau maligne",
            30,380,"pulbere",300,"g"),
            new("RX Liquid Immuno","supliment nutritional si botanic pentru intarirea sistemului imunitar la caini si pisici",
            234,222,"lichid",120,"ml")

        };

        context.Drugs.AddRange(drugs);
        context.SaveChanges();
    }
}
