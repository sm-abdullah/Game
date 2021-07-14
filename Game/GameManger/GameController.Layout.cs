
using System.Drawing;
using System.Windows.Forms;
using Game.Views;
using Game.Business;
using Business;

namespace Game.GameManger
{
    public partial class GameController
    {
        private const int ViewHeight = 763;
        private const int ViewWidth = 995;
        private ScorePanel _scorePanel;
        private Form _view;
        private NationalityPanel _japanesePanel;
        private NationalityPanel _chinesePanel;
        private NationalityPanel _koreanPanel;
        private NationalityPanel _thaiPanel;
        private ImageBoxControl _imageBoxControl;
        private IScoreManager _scoreManager;
        IGameFlowManager _gameFlowManager;
        public GameController(Form view, IGameFlowManager gameFlowManager, IScoreManager scoreManager, IMotionDriver iMotionDriver,IImageAnimation imageAnimation) 
        {
            _scoreManager = scoreManager;
            _gameFlowManager = gameFlowManager;
            //adjust view
            view.BackColor = System.Drawing.Color.White;
            view.FormBorderStyle = FormBorderStyle.FixedSingle;
            view.MinimizeBox = false;
            view.MaximizeBox = false;
            view.Height = ViewHeight;
            view.Width = ViewWidth;

            //adjust controls
            _scorePanel = new ScorePanel();
            _japanesePanel = new NationalityPanel();
            _japanesePanel.Location = new Point(0, 0);
            _japanesePanel.NationalityText = "Japanese";
            _chinesePanel = new NationalityPanel();
            _chinesePanel.NationalityText = "Chinese";
            _chinesePanel.Location = new Point(ViewWidth - _chinesePanel.Width, 0);
            _koreanPanel = new NationalityPanel();
            _koreanPanel.NationalityText = "Korean";
            _koreanPanel.Location = new Point(0, ViewHeight - (88 + _koreanPanel.Height));
            _thaiPanel = new NationalityPanel();
            _thaiPanel.NationalityText = "Thai";
            _thaiPanel.Location = new Point(ViewWidth - _chinesePanel.Width, ViewHeight - (88 + _koreanPanel.Height));

            _imageBoxControl = new ImageBoxControl(iMotionDriver,imageAnimation);
            ((System.ComponentModel.ISupportInitialize)(this._imageBoxControl)).BeginInit();
            this._imageBoxControl.BackColor = System.Drawing.Color.Transparent;
            this._imageBoxControl.Image = gameFlowManager.GetNext().Value.Key;
            this._imageBoxControl.Location = new System.Drawing.Point(349, 126);
            this._imageBoxControl.Name = "imageBoxControl1";
            this._imageBoxControl.Size = new System.Drawing.Size(274, 198);
            this._imageBoxControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._imageBoxControl.TabIndex = 0;
            this._imageBoxControl.TabStop = false;
            this._imageBoxControl.ImageReached += new ImageReached(this.imageBoxControl_ImageReached);
            _view = view;
            Initialze();

        }
        public void Initialze() 
        {
            _view.Controls.Add(_imageBoxControl);
            _view.Controls.Add(_scorePanel);
            _view.Controls.Add(_japanesePanel);
            _view.Controls.Add(_chinesePanel);
            _view.Controls.Add(_koreanPanel);
            _view.Controls.Add(_thaiPanel);
           
        }
    }
}
