
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgShowRolesViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_BtnCreateButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnCreateButton == null )
     			{
		    		this.m_E_BtnCreateButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BtnCreate");
     			}
     			return this.m_E_BtnCreateButton;
     		}
     	}

		public UnityEngine.UI.Image E_BtnCreateImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnCreateImage == null )
     			{
		    		this.m_E_BtnCreateImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BtnCreate");
     			}
     			return this.m_E_BtnCreateImage;
     		}
     	}

		public UnityEngine.UI.Button E_BtnDeleteButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnDeleteButton == null )
     			{
		    		this.m_E_BtnDeleteButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BtnDelete");
     			}
     			return this.m_E_BtnDeleteButton;
     		}
     	}

		public UnityEngine.UI.Image E_BtnDeleteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnDeleteImage == null )
     			{
		    		this.m_E_BtnDeleteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BtnDelete");
     			}
     			return this.m_E_BtnDeleteImage;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect E_RolesLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RolesLoopHorizontalScrollRect == null )
     			{
		    		this.m_E_RolesLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"E_Roles");
     			}
     			return this.m_E_RolesLoopHorizontalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BtnCreateButton = null;
			this.m_E_BtnCreateImage = null;
			this.m_E_BtnDeleteButton = null;
			this.m_E_BtnDeleteImage = null;
			this.m_E_RolesLoopHorizontalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_BtnCreateButton = null;
		private UnityEngine.UI.Image m_E_BtnCreateImage = null;
		private UnityEngine.UI.Button m_E_BtnDeleteButton = null;
		private UnityEngine.UI.Image m_E_BtnDeleteImage = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_E_RolesLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
