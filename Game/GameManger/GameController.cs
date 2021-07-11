using Game.ImageBox;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Game.GameManger
{
    /// <summary>
    /// this is main game controller
    /// </summary>
    public partial class GameController
    {
        public void StartGame()
        {
            this.imageBoxControl.StartDropping();
        }
        public void Retry()
        {
            this.imageBoxControl.Reset();
            this.imageBoxControl.StartDropping();
        }
        private void imageBoxControl_ImageReached(IImageBoxControl sender, ImageDirection direction)
        {
            var item = Images.ElementAt(Counter);
            if ((direction == ImageDirection.LeftBottom && item.Value == Nationality.Korean) ||
                 (direction == ImageDirection.LeftTop && item.Value == Nationality.Japnaies) ||
                 (direction == ImageDirection.RightTop && item.Value == Nationality.Chines) ||
                  (direction == ImageDirection.RightBottom && item.Value == Nationality.Thai)
                )
            {
                this._scorePanel.TotalScore += 20;
            }
            else if (direction != ImageDirection.TopBottom)
            {
                this._scorePanel.TotalScore -= 5;
            }
            Counter++;
            if (Counter > 9)
            {
                var result = MessageBox.Show(string.Format("Your Total Score : {0}", this._scorePanel.TotalScore), "Want to play again?", buttons: MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Counter = 0;
                    Retry();
                }
                else { Environment.Exit(1); }
            }

            this.imageBoxControl.Image = Images.ElementAt(Counter).Key;
            this.imageBoxControl.Reset();
        }
    }
}
