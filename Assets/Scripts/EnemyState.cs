using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyState
{
    WAITING,
    FINDPATH,
    WANDER,
    WANDERAROUNDMAZE,
    SEEKPLAYER,
    FLEEFROMPLAYER,
    FLEEFROMPLAYERWANDER,
    RETURNTOBASE
}
