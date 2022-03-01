using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgEnterSystem
	{

		public static void RegisterUIEvent(this DlgEnter self)
		{
			self.View.EBtn_EnterButton.AddListener(() =>
			{
				self.OnEnterBtnClick().Coroutine();
			});
		}

		public static void ShowWindow(this DlgEnter self, Entity contextData = null)
		{
			self.View.ETxt_LabelText.text = "DlgEnter";
		}

		public static async ETTask OnEnterBtnClick(this DlgEnter self)
		{
			R2C_Login r2CLogin = await self.Login();
			
			// 创建一个gate Session,并且保存到SessionComponent中
			Session gateSession = self.ZoneScene().GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2CLogin.Address));
			gateSession.AddComponent<PingComponent>();
			self.ZoneScene().AddComponent<SessionComponent>().Session = gateSession;
				
			G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await gateSession.Call(
				new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId});

			Log.Debug("登陆gate成功!");
			
		}

		public static async ETTask<R2C_Login> Login(this DlgEnter self)
		{
			R2C_Login r2CLogin;
			Session session = null;
			try
			{
				session = self.ZoneScene().GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(ConstValue.LoginAddress));
				{
					r2CLogin = (R2C_Login) await session.Call(new C2R_Login() { Account = "", Password = "" });
				}
			}
			finally
			{
				session?.Dispose();
			}
			return r2CLogin;
		}
		

	}
}
