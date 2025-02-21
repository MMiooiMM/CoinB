# CoinB

## 安裝與設定

### 1. 安裝 .NET 9 SDK
請確保已安裝 .NET 9 SDK。可以從 [這裡](https://dotnet.microsoft.com/download/dotnet/9.0) 下載並安裝。

### 2. 安裝 dotnet ef 工具

`dotnet tool install --global dotnet-ef`

### 3. 新增遷移

`dotnet ef migrations add NewMigration`

### 4. 更新資料庫

`dotnet ef database update`

## 專案結構

- `CoinB/Program.cs` - 應用程式入口
- `CoinB/Data` - 資料庫上下文和模型
- `CoinB/Services` - 服務層
- `CoinB/Endpoints` - API 端點

## 授權

此專案採用 MIT 授權。詳情請參閱 [LICENSE](LICENSE) 文件。