﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace StreamJsonRpc
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Microsoft;

    [DebuggerDisplay("{DebuggerDisplay}")]
    internal struct MethodSignatureAndTarget : IEquatable<MethodSignatureAndTarget>
    {
        public MethodSignatureAndTarget(MethodInfo method, object target)
        {
            Requires.NotNull(method, nameof(method));

            this.Signature = new MethodSignature(method);
            this.Target = target;
        }

        public MethodSignature Signature { get; }

        public object Target { get; }

        [ExcludeFromCodeCoverage]
        private string DebuggerDisplay => $"{this.Signature} ({this.Target})";

        public override bool Equals(object obj)
        {
            MethodSignatureAndTarget other = (MethodSignatureAndTarget)obj;
            return this.Equals(other);
        }

        public bool Equals(MethodSignatureAndTarget other)
        {
            return this.Signature.Equals(other.Signature)
                && object.ReferenceEquals(this.Target, other.Target);
        }

        public override int GetHashCode()
        {
            return this.Signature.GetHashCode() + RuntimeHelpers.GetHashCode(this.Target);
        }
    }
}
