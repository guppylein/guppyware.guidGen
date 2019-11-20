namespace Guppyware.GuidGen
{
    partial class GenerateGuid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblGuidGenerated = new System.Windows.Forms.Label();
            this.timWaitTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblGuidGenerated
            // 
            this.lblGuidGenerated.AutoSize = true;
            this.lblGuidGenerated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuidGenerated.Location = new System.Drawing.Point(11, 13);
            this.lblGuidGenerated.Name = "lblGuidGenerated";
            this.lblGuidGenerated.Size = new System.Drawing.Size(186, 13);
            this.lblGuidGenerated.TabIndex = 0;
            this.lblGuidGenerated.Text = "Guid in Zwischenablage kopiert";
            // 
            // timWaitTimer
            // 
            this.timWaitTimer.Interval = 1000;
            this.timWaitTimer.Tick += new System.EventHandler(this.timWaitTimer_Tick);
            // 
            // GenerateGuid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(380, 41);
            this.Controls.Add(this.lblGuidGenerated);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenerateGuid";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GenerateGuid";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GenerateGuid_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGuidGenerated;
        private System.Windows.Forms.Timer timWaitTimer;
    }
}

