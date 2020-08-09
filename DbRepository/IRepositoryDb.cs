using ComplianceRepository.Data;
using System.Collections.Generic;

namespace DbRepository
{
    public interface IRepositoryDb
    {
        /// <summary>
        /// Получить дату последнего обновления записей (в секундах, Unix-time)
        /// </summary>
        /// <returns>Unix-Time, в секундах</returns>
        int GetLastUpdateAtSec();

        /// <summary>
        /// Добавить коллекцию физических лиц
        /// </summary>
        /// <param name="peoples">Коллекция физических лиц</param>
        void AddPeoples(IEnumerable<People> peoples);
        
        /// <summary>
        /// Добавить коллекцию связанных лиц
        /// </summary>
        /// <param name="idPerson">Идентификатор физического лица</param>
        /// <param name="relatives">Коллекция связанных лиц</param>
        void AddRelatives(int idPerson, IEnumerable<Relative> relatives);

        /// <summary>
        /// Добавить коллекцию категорий
        /// </summary>
        /// <param name="idPerson">Идентификатор физического лица</param>
        /// <param name="categorie">Коллекция категорий</param>
        void AddCategories(int idPerson, IEnumerable<string> categorie);
       
        /// <summary>
        /// Добавить коллекцию контактной информации физического лица
        /// </summary>
        /// <param name="idPerson">Идентификатор физического лица</param>
        /// <param name="categorie">Коллекция контактной информации</param>
        void AddContacts(int idPerson, IEnumerable<Contact> contacts);
    }
}