using Godot;
using System;

namespace BoardGameFramework
{
    public class Board : Area2D
    {
        [Export]
        private int numberOfColumns = 0;

        [Export]
        private int numberOfRows = 0;

        [Export(PropertyHint.MultilineText, "Grid Cell Size")]
        private int tileSize = 48;

        [Export(PropertyHint.MultilineText, "First Cell Grid Coordinates X-Axis")]
        private int initX = -12;

        [Export(PropertyHint.MultilineText, "First Cell Grid Coordinates Y-Axis")]
        private int initY = -10;

        [Export]
        private string mapData = "";

        [Signal]
        private delegate void FinishedUpdating();

        private Node2D _currentSelectedNode;
        private TileMap _tileMap;
        private CollisionShape2D _collisionShape2D;

        public override void _Ready()
        {
            _tileMap = this.GetNode<TileMap>("./Ground");
            _collisionShape2D = this.GetNode<CollisionShape2D>("./CollisionShape2D");
        }

        public void SetDimension(int columns, int rows)
        {
            numberOfColumns = columns;
            numberOfRows = rows;
        }

        public (int, int) GetDimension()
        {
            return (numberOfColumns, numberOfRows);
        }

        public void SetTileSize(int tileSize)
        {
            this.tileSize = tileSize;
        }

        public int GetTileSize()
        {
            return tileSize;
        }

        public void SetInitCoordinates(int initX, int initY)
        {
            this.initX = initX;
            this.initY = initY;
        }

        public (int, int) GetInitCoordinates()
        {
            return (initX, initY);
        }

        public void SelectNode(Node2D node)
        {
            if (_currentSelectedNode != null && _currentSelectedNode.IsConnected("FinishedMovement", this, "_on_Player_FinishedMovement"))
                _currentSelectedNode.Disconnect("FinishedMovement", this, "_on_Player_FinishedMovement");

            _currentSelectedNode = node;

            _currentSelectedNode.Connect("FinishedMovement", this, "_on_Player_FinishedMovement");
        }

        public Node2D GetSelectedNode()
        {
            return _currentSelectedNode;
        }

        private void _on_Player_FinishedMovement(int column, int row, string direction)
        {
            EmitSignal(nameof(FinishedUpdating));
        }

        public TileMap Tilemap => _tileMap;

        public string MapDataFileName => mapData;

        public CollisionShape2D CollisionShape2D => _collisionShape2D;
    }
}
