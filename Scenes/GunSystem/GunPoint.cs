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

    public override void _Process(double delta)
    {
        LookAtMouse();
    }

    // Function that rotates this node to look at the mouse position
    private void LookAtMouse()
    {
        var mousePos = mousePosition.GetMousePosition();
        var worldPos = camera.ProjectPosition(mousePos, 1000);

        var spaceState = GetWorld3D().DirectSpaceState;
        var parameters = new PhysicsRayQueryParameters3D
        {
            From = camera.GlobalPosition,
            To = worldPos,
            CollisionMask = LayerHelper.GetLayer(Layer.Default),
        };
        var result = spaceState.IntersectRay(parameters);
        if (result.TryGetValue("position", out var position))
        {
            var point = (Vector3)position;
            LookAt(point);
        }

        DrawTools.DrawRay(rayMesh, camera.GlobalPosition, worldPos);
    }
}