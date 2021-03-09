using System;
using System.Collections.Generic;
using TetrisUI;

namespace Tetris
{
    public abstract class Shape
    {
        public List<bool[,]> ShapesList = new List<bool[,]>();
        public abstract ShapeColor Color { get; }
        public int CurrentShapesLength;
        public int CurrentShapesWidth;

        public bool[,] GetShapeType(RotationMode rm)
        {
            GetShapeDimensions(rm);
            switch (rm)
            {
                case RotationMode.A:
                    return ShapesList[0];
                case RotationMode.B:
                    return ShapesList[1];
                case RotationMode.C:
                    return ShapesList[2];
                case RotationMode.D:
                    return ShapesList[3];
                default: throw new IndexOutOfRangeException();
            }
        }

        private void GetShapeDimensions(RotationMode rm)
        {
            int x;

            switch (rm)
            {
                case RotationMode.A:
                    x = 0;
                    for (var i = 0; i <= ShapesList[x].GetLength(0) - 1; i++)
                    for (var k = 0; k <= ShapesList[x].GetLength(1) - 1; k++)
                    {
                        if (!ShapesList[x][i, k]) continue;
                        if (i > CurrentShapesLength) CurrentShapesLength = i;
                        if (k > CurrentShapesWidth) CurrentShapesWidth = k;
                    }

                    break;
                case RotationMode.B:
                    x = 1;
                    for (var i = 0; i < ShapesList[x].GetLength(0); i++)
                    for (var k = 0; k < ShapesList[x].GetLength(1); k++)
                    {
                        if (!ShapesList[x][i, k]) continue;
                        if (i > CurrentShapesLength) CurrentShapesLength = i;
                        if (k > CurrentShapesWidth) CurrentShapesWidth = k;
                    }

                    break;
                case RotationMode.C:
                    x = 2;
                    for (var i = 0; i < ShapesList[x].GetLength(0); i++)
                    for (var k = 0; k < ShapesList[x].GetLength(1); k++)
                    {
                        if (!ShapesList[x][i, k]) continue;
                        if (i > CurrentShapesLength) CurrentShapesLength = i;
                        if (k > CurrentShapesWidth) CurrentShapesWidth = k;
                    }

                    break;
                case RotationMode.D:
                    x = 3;
                    for (var i = 0; i < ShapesList[x].GetLength(0); i++)
                    for (var k = 0; k < ShapesList[x].GetLength(1); k++)
                    {
                        if (!ShapesList[x][i, k]) continue;
                        if (i > CurrentShapesLength) CurrentShapesLength = i;
                        if (k > CurrentShapesWidth) CurrentShapesWidth = k;
                    }

                    break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }

    public enum RotationMode
    {
        A,
        B,
        C,
        D
    }

    public class Ishape : Shape
    {
        public Ishape()
        {
            // I shapes
            var I_0 = new[,]
            {
                {false, false, false, false},
                {true, true, true, true},
                {false, false, false, false},
                {false, false, false, false}
            };
            var I_90 = new[,]
            {
                {false, false, true, false},
                {false, false, true, false},
                {false, false, true, false},
                {false, false, true, false}
            };
            var I_180 = new[,]
            {
                {false, false, false, false},
                {false, false, false, false},
                {true, true, true, true},
                {false, false, false, false}
            };
            var I_270 = new[,]
            {
                {false, true, false, false},
                {false, true, false, false},
                {false, true, false, false},
                {false, true, false, false}
            };

            //ADDING SHAPES TO THE LIST
            ShapesList.Add(I_0);
            ShapesList.Add(I_90);
            ShapesList.Add(I_180);
            ShapesList.Add(I_270);
        }

        public override ShapeColor Color => ShapeColor.Cyan;
    }

    public class Jshape : Shape
    {
        public Jshape()
        {
            // J shapes
            var J_0 = new[,]
            {
                {true, false, false},
                {true, true, true},
                {false, false, false}
            };
            var J_90 = new[,]
            {
                {false, true, true},
                {false, true, false},
                {false, true, false}
            };
            var J_180 = new[,]
            {
                {false, false, false},
                {true, true, true},
                {false, false, true}
            };
            var J_270 = new[,]
            {
                {false, true, false},
                {false, true, false},
                {true, true, false}
            };

            //ADDING SHAPES TO THE LIST
            ShapesList.Add(J_0);
            ShapesList.Add(J_90);
            ShapesList.Add(J_180);
            ShapesList.Add(J_270);
        }

        public override ShapeColor Color => ShapeColor.Blue;
    }

    public class Lshape : Shape
    {
        public Lshape()
        {
            // L shapes
            var L_0 = new[,]
            {
                {false, false, true},
                {true, true, true},
                {false, false, false}
            };
            var L_90 = new[,]
            {
                {false, true, false},
                {false, true, false},
                {false, true, true}
            };
            var L_180 = new[,]
            {
                {false, false, false},
                {true, true, true},
                {true, false, false}
            };
            var L_270 = new[,]
            {
                {true, true, false},
                {false, true, false},
                {false, true, false}
            };

            //ADDING SHAPES TO THE LIST
            ShapesList.Add(L_0);
            ShapesList.Add(L_90);
            ShapesList.Add(L_180);
            ShapesList.Add(L_270);
        }

        public override ShapeColor Color => ShapeColor.Orange;
    }

    public class Oshape : Shape
    {
        public Oshape()
        {
            // O shapes
            var O_0 = new[,]
            {
                {false, true, true, false},
                {false, true, true, false},
                {false, false, false, false}
            };
            var O_90 = new[,]
            {
                {false, true, true, false},
                {false, true, true, false},
                {false, false, false, false}
            };
            var O_180 = new[,]
            {
                {false, true, true, false},
                {false, true, true, false},
                {false, false, false, false}
            };
            var O_270 = new[,]
            {
                {false, true, true, false},
                {false, true, true, false},
                {false, false, false, false}
            };

            //ADDING SHAPES TO THE LIST
            ShapesList.Add(O_0);
            ShapesList.Add(O_90);
            ShapesList.Add(O_180);
            ShapesList.Add(O_270);
        }

        public override ShapeColor Color => ShapeColor.Yellow;
    }

    public class Sshape : Shape
    {
        public Sshape()
        {
            // S shapes
            var S_0 = new[,]
            {
                {false, true, true},
                {true, true, false},
                {false, false, false}
            };
            var S_90 = new[,]
            {
                {false, true, false},
                {false, true, true},
                {false, false, true}
            };
            var S_180 = new[,]
            {
                {false, false, false},
                {false, true, true},
                {true, true, false}
            };
            var S_270 = new[,]
            {
                {true, false, false},
                {true, true, false},
                {false, true, false}
            };

            //ADDING SHAPES TO THE LIST
            ShapesList.Add(S_0);
            ShapesList.Add(S_90);
            ShapesList.Add(S_180);
            ShapesList.Add(S_270);
        }

        public override ShapeColor Color => ShapeColor.Green;
    }

    public class Tshape : Shape
    {
        public Tshape()
        {
            // T shapes
            var T_0 = new[,]
            {
                {false, true, false},
                {true, true, true},
                {false, false, false}
            };
            var T_90 = new[,]
            {
                {false, true, false},
                {false, true, true},
                {false, true, false}
            };
            var T_180 = new[,]
            {
                {false, false, false},
                {true, true, true},
                {false, true, false}
            };
            var T_270 = new[,]
            {
                {false, true, false},
                {true, true, false},
                {false, true, false}
            };

            //ADDING SHAPES TO THE LIST
            ShapesList.Add(T_0);
            ShapesList.Add(T_90);
            ShapesList.Add(T_180);
            ShapesList.Add(T_270);
        }

        public override ShapeColor Color => ShapeColor.Purple;
    }

    public class Zshape : Shape
    {
        public Zshape()
        {
            // Z shapes
            var Z_0 = new[,]
            {
                {true, true, false},
                {false, true, true},
                {false, false, false}
            };
            var Z_90 = new[,]
            {
                {false, false, true},
                {false, true, true},
                {false, true, false}
            };
            var Z_180 = new[,]
            {
                {false, false, false},
                {true, true, false},
                {false, true, true}
            };
            var Z_270 = new[,]
            {
                {false, true, false},
                {true, true, false},
                {true, false, false}
            };

            //ADDING SHAPES TO THE LIST
            ShapesList.Add(Z_0);
            ShapesList.Add(Z_90);
            ShapesList.Add(Z_180);
            ShapesList.Add(Z_270);
        }

        public override ShapeColor Color => ShapeColor.Red;
    }
}