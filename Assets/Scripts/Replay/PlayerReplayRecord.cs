using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class PlayerReplayRecord
{
    private float[] position = new float[3];

    private float[] rotation = new float[3];

    public PlayerReplayRecord(Vector3 position, Vector3 rotation)
    {
        setPosition(position);
        setRotation(rotation);
    }

    public void setPosition(Vector3 position)
    {
        //this.position = position;
        this.position[0] = position.x;
        this.position[1] = position.y;
        this.position[2] = position.z;
    }

    public Vector3 getPosition()
    {
        return new Vector3(position[0], position[1], position[2]);
    }

    public void setRotation(Vector3 rotation)
    {
        //this.rotation = rotation;
        this.rotation[0] = rotation.x;
        this.rotation[1] = rotation.y;
        this.rotation[2] = rotation.z;
    }

    public Vector3 getRotation()
    {
        return new Vector3(rotation[0], rotation[1], rotation[2]);
    }
}
