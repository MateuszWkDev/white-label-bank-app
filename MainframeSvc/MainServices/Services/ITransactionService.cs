using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace MainServices.Services
{
    [ServiceContract]
    public interface ITransactionService
    {
        [OperationContract]
        List<TransactionContract> GetTransactionsForUser(int userId);
        [OperationContract]
        void PerformTransaction(TransactionContract transaction);
    }
    [DataContract]
    public class TransactionContract
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int FromAccountId { get; set; }
        [DataMember]
        public int ToAccountId { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
    }
}
