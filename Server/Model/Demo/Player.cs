namespace ET
{
	public enum PlayerState
	{
		Disconnect, 
		Gate,
		Game,
	}
	
	
	[ObjectSystem]
	public class PlayerSystem : AwakeSystem<Player, long ,long>
	{
		public override void Awake(Player self, long Account , long RoleId)
		{
			self.Account = Account;
			self.UnitId = RoleId;
		}
	}

	public sealed class Player : Entity, IAwake<long,long> ,IAwake<string>
	{
		public long Account { get; set; }
		
		public long UnitId { get; set; }
		
		public long SessionInstanceId { get; set; }

		public PlayerState PlayerState { get; set; }

	}
}