using JetBrains.Annotations;
using System;

namespace CloudeDev.Architecture
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class InjectAttribute : Attribute { }

    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class Service : Attribute { }

    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class Listener : Attribute { }
}
