using System.Collections.Generic;
using System.Xml.Serialization;

namespace ComplianceRepository.Data
{
    [XmlRoot(ElementName = "response")]
    public class Peoples
    {
        [XmlElement(ElementName = "system_info")]
        public System_info System_info { get; set; }

        [XmlElement(ElementName = "entities")]
        public EntitiesPeoples Entities { get; set; }

        [XmlAttribute(AttributeName = "next_page")]
        public string Next_page { get; set; }

        [XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string NoNamespaceSchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
    }


    [XmlRoot(ElementName = "system_info")]
    public class System_info
    {
        [XmlElement(ElementName = "created_at")]
        public string Created_at { get; set; }
        [XmlElement(ElementName = "total")]
        public string Total { get; set; }
        [XmlElement(ElementName = "count")]
        public string Count { get; set; }
        [XmlElement(ElementName = "took")]
        public string Took { get; set; }
    }

    [XmlRoot(ElementName = "entities")]
    public class EntitiesPeoples
    {
        [XmlElement(ElementName = "entity")]
        public List<EntityPeople> Entity { get; set; }
    }

    [XmlRoot(ElementName = "entity")]
    public class EntityPeople
    {
        [XmlElement(ElementName = "system_id")]
        public string System_id { get; set; }

        [XmlElement(ElementName = "updated_at")]
        public string Updated_at { get; set; }

        [XmlElement(ElementName = "updated_at_sec")]
        public string Updated_at_sec { get; set; }

        [XmlElement(ElementName = "full_name")]
        public string Full_name { get; set; }

        [XmlElement(ElementName = "dob")]
        public string Dob { get; set; }

        [XmlElement(ElementName = "dob_extra")]
        public Dob_extra Dob_extra { get; set; }
        [XmlElement(ElementName = "dod")]
        public string Dod { get; set; }
        [XmlElement(ElementName = "dod_extra")]
        public Dod_extra Dod_extra { get; set; }
        [XmlElement(ElementName = "pob")]
        public string Pob { get; set; }
        [XmlElement(ElementName = "pob_extra")]
        public Pob_extra Pob_extra { get; set; }
        [XmlElement(ElementName = "dead")]
        public string Dead { get; set; }
        [XmlElement(ElementName = "gender")]
        public string Gender { get; set; }
        [XmlElement(ElementName = "names")]
        public Names Names { get; set; }
        [XmlElement(ElementName = "translit_names")]
        public Translit_names Translit_names { get; set; }
        [XmlElement(ElementName = "jobs")]
        public Jobs Jobs { get; set; }
        [XmlElement(ElementName = "incomes")]
        public Incomes Incomes { get; set; }
        [XmlElement(ElementName = "ownerships")]
        public Ownerships Ownerships { get; set; }
        [XmlElement(ElementName = "biography")]
        public string Biography { get; set; }
        [XmlElement(ElementName = "persdocs")]
        public Persdocs Persdocs { get; set; }
        [XmlElement(ElementName = "countries")]
        public Countries Countries { get; set; }

        [XmlElement(ElementName = "categories")]
        public Categories Categories { get; set; }

        [XmlElement(ElementName = "addresses")]
        public Addresses Addresses { get; set; }

        [XmlElement(ElementName = "contact_infos")]
        public Contact_infos Contact_infos { get; set; }

        [XmlElement(ElementName = "licenses")]
        public Licenses Licenses { get; set; }

        [XmlElement(ElementName = "sanctions")]
        public Sanctions Sanctions { get; set; }

        [XmlElement(ElementName = "watch_lists")]
        public Watch_lists Watch_lists { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "relatives")]
        public Relatives Relatives { get; set; }

        [XmlElement(ElementName = "sanlists")]
        public Sanlists Sanlists { get; set; }

        [XmlElement(ElementName = "category_407")]
        public Category_407 Category_407 { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlText]
        public string Text { get; set; }
        [XmlElement(ElementName = "last_name")]
        public string Last_name { get; set; }
        [XmlElement(ElementName = "first_name")]
        public string First_name { get; set; }
        [XmlElement(ElementName = "middle_name")]
        public string Middle_name { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "locale")]
        public string Locale { get; set; }
        [XmlAttribute(AttributeName = "updated_at")]
        public string Updated_at { get; set; }
        [XmlElement(ElementName = "authority")]
        public Authority Authority { get; set; }
        [XmlElement(ElementName = "categories")]
        public Categories Categories { get; set; }
        [XmlElement(ElementName = "category_407")]
        public Category_407 Category_407 { get; set; }
        [XmlAttribute(AttributeName = "date_start")]
        public string Date_start { get; set; }
        [XmlAttribute(AttributeName = "date_end")]
        public string Date_end { get; set; }
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlAttribute(AttributeName = "main")]
        public string Main { get; set; }
        [XmlAttribute(AttributeName = "unactive")]
        public string Unactive { get; set; }
        [XmlElement(ElementName = "income")]
        public Income Income { get; set; }
        [XmlElement(ElementName = "ownership")]
        public Ownership Ownership { get; set; }
        [XmlElement(ElementName = "mserial")]
        public string Mserial { get; set; }
        [XmlElement(ElementName = "number")]
        public string Number { get; set; }
        [XmlElement(ElementName = "common")]
        public string Common { get; set; }
        [XmlElement(ElementName = "issuing_country")]
        public string Issuing_country { get; set; }
        [XmlElement(ElementName = "issue")]
        public string Issue { get; set; }
        [XmlAttribute(AttributeName = "iso")]
        public string Iso { get; set; }
        [XmlAttribute(AttributeName = "en")]
        public string En { get; set; }
        [XmlElement(ElementName = "city")]
        public string City { get; set; }
        [XmlElement(ElementName = "address")]
        public string Address { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "sanlist_id")]
        public string Sanlist_id { get; set; }
        [XmlAttribute(AttributeName = "sanlist")]
        public string Sanlist { get; set; }
        [XmlAttribute(AttributeName = "fifty")]
        public string Fifty { get; set; }
        [XmlElement(ElementName = "sanction")]
        public Sanction Sanction { get; set; }
        [XmlElement(ElementName = "watch_list")]
        public Watch_list Watch_list { get; set; }
        [XmlAttribute(AttributeName = "type_id")]
        public string Type_id { get; set; }

        [XmlElement(ElementName = "owner")]
        public Owner Owner { get; set; }
    }

    [XmlRoot(ElementName = "owner")]
    public class Owner
    {
        [XmlAttribute(AttributeName = "system_id")]
        public string SystemId { get; set; }
       
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
       
        [XmlAttribute(AttributeName = "type_id")]
        public string TypeId { get; set; }

    }

    [XmlRoot(ElementName = "dob_extra")]
    public class Dob_extra
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "dod_extra")]
    public class Dod_extra
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "pob_extra")]
    public class Pob_extra
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "names")]
    public class Names
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "translit_names")]
    public class Translit_names
    {
        [XmlElement(ElementName = "item")]
        public List<string> Item { get; set; }
    }

    [XmlRoot(ElementName = "authority")]
    public class Authority
    {
        [XmlAttribute(AttributeName = "reg_id")]
        public string Reg_id { get; set; }
        [XmlAttribute(AttributeName = "address")]
        public string Address { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "jobs")]
    public class Jobs
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "income")]
    public class Income
    {
        [XmlAttribute(AttributeName = "cur")]
        public string Cur { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "incomes")]
    public class Incomes
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "ownership")]
    public class Ownership
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ownerships")]
    public class Ownerships
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "persdocs")]
    public class Persdocs
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "countries")]
    public class Countries
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "categories")]
    public class Categories
    {
        [XmlElement(ElementName = "item")]
        public List<string> Item { get; set; }
    }

    [XmlRoot(ElementName = "addresses")]
    public class Addresses
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "contact_infos")]
    public class Contact_infos
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "licenses")]
    public class Licenses
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "sanction")]
    public class Sanction
    {
        [XmlAttribute(AttributeName = "sanlist_id")]
        public string Sanlist_id { get; set; }
        [XmlAttribute(AttributeName = "sanction_id")]
        public string Sanction_id { get; set; }
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlAttribute(AttributeName = "reason_inclusion")]
        public string Reason_inclusion { get; set; }
        [XmlAttribute(AttributeName = "sanlist")]
        public string Sanlist { get; set; }
        [XmlAttribute(AttributeName = "country")]
        public string Country { get; set; }
        [XmlAttribute(AttributeName = "extra_informations")]
        public string Extra_informations { get; set; }
        [XmlAttribute(AttributeName = "uid")]
        public string Uid { get; set; }
        [XmlAttribute(AttributeName = "last_update_in_source")]
        public string Last_update_in_source { get; set; }
        [XmlAttribute(AttributeName = "reference_number")]
        public string Reference_number { get; set; }
        [XmlAttribute(AttributeName = "program_number")]
        public string Program_number { get; set; }
        [XmlAttribute(AttributeName = "type_name")]
        public string Type_name { get; set; }
        [XmlAttribute(AttributeName = "type_tag")]
        public string Type_tag { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "sanctions")]
    public class Sanctions
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "watch_list")]
    public class Watch_list
    {
        [XmlAttribute(AttributeName = "list_id")]
        public string List_id { get; set; }
        [XmlAttribute(AttributeName = "country")]
        public string Country { get; set; }
        [XmlAttribute(AttributeName = "authority")]
        public string Authority { get; set; }
        [XmlAttribute(AttributeName = "extra_information")]
        public string Extra_information { get; set; }
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "watch_lists")]
    public class Watch_lists
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "relatives")]
    public class Relatives
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "sanlists")]
    public class Sanlists
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "category_407")]
    public class Category_407
    {
        [XmlElement(ElementName = "item")]
        public List<string> Item { get; set; }
    }
}