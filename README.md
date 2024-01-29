# iisLogFileReader

Ein Viewer für IIS Logfiles, implementiert mit einer experimentellen Mischung aus ASP.NET MVC (.NET 4.7.2) mit Vue 3 Frontend. 
Das Vue Frontend wurde mit `vite` aufgesetzt. 

## Backend starten
  1. Log-Dateien von `./examples` nach `C:\ExampleLogFiles` kopieren - Leider liest das Backend gegenwärtig nur das erste Logfile in diesem Verzeichnis.
  2. `./IisLogFileReader.sln` debuggen

## Frontend starten
Unter `./frontend`: 
  1. `npm install`
  2. `npm run dev`
