using UnityEngine;
// Image をいじるために必要
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    // フィールド名はキャメルケース
    [SerializeField] GameObject appleImage;
    [SerializeField] GameObject mugImage;
    [SerializeField] GameObject pepperGrinderImage;
    [SerializeField] GameObject keyImage;
    [SerializeField] GameObject memoImage; 
    [SerializeField] GameObject selectedItemGO;

    // SelectWithMouse からも参照したいため public
    public string selectedItem;

    // Inspector の onClick で選択するために public にする必要がある
    public void PressButton(string item) {
        ResetSelection();
        
        switch (item) {
        case "apple":
            // Image コンポーネントの Color を設定
            appleImage.GetComponent<Image>().color = Color.red;
            break;
            
        case "mug":
            mugImage.GetComponent<Image>().color = Color.red;

            // mug と pepperGrinder を組み合わせると key をゲットできる
            // 使ったアイテムは消える
            if (selectedItem == "pepperGrinder") {
                keyImage.transform.SetAsLastSibling();
                keyImage.SetActive(true);
                mugImage.SetActive(false);
                pepperGrinderImage.SetActive(false);
            }

            break;

        case "pepperGrinder":
            pepperGrinderImage.GetComponent<Image>().color = Color.red;

            if (selectedItem == "mug") {
                keyImage.transform.SetAsLastSibling();
                keyImage.SetActive(true);
                mugImage.SetActive(false);
                pepperGrinderImage.SetActive(false);
            }

            break;

        case "key":
            keyImage.GetComponent<Image>().color = Color.red;
            break;

        case "memo":
            memoImage.GetComponent<Image>().color = Color.red;
            selectedItemGO.SetActive(true);
            break;

        case "selectedItemBG":
            selectedItemGO.SetActive(false);
            break;
        }

        selectedItem = item;
    }

    private void ResetSelection() {
        GameObject[] images = new GameObject[] { appleImage, mugImage, pepperGrinderImage, keyImage, memoImage };
        foreach (var image in images) {
            image.GetComponent<Image>().color = Color.white;
        }
    }
}
