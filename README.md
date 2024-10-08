# ClipboardQRGenerator
クリップボードに登録されたテキストデータをQRコードに変換し、もう一度クリップボードに登録し直すツール。  
生成したQRコードの即時保存に対応しています。
(QRコードは(株)デンソーウェーブの登録商標です)
# 1. 機能
1. クリップボードを監視し、自動でQRコードを生成
2. 生成QRコード自動コピー
3. 生成QRコード自動保存
4. 生成QRコード履歴機能
** **
# 2. 使い方

> [!Note]
> すべてClipboardQRGeneratorを立ち上げてある前提で解説しています

### 1. 基本的なQRコード生成

1. 「監視開始」ボタンをクリックします
1. QRコード化したいテキストデータをコピーします。
1. QRコードを貼り付けたい場所でペーストします。
1. QRコード画像が貼り付けられたら成功です。

### 2. QRコードの自動保存

1. メインウインドウの「生成時に保存する」にチェックを入れます。
2. 「保存先」ボタンをクリックし、開いたダイアログで保存先を設定します。
3. 「保存形式」リストで画像の形式を設定します。
4. 「ファイル名形式」で保存されるファイル名の形式を設定します。内容は[こちらの表](#ファイル名形式)の通りです。
5. 「監視開始」をクリックし、QRコード化したい文字列をコピーします。
> [!Tip]  
> Excelの場合は、範囲選択してコピーすることにより一斉にQR化することができます。

6. 保存先フォルダに指定した形式・ファイル名で保存されていることを確認します。
7. 保存できていたら成功です。

### 3. 生成ログからのコピー・保存
生成ログに保存されている、コピー(or 保存)したい文字を右クリックします。  
### 2-1. コピーする場合
2-1-1. 「QRをコピー」をクリックします。  
2-1-2. 貼り付けたい先でペーストします。  

### 2-2. 保存する場合
「QRを保存」にカーソルをかざすと「ファイル名を指定して保存」と「生成QR保存フォルダに保存」の２種類が出てきます。  
#### **ファイル名を保存して保存**  
> 他のソフトウェアと同様、保存先とファイル形式、ファイル名を指定して保存します。  
  
#### **生成QR保存フォルダに保存**  
> 保存先として設定されているフォルダに保存します。  
> ファイル名・ファイル形式についてはリストボックスの設定に従います。  

** **
# 3. その他
## 1. 画面上の項目全解説
### 1. QR生成の設定
#### 生成解像度
> 生成するQRコード画像の解像度を横ｘ縦で設定できます。単位:px  
> 縦横900px以上を設定した場合、画質の劣化が発生する可能性があります。

#### 誤り訂正レベル
> QRコードが何%欠損しても読み取り可能かを設定できます。

### 2. QRコード保存の設定
#### 生成時に保存する
> チェックを入れると、生成時にテキストボックス内のフォルダパスに保存します。

#### 保存先
> 生成時に保存するフォルダパスを設定します。ダイアログ以外にも手入力でも設定可能です。

#### 保存形式
> PNG、JPG、GIF、BMPから選択可能です。

#### ファイル名形式  
ファイル名の例を以下に示します。
> [!Note]
> 下記の例ではコピーしたテキストを「<https://example.com/examplefile.pdf>」とします。

|形式名|例|
|-|-|
|日時|年-月-日 時-分-秒|
|クリップボード内容|https__example.com_example.pdf|
|日時+クリップボード内容|年-月-日 時-分-秒https__example.com_example.pdf|
|URL・フォルダパスファイル名|examplefile|

> [!Important]
> クリップボード内容にファイル名として使用できない文字(「￥」や「:」、「/」など) が含まれている場合は、自動的に「_」(アンダーバー)に置換えられます。
### 3. QR化ログ
> QRコード化されたテキストデータがログとして列挙されます。   
> 右クリックメニューから[コピーしなおしや保存し直しができます](#3-生成ログからのコピー保存)。

### 4. 最新のQR
> 最後に生成したQRコードが表示されています。  
> ログからコピー・保存で再生成されたQRコードは表示されません。

### 5.コントロール

#### 監視開始・監視終了
> 意図しないタイミングでQRが生成・保存されることを防ぐ機能です。  
> 生成を行う際に「監視開始」、終わったら「監視終了」を押すようにしてください。

#### QR化ログの保持
> QR化ログを保存し、次回以降も利用できるようにするかの設定です。  
> チェックが入っていると少し起動・終了時間が延びます。デフォルトでONになっています。

#### QR化ログクリア
> 保存されているQR化ログをすべて削除します。

#### クリップボードクリア
> クリップボードの内容を削除します。  
> 「監視終了」押下後に押すことを推奨しています。
