using System.Collections.Generic;

namespace ET
{
	public  class DlgServerLinks :Entity,IAwake
	{

		public DlgServerLinksViewComponent View { get => this.Parent.GetComponent<DlgServerLinksViewComponent>();} 
		
		public Dictionary<int, Scroll_Item_DlgServerList> ScrollItemDlgServerListsDic = new Dictionary<int, Scroll_Item_DlgServerList>();

	}
}
