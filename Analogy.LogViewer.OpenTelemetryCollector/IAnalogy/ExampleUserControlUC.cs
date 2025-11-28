using Analogy.LogViewer.OpenTelemetryCollector.Managers;
using Analogy.LogViewer.OpenTelemetryCollector.Types;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Analogy.LogViewer.OpenTelemetryCollector.IAnalogy
{
    public partial class ExampleUserControlUC : UserControl
    {
        private OtelMetricOnDemandPlotting p;

        public ExampleUserControlUC()
        {
            InitializeComponent();
        }

        private void btnGenerator_Click(object sender, EventArgs e)
        {
            //p = new OtelMetricOnDemandPlotting();
            //OnDemandPlottingContainer.Instance.AddOnDemandPlotting(p);
        }

        private void btnGneratorShow_Click(object sender, EventArgs e)
        {
            p.StartPlotting();
        }

        private void btnGeneratorHide_Click(object sender, EventArgs e)
        {
            p.HidePlot();
        }

        private void btnStopPlotting_Click(object sender, EventArgs e)
        {
            p.StopPlotting();
        }

        private void btnShowPlot_Click(object sender, EventArgs e)
        {
            p.ShowPlot();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            treeViewMetrics.Nodes.Clear();
#if NET
            foreach (KeyValuePair<string, Types.MetricRecords> metric in MetricsManager.Instance.Metrics)
            {
                var root = new TreeNode(metric.Key) { Tag = metric };
                treeViewMetrics.Nodes.Add(root);
                foreach (string name in metric.Value.GetMetricsTypes())
                {
                    root.Nodes.Add(new TreeNode(name)
                    {
                        Tag = metric.Value,
                    });
                }
            }
#endif
        }

        private void treeViewMetrics_AfterSelect(object sender, TreeViewEventArgs e)
        {
#if NET
            if (e.Node?.Tag is MetricRecords metric)
            {
                p = new OtelMetricOnDemandPlotting(metric.Key, e.Node.Text, Guid.NewGuid());
                OnDemandPlottingContainer.Instance.AddOnDemandPlotting(p);
            }
#endif
        }
    }
}