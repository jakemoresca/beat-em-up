using Godot;

namespace BoardGameFramework
{
    public class GridPosition
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public string ToEdgeString()
        {
            return $"col{Column}row{Row}";
        }
    }

    public static class BoardPositionHelper
    {
        public static bool IsSideDirection(string direction, string directionToCompare)
        {
            if (direction == "up" || direction == "down")
            {
                return directionToCompare == "left" || directionToCompare == "right";
            }
            else if (direction == "left" || direction == "right")
            {
                return directionToCompare == "up" || directionToCompare == "down";
            }

            return false;
        }

        public static bool IsOppositeDirection(string direction, string directionToCompare)
        {
            return directionToCompare == GetOppositeDirection(direction);
        }

        public static string GetOppositeDirection(string direction)
        {
            switch (direction)
            {
                case "up":
                    return "down";
                case "down":
                    return "up";
                case "left":
                    return "right";
                case "right":
                    return "left";
            }

            return string.Empty;
        }

        public static GridPosition GetTargetPosition(int column, int row, string direction, int range = 1)
        {
            switch (direction)
            {
                case "up":
                    row -= range;
                    break;

                case "left":
                    column -= range;
                    break;

                case "right":
                    column += range;
                    break;

                case "down":
                    row += range;
                    break;
            }

            return new GridPosition { Column = column, Row = row };
        }

        public static Vector2 GetTargetPosition(TileMap tilemap, GridPosition position, int tileSize, (int, int) initCoordinates)
        {
            var (initX, initY) = initCoordinates;

            var vector2Position = new Vector2(position.Column, position.Row);
            var targetPosition = tilemap.MapToWorld(vector2Position, true);

            var targetX = (targetPosition.x + (tileSize / 2)) * 1.5f;
            var targetY = (targetPosition.y + (tileSize / 2)) * 1.5f;

            return new Vector2(targetX, targetY);
        }
    }
}