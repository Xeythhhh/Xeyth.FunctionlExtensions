﻿using Xeyth.Result.Base;
using Xeyth.Result.Reasons;
using Xeyth.Result.Reasons.Abstract;

namespace Xeyth.Result;

/// <summary>Represents a non-generic result indicating success or failure.</summary>
public partial class Result : ResultBase<Result>
{
    static Result() { }

    /// <summary>Implicitly converts an <see cref="Error"/> into a failed <see cref="Result"/>.</summary>
    public static implicit operator Result(Error error) => Fail(error);

    /// <summary>Implicitly converts a list of <see cref="IError"/> into a failed <see cref="Result"/>.</summary>
    public static implicit operator Result(List<IError> errors) => Fail(errors);
}
