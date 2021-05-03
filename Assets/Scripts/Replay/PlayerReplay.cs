using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReplay : MonoBehaviour
{
    private List<PlayerReplayRecord> playerReplayRecords = new List<PlayerReplayRecord>();

    private void FixedUpdate()
    {
        playerReplayRecords.Add(new PlayerReplayRecord(transform.position, transform.eulerAngles));
    }

    public List<PlayerReplayRecord> getRecord()
    {
        return this.playerReplayRecords;
    }
}
