using ComplianceRepository;
using ComplianceRepository.Data;
using DbRepository;
using System;
using System.Linq;

namespace testRep
{
    class Program
    {
        static void Main(string[] args)
        {
            var rep = new RepositoryComplianceApi(Properties.Settings.Default.ApiKey, Properties.Settings.Default.UrlService);
            var repFile = new RepositoryFile();

            try
            {
                Console.WriteLine("----------------------------");

                // Получаем время последнего обновления в секундах
                var lastUpdate = repFile.GetLastUpdateAtSec();

                // + 1 секунда
                lastUpdate++;

                var a = rep.GetPeoples(lastUpdate);
                foreach (var item in a.Entities.Entity)
                {
                    Console.WriteLine($"{item.Updated_at_sec};{item.System_id};{item.Full_name}");
                }

                Console.WriteLine("----------------------------");

                var p = a.Entities.Entity.Select(x =>
                {
                    return new People(x);
                });

                Console.WriteLine("----------------------------");

                repFile.AddPeoples(p);

                foreach (var item in p)
                {
                    Console.WriteLine(item);
                    repFile.AddCategories(item.BlacklistId, item.Categories);
                    repFile.AddRelatives(item.BlacklistId, item.Relatives);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}