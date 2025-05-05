using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject endPanel;
    [SerializeField] GameObject itemBoxCanvas;
    [SerializeField] GameObject player;
    [SerializeField] GameObject expandedKeypadObject;
    [SerializeField] Animator doorAnim;
    [SerializeField] Animator bathroomDoorAnim;

    public void OnClickStart() {
        startPanel.SetActive(false);
        itemBoxCanvas.SetActive(true);
        // Startボタンを押すまで移動できないようにする
        player.GetComponent<PlayerController>().enabled = true;
    }

    public void OnClickGoStudio() {
        // Scene名でもSceneListのindexでも良い
        // SceneManager.LoadScene(1);

        // フェードインさせる場合は Simple Fade Scene Transition System をimportした上で以下で実装可能
        Initiate.Fade("ScreenShotScene", Color.white, 3.0f);
    }

    public void OnClear() {
        // 少しずつ時差をつけて実行する
        StartCoroutine(HiddenAfterSeconds(1f));
        StartCoroutine(SetTriggerAfterSeconds(1.3f));
        StartCoroutine(ShowPanelAfterSeconds(4f));

        player.GetComponent<PlayerController>().enabled = false;
    }

    System.Collections.IEnumerator HiddenAfterSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
        expandedKeypadObject.SetActive(false);
    }

    System.Collections.IEnumerator SetTriggerAfterSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
        doorAnim.SetTrigger("Open");
        bathroomDoorAnim.SetTrigger("Open");
    }

    System.Collections.IEnumerator ShowPanelAfterSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
        endPanel.SetActive(true);
    }
}
