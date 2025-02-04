﻿using Xeyth.Result.Reasons.Abstract;

namespace Xeyth.Result.Extensions.Reasons;

public static class ReasonExtensions
{
    /// <summary>Checks if the <see cref="IReason"/> contains metadata with the specified key.</summary>
    /// <param name="reason">The <see cref="IReason"/> to check.</param>
    /// <param name="key">The metadata key to search for.</param>
    /// <returns><see langword="true"/> if the key exists; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null or empty.</exception>
    public static bool HasMetadataKey(this IReason reason, string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        return reason.Metadata.ContainsKey(key);
    }

    /// <summary>Checks if the <see cref="IReason"/> contains metadata with the specified key that satisfies the given predicate.</summary>
    /// <param name="reason">The <see cref="IReason"/> to check.</param>
    /// <param name="key">The metadata key to search for.</param>
    /// <param name="predicate">The predicate to apply to the metadata value.</param>
    /// <returns><see langword="true"/> if the key exists and the predicate evaluates to <see langword="true"/>; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> or <paramref name="predicate"/> is null.</exception>
    public static bool HasMetadata(this IReason reason, string key, Func<object, bool> predicate)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        ArgumentNullException.ThrowIfNull(predicate);
        return reason.Metadata.TryGetValue(key, out object? actualValue) && predicate(actualValue);
    }
}
