namespace ActiveType
{
    partial class UserStats
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
            PureComponents.NicePanel.ContainerImage containerImage1 = new PureComponents.NicePanel.ContainerImage();
            PureComponents.NicePanel.HeaderImage headerImage1 = new PureComponents.NicePanel.HeaderImage();
            PureComponents.NicePanel.HeaderImage headerImage2 = new PureComponents.NicePanel.HeaderImage();
            PureComponents.NicePanel.PanelStyle panelStyle1 = new PureComponents.NicePanel.PanelStyle();
            PureComponents.NicePanel.ContainerStyle containerStyle1 = new PureComponents.NicePanel.ContainerStyle();
            PureComponents.NicePanel.PanelHeaderStyle panelHeaderStyle1 = new PureComponents.NicePanel.PanelHeaderStyle();
            PureComponents.NicePanel.PanelHeaderStyle panelHeaderStyle2 = new PureComponents.NicePanel.PanelHeaderStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserStats));
            this.userCoursesTree = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statisticsTabControl = new System.Windows.Forms.TabControl();
            this.userStatsTab = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.userTotalTimeSpentLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.userLastLogin = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.totalCompletedCoursesLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.currentSessionPathLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.currentSessionNameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.userUsernameLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.userLastNameLabel = new System.Windows.Forms.Label();
            this.userFirstNameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.accuracyTab = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.overallCourseAccuracyLabel = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.currentCourseName1Label = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.selectedCourseAccuracyLabel = new System.Windows.Forms.Label();
            this.timeTakenTab = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.overallTimeTakenLabel = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.currentCourseName2Label = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.selectedCourseTimeTakenLabel = new System.Windows.Forms.Label();
            this.keyResponseTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.nicePanel1 = new PureComponents.NicePanel.NicePanel();
            this.groupBox1.SuspendLayout();
            this.statisticsTabControl.SuspendLayout();
            this.userStatsTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.accuracyTab.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.timeTakenTab.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.nicePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userCoursesTree
            // 
            this.userCoursesTree.Location = new System.Drawing.Point(15, 53);
            this.userCoursesTree.Name = "userCoursesTree";
            this.userCoursesTree.Size = new System.Drawing.Size(155, 329);
            this.userCoursesTree.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statisticsTabControl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.userCoursesTree);
            this.groupBox1.Location = new System.Drawing.Point(17, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 388);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // statisticsTabControl
            // 
            this.statisticsTabControl.Controls.Add(this.userStatsTab);
            this.statisticsTabControl.Controls.Add(this.accuracyTab);
            this.statisticsTabControl.Controls.Add(this.timeTakenTab);
            this.statisticsTabControl.Controls.Add(this.keyResponseTab);
            this.statisticsTabControl.Location = new System.Drawing.Point(187, 33);
            this.statisticsTabControl.Name = "statisticsTabControl";
            this.statisticsTabControl.SelectedIndex = 0;
            this.statisticsTabControl.Size = new System.Drawing.Size(456, 349);
            this.statisticsTabControl.TabIndex = 2;
            // 
            // userStatsTab
            // 
            this.userStatsTab.Controls.Add(this.groupBox4);
            this.userStatsTab.Controls.Add(this.groupBox3);
            this.userStatsTab.Controls.Add(this.groupBox2);
            this.userStatsTab.Location = new System.Drawing.Point(4, 22);
            this.userStatsTab.Name = "userStatsTab";
            this.userStatsTab.Padding = new System.Windows.Forms.Padding(3);
            this.userStatsTab.Size = new System.Drawing.Size(448, 323);
            this.userStatsTab.TabIndex = 0;
            this.userStatsTab.Text = "User Statistics";
            this.userStatsTab.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.userTotalTimeSpentLabel);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.userLastLogin);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(214, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(228, 153);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // userTotalTimeSpentLabel
            // 
            this.userTotalTimeSpentLabel.AutoSize = true;
            this.userTotalTimeSpentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.userTotalTimeSpentLabel.Location = new System.Drawing.Point(6, 119);
            this.userTotalTimeSpentLabel.Name = "userTotalTimeSpentLabel";
            this.userTotalTimeSpentLabel.Size = new System.Drawing.Size(117, 18);
            this.userTotalTimeSpentLabel.TabIndex = 9;
            this.userTotalTimeSpentLabel.Text = "1 day 12:34:66";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "Last Login";
            // 
            // userLastLogin
            // 
            this.userLastLogin.AutoSize = true;
            this.userLastLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.userLastLogin.Location = new System.Drawing.Point(6, 57);
            this.userLastLogin.Name = "userLastLogin";
            this.userLastLogin.Size = new System.Drawing.Size(90, 18);
            this.userLastLogin.TabIndex = 8;
            this.userLastLogin.Text = "21.03.2007";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(6, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 18);
            this.label9.TabIndex = 7;
            this.label9.Text = "Total Time";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.totalCompletedCoursesLabel);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.currentSessionPathLabel);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.currentSessionNameLabel);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(6, 161);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 153);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Session Information";
            // 
            // totalCompletedCoursesLabel
            // 
            this.totalCompletedCoursesLabel.AutoSize = true;
            this.totalCompletedCoursesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.totalCompletedCoursesLabel.Location = new System.Drawing.Point(99, 119);
            this.totalCompletedCoursesLabel.Name = "totalCompletedCoursesLabel";
            this.totalCompletedCoursesLabel.Size = new System.Drawing.Size(180, 18);
            this.totalCompletedCoursesLabel.TabIndex = 7;
            this.totalCompletedCoursesLabel.Text = "12 courses completed.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(6, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Courses";
            // 
            // currentSessionPathLabel
            // 
            this.currentSessionPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.currentSessionPathLabel.Location = new System.Drawing.Point(99, 57);
            this.currentSessionPathLabel.Name = "currentSessionPathLabel";
            this.currentSessionPathLabel.Size = new System.Drawing.Size(331, 47);
            this.currentSessionPathLabel.TabIndex = 5;
            this.currentSessionPathLabel.Text = "C:\\Sessions\\test.ses";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Path";
            // 
            // currentSessionNameLabel
            // 
            this.currentSessionNameLabel.AutoSize = true;
            this.currentSessionNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.currentSessionNameLabel.Location = new System.Drawing.Point(99, 30);
            this.currentSessionNameLabel.Name = "currentSessionNameLabel";
            this.currentSessionNameLabel.Size = new System.Drawing.Size(55, 18);
            this.currentSessionNameLabel.TabIndex = 3;
            this.currentSessionNameLabel.Text = "Ahmet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(6, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.userUsernameLabel);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.userLastNameLabel);
            this.groupBox2.Controls.Add(this.userFirstNameLabel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 153);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Information";
            // 
            // userUsernameLabel
            // 
            this.userUsernameLabel.AutoSize = true;
            this.userUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.userUsernameLabel.Location = new System.Drawing.Point(99, 96);
            this.userUsernameLabel.Name = "userUsernameLabel";
            this.userUsernameLabel.Size = new System.Drawing.Size(58, 18);
            this.userUsernameLabel.TabIndex = 5;
            this.userUsernameLabel.Text = "abutun";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(6, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Username";
            // 
            // userLastNameLabel
            // 
            this.userLastNameLabel.AutoSize = true;
            this.userLastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.userLastNameLabel.Location = new System.Drawing.Point(99, 62);
            this.userLastNameLabel.Name = "userLastNameLabel";
            this.userLastNameLabel.Size = new System.Drawing.Size(65, 18);
            this.userLastNameLabel.TabIndex = 3;
            this.userLastNameLabel.Text = "BÜTÜN";
            // 
            // userFirstNameLabel
            // 
            this.userFirstNameLabel.AutoSize = true;
            this.userFirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.userFirstNameLabel.Location = new System.Drawing.Point(99, 27);
            this.userFirstNameLabel.Name = "userFirstNameLabel";
            this.userFirstNameLabel.Size = new System.Drawing.Size(55, 18);
            this.userFirstNameLabel.TabIndex = 2;
            this.userFirstNameLabel.Text = "Ahmet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Surname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // accuracyTab
            // 
            this.accuracyTab.Controls.Add(this.groupBox6);
            this.accuracyTab.Controls.Add(this.groupBox5);
            this.accuracyTab.Location = new System.Drawing.Point(4, 22);
            this.accuracyTab.Name = "accuracyTab";
            this.accuracyTab.Padding = new System.Windows.Forms.Padding(3);
            this.accuracyTab.Size = new System.Drawing.Size(448, 323);
            this.accuracyTab.TabIndex = 1;
            this.accuracyTab.Text = "Accuracy";
            this.accuracyTab.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.overallCourseAccuracyLabel);
            this.groupBox6.Location = new System.Drawing.Point(6, 165);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(436, 153);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Overall Accuracy";
            // 
            // overallCourseAccuracyLabel
            // 
            this.overallCourseAccuracyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.overallCourseAccuracyLabel.Location = new System.Drawing.Point(53, 23);
            this.overallCourseAccuracyLabel.Name = "overallCourseAccuracyLabel";
            this.overallCourseAccuracyLabel.Size = new System.Drawing.Size(331, 107);
            this.overallCourseAccuracyLabel.TabIndex = 6;
            this.overallCourseAccuracyLabel.Text = "55 %";
            this.overallCourseAccuracyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.currentCourseName1Label);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.selectedCourseAccuracyLabel);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(436, 153);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Course Accuracy";
            // 
            // currentCourseName1Label
            // 
            this.currentCourseName1Label.AutoSize = true;
            this.currentCourseName1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.currentCourseName1Label.Location = new System.Drawing.Point(99, 34);
            this.currentCourseName1Label.Name = "currentCourseName1Label";
            this.currentCourseName1Label.Size = new System.Drawing.Size(55, 18);
            this.currentCourseName1Label.TabIndex = 7;
            this.currentCourseName1Label.Text = "Test 1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(6, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 18);
            this.label11.TabIndex = 6;
            this.label11.Text = "Name";
            // 
            // selectedCourseAccuracyLabel
            // 
            this.selectedCourseAccuracyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.selectedCourseAccuracyLabel.Location = new System.Drawing.Point(53, 61);
            this.selectedCourseAccuracyLabel.Name = "selectedCourseAccuracyLabel";
            this.selectedCourseAccuracyLabel.Size = new System.Drawing.Size(331, 89);
            this.selectedCourseAccuracyLabel.TabIndex = 5;
            this.selectedCourseAccuracyLabel.Text = "55 %";
            this.selectedCourseAccuracyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeTakenTab
            // 
            this.timeTakenTab.Controls.Add(this.groupBox7);
            this.timeTakenTab.Controls.Add(this.groupBox8);
            this.timeTakenTab.Location = new System.Drawing.Point(4, 22);
            this.timeTakenTab.Name = "timeTakenTab";
            this.timeTakenTab.Size = new System.Drawing.Size(448, 323);
            this.timeTakenTab.TabIndex = 2;
            this.timeTakenTab.Text = "Time Taken";
            this.timeTakenTab.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.overallTimeTakenLabel);
            this.groupBox7.Location = new System.Drawing.Point(6, 165);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(436, 153);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Overall Time Taken";
            // 
            // overallTimeTakenLabel
            // 
            this.overallTimeTakenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.overallTimeTakenLabel.Location = new System.Drawing.Point(53, 23);
            this.overallTimeTakenLabel.Name = "overallTimeTakenLabel";
            this.overallTimeTakenLabel.Size = new System.Drawing.Size(331, 107);
            this.overallTimeTakenLabel.TabIndex = 6;
            this.overallTimeTakenLabel.Text = "4 d 03:45:89";
            this.overallTimeTakenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.currentCourseName2Label);
            this.groupBox8.Controls.Add(this.label12);
            this.groupBox8.Controls.Add(this.selectedCourseTimeTakenLabel);
            this.groupBox8.Location = new System.Drawing.Point(6, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(436, 153);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Course Time Taken";
            // 
            // currentCourseName2Label
            // 
            this.currentCourseName2Label.AutoSize = true;
            this.currentCourseName2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.currentCourseName2Label.Location = new System.Drawing.Point(99, 34);
            this.currentCourseName2Label.Name = "currentCourseName2Label";
            this.currentCourseName2Label.Size = new System.Drawing.Size(55, 18);
            this.currentCourseName2Label.TabIndex = 9;
            this.currentCourseName2Label.Text = "Test 1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(6, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 18);
            this.label12.TabIndex = 8;
            this.label12.Text = "Name";
            // 
            // selectedCourseTimeTakenLabel
            // 
            this.selectedCourseTimeTakenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.selectedCourseTimeTakenLabel.Location = new System.Drawing.Point(53, 61);
            this.selectedCourseTimeTakenLabel.Name = "selectedCourseTimeTakenLabel";
            this.selectedCourseTimeTakenLabel.Size = new System.Drawing.Size(331, 89);
            this.selectedCourseTimeTakenLabel.TabIndex = 5;
            this.selectedCourseTimeTakenLabel.Text = "4 d 03:45:89";
            this.selectedCourseTimeTakenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keyResponseTab
            // 
            this.keyResponseTab.Location = new System.Drawing.Point(4, 22);
            this.keyResponseTab.Name = "keyResponseTab";
            this.keyResponseTab.Size = new System.Drawing.Size(448, 323);
            this.keyResponseTab.TabIndex = 3;
            this.keyResponseTab.Text = "Key Stats";
            this.keyResponseTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Course Tree";
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(581, 433);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // nicePanel1
            // 
            this.nicePanel1.BackColor = System.Drawing.Color.Transparent;
            this.nicePanel1.CloseButton = true;
            this.nicePanel1.CollapseButton = false;
            containerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight;
            containerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            containerImage1.Image = null;
            containerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small;
            containerImage1.Transparency = 50;
            this.nicePanel1.ContainerImage = containerImage1;
            this.nicePanel1.ContextMenuButton = false;
            this.nicePanel1.Controls.Add(this.groupBox1);
            this.nicePanel1.Controls.Add(this.closeButton);
            headerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            headerImage1.Image = null;
            this.nicePanel1.FooterImage = headerImage1;
            this.nicePanel1.FooterText = "Statistics";
            this.nicePanel1.ForeColor = System.Drawing.Color.Black;
            headerImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Trash;
            headerImage2.Image = null;
            this.nicePanel1.HeaderImage = headerImage2;
            this.nicePanel1.HeaderText = "ActiveType - User Statistics";
            this.nicePanel1.IsExpanded = true;
            this.nicePanel1.Location = new System.Drawing.Point(0, 0);
            this.nicePanel1.MinimizeButton = true;
            this.nicePanel1.Name = "nicePanel1";
            this.nicePanel1.OriginalFooterVisible = true;
            this.nicePanel1.OriginalHeight = 0;
            this.nicePanel1.Resizable = false;
            this.nicePanel1.Size = new System.Drawing.Size(684, 481);
            containerStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            containerStyle1.BaseColor = System.Drawing.Color.Transparent;
            containerStyle1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            containerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid;
            containerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left;
            containerStyle1.FadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(232)))), ((int)(((byte)(252)))));
            containerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward;
            containerStyle1.FlashItemBackColor = System.Drawing.Color.Red;
            containerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            containerStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            containerStyle1.ForeColor = System.Drawing.Color.Black;
            containerStyle1.Shape = PureComponents.NicePanel.Shape.Squared;
            panelStyle1.ContainerStyle = containerStyle1;
            panelHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(42)))), ((int)(((byte)(127)))));
            panelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            panelHeaderStyle1.FadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            panelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading;
            panelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(122)))), ((int)(((byte)(1)))));
            panelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(159)))));
            panelHeaderStyle1.FlashForeColor = System.Drawing.Color.White;
            panelHeaderStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            panelHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(198)))), ((int)(((byte)(237)))));
            panelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small;
            panelStyle1.FooterStyle = panelHeaderStyle1;
            panelHeaderStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            panelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            panelHeaderStyle2.FadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(42)))), ((int)(((byte)(127)))));
            panelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.VerticalFading;
            panelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(122)))), ((int)(((byte)(1)))));
            panelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(159)))));
            panelHeaderStyle2.FlashForeColor = System.Drawing.Color.White;
            panelHeaderStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            panelHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            panelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium;
            panelStyle1.HeaderStyle = panelHeaderStyle2;
            this.nicePanel1.Style = panelStyle1;
            this.nicePanel1.TabIndex = 3;
            // 
            // UserStats
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(684, 481);
            this.Controls.Add(this.nicePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserStats";
            this.Text = "ActiveType - Statistics";
            this.Load += new System.EventHandler(this.UserStats_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statisticsTabControl.ResumeLayout(false);
            this.userStatsTab.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.accuracyTab.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.timeTakenTab.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.nicePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView userCoursesTree;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl statisticsTabControl;
        private System.Windows.Forms.TabPage userStatsTab;
        private System.Windows.Forms.TabPage accuracyTab;
        private System.Windows.Forms.TabPage timeTakenTab;
        private System.Windows.Forms.TabPage keyResponseTab;
        private System.Windows.Forms.Button closeButton;
        private PureComponents.NicePanel.NicePanel nicePanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label userTotalTimeSpentLabel;
        private System.Windows.Forms.Label userLastLogin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label userUsernameLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label userLastNameLabel;
        private System.Windows.Forms.Label userFirstNameLabel;
        private System.Windows.Forms.Label currentSessionNameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label totalCompletedCoursesLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label currentSessionPathLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label overallCourseAccuracyLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label selectedCourseAccuracyLabel;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label overallTimeTakenLabel;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label selectedCourseTimeTakenLabel;
        private System.Windows.Forms.Label currentCourseName1Label;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label currentCourseName2Label;
        private System.Windows.Forms.Label label12;
    }
}