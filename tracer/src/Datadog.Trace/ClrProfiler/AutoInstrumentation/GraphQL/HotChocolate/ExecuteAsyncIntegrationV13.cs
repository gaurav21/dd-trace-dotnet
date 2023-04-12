// <copyright file="ExecuteAsyncIntegrationV13.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Datadog.Trace.ClrProfiler.AutoInstrumentation.GraphQL.HotChocolate.ASM;
using Datadog.Trace.ClrProfiler.CallTarget;
using Datadog.Trace.DuckTyping;

namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.GraphQL.HotChocolate
{
    /// <summary>
    /// HotChocolate.Execution.RequestExecutor calltarget instrumentation
    /// </summary>
    [InstrumentMethodAttribute(
        IntegrationName = HotChocolateCommon.IntegrationName,
        MethodName = "ExecuteAsync",
        ReturnTypeName = "System.Threading.Tasks.Task`1<HotChocolate.Execution.IExecutionResult>",
        ParameterTypeNames = new string[] { "HotChocolate.Execution.IQueryRequest", ClrNames.CancellationToken },
        AssemblyName = "HotChocolate.Execution",
        TypeName = "HotChocolate.Execution.RequestExecutor",
        MinimumVersion = "13",
        MaximumVersion = "13.*.*")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ExecuteAsyncIntegrationV13
    {
        /// <summary>
        /// OnMethodBegin callback
        /// </summary>
        /// <typeparam name="TTarget">Type of the target</typeparam>
        /// <typeparam name="TQueyRequest">Type of the queryRequest</typeparam>
        /// <param name="instance">Instance value, aka `this` of the instrumented method.</param>
        /// <param name="request">QueryRequest</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Calltarget state value</returns>
        internal static CallTargetState OnMethodBegin<TTarget, TQueyRequest>(TTarget instance, TQueyRequest request, in CancellationToken token)
            where TQueyRequest : IQueryRequest
        {
            // ASM
            HotChocolateSecurity.ScanQuery(request.Query);

            return new CallTargetState(scope: HotChocolateCommon.CreateScopeFromExecuteAsync(Tracer.Instance, request));
        }

        /// <summary>
        /// OnAsyncMethodEnd callback
        /// </summary>
        /// <typeparam name="TTarget">Type of the target</typeparam>
        /// <typeparam name="TExecutionResult">Type of the execution result value</typeparam>
        /// <param name="instance">Instance value, aka `this` of the instrumented method.</param>
        /// <param name="executionResult">ExecutionResult instance</param>
        /// <param name="exception">Exception instance in case the original code threw an exception.</param>
        /// <param name="state">Calltarget state value</param>
        internal static TExecutionResult OnAsyncMethodEnd<TTarget, TExecutionResult>(TTarget instance, TExecutionResult executionResult, Exception exception, in CallTargetState state)
        {
            Scope scope = state.Scope;
            if (scope is null)
            {
                return executionResult;
            }

            try
            {
                if (exception != null)
                {
                    scope.Span?.SetException(exception);
                }
                else if (executionResult.TryDuckCast<IQueryResult>(out var result))
                {
                    if (result.Errors != null)
                    {
                        HotChocolateCommon.RecordExecutionErrorsIfPresent(scope.Span, HotChocolateCommon.ErrorType, result.Errors);
                    }
                }
            }
            finally
            {
                scope.Dispose();
            }

            return executionResult;
        }
    }
}
