
namespace thesis_UI1
{
    partial class Add_Person
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
            this.nameText = new System.Windows.Forms.TextBox();
            this.surnameText = new System.Windows.Forms.TextBox();
            this.okay = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.surname = new System.Windows.Forms.Label();
            this.BirthdateLabel = new System.Windows.Forms.Label();
            this.dateTimePickerPersonBirthDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(27, 36);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(100, 20);
            this.nameText.TabIndex = 0;
            // 
            // surnameText
            // 
            this.surnameText.Location = new System.Drawing.Point(165, 36);
            this.surnameText.Name = "surnameText";
            this.surnameText.Size = new System.Drawing.Size(100, 20);
            this.surnameText.TabIndex = 2;
            // 
            // okay
            // 
            this.okay.Location = new System.Drawing.Point(52, 159);
            this.okay.Name = "okay";
            this.okay.Size = new System.Drawing.Size(75, 23);
            this.okay.TabIndex = 3;
            this.okay.Text = "Okay";
            this.okay.UseVisualStyleBackColor = true;
            this.okay.Click += new System.EventHandler(this.okay_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(165, 159);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(24, 20);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(35, 13);
            this.name.TabIndex = 5;
            this.name.Text = "Name";
            // 
            // surname
            // 
            this.surname.AutoSize = true;
            this.surname.Location = new System.Drawing.Point(162, 20);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(49, 13);
            this.surname.TabIndex = 6;
            this.surname.Text = "Surname";
            // 
            // BirthdateLabel
            // 
            this.BirthdateLabel.AutoSize = true;
            this.BirthdateLabel.Location = new System.Drawing.Point(24, 85);
            this.BirthdateLabel.Name = "BirthdateLabel";
            this.BirthdateLabel.Size = new System.Drawing.Size(49, 13);
            this.BirthdateLabel.TabIndex = 7;
            this.BirthdateLabel.Text = "Birthdate";
            // 
            // dateTimePickerPersonBirthDate
            // 
            this.dateTimePickerPersonBirthDate.Location = new System.Drawing.Point(27, 101);
            this.dateTimePickerPersonBirthDate.Name = "dateTimePickerPersonBirthDate";
            this.dateTimePickerPersonBirthDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerPersonBirthDate.TabIndex = 8;
            // 
            // Add_Person
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 224);
            this.Controls.Add(this.dateTimePickerPersonBirthDate);
            this.Controls.Add(this.BirthdateLabel);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.name);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.okay);
            this.Controls.Add(this.surnameText);
            this.Controls.Add(this.nameText);
            this.Name = "Add_Person";
            this.Text = "Add_Person";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox nameText;
        public System.Windows.Forms.TextBox surnameText;
        public System.Windows.Forms.Button okay;
        public System.Windows.Forms.Button cancel;
        public System.Windows.Forms.Label name;
        public System.Windows.Forms.Label surname;
        public System.Windows.Forms.Label BirthdateLabel;
        private System.Windows.Forms.DateTimePicker dateTimePickerPersonBirthDate;
    }
}