namespace ET
{
	[AUIEvent(WindowID.WindowID_ServerLinks)]
	public  class DlgServerLinksEventHandler : IAUIEventHandler
	{

		public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.WindowData.windowType = UIWindowType.Normal; 
		}

		public void OnInitComponent(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.AddComponent<DlgServerLinksViewComponent>(); 
		  uiBaseWindow.AddComponent<DlgServerLinks>(); 
		}

		public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.GetComponent<DlgServerLinks>().RegisterUIEvent(); 
		}

		public void OnShowWindow(UIBaseWindow uiBaseWindow, Entity contextData = null)
		{
		  uiBaseWindow.GetComponent<DlgServerLinks>().ShowWindow(contextData); 
		}

		public void OnHideWindow(UIBaseWindow uiBaseWindow)
		{
			uiBaseWindow.GetComponent<DlgServerLinks>().HideWindow(); 
		}

		public void BeforeUnload(UIBaseWindow uiBaseWindow)
		{
		}

	}
}
