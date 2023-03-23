using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Underdone;
public partial class Underdone : GameManager
{
	public static float LakeRadius = 512f;

	public Underdone()
	{
		if ( Game.IsClient )
		{
			_ = new Hud();	
			Log.Info( "this shit should be working big dawg" );
		}
	}

	public override void ClientJoined(IClient cl)
    {

		base.ClientJoined(cl);

		Reset( cl );
    }


	public static void Reset(IClient cl )
	{
		cl.Pawn?.Delete();

		var pawn = new PlayerClass();
		cl.Pawn = pawn;

		var clothing = new ClothingContainer();
		clothing.LoadFromClient( cl );
		clothing.DressEntity( pawn );

		var allSpawnPoints = Entity.All.OfType<SpawnPoint>();
		var randomSpawnPoint = allSpawnPoints.OrderBy( x => Guid.NewGuid() ).FirstOrDefault();

		pawn.Position = randomSpawnPoint.Position;
	}
}
