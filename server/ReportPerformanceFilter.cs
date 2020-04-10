using System.Text.Json;
using Hangfire.Common;
using Hangfire.Logging;
using Hangfire.States;
using Hangfire.Storage;

namespace server.Filters {
    public class ReportPerformanceFilter : JobFilterAttribute, IApplyStateFilter {
        readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction) {
            var succeededState = context.NewState as SucceededState;
            if (succeededState != null) {
                Logger.Info(JsonSerializer.Serialize(
                    new { Latency = succeededState.Latency, Duration = succeededState.PerformanceDuration, },
                    new JsonSerializerOptions() {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    }));
            }
        }
        public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction) { }
    }
}