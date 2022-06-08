namespace MessageBomber
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.windowTitle = new System.Windows.Forms.TextBox();
            this.sendText = new System.Windows.Forms.Timer(this.components);
            this.inputText = new System.Windows.Forms.TextBox();
            this.timeInterval = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.stopTimer = new System.Windows.Forms.Button();
            this.startTimer = new System.Windows.Forms.Button();
            this.pressEnter = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.executionNumber = new System.Windows.Forms.TextBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowTitle
            // 
            this.windowTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.windowTitle.Location = new System.Drawing.Point(40, 24);
            this.windowTitle.Name = "windowTitle";
            this.windowTitle.Size = new System.Drawing.Size(200, 31);
            this.windowTitle.TabIndex = 0;
            // 
            // sendText
            // 
            this.sendText.Interval = 1000;
            this.sendText.Tick += new System.EventHandler(this.sendText_Tick);
            // 
            // inputText
            // 
            this.inputText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputText.Location = new System.Drawing.Point(41, 61);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(405, 167);
            this.inputText.TabIndex = 2;
            this.inputText.Text = "轰炸测试文字";
            // 
            // timeInterval
            // 
            this.timeInterval.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeInterval.Location = new System.Drawing.Point(246, 24);
            this.timeInterval.Name = "timeInterval";
            this.timeInterval.Size = new System.Drawing.Size(200, 31);
            this.timeInterval.TabIndex = 3;
            this.timeInterval.Text = "1000";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.stopTimer);
            this.groupBox.Controls.Add(this.startTimer);
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox.Location = new System.Drawing.Point(41, 234);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(234, 84);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "控制（状态：OFF）";
            // 
            // stopTimer
            // 
            this.stopTimer.Location = new System.Drawing.Point(86, 30);
            this.stopTimer.Name = "stopTimer";
            this.stopTimer.Size = new System.Drawing.Size(64, 39);
            this.stopTimer.TabIndex = 1;
            this.stopTimer.Text = "停止";
            this.stopTimer.UseVisualStyleBackColor = true;
            this.stopTimer.Click += new System.EventHandler(this.stopTimer_Click);
            // 
            // startTimer
            // 
            this.startTimer.Location = new System.Drawing.Point(16, 30);
            this.startTimer.Name = "startTimer";
            this.startTimer.Size = new System.Drawing.Size(64, 39);
            this.startTimer.TabIndex = 0;
            this.startTimer.Text = "开始";
            this.startTimer.UseVisualStyleBackColor = true;
            this.startTimer.Click += new System.EventHandler(this.startTimer_Click);
            // 
            // pressEnter
            // 
            this.pressEnter.AutoSize = true;
            this.pressEnter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pressEnter.Location = new System.Drawing.Point(302, 244);
            this.pressEnter.Name = "pressEnter";
            this.pressEnter.Size = new System.Drawing.Size(144, 28);
            this.pressEnter.TabIndex = 5;
            this.pressEnter.Text = "自动按下回车";
            this.pressEnter.UseVisualStyleBackColor = true;
            // 
            // executionNumber
            // 
            this.executionNumber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.executionNumber.Location = new System.Drawing.Point(302, 278);
            this.executionNumber.Name = "executionNumber";
            this.executionNumber.Size = new System.Drawing.Size(144, 31);
            this.executionNumber.TabIndex = 6;
            this.executionNumber.Text = "5";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 344);
            this.Controls.Add(this.executionNumber);
            this.Controls.Add(this.pressEnter);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.timeInterval);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.windowTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "信息轰炸器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox windowTitle;
        private System.Windows.Forms.Timer sendText;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.TextBox timeInterval;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button stopTimer;
        private System.Windows.Forms.Button startTimer;
        private System.Windows.Forms.CheckBox pressEnter;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox executionNumber;
    }
}

