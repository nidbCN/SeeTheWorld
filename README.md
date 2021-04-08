# 简介

随机返回指定数量图片，可以添加图片，使用EF Core作为ORM框架，SQLite存储。

# 配置

请先安装dotnet SDK和`EF Core 工具`
参考以下命令(Ubuntu 20.10):
```sh
wget https://packages.microsoft.com/config/ubuntu/20.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-5.0
dotnet tool install --global dotnet-ef
```

配置文件`appsetting.json`：
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ConnectionStrings": {
    "SqLite": "Data Source=Pictures.db; "
  },
    "AppConfig": {
      "BaseUrl": "test"
  },
  "AllowedHosts": "*"
}
```

## BaseUrl

`BaseUrl` 是为了经过反代后仍然能够正常使用Swagger。比如说程序开在`127.0.0.1:5000`，经过nginx将`https://api.example.com/SeeTheWorld`反代到程序后，API可以正常使用，但是Swagger不能。对于这种情况需要在`BaseUrl`中填写`SeeTheWorld`。Swagger的默认地址为：`https://api.example.com/<BaseUrl>/docs/index.html`

## 构建

建议使用Visual Studio 发布适用的版本。或在系统上使用dotnet CLI构建。自带的脚本仅用于构建Ubuntu下的程序
可以参考进行修改

## Docker

`./run-docker.sh`

## LICENSE

![GPL-v3](https://img.cdn.gaein.cn/Logos/gplv3.png)
