interface Transaction {
  id?: number;
  userId?: number;
  fromAccountId: number;
  toAccountId: number;
  amount: number;
}

export default Transaction;
