#if NET
using OpenTelemetry.Proto.Metrics.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analogy.LogViewer.OpenTelemetryCollector.Types
{
    internal class MetricRecords
    {
        public string Key { get; }
        private List<Metric> Records { get; } = [];
        private List<string> RecordsName { get; } = [];
        public MetricRecords(string key, (ResourceMetrics ResourceMetric, ScopeMetrics ScopeMetric, Metric Metric) valueTuple)
        {
            Key = key;
        }

        public void AddMetric((ResourceMetrics ResourceMetric, ScopeMetrics ScopeMetric, Metric Metric) e)
        {
            Records.Add(e.Metric);
            if (!RecordsName.Contains(e.Metric.Name))
            {
                RecordsName.Add(e.Metric.Name);
            }
        }
        public List<string> GetMetricsTypes() => RecordsName.ToList();
    }
}
#endif