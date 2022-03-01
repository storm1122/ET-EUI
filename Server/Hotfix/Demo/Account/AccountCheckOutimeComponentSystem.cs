using System;

namespace ET
{
    [Timer(TimerType.AccountSessionCheckOuttime)]
    public class AccountSessionChectOuttimer: ATimer<AccountCheckOutimeComponent>
    {
        public override void Run(AccountCheckOutimeComponent self)
        {
            try
            {
                self.DeleteSession();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }

    public class AccountCheckOutimeComponentAwakeSystem: AwakeSystem<AccountCheckOutimeComponent, long>
    {
        public override void Awake(AccountCheckOutimeComponent self, long accountId)
        {
            self.AccountId = accountId;
            TimerComponent.Instance.Remove(ref self.Timer);
            self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 600000, TimerType.AccountSessionCheckOuttime, self);
        }
    }

    public class AccountCheckOutimeComponentDestroySystem: DestroySystem<AccountCheckOutimeComponent>
    {
        public override void Destroy(AccountCheckOutimeComponent self)
        {
            self.AccountId = 0;
            TimerComponent.Instance.Remove(ref self.Timer);
        }
    }

    public static class AccountCheckOutimeComponentSystem
    {
        public static void DeleteSession(this AccountCheckOutimeComponent self)
        {
            Session session = self.GetParent<Session>();
            long sessionInstanceId = session.DomainScene().GetComponent<AccountSessionsComponent>().Get(self.AccountId);
            if (session.InstanceId == sessionInstanceId)
            {
                session.DomainScene().GetComponent<AccountSessionsComponent>().Remove(self.AccountId);
            }
            
            session?.Send(new A2C_Disconnect(){Error = 1});
            session?.Disconnect().Coroutine();
        }
    }
}