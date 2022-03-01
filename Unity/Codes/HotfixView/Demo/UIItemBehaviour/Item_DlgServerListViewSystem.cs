
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_DlgServerListDestroySystem : DestroySystem<Scroll_Item_DlgServerList> 
	{
		public override void Destroy( Scroll_Item_DlgServerList self )
		{
			self.DestroyWidget();
		}
	}
}
