using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MainServices.Services
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        UserContract GetUserByLogin(string login);
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
