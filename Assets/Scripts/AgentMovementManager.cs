using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovementManager : MonoBehaviour
{
    public bool allowToMove = true;

    public void setAllowToMove(bool b)
    {
        allowToMove = b;
    }

    public bool IsAllowedToMove()
    {
        return allowToMove;
    }
}
