// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading;
using Microsoft.Framework.Primitives;

namespace Microsoft.Framework.Configuration
{
    public class ConfigurationReloadToken : IChangeToken
    {
        CancellationTokenSource _cts = new CancellationTokenSource();

        public bool ActiveChangeCallbacks => true;

        public bool HasChanged => _cts.IsCancellationRequested;

        public IDisposable RegisterChangeCallback(Action<object> callback, object state) => _cts.Token.Register(callback, state);

        public void OnReload() => _cts.Cancel();
    }
}
