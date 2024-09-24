using Godot;

public partial class Ball : CharacterBody2D
{
	[Export]
	public float Speed = 250.0F;

	public override void _Ready()
	{
		Velocity = new Vector2(-200, 0).Normalized() * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);
		if (collision is not null)
		{
			System.Console.WriteLine("Hit!");
			Velocity = Velocity.Bounce(collision.GetNormal()) * 1.1F;
		}
	}

	public void Hit(Vector2 hitVelocity)
	{
		
	}
}
