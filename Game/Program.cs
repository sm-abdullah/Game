using Game.GameManger;
using System;
using System.Windows.Forms;
using Game.Business;
using External;
using Business;

namespace Game
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                IImageResources repo = new ImageResources();
                const int maxImages = 11;
                IGameFlowManager gameFlowManger = new GameFlowManager(repo, maxImages);
                // i belive win form is not best choice to build games.
                // i am still using  just to show what i can do better
                // i could have used Designer form
                // using dumb view just to show how flexible it is.
                var view = new Form();
                var imageAnimation = new ImageFadeout();
                var imotionDriver = new MotionDriver();
                var iScoreManager = new ScoreManager();
                var controller = new GameController(view, gameFlowManger, iScoreManager, imotionDriver, imageAnimation);
                controller.StartGame();
                Application.Run(view);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fata error occured EX: {ex.Message}");
            }
        }
    }
}
