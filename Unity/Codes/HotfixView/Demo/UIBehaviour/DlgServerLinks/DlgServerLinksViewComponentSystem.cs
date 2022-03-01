
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgServerLinksViewComponentAwakeSystem : AwakeSystem<DlgServerLinksViewComponent> 
	{
		public override void Awake(DlgServerLinksViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgServerLinksViewComponentDestroySystem : DestroySystem<DlgServerLinksViewComponent> 
	{
		public override void Destroy(DlgServerLinksViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
