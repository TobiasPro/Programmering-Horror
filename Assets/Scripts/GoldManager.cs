using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    // Vi bruger TMPro for at lave en public TextMesh
using TMPro;

public class GoldManager : MonoBehaviour
{
    public int Point = 0;
    // Laver en refference til manager text
    public TextMeshProUGUI PointText;

    public int PointToEnableTarget;

    public GameObject TargetToEnable;

    public void AddPoint(int amount)
    {
        // Tilføjer 1 point til det nuværende amount
        Point += amount;
        PointText.text = "" + Point;
        // Her gør vi så hvis point eller flere som man har brug for TargetToEnable så bliver vores goal activ
        if(Point >= PointToEnableTarget)
        {
            TargetToEnable.SetActive(true);
        }
    }

}
