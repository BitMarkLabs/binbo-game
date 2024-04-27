using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace _17012180.OOP.Assessment
{
    internal class SideView : RectangleShape
    {
        private Font basic_font;
        private Text title_text;
        private Text title_text2;
        private GameMap gameMap; // Add a reference to the GameMap class

        public SideView(GameMap gameMap)
        {
            this.Size = new Vector2f(198, 598);
            this.Position = new Vector2f(601, 1);
            this.FillColor = Color.White;
            this.OutlineThickness = 2;
            this.OutlineColor = Color.Black;

            this.gameMap = gameMap; // Store reference to GameMap instance

            basic_font = new Font("resources/basic_font.ttf");
            title_text = new Text("OOPS Game", basic_font);
            title_text.Position = this.Position + new Vector2f(20f, 20f);
            title_text.FillColor = Color.Black;
            title_text2 = new Text("OOPS Game", basic_font);
            title_text2.Position = this.Position + new Vector2f(20f, 120f);
            title_text2.FillColor = Color.Black;
           

            // Update displayed string with game points
            UpdateDisplayedString();
            // Get movements display
            GetMovementsDisplay();
          
        }

        public void DrawSideView(RenderWindow window)
        {
            window.Draw(this);
            window.Draw(title_text);
            window.Draw(title_text2);
            

        }

        public void UpdateDisplayedString()
        {
            // Get points from the GameMap instance
            int points = gameMap.GetPoints();
            // Set the text to display the points
            title_text.DisplayedString = "Game Points: \n" + points.ToString();
        }

        public void GetMovementsDisplay()
        {
            // Get movements from the GameMap instance
            int movements = gameMap.GetMovements();
            // Set the text to display the movements
            title_text2.DisplayedString = "Game \n Movements: \n" + movements.ToString();
        }

     
    }
}
