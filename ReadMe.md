# このソフトウェアについて

日時文字列を標準出力するコンソールアプリである。

動けばいいレベルなので完成度が低い。

# 開発環境 #

* Windows XP SP3
* Visual C# 2010 Express
* .NET Framework 4.0
    * Windows Console Application
* NUnit 2.6.4

# プロジェクト

プロジェクト|概要
------------|----
GetTimestamp|ツール本体。
GetTimestampFormatExample|おまけツール。フォーマットのパターンを出力する。
GetTimestampTest|NUnitによる単体試験。

# GetTimestamp

## 使い方

実行コマンド例|出力例
--------------|------
GetTimestamp.exe|20161220102139578
GetTimestamp.exe "ggyyyy年M月d日 H時m分s秒" ja-JP System.Globalization.JapaneseCalendar|平成28年12月20日 10時21分49秒
Timestamp.exe F|2016年12月20日(火) 10:22:29
GetTimestamp.exe "yyyy-MM-dd HH:mm:ss.ffffff"|2016-12-20 10:23:15.859375
GetTimestamp.exe dddd|火曜日

### ヘルプ

実行コマンド例|説明
--------------|----
GetTimestamp.exe --help|ヘルプを表示する。
GetTimestamp.exe --listup-cultures|Culture一覧を表示する。第二引数の候補。
GetTimestamp.exe --listup-calendars|Calendar一覧を表示する。第三引数の候補。
GetTimestamp.exe --listup-calendars ja-JP|ja-JPにおけるCalendar一覧を表示する。第三引数の候補。

### フォーマット

* [標準の日時書式指定文字列](https://msdn.microsoft.com/ja-jp/library/az4se3k1\(v=vs.110\).aspx)
* [カスタム日時書式指定文字列](https://msdn.microsoft.com/ja-jp/library/8kb3ddd4\(v=vs.110\).aspx)

# ライセンス #

このソフトウェアはCC0ライセンスです。

[![CC0](http://i.creativecommons.org/p/zero/1.0/88x31.png "CC0")](http://creativecommons.org/publicdomain/zero/1.0/deed.ja)
