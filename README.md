# hangfire-dotnet3

hangfire template solution with .net sdk 3.0

## 使い方

**docker-composeは動きません**。

### mongoサーバーの起動

mongoサーバーをインストールして、起動させてください。

### クライアントの起動

`Hangfire Dashboard` を見るために クライアント を起動させます。

```cmd
cd client
dotnet run .
```

[http://localhost:5000/hangfire](http://localhost:5000/hangfire) からダッシュボードにアクセスできます。

### サーバーの起動

ジョブを実行する `Hangfire Server` を起動させます。

```cmd
cd server
dotnet run .
```

2つぐらいコマンドプロンプトを開いて実行すると動きがわかりやすいです。

### キューする主体の起動

**本来はクライアントで実施すべきですが、別アプリのappでキューします**。

```cmd