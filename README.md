# FixUtf8
remove invalid byte sequences (UTF-8)

```powershell
Get-ChildItem "C:\files" | Foreach-Object { &"FixUtf8.exe" $_.FullName ($_.FullName + ".conv") }
```
