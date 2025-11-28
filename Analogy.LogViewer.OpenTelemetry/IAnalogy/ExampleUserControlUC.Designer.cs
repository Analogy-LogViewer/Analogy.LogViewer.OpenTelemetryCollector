
namespace Analogy.LogViewer.OpenTelemetry.IAnalogy
{
    partial class ExampleUserControlUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMetric = new System.Windows.Forms.Label();
            btnGenerator = new System.Windows.Forms.Button();
            btnGeneratorHide = new System.Windows.Forms.Button();
            btnGneratorShow = new System.Windows.Forms.Button();
            btnStopPlotting = new System.Windows.Forms.Button();
            btnShowPlot = new System.Windows.Forms.Button();
            treeViewMetrics = new System.Windows.Forms.TreeView();
            BtnRefresh = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblMetric
            // 
            lblMetric.Dock = System.Windows.Forms.DockStyle.Top;
            lblMetric.Location = new System.Drawing.Point(0, 0);
            lblMetric.Name = "lblMetric";
            lblMetric.Size = new System.Drawing.Size(501, 20);
            lblMetric.TabIndex = 0;
            lblMetric.Text = "Select Metric:";
            // 
            // btnGenerator
            // 
            btnGenerator.Enabled = false;
            btnGenerator.Location = new System.Drawing.Point(530, 20);
            btnGenerator.Name = "btnGenerator";
            btnGenerator.Size = new System.Drawing.Size(131, 29);
            btnGenerator.TabIndex = 8;
            btnGenerator.Text = "Create Plot";
            btnGenerator.UseVisualStyleBackColor = true;
            btnGenerator.Click += btnGenerator_Click;
            // 
            // btnGeneratorHide
            // 
            btnGeneratorHide.Location = new System.Drawing.Point(530, 90);
            btnGeneratorHide.Name = "btnGeneratorHide";
            btnGeneratorHide.Size = new System.Drawing.Size(131, 29);
            btnGeneratorHide.TabIndex = 7;
            btnGeneratorHide.Text = "Hide plot";
            btnGeneratorHide.UseVisualStyleBackColor = true;
            btnGeneratorHide.Click += btnGeneratorHide_Click;
            // 
            // btnGneratorShow
            // 
            btnGneratorShow.Location = new System.Drawing.Point(530, 158);
            btnGneratorShow.Name = "btnGneratorShow";
            btnGneratorShow.Size = new System.Drawing.Size(131, 29);
            btnGneratorShow.TabIndex = 6;
            btnGneratorShow.Text = "start plotting";
            btnGneratorShow.UseVisualStyleBackColor = true;
            btnGneratorShow.Click += btnGneratorShow_Click;
            // 
            // btnStopPlotting
            // 
            btnStopPlotting.Location = new System.Drawing.Point(530, 193);
            btnStopPlotting.Name = "btnStopPlotting";
            btnStopPlotting.Size = new System.Drawing.Size(131, 29);
            btnStopPlotting.TabIndex = 9;
            btnStopPlotting.Text = "stop plotting";
            btnStopPlotting.UseVisualStyleBackColor = true;
            btnStopPlotting.Click += btnStopPlotting_Click;
            // 
            // btnShowPlot
            // 
            btnShowPlot.Location = new System.Drawing.Point(530, 55);
            btnShowPlot.Name = "btnShowPlot";
            btnShowPlot.Size = new System.Drawing.Size(131, 29);
            btnShowPlot.TabIndex = 10;
            btnShowPlot.Text = "Show Plot";
            btnShowPlot.UseVisualStyleBackColor = true;
            btnShowPlot.Click += btnShowPlot_Click;
            // 
            // treeViewMetrics
            // 
            treeViewMetrics.Dock = System.Windows.Forms.DockStyle.Fill;
            treeViewMetrics.Location = new System.Drawing.Point(0, 20);
            treeViewMetrics.Name = "treeViewMetrics";
            treeViewMetrics.Size = new System.Drawing.Size(501, 340);
            treeViewMetrics.TabIndex = 11;
            treeViewMetrics.AfterSelect += treeViewMetrics_AfterSelect;
            // 
            // BtnRefresh
            // 
            BtnRefresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            BtnRefresh.Location = new System.Drawing.Point(0, 360);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new System.Drawing.Size(501, 29);
            BtnRefresh.TabIndex = 12;
            BtnRefresh.Text = "Refresh List";
            BtnRefresh.UseVisualStyleBackColor = true;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(treeViewMetrics);
            panel1.Controls.Add(BtnRefresh);
            panel1.Controls.Add(lblMetric);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(501, 389);
            panel1.TabIndex = 13;
            // 
            // ExampleUserControlUC
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(btnShowPlot);
            Controls.Add(btnStopPlotting);
            Controls.Add(btnGenerator);
            Controls.Add(btnGeneratorHide);
            Controls.Add(btnGneratorShow);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "ExampleUserControlUC";
            Size = new System.Drawing.Size(940, 389);
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMetric;
        private System.Windows.Forms.Button btnGenerator;
        private System.Windows.Forms.Button btnGeneratorHide;
        private System.Windows.Forms.Button btnGneratorShow;
        private System.Windows.Forms.Button btnStopPlotting;
        private System.Windows.Forms.Button btnShowPlot;
        private System.Windows.Forms.TreeView treeViewMetrics;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Panel panel1;
    }
}
