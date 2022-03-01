
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgEnterViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text ETxt_LabelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETxt_LabelText == null )
     			{
		    		this.m_ETxt_LabelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Sprite_BackGround/ETxt_Label");
     			}
     			return this.m_ETxt_LabelText;
     		}
     	}

		public UnityEngine.UI.Button EBtn_EnterButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtn_EnterButton == null )
     			{
		    		this.m_EBtn_EnterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/EBtn_Enter");
     			}
     			return this.m_EBtn_EnterButton;
     		}
     	}

		public UnityEngine.UI.Image EBtn_EnterImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtn_EnterImage == null )
     			{
		    		this.m_EBtn_EnterImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/EBtn_Enter");
     			}
     			return this.m_EBtn_EnterImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ETxt_LabelText = null;
			this.m_EBtn_EnterButton = null;
			this.m_EBtn_EnterImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_ETxt_LabelText = null;
		private UnityEngine.UI.Button m_EBtn_EnterButton = null;
		private UnityEngine.UI.Image m_EBtn_EnterImage = null;
		public Transform uiTransform = null;
	}
}
