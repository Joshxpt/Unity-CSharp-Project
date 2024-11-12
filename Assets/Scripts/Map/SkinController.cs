using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    public static bool SkinA;
    public static bool SkinB;
    public static bool SkinC;
    public static bool SkinD;

    public void SelectA()
    {
        SkinA = true;
        SkinB = false;
        SkinC = false;
        SkinD = false;
    }

    public void SelectB()
    {
        SkinA = false;
        SkinB = true;
        SkinC = false;
        SkinD = false;
    }

    public void SelectC()
    {
        SkinA = false;
        SkinB = false;
        SkinC = true;
        SkinD = false;
    }
    public void SelectD()
    {
        SkinA = false;
        SkinB = false;
        SkinC = false;
        SkinD = true;
    }
}
