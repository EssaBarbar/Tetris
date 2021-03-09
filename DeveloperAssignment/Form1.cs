using System;
using System.Collections.Generic;
using System.Linq;
using TetrisUI;

namespace Tetris
{
    public partial class Form1 : GameBoard
    {
        private readonly List<Pixel> _crumbs = new List<Pixel>();
        private int _x = 3;
        private int _y;
        private RotationMode _currentRotationMode = RotationMode.A;
        private static readonly Random Rnd = new Random();
        private List<Shape> _listOfShapes;
        private Shape _theCurrentShape;

        private void PopulateList()
        {
            _listOfShapes = new List<Shape>
            {
                new Ishape(),
                new Jshape(),
                new Lshape(),
                new Oshape(),
                new Sshape(),
                new Tshape(),
                new Zshape()
            };
        } 

        private Shape GetRandomShape()
        {
            // if (listOfShapes?.Any()??true)
            if (_listOfShapes == null || !_listOfShapes.Any()) PopulateList();
            var indexOfRandom = Rnd.Next(_listOfShapes.Count);
            var currentShape = _listOfShapes[indexOfRandom];
            _listOfShapes.Remove(currentShape);
            _y = 0;
            return currentShape;
        }

        public Form1() : base(1000 /*Set the speed of the game in milliseconds*/)
        {
            _theCurrentShape = GetRandomShape();
        }

        //<summary>
        //Runs every nn:th second set in gamespeed
        //</summary>
        protected override void UpdateGame()
        {
            Drop();
        }

        // <summary>
        // Renders gameboard
        // </summary>
        // <param name="render"></param>
        protected override void Render(IRender render)
        {
            // check if all x on the same Y are in the list then remove all pixels with the that Y

            // here will be the render of crumbs
            foreach (var crumb in _crumbs) render.Draw(crumb.X, crumb.Y, crumb.Color);

            //
            var currentShape = _theCurrentShape.GetShapeType(_currentRotationMode);
            var col = currentShape.GetLength(0);
            var row = currentShape.GetLength(1);
            for (var i = 0; i <= col - 1; i++)
            for (var k = 0; k <= row - 1; k++)
            {
                var drawPoint = currentShape[i, k];
                if (!drawPoint) continue;
                render.Draw(k + _x, i + _y, _theCurrentShape.Color);
            }
        }

        // <summary>
        // Runs on arrow up
        // </summary>
        protected override void Rotate()
        {
            switch (_currentRotationMode)
            {
                case RotationMode.A:
                    _currentRotationMode = RotationMode.B;
                    return;
                case RotationMode.B:
                    _currentRotationMode = RotationMode.C;
                    return;
                case RotationMode.C:
                    _currentRotationMode = RotationMode.D;
                    return;
                case RotationMode.D:
                    _currentRotationMode = RotationMode.A;
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // <summary>
        // Runs on arrow down
        // </summary>
        protected override void Drop()
        {
            if (_y + _theCurrentShape.CurrentShapesLength == 19)
            {
                Collision(_theCurrentShape);
                return;
            }

            _y++;
        }

        // <summary>
        // Runs on arrow left
        // </summary>
        protected override void MoveLeft()
        {
            if (_x == 0)
            {
                if (!_theCurrentShape.GetShapeType(_currentRotationMode)[0, 0] ||
                    !_theCurrentShape.GetShapeType(_currentRotationMode)[1, 0] ||
                    !_theCurrentShape.GetShapeType(_currentRotationMode)[2, 0]) return;
                if (_x == -1) return;
                _x--;
                return;
            }

            _x--;
        }

        // <summary>
        // Runs on arrow right
        // </summary>
        protected override void MoveRight()
        {
            if (_x + _theCurrentShape.CurrentShapesWidth == 9) return;
            _x++;
        }

        private void Collision(Shape theShapeToCollid)
        {
            SendTheCurrentShapeToCrumbs(theShapeToCollid);
            _theCurrentShape = GetRandomShape();
        }

        private void SendTheCurrentShapeToCrumbs(Shape shapeToSend)
        {
            var currentShape = shapeToSend.GetShapeType(_currentRotationMode);
            var col = currentShape.GetLength(0);
            var row = currentShape.GetLength(1);
            for (var i = 0; i <= col - 1; i++)
            for (var k = 0; k <= row - 1; k++)
            {
                var drawPoint = currentShape[i, k];
                if (!drawPoint) continue;
                var pixelToCrumbs = new Pixel {X = k + _x, Y = i + _y, Color = shapeToSend.Color};
                _crumbs.Add(pixelToCrumbs);
            }
        }
    }
}