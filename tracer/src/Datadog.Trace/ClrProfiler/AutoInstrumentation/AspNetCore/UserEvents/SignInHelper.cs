// <copyright file="SignInHelper.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using Datadog.Trace.AppSec;
using Datadog.Trace.ClrProfiler.CallTarget;

namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.AspNetCore.UserEvents;

internal static class SignInHelper
{
    internal static void FillSpanWithUserEvent(Security security, CallTargetState state, ISignInResult returnValue)
    {
        var span = state.Scope.Span;
        var setTag = TaggingUtils.GetSpanSetter(span, out _);
        var tryAddTag = TaggingUtils.GetSpanSetter(span, out _, replaceIfExists: false);

        if (returnValue.Succeeded)
        {
            setTag(Tags.AppSec.EventsUsers.LoginEvent.SuccessTrack, "true");
            setTag(Tags.AppSec.EventsUsers.LoginEvent.SuccessAutoMode, security.Settings.UserEventsAutomatedTracking);
            if (state.State is UserState userState)
            {
                if (userState.IsUserIdGuid())
                {
                    tryAddTag(Tags.User.Id, userState.UserId);
                }
            }
        }
        else
        {
            setTag(Tags.AppSec.EventsUsers.LoginEvent.FailureTrack, "true");
            setTag(Tags.AppSec.EventsUsers.LoginEvent.FailureAutoMode, security.Settings.UserEventsAutomatedTracking);
            if (state.State is UserState userState)
            {
                tryAddTag(Tags.AppSec.EventsUsers.LoginEvent.FailureUserExists, userState.Exists ? "true" : "false");
                if (userState.IsUserIdGuid())
                {
                    tryAddTag(Tags.AppSec.EventsUsers.LoginEvent.FailureUserId, userState.UserId);
                }
            }
        }

        security.SetTraceSamplingPriority(span);
    }
}
