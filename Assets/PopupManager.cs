using TinhDiem;
using TMPro;
using UnityEngine;

public class PopupManager : Singleton<PopupManager>
{
    public TextMeshProUGUI _infoTMP;
    public GameObject popup;
    public void ShowText(string info)
    {
        popup.SetActive(true);
        _infoTMP.SetText(info);
    }

    public void Hide()
    {
        popup.SetActive(false);
    }
}