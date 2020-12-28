﻿using Kalendra.Commons.Runtime.Domain.Gateways;
using Kalendra.Commons.Tests.TestDataBuilders.Domain.BoardSystem;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Fake
    {
        public static IReadOnlyRepository<T> ReadOnlyRepository<T>() where T : new() => ReadOnlyRepositoryMockBuilder<T>.New().ReturnsDefaults();
    }
}