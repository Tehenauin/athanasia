
using System;

public static class Paths
{
    public const string FormsFolder = "/Lexicon/Forms";
    public const string GenesFolder = "/Lexicon/Genes";
    public const string ClassesFolder = "/Lexicon/Classes";
    public const string AbilitiesFolder = "/Lexicon/Abilities";


    public static string TypeFolder(Object obj) {
        switch (obj) {
            case Form t: 
                return FormsFolder;
            case Gene t:
                return GenesFolder;
            case CClass t:
                return ClassesFolder;
            case Ability t:
                return AbilitiesFolder;
            default: return null;
        }
    }



}
