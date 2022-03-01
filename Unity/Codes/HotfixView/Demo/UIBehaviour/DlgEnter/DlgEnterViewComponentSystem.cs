
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgEnterViewComponentAwakeSystem : AwakeSystem<DlgEnterViewComponent> 
	{
		public override void Awake(DlgEnterViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgEnterViewComponentDestroySystem : DestroySystem<DlgEnterViewComponent> 
	{
		public override void Destroy(DlgEnterViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
