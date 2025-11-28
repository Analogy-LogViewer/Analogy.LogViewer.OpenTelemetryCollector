#if NET
using Analogy.LogViewer.OpenTelemetry.Otel;
using Analogy.LogViewer.OpenTelemetry.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analogy.LogViewer.OpenTelemetry.Managers
{
    internal class MetricsManager
    {
        private static Lazy<MetricsManager> _instance = new Lazy<MetricsManager>(() => new MetricsManager());

        public static MetricsManager Instance { get; } = _instance.Value;
        public Dictionary<string, MetricRecords> Metrics = new Dictionary<string, MetricRecords>();
        private bool Initialized { get; set; }

        public void InitializeIfNeeded()
        {
            if (Initialized)
            {
                return;
            }

            Initialized = true;
#if NET
            MetricReporter.Instance.NewMetric += (s, e) =>
            {
                var key = Utils.GetServiceNameFromMetricResource(e.ResourceMetric);
                if (Metrics.TryGetValue(key, out var record))
                {
                    record.AddMetric(e);
                }
                else
                {
                    Metrics[key] = new MetricRecords(key, e);
                }
            };
#endif
        }
    }
}
#endif