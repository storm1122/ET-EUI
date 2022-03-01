namespace ET
{
    public class AccountCheckOutimeComponent : Entity , IAwake<long>, IDestroy
    {
        public long Timer = 0;
        public long AccountId = 0;
    }
}