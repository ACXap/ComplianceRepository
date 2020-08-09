using ComplianceRepository.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DbRepository
{
    public class RepositoryFile : IRepositoryDb
    {
        private readonly string _filePeoples = "peoplesdb.txt";
        private readonly string _fileCategories = "categoriesdb.txt";
        private readonly string _fileRelatives = "relativesdb.txt";
        private readonly string _separator = ";";

        public void AddCategories(int idPerson, IEnumerable<string> categories)
        {
            if (categories == null || !categories.Any()) return;

            File.AppendAllLines(_fileCategories, categories.Select(x =>
            {
                return $"{idPerson}{_separator}{x}";
            }));
        }

        public void AddPeoples(IEnumerable<People> peoples)
        {
            if (peoples == null || !peoples.Any()) return;

            File.AppendAllLines(_filePeoples, peoples.Select(x => x.ToString()));
        }

        public void AddRelatives(int idPerson, IEnumerable<Relative> relatives)
        {
            if (relatives == null || !relatives.Any()) return;

            File.AppendAllLines(_fileRelatives, relatives.Select(x =>
            {
                return $"{idPerson}{_separator}{x.Id}{_separator}{x.TypeRelationshipId}";
            }));
        }

        public int GetLastUpdateAtSec()
        {
            if (File.Exists(_filePeoples))
            {
                var str = File.ReadAllLines(_filePeoples);
                var peoples = str.Select(x =>
                {
                    var s = x.Split(new string[] { _separator }, StringSplitOptions.None);
                    return int.Parse(s[6]);
                });

                return peoples.Max();
            }

            return 0;
        }
    }
}