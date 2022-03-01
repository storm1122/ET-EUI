
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_DlgShowRolesDestroySystem : DestroySystem<Scroll_Item_DlgShowRoles> 
	{
		public override void Destroy( Scroll_Item_DlgShowRoles self )
		{
			self.DestroyWidget();
		}
	}
}
