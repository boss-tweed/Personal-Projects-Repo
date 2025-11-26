class Account {
    public decimal Balance { get; private set; }

    public Account(decimal initialBalance)
    { //Initial balance starts at $0
        if (initialBalance < 0)
            throw new ArgumentOutOfRangeException("Balance must be greater than $0. Please make a deposit");
        this.Balance = initialBalance;
    }

    public bool makeDeposit(decimal amount)
    {
        if (amount <= 0)
            return false;
        this.Balance += amount;
        return true;
    }
    
    public bool makeWithdrawl(decimal amount)
    {
        if (amount <= 0 || this.Balance - amount < 0)
            return false;
        this.Balance -= amount;
        return true;
    }
}