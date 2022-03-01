
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgShowRolesViewComponentAwakeSystem : AwakeSystem<DlgShowRolesViewComponent> 
	{
		public override void Awake(DlgShowRolesViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgShowRolesViewComponentDestroySystem : DestroySystem<DlgShowRolesViewComponent> 
	{
		public override void Destroy(DlgShowRolesViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
