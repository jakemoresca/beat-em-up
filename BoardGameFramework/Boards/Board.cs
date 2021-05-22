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
        private TileMap _tileMap;

        public override void _Ready()
        {
            _tileMap = this.GetNode<TileMap>("./Ground");
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

        public TileMap Tilemap => _tileMap;
    }
}
