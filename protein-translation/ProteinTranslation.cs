using System;
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

    public static string[] Proteins(string strand)
    {
        var result = new string[1]{"Methionine"};
        return result;
    }
}