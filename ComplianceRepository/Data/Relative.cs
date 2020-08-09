namespace ComplianceRepository.Data
{
    public class Relative
    {
        /// <summary>
        /// Идентификатор связанного лица
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор типа связи
        /// </summary>
        public int TypeRelationshipId { get; set; }
    }
}