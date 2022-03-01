using System;

namespace ET
{
    public class C2A_DeleteRoleHandler: AMRpcHandler<C2A_DeleteRole, A2C_DeleteRole>
    {
        protected override async ETTask Run(Session session, C2A_DeleteRole request, A2C_DeleteRole response, Action reply)
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
                    var roleInfos = await DBManagerComponent.Instance.GetZoneDB(request.ServerId)
                            .Query<RoleInfo>(d => d.Id == request.RoleInfoId && d.ServerId == request.ServerId);

                    if (roleInfos == null || roleInfos.Count == 0)
                    {
                        response.Error = ErrorCode.ERR_DeleteRoleIsNull;
                        reply();
                        return;
                    }

                    var roleInfo = roleInfos[0];
                    session.AddChild(roleInfo);

                    roleInfo.State = (int) RoleInfoState.Frozen;
                    
                    await DBManagerComponent.Instance.GetZoneDB(request.ServerId).Save<RoleInfo>(roleInfo);

                    response.DeleteRoleInfoId = roleInfo.Id;
                    roleInfo?.Dispose();
                    roleInfos.Clear();
                    reply();
                }
            }

            
            await ETTask.CompletedTask;
        }
    }
}