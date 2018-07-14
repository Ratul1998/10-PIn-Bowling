using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {
    public enum Action {Tidy,Reset,EndTurn,EndGame};
    private int[] bowls = new int[21];
    private int bowl = 1;
    public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid Pins");
        }
        bowls[bowl - 1] = pins;
        if (bowl >= 19 && Bowl21Awarded())
        {
            bowl++;
            return Action.Reset;
        }
        if (pins == 10)
        {
            return Action.EndTurn;
            bowl += 2;
        }
        if (bowl%2!=0)
        {
            bowl++;
            return Action.Tidy;
        }else if (bowl % 2 == 0)
        {
            bowl++;
            return Action.EndTurn;
        }

        throw new UnityException("Not Sure What Action To return");

    }
    private bool Bowl21Awarded()
    {
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }
}
