// <copyright file="SignInManagerPasswordSignInUserIntegration.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using System;
using System.ComponentModel;
using Datadog.Trace.AppSec;
using Datadog.Trace.ClrProfiler.CallTarget;
using Datadog.Trace.Configuration;

#if !NETFRAMEWORK
namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.AspNetCore.UserEvents;

/// <summary>
/// SignInManagerIntegration
/// </summary>
[InstrumentMethod(
    AssemblyName = AssemblyName,
    TypeName = "Microsoft.AspNetCore.Identity.SignInManager`1",
    MethodName = "PasswordSignInAsync",
    ParameterTypeNames = new[] { "!0", ClrNames.String, ClrNames.Bool, ClrNames.Bool },
    ReturnTypeName = "System.Threading.Tasks.Task`1[Microsoft.AspNetCore.Identity.SignInResult]",
    MinimumVersion = "2",
    MaximumVersion = "7",
    IntegrationName = nameof(IntegrationId.AspNetCore),
    InstrumentationCategory = InstrumentationCategory.AppSec)]
[InstrumentMethod(
    AssemblyName = AssemblyName,
    TypeName = "Microsoft.AspNetCore.Identity.SignInManager`1",
    MethodName = "PasswordSignInAsync",
    ParameterTypeNames = new[] { ClrNames.String, ClrNames.String, ClrNames.Bool, ClrNames.Bool },
    ReturnTypeName = "System.Threading.Tasks.Task`1[Microsoft.AspNetCore.Identity.SignInResult]",
    MinimumVersion = "2",
    MaximumVersion = "7",
    IntegrationName = nameof(IntegrationId.AspNetCore),
    CallTargetIntegrationType = IntegrationType.Derived,
    InstrumentationCategory = InstrumentationCategory.AppSec)]
[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public static class SignInManagerPasswordSignInUserIntegration
{
    private const string AssemblyName = "Microsoft.AspNetCore.Identity";

    internal static CallTargetState OnMethodBegin<TTarget, TUser>(TTarget instance, TUser? user, string password, bool isPersistent, bool lockoutOnFailure)
        where TUser : IIdentityUser
    {
        var security = Security.Instance;
        // todo milestone 2 deal with extended mode of UserEventsAutomatedTracking
        if (security.TrackUserEvents)
        {
            var tracer = Tracer.Instance;
            var scope = tracer.InternalActiveScope;
            var targetState = new UserState { UserId = user?.Id.ToString(), Exists = user != null };
            return new CallTargetState(scope, targetState);
        }

        return CallTargetState.GetDefault();
    }

    internal static TReturn OnAsyncMethodEnd<TTarget, TReturn>(TTarget instance, TReturn returnValue, Exception exception, in CallTargetState state)
        where TReturn : ISignInResult
    {
        var security = Security.Instance;
        if (security.TrackUserEvents)
        {
            // if we come here, it's that the user has been found in database
            SignInHelper.FillSpanWithUserEvent(security, state, returnValue);
        }

        return returnValue;
    }
}
#endif
