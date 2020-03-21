using System;
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
    enum AminoAcid {
        Methionine, Phenylalanine, Leucine, Serine,Tyrosine, Cysteine, Tryptophan, STOP
    }

    private static Dictionary<string, string> Codon = new Dictionary<string, string>{
        {"AUG", "Methionine"},
        {"UUU", "Phenylalanine"}
    };

    public static string[] Proteins(string strand)
    {
        List<string> codes = ChunkUp(strand, 3);
        return codes
            .Select(c => Codon[c])
            .ToArray();
    }

    private static List<string> ChunkUp(string strand, int size) {
        List<string> result = new List<string>();
        for (int i = 0; i <= strand.Length - size; i += size) {
            result.Add(strand.Substring(i, size));
        }
        return result;
    }
}