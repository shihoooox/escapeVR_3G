**以下[ ]内を指定のものに変えてください。  
基本的に以下に書いたコマンド以外は使いません。**

=====

## 作業を始める

マスターブランチに移動  

    $ git checkout master

作業をするときはブランチを作る。
branch名は、*スクリプト/モデル名*にしてください。

    $ git branch [branch名]

    《例》$ git branch MainObjectMenuManager
    《例》$ git branch model_ball

作成したブランチに移動  

    $ git checkout [branch名]
    

ブランチを作ったら、指定の場所にスクリプト/モデルを作る。その後、

    $ git add .
    $ git commit -m “[branch名]の制作”
    $ git push origin [branch名]

ブラウザ上の [escapeVR_3Gのページ](https://github.com/shihoooox/escapeVR_3G "escapeVR_3G")で
`Compare & pull request`を押す。  
移動先のページで、

    ーーーーーーーーーーーーーーーーーーー
    タイトル : [スクリプト名]の制作
    コメント : 
    - [ ] メソッド名（モデルの場合必要無し）
    - [ ] メソッド名
    	　：
    ーーーーーーーーーーーーーーーーーーー 

`- [ ]`はチェックボックスのコマンドです

    《例》 
    ーーーーーーーーーーーーーーーーーーー
    タイトル : MainObjectMenuManagerの制作
    コメント : 
    - [ ] Start
    - [ ] Update
    - [ ] setObject
    - [ ] unsetObject
    ーーーーーーーーーーーーーーーーーーー 

を入力し、`Create pull request`を押す。  
これで作業を行うブランチの準備ができました。  

メソッドを作り終えるたびに、ブラウザ上の`Pull requests`タブから、自分のページに行きチェックボックスにチェックを入れる。  
それにより進捗確認を行うため、忘れないこと。  
*チェックボッスクスは同期されているため、他人のページのチェックボックスは触らない。*


ある程度作業が進む or 作業が終わったら、

    $ git add .
    $ git commit -m “[進捗状態]”
    $ git push origin [branch名]

を行う。
エラーが出たら指示に従ってください。

リモートとローカルの状態が異なっているとpushできないので、リモートに更新がある場合、pullしてからpushしてください。  

    $ git pull origin master
    
を行うと、最新の状態に更新できます。  


全ての作業を終えたら、LINEグループでその旨を伝える。  
岡本さんがプログラム/モデルをチェックして、合格したら岡本さんがmergeする。

次の作業を始める時は上に戻る。


## unityを使用する上での注意点

* 一度組み込んだモデルに修正があり、同じファイル名で上書きしたい場合、Unityエディタ外(Finder上)でファイルを上書きしてください。  
* ファイルの移動、ファイルの解明を行いたい場合は、Unity上で行ってください。
* 複数人で１つのシーンを編集しないでください。