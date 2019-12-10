using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace StarWeb.Models
{
	

	public enum TileItems
    {
        Empty,
        Player,
        Enemy,
        StarBase,
        Planet,
        Asteriod,
        Star
    }



    public class Entity
    {
        public int HitPoints { get; set; } = 100;
        public int Position { get; set; }
        public bool isAlive { get; set; }
        public TileItems EntityType { get; set; }

        public Entity(TileItems type, int HP, int Pos, bool Alive)
        {
            EntityType = type;
			HitPoints = HP;
			Position = Pos;
			isAlive = Alive;
        }

    }


    public class Tile
    {
        public static Random rnd = new Random();
        

        public TileItems ItemContained { get; set; } = 0;
        public bool IsVisitable { get; set; } = true;
        public string ImageLocation { get; set; }
        

        public void ToggleVisitable()
        {
            if (IsVisitable) IsVisitable = false;
            else IsVisitable = true;
        }
        public void UpdateImage()
        {

			

			switch (ItemContained)
            {
                case TileItems.Asteriod:
                    ImageLocation = "Images/asteroid.png";
                    break;
                case TileItems.Planet:
				   ImageLocation = $"Images/PLANET{rnd.Next(1,12)}.png";
                    break;
                case TileItems.Player:
                    ImageLocation = "Images/Player1.png";
                    break;
                case TileItems.Enemy:
                    ImageLocation = "Images/Enemy1.png";
                    break;
                case TileItems.Empty:
                    ImageLocation = "Images/empty.png";
                    break;
                case TileItems.Star:
                    ImageLocation = $"Images/Star{rnd.Next(1, 4)}.png";
                    break;
                case TileItems.StarBase:
                    ImageLocation = "Images/StarBase.png";
                    break;
                default:
                    ImageLocation = "Images/rocket.png";
                    break;

            }
        }

        public Tile(TileItems initTile)
        {
            ItemContained = initTile;

            UpdateImage();


        }

     
    }


}