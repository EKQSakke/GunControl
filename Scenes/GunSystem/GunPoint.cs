public partial class GunPoint : Node3D
{
	MousePosition mousePosition;

	public override void _Ready()
	{
		mousePosition = this.AddChildOfType<MousePosition>();
	}

	public override void _PhysicsProcess(double delta)
	{
		LookAtMouse();
	}

	// Function that rotates this node to look at the mouse position	
	public void LookAtMouse()
	{

	}
}