# CoinB.Client

## 安裝工具

### OpenAPI Generator

```shell
npm install @openapitools/openapi-generator-cli -g
```

## 更新 OpenAPI 方式

1. 從 CoinB.Server 專案中複製 `openapi.json` 檔案到此專案根目錄。

2. 產生 OpenAPI Client

```shell
openapi-generator-cli generate -i ./openapi.json -g typescript-axios -o ./coinb-client-service
```

3. 安装依賴

```shell
cd ./coinb-client-service
npm install
```