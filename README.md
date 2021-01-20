# FixUtf8
remove invalid byte sequences (UTF-8)

```powershell
Get-ChildItem . -Recurse | Where { ! $_.PSIsContainer } | Foreach-Object { echo $_.FullName; &"FixUtf8.exe" $_.FullName ($_.FullName + ".conv") }
```
