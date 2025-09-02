namespace MU.SnakeGame.CLI;

/// <summary>
/// Directions
/// 00 - Horizontal; 01 - Vertical
/// 00 - Decreasing; 10 - Increasing
/// 0 - Left
/// 1 - Down
/// 2 - Right
/// 3 - Up
/// </summary>
[Flags]
public enum Direction
{
    Left = 0,
    Down = 1, 
    Right = 2,
    Up = 3,
}