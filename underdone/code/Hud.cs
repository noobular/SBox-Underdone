using Sandbox.UI;
namespace Underdone
{
	internal class Hud : RootPanel
	{
		public Hud() 
		{
			AddChild<MouseUse>(); //Force mouse to always be active
			AddChild<QuestMenu>();
			AddChild<InventoryMenu>();
		}
	}
}
