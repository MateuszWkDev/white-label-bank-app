namespace MainServices.Services
{
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        UserContract GetUserByLogin(string login);

        [OperationContract]
        int AuthenticateUser(string login, string password);
    }

    [DataContract]
    public class UserContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Login { get; set; }
    }
}
