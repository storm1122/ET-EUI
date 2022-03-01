namespace ET
{
    public enum AccountType
    {
        General,
        Blacklist,
    }
    public class Account : Entity,IAwake
    {
        public string AccountName;
        public string Password;
        public long CreateTime;
        public int AccountType;
    }
}