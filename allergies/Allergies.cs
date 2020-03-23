using System;
using System.Collections.Generic;

/*
1  = 0000 0001
2  = 0000 0010
4  = 0000 0100
8  = 0000 1000
16 = 0001 0000
32 = 0010 0000
64 = 0100 0000
128= 1000 0000
*/

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
    private int Mask;
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
        var allergens = Enum.GetValues(typeof(Allergen));
        foreach (Allergen allergen in allergens) {
            if ( (Mask & (byte)allergen) == (byte)allergen )
            result.Add(allergen);
        }
        return result.ToArray();
    }
}