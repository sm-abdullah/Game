﻿using Game.ImageBox;
using Game.ImageRepo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game.GameManger
{
    public partial class GameController
    {
        Dictionary<Image, Nationality> Images;
        private int Counter = 0;
        private ScorePanel _scorePanel;
        private Form _view;
        private NationalityPanel _JapanesPanel;
        private NationalityPanel _ChinesPanel;
        private NationalityPanel _KoreanPanel;
        private NationalityPanel _ThaiPanel;
        private int ViewHeight = 763;
        private int ViewWidth = 995;
        private ImageBoxControl imageBoxControl;
        public GameController(Form view, IImageResources imageResources, IMotionDriver iMotionDriver,IImageAnimation imageAnimation) 
        {
            Images = imageResources.GetImagesFromResources();
            //adjust view
            view.BackColor = System.Drawing.Color.White;
            view.FormBorderStyle = FormBorderStyle.FixedSingle; 
            view.MaximizeBox = false;
            view.Height = ViewHeight;
            view.Width = ViewWidth;

            //adjust controls
            _scorePanel = new ScorePanel();
            _JapanesPanel = new NationalityPanel();
            _JapanesPanel.Location = new Point(0, 0);
            _JapanesPanel.NationalityText = "Japanes";
            _ChinesPanel = new NationalityPanel();
            _ChinesPanel.NationalityText = "Chines";
            _ChinesPanel.Location = new Point(ViewWidth - _ChinesPanel.Width, 0);
            _KoreanPanel = new NationalityPanel();
            _KoreanPanel.NationalityText = "Korean";
            _KoreanPanel.Location = new Point(0, ViewHeight - (88 + _KoreanPanel.Height));
            _ThaiPanel = new NationalityPanel();
            _ThaiPanel.NationalityText = "Thai";
            _ThaiPanel.Location = new Point(ViewWidth - _ChinesPanel.Width, ViewHeight - (88 + _KoreanPanel.Height));

            imageBoxControl = new ImageBoxControl(iMotionDriver,imageAnimation);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxControl)).BeginInit();
            this.imageBoxControl.BackColor = System.Drawing.Color.Transparent;
            this.imageBoxControl.Image = global::Game.Properties.Resources.thai03;
            this.imageBoxControl.Location = new System.Drawing.Point(349, 126);
            this.imageBoxControl.Name = "imageBoxControl1";
            this.imageBoxControl.Size = new System.Drawing.Size(274, 198);
            this.imageBoxControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxControl.TabIndex = 0;
            this.imageBoxControl.TabStop = false;
            this.imageBoxControl.ImageReached += new Game.ImageBox.ImageReached(this.imageBoxControl_ImageReached);
            _view = view;
            Initialze();

        }
        public void Initialze() 
        {
            _view.Controls.Add(imageBoxControl);
            _view.Controls.Add(_scorePanel);
            _view.Controls.Add(_JapanesPanel);
            _view.Controls.Add(_ChinesPanel);
            _view.Controls.Add(_KoreanPanel);
            _view.Controls.Add(_ThaiPanel);
           
        }
    }
}