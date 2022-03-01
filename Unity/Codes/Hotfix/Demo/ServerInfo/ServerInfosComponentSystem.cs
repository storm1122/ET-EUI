using System.Collections.Generic;

namespace ET
{
    public class ServerInfosComponentDestorySystem: DestroySystem<ServerInfosComponent>
    {
        public override void Destroy(ServerInfosComponent self)
        {
            foreach (var serverInfo in self.ServerInfoList)
            {
                serverInfo?.Dispose();
            }
            self.ServerInfoList.Clear();
        }
    }


    public static class ServerInfosComponentSystem
    {
        public static void Add(this ServerInfosComponent self, ServerInfo serverInfo)
        {
            self.ServerInfoList.Add(serverInfo);
        }
        
        public static List<ServerInfo> Get(this ServerInfosComponent self)
        {
            return self.ServerInfoList;
        }
    }
}