# 简介

随机返回指定数量图片，可以添加图片，使用EF Core作为ORM框架，SQLite存储。

# 配置

配置文件`appsetting.json`：
```json
{
    // 日志配置
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  // 连接字符串
  "ConnectionStrings": {
    "SqLite": "Data Source=Pictures.db; "
  },
  // 程序配置
    "AppConfig": {
      "BaseUrl": "test"
  },
  "AllowedHosts": "*"
}
```

## BaseUrl

`BaseUrl` 是为了经过反代后仍然能够正常使用Swagger。比如说程序开在`127.0.0.1:5000`，经过nginx将`https://api.example.com/SeeTheWorld`反代到程序后，API可以正常使用，但是Swagger不能。对于这种情况需要在`BaseUrl`中填写`SeeTheWorld`。Swagger的默认地址为：`https://api.example.com/<BaseUrl>/docs/index.html`

## 构建

建议使用Visual Studio 发布适用的版本。或在系统上使用dotnet CLI构建。自带的

## Docker



## LICENSE

![GPL-v3](https://img.cdn.gaein.cn/Logos/gplv3.png)
