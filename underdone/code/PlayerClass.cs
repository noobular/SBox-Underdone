using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Underdone;

partial class PlayerClass : AnimatedEntity
{
	LevelSystem Levels = new LevelSystem();
	InventorySystem Inv = new InventorySystem();

	public Enemy Enemy;

	public float Speed = 200f;

	public bool IsOutOfLake => Position.Distance( Vector3.Zero ) > Underdone.LakeRadius;

	

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/citizen/citizen.vmdl" );

		Enemy = new Enemy { EnemyTarget = this };

		Levels.SetLevel( 50 );
		Log.Info( "Level: " + Levels.GetLevel().ToString() + " | Experience: " + Levels.GetExperience().ToString() );

		Log.Info(Inv.GetItems());


	}

	protected override void OnDestroy()
	{
		base.OnDestroy();

		if ( Game.IsServer )
		{
			Enemy.Delete();
		}
	}

	public override void Simulate( IClient cl)
    {
		base.Simulate( cl );

		var moveDirection = InputDirection.Normal;

		var wishVelocity = moveDirection * Speed * (IsOutOfLake ? 2 : 1);

		Velocity = Vector3.Lerp(Velocity, wishVelocity, Time.Delta*10f);
		Position += Velocity * Time.Delta;

		if(!Velocity.IsNearlyZero(0.1f))
			Rotation = Rotation.Slerp(Rotation, Rotation.LookAt(Velocity, Vector3.Up), Time.Delta * 10f);

		var animationHelper = new CitizenAnimationHelper(this);
		animationHelper.WithVelocity(Velocity);
		animationHelper.IsSwimming = !IsOutOfLake; 

    }


	public override void FrameSimulate(IClient cl)
    {
		base.FrameSimulate(cl);

		Camera.Position = Position + Vector3.Up * 1000f;

		Camera.Rotation = Rotation.FromPitch(90f);
    }

	[ClientInput] public Vector3 InputDirection { get; set; }
	public override void BuildInput()
    {
		base.BuildInput();

		InputDirection = Input.AnalogMove;
		//Log.Info(InputDirection);
    }
}
