# FixUtf8
remove invalid byte sequences (UTF-8)

```powershell
Get-ChildItem . -Recurse | Where { ! $_.PSIsContainer } | Foreach-Object { echo $_.FullName; &"FixUtf8.exe" $_.FullName ($_.FullName + ".conv") }
```

# PrepareCSV
convert raw txt `key:value` to CSV

```powershell
Get-ChildItem . -Recurse | Where { ! $_.PSIsContainer } | Foreach-Object { echo $_.FullName; &"PrepareCSV.exe" $_.FullName ($_.FullName + ".conv") }
```

import resulting CSV to PostgreSQL

```sql
COPY "Entries" ("Key", "Value") FROM '/var/db_backups/db.conv' with (FORMAT csv, ENCODING 'UTF8', DELIMITER E'\t', QUOTE U&'\001D', ESCAPE U&'\001E');
```
