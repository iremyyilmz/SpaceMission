using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneCalculator 
{
    static float left;
    static float right;
    static float top;
    static float bottom;

    public static float Left
    {
        get
        {
            return left;
        }
    }

    public static float Right
    {
        get
        {
            return right;
        }
    }

    public static float Top
    {
        get
        {
            return top;
        }
    }

    public static float Bottom
    {
        get
        {
            return bottom;
        }
    }

    public static void Init()
    {
        float zAxis = -Camera.main.transform.position.z;
        Vector3 lowerLeftCorner = new Vector3(0, 0, zAxis);
        Vector3 upperRigthCorner = new Vector3(Screen.width, Screen.height, zAxis);

        Vector3 leftGameWorld = Camera.main.ScreenToWorldPoint(lowerLeftCorner);
        Vector3 rightGameWorld = Camera.main.ScreenToWorldPoint(upperRigthCorner);

        left = leftGameWorld.x;
        right = rightGameWorld.x;
        top = rightGameWorld.y;
        bottom = leftGameWorld.y;
    }
}
