using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem 
{
    //CollectedCounts
    public static int collectedGoldCount { get; set; }
    public static int collectedSilverCount { get; set; }
    public static int collectedRedCrystalCount { get; set; }
    public static int collectedGemstoneCount { get; set; }
    public static int collectedTotalItemCount { get; set; }

    //MoneyValue
    public static int silverMoneyValue { get; set; } = 5;
    public static int goldMoneyValue { get; set; } = 10;
    public static int redCrystalMoneyValue { get; set; } = 20;
    public static int gemstoneMoneyValue { get; set; } = 15;

    //SoldCounts

    public static int soldGoldCount { get; set; }
    public static int soldSilverCount { get; set; }
    public static int soldRedCrystalCount { get; set; }
    public static int soldGemstoneCount { get; set; }
    public static int soldTotalItemCount { get; set; }
}

