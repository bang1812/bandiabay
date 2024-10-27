using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefs
{
    public static int bestScore{
        set{
            if(PlayerPrefs.GetInt(Consts.BEST_SCORE, 0) < value){
                PlayerPrefs.SetInt(Consts.BEST_SCORE, value);
            }
        }

        get => PlayerPrefs.GetInt(Consts.BEST_SCORE);
    }
}
