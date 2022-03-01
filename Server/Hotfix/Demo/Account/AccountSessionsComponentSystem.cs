namespace ET
{
    public class AccountSessionsComponentDsetroySystem: DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.AccountSessionDic.Clear();
        }
    }

    public static class AccountSessionsComponentSystem
    {
        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            if (!self.AccountSessionDic.TryGetValue(accountId, out long instanceId))
            {
                return 0;
            }
            return instanceId;
        }

        public static void Add(this AccountSessionsComponent self, long accountId, long instanceId)
        {
            if (self.AccountSessionDic.ContainsKey(accountId))
            {
                self.AccountSessionDic[accountId] = instanceId;
                return;
            }
            self.AccountSessionDic.Add(accountId, instanceId);
        }

        public static void Remove(this AccountSessionsComponent self, long accountId)
        {
            if (self.AccountSessionDic.ContainsKey(accountId))
            {
                self.AccountSessionDic.Remove(accountId);
            }
        }
    }
}