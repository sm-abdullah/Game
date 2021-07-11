
using System.Windows.Forms;

namespace Game.GameManger
{
    /// <summary>
    /// Main Score panel that will be docked at bottom of form/view
    /// </summary>
    public class ScorePanel : Panel
    {
        private const string ScoreDescription = "Your total Score : {0}";
        private Label ScoreStatus;
        private int _totalScore;
        public int TotalScore
        {
            get { return _totalScore; }
            set
            {
                _totalScore = value;
                ScoreStatus.Text = string.Format(ScoreDescription, _totalScore);
            }
        }
        public ScorePanel()
        {
            this.SuspendLayout();
            ScoreStatus = new Label();
            TotalScore = 0;
            this.Controls.Add(this.ScoreStatus);
            this.Dock = DockStyle.Bottom;
            this.Location = new System.Drawing.Point(0, 658);
            // 
            // Score_lable
            // 
            this.ScoreStatus.AutoSize = true;
            this.ScoreStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreStatus.Location = new System.Drawing.Point(12, 26);
            this.ScoreStatus.Name = "Score_lable";
            this.ScoreStatus.Size = new System.Drawing.Size(60, 24);
            this.ScoreStatus.TabIndex = 0;

            this.BackColor = System.Drawing.Color.DarkGray;
            this.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Location = new System.Drawing.Point(0, 658);
            this.Size = new System.Drawing.Size(977, 68);
            this.TotalScore = 0;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ScorePanel
            // 
          
            this.ResumeLayout(false);

        }
    }
}
