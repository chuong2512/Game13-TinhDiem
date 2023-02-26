using UnityEngine;
using UnityEngine.UI;

public class PurchasingManager : MonoBehaviour
{
    public GameObject sureObject;
    public Button yesBtn, noBtn;

    void Start()
    {
        yesBtn.onClick.AddListener(() =>
        {
            TinhDiemManager.Instance.Caculate();
            sureObject.SetActive(false);
        });
        noBtn.onClick.AddListener(() => sureObject.SetActive(false));
    }

    public void Sub()
    {
        GameDataManager.Instance.playerData.SubDiamond(10000);
    }

    public void OnPressDown(int i)
    {
        switch (i)
        {
            case 1:
                IAPManager.OnPurchaseSuccess = () => GameDataManager.Instance.playerData.AddDiamond(10000);
                IAPManager.Instance.BuyProductID(IAPKey.PACK1);
                break;
            case 2:
                IAPManager.OnPurchaseSuccess = () => GameDataManager.Instance.playerData.AddDiamond(20000);
                IAPManager.Instance.BuyProductID(IAPKey.PACK2);
                break;
            case 3:
                IAPManager.OnPurchaseSuccess = () => GameDataManager.Instance.playerData.AddDiamond(50000);
                IAPManager.Instance.BuyProductID(IAPKey.PACK3);
                break;
            case 4:
                IAPManager.OnPurchaseSuccess = () => GameDataManager.Instance.playerData.AddDiamond(100000);
                IAPManager.Instance.BuyProductID(IAPKey.PACK4);
                break;
        }
    }
}