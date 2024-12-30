using System.Linq;

public enum Layer : uint {
    None = 0,
    Default = 1,        // 1 Anyhting to collide with
    Player = 2,         // 2
    Enemy = 4,          // 3
    Interactable = 8,   // 4 Anything that can be interacted with by player
    Blockage = 16,      // 5 Blocks breakable by enemies
}

public static class LayerHelper
{
    /// <summary>
    /// Gives combined layer bit value for given layers
    /// </summary>
    /// <param name="layers"></param>
    /// <returns>Bit value for given layers</returns>
    public static uint GetLayer(params Layer[] layers)
    {
        return (uint)layers.Sum(e => (uint) e);
    }
}