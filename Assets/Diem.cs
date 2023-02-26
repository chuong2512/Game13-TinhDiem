using System.Globalization;
using TMPro;
using UnityEngine;

public class Diem : MonoBehaviour
{
    public TextMeshProUGUI mon;

    public void Init(string mon, float diem, string ketqua = "")
    {
        var diemString = diem.ToString("F1", CultureInfo.InvariantCulture);

        if (ketqua == "")
        {
            this.mon.SetText($"{mon} : {diemString}");
        }
        else
        {
            this.mon.SetText($"{mon} : {diemString} - {ketqua}");
        }
    }
}