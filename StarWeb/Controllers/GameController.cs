using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StarWeb.Models;
using GridMvc.Html;


namespace StarWeb.Controllers
{
    public class GameController : Controller
    {
        int playerMax = 1;
        int sunMax = 3;        
        int planetMax = 10;
        int enemyMax = 20;
        int asteroidMax = 15;
        int starbaseMax = 5;
        int sunMin = 1;
        int planetMin = 3;
        int enemyMin = 10;
        int asteroidMin = 2;
        int starbaseMin = 0;
		static bool FirstRun = false;

        int currentTile;
        // GET: Game
        int r = 0;
        static Random rnd = new Random();

        static List<Tile>  galaxy = new List<Tile>();
        static List<Entity> entityList = new List<Entity>();

        public int CountEntitys()
        {
            return entityList.Count;
        }

        public void InitaliseGalaxy()
        {
            sunMax = rnd.Next(sunMin, sunMax);
            planetMax = rnd.Next(planetMin, planetMax);
            enemyMax = rnd.Next(enemyMin, enemyMax);
            asteroidMax = rnd.Next(asteroidMin, asteroidMax);
            starbaseMax = rnd.Next(starbaseMin, starbaseMax);

			//Empty,
			//Player,
			//Enemy,
			//StarBase,
			//Planet,
			//Asteriod,
			//Star

		

            for (int a = 0; a < 100; a++)
            {
                galaxy.Add(new Tile(0));
            }

            for (int b = 0; b < playerMax; b++)
            {
                currentTile = rnd.Next(0, 100);
                if (galaxy[currentTile].ItemContained == TileItems.Empty)
                {
                    galaxy[currentTile].ItemContained = TileItems.Player;
                    galaxy[currentTile].UpdateImage();
					
                    entityList.Add(new Entity(TileItems.Player, 100, currentTile, true));

                    
                }
                else b--;
            }

            for (int b = 0; b < planetMax; b++)
            {
                currentTile = rnd.Next(0, 100);
                if (galaxy[currentTile].ItemContained == TileItems.Empty)
                {
                    galaxy[currentTile].ItemContained = TileItems.Planet;
                    galaxy[currentTile].UpdateImage();
                }
                else b--;
            }

            for (int b = 0; b < enemyMax; b++)
            {
                currentTile = rnd.Next(0, 100);
                if (galaxy[currentTile].ItemContained == TileItems.Empty)
                {
                    galaxy[currentTile].ItemContained = TileItems.Enemy;
                    galaxy[currentTile].UpdateImage();
                    entityList.Add(new Entity(TileItems.Enemy, 100,currentTile,true));
                }
                else b--;
            }

            for (int b = 0; b < sunMax; b++)
            {
                currentTile = rnd.Next(0, 100);
                if (galaxy[currentTile].ItemContained == TileItems.Empty)
                {
                    galaxy[currentTile].ItemContained = TileItems.Star;
                    galaxy[currentTile].UpdateImage();
                }
                else b--;
            }

            for (int b = 0; b < asteroidMax; b++)
            {
                currentTile = rnd.Next(0, 100);
                if (galaxy[currentTile].ItemContained == TileItems.Empty)
                {
                    galaxy[currentTile].ItemContained = TileItems.Asteriod;
                    galaxy[currentTile].UpdateImage();
                }
                else b--;
            }

            for (int b = 0; b < starbaseMax; b++)
            {
                currentTile = rnd.Next(0, 100);
                if (galaxy[currentTile].ItemContained == TileItems.Empty)
                {
                    galaxy[currentTile].ItemContained = TileItems.StarBase;
                    galaxy[currentTile].UpdateImage();
                    entityList.Add(new Entity(TileItems.StarBase, 100, currentTile, true));
                }
                else b--;
            }
        }


        public class MyViewModel
        {
            public IEnumerable< List<Entity>> entities { get; set; }
            public IEnumerable<List<Tile>> Tiles { get; set; }
        }

        public ActionResult Index()
        {
			if (!FirstRun) {
				galaxy.Clear();
				InitaliseGalaxy();
				FirstRun = true;
			}
            var Combinedmodel = new MyViewModel
            {
                //entities = entityList,
                //Tiles = galaxy
            };
            return View(galaxy);

        }

		public ActionResult MoveNorth()
		{
			
			foreach(Entity e in entityList) {
				if (e.EntityType == TileItems.Player) {

					if (e.Position - 10 > 0) {
						if (galaxy [e.Position - 10].ItemContained == TileItems.Empty) {
							Tile tile = galaxy [e.Position];
							galaxy.RemoveAt(e.Position);
							galaxy.Insert(e.Position, new Tile(0));

							e.Position = e.Position - 10;
							galaxy.RemoveAt(e.Position);
							galaxy.Insert(e.Position, tile);
						}
					}
				}
			}

			return Redirect("/Game");
		}

		public ActionResult MoveSouth()
		{

			foreach (Entity e in entityList) {
				if (e.EntityType == TileItems.Player) {
					if (e.Position + 10 < 100) {
						if (galaxy [e.Position + 10].ItemContained == TileItems.Empty) {
							Tile tile = galaxy [e.Position];
							galaxy.RemoveAt(e.Position);
							galaxy.Insert(e.Position, new Tile(0));

							e.Position = e.Position + 10;
							galaxy.RemoveAt(e.Position);
							galaxy.Insert(e.Position, tile);
						}
					}
				}
			}

			return Redirect("/Game");
		}

		public ActionResult MoveEast()
		{

			foreach (Entity e in entityList) {
				if (e.EntityType == TileItems.Player) {
					if (e.Position +1 < 100) {
						if (galaxy [e.Position + 1].ItemContained == TileItems.Empty) {
							Tile tile = galaxy [e.Position];
							galaxy.RemoveAt(e.Position);
							galaxy.Insert(e.Position, new Tile(0));

							e.Position = e.Position + 1;
							galaxy.RemoveAt(e.Position);
							galaxy.Insert(e.Position, tile);
						}
					}
				}
			}

			return Redirect("/Game");
		}

		public ActionResult ReturnPlayerHP()
		{
			return View();
		}

		public ActionResult MoveWest()
		{

			foreach (Entity e in entityList) {
				if (e.EntityType == TileItems.Player) {
					if (e.Position - 1 > 0) {
						if (galaxy [e.Position - 1].ItemContained == TileItems.Empty) {
							Tile tile = galaxy [e.Position];
							galaxy.RemoveAt(e.Position);
							galaxy.Insert(e.Position, new Tile(0));

							e.Position = e.Position - 1;
							galaxy.RemoveAt(e.Position);
							galaxy.Insert(e.Position, tile);
						}
					}
				}
			}

			return Redirect("/Game");
		}
		public ActionResult NewGame()
		{
			FirstRun = false;
			return Redirect("/Game");
		}
    }
}