﻿using System;

namespace ET
{
    public class C2A_GetRoleHandler: AMRpcHandler<C2A_GetRole, A2C_GetRole>
    {
        protected override async ETTask Run(Session session, C2A_GetRole request, A2C_GetRole response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }
            
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                session?.Disconnect().Coroutine();
                return;
            }
            
            string token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);
            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session?.Disconnect().Coroutine();
                return;
            }


            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRole, request.AccountId))
                {
                    var roles = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                            .Query<RoleInfo>(d =>
                                    d.AccountId == request.AccountId && d.ServerId == request.ServerId && d.State == (int) RoleInfoState.Normal);

                    if (roles == null || roles.Count == 0)
                    {
                        reply();
                        return;
                    }

                    foreach (var role in roles)
                    {
                        response.RoleinfosList.Add(role.ToMessage());
                        role?.Dispose();
                    }
                    roles.Clear();
                    reply();
                }
            }
            
            
                
            await ETTask.CompletedTask;
        }
    }
}