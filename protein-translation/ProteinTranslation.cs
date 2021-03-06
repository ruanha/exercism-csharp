﻿using System.Collections.Generic;

public static class ProteinTranslation
{
   public static string[] Proteins(string strand)
    {
        List<string> codons = ChunkUp(strand, 3);
        List<string> result = new List<string>();
        
        foreach (string codon in codons) {
            string AA = GetAminoAcidFrom(codon);
            if (AA != AminoAcids.STOP.ToString()) {
                result.Add(AA);
            } else {
                break;
            }
        }
        return result.ToArray();
    }

    private static List<string> ChunkUp(string strand, int size) {
        List<string> result = new List<string>();
        for (int i = 0; i <= strand.Length - size; i += size) {
            result.Add(strand.Substring(i, size));
        }
        return result;
    }
    
    private static string GetAminoAcidFrom(string codon) {
        return Codon[codon];
    }

    enum AminoAcids {
        Methionine, Phenylalanine, Leucine, Serine, Tyrosine, Cysteine, Tryptophan, STOP
    }
 
    private static Dictionary<string, string> Codon = new Dictionary<string, string>{
        {"AUG", AminoAcids.Methionine.ToString()},
        {"UUU", AminoAcids.Phenylalanine.ToString()},
        {"UUC", AminoAcids.Phenylalanine.ToString()},
        {"UUA", AminoAcids.Leucine.ToString()},
        {"UUG", AminoAcids.Leucine.ToString()},
        {"UCU", AminoAcids.Serine.ToString()},
        {"UCC", AminoAcids.Serine.ToString()},
        {"UCA", AminoAcids.Serine.ToString()},
        {"UCG", AminoAcids.Serine.ToString()},
        {"UAU", AminoAcids.Tyrosine.ToString()},
        {"UAC", AminoAcids.Tyrosine.ToString()},
        {"UGU", AminoAcids.Cysteine.ToString()},
        {"UGC", AminoAcids.Cysteine.ToString()},
        {"UGG", AminoAcids.Tryptophan.ToString()},
        {"UAA", AminoAcids.STOP.ToString()},
        {"UAG", AminoAcids.STOP.ToString()},
        {"UGA", AminoAcids.STOP.ToString()},
    };
}