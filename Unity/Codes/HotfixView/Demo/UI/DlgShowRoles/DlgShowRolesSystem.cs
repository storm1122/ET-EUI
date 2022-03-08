using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgShowRolesSystem
	{

		public static void RegisterUIEvent(this DlgShowRoles self)
		{
			self.View.E_RolesLoopHorizontalScrollRect.AddItemRefreshListener((Transform trans, int index) =>
			{
				self.OnScrollItemRefreshHandle(trans, index);
			});
			self.View.E_BtnCreateButton.AddListenerAsync(() => { return self.OnBtnCreateClickHandle(); });
			self.View.E_BtnDeleteButton.AddListenerAsync(() => { return self.OnBtnDeleteClickHandle(); });
			self.View.E_BtnEnterGameButton.AddListenerAsync(() => { return self.OnBtnConfirmClickHandler(); });
		}

		public static void ShowWindow(this DlgShowRoles self, Entity contextData = null)
		{
			self.RefreshRoleItems();
		}

		public static void RefreshRoleItems(this DlgShowRoles self)
		{
			int count = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos.Count;
			self.AddUIScrollItems(ref self.ScrollItemDic, count);
			self.View.E_RolesLoopHorizontalScrollRect.SetVisible(true,count);
		}
		

		public static void OnScrollItemRefreshHandle(this DlgShowRoles self, Transform trans , int index)
		{
			Scroll_Item_DlgShowRoles item = self.ScrollItemDic[index].BindTrans(trans);
			RoleInfo roleInfo = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos[index];
			item.E_TxtNameText.SetText(roleInfo.Name);
			var currentId = self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId;
			item.E_BtnClickImage.color = roleInfo.Id == currentId? Color.red : Color.white;
			item.E_BtnClickButton.AddListener(() => { self.OnScrollItemClickHandle(roleInfo.Id);});
		}

		public static void OnScrollItemClickHandle(this DlgShowRoles self , long id)
		{
			self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId = id;
			self.View.E_RolesLoopHorizontalScrollRect.RefillCells();
		}


		public static async ETTask OnBtnCreateClickHandle(this DlgShowRoles self)
		{
			try
			{
				int count = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos.Count;
				int err = await LoginHelper.CreateRole(self.DomainScene(), $"角色{count + 1}-{TimeHelper.ServerNow().ToString()}");

				if (err != ErrorCode.ERR_Success)
				{
					Log.Error(err.ToString());
					return;
				}

				self.RefreshRoleItems();
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}

			await Task.CompletedTask;
		}
		
		public static async ETTask OnBtnDeleteClickHandle(this DlgShowRoles self)
		{
			
			try
			{
				long id = self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId;
				int err = await LoginHelper.DeleteRole(self.DomainScene(), id );

				if (err != ErrorCode.ERR_Success)
				{
					Log.Error(err.ToString());
					return;
				}
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
			
			self.RefreshRoleItems();
			await Task.CompletedTask;
		}

		public static async ETTask OnBtnConfirmClickHandler(this DlgShowRoles self)
		{
			if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
			{
				Log.Error("需要选择一个角色");
				return;
			}

			try
			{
				int errorCode = await LoginHelper.GetRealmKey(self.ZoneScene());
				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
				
				errorCode = await LoginHelper.EnterGame(self.ZoneScene());
				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
				
				
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
				return;
			}

			await ETTask.CompletedTask;
		}
	}
}
