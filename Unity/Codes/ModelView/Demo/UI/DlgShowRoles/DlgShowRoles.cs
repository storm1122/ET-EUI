using System.Collections.Generic;

namespace ET
{
	public  class DlgShowRoles :Entity,IAwake
	{

		public DlgShowRolesViewComponent View { get => this.Parent.GetComponent<DlgShowRolesViewComponent>();} 

		public Dictionary<int, Scroll_Item_DlgShowRoles> ScrollItemDic = new Dictionary<int, Scroll_Item_DlgShowRoles>();

	}
}
