namespace SimulateSensor
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            this.label_db = new System.Windows.Forms.Label();
            this.label_ac = new System.Windows.Forms.Label();
            this.label_window = new System.Windows.Forms.Label();
            this.label_active = new System.Windows.Forms.Label();
            this.label_position = new System.Windows.Forms.Label();
            this.label_object = new System.Windows.Forms.Label();
            this.button_sendData = new System.Windows.Forms.Button();
            this.checkBox_ac = new System.Windows.Forms.CheckBox();
            this.comboBox_position = new System.Windows.Forms.ComboBox();
            this.comboBox_object = new System.Windows.Forms.ComboBox();
            this.checkBox_window = new System.Windows.Forms.CheckBox();
            this.checkBox_active = new System.Windows.Forms.CheckBox();
            this.timer_sendData = new System.Windows.Forms.Timer(this.components);
            this.button_stopTimer = new System.Windows.Forms.Button();
            this.button_startTimer = new System.Windows.Forms.Button();
            this.label_state = new System.Windows.Forms.Label();
            this.checkBox_db = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_urlModify = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(36, 12);
            label1.TabIndex = 22;
            label1.Text = "State : ";
            // 
            // label_db
            // 
            this.label_db.AutoSize = true;
            this.label_db.Location = new System.Drawing.Point(12, 9);
            this.label_db.Name = "label_db";
            this.label_db.Size = new System.Drawing.Size(21, 12);
            this.label_db.TabIndex = 0;
            this.label_db.Text = "DB";
            // 
            // label_ac
            // 
            this.label_ac.AutoSize = true;
            this.label_ac.Location = new System.Drawing.Point(12, 36);
            this.label_ac.Name = "label_ac";
            this.label_ac.Size = new System.Drawing.Size(21, 12);
            this.label_ac.TabIndex = 1;
            this.label_ac.Text = "AC";
            // 
            // label_window
            // 
            this.label_window.AutoSize = true;
            this.label_window.Location = new System.Drawing.Point(12, 64);
            this.label_window.Name = "label_window";
            this.label_window.Size = new System.Drawing.Size(45, 12);
            this.label_window.TabIndex = 8;
            this.label_window.Text = "Window";
            // 
            // label_active
            // 
            this.label_active.AutoSize = true;
            this.label_active.Location = new System.Drawing.Point(12, 92);
            this.label_active.Name = "label_active";
            this.label_active.Size = new System.Drawing.Size(35, 12);
            this.label_active.TabIndex = 9;
            this.label_active.Text = "Active";
            // 
            // label_position
            // 
            this.label_position.AutoSize = true;
            this.label_position.Location = new System.Drawing.Point(12, 120);
            this.label_position.Name = "label_position";
            this.label_position.Size = new System.Drawing.Size(42, 12);
            this.label_position.TabIndex = 10;
            this.label_position.Text = "Position";
            // 
            // label_object
            // 
            this.label_object.AutoSize = true;
            this.label_object.Location = new System.Drawing.Point(12, 148);
            this.label_object.Name = "label_object";
            this.label_object.Size = new System.Drawing.Size(35, 12);
            this.label_object.TabIndex = 11;
            this.label_object.Text = "Object";
            // 
            // button_sendData
            // 
            this.button_sendData.Location = new System.Drawing.Point(8, 33);
            this.button_sendData.Name = "button_sendData";
            this.button_sendData.Size = new System.Drawing.Size(75, 23);
            this.button_sendData.TabIndex = 12;
            this.button_sendData.Text = "Send Data";
            this.button_sendData.UseVisualStyleBackColor = true;
            this.button_sendData.Click += new System.EventHandler(this.button_sendData_Click);
            // 
            // checkBox_ac
            // 
            this.checkBox_ac.AutoSize = true;
            this.checkBox_ac.Location = new System.Drawing.Point(93, 35);
            this.checkBox_ac.Name = "checkBox_ac";
            this.checkBox_ac.Size = new System.Drawing.Size(38, 16);
            this.checkBox_ac.TabIndex = 14;
            this.checkBox_ac.Text = "On";
            this.checkBox_ac.UseVisualStyleBackColor = true;
            // 
            // comboBox_position
            // 
            this.comboBox_position.FormattingEnabled = true;
            this.comboBox_position.Items.AddRange(new object[] {
            "Living Room - 0",
            "Bed Room - 1",
            "Kitchen - 2",
            "Dining Room - 3",
            "Toilet - 4"});
            this.comboBox_position.Location = new System.Drawing.Point(93, 117);
            this.comboBox_position.Name = "comboBox_position";
            this.comboBox_position.Size = new System.Drawing.Size(121, 20);
            this.comboBox_position.TabIndex = 15;
            // 
            // comboBox_object
            // 
            this.comboBox_object.FormattingEnabled = true;
            this.comboBox_object.Items.AddRange(new object[] {
            "None - 0",
            "Phone - 1",
            "Book - 2",
            "Knife - 3",
            "Fork - 4",
            "Spoon - 5",
            "Pot - 6",
            "Toothbrush - 7",
            "Towel - 8"});
            this.comboBox_object.Location = new System.Drawing.Point(93, 145);
            this.comboBox_object.Name = "comboBox_object";
            this.comboBox_object.Size = new System.Drawing.Size(121, 20);
            this.comboBox_object.TabIndex = 16;
            // 
            // checkBox_window
            // 
            this.checkBox_window.AutoSize = true;
            this.checkBox_window.Location = new System.Drawing.Point(93, 64);
            this.checkBox_window.Name = "checkBox_window";
            this.checkBox_window.Size = new System.Drawing.Size(38, 16);
            this.checkBox_window.TabIndex = 17;
            this.checkBox_window.Text = "On";
            this.checkBox_window.UseVisualStyleBackColor = true;
            // 
            // checkBox_active
            // 
            this.checkBox_active.AutoSize = true;
            this.checkBox_active.Location = new System.Drawing.Point(93, 91);
            this.checkBox_active.Name = "checkBox_active";
            this.checkBox_active.Size = new System.Drawing.Size(38, 16);
            this.checkBox_active.TabIndex = 18;
            this.checkBox_active.Text = "On";
            this.checkBox_active.UseVisualStyleBackColor = true;
            // 
            // timer_sendData
            // 
            this.timer_sendData.Interval = 10000;
            this.timer_sendData.Tick += new System.EventHandler(this.timer_sendData_Tick);
            // 
            // button_stopTimer
            // 
            this.button_stopTimer.Location = new System.Drawing.Point(8, 62);
            this.button_stopTimer.Name = "button_stopTimer";
            this.button_stopTimer.Size = new System.Drawing.Size(75, 23);
            this.button_stopTimer.TabIndex = 20;
            this.button_stopTimer.Text = "Stop Timer";
            this.button_stopTimer.UseVisualStyleBackColor = true;
            this.button_stopTimer.Click += new System.EventHandler(this.button_stopTimer_Click);
            // 
            // button_startTimer
            // 
            this.button_startTimer.Location = new System.Drawing.Point(8, 91);
            this.button_startTimer.Name = "button_startTimer";
            this.button_startTimer.Size = new System.Drawing.Size(75, 23);
            this.button_startTimer.TabIndex = 21;
            this.button_startTimer.Text = "Start Timer";
            this.button_startTimer.UseVisualStyleBackColor = true;
            this.button_startTimer.Click += new System.EventHandler(this.button_startTimer_Click);
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(48, 18);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(33, 12);
            this.label_state.TabIndex = 23;
            this.label_state.Text = "label1";
            // 
            // checkBox_db
            // 
            this.checkBox_db.AutoSize = true;
            this.checkBox_db.Location = new System.Drawing.Point(93, 8);
            this.checkBox_db.Name = "checkBox_db";
            this.checkBox_db.Size = new System.Drawing.Size(38, 16);
            this.checkBox_db.TabIndex = 24;
            this.checkBox_db.Text = "On";
            this.checkBox_db.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_urlModify);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.label_state);
            this.groupBox1.Controls.Add(this.button_startTimer);
            this.groupBox1.Controls.Add(this.button_sendData);
            this.groupBox1.Controls.Add(this.button_stopTimer);
            this.groupBox1.Location = new System.Drawing.Point(251, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(92, 157);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "config";
            // 
            // button_urlModify
            // 
            this.button_urlModify.Location = new System.Drawing.Point(8, 120);
            this.button_urlModify.Name = "button_urlModify";
            this.button_urlModify.Size = new System.Drawing.Size(75, 23);
            this.button_urlModify.TabIndex = 24;
            this.button_urlModify.Text = "Modify URL";
            this.button_urlModify.UseVisualStyleBackColor = true;
            this.button_urlModify.Click += new System.EventHandler(this.button_urlModify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 189);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox_db);
            this.Controls.Add(this.checkBox_active);
            this.Controls.Add(this.checkBox_window);
            this.Controls.Add(this.comboBox_object);
            this.Controls.Add(this.comboBox_position);
            this.Controls.Add(this.checkBox_ac);
            this.Controls.Add(this.label_object);
            this.Controls.Add(this.label_position);
            this.Controls.Add(this.label_active);
            this.Controls.Add(this.label_window);
            this.Controls.Add(this.label_ac);
            this.Controls.Add(this.label_db);
            this.Name = "Form1";
            this.Text = "I am a sensor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_db;
        private System.Windows.Forms.Label label_ac;
        private System.Windows.Forms.Label label_window;
        private System.Windows.Forms.Label label_active;
        private System.Windows.Forms.Label label_position;
        private System.Windows.Forms.Label label_object;
        private System.Windows.Forms.Button button_sendData;
        private System.Windows.Forms.CheckBox checkBox_ac;
        private System.Windows.Forms.ComboBox comboBox_position;
        private System.Windows.Forms.ComboBox comboBox_object;
        private System.Windows.Forms.CheckBox checkBox_window;
        private System.Windows.Forms.CheckBox checkBox_active;
        private System.Windows.Forms.Timer timer_sendData;
        private System.Windows.Forms.Button button_stopTimer;
        private System.Windows.Forms.Button button_startTimer;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.CheckBox checkBox_db;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_urlModify;
    }
}

