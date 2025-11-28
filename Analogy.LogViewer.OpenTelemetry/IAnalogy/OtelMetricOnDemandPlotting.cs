using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Template.Managers;
using Microsoft.Extensions.Logging;
#if NET
using OpenTelemetry.Proto.Metrics.V1;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.OpenTelemetry.IAnalogy
{
    public class OtelMetricOnDemandPlotting(string source, string metricName, Guid id) : IAnalogyOnDemandPlotting
    {
        public string Source { get; } = source;
        public string MetricName { get; } = metricName;
        public Guid Id { get; } = id;
        public event EventHandler<(Guid Id, IEnumerable<AnalogyPlottingPointData> PointsData)> OnNewPointsData;
        private bool enable;
        private UserControl UI;
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
                    switch (e.Metric.DataCase)
                    {
                        case Metric.DataOneofCase.None:
                            break;
                        case Metric.DataOneofCase.Gauge:
                            var list = new List<AnalogyPlottingPointData>();

                            foreach (var val in e.Metric.Gauge.DataPoints)
                            {
                                if (val.HasAsDouble)
                                {
                                    var unixTimeMilliseconds = val.TimeUnixNano / 1_000_000;
                                    var time = DateTimeOffset.FromUnixTimeMilliseconds((long)unixTimeMilliseconds);
                                    AnalogyPlottingPointData d = new AnalogyPlottingPointData(MetricName, val.AsDouble, time);
                                    list.Add(d);
                                }
                            }

                            if (list.Any())
                            {
                                if (UI.InvokeRequired)
                                {
                                    UI.Invoke(new MethodInvoker(() =>
                                    {
                                        OnNewPointsData?.Invoke(this, (Id, list));
                                    }));
                                }
                                else
                                {
                                    OnNewPointsData?.Invoke(this, (Id, list));
                                }
                            }

                            break;
                        case Metric.DataOneofCase.Sum:
                            break;
                        case Metric.DataOneofCase.Histogram:
                            break;
                        case Metric.DataOneofCase.ExponentialHistogram:
                            break;
                        case Metric.DataOneofCase.Summary:
                            break;
                        default:
                            break;
                    }
                }
            };
#endif
            return Task.CompletedTask;
        }

        public void StartPlotting(UserControl ui)
        {
            UI = ui;
            enable = true;
        }

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