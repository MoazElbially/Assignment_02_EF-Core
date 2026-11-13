using Assignment_02_EF_Core.EventHub.Data;

namespace Assignment_02_EF_Core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (EventHubDbContext context =
                  new EventHubDbContext())
            {
                if (context.Database.CanConnect())
                {
                    Console.WriteLine(
                        "Connected to EventHubDB Successfully!"
                    );
                }
                else
                {
                    Console.WriteLine(
                        "Database Connection Failed!"
                    );
                }
            }
        }
    }
}
