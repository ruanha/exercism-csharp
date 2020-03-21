﻿using System;
using System.Linq;
using System.Collections.Generic;
/*
Codon 	Protein
AUG 	Methionine
UUU, UUC 	Phenylalanine
UUA, UUG 	Leucine
UCU, UCC, UCA, UCG 	Serine
UAU, UAC 	Tyrosine
UGU, UGC 	Cysteine
UGG 	Tryptophan
UAA, UAG, UGA 	STOP
*/
public static class ProteinTranslation
{
    enum AminoAcids {
        Methionine, Phenylalanine, Leucine, Serine,
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
    };

    public static string[] Proteins(string strand)
    {
        List<string> codes = ChunkUp(strand, 3);
        return codes
            .Select(c => GetAminoAcidFrom(c))
            .ToArray();
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
}