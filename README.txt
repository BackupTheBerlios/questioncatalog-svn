- Der Ordner "UmfrageEditorWebFiles" muss beim Webserver als Virtuelles Verzeichnis freigegeben werden

- Versionskontrolle:
	Dateien, die sich bei jedem Kompilieren ändern (*.dll, *.pdb, *.exe u.ä.) sollten nicht in die Versionskontrolle aufgenommen werden, da es sonst andauernd zu Konflikten kommt
	
- In der Datei "UmfrageEditorWebFiles\notes\CodeStyle.txt" kann jeder eintragen, welches Kürzel für einen bestimmten Variablentyp (insbesondere Controls) verwendet wurde, um den Code einheitlich zu halten (als Beispiel habe ich mal für Buttons btn vergeben)

- eine Todo-Liste ist schon im Visual Studio integriert (zu finden unter Ansicht->Andere Fenster->Aufgabenliste)

- für allgemeine Graphiken ist ein Verzeichnis UmfrageEditorWebFiles\images vorgesehen, falls eine Seite spezielle Graphiken benutzt, können die in ein extra images-Verzeichnis in den jeweiligen Ordner der Seite

- um die Dateien zu Gruppieren kann entweder für jede Seite extra oder für zusammengehörende Seiten jeweils ein Unterordner angelegt werden (in Visual Studio anlegen), die Startseite habe ich zB. schon mal in das Verzeichnis UmfrageEditorWebFiles\Loginpage gesteckt
WICHTIG ist dabei, dass alle Seiten auf der selben Verzeichnisebene liegen!

- die Dateien Global.asax*, Web.config und AssemblyInfo.cs sollen nicht verschoben werden