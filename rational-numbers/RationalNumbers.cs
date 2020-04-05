using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) =>
        r.Expreal(realNumber);
}

public struct RationalNumber
{
    private int numerator;
    private int denominator;
    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentOutOfRangeException("denominator cannot be zero");
        if (denominator < 1) {
            numerator *= -1;
            denominator *= -1;
        }
        this.numerator = numerator;
        this.denominator = denominator;
    }
    
    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            r1.numerator * r2.denominator + r2.numerator * r1.denominator,
            r1.denominator * r2.denominator)
            .Reduce();

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            r1.numerator * r2.denominator - r2.numerator * r1.denominator,
            r1.denominator * r2.denominator)
            .Reduce();

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            r1.numerator * r2.numerator,
            r1.denominator * r2.denominator)
            .Reduce();

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            r1.numerator * r2.denominator,
            r2.numerator * r1.denominator)
            .Reduce();

    public RationalNumber Abs() =>
        new RationalNumber(
            Math.Abs(numerator),
            Math.Abs(denominator))
            .Reduce();

    public RationalNumber Reduce()
    {
        int factor = GreatesCommonFactor();
        if (numerator == 0) denominator = 1;
        numerator /= factor;
        denominator /= factor;
        return new RationalNumber(numerator, denominator);
    }

    private readonly int GreatesCommonFactor()
    {
        var numeratorFactors = Factors(numerator);
        var denominatorFactors = Factors(denominator);

        var greatestFactor = numeratorFactors
            .FirstOrDefault(x => denominatorFactors.Contains(x));

        return (greatestFactor == 0) ? 1 : greatestFactor;
    }

    private readonly List<int> Factors(int number) {
        int n = Math.Abs(number);
        return Enumerable.Range(2, n).Where(x => n % x == 0).ToList();
    }

    public RationalNumber Exprational(int power) =>
        new RationalNumber(
            (int)Math.Pow((double)numerator, Math.Abs(power)),
            (int)Math.Pow((double)denominator, Math.Abs(power)))
            .Reduce();

    public double Expreal(int baseNumber) =>
        Math.Pow(Math.Pow(baseNumber, 1.0 / denominator), numerator);
}