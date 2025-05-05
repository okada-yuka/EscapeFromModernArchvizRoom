using UnityEngine;
using System.IO;
using System;  // DateTimeの使用のため
using UnityEditor;  // UnityエディタのAPIを使うために必要

public class ScreenshotCapture : MonoBehaviour
{
    public Camera mainCamera;  // 透過画像を保存するカメラ
    public string fileNamePrefix = "screenshot";  // ファイル名のプレフィックス
    public string directoryPath = "Assets/Resources/Icons";  // 保存先のディレクトリ

    public void CaptureScreenshotWithTransparentBackground()
    {
        // 透過背景のためにカメラの設定を変更
        mainCamera.clearFlags = CameraClearFlags.SolidColor;
        mainCamera.backgroundColor = Color.clear;  // 背景を透明に設定

        // RenderTextureの作成
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);

        // カメラの出力先をRenderTextureに設定
        mainCamera.targetTexture = renderTexture;

        // 描画対象となるRenderTextureをアクティブにする
        RenderTexture.active = renderTexture;

        // カメラでシーンを描画
        mainCamera.Render();

        // 画像データを読み込むためのTexture2Dを作成
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);

        // RenderTextureの内容をTexture2Dにコピー
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();  // データを確定

        // RenderTextureの後処理
        mainCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // 保存先のディレクトリがなければ作成
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);  // フォルダがなければ作成
        }

        // タイムスタンプを使ってユニークなファイル名を作成
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = $"{fileNamePrefix}_{timestamp}.png";  // 新しいファイル名

        // 保存するファイルパス
        string fullPath = Path.Combine(directoryPath, fileName);

        // PNG形式で保存
        byte[] pngData = screenshot.EncodeToPNG();
        
        // ファイルを書き込む
        File.WriteAllBytes(fullPath, pngData);

        // インポート設定を変更してSpriteとして扱う
        AssetDatabase.ImportAsset(fullPath);  // アセットデータベースに新しい画像をインポート
        TextureImporter textureImporter = AssetImporter.GetAtPath(fullPath) as TextureImporter;

        if (textureImporter != null)
        {
            textureImporter.textureType = TextureImporterType.Sprite;  // Spriteタイプに設定
            textureImporter.spriteImportMode = SpriteImportMode.Single;  // SpriteモードをSingleに設定
            textureImporter.isReadable = true;  // スプライトを読み取り可能にする
            textureImporter.SaveAndReimport();  // 設定を保存してインポートを更新
        }

        // スクリーンショットを保存したことをログに出力
        Debug.Log("スクリーンショットを保存し、Spriteとして設定しました: " + fullPath);
    }
}