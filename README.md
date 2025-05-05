## 🎥 チュートリアル
[【Unityゲーム制作】3D脱出ゲーム制作のやり方を入門者・初心者向けに解説！　Unityの基本操作とオブジェクト配置編 - YouTube](https://www.youtube.com/watch?v=5cowmeabYtI) ~

## 🛠️ 開発環境
- Unityバージョン: 6 (6000.0.44f1)
- プラットフォーム: macOS

## 🧰 利用したAsset
### [Modern Archviz: Leafless | Unity Asset Store](https://assetstore.unity.com/packages/3d/environments/modern-archviz-leafless-108308)
Sceneを利用

### [Keypad FREE | Unity Asset Store](https://assetstore.unity.com/packages/3d/props/electronics/keypad-free-262151)
パスワードを入れるためのKeypadとして利用

### [Retro PSX Horror Puzzle Item Pack (Icon+LowPoly) | Unity Asset Store](https://assetstore.unity.com/packages/3d/props/retro-psx-horror-puzzle-item-pack-icon-lowpoly-250188)
ItemBoxに表示するKeyの画像として利用

### [Simple Fade Scene Transition System | Unity Asset Store](https://assetstore.unity.com/packages/tools/particles-effects/simple-fade-scene-transition-system-81753)
別Sceneへの遷移時にフェードアウトさせるために利用

## 📝 メモ
- [嗚呼蛙_チュートリアル](https://www.notion.so/okadayuka/_-1cc9c2f780ac804f8bcbceb49c1d1b28?pvs=4)

## 🌟 アピールポイント
`ScreenShotScene`ではPrefabを並べてそのスクリーンショットを撮影することができる  
ItemBoxに表示するアイテム画像を撮影するために使用した  
Image > Source Image にそのまま指定できるよう、以下のように設定（詳細はScreenshotCapture.csを参照）

```
textureImporter.textureType = TextureImporterType.Sprite;  // Spriteタイプに設定
textureImporter.spriteImportMode = SpriteImportMode.Single;  // SpriteモードをSingleに設定
textureImporter.isReadable = true;  // スプライトを読み取り可能にする
textureImporter.SaveAndReimport();  // 設定を保存してインポートを更新
```

<img width="1440" alt="image" src="https://github.com/user-attachments/assets/3d08f1c8-fff9-47c6-9708-f697ab03babc"/>
（別リポジトリに切り出す予定）
