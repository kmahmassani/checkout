﻿namespace PaymentGateway.API.Extensions
{
    public static class StringExtension
{
    public static string Right(this string source, int tail_length)
    {
       if(tail_length >= source.Length)
          return source;
       return source.Substring(source.Length - tail_length);
    }
}
}
