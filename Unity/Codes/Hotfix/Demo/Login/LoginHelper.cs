using System;
using UnityEngine;

namespace ET
{
    public static class LoginHelper
    {
        public static async ETTask<int> Login(Scene zoneScene, string address, string account, string password)
        {
            A2C_LoginAccount a2CLoginAccount = null;
            Session accountSession = null;

            try
            {
                accountSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                password = MD5Helper.StringMD5(password);
                a2CLoginAccount = (A2C_LoginAccount) await accountSession.Call(new C2A_LoginAccount() { AccountName = account, Password = password });
            }
            catch (Exception e)
            {
                accountSession?.Dispose();
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2CLoginAccount.Error != ErrorCode.ERR_Success)
            {
                accountSession?.Dispose();
                return a2CLoginAccount.Error;
            }
            
            zoneScene.AddComponent<SessionComponent>().Session = accountSession;
            zoneScene.GetComponent<SessionComponent>().Session.AddComponent<PingComponent>();

            zoneScene.GetComponent<AccountInfoComponent>().Token = a2CLoginAccount.Token;
            zoneScene.GetComponent<AccountInfoComponent>().AccountId = a2CLoginAccount.AccountId;
            

            return ErrorCode.ERR_Success;
        }



        public static async ETTask<int> GetRoles(Scene zoneScene)
        {
            A2C_GetRole a2CGetRole = null;
            try
            {
                a2CGetRole = (A2C_GetRole) await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRole()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2CGetRole.Error != ErrorCode.ERR_Success)
            {
                return a2CGetRole.Error;
            }
            
            zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Clear();

            foreach (var roleProto in a2CGetRole.RoleinfosList)
            {
                var roleInfo = zoneScene.GetComponent<RoleInfosComponent>().AddChild<RoleInfo>();
                roleInfo.FromMessage(roleProto);
                zoneScene.GetComponent<RoleInfosComponent>().Add(roleInfo);
            }
            

            return ErrorCode.ERR_Success;
        }
        
        public static async ETTask<int> GetServerInfos(Scene zoneScene)
        {
            A2C_GetServerInfos a2CGetServerInfos = null;
            try
            {
                a2CGetServerInfos = (A2C_GetServerInfos) await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetServerInfos()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2CGetServerInfos.Error != ErrorCode.ERR_Success)
            {
                return a2CGetServerInfos.Error;
            }

            foreach (var serverInfoProto in a2CGetServerInfos.ServerInfosList)
            {
                ServerInfo serverInfo = zoneScene.GetComponent<ServerInfosComponent>().AddChild<ServerInfo>();
                serverInfo.FromMessage(serverInfoProto);
                zoneScene.GetComponent<ServerInfosComponent>().Add(serverInfo);
            }
            
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> CreateRole(Scene zoneScene, string name)
        {
            A2C_CreateRole a2CCreateRole = null;
            try
            {
                a2CCreateRole = (A2C_CreateRole) await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_CreateRole()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    Name = name,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2CCreateRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2CCreateRole.Error.ToString());
                return a2CCreateRole.Error;
            }

            RoleInfo newRoleInfo = zoneScene.GetComponent<RoleInfosComponent>().AddChild<RoleInfo>();
            newRoleInfo.FromMessage(a2CCreateRole.RoleInfo);
            zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Add(newRoleInfo);
            
            return ErrorCode.ERR_Success;
        }



        public static async ETTask<int> DeleteRole(Scene zoneScene, long roleId)
        {
            A2C_DeleteRole a2CDeleteRole = null;

            try
            {
                a2CDeleteRole = (A2C_DeleteRole) await zoneScene.GetComponent<SessionComponent>().Session
                        .Call(new C2A_DeleteRole()
                        {
                            AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                            Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                            RoleInfoId = zoneScene.GetComponent<RoleInfosComponent>().CurrentRoleId,
                            ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                        });

            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2CDeleteRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2CDeleteRole.Error.ToString());
                return a2CDeleteRole.Error;
            }

            int idx = zoneScene.GetComponent<RoleInfosComponent>().RoleInfos
                    .FindIndex((info) => { return info.Id == a2CDeleteRole.DeleteRoleInfoId; });
            
            zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.RemoveAt(idx);
            
            
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }



        public static async ETTask<int> GetRealmKey(Scene zoneScene)
        {
            A2C_GetRealmKey a2CGetRealmKey = null;

            try
            {
                a2CGetRealmKey = (A2C_GetRealmKey) await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRealmKey()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                });


            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2CGetRealmKey.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2CGetRealmKey.Error.ToString());
                return a2CGetRealmKey.Error;
            }

            zoneScene.GetComponent<AccountInfoComponent>().RealmKey = a2CGetRealmKey.RealmKey;
            zoneScene.GetComponent<AccountInfoComponent>().RealmAddress = a2CGetRealmKey.RealmAddress;


            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        
        
    }
}