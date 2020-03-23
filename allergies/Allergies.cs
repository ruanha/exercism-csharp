using System;
using System.Collections.Generic;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private readonly int Mask;
    public Allergies(int mask)
    {
        Mask = mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        var result = Mask & (byte)allergen;
        return result == (byte)allergen;
    }

    public Allergen[] List()
    {
        List<Allergen> result = new List<Allergen>();

        Array allergens = Enum.GetValues(typeof(Allergen));

        foreach (Allergen allergen in allergens) {
            if (IsAllergicTo(allergen)) 
                result.Add(allergen);
        }
        return result.ToArray();
    }
}