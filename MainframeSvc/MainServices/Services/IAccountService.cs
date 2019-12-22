using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MainServices.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountService" in both code and config file together.
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        AccountContract GetAccount(int id);
        [OperationContract]
        List<int> GetAccountsForUser(int userId);
    }
    [DataContract]
    public class AccountContract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal Balance { get; set; }
    }
}
