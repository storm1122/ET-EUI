using System.Collections.Generic;

namespace ET
{
    public class AccountSessionsComponent: Entity, IAwake,IDestroy
    {
        public Dictionary<long, long> AccountSessionDic = new Dictionary<long, long>();
    }
}