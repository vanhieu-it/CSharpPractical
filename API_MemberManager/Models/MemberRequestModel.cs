namespace API_MemberManager.Models
{
    public class MemberRequestModel
    {
        private Guid _id;
        public Guid Id
        {
            get
            {
                if(_id == Guid.Empty)
                {
                    _id = Guid.NewGuid();
                }
                return _id;
            }
            set { _id = value; }
        }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }  
    }
}
