using LanguageFileTranslatorApp.Infra.Funcky.ResultErrors;

namespace LanguageFileTranslatorApp.Infra.Funcky.ResultClass;
// Copyright (c) 2015 Vladimir Khorikov
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
//     use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:

public class Result
{
    public const string? DefaultNoValueExceptionMessage = "DefaultNoValueExceptionMessage";

    protected Result(bool isSuccess, BaseResultError? error = null)
    {
        switch (isSuccess)
        {
            case true when error != null:
                throw new InvalidOperationException();
            case false when error is null:
                throw new InvalidOperationException();
            default:
                IsSuccess = isSuccess;
                Error = error;
                break;
        }
    }

    public bool IsSuccess { get; }
    public BaseResultError? Error { get; }
    public bool IsFailure => !IsSuccess;

    public static Result Fail(BaseResultError resultError)
    {
        return new Result(false, resultError);
    }

    public static Result<T> Fail<T>(BaseResultError? resultError)
    {
        return new Result<T>(default!, false, resultError);
    }

    public static Result Ok()
    {
        return new Result(true);
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value, true, null);
    }

    public static Result Combine(params Result[] results)
    {
        foreach (var result in results)
            if (result.IsFailure)
                return result;

        return Ok();
    }
}

public class Result<T> : Result
{
    private readonly T _value;

    protected internal Result(T value, bool isSuccess, BaseResultError? error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    public T Value => IsSuccess ? _value : throw new InvalidOperationException();
}