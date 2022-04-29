using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis_UI1
{
    class CalendarForm : Form
    {
        private Button calendarOkButton;
        private Button calendarCancelButton;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
        private Label dateStartLabel;
        private Label dateEndLabel;
        Main_Form mainForm;
        SelectionRange selectionRange;

        public CalendarForm(Main_Form mainForm, SelectionRange selectionRange)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.selectionRange = selectionRange;
        }
       

        private void calendarCancelButton_Click(object sender, EventArgs e)
        {
            if (mainForm.addSomethingToPersonBox.SelectedIndex == 0)
            {
                mainForm.dateIntervalForDataTextLabel.Enabled = false;
                mainForm.dateIntervalForDataTimeLabel.Enabled = false;
                mainForm.dataCountForDataTextBox.Enabled = false;
                mainForm.enterDataCountLabel.Enabled = false;
                mainForm.minHourDataComboBox.Enabled = false;
                mainForm.minHourDataTextBox.Enabled = false;
                mainForm.timeLabal.Enabled = false;
                mainForm.label1.Enabled = false;
                mainForm.dateIntervalForDataTimeLabel.Text = "None";
                mainForm.selectInputDataComboBox.SelectedIndex = -1;

                mainForm.newParameterTypeBox.SelectedIndex = -1;
                mainForm.selectParameterBox.SelectedIndex = -1;
            }
            else if (mainForm.addSomethingToPersonBox.SelectedIndex == 1)
            {
                mainForm.dateIntervalForQuTextLabel.Enabled = false;
                mainForm.dateIntervalForQuTimeLabel.Enabled = false;
                mainForm.dataCountForQuTextBox.Enabled = false;
                mainForm.dataCountForQuLabel.Enabled = false;
                mainForm.minHourQuComboBox.Enabled = false;
                mainForm.minHourInputQuTextBox.Enabled = false;
                mainForm.askingRateLabel.Enabled = false;
                mainForm.dateIntervalForQuTimeLabel.Text = "None";
                mainForm.selectInputQuComboBox.SelectedIndex = -1;
            }
                this.Close();
        }

        private void calendarOkButton_Click(object sender, EventArgs e)
        {
            //mainForm.dateIntervalDataCheckBox.Checked = false;

            //selectionRange = new SelectionRange(dateTimePickerStart.Value, dateTimePickerEnd.Value);
            selectionRange.Start = dateTimePickerStart.Value;
            selectionRange.End = dateTimePickerEnd.Value;

            if (mainForm.addSomethingToPersonBox.SelectedIndex == 0)
            {
                //mainForm.selectionRangeForData = selectionRange;
                if(mainForm.newParameterTypeBox.SelectedIndex == -1)
                {
                    updateMainFormUIforData();
                }
                else if(mainForm.addSomethingToPersonBox.SelectedIndex == -1)
                {
                    updateMainFormUIforParameter();
                }

            }
            else if(mainForm.addSomethingToPersonBox.SelectedIndex == 1)
            {
                //mainForm.selectionRangeForQuestion = selectionRange;
                updateMainFormUIforQu();
            }
            
            this.Close();
        }

        void updateMainFormUIforQu()
        {
            mainForm.dateIntervalForQuTimeLabel.Text = selectionRange.Start.ToShortDateString() + "\n" + selectionRange.End.ToShortDateString();
            mainForm.dateIntervalForQuTimeLabel.ForeColor = System.Drawing.Color.Black;
            mainForm.dateIntervalForQuTextLabel.ForeColor = System.Drawing.Color.Black;
        }

        void updateMainFormUIforData()
        {
            mainForm.dateIntervalForDataTextLabel.Text = selectionRange.Start.ToShortDateString() + "\n" + selectionRange.End.ToShortDateString();
            mainForm.dateIntervalForDataTextLabel.ForeColor = System.Drawing.Color.Black;
            mainForm.dateIntervalForDataTextLabel.ForeColor = System.Drawing.Color.Black;
        }

        void updateMainFormUIforParameter()
        {
           /* mainForm.dateIntervalForDataTextLabel.Text = selectionRange.Start.ToShortDateString() + "\n" + selectionRange.End.ToShortDateString();
            mainForm.dateIntervalForDataTextLabel.ForeColor = System.Drawing.Color.Black;
            mainForm.dateIntervalForDataTextLabel.ForeColor = System.Drawing.Color.Black;*/
        }

        private void InitializeComponent()
        {
            this.calendarOkButton = new System.Windows.Forms.Button();
            this.calendarCancelButton = new System.Windows.Forms.Button();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateStartLabel = new System.Windows.Forms.Label();
            this.dateEndLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // calendarOkButton
            // 
            this.calendarOkButton.BackColor = System.Drawing.Color.PaleGreen;
            this.calendarOkButton.Location = new System.Drawing.Point(18, 180);
            this.calendarOkButton.Name = "calendarOkButton";
            this.calendarOkButton.Size = new System.Drawing.Size(75, 23);
            this.calendarOkButton.TabIndex = 1;
            this.calendarOkButton.Text = "Ok";
            this.calendarOkButton.UseVisualStyleBackColor = false;
            this.calendarOkButton.Click += new System.EventHandler(this.calendarOkButton_Click);
            // 
            // calendarCancelButton
            // 
            this.calendarCancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.calendarCancelButton.Location = new System.Drawing.Point(124, 180);
            this.calendarCancelButton.Name = "calendarCancelButton";
            this.calendarCancelButton.Size = new System.Drawing.Size(75, 23);
            this.calendarCancelButton.TabIndex = 2;
            this.calendarCancelButton.Text = "Cancel";
            this.calendarCancelButton.UseVisualStyleBackColor = false;
            this.calendarCancelButton.Click += new System.EventHandler(this.calendarCancelButton_Click);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(18, 123);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(181, 20);
            this.dateTimePickerEnd.TabIndex = 3;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(18, 42);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(181, 20);
            this.dateTimePickerStart.TabIndex = 4;
            // 
            // dateStartLabel
            // 
            this.dateStartLabel.AutoSize = true;
            this.dateStartLabel.Location = new System.Drawing.Point(15, 20);
            this.dateStartLabel.Name = "dateStartLabel";
            this.dateStartLabel.Size = new System.Drawing.Size(55, 13);
            this.dateStartLabel.TabIndex = 5;
            this.dateStartLabel.Text = "Start Date";
            // 
            // dateEndLabel
            // 
            this.dateEndLabel.AutoSize = true;
            this.dateEndLabel.Location = new System.Drawing.Point(15, 99);
            this.dateEndLabel.Name = "dateEndLabel";
            this.dateEndLabel.Size = new System.Drawing.Size(52, 13);
            this.dateEndLabel.TabIndex = 6;
            this.dateEndLabel.Text = "End Date";
            // 
            // CalendarForm
            // 
            this.ClientSize = new System.Drawing.Size(233, 240);
            this.Controls.Add(this.dateEndLabel);
            this.Controls.Add(this.dateStartLabel);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.calendarCancelButton);
            this.Controls.Add(this.calendarOkButton);
            this.Name = "CalendarForm";
            this.Text = "Choose End Date";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
