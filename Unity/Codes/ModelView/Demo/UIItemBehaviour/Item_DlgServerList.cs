
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class Scroll_Item_DlgServerList : Entity,IAwake,IDestroy 
	{
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_DlgServerList BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button EButton_ClickButton
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
     				if( this.m_EButton_ClickButton == null )
     				{
		    			this.m_EButton_ClickButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Click");
     				}
     				return this.m_EButton_ClickButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Click");
     			}
     		}
     	}

		public UnityEngine.UI.Image EButton_ClickImage
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
     				if( this.m_EButton_ClickImage == null )
     				{
		    			this.m_EButton_ClickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Click");
     				}
     				return this.m_EButton_ClickImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Click");
     			}
     		}
     	}

		public UnityEngine.UI.Text ELabel_LabelText
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
     				if( this.m_ELabel_LabelText == null )
     				{
		    			this.m_ELabel_LabelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_Click/ELabel_Label");
     				}
     				return this.m_ELabel_LabelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_Click/ELabel_Label");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EButton_ClickButton = null;
			this.m_EButton_ClickImage = null;
			this.m_ELabel_LabelText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EButton_ClickButton = null;
		private UnityEngine.UI.Image m_EButton_ClickImage = null;
		private UnityEngine.UI.Text m_ELabel_LabelText = null;
		public Transform uiTransform = null;
	}
}
