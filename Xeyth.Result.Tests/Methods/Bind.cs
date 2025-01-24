﻿using Shouldly;

namespace Xeyth.Result.Tests.Methods;

public class Bind
{
    public class ShouldBind
    {
        private const string Confirmation = "Bound to new result";

        [Fact]
        public void WhenInitialResultIsSuccessful_AndBindingResultIsSuccessful() => Verify(Result.Ok()
            .Bind(() => Result.Ok().WithSuccess(Confirmation)));

        [Fact]
        public void WhenInitialResultIsSuccessful_AndBindingResultIsFailure() => Verify(Result.Ok()
            .Bind(() => Result.Fail(Confirmation)));

        [Fact]
        public void WhenInitialResultIsSuccessful_AndGenericBindingResultIsSuccessful() => Verify(Result.Ok()
            .Bind(() => Result.Ok(420).WithSuccess(Confirmation)));

        [Fact]
        public void WhenInitialResultIsSuccessful_AndGenericBindingResultIsFailure() => Verify(Result.Ok()
            .Bind(() => Result.Fail<int>(Confirmation)));
    }

    public class ShouldNotBind
    {
        private const string Warning = "Should not bind!";
        private const string Error = "Initial Result Error";

        [Fact]
        public void WhenInitialResultIsFailure_AndBindingResultIsSuccessful() => Verify(Result.Fail(Error)
            .Bind(() => Result.Ok().WithSuccess(Warning)));

        [Fact]
        public void WhenInitialResultIsFailure_AndBindingResultIsFailure() => Verify(Result.Fail(Error)
            .Bind(() => Result.Fail(Warning)));

        [Fact]
        public void WhenInitialResultIsFailure_AndGenericBindingResultIsSuccessful() => Verify(Result.Fail(Error)
            .Bind(() => Result.Ok(420).WithSuccess(Warning)));

        [Fact]
        public void WhenInitialResultIsFailure_AndGenericBindingResultIsFailure() => Verify(Result.Fail(Error)
            .Bind(() => Result.Fail<int>(Warning)));
    }

    [Fact]
    public void ShouldThrowArgumentNullException_WhenBindActionIsNull() => Should.Throw<ArgumentNullException>(() =>
        Result.Ok().Bind((Func<Result>)null!));

    [Fact]
    public void ShouldThrowArgumentNullException_WhenGenericBindActionIsNull() => Should.Throw<ArgumentNullException>(() =>
        Result.Ok().Bind((Func<Result<object>>)null!));
}
