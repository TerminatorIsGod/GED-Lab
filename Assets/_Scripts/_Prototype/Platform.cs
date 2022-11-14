using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    protected int width;
    protected int height;
    protected GameObject cloneObj;

    public abstract GameObject spawn();
    public abstract Platform clone();

}

public class customizablePlatform : Platform
{
    public customizablePlatform(int width, int height, GameObject cloneObj)
    {
        this.width = width;
        this.height = height;
        this.cloneObj = cloneObj;
    }

    public override GameObject spawn()
    {
        cloneObj.transform.localScale = new Vector3(width, height, cloneObj.transform.localScale.z);
        return cloneObj;
    }

    public override Platform clone()
    {
        return new customizablePlatform(width, height, Instantiate(cloneObj));
    }
}
