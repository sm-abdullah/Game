using Entites;
using System;
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
            this._imageBoxControl.StartDropping();
        }
        public void Retry()
        {
            this._imageBoxControl.Reset();
            this._imageBoxControl.StartDropping();
            this._scorePanel.TotalScore = 0;
            this._scoreManager.Reset();
            this._gameFlowManager.Reset();
        }
        private void imageBoxControl_ImageReached(IImageBoxControl sender, ImageDirection direction)
        {
            try
            {


                var item = _gameFlowManager.GetMostRecent();
                this._scorePanel.TotalScore = _scoreManager.ManageScore(direction, item.Value.Value);

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
                this._imageBoxControl.Image = nextPic.Value.Key;
                this._imageBoxControl.Reset();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"an error has occured EX:{ex.Message}");
            }
        }
    }
}
