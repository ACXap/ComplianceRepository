using ComplianceRepository;
using ComplianceRepository.Data;
using DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCompliance
{
    class Program
    {
        private static IRepositoryCompliance _repositoryCompliance = new RepositoryComplianceApi(Properties.Settings.Default.ApiKey, Properties.Settings.Default.UrlService);
        private static IRepositoryDb _repositoryChd = new RepositoryChd(Properties.Settings.Default.ConnectString);

        private static DateTime _startApplication;

        static void Main(string[] args)
        {
            StartApplication();

            try
            {
                // Получаем время последнего обновления в секундах
                Console.WriteLine("Подключение к базе данных и получение последней даты обновления...");
                var lastUpdate = _repositoryChd.GetLastUpdateAtSec();

                // +1 секунда, для получения новых записей
                lastUpdate++;

                // Получаем ответ от сервера API Compliance
                Console.WriteLine("Получаем ответ от сервера API Compliance...");
                var peoples = _repositoryCompliance.GetPeoples(lastUpdate);

                // Количество новых записей
                var countNewRecord = int.Parse(peoples.System_info.Count);
                Console.WriteLine($"Количество новых записей: {countNewRecord}");

                if (countNewRecord > 0)
                {
                    // Получаем коллекцию людей для записи в базу данных
                    var collectionPeople = GetPeoples(peoples);
                    Console.WriteLine($"Количество подготовленных для загрузки записей: {collectionPeople.Count()}");

                    // Записываем людей в базу данных
                    Console.WriteLine("Записываем людей в базу данных");
                    _repositoryChd.AddPeoples(collectionPeople);

                    // Записываем вспомогательной информации в базу
                    Console.WriteLine("Записываем категории, близкие связи людей, контактную информацию в базу");
                    SaveCategoriesRelativesContacts(collectionPeople);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            StopApplication();

            Console.ReadLine();
        }

        private static void StartApplication()
        {
            _startApplication = DateTime.Now;
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine(_startApplication);
            Console.WriteLine(new string('#', 100));
        }

        private static void StopApplication()
        {
            var stopApplication = DateTime.Now;
            var sec = (stopApplication - _startApplication).TotalSeconds;
            var time = sec < 60 ?  $"(сек): {sec}": $"(мин): {(stopApplication - _startApplication).TotalMinutes}";

            Console.WriteLine(new string('#', 100));
            Console.WriteLine(stopApplication);
            Console.WriteLine($"Обработка заняла {time}");
            Console.WriteLine("Обработка завершена!");
        }

        private static void SaveCategoriesRelativesContacts(IEnumerable<People> collectionPeople)
        {
            var progress = new ProgressBar();

            var count = collectionPeople.Count();
            var index = 0;

            foreach (var item in collectionPeople)
            {
                if (item.Categories.Any()) _repositoryChd.AddCategories(item.BlacklistId, item.Categories);
                if (item.Relatives.Any()) _repositoryChd.AddRelatives(item.BlacklistId, item.Relatives);
                if (item.Contacts.Any()) _repositoryChd.AddContacts(item.BlacklistId, item.Contacts);

                progress.Report((double)index++ / count);
            }

            progress.Report(1);
            progress.Dispose();
        }

        private static IEnumerable<People> GetPeoples(Peoples peoples)
        {
            var p = peoples.Entities.Entity.Select(x =>
            {
                return new People(x);
            });

            return p;
        }
    }
}