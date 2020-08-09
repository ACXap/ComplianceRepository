using System.Collections.Generic;
using System.Linq;

namespace ComplianceRepository.Data
{
    public class People
    {
        private readonly string _separator = ",";

        public People(EntityPeople entityPeople)
        {
            BlacklistId = int.Parse(entityPeople.System_id);
            AllNames = GetNames(entityPeople.Names.Item);
            NameRawSource = entityPeople.Full_name;
            BirthDate = entityPeople.Dob;
            BirthPlace = entityPeople.Pob;
            DocumentNumber = GetDocumentNumber(entityPeople.Persdocs.Item);
            AddressRawSource = GetAddress(entityPeople.Addresses.Item);
            UpdatedAtSec = int.Parse(entityPeople.Updated_at_sec);
            Relatives = GetRelatives(entityPeople.Relatives.Item);
            Categories = GetCategories(entityPeople.Categories.Item);
            BirthDateExtra = GetBirthDateExtra(entityPeople.Dob_extra.Item);
            BirthPlaceExtra = GetBirthPlaceExtra(entityPeople.Pob_extra.Item);
            Contacts = GetContacts(entityPeople.Contact_infos.Item);
        }

        public People() { }

        public override string ToString()
        {
            return $"{BlacklistId};" +
                    $"{AllNames};" +
                     $"{NameRawSource};" +
                      $"{BirthDate};" +
                       $"{BirthPlace};" +
                        $"{DocumentNumber};" +
                         $"{UpdatedAtSec};" +
                         $"{AddressRawSource};" +
                          $"{BirthDateExtra};" +
                           $"{BirthPlaceExtra}";
        }

        private List<Contact> GetContacts(List<Item> contacts)
        {
            if (contacts == null || !contacts.Any()) return new List<Contact>(0);

            var cont = contacts.Select(x =>
            {
                return new Contact() { ContactInfo = x.Text, Type = x.Type };
            }).ToList();

            return cont;
        }

        private string GetBirthDateExtra(List<Item> dobExtra)
        {
            if (dobExtra == null || !dobExtra.Any()) return string.Empty;

            var dobe = string.Join(_separator, dobExtra.Where(x => !string.IsNullOrWhiteSpace(x.Text)).Select(x => x.Text).Distinct());

            return dobe;
        }

        private string GetBirthPlaceExtra(List<Item> pobExtra)
        {
            if (pobExtra == null || !pobExtra.Any()) return string.Empty;

            var pobe = string.Join(_separator, pobExtra.Where(x => !string.IsNullOrWhiteSpace(x.Text)).Select(x => x.Text).Distinct());

            return pobe;
        }

        private List<string> GetCategories(List<string> categories)
        {
            if (categories == null || !categories.Any()) return new List<string>(0);

            return categories;
        }

        private List<Relative> GetRelatives(List<Item> relatives)
        {
            if (relatives == null || !relatives.Any()) return new List<Relative>(0);

            var rel = relatives.Select(x =>
            {
                return new Relative() { Id = int.Parse(x.Text), TypeRelationshipId = int.Parse(x.Type_id) };
            }).ToList();

            return rel;
        }

        private string GetAddress(List<Item> addresss)
        {
            if (addresss == null || !addresss.Any()) return string.Empty;

            var address = addresss[0].Address;

            return address;
        }

        private string GetDocumentNumber(List<Item> documents)
        {
            if (documents == null || !documents.Any()) return string.Empty;

            var document = documents[0].Mserial + documents[0].Number;

            return document;
        }

        private string GetNames(List<Item> names)
        {
            if (names == null || !names.Any()) return string.Empty;

            var name = string.Join(_separator, names.Select(x => x.Name).Distinct());

            return name;
        }

        /// <summary>
        /// system_id Идентификатор записи в X-Compliance
        /// </summary>
        public int BlacklistId { get; set; }

        /// <summary>
        /// names:item.name Все имена: ФИО лиц альтернативные (перечисление в одной строке через разделитель, брать уникальные значения)
        /// </summary>
        public string AllNames { get; set; }

        /// <summary>
        /// full_name Исходное имя: ФИО лица основное
        /// </summary>
        public string NameRawSource { get; set; }

        /// <summary>
        /// dob Дата рождения: основная
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// dob Дата рождения: альтернативные
        /// </summary>
        public string BirthDateExtra { get; set; }

        /// <summary>
        /// pob Место рождения: основное
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// pob Место рождения: альтернативные
        /// </summary>
        public string BirthPlaceExtra { get; set; }

        /// <summary>
        /// persdocs:item:mserial + persdocs:item:number Номер документа одной строкой
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// addresses:item:address Исходный адрес одной строкой
        /// </summary>
        public string AddressRawSource { get; set; }

        /// <summary>
        /// Дата последнего обновления анкеты 
        /// </summary>
        public int UpdatedAtSec { get; set; }

        /// <summary>
        /// Список идентификаторов лиц, связанных с физическим лицом
        /// </summary>
        public List<Relative> Relatives { get; set; }

        /// <summary>
        /// Список категорий, к которым принадлежит физическое лицо
        /// </summary>
        public List<string> Categories { get; set; }

        /// <summary>
        /// Список контактной информации лица
        /// </summary>
        public List<Contact> Contacts { get; set; }
    }
}