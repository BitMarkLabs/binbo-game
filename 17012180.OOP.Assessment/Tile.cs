using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _17012180.OOP.Assessment
{
    internal class Tile : RectangleShape
    {
        public int X;
        public int Y;
        public string type;
        public bool IsFilled { get; set; } // Add IsFilled property

        
        public Tile ()
        {
            this.Size = new Vector2f(60, 60);
            this.Texture = new Texture("resources/img_floor.jpg");
            this.type = "f";
            IsFilled = false;
        }

    }

  
   
    internal class WallTile : Tile
    {
        public WallTile()
        {
            this.Texture = new Texture("resources/img_wall.jpg");
            this.type = "w";
        }
    }

    internal class DiamondTile : Tile
    {
        public int y, x ;
        public DiamondTile() 
        {
            this.Texture = new Texture("resources/img_diamond.jpg");
            this.type = "d";
        }
    }

    internal class Player : Tile
    {
        public int y, x;
        public Player()
        {
            this.Texture = new Texture("resources/img_player.jpg");
            this.type = "p";
        }
    }

    internal class CrateTile : Tile
    {
        public int y, x;
        public CrateTile()
        {
            this.Texture = new Texture("resources/img_crate.jpg");
            this.type = "c";
        }
    }

    internal class FilledCrateTile : Tile
    {
        public int y, x;

        public FilledCrateTile()
        {
            this.Texture = new Texture("resources/img_filled_crate.jpg");
            this.type = "t";
        }
    }

}
