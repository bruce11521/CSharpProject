namespace MyStudio
{
    partial class TEST
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radTextBoxControl_Name = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radTextBox_Result = new Telerik.WinControls.UI.RadTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox_Result)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.25641F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.74359F));
            this.tableLayoutPanel1.Controls.Add(this.radTextBoxControl_Name, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radButton1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.radTextBox_Result, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.44954F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.55046F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 436);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Location = new System.Drawing.Point(394, 392);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(135, 41);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "合成";
            // 
            // radTextBoxControl_Name
            // 
            this.radTextBoxControl_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTextBoxControl_Name.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTextBoxControl_Name.Location = new System.Drawing.Point(394, 3);
            this.radTextBoxControl_Name.Name = "radTextBoxControl_Name";
            this.radTextBoxControl_Name.Size = new System.Drawing.Size(383, 383);
            this.radTextBoxControl_Name.TabIndex = 2;
            // 
            // radTextBox_Result
            // 
            this.radTextBox_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTextBox_Result.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTextBox_Result.Location = new System.Drawing.Point(3, 3);
            this.radTextBox_Result.Name = "radTextBox_Result";
            this.radTextBox_Result.Size = new System.Drawing.Size(385, 27);
            this.radTextBox_Result.TabIndex = 3;
            // 
            // TEST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 436);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TEST";
            this.Text = "TEST";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox_Result)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadTextBoxControl radTextBoxControl_Name;
        private Telerik.WinControls.UI.RadTextBox radTextBox_Result;
    }
}