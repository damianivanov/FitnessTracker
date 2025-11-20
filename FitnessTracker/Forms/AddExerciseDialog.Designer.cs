using System.Windows.Forms;
using FitnessTracker.UI;

namespace FitnessTracker.Forms;

partial class AddExerciseDialog
{
    private System.ComponentModel.IContainer components = null;
    private Panel panelMain;
    private Label lblTitle;
    private Label lblExercise;
    private ComboBox cmbExercise;
    private Label lblReps;
    private NumericUpDown nudReps;
    private Label lblWeight;
    private NumericUpDown nudWeight;
    private Button btnAdd;
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
        this.lblExercise = new Label();
        this.cmbExercise = new ComboBox();
        this.lblReps = new Label();
        this.nudReps = new NumericUpDown();
        this.lblWeight = new Label();
        this.nudWeight = new NumericUpDown();
        this.btnAdd = new Button();
        this.btnCancel = new Button();
        this.panelMain.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudReps)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
        this.SuspendLayout();
        
        // 
        // panelMain
        // 
        this.panelMain.BackColor = UiConstants.Colors.BackgroundDark;
        this.panelMain.Controls.Add(this.lblTitle);
        this.panelMain.Controls.Add(this.lblExercise);
        this.panelMain.Controls.Add(this.cmbExercise);
        this.panelMain.Controls.Add(this.lblReps);
        this.panelMain.Controls.Add(this.nudReps);
        this.panelMain.Controls.Add(this.lblWeight);
        this.panelMain.Controls.Add(this.nudWeight);
        this.panelMain.Controls.Add(this.btnAdd);
        this.panelMain.Controls.Add(this.btnCancel);
        this.panelMain.Dock = DockStyle.Fill;
        this.panelMain.Location = new System.Drawing.Point(0, 0);
        this.panelMain.Name = "panelMain";
        this.panelMain.Padding = new Padding(30);
        this.panelMain.Size = new System.Drawing.Size(500, 400);
        this.panelMain.TabIndex = 0;
        
        // 
        // lblTitle
        // 
        this.lblTitle.Font = new System.Drawing.Font("Segue UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = UiConstants.Colors.TextPrimary;
        this.lblTitle.Location = new System.Drawing.Point(0, 30);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(500, 30);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Add Exercise";
        this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        
        // 
        // lblExercise
        // 
        this.lblExercise.StyleLabel();
        this.lblExercise.AutoSize = true;
        this.lblExercise.Location = new System.Drawing.Point(30, 85);
        this.lblExercise.Name = "lblExercise";
        this.lblExercise.Size = new System.Drawing.Size(70, 21);
        this.lblExercise.TabIndex = 1;
        this.lblExercise.Text = "Exercise:";
        
        // 
        // cmbExercise
        // 
        this.cmbExercise.BackColor = UiConstants.Colors.BackgroundMedium;
        this.cmbExercise.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbExercise.FlatStyle = FlatStyle.Flat;
        this.cmbExercise.Font = new System.Drawing.Font("Segue UI", 11F);
        this.cmbExercise.ForeColor = UiConstants.Colors.TextPrimary;
        this.cmbExercise.FormattingEnabled = true;
        this.cmbExercise.Location = new System.Drawing.Point(30, 115);
        this.cmbExercise.Name = "cmbExercise";
        this.cmbExercise.Size = new System.Drawing.Size(440, 28);
        this.cmbExercise.TabIndex = 2;
        
        // 
        // lblReps
        // 
        this.lblReps.StyleLabel();
        this.lblReps.AutoSize = true;
        this.lblReps.Location = new System.Drawing.Point(30, 170);
        this.lblReps.Name = "lblReps";
        this.lblReps.Size = new System.Drawing.Size(47, 21);
        this.lblReps.TabIndex = 3;
        this.lblReps.Text = "Reps:";
        
        // 
        // nudReps
        // 
        this.nudReps.BackColor = UiConstants.Colors.BackgroundMedium;
        this.nudReps.BorderStyle = BorderStyle.FixedSingle;
        this.nudReps.Font = new System.Drawing.Font("Segue UI", 12F);
        this.nudReps.ForeColor = UiConstants.Colors.TextPrimary;
        this.nudReps.Location = new System.Drawing.Point(30, 200);
        this.nudReps.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
        this.nudReps.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        this.nudReps.Name = "nudReps";
        this.nudReps.Size = new System.Drawing.Size(200, 40);
        this.nudReps.TabIndex = 4;
        this.nudReps.Value = new decimal(new int[] { 10, 0, 0, 0 });
        this.nudReps.TextAlign = HorizontalAlignment.Center;
        
        // 
        // lblWeight
        // 
        this.lblWeight.StyleLabel();
        this.lblWeight.AutoSize = true;
        this.lblWeight.Location = new System.Drawing.Point(270, 170);
        this.lblWeight.Name = "lblWeight";
        this.lblWeight.Size = new System.Drawing.Size(96, 21);
        this.lblWeight.TabIndex = 5;
        this.lblWeight.Text = "Weight (kg):";
        
        // 
        // nudWeight
        // 
        this.nudWeight.BackColor = UiConstants.Colors.BackgroundMedium;
        this.nudWeight.BorderStyle = BorderStyle.FixedSingle;
        this.nudWeight.DecimalPlaces = 1;
        this.nudWeight.Font = new System.Drawing.Font("Segue UI", 12F);
        this.nudWeight.ForeColor = UiConstants.Colors.TextPrimary;
        this.nudWeight.Increment = new decimal(new int[] { 25, 0, 0, 65536 });
        this.nudWeight.Location = new System.Drawing.Point(270, 200);
        this.nudWeight.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
        this.nudWeight.Name = "nudWeight";
        this.nudWeight.Size = new System.Drawing.Size(200, 40);
        this.nudWeight.TabIndex = 6;
        this.nudWeight.Value = new decimal(new int[] { 20, 0, 0, 0 });
        this.nudWeight.TextAlign = HorizontalAlignment.Center;
        
        // 
        // btnAdd
        // 
        this.btnAdd.StylePrimary();
        this.btnAdd.Location = new System.Drawing.Point(270, 310);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(100, 45);
        this.btnAdd.TabIndex = 7;
        this.btnAdd.Text = "Add";
        this.btnAdd.UseVisualStyleBackColor = false;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
        
        // 
        // btnCancel
        // 
        this.btnCancel.StyleSecondary();
        this.btnCancel.Location = new System.Drawing.Point(380, 310);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(90, 45);
        this.btnCancel.TabIndex = 8;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = false;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        
        // 
        // AddExerciseDialog
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(500, 400);
        this.Controls.Add(this.panelMain);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "AddExerciseDialog";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Add Exercise";
        this.panelMain.ResumeLayout(false);
        this.panelMain.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudReps)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
        this.ResumeLayout(false);
    }
}

