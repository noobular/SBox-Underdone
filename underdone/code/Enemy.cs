using Sandbox;
using System;
using System.Linq;

namespace Underdone;

partial class Enemy : AnimatedEntity
{

	public PlayerClass EnemyTarget;
	LevelSystem levelSystem = new LevelSystem();

	public override void Spawn()
	{
		base.Spawn();
		
		SetModel( "models/citizen/citizen.vmdl" );
		Scale = 1.5f;
		EnableDrawing = false;

		Position = Vector3.Forward * Underdone.LakeRadius;

		var kongCostume = new AnimatedEntity( "models/kong.vmdl_c" );
		kongCostume.SetParent(this,true);
	}

	[Event.Tick.Server]
	public void ComputeAI()
	{
		if (EnemyTarget == null) return;

		Rotation currentRotation = Rotation.LookAt( Position, Vector3.Up );
		Rotation targetRotation = Rotation.LookAt( EnemyTarget.Position, Vector3.Up );
		float rotationDistance = currentRotation.Distance( targetRotation );
		float rotationStep = Time.Delta / rotationDistance * 90f;

		Rotation newRotation = Rotation.Slerp( currentRotation, targetRotation, rotationStep );
		var newPosition = newRotation.Forward * Underdone.LakeRadius;
		Velocity = (newPosition - Position) / Time.Delta;
		Position = newPosition;

		if ( !Velocity.IsNearlyZero( 0.1f ) )
			Rotation = Rotation.Slerp( Rotation, Rotation.LookAt( Velocity, Vector3.Up ), Time.Delta * 10f );

		var animationHelper = new CitizenAnimationHelper( this );
		animationHelper.WithVelocity( Velocity / Scale);


		if ( Position.Distance(EnemyTarget.Position) <= 30f )
		{
			Underdone.Reset( EnemyTarget.Client );
		}
	}
}
