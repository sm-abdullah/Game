using Game.GameManger;
using Game.ImageRepo;
using System;
using System.Windows.Forms;
using Game.Business;
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
            // ibelive win form is not best choice to build games.
            // i am still using to just to show what i can do better
            // i could have used Designer form
            // using dumb view is show just to show how flexible it is.
            var view = new Form();
            var imageAnimation = new ImageFadeout();
            var imotionDriver = new MotionDriver();
            var controller = new GameController(view, repo, imotionDriver, imageAnimation);
            controller.StartGame();
            Application.Run(view);
        }
    }
}
