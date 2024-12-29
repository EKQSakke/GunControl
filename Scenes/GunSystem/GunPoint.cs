public partial class GunPoint : Node3D
{
	MousePosition mousePosition;
	Camera3D camera;
	MeshInstance3D rayMesh;

	public override void _Ready()
	{
		mousePosition = this.AddChildOfType<MousePosition>();
		camera = GetViewport().GetCamera3D();
		rayMesh = this.AddChildOfType<MeshInstance3D>();
	}

	public override void _PhysicsProcess(double delta)
	{
		LookAtMouse();
	}

	// Function that rotates this node to look at the mouse position	
	public void LookAtMouse()
	{
		var mousePos = mousePosition.GetMousePosition();
		var worldPos = camera.ProjectPosition(mousePos, 1000);

		var spaceState = GetWorld3D().DirectSpaceState;
		var parameters = PhysicsRayQueryParameters3D.Create(camera.GlobalPosition, worldPos, collisionMask: 1);
		var result = spaceState.IntersectRay(parameters);
		GD.Print($"{camera.GlobalPosition}, {worldPos}, {result.Count}");

		if (result.TryGetValue("position", out var position))
		{
			var point = (Vector3)position;
			LookAt(point, Vector3.Up);
		}

		DrawTools.DrawRay(rayMesh, camera.GlobalPosition, worldPos);
	}
}