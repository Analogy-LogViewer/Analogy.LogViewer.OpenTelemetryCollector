using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.OpenTelemetry.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.OpenTelemetry.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            TaskCompletionSource<AnalogyLogMessage> taskReceived = new();

            Analogy.LogViewer.OpenTelemetry.Otel.OtelGrpcHosting.InitializeIfNeeded();
            Analogy.LogViewer.OpenTelemetry.Otel.MetricReporter.Instance.NewMetric += (s, e) =>
            {
                var key = Utils.GetServiceNameFromMetricResource(e.ResourceMetric);
                AnalogyLogMessage m = new AnalogyLogMessage
                {
                    Text = e.ToString(),
                    Level = AnalogyLogLevel.Information,
                    Class = AnalogyLogClass.General,
                    Source = e.Metric.Description,
                    User = Environment.UserName,
                    Module = key,
                    MachineName = Environment.MachineName,
                    ThreadId = Thread.CurrentThread.ManagedThreadId,
                };
                taskReceived.TrySetResult(m);
            };
            var metric = await taskReceived.Task;
            Assert.IsNotNull(metric);
        }
    }
}