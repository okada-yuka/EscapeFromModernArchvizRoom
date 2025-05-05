using UnityEngine;
// namespaceを指定してimportする必要がある
using NavKeypad;

public class SelectWithMouse : MonoBehaviour
{
    [SerializeField] ItemManager itemManager;
    [SerializeField] GameObject door;
    [SerializeField] GameObject painting;
    [SerializeField] GameObject selectedKeypad;

    [Header("UI Images")]
    [SerializeField] GameObject appleUIImage;
    [SerializeField] GameObject mugUIImage;
    [SerializeField] GameObject pepperGrinderUIImage;
    [SerializeField] GameObject memoUIImage;
    [SerializeField] GameObject keyUIImage;

    [Header("World Items")]
    [SerializeField] GameObject appleWorldObject;
    [SerializeField] GameObject mugWorldObject;
    [SerializeField] GameObject pepperGrinderWorldObject;
    [SerializeField] GameObject itemBoxPanel;

    void Start() {
        door.transform.Rotate(0, -90, 0);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            OnMouseClick();
        }
    }

    void OnMouseClick() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            TryPickupItem(hit.transform.name);

            // RaycastHitしたオプジェクトに KeypadButton コンポーネントがあるか確認
            KeypadButton keypadButton = hit.transform.GetComponent<KeypadButton>();
            if (keypadButton != null) {
                Debug.Log("ExpandedKeypadのボタンをタップ");
                keypadButton.PressButton();
            }
        }
    }

    void TryPickupItem(string itemName) {
        switch (itemName) {
            case "Apple_01":
                PickupItem(appleUIImage, appleWorldObject);
                break;
            case "Mug_01":
                PickupItem(mugUIImage, mugWorldObject);
                break;
            case "PepperGrinder_01":
                PickupItem(pepperGrinderUIImage, pepperGrinderWorldObject);
                break;
            case "BathroomDoor_01":
                // TODO: ドアの開閉がうまくいっていない
                // アイテムの key が選択状態の場合、ドアを開ける
                // パスワードの入力を追加する
                // if (itemManager.selectedItem == "key") {
                    Debug.Log("keyを持った状態でドアをタップ");
                    door.transform.Rotate(0, -90, 0);
                    // door.transform.Rotate(Vector3.up * Time.deltaTime * 3); 
                // }
                break;
            case "PaintingExtraSmall_c_01":
                // TODO: 絵画の位置をずらすのもできない
                // Debug.Log("paintingをクリック");
                // Debug.Log($"{painting.name} pos: {painting.transform.position}");
                // painting.transform.SetParent(null);
                // painting.transform.position += new Vector3(10f, 10f, 10f);

                if (itemManager.selectedItem == "key") {
                    Debug.Log("paintingを持った状態で絵画をタップ");
                    keyUIImage.SetActive(false);
                    memoUIImage.transform.SetAsLastSibling();
                    memoUIImage.SetActive(true);

                    painting.transform.position += new Vector3(100f, 100f, 100f);
                }
                break;

            case "Keypad":
                Debug.Log("ドア横のKeypadをタップ");
                selectedKeypad.SetActive(true);
                itemBoxPanel.SetActive(false);
                break;

            default:
                Debug.Log("未対応のアイテム：" + itemName);
                break;
        }
    }

    void PickupItem(GameObject uiImage, GameObject worldItem) {
        uiImage.SetActive(true);
        // 1番最後に持ってくる
        uiImage.transform.SetAsLastSibling();
        worldItem.SetActive(false);
    }
}
