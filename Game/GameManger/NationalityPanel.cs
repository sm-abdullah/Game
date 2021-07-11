using System.Windows.Forms;

namespace Game.GameManger
{
    /// <summary>
    /// this is Panel Call that will be positioned in all four conrners
    /// </summary>
    public class NationalityPanel : Panel
    {
        private Label Nationality_Lable;

        public string NationalityText
        {
            get { return Nationality_Lable.Text; }
            set { Nationality_Lable.Text = value; }
        }
        public NationalityPanel() 
        {
            Nationality_Lable = new Label();
            Init();
        }
        private void Init()
        {

            // 
            // Japanese_Panel
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.Nationality_Lable);
            this.Location = new System.Drawing.Point(12, 12);
            this.Size = new System.Drawing.Size(336, 244);
            // 
            // Japanese_Label
            // 
            this.Nationality_Lable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Nationality_Lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nationality_Lable.Location = new System.Drawing.Point(0, 0);
            this.Nationality_Lable.Size = new System.Drawing.Size(336, 244);
            this.Nationality_Lable.TabIndex = 0;
            this.Nationality_Lable.Text = NationalityText;
            this.Nationality_Lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
