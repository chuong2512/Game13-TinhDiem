using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setTExtNul : MonoBehaviour
{
    public void SetEmpty()
    {
        GetComponent<Text>().text = "";
    }
}