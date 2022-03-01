
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class Scroll_Item_DlgShowRoles : Entity,IAwake,IDestroy 
	{
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_DlgShowRoles BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_BtnClickButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_BtnClickButton == null )
     				{
		    			this.m_E_BtnClickButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BtnClick");
     				}
     				return this.m_E_BtnClickButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BtnClick");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_BtnClickImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_BtnClickImage == null )
     				{
		    			this.m_E_BtnClickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BtnClick");
     				}
     				return this.m_E_BtnClickImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BtnClick");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TxtNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_TxtNameText == null )
     				{
		    			this.m_E_TxtNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TxtName");
     				}
     				return this.m_E_TxtNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TxtName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BtnClickButton = null;
			this.m_E_BtnClickImage = null;
			this.m_E_TxtNameText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_BtnClickButton = null;
		private UnityEngine.UI.Image m_E_BtnClickImage = null;
		private UnityEngine.UI.Text m_E_TxtNameText = null;
		public Transform uiTransform = null;
	}
}
