# SkImageResizer

**SkImageResizer** 是一個可以調整圖片大小的主控台專案，專案中有 50 張範例圖片。該程式並沒有使用**非同步**的方法，我們想讓同學們使用第一天所學的非同步觀念與技巧。

> 此專案使用 [.NET Core 3.1](https://dotnet.microsoft.com/download) 與跨平台的 [SkiaSharp](https://github.com/mono/SkiaSharp) 套件對圖片進行縮放作業。

## 任務說明

該專案中有兩個檔案：

1. `Program.cs`

    主程式不用修改，所有程式碼皆已寫好，包含執行時間計算部分。

2. `SKImageProcess.cs`

    目前的 `ResizeImagesAsync` 非同步方法，其實是直接複製 `ResizeImages` 同步方法的內容而已，並不是「真」非同步方法喔！

    請修改 `ResizeImagesAsync` 非同步方法，用比較有效率的方式執行圖片縮放功能！

> 這個 **SkImageResizer** 專案為 .NET Core 3.1 專案類型，請務必安裝 **.NET Core 工作負載**才能在 Visual Studio 2019 進行開發。若使用 Visual Studio Code 進行開發，請安裝 [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) 擴充套件。

## 執行方式

```sh
cd SkImageResizer
dotnet restore
dotnet run -c Release
```

## 繳交作業

1. 建議大家先對此專案 Fork 到自己的 GitHub 帳號下，然後在進行開發，開發完成後，請將專案網址回覆在 FB 社團的貼文留言中，同學之間也可以互相學習觀摩作法！ 🙂

2. 請提供執行環境的硬體規格說明，提供資料的範例如下：

    ```txt
    作業系統：Microsoft Windows [Version 10.0.18363.1082]
    　ＣＰＵ：1 Sockets, 2 Cores, 4 Logical processors
    　ＲＡＭ：16GB
    ```

## 注意事項

1. 程式碼需兼顧**可讀性**(請適度排版)與**執行效率**
2. 效能提升比例公式已經寫好，寫好程式碼之後直接執行即可看到效能提升比例。

## 效能測試

[BenchmarkDotNet](https://benchmarkdotnet.org/) 是一套威力強大的 .NET 效能測試套件，可以用來相對客觀的分析 .NET 程式碼的執行效率。

**SkImageResizer.Benchmark** 專案已經將測試的方法寫好，他會分析同步與非同步程式的執行效率，並提供完整的測試結果報告。執行的方式與步驟如下：

```sh
cd SkImageResizer.Benchmark
dotnet run -c Release
```
