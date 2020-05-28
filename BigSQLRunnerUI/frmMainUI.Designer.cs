namespace BigSQLRunnerUI
{
    partial class frmMainUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScriptFile = new System.Windows.Forms.TextBox();
            this.btnBrowseScriptFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLinesPerBatch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartingLine = new System.Windows.Forms.TextBox();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.pbScriptProgress = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnTestConnectionString = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection String";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(109, 6);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConnectionString.Size = new System.Drawing.Size(418, 47);
            this.txtConnectionString.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Script file";
            // 
            // txtScriptFile
            // 
            this.txtScriptFile.Location = new System.Drawing.Point(109, 81);
            this.txtScriptFile.Name = "txtScriptFile";
            this.txtScriptFile.Size = new System.Drawing.Size(418, 20);
            this.txtScriptFile.TabIndex = 3;
            // 
            // btnBrowseScriptFile
            // 
            this.btnBrowseScriptFile.Location = new System.Drawing.Point(533, 79);
            this.btnBrowseScriptFile.Name = "btnBrowseScriptFile";
            this.btnBrowseScriptFile.Size = new System.Drawing.Size(85, 23);
            this.btnBrowseScriptFile.TabIndex = 4;
            this.btnBrowseScriptFile.Text = "Browse...";
            this.btnBrowseScriptFile.UseVisualStyleBackColor = true;
            this.btnBrowseScriptFile.Click += new System.EventHandler(this.btnBrowseScriptFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lines per batch";
            // 
            // txtLinesPerBatch
            // 
            this.txtLinesPerBatch.Location = new System.Drawing.Point(109, 126);
            this.txtLinesPerBatch.Name = "txtLinesPerBatch";
            this.txtLinesPerBatch.Size = new System.Drawing.Size(100, 20);
            this.txtLinesPerBatch.TabIndex = 6;
            this.txtLinesPerBatch.Text = "300";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Starting Line";
            // 
            // txtStartingLine
            // 
            this.txtStartingLine.Location = new System.Drawing.Point(325, 126);
            this.txtStartingLine.Name = "txtStartingLine";
            this.txtStartingLine.Size = new System.Drawing.Size(100, 20);
            this.txtStartingLine.TabIndex = 8;
            this.txtStartingLine.Text = "0";
            // 
            // btnRunScript
            // 
            this.btnRunScript.Location = new System.Drawing.Point(473, 124);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(145, 43);
            this.btnRunScript.TabIndex = 9;
            this.btnRunScript.Text = "Run Script Now!";
            this.btnRunScript.UseVisualStyleBackColor = true;
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // pbScriptProgress
            // 
            this.pbScriptProgress.Location = new System.Drawing.Point(15, 192);
            this.pbScriptProgress.Name = "pbScriptProgress";
            this.pbScriptProgress.Size = new System.Drawing.Size(603, 23);
            this.pbScriptProgress.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 228);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(606, 33);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Idle";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTestConnectionString
            // 
            this.btnTestConnectionString.Location = new System.Drawing.Point(533, 6);
            this.btnTestConnectionString.Name = "btnTestConnectionString";
            this.btnTestConnectionString.Size = new System.Drawing.Size(85, 47);
            this.btnTestConnectionString.TabIndex = 12;
            this.btnTestConnectionString.Text = "Test Connection String";
            this.btnTestConnectionString.UseVisualStyleBackColor = true;
            this.btnTestConnectionString.Click += new System.EventHandler(this.btnTestConnectionString_Click);
            // 
            // frmMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 275);
            this.Controls.Add(this.btnTestConnectionString);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbScriptProgress);
            this.Controls.Add(this.btnRunScript);
            this.Controls.Add(this.txtStartingLine);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLinesPerBatch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowseScriptFile);
            this.Controls.Add(this.txtScriptFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Big SQL Runner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainUI_FormClosing);
            this.Load += new System.EventHandler(this.frmMainUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtScriptFile;
        private System.Windows.Forms.Button btnBrowseScriptFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLinesPerBatch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStartingLine;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.ProgressBar pbScriptProgress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnTestConnectionString;
    }
}

