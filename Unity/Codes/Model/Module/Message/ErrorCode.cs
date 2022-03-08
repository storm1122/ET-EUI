namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误
        
        // 110000以下的错误请看ErrorCore.cs
        
        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常

        public const int ERR_NetWorkError = 200002;
        public const int ERR_LoginInfoError = 200003;
        public const int ERR_RequestRepeatedly = 200004;
        public const int ERR_TokenError = 200009;
        public const int ERR_RoleNameIsNull = 200010;
        public const int ERR_RoleNameSame = 200011;
        public const int ERR_DeleteRoleIsNull = 200012;     //要删除的角色不存在
        public const int ERR_RequestSceneTypeError = 200013;    
        public const int ERR_ConnectGateError = 200014;    
        public const int ERR_OtherAccountLogin = 200015;   
        public const int ERR_SessionPlayerError = 200016;    
        public const int ERR_NonePlayerError = 200017;    
        public const int ERR_PlayerSessionError = 200018;
        public const int ERR_SessionStateError = 200019;
        public const int ERR_EnterGameError = 200020;
        public const int ERR_ReEnterGameError = 200021;
        public const int ERR_ReEnterGameError2 = 200022;

    }
}