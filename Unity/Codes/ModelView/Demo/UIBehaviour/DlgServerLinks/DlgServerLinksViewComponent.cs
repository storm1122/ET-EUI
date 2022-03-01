
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgServerLinksViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text ELabel_SelectedServerText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_SelectedServerText == null )
     			{
		    		this.m_ELabel_SelectedServerText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_SelectedServer");
     			}
     			return this.m_ELabel_SelectedServerText;
     		}
     	}

		public UnityEngine.UI.Image ELoopScrollList_ServerLinkImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_ServerLinkImage == null )
     			{
		    		this.m_ELoopScrollList_ServerLinkImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ELoopScrollList_ServerLink");
     			}
     			return this.m_ELoopScrollList_ServerLinkImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_ServerLinkLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_ServerLinkLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_ServerLinkLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"ELoopScrollList_ServerLink");
     			}
     			return this.m_ELoopScrollList_ServerLinkLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_ConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ConfirmButton == null )
     			{
		    		this.m_EButton_ConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Confirm");
     			}
     			return this.m_EButton_ConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_ConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ConfirmImage == null )
     			{
		    		this.m_EButton_ConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Confirm");
     			}
     			return this.m_EButton_ConfirmImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELabel_SelectedServerText = null;
			this.m_ELoopScrollList_ServerLinkImage = null;
			this.m_ELoopScrollList_ServerLinkLoopVerticalScrollRect = null;
			this.m_EButton_ConfirmButton = null;
			this.m_EButton_ConfirmImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_ELabel_SelectedServerText = null;
		private UnityEngine.UI.Image m_ELoopScrollList_ServerLinkImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_ServerLinkLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_ConfirmButton = null;
		private UnityEngine.UI.Image m_EButton_ConfirmImage = null;
		public Transform uiTransform = null;
	}
}
