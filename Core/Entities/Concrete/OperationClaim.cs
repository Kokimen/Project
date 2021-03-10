namespace Core.Entities.Concrete
{
    public class OperationClaim:IEntity
    {
        public int ClaimId { get; set; }
        public string ClaimName { get; set; }
    }
}