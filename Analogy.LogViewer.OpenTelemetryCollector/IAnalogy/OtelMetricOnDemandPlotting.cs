using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Template.Managers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.OpenTelemetryCollector.IAnalogy
{
    public class OtelMetricOnDemandPlotting(string source, string metricName, Guid id) : IAnalogyOnDemandPlotting
    {
        public string Source { get; } = source;
        public string MetricName { get; } = metricName;
        public Guid Id { get; } = id;
        public event EventHandler<(Guid Id, IEnumerable<AnalogyPlottingPointData> PointsData)> OnNewPointsData;
        private bool enable;
        private IAnalogyOnDemandPlottingInteractor Interactor { get; set; }
        public Task InitializeOnDemandPlotting(IAnalogyOnDemandPlottingInteractor onDemandPlottingInteractor, ILogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            Interactor = onDemandPlottingInteractor;
#if NET            
            Otel.MetricReporter.Instance.NewMetric += (s, e) =>
            {
                if (!enable)
                {
                    return;
                }
                var key = Types.Utils.GetServiceNameFromMetricResource(e.ResourceMetric);
                if (source.Equals(key) && e.Metric.Name.Equals(MetricName))
                {
                    var now = DateTimeOffset.Now;
                    switch (e.Metric.DataCase)
                    {
                        case OpenTelemetry.Proto.Metrics.V1.Metric.DataOneofCase.None:
                            break;
                        case OpenTelemetry.Proto.Metrics.V1.Metric.DataOneofCase.Gauge:
                            var list = new List<AnalogyPlottingPointData>();

                            foreach (var val in e.Metric.Gauge.DataPoints)
                            {
                                if (val.HasAsDouble)
                                {
                                    AnalogyPlottingPointData d = new AnalogyPlottingPointData(MetricName, val.AsDouble, now);
                                    list.Add(d);
                                }
                            }

                            if (list.Any())
                            {
                                OnNewPointsData?.Invoke(this, (Id, list));
                            }

                            break;
                        case OpenTelemetry.Proto.Metrics.V1.Metric.DataOneofCase.Sum:
                            break;
                        case OpenTelemetry.Proto.Metrics.V1.Metric.DataOneofCase.Histogram:
                            break;
                        case OpenTelemetry.Proto.Metrics.V1.Metric.DataOneofCase.ExponentialHistogram:
                            break;
                        case OpenTelemetry.Proto.Metrics.V1.Metric.DataOneofCase.Summary:
                            break;
                        default:
                            break;
                    }
                }
            };
#endif
            return Task.CompletedTask;
        }
        private double GenerateValue(double x) { return Math.Sin(x / 1000.0) * 3 * x + x / 2 + 5; }

        public void StartPlotting() => enable = true;

        public void StopPlotting() => enable = false;

        public void ShowPlot()
        {
            Interactor.ShowPlot(Id, MetricName, AnalogyOnDemandPlottingStartupType.TabbedWindow);
        }

        public void ClosePlot()
        {
            Interactor.ClosePlot(Id);
        }

        public void RemoveSeriesFromPlot(string seriesName)
        {
            Interactor.RemoveSeriesFromPlot(Id, seriesName);
        }

        public void ClearSeriesData(string seriesNameToClear)
        {
            Interactor.ClearSeriesData(Id, seriesNameToClear);
        }

        public void ClearAllData()
        {
            Interactor.ClearAllData(Id);
        }

        public void HidePlot()
        {
            Interactor.ClosePlot(Id);
        }
    }
}