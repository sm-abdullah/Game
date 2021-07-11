using Game.GameManger;
using Game.ImageBox;
using Game.ImageBox.Animation;
using Game.ImageRepo;
using System;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IImageResources repo = new ImageResources();
            var view = new Form();
            var imageAnimation = new ImageFadeout();
            var imotionDriver = new MotionDriver();
            var controller = new GameController(view, repo, imotionDriver, imageAnimation);
            controller.StartGame();
            Application.Run(view);
        }
    }
}
