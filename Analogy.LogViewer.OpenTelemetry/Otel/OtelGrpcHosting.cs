#if NET
using Analogy.LogViewer.OpenTelemetry.Managers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Analogy.LogViewer.OpenTelemetry.Otel
{
    public static class OtelGrpcHosting
    {
        private static CancellationTokenSource _cts = new();
        private static IHost? _hoster;
        private static Task hostingTask;
        private static bool Connected { get; set; }

        public static void InitializeIfNeeded()
        {
            if (_hoster is null)
            {
                MetricsManager.Instance.InitializeIfNeeded();
                _hoster = CreateHostBuilder().Build();
                hostingTask = _hoster.StartAsync(_cts.Token);
                Connected = true;
            }
        }
        private static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, UserSettingsManager.UserSettings.Settings.SelfHostingServerPort,
                            listenOptions =>
                            {
                                listenOptions.Protocols = HttpProtocols.Http2;
                            });
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
#endif