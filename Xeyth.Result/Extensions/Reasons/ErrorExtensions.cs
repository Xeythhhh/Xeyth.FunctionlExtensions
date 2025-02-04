﻿using Xeyth.Result.Reasons.Abstract;

namespace Xeyth.Result.Extensions.Reasons;

public static class ErrorExtensions
{
    /// <summary>Casts an <see cref="IError"/> to the specified error type <typeparamref name="TError"/>.</summary>
    /// <typeparam name="TError">The type to which the error should be cast.</typeparam>
    /// <param name="error">The error to cast.</param>
    /// <returns>The error cast to the specified type <typeparamref name="TError"/>.</returns>
    /// <exception cref="InvalidCastException">Thrown if the error cannot be cast to the specified type <typeparamref name="TError"/>.</exception>
    public static TError CastError<TError>(this IError error)
        where TError : IError
    {
        if (error is TError castedError)
            return castedError;

        throw new InvalidCastException($"Error type '{error.GetType().Name}' is not compatible with expected type '{typeof(TError).Name}'.");
    }
}