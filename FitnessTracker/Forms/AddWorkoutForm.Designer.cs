using FitnessTracker.UI;

namespace FitnessTracker.Forms;

partial class AddWorkoutForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel panelMain;
    private Label lblTitle;
    private Label lblWorkoutName;
    private TextBox txtWorkoutName;
    private Label lblDate;
    private DateTimePicker dtpWorkoutDate;
    private Label lblExercises;
    private FlowLayoutPanel flpExercises;
    private Button btnAddExercise;
    private Button btnRemoveExercise;
    private Button btnSave;
    private Button btnCancel;

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
        this.panelMain = new Panel();
        this.lblTitle = new Label();
        this.lblWorkoutName = new Label();
        this.txtWorkoutName = new TextBox();
        this.lblDate = new Label();
        this.dtpWorkoutDate = new DateTimePicker();
        this.lblExercises = new Label();
        this.flpExercises = new FlowLayoutPanel();
        this.btnAddExercise = new Button();
        this.btnRemoveExercise = new Button();
        this.btnSave = new Button();
        this.btnCancel = new Button();
        this.panelMain.SuspendLayout();
        this.SuspendLayout();
        
        // 
        // panelMain
        // 
        this.panelMain.BackColor = UiConstants.Colors.BackgroundDark;
        this.panelMain.Controls.Add(this.lblTitle);
        this.panelMain.Controls.Add(this.lblWorkoutName);
        this.panelMain.Controls.Add(this.txtWorkoutName);
        this.panelMain.Controls.Add(this.lblDate);
        this.panelMain.Controls.Add(this.dtpWorkoutDate);
        this.panelMain.Controls.Add(this.lblExercises);
        this.panelMain.Controls.Add(this.flpExercises);
        this.panelMain.Controls.Add(this.btnAddExercise);
        this.panelMain.Controls.Add(this.btnRemoveExercise);
        this.panelMain.Controls.Add(this.btnSave);
        this.panelMain.Controls.Add(this.btnCancel);
        this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain.Location = new System.Drawing.Point(0, 0);
        this.panelMain.Name = "panelMain";
        this.panelMain.Padding = new Padding(30);
        this.panelMain.Size = new System.Drawing.Size(800, 650);
        this.panelMain.TabIndex = 0;
        
        // 
        // lblTitle
        // 
        this.lblTitle.Font = new System.Drawing.Font("Segue UI", 20F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = UiConstants.Colors.TextPrimary;
        this.lblTitle.Location = new System.Drawing.Point(0, 30);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(800, 37);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Add Workout";
        this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        
        // 
        // lblWorkoutName
        // 
        this.lblWorkoutName.StyleLabel();
        this.lblWorkoutName.AutoSize = true;
        this.lblWorkoutName.Location = new System.Drawing.Point(180, 90);
        this.lblWorkoutName.Name = "lblWorkoutName";
        this.lblWorkoutName.Size = new System.Drawing.Size(120, 21);
        this.lblWorkoutName.TabIndex = 1;
        this.lblWorkoutName.Text = "Workout Name:";
        
        // 
        // txtWorkoutName
        // 
        this.txtWorkoutName.StyleInput();
        this.txtWorkoutName.Location = new System.Drawing.Point(50, 120);
        this.txtWorkoutName.Name = "txtWorkoutName";
        this.txtWorkoutName.Size = new System.Drawing.Size(350, 20);
        this.txtWorkoutName.Padding = new Padding(top: 10, left: 5, bottom: 10, right: 5);
        this.txtWorkoutName.TabIndex = 2;
        this.txtWorkoutName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
        
        // 
        // lblDate
        // 
        this.lblDate.StyleLabel();
        this.lblDate.AutoSize = true;
        this.lblDate.Location = new System.Drawing.Point(450, 90);
        this.lblDate.Name = "lblDate";
        this.lblDate.Size = new System.Drawing.Size(45, 20);
        this.lblDate.TabIndex = 3;
        this.lblDate.Text = "Date:";
        
        // 
        // dtpWorkoutDate
        // 
        this.dtpWorkoutDate.CalendarMonthBackground = UiConstants.Colors.BackgroundMedium;
        this.dtpWorkoutDate.Font = new System.Drawing.Font("Segue UI", 12F);
        this.dtpWorkoutDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpWorkoutDate.Location = new System.Drawing.Point(420, 120);
        this.dtpWorkoutDate.Name = "dtpWorkoutDate";
        this.dtpWorkoutDate.Size = new System.Drawing.Size(330, 40);
        this.dtpWorkoutDate.TabIndex = 4;
        
        // 
        // lblExercises
        // 
        this.lblExercises.AutoSize = true;
        this.lblExercises.Font = new System.Drawing.Font("Segue UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblExercises.ForeColor = UiConstants.Colors.TextPrimary;
        this.lblExercises.Location = new System.Drawing.Point(45, 180);
        this.lblExercises.Name = "lblExercises";
        this.lblExercises.Size = new System.Drawing.Size(90, 25);
        this.lblExercises.TabIndex = 5;
        this.lblExercises.Text = "Exercises";
        this.lblExercises.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        
        // 
        // btnAddExercise
        // 
        this.btnAddExercise.StyleSuccess();
        this.btnAddExercise.Location = new System.Drawing.Point(160, 173);
        this.btnAddExercise.Name = "btnAddExercise";
        this.btnAddExercise.Size = new System.Drawing.Size(140, 40);
        this.btnAddExercise.TabIndex = 7;
        this.btnAddExercise.Text = "+ Add Exercise";
        this.btnAddExercise.UseVisualStyleBackColor = false;
        this.btnAddExercise.Click += new System.EventHandler(this.btnAddExercise_Click);
        
        // 
        // flpExercises
        // 
        this.flpExercises.AutoScroll = true;
        this.flpExercises.BackColor = UiConstants.Colors.BackgroundDark;
        this.flpExercises.Location = new System.Drawing.Point(45, 220);
        this.flpExercises.Name = "flpExercises";
        this.flpExercises.Size = new System.Drawing.Size(710, 280);
        this.flpExercises.TabIndex = 6;
        
        // 
        // btnRemoveExercise
        // 
        this.btnRemoveExercise.StyleDanger();
        this.btnRemoveExercise.Location = new System.Drawing.Point(410, 520);
        this.btnRemoveExercise.Name = "btnRemoveExercise";
        this.btnRemoveExercise.Size = new System.Drawing.Size(140, 40);
        this.btnRemoveExercise.TabIndex = 8;
        this.btnRemoveExercise.Text = "Remove";
        this.btnRemoveExercise.UseVisualStyleBackColor = false;
        this.btnRemoveExercise.Visible = false;
        this.btnRemoveExercise.Click += new System.EventHandler(this.btnRemoveExercise_Click);
        
        // 
        // btnSave
        // 
        this.btnSave.StyleSuccess();
        this.btnSave.Location = new System.Drawing.Point(280, 575);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(110, 45);
        this.btnSave.TabIndex = 9;
        this.btnSave.Text = "Save";
        this.btnSave.UseVisualStyleBackColor = false;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        
        // 
        // btnCancel
        // 
        this.btnCancel.StyleSecondary();
        this.btnCancel.Location = new System.Drawing.Point(410, 575);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(110, 45);
        this.btnCancel.TabIndex = 10;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = false;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        
        // 
        // AddWorkoutForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 650);
        this.Controls.Add(this.panelMain);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "AddWorkoutForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Add Workout - Fitness Tracker";
        this.panelMain.ResumeLayout(false);
        this.panelMain.PerformLayout();
        this.ResumeLayout(false);
    }
}

