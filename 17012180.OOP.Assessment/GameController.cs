using SFML.Graphics;
using SFML.Window;


namespace _17012180.OOP.Assessment
{
    internal class GameController
    {
        private RenderWindow gameWindow;
        private GameMap gameMap;
        private SideView sideView;


        public GameController()

        {
            gameWindow = new RenderWindow(new VideoMode(800, 600), "Assessment Game", Styles.Close);
            gameWindow.Closed += OnClosed;
            gameWindow.KeyReleased += OnKeyReleased;    
            
            gameMap = new GameMap();

            sideView  = new SideView(gameMap);
        }

        private void OnClosed(object? sender, EventArgs e)
        {
            
            gameWindow.Close();
        }

        private void OnKeyReleased(object? sender, KeyEventArgs e)
        {
            switch(e.Code)
            {
                case Keyboard.Key.Up:
                    Console.WriteLine("Up was pressed");
                    gameMap.MovePlayer(GameMap.MoveDirections.Up);
                    break;
                case Keyboard.Key.Down:
                    Console.WriteLine("Down was pressed");
                    gameMap.MovePlayer(GameMap.MoveDirections.Down);
                    break;
                case Keyboard.Key.Left:
                    Console.WriteLine("Left was pressed");
                    gameMap.MovePlayer(GameMap.MoveDirections.Left);
                    break;
                case Keyboard.Key.Right:
                    Console.WriteLine("Right was pressed");
                    gameMap.MovePlayer(GameMap.MoveDirections.Right);
                    break;
                case Keyboard.Key.W:
                    Console.WriteLine("Player want to move up");
                    gameMap.MovePlayer(GameMap.MoveDirections.Up);
                    break;
                case Keyboard.Key.A:
                    Console.WriteLine("Player want to move left");
                    gameMap.MovePlayer(GameMap.MoveDirections.Left);
                    break;
                case Keyboard.Key.S:
                    Console.WriteLine("Player want to move down");
                    gameMap.MovePlayer(GameMap.MoveDirections.Down);
                    break;
                case Keyboard.Key.D:
                    Console.WriteLine("Player want to move right");
                    gameMap.MovePlayer(GameMap.MoveDirections.Right);
                    break;
            }
        }



        public void Run()
        {
            while (gameWindow.IsOpen)
            {
                // Gather user ipnut
                gameWindow.DispatchEvents();

                // update game 
                UpdateGame();

                // render game
                RenderGame();
            }

            gameWindow.Close();
        }

        private void UpdateGame()
        {
            // We can update our game here
            sideView.UpdateDisplayedString();
            sideView.GetMovementsDisplay();
        }

        private void RenderGame()
        {
            // Draw everything here
            // Clear 
            gameWindow.Clear(Color.Magenta);

            // Draw all our game elemen
            gameMap.DrawMap(gameWindow);
            sideView.DrawSideView(gameWindow);
            
            // Display
            gameWindow.Display();
        }
    }
}
