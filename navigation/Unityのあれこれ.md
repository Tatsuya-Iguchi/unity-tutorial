# Unity
## Project作ったら
### ライブラリとかをインストールする。（最新はやり方が本とかとちょっと違う。2018/04？ が基点）
  https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@2.0/manual/index.html
1. タブから Window > Package Manager 選択 > 上の方にある Advanced ▼ をクリック > Show preview packages にチェックをつける。
2. 次のPackageをインストールする。 インストールは左ペインで対象の package を選択、右上にある install をクリック。
  + AR Foundation ・・・ ビルド環境に応じてライブラリ互換変換してくれる。（MacだったらARKitで〜とか。）
  + ARCore XR Plugin ・・・ Android 用のライブラリ群みたいなもん
  + ARKit Face Tracking ・・・ iPhone 用。顔検知するっぽい？
  + ARKit XR Plugin ・・・ iPhone 用のライブラリ群みたいなもん

-----
### やった
-----

+ 画面領域に表示領域を設ける。
  + CANVASが手っ取り早い。
+ 座標を表示領域に表示する。
  + CANVASのテキスト領域にスクリプトでカメラの座標を上書きする。
+ カメラの座標を表示する。
  + メインタグつけたカメラをアタッチして座標とる。

+ オブジェクトの座標を取得する。
  + AR Session の開始位置からの相対位置になる模様。オブジェクトを置きたい場所の座標をメモ（cm単位）して手設定。
+ 対象のオブジェクトを表示する。
  + Cube と Sphere を適当に早退位置で配置。
+ オブジェクトを特定の座標において移動して表示されるか確認する。
  + カメラの Inspector ＞ Clipping Plane ＞ Farで認識距離を変えられる。 デフォ20m

+ 複数のオブジェクトから座標を取る。
  + Script で ターゲットオブジェクトを切り替えて Game Object を返却する。
+ オブジェクトによって表示する座標を変更する。
  + テキスト領域二つでそれぞれ表示させる。
+ 座標の開始位置を固定する。
  + 現状不可。物理的な開始位置を固定化してズレをチェック。
+ オブジェクトがある方向に矢印を向ける。
  + LookAt で対象のオブジェクトに向ける。Z軸の回転に対して微妙だったり、180°以上回転している状態だと満たせていない。

+ ボタンでオブジェクトへの案内と表示を切り替える。
  + CANVAS と Button で対応。スクリプト化。
+ 表示領域を1箇所にまとめる。
  + テキスト領域を対象のオブジェクトから取得した座標を表示するようにスクリプトで設定。

+ 東西南北を固定する。
  + Alignment がない... GPS ＋ Input.location で対応できていそう。
    + ダメっぽい？日にちごとに東西南北が異なる。。。謎。（N日は北0°がN+1日で350°とかにずれたり。）磁気による影響を受けるため、室内では端末ごとに（北）向きが異なることがある。
    + そもそもGPSを使うこと自体が屋内測位ではNGであると断言する。（cm単位での誤差に耐えられない。）屋内測位ではwifiの電波強度からの三辺測量か、加速度などを用いた慣性航法が一般的。（他にもアクティブRFIDなどがある。）
    + AR技術を用いるのであれば、画像マーカーからの相対位置による距離取得を利用し、相対的な案内をする手法が最良と考える。

+ GPS位置情報をunityで扱う。
  + そんなに精度良くない。外でも0.0001とかの単位では取れない。
    + 同じブロック数（歩数）歩いてもその都度取れた経度緯度が異なる。（経度only、緯度onlyでも同じ）建物は割と近目（50m内）。
    + エレベーターの加速には耐えられない。（8秒ほどでリセット）
    + エスカレーターは画面に変化が少ないと、同じ位置にいると誤認する。（X方向に乗る/降りる場合、YZがズレる）。

+ Vuforiaを使わずにARImageTrackingだけで画像認識させる。
  + コードで実現した。イマイチ。

+ シーンを切り替える。
  + 新しくシーン追加。ボタンで切り替える。
+ タイトルに戻れるようにする。
  + SceneManager.LoadScene("シーン名"); でOK

+ シーンで選択したターゲットの情報を引き継ぐ。
  + ARsession情報を引き継げない。キャンバスでスクリーンを覆っているとpositionが取れない？
+ 案内先にたどり着いたら表示を変える。
  + distanceのif文。
+ 案内先までの距離を表示する。
  + 変数.ToString("f1")　で表示。
+ 目的地付近で文字色を変える。
  + GAMEOBJECT.GetComponent<Text>().color = new Color(0.0f, 0.8f, 0.0f, 1.0f);

+ 案内先のオブジェクトを見えなくする。
  + GameObject.Find(対象).SetActive(false);だと更新しなくなる。



-----
### やってない
-----

+ 上下左右を固定する。
  + Y軸で180°以上あれば、絶対値から-180する？
+ GPS位置情報から現在地を推定する。
  + 緯度, 経度   http://mononofu.hatenablog.com/entry/20090324/1237894846
  + toyosu 35.653837, 139.795441
           35.653740, 139.795452
  + クリック位置で異なる。
+ 矢印をかっこよくする。
+ どこで起動してもカメラの座標位置を修正する。
+ オブジェクトがある方向の平面で線を引く。

### わかったこと
+ 細かな部分はやったこと別に記載。
+ カメラを暗くする(例えば付箋で塞ぐとか)すると、初期位置がリセットされる。
+ かなりズレる（cm単位での補正が必要になる）。
+ 起動角度によって向きが異なる。（右が正方向なのか、左が正方向なのか。）　東西南北上下左右の固定が必要。