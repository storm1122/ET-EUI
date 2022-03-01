using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgServerLinksSystem
	{

		public static void RegisterUIEvent(this DlgServerLinks self)
		{
			self.View.EButton_ConfirmButton.AddListenerAsync(() => { return self.OnBtnConfirmClickHandle(); });
			self.View.ELoopScrollList_ServerLinkLoopVerticalScrollRect.AddItemRefreshListener((Transform trans, int index) =>
			{
				self.OnScrollItemRefreshHandle(trans, index); });
		}

		public static void ShowWindow(this DlgServerLinks self, Entity contextData = null)
		{
			int count = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList.Count;
			self.AddUIScrollItems(ref self.ScrollItemDlgServerListsDic , count);
			self.View.ELoopScrollList_ServerLinkLoopVerticalScrollRect.SetVisible(true, count);
		}

		public static void HideWindow(this DlgServerLinks self)
		{
			self.RemoveUIScrollItems(ref self.ScrollItemDlgServerListsDic);
		}

		public static void OnScrollItemRefreshHandle(this DlgServerLinks self, Transform trans , int index)
		{
			Scroll_Item_DlgServerList item = self.ScrollItemDlgServerListsDic[index].BindTrans(trans);
			ServerInfo serverInfo = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList[index];
			item.ELabel_LabelText.SetText(serverInfo.ServerName);
			var currentId = self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId;
			item.EButton_ClickImage.color = serverInfo.Id == currentId? Color.red : Color.white;
			
			item.EButton_ClickButton.AddListener(() => { self.OnServerSelectedClickHandle(serverInfo.Id);});

		}

		public static void OnServerSelectedClickHandle(this DlgServerLinks self, long serverId)
		{
			self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId = int.Parse(serverId.ToString());
			Log.Console($"选择了服务器id: {serverId}");
			self.View.ELoopScrollList_ServerLinkLoopVerticalScrollRect.RefillCells();
		}

		public static async ETTask OnBtnConfirmClickHandle(this DlgServerLinks self)
		{
			bool isSelect = self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId != 0;
			if (!isSelect)
			{
				Log.Error("先选择区服");
				return;
			}

			try
			{
				int errorCode = await LoginHelper.GetRoles(self.DomainScene());
				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
				self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_ShowRoles);
				self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_ServerLinks);
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
