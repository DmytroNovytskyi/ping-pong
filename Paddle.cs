using Godot;

public partial class Paddle : CharacterBody2D
{
	[Export]
	public ushort Speed { get; set; } = 15;

	private int MinHeightBoundary;
	private int MaxHeightBoundary;

	public override void _Ready()
	{
		int HalfSpriteHeight = GetNode<Sprite2D>("Sprite2D").Texture.GetHeight() / 2;
		MinHeightBoundary = HalfSpriteHeight;
		MaxHeightBoundary = (int)(GetViewportRect().Size.Y - HalfSpriteHeight);
	}

	public override void _Process(double delta)
	{
		int velocity = ProcessInputs();
		SetPosition(velocity, delta);
	}


	private short ProcessInputs()
	{
		short velocity = 0;

		if (Input.IsActionPressed("player1_move_up"))
		{
			velocity = -1;
		}
		if (Input.IsActionPressed("player1_move_down"))
		{
			velocity = 1;
		}

		return velocity;
	}

	private void SetPosition(int velocity, double timePassed)
	{
		float Y = Mathf.Clamp(Position.Y + velocity * Speed, MinHeightBoundary, MaxHeightBoundary);
		Position = new Vector2(Position.X, Y);
	}
}
