
namespace thesis_UI1
{
    public partial class Main_Form
    {

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.addPerson = new System.Windows.Forms.Button();
            this.addNewDataType = new System.Windows.Forms.Button();
            this.dataTypesGrid = new System.Windows.Forms.DataGridView();
            this.parametersGrid = new System.Windows.Forms.DataGridView();
            this.parametersColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addParameterButton = new System.Windows.Forms.Button();
            this.newDataTypeSelectionBox = new System.Windows.Forms.ComboBox();
            this.newParameterTypeBox = new System.Windows.Forms.ComboBox();
            this.selectParameterBox = new System.Windows.Forms.ComboBox();
            this.selectNewDataTypeLabel = new System.Windows.Forms.Label();
            this.selectParameterTypeLabel = new System.Windows.Forms.Label();
            this.selectParameterLabel = new System.Windows.Forms.Label();
            this.timeLabal = new System.Windows.Forms.Label();
            this.minHourDataComboBox = new System.Windows.Forms.ComboBox();
            this.minHourDataTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.minOrHourLabel = new System.Windows.Forms.Label();
            this.dataTypeDeleteButton = new System.Windows.Forms.Button();
            this.parameterDeleteButton = new System.Windows.Forms.Button();
            this.DataGridLabel = new System.Windows.Forms.Label();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.parametersToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.sleepingParameterLabel = new System.Windows.Forms.Label();
            this.sleepingParameterComboBox = new System.Windows.Forms.ComboBox();
            this.dateIntervalForDataTimeLabel = new System.Windows.Forms.Label();
            this.dateIntervalForDataTextLabel = new System.Windows.Forms.Label();
            this.enterDataCountLabel = new System.Windows.Forms.Label();
            this.selectInputDataComboBox = new System.Windows.Forms.ComboBox();
            this.dataCountForDataTextBox = new System.Windows.Forms.TextBox();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.assignedQuestionsToBeAskedDataGrid = new System.Windows.Forms.DataGridView();
            this.dataCountForQuLabel = new System.Windows.Forms.Label();
            this.dateIntervalForQuTimeLabel = new System.Windows.Forms.Label();
            this.dateIntervalForQuTextLabel = new System.Windows.Forms.Label();
            this.selectInputQuComboBox = new System.Windows.Forms.ComboBox();
            this.dataCountForQuTextBox = new System.Windows.Forms.TextBox();
            this.minHourInputQuTextBox = new System.Windows.Forms.TextBox();
            this.askingRateLabel = new System.Windows.Forms.Label();
            this.minHourQuComboBox = new System.Windows.Forms.ComboBox();
            this.questionsAssignedToPersonLabel = new System.Windows.Forms.Label();
            this.deleteQuestionButton = new System.Windows.Forms.Button();
            this.addQuestionToPersonButton = new System.Windows.Forms.Button();
            this.questionSelectionListBox = new System.Windows.Forms.ListBox();
            this.questionListlabel = new System.Windows.Forms.Label();
            this.addSomethingToPersonBox = new System.Windows.Forms.ComboBox();
            this.questionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.questionsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.stopButton = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.DataNoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generate = new System.Windows.Forms.Button();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personsGrid = new System.Windows.Forms.DataGridView();
            this.deletePersonButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataTypesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersGrid)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.parametersToolStripContainer.ContentPanel.SuspendLayout();
            this.parametersToolStripContainer.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assignedQuestionsToBeAskedDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // addPerson
            // 
            this.addPerson.BackColor = System.Drawing.Color.LemonChiffon;
            this.addPerson.Location = new System.Drawing.Point(154, 269);
            this.addPerson.Name = "addPerson";
            this.addPerson.Size = new System.Drawing.Size(75, 23);
            this.addPerson.TabIndex = 1;
            this.addPerson.Text = "Add Person";
            this.addPerson.UseVisualStyleBackColor = false;
            this.addPerson.Click += new System.EventHandler(this.addPatient_Click);
            // 
            // addNewDataType
            // 
            this.addNewDataType.BackColor = System.Drawing.Color.LemonChiffon;
            this.addNewDataType.Location = new System.Drawing.Point(3, 341);
            this.addNewDataType.Name = "addNewDataType";
            this.addNewDataType.Size = new System.Drawing.Size(147, 23);
            this.addNewDataType.TabIndex = 5;
            this.addNewDataType.Text = "Add New Data Type";
            this.addNewDataType.UseVisualStyleBackColor = false;
            this.addNewDataType.Click += new System.EventHandler(this.addNewSensor_Click);
            // 
            // dataTypesGrid
            // 
            this.dataTypesGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataTypesGrid.ColumnHeadersHeight = 21;
            this.dataTypesGrid.Location = new System.Drawing.Point(3, 12);
            this.dataTypesGrid.Name = "dataTypesGrid";
            this.dataTypesGrid.ReadOnly = true;
            this.dataTypesGrid.Size = new System.Drawing.Size(466, 127);
            this.dataTypesGrid.TabIndex = 10;
            this.dataTypesGrid.SelectionChanged += new System.EventHandler(this.dataTypesGrid_SelectionChanged);
            // 
            // parametersGrid
            // 
            this.parametersGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.parametersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parametersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parametersColumn,
            this.Value});
            this.parametersGrid.Location = new System.Drawing.Point(32, 8);
            this.parametersGrid.Name = "parametersGrid";
            this.parametersGrid.ReadOnly = true;
            this.parametersGrid.Size = new System.Drawing.Size(272, 157);
            this.parametersGrid.TabIndex = 11;
            // 
            // parametersColumn
            // 
            this.parametersColumn.HeaderText = "Parameters";
            this.parametersColumn.Name = "parametersColumn";
            this.parametersColumn.ReadOnly = true;
            this.parametersColumn.Width = 150;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 70;
            // 
            // addParameterButton
            // 
            this.addParameterButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.addParameterButton.Location = new System.Drawing.Point(31, 222);
            this.addParameterButton.Name = "addParameterButton";
            this.addParameterButton.Size = new System.Drawing.Size(121, 23);
            this.addParameterButton.TabIndex = 12;
            this.addParameterButton.Text = "Add New Parameter";
            this.addParameterButton.UseVisualStyleBackColor = false;
            this.addParameterButton.Click += new System.EventHandler(this.addParameterButton_Click);
            // 
            // newDataTypeSelectionBox
            // 
            this.newDataTypeSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newDataTypeSelectionBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.newDataTypeSelectionBox.FormattingEnabled = true;
            this.newDataTypeSelectionBox.Location = new System.Drawing.Point(3, 308);
            this.newDataTypeSelectionBox.Name = "newDataTypeSelectionBox";
            this.newDataTypeSelectionBox.Size = new System.Drawing.Size(121, 21);
            this.newDataTypeSelectionBox.TabIndex = 13;
            // 
            // newParameterTypeBox
            // 
            this.newParameterTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newParameterTypeBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.newParameterTypeBox.FormattingEnabled = true;
            this.newParameterTypeBox.Location = new System.Drawing.Point(32, 191);
            this.newParameterTypeBox.Name = "newParameterTypeBox";
            this.newParameterTypeBox.Size = new System.Drawing.Size(121, 21);
            this.newParameterTypeBox.TabIndex = 14;
            this.newParameterTypeBox.SelectionChangeCommitted += new System.EventHandler(this.newParameterTypeBox_SelectedIndexChanged);
            // 
            // selectParameterBox
            // 
            this.selectParameterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectParameterBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.selectParameterBox.FormattingEnabled = true;
            this.selectParameterBox.Location = new System.Drawing.Point(183, 192);
            this.selectParameterBox.Name = "selectParameterBox";
            this.selectParameterBox.Size = new System.Drawing.Size(121, 21);
            this.selectParameterBox.TabIndex = 15;
            // 
            // selectNewDataTypeLabel
            // 
            this.selectNewDataTypeLabel.AutoSize = true;
            this.selectNewDataTypeLabel.Location = new System.Drawing.Point(0, 292);
            this.selectNewDataTypeLabel.Name = "selectNewDataTypeLabel";
            this.selectNewDataTypeLabel.Size = new System.Drawing.Size(115, 13);
            this.selectNewDataTypeLabel.TabIndex = 16;
            this.selectNewDataTypeLabel.Text = "Select New Data Type";
            // 
            // selectParameterTypeLabel
            // 
            this.selectParameterTypeLabel.AutoSize = true;
            this.selectParameterTypeLabel.Location = new System.Drawing.Point(29, 175);
            this.selectParameterTypeLabel.Name = "selectParameterTypeLabel";
            this.selectParameterTypeLabel.Size = new System.Drawing.Size(123, 13);
            this.selectParameterTypeLabel.TabIndex = 17;
            this.selectParameterTypeLabel.Text = "Daylight Parameter Type";
            // 
            // selectParameterLabel
            // 
            this.selectParameterLabel.AutoSize = true;
            this.selectParameterLabel.Location = new System.Drawing.Point(180, 176);
            this.selectParameterLabel.Name = "selectParameterLabel";
            this.selectParameterLabel.Size = new System.Drawing.Size(96, 13);
            this.selectParameterLabel.TabIndex = 18;
            this.selectParameterLabel.Text = "Daylight Parameter";
            // 
            // timeLabal
            // 
            this.timeLabal.AutoSize = true;
            this.timeLabal.Enabled = false;
            this.timeLabal.Location = new System.Drawing.Point(0, 180);
            this.timeLabal.Name = "timeLabal";
            this.timeLabal.Size = new System.Drawing.Size(80, 13);
            this.timeLabal.TabIndex = 19;
            this.timeLabal.Text = "Update Interval";
            // 
            // minHourDataComboBox
            // 
            this.minHourDataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minHourDataComboBox.DropDownWidth = 75;
            this.minHourDataComboBox.Enabled = false;
            this.minHourDataComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.minHourDataComboBox.FormattingEnabled = true;
            this.minHourDataComboBox.Items.AddRange(new object[] {
            "Min",
            "Hour"});
            this.minHourDataComboBox.Location = new System.Drawing.Point(3, 196);
            this.minHourDataComboBox.Name = "minHourDataComboBox";
            this.minHourDataComboBox.Size = new System.Drawing.Size(75, 21);
            this.minHourDataComboBox.TabIndex = 20;
            this.minHourDataComboBox.SelectedIndexChanged += new System.EventHandler(this.minHourDataSelectedIndexChanged);
            // 
            // minHourDataTextBox
            // 
            this.minHourDataTextBox.Enabled = false;
            this.minHourDataTextBox.Location = new System.Drawing.Point(100, 197);
            this.minHourDataTextBox.Name = "minHourDataTextBox";
            this.minHourDataTextBox.Size = new System.Drawing.Size(50, 20);
            this.minHourDataTextBox.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(97, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Enter";
            // 
            // minOrHourLabel
            // 
            this.minOrHourLabel.AutoSize = true;
            this.minOrHourLabel.Enabled = false;
            this.minOrHourLabel.Location = new System.Drawing.Point(125, 167);
            this.minOrHourLabel.Name = "minOrHourLabel";
            this.minOrHourLabel.Size = new System.Drawing.Size(0, 13);
            this.minOrHourLabel.TabIndex = 23;
            // 
            // dataTypeDeleteButton
            // 
            this.dataTypeDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataTypeDeleteButton.Location = new System.Drawing.Point(4, 371);
            this.dataTypeDeleteButton.Name = "dataTypeDeleteButton";
            this.dataTypeDeleteButton.Size = new System.Drawing.Size(146, 23);
            this.dataTypeDeleteButton.TabIndex = 24;
            this.dataTypeDeleteButton.Text = "Delete Selected Data Type";
            this.dataTypeDeleteButton.UseVisualStyleBackColor = false;
            this.dataTypeDeleteButton.Click += new System.EventHandler(this.sensorDeleteButton_Click);
            // 
            // parameterDeleteButton
            // 
            this.parameterDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.parameterDeleteButton.Location = new System.Drawing.Point(183, 222);
            this.parameterDeleteButton.Name = "parameterDeleteButton";
            this.parameterDeleteButton.Size = new System.Drawing.Size(121, 23);
            this.parameterDeleteButton.TabIndex = 25;
            this.parameterDeleteButton.Text = "Delete Selected Parameter";
            this.parameterDeleteButton.UseVisualStyleBackColor = false;
            this.parameterDeleteButton.Click += new System.EventHandler(this.parameterDeleteButton_Click);
            // 
            // DataGridLabel
            // 
            this.DataGridLabel.AutoSize = true;
            this.DataGridLabel.Location = new System.Drawing.Point(593, 3);
            this.DataGridLabel.Name = "DataGridLabel";
            this.DataGridLabel.Size = new System.Drawing.Size(52, 13);
            this.DataGridLabel.TabIndex = 29;
            this.DataGridLabel.Text = "Data Grid";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.parametersToolStripContainer);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dateIntervalForDataTimeLabel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dateIntervalForDataTextLabel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.enterDataCountLabel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.selectInputDataComboBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStripContainer2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataCountForDataTextBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.addNewDataType);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataTypesGrid);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataTypeDeleteButton);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.selectNewDataTypeLabel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.newDataTypeSelectionBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.minOrHourLabel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.timeLabal);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.minHourDataTextBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.minHourDataComboBox);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(472, 491);
            this.toolStripContainer1.Location = new System.Drawing.Point(9, 330);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(472, 491);
            this.toolStripContainer1.TabIndex = 30;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // parametersToolStripContainer
            // 
            // 
            // parametersToolStripContainer.ContentPanel
            // 
            this.parametersToolStripContainer.ContentPanel.Controls.Add(this.sleepingParameterLabel);
            this.parametersToolStripContainer.ContentPanel.Controls.Add(this.sleepingParameterComboBox);
            this.parametersToolStripContainer.ContentPanel.Controls.Add(this.parametersGrid);
            this.parametersToolStripContainer.ContentPanel.Controls.Add(this.selectParameterLabel);
            this.parametersToolStripContainer.ContentPanel.Controls.Add(this.selectParameterTypeLabel);
            this.parametersToolStripContainer.ContentPanel.Controls.Add(this.selectParameterBox);
            this.parametersToolStripContainer.ContentPanel.Controls.Add(this.parameterDeleteButton);
            this.parametersToolStripContainer.ContentPanel.Controls.Add(this.newParameterTypeBox);
            this.parametersToolStripContainer.ContentPanel.Controls.Add(this.addParameterButton);
            this.parametersToolStripContainer.ContentPanel.Size = new System.Drawing.Size(307, 292);
            this.parametersToolStripContainer.Location = new System.Drawing.Point(162, 149);
            this.parametersToolStripContainer.Name = "parametersToolStripContainer";
            this.parametersToolStripContainer.Size = new System.Drawing.Size(307, 317);
            this.parametersToolStripContainer.TabIndex = 43;
            this.parametersToolStripContainer.Text = "toolStripContainer3";
            // 
            // sleepingParameterLabel
            // 
            this.sleepingParameterLabel.AutoSize = true;
            this.sleepingParameterLabel.Location = new System.Drawing.Point(115, 265);
            this.sleepingParameterLabel.Name = "sleepingParameterLabel";
            this.sleepingParameterLabel.Size = new System.Drawing.Size(99, 13);
            this.sleepingParameterLabel.TabIndex = 27;
            this.sleepingParameterLabel.Text = "Sleeping Parameter";
            // 
            // sleepingParameterComboBox
            // 
            this.sleepingParameterComboBox.FormattingEnabled = true;
            this.sleepingParameterComboBox.Location = new System.Drawing.Point(118, 283);
            this.sleepingParameterComboBox.Name = "sleepingParameterComboBox";
            this.sleepingParameterComboBox.Size = new System.Drawing.Size(96, 21);
            this.sleepingParameterComboBox.TabIndex = 26;
            this.sleepingParameterComboBox.SelectionChangeCommitted += new System.EventHandler(this.sleepingParameterComboBox_SelectedIndexChanged);
            // 
            // dateIntervalForDataTimeLabel
            // 
            this.dateIntervalForDataTimeLabel.AutoSize = true;
            this.dateIntervalForDataTimeLabel.Enabled = false;
            this.dateIntervalForDataTimeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dateIntervalForDataTimeLabel.Location = new System.Drawing.Point(93, 252);
            this.dateIntervalForDataTimeLabel.Name = "dateIntervalForDataTimeLabel";
            this.dateIntervalForDataTimeLabel.Size = new System.Drawing.Size(33, 13);
            this.dateIntervalForDataTimeLabel.TabIndex = 36;
            this.dateIntervalForDataTimeLabel.Text = "None";
            // 
            // dateIntervalForDataTextLabel
            // 
            this.dateIntervalForDataTextLabel.AutoSize = true;
            this.dateIntervalForDataTextLabel.Enabled = false;
            this.dateIntervalForDataTextLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dateIntervalForDataTextLabel.Location = new System.Drawing.Point(3, 252);
            this.dateIntervalForDataTextLabel.Name = "dateIntervalForDataTextLabel";
            this.dateIntervalForDataTextLabel.Size = new System.Drawing.Size(71, 13);
            this.dateIntervalForDataTextLabel.TabIndex = 35;
            this.dateIntervalForDataTextLabel.Text = "Time Interval:";
            // 
            // enterDataCountLabel
            // 
            this.enterDataCountLabel.AutoSize = true;
            this.enterDataCountLabel.Enabled = false;
            this.enterDataCountLabel.Location = new System.Drawing.Point(3, 229);
            this.enterDataCountLabel.Name = "enterDataCountLabel";
            this.enterDataCountLabel.Size = new System.Drawing.Size(85, 13);
            this.enterDataCountLabel.TabIndex = 34;
            this.enterDataCountLabel.Text = "Number of Data:";
            // 
            // selectInputDataComboBox
            // 
            this.selectInputDataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectInputDataComboBox.DropDownWidth = 178;
            this.selectInputDataComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.selectInputDataComboBox.FormattingEnabled = true;
            this.selectInputDataComboBox.Items.AddRange(new object[] {
            "1. Only Update Rate",
            "2. Update Rate and Time Interval",
            "3. Number of Data and Time Interval"});
            this.selectInputDataComboBox.Location = new System.Drawing.Point(4, 157);
            this.selectInputDataComboBox.Name = "selectInputDataComboBox";
            this.selectInputDataComboBox.Size = new System.Drawing.Size(145, 21);
            this.selectInputDataComboBox.TabIndex = 33;
            this.selectInputDataComboBox.SelectionChangeCommitted += new System.EventHandler(this.selectInputDataComboBox_SelectedIndexChanged);
            // 
            // dataCountForDataTextBox
            // 
            this.dataCountForDataTextBox.Enabled = false;
            this.dataCountForDataTextBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dataCountForDataTextBox.Location = new System.Drawing.Point(100, 223);
            this.dataCountForDataTextBox.Name = "dataCountForDataTextBox";
            this.dataCountForDataTextBox.Size = new System.Drawing.Size(50, 20);
            this.dataCountForDataTextBox.TabIndex = 32;
            this.dataCountForDataTextBox.Text = "Count";
            this.dataCountForDataTextBox.Enter += new System.EventHandler(this.dataCountForDataTextBox_Enter);
            this.dataCountForDataTextBox.Leave += new System.EventHandler(this.dataCountForDataTextBox_Leave);
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.assignedQuestionsToBeAskedDataGrid);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.dataCountForQuLabel);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.dateIntervalForQuTimeLabel);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.dateIntervalForQuTextLabel);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.selectInputQuComboBox);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.dataCountForQuTextBox);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.minHourInputQuTextBox);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.askingRateLabel);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.minHourQuComboBox);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.questionsAssignedToPersonLabel);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.deleteQuestionButton);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.addQuestionToPersonButton);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.questionSelectionListBox);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.questionListlabel);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(330, 464);
            this.toolStripContainer2.Location = new System.Drawing.Point(80, 12);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(330, 464);
            this.toolStripContainer2.TabIndex = 32;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // assignedQuestionsToBeAskedDataGrid
            // 
            this.assignedQuestionsToBeAskedDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.assignedQuestionsToBeAskedDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.assignedQuestionsToBeAskedDataGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.assignedQuestionsToBeAskedDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assignedQuestionsToBeAskedDataGrid.Location = new System.Drawing.Point(11, 299);
            this.assignedQuestionsToBeAskedDataGrid.Name = "assignedQuestionsToBeAskedDataGrid";
            this.assignedQuestionsToBeAskedDataGrid.Size = new System.Drawing.Size(295, 99);
            this.assignedQuestionsToBeAskedDataGrid.TabIndex = 40;
            // 
            // dataCountForQuLabel
            // 
            this.dataCountForQuLabel.AutoSize = true;
            this.dataCountForQuLabel.Enabled = false;
            this.dataCountForQuLabel.Location = new System.Drawing.Point(8, 226);
            this.dataCountForQuLabel.Name = "dataCountForQuLabel";
            this.dataCountForQuLabel.Size = new System.Drawing.Size(85, 13);
            this.dataCountForQuLabel.TabIndex = 37;
            this.dataCountForQuLabel.Text = "Number of Data:";
            // 
            // dateIntervalForQuTimeLabel
            // 
            this.dateIntervalForQuTimeLabel.AutoSize = true;
            this.dateIntervalForQuTimeLabel.Enabled = false;
            this.dateIntervalForQuTimeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dateIntervalForQuTimeLabel.Location = new System.Drawing.Point(96, 249);
            this.dateIntervalForQuTimeLabel.Name = "dateIntervalForQuTimeLabel";
            this.dateIntervalForQuTimeLabel.Size = new System.Drawing.Size(33, 13);
            this.dateIntervalForQuTimeLabel.TabIndex = 39;
            this.dateIntervalForQuTimeLabel.Text = "None";
            // 
            // dateIntervalForQuTextLabel
            // 
            this.dateIntervalForQuTextLabel.AutoSize = true;
            this.dateIntervalForQuTextLabel.Enabled = false;
            this.dateIntervalForQuTextLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dateIntervalForQuTextLabel.Location = new System.Drawing.Point(8, 249);
            this.dateIntervalForQuTextLabel.Name = "dateIntervalForQuTextLabel";
            this.dateIntervalForQuTextLabel.Size = new System.Drawing.Size(71, 13);
            this.dateIntervalForQuTextLabel.TabIndex = 38;
            this.dateIntervalForQuTextLabel.Text = "Time Interval:";
            // 
            // selectInputQuComboBox
            // 
            this.selectInputQuComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectInputQuComboBox.DropDownWidth = 178;
            this.selectInputQuComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.selectInputQuComboBox.FormattingEnabled = true;
            this.selectInputQuComboBox.Items.AddRange(new object[] {
            "1. Only Update Rate",
            "2. Update Rate and Time Interval",
            "3. Number of Data and Time Interval"});
            this.selectInputQuComboBox.Location = new System.Drawing.Point(9, 163);
            this.selectInputQuComboBox.Name = "selectInputQuComboBox";
            this.selectInputQuComboBox.Size = new System.Drawing.Size(187, 21);
            this.selectInputQuComboBox.TabIndex = 37;
            this.selectInputQuComboBox.SelectedIndexChanged += new System.EventHandler(this.selectInputQuComboBox_SelectedIndexChanged);
            // 
            // dataCountForQuTextBox
            // 
            this.dataCountForQuTextBox.Enabled = false;
            this.dataCountForQuTextBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dataCountForQuTextBox.Location = new System.Drawing.Point(99, 219);
            this.dataCountForQuTextBox.Name = "dataCountForQuTextBox";
            this.dataCountForQuTextBox.Size = new System.Drawing.Size(41, 20);
            this.dataCountForQuTextBox.TabIndex = 30;
            this.dataCountForQuTextBox.Text = "Count";
            this.dataCountForQuTextBox.Enter += new System.EventHandler(this.questionCountTextBox_Enter);
            this.dataCountForQuTextBox.Leave += new System.EventHandler(this.questionCountTextBox_Leave);
            // 
            // minHourInputQuTextBox
            // 
            this.minHourInputQuTextBox.Enabled = false;
            this.minHourInputQuTextBox.Location = new System.Drawing.Point(156, 192);
            this.minHourInputQuTextBox.Name = "minHourInputQuTextBox";
            this.minHourInputQuTextBox.Size = new System.Drawing.Size(40, 20);
            this.minHourInputQuTextBox.TabIndex = 27;
            // 
            // askingRateLabel
            // 
            this.askingRateLabel.AutoSize = true;
            this.askingRateLabel.Enabled = false;
            this.askingRateLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.askingRateLabel.Location = new System.Drawing.Point(8, 199);
            this.askingRateLabel.Name = "askingRateLabel";
            this.askingRateLabel.Size = new System.Drawing.Size(65, 13);
            this.askingRateLabel.TabIndex = 8;
            this.askingRateLabel.Text = "Asking Rate";
            // 
            // minHourQuComboBox
            // 
            this.minHourQuComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minHourQuComboBox.Enabled = false;
            this.minHourQuComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.minHourQuComboBox.FormattingEnabled = true;
            this.minHourQuComboBox.Items.AddRange(new object[] {
            "Min",
            "Hour"});
            this.minHourQuComboBox.Location = new System.Drawing.Point(99, 192);
            this.minHourQuComboBox.Name = "minHourQuComboBox";
            this.minHourQuComboBox.Size = new System.Drawing.Size(51, 21);
            this.minHourQuComboBox.TabIndex = 26;
            this.minHourQuComboBox.SelectedIndexChanged += new System.EventHandler(this.minHourComboBox_SelectedIndexChanged);
            // 
            // questionsAssignedToPersonLabel
            // 
            this.questionsAssignedToPersonLabel.AutoSize = true;
            this.questionsAssignedToPersonLabel.Location = new System.Drawing.Point(6, 283);
            this.questionsAssignedToPersonLabel.Name = "questionsAssignedToPersonLabel";
            this.questionsAssignedToPersonLabel.Size = new System.Drawing.Size(152, 13);
            this.questionsAssignedToPersonLabel.TabIndex = 5;
            this.questionsAssignedToPersonLabel.Text = "Questions Assigned To Person";
            // 
            // deleteQuestionButton
            // 
            this.deleteQuestionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.deleteQuestionButton.Location = new System.Drawing.Point(7, 404);
            this.deleteQuestionButton.Name = "deleteQuestionButton";
            this.deleteQuestionButton.Size = new System.Drawing.Size(105, 23);
            this.deleteQuestionButton.TabIndex = 4;
            this.deleteQuestionButton.Text = "Delete Question";
            this.deleteQuestionButton.UseVisualStyleBackColor = false;
            this.deleteQuestionButton.Click += new System.EventHandler(this.deleteQuestionButton_Click);
            // 
            // addQuestionToPersonButton
            // 
            this.addQuestionToPersonButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.addQuestionToPersonButton.Location = new System.Drawing.Point(227, 243);
            this.addQuestionToPersonButton.Name = "addQuestionToPersonButton";
            this.addQuestionToPersonButton.Size = new System.Drawing.Size(79, 23);
            this.addQuestionToPersonButton.TabIndex = 2;
            this.addQuestionToPersonButton.Text = "Add Question";
            this.addQuestionToPersonButton.UseVisualStyleBackColor = false;
            this.addQuestionToPersonButton.Click += new System.EventHandler(this.addQuestionToPersonButton_Click);
            // 
            // questionSelectionListBox
            // 
            this.questionSelectionListBox.FormattingEnabled = true;
            this.questionSelectionListBox.Location = new System.Drawing.Point(7, 31);
            this.questionSelectionListBox.Name = "questionSelectionListBox";
            this.questionSelectionListBox.Size = new System.Drawing.Size(299, 121);
            this.questionSelectionListBox.TabIndex = 1;
            // 
            // questionListlabel
            // 
            this.questionListlabel.AutoSize = true;
            this.questionListlabel.Location = new System.Drawing.Point(4, 9);
            this.questionListlabel.Name = "questionListlabel";
            this.questionListlabel.Size = new System.Drawing.Size(124, 13);
            this.questionListlabel.TabIndex = 0;
            this.questionListlabel.Text = "Question List Hardcoded";
            // 
            // addSomethingToPersonBox
            // 
            this.addSomethingToPersonBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addSomethingToPersonBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addSomethingToPersonBox.FormattingEnabled = true;
            this.addSomethingToPersonBox.Items.AddRange(new object[] {
            "Sensors",
            "Questions"});
            this.addSomethingToPersonBox.Location = new System.Drawing.Point(13, 303);
            this.addSomethingToPersonBox.Name = "addSomethingToPersonBox";
            this.addSomethingToPersonBox.Size = new System.Drawing.Size(145, 21);
            this.addSomethingToPersonBox.TabIndex = 31;
            this.addSomethingToPersonBox.SelectedIndexChanged += new System.EventHandler(this.assignSomethingToPersonBox_SelectedIndexChanged);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.stopButton.Location = new System.Drawing.Point(677, 536);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 36;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click_1);
            // 
            // dataGrid
            // 
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataNoColumn,
            this.TimeColumn,
            this.DataColumn});
            this.dataGrid.Location = new System.Drawing.Point(596, 30);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(335, 500);
            this.dataGrid.TabIndex = 35;
            // 
            // DataNoColumn
            // 
            this.DataNoColumn.HeaderText = "Data No";
            this.DataNoColumn.Name = "DataNoColumn";
            this.DataNoColumn.ReadOnly = true;
            this.DataNoColumn.Width = 70;
            // 
            // TimeColumn
            // 
            this.TimeColumn.HeaderText = "Time";
            this.TimeColumn.Name = "TimeColumn";
            this.TimeColumn.ReadOnly = true;
            this.TimeColumn.Width = 120;
            // 
            // DataColumn
            // 
            this.DataColumn.HeaderText = "Data";
            this.DataColumn.Name = "DataColumn";
            this.DataColumn.ReadOnly = true;
            // 
            // generate
            // 
            this.generate.BackColor = System.Drawing.Color.LightGreen;
            this.generate.Location = new System.Drawing.Point(596, 536);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(75, 23);
            this.generate.TabIndex = 34;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = false;
            this.generate.Click += new System.EventHandler(this.generate_Click_1);
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "users";
            // 
            // personsGrid
            // 
            this.personsGrid.AccessibleDescription = "public";
            this.personsGrid.AccessibleName = "personsGrid";
            this.personsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.personsGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.personsGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.personsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personsGrid.Location = new System.Drawing.Point(15, 12);
            this.personsGrid.Name = "personsGrid";
            this.personsGrid.ReadOnly = true;
            this.personsGrid.Size = new System.Drawing.Size(466, 251);
            this.personsGrid.TabIndex = 41;
            this.personsGrid.SelectionChanged += new System.EventHandler(this.patientsGrid_SelectionChanged_1);
            // 
            // deletePersonButton
            // 
            this.deletePersonButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.deletePersonButton.Location = new System.Drawing.Point(278, 269);
            this.deletePersonButton.Name = "deletePersonButton";
            this.deletePersonButton.Size = new System.Drawing.Size(75, 23);
            this.deletePersonButton.TabIndex = 42;
            this.deletePersonButton.Text = "Delete Person";
            this.deletePersonButton.UseVisualStyleBackColor = false;
            this.deletePersonButton.Click += new System.EventHandler(this.deletePatient_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(986, 884);
            this.Controls.Add(this.deletePersonButton);
            this.Controls.Add(this.personsGrid);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.addSomethingToPersonBox);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.DataGridLabel);
            this.Controls.Add(this.addPerson);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_Form";
            this.Text = "Data Generator";
            ((System.ComponentModel.ISupportInitialize)(this.dataTypesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersGrid)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.parametersToolStripContainer.ContentPanel.ResumeLayout(false);
            this.parametersToolStripContainer.ContentPanel.PerformLayout();
            this.parametersToolStripContainer.ResumeLayout(false);
            this.parametersToolStripContainer.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.ContentPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assignedQuestionsToBeAskedDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button addPerson;
        public System.Windows.Forms.Button addNewDataType;
        public System.Windows.Forms.DataGridView dataTypesGrid;
        public System.Windows.Forms.DataGridView parametersGrid;
        public System.Windows.Forms.Button addParameterButton;
        public System.Windows.Forms.ComboBox newDataTypeSelectionBox;
        public System.Windows.Forms.ComboBox newParameterTypeBox;
        public System.Windows.Forms.ComboBox selectParameterBox;
        public System.Windows.Forms.Label selectNewDataTypeLabel;
        public System.Windows.Forms.Label selectParameterTypeLabel;
        public System.Windows.Forms.Label selectParameterLabel;
        public System.Windows.Forms.Label timeLabal;
        public System.Windows.Forms.ComboBox minHourDataComboBox;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label minOrHourLabel;
        public System.Windows.Forms.TextBox minHourDataTextBox;
        public System.Windows.Forms.Button dataTypeDeleteButton;
        public System.Windows.Forms.Button parameterDeleteButton;
        public System.Windows.Forms.Label DataGridLabel;
        public System.Windows.Forms.ToolStripContainer toolStripContainer1;
        public System.Windows.Forms.ComboBox addSomethingToPersonBox;
        public System.Windows.Forms.ToolStripContainer toolStripContainer2;
        public System.Windows.Forms.Label questionListlabel;
        public System.Windows.Forms.Button addQuestionToPersonButton;
        public System.Windows.Forms.Label questionsAssignedToPersonLabel;
        public System.Windows.Forms.Button deleteQuestionButton;
        public System.Windows.Forms.TextBox minHourInputQuTextBox;
        public System.Windows.Forms.Label askingRateLabel;
        public System.Windows.Forms.ComboBox minHourQuComboBox;
        public System.Windows.Forms.TextBox dataCountForQuTextBox;
        public System.Windows.Forms.TextBox dataCountForDataTextBox;
        public System.Windows.Forms.ComboBox selectInputDataComboBox;
        public System.Windows.Forms.Label enterDataCountLabel;
        public System.Windows.Forms.Label dateIntervalForDataTextLabel;
        public System.Windows.Forms.Label dateIntervalForDataTimeLabel;
        public System.Windows.Forms.Label dateIntervalForQuTimeLabel;
        public System.Windows.Forms.Label dateIntervalForQuTextLabel;
        public System.Windows.Forms.ComboBox selectInputQuComboBox;
        public System.Windows.Forms.Label dataCountForQuLabel;

        private System.Windows.Forms.BindingSource questionsBindingSource;

        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.Button stopButton;
        public System.Windows.Forms.DataGridView dataGrid;
        public System.Windows.Forms.DataGridViewTextBoxColumn DataNoColumn;
        public System.Windows.Forms.DataGridViewTextBoxColumn TimeColumn;
        public System.Windows.Forms.DataGridViewTextBoxColumn DataColumn;
        public System.Windows.Forms.Button generate;
        public System.Windows.Forms.BindingSource usersBindingSource;

        public System.Windows.Forms.ListBox questionSelectionListBox;
        public System.Windows.Forms.DataGridView personsGrid;

        private System.Windows.Forms.BindingSource questionsBindingSource1;
        private System.Windows.Forms.Button deletePersonButton;
        private System.Windows.Forms.DataGridView assignedQuestionsToBeAskedDataGrid;
        private System.Windows.Forms.ToolStripContainer parametersToolStripContainer;
        private System.Windows.Forms.Label sleepingParameterLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn parametersColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        public System.Windows.Forms.ComboBox sleepingParameterComboBox;
    }
}

