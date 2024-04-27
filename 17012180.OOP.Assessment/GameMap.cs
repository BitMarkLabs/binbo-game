using SFML.Graphics;
using SFML.System;
using SFML.Window;




namespace _17012180.OOP.Assessment
{
    public class GameMap
    {
        
        private Tile[,] map;
       
        public enum MoveDirections { Left, Right, Up, Down };
        private int player_x = 3;
        private int player_y = 3;
        private int points = 0;
        private int movements = 0;
        
     
        public string[] all_file;
        

        bool level_two_loaded = false;
        bool level_three_loaded = false;
       
       
        

        public GameMap()
        {
            
            map = new Tile[10, 10];
            all_file = File.ReadAllLines("maps/Map0.map");

            //Console.WriteLine(all_file[0][0]);    
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    map[y, x] = new Tile();
                    map[y, x].Position = new Vector2f(x * 60f, y * 60f);
                    
                    // Set wall texture for the edges
                    if (all_file[y][x] == 'W')
                    {
                        map[y, x] = new WallTile();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);
                    }

                    else if (all_file[y][x] == 'F')
                    {
                        map[y, x] = new Tile();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);

                    }


                    // Add diamonds
                    else if (all_file[y][x] == 'D')
                    {
                        map[y, x] = new DiamondTile();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);

                    }

                    // Add empty crates
                    else if (all_file[y][x] == 'C')
                    {
                        map[y, x] = new CrateTile();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);
                    }

                    else if (all_file[y][x] == 'P')
                    {
                        map[y, x] = new Player();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);
                        player_x = x;
                        player_y = y;
                    }
                }
            }

        }

        private void levelTwo()
        {
            //all_file[0] = null;
            all_file = File.ReadAllLines("maps/Map1.map");
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    map[y, x] = new Tile();
                    map[y, x].Position = new Vector2f(x * 60f, y * 60f);

                    // Set wall texture for the edges
                    if (all_file[y][x] == 'W')
                    {
                        map[y, x] = new WallTile();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);
                    }

                    else if (all_file[y][x] == 'F')
                    {
                        map[y, x] = new Tile();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);

                    }


                    // Add diamonds
                    else if (all_file[y][x] == 'D')
                    {
                        map[y, x] = new DiamondTile();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);

                    }

                    // Add empty crates
                    else if (all_file[y][x] == 'C')
                    {
                        map[y, x] = new CrateTile();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);
                    }

                    else if (all_file[y][x] == 'P')
                    {
                        map[y, x] = new Player();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);
                        player_x = x;
                        player_y = y;
                    }



                }
            }
        }

        private void levelThree()
        {
            all_file = File.ReadAllLines("maps/Map2.map");
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    map[y, x] = new Tile();
                    map[y, x].Position = new Vector2f(x * 60f, y * 60f);

                    // Set wall texture for the edges
                    if (all_file[y][x] == 'W')
                    {
                        map[y, x] = new WallTile();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);
                    }

                    else if (all_file[y][x] == 'F')
                    {
                        map[y, x] = new Tile();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);

                    }


                    // Add diamonds
                    else if (all_file[y][x] == 'D')
                    {
                        map[y, x] = new DiamondTile();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);

                    }

                    // Add empty crates
                    else if (all_file[y][x] == 'C')
                    {
                        map[y, x] = new CrateTile();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);
                    }

                    else if (all_file[y][x] == 'P')
                    {
                        map[y, x] = new Player();
                        map[y, x].Position = new Vector2f(x * 60f, y * 60f);
                        player_x = x;
                        player_y = y;
                    }
                }
            }
        }


        public void DrawMap(RenderWindow window)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    window.Draw(map[y, x]);
                }
            }


                if (points >= 20)
                {
                    if (level_two_loaded == false)
                    {
                        levelTwo();
                        level_two_loaded = true;
                    }

                    else if (points >= 40)
                    {
                        if (level_three_loaded == false)
                        {
                            levelThree();
                            level_three_loaded = true;
                        }
                    }

                }
        }

    public void MovePlayer(MoveDirections direction)
        {
            try
            {
                // Update player position based on direction
                int newPlayerX = player_x;
                int newPlayerY = player_y;
                movements++;

                if (direction == MoveDirections.Up && player_y > 0)
                {
                    newPlayerY--;

                }
                else if (direction == MoveDirections.Down && player_y < 9)
                {
                    newPlayerY++;
    
                }
                else if (direction == MoveDirections.Left && player_x > 0)
                {
                    newPlayerX--;
                    
                }
                else if (direction == MoveDirections.Right && player_x < 9)
                {
                    newPlayerX++;
                    
                }

                // Check if the new position is a wall or filled crate
                if (map[newPlayerY, newPlayerX].type == "w" || map[newPlayerY, newPlayerX].type == "t")
                {
                    movements--;
                    // Stop movement
                    return;
                    
                }


                // Check if the new position contains a crate
                if (map[newPlayerY, newPlayerX].type == "c")
                {
                    // Calculate the next position for the crate
                    int nextCrateX = newPlayerX + (newPlayerX - player_x);
                    int nextCrateY = newPlayerY + (newPlayerY - player_y);


                    // Check if the next position for the crate is valid and empty
                    if (nextCrateX >= 0 && nextCrateX < 10 && nextCrateY >= 0 && nextCrateY < 10 &&
                        map[nextCrateY, nextCrateX].type != "w" && map[nextCrateY, nextCrateX].type != "c"
                         && map[nextCrateY, nextCrateX].type != "t")
                        
                    {
                        // If the crate touches a diamond, turn it into TNT
                        if (map[nextCrateY, nextCrateX].type == "d")
                        {
                            map[nextCrateY, nextCrateX].type = "t";
                            map[nextCrateY, nextCrateX].Texture = new Texture("resources/img_filled_crate.jpg");
                            map[newPlayerY, newPlayerX].type = "f";
                            points += 10;

                        }

                        else
                        {   
                            // Move the crate to the next position
                            map[nextCrateY, nextCrateX].type = "c";
                            map[nextCrateY, nextCrateX].Texture = new Texture("resources/img_crate.jpg");
                            map[newPlayerY, newPlayerX].type = "f";

                        }

                    }

                    else
                    {
                        // Stop movement if the next position for the crate is invalid or not empty
                        movements--;
                        return;
                    }



                }

                // Move the player to the new position

                if(map[player_y, player_x].type == "d")
                {
                    map[player_y, player_x].Texture = new Texture("resources/img_diamond.jpg");
                }
                else
                {
                    map[player_y, player_x].Texture = new Texture("resources/img_floor.jpg");
                }
                
                player_x = newPlayerX;
                player_y = newPlayerY;
                map[player_y, player_x].Texture = new Texture("resources/img_player.jpg");


            }
            catch (IndexOutOfRangeException)
            {
                // Handle index out of range exception
            }
        }



        // Getter methods for points and movements
        public int GetPoints()
        {
            return points;

        }

        public int GetMovements()
        {
            return movements;
        }


    }


}