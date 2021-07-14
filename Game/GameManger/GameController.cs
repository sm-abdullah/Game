using Entites;
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
            this._scorePanel.TotalScore = 0;
            _gameFlowManager.Reset();
        }
        private void imageBoxControl_ImageReached(IImageBoxControl sender, ImageDirection direction)
        {
            var item = _gameFlowManager.GetMostRecent();
            if ((direction == ImageDirection.LeftBottom && item.Value.Value == Nationality.Korean) ||
                 (direction == ImageDirection.LeftTop && item.Value.Value == Nationality.Japnaies) ||
                 (direction == ImageDirection.RightTop && item.Value.Value == Nationality.Chines) ||
                  (direction == ImageDirection.RightBottom && item.Value.Value == Nationality.Thai)
                )
            {
                this._scorePanel.TotalScore += 20;
            }
            else if (direction != ImageDirection.TopBottom)
            {
                this._scorePanel.TotalScore -= 5;
            }

            var nextPic = _gameFlowManager.GetNext();
            if (nextPic == null)
            {
                var result = MessageBox.Show(string.Format("Your Total Score : {0}", this._scorePanel.TotalScore), "Want to play again?", buttons: MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    Retry();
                    nextPic = _gameFlowManager.GetNext();
                }
                else { Environment.Exit(1); }
            }
            this.imageBoxControl.Image = nextPic.Value.Key;
            this.imageBoxControl.Reset();
        }
    }
}
