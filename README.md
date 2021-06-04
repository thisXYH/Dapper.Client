# Dapper.Client
基于`Dapper`的数据库客户端抽象, 可以快速便捷的实现 `mssql`,`mysql`,`oracle`... 对应的客户端。

## 为什么要封装
* `Dapper` 是扩展到 `IDbConnection` 上，直接使用的话需要手动管理 `IDbConnection` 生命周期
* `Dapper` 扩展的Api太多了，不少Api容易用歪（比如一次返回多个实体，根据某字段进行切分），需要做一层屏蔽，仅提供常用语义
    * 获取受影响行数
    * 是否存在某数据
    * 获取一个值
    * 获取一行值
    * 获取多行值
    * 获取一个表
    * 获取多个表
* 解决使用相同逻辑方法需要提供 `IDbConnection`、`IDbTransaction` 版，导致重复代码或者兼容代码。

## 使用方式
1. 引用包： dotnet add package Dapper.Client
1. 继承 AbstractDbClient， 实现目标客户端
2. 通过客户端访问数据库。

> 具体操作查看示例项目  `Dapper.Client.Sample`