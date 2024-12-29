public partial class GunPoint : Node3D
{
    MousePosition mousePosition;
    Camera3D camera;

    public override void _Ready()
    {
        mousePosition = this.AddChildOfType<MousePosition>();
        camera = GetViewport().GetCamera3D();
    }

    public override void _PhysicsProcess(double delta)
    {
        LookAtMouse();
    }

    // Function that rotates this node to look at the mouse position	
    public void LookAtMouse()
    {
        Vector2 mousePos = mousePosition.GetMousePosition();
        Vector3 from = camera.ProjectRayOrigin(mousePos);
        Vector3 to = from + camera.ProjectRayNormal(mousePos) * 1000;

        var spaceState = GetWorld3D().DirectSpaceState;
		var parameters = PhysicsRayQueryParameters3D.Create(from, to);
        var result = spaceState.IntersectRay(parameters);

        if (result.Count > 0)
        {
            Vector3 point = (Vector3)result["position"];
            LookAt(point, Vector3.Up);
        }
    }
}