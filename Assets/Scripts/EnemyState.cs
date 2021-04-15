using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyState
{
    FINDPATH,
    WANDER,
    WANDERAROUNDMAZE,
    SEEKPLAYER,
    FLEEFROMPLAYER,
    RETURNTOBASE
}
