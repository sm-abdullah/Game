using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Entites;
using Game.Views;
using Game.Business;
using Business;
using System.Linq;

namespace Game.GameManger
{
    public partial class GameController
    {
        private ScorePanel _scorePanel;
        private Form _view;
        private NationalityPanel _JapanesePanel;
        private NationalityPanel _ChinesePanel;
        private NationalityPanel _KoreanPanel;
        private NationalityPanel _ThaiPanel;
        private int ViewHeight = 763;
        private int ViewWidth = 995;
        private ImageBoxControl imageBoxControl;
        IGameFlowManager _gameFlowManager;
        public GameController(Form view, IGameFlowManager gameFlowManager, IMotionDriver iMotionDriver,IImageAnimation imageAnimation) 
        {
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
            _JapanesePanel = new NationalityPanel();
            _JapanesePanel.Location = new Point(0, 0);
            _JapanesePanel.NationalityText = "Japanese";
            _ChinesePanel = new NationalityPanel();
            _ChinesePanel.NationalityText = "Chinese";
            _ChinesePanel.Location = new Point(ViewWidth - _ChinesePanel.Width, 0);
            _KoreanPanel = new NationalityPanel();
            _KoreanPanel.NationalityText = "Korean";
            _KoreanPanel.Location = new Point(0, ViewHeight - (88 + _KoreanPanel.Height));
            _ThaiPanel = new NationalityPanel();
            _ThaiPanel.NationalityText = "Thai";
            _ThaiPanel.Location = new Point(ViewWidth - _ChinesePanel.Width, ViewHeight - (88 + _KoreanPanel.Height));

            imageBoxControl = new ImageBoxControl(iMotionDriver,imageAnimation);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxControl)).BeginInit();
            this.imageBoxControl.BackColor = System.Drawing.Color.Transparent;
            this.imageBoxControl.Image = gameFlowManager.GetNext().Value.Key;
            this.imageBoxControl.Location = new System.Drawing.Point(349, 126);
            this.imageBoxControl.Name = "imageBoxControl1";
            this.imageBoxControl.Size = new System.Drawing.Size(274, 198);
            this.imageBoxControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxControl.TabIndex = 0;
            this.imageBoxControl.TabStop = false;
            this.imageBoxControl.ImageReached += new ImageReached(this.imageBoxControl_ImageReached);
            _view = view;
            Initialze();

        }
        public void Initialze() 
        {
            _view.Controls.Add(imageBoxControl);
            _view.Controls.Add(_scorePanel);
            _view.Controls.Add(_JapanesePanel);
            _view.Controls.Add(_ChinesePanel);
            _view.Controls.Add(_KoreanPanel);
            _view.Controls.Add(_ThaiPanel);
           
        }
    }
}
