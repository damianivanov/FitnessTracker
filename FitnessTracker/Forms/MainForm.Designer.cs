using FitnessTracker.UI;

namespace FitnessTracker.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel panelTop;
    private Panel panelMain;
    private Label lblWelcome;
    private Button btnLogout;
    private Label lblTitle;
    private FlowLayoutPanel flpWorkouts;
    private Button btnAddWorkout;
    private Label lblWorkoutsTitle;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.panelTop = new Panel();
        this.panelMain = new Panel();
        this.lblWelcome = new Label();
        this.btnLogout = new Button();
        this.lblTitle = new Label();
        this.flpWorkouts = new FlowLayoutPanel();
        this.btnAddWorkout = new Button();
        this.lblWorkoutsTitle = new Label();
        this.panelTop.SuspendLayout();
        this.panelMain.SuspendLayout();
        this.SuspendLayout();
        
        // 
        // panelTop
        // 
        this.panelTop.BackColor = UiConstants.Colors.BackgroundMedium;
        this.panelTop.Controls.Add(this.lblTitle);
        this.panelTop.Controls.Add(this.lblWelcome);
        this.panelTop.Controls.Add(this.btnLogout);
        this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.panelTop.Location = new System.Drawing.Point(0, 0);
        this.panelTop.Name = "panelTop";
        this.panelTop.Size = new System.Drawing.Size(900, 100);
        this.panelTop.TabIndex = 0;
        
        // 
        // lblTitle
        // 
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segue UI", 20F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = UiConstants.Colors.TextPrimary;
        this.lblTitle.Location = new System.Drawing.Point(20, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(192, 37);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Fitness Tracker";
        
        // 
        // lblWelcome
        // 
        this.lblWelcome.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
        this.lblWelcome.Font = new System.Drawing.Font("Segue UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblWelcome.ForeColor = UiConstants.Colors.TextPrimary;
        this.lblWelcome.Location = new System.Drawing.Point(500, 30);
        this.lblWelcome.Name = "lblWelcome";
        this.lblWelcome.Size = new System.Drawing.Size(280, 25);
        this.lblWelcome.TabIndex = 1;
        this.lblWelcome.Text = "Welcome!";
        this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        
        // 
        // btnLogout
        // 
        this.btnLogout.StyleDanger();
        this.btnLogout.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
        this.btnLogout.Location = new System.Drawing.Point(790, 30);
        this.btnLogout.Name = "btnLogout";
        this.btnLogout.Size = new System.Drawing.Size(90, UiConstants.Button.HeightSmall);
        this.btnLogout.TabIndex = 3;
        this.btnLogout.Text = "Logout";
        this.btnLogout.UseVisualStyleBackColor = false;
        this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
        
        // 
        // panelMain
        // 
        this.panelMain.BackColor = UiConstants.Colors.BackgroundDark;
        this.panelMain.Controls.Add(this.btnAddWorkout);
        this.panelMain.Controls.Add(this.lblWorkoutsTitle);
        this.panelMain.Controls.Add(this.flpWorkouts);
        this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain.Location = new System.Drawing.Point(0, 100);
        this.panelMain.Name = "panelMain";
        this.panelMain.Padding = new Padding(0, 20, 0, 20);
        this.panelMain.Size = new System.Drawing.Size(900, 550);
        this.panelMain.TabIndex = 1;
        
        // 
        // lblWorkoutsTitle
        // 
        this.lblWorkoutsTitle.AutoSize = true;
        this.lblWorkoutsTitle.Font = new System.Drawing.Font("Segue UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblWorkoutsTitle.ForeColor = UiConstants.Colors.TextPrimary;
        this.lblWorkoutsTitle.Location = new System.Drawing.Point(20, 25);
        this.lblWorkoutsTitle.Name = "lblWorkoutsTitle";
        this.lblWorkoutsTitle.Size = new System.Drawing.Size(150, 30);
        this.lblWorkoutsTitle.TabIndex = 0;
        this.lblWorkoutsTitle.Text = "My Workouts";
        
        // 
        // btnAddWorkout
        // 
        this.btnAddWorkout.StyleSuccess();
        this.btnAddWorkout.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.btnAddWorkout.Location = new System.Drawing.Point(180, 20);
        this.btnAddWorkout.Name = "btnAddWorkout";
        this.btnAddWorkout.Size = new System.Drawing.Size(155, 40);
        this.btnAddWorkout.TabIndex = 1;
        this.btnAddWorkout.Text = "+ Add Workout";
        this.btnAddWorkout.UseVisualStyleBackColor = false;
        this.btnAddWorkout.Click += new System.EventHandler(this.btnAddWorkout_Click);
        
        // 
        // flpWorkouts
        // 
        this.flpWorkouts.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right));
        this.flpWorkouts.AutoScroll = true;
        this.flpWorkouts.BackColor = UiConstants.Colors.BackgroundDark;
        this.flpWorkouts.Location = new System.Drawing.Point(20, 75);
        this.flpWorkouts.Name = "flpWorkouts";
        this.flpWorkouts.Size = new System.Drawing.Size(880, 455);
        this.flpWorkouts.TabIndex = 2;
        
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(900, 650);
        this.Controls.Add(this.panelMain);
        this.Controls.Add(this.panelTop);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Fitness Tracker";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
        this.panelTop.ResumeLayout(false);
        this.panelTop.PerformLayout();
        this.panelMain.ResumeLayout(false);
        this.panelMain.PerformLayout();
        this.ResumeLayout(false);
    }
}

