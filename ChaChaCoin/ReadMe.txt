﻿チャチャウォレットの各クラスの説明
1,Form1:ウォレットのメインフォームになります
付属ボタン
・Get＿Publickey：使用者の最初に入力したプライベートキーから導出されたパブリックキー （コインの送受信に使うアドレス）が表示されます！

・AssetMove_Move:コインの送金を行うボタン（トランザクションの情報は、テーブル名、枚数、送り主のパブリックキー、送り先のパブリックキー ）
                :トランザクションに関する署名は送り元のプライベートキーが行う！今回のチャチャウォレットはやんちゃんが一番はじめに入力した
                :プライベートキーをUtilsファイルに初期化しないかぎり記憶するようにアプリケーションの設定をしています！安心を！

・Get_Balance   :はじめに指定したプライベートキーから導出したパブリックキー上のチャチャの枚数を表示・更新します！

メニューについて
・File
1)aboutChaChaWallet:ここにはChaChaCoinの基盤となるmiyabiの性能とプログラミング言語、デベロッパー情報、ChaChaCoinに関する情報を記載してます！
2)Quit             :ウォレットシステムを終了させるボタンです！
・Miyabi  
1)manual           :miyabiに関する情報が乗っています（提供:BitFlyer BlockChain) miyabiは純日本産のブロックチェーンです！
2)playground       :miyabiの体験用のwebアプリケーション（自分でテーブルを作ったり、トークンを発行したり、トークンの移動ができます）
                   :詳しくはビットフライヤーさんに聞いてください！チャチャに関する問合せは絶対にやめてください！（迷惑かけたくない）
・Social           
1)twitter          :今回のチャチャのデベロッパーであるやんちゃんの垢ですDMで質問できるように付属しました！
2)Github           :やんちゃんのGithubリンクです今回動かしているコードが載っています！
・help             :開発中なので今後追加します！

2,Form2;パブリックキー の表示フォーム
3,Form3:コインの送金情報の入力フォーム
4,Form4:チャチャコインに関する記述
5,Form5:入力情報の警告フォーム
6,Form6:トランザクションIDと送金の成功の有無
7,Form7:プライベートキーの入力と登録のフォーム
技術情報(miyabiのスペック)
・BrockChain miyabi (BitFlyer BrockChain)
・コンセンサスアルゴリズム BFK2
・BFT :ビザンチンノード耐性あり
・処理速度 4000/秒

コードに関して
各ファイルとクラスの説明
・namespace:WalletService/program.cs(class:WAction)
<method1> Send           :ウォレットの送金処理に関するトランザクションの生成とmiyabiへのブロードキャスト <return>tx.Id.ToString()(トランザクションID) ,result(送金の結果)</return>
<method2> ShowAsset      :最初に入力されたプライベートキーからパブリックキー を生成しそこのAssetのamountを返す <return>result.Value(保有枚数)</return>
<method3> SendTransaction:作成されたトランザクション情報をmiyabiに送信 <return>なし</return>
<method4> GetAddress     :Utilsファイルに格納されたプライベートキーからパブリックキーを生成 <return>new PublicKeyAddress(Utils.GetUser0KeyPair())</return>
<method5> setClient      :プレイグラウンドURLを読み込みClientの型で返す<return>client</return>

・namespace:Utility/Utils.cs(class:Utils) 提供：bitflyer提供
<変数１>ApiUrl           :miyabiプレイグラウンドのUrlの文字列(string型)
<変数２>GetKeypair       :はじめに入力したプライベートキー情報
<method1> WaitTx:トランザクション情報の状態を返す <return>result.Value.ResultCode.ToString()</return>

・namespace:ChaChaCoin/Form1.cs (class:Form1)
<method1> Form1_Load        :%appdata%/local/ChaChacoin/~/~/直下のuses.Configの各設定の読み込みともしプライベートキー情報がなかった場合はフォーム７を開く
<method2> Form_close        :%appdata%/local/ChaChacoin/~/~/直下のuses.Configのアプリの終了時の値を保存
<method3> GetPublickey_Click:フォーム２を開く
<method4> AssetMove_Click   :フォーム３を開く
<method5> Get_Balance_Click :自分のパブリックキー上の枚数の取得・更新
<method6> GetPublickey_Click:

メニュー
<method7>aboutChaChaWallet〜 ：フォーム４を開く
<method8>quit                :ウォレットの終了
<method9>manual〜            :miyabiのマニュアルウェブサイトを表示
<method10>playground         :miyabiのプレイグラウンドのwebサイトを表示
<method11>twitter~           :やんちゃんのtwitterを表示
<method12>github~            :やんちゃんのgithubを表示

＊ヘルプは開拓中

・namespace:ChaChaCoin/Form2.cs (class:Form2)
<method1> Form2_load：テキストボックス１に自分のパブリックキーを表示
<method2> Confirm：フォーム２を閉じる

・namespace:ChaChaCoin/Form3.cs (class:Form3)
<method1>Buttun1_Click(sendボタン):各テキストボックスに入力された値を文字列から型変換されることを<method2>Inputjudgementと<method３>Inputnumjudgementで評価し
                                 :<method4>Showtransactionにamountを渡す、その後WAction/program.csのSendメソッドを実行し帰ってきた結果をフォーム６の各変数に
                                 :値を代入しフォーム６を表示
<method2>Inputjudgement          :文字列からパブリックキーへの型変換を調査し例外はフォーム５を開き警告 <return>inputaddress</return>
<method3>Inputnumjudgement       :入力された文字列からdecimal型への型変換を調査例外はフォーム５を開き警告 <return>inputamount</return>
<method4>Showtransaction         :受け取った変数amountを各配列に格納し各条件にあうiの数字でフォーム１のrecenttransactionへの表示を変更する
<method5>Form3_Load              :フォーム３が開いた時%appdata%/local/ChaChacoin/~/~/直下のuses.Configのアプリの記憶している値の読み込み
<method6>OnFormClosed            :フォーム３が閉じた時%appdata%/local/ChaChacoin/~/~/直下のuses.Configのアプリの情報の値の書き込み

・namespace:ChaChaCoin/Form5.cs (class:Form4)
チャチャコインに関する説明を記述

・namespace:ChaChaCoin/Form4.cs (class:Form5)
<method1>Buttun1_Click(Backボタン):フォーム５を閉じる

・namespace:ChaChaCoin/Form6.cs (class:Form6)
<method1>Form6_Load               :フォーム６を開くときにトランザクションのID と送金に関する結果を表示する
<method1>Button1_Click(Closeボタン):フォーム６を閉じる

・namespace:ChaChaCoin/Form7.cs (class:Form7)
<method1>Buttun1_Click(regist_privatekeyボタン):テキストボックス１に入力された値を変換可能であるか判別し変換できない場合はフォーム５を開き警告する問題なければUtils.csファイルの
                                              :配列に値を格納しフォーム７を閉じる
<method1>Inputprivatekeyjudgement             :入力された文字列の変換判定を行う
<method1>Form7_Closed                         :アプリの都合上users.Configにひとまずprivatekey情報をnullとして保存

・namespace:ChaChaCoin/program.cs (class:Program)
メインメソッドが存在します（詳細は省略）
