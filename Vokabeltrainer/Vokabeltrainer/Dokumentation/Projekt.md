!!! info

    #### 👥 Projektgruppe
    **Daniel Walser**  
    **Klasse:** 2AHIF  **Jahr:** 2025

    ---

    #### 🧑‍🏫 Betreuer
    **?**

    ---

    #### ✨ Kurzbeschreibung
    Der **Vokabeltrainer** ist ein interaktives Programm zur Erstellung digitaler Karteikarten. Nutzer:innen können neue Vokabeln eingeben, speichern und sich diese in **zufälliger Reihenfolge** abfragen lassen.

    🧠 **Ziel:** Den eigenen Wissensstand **effektiv testen** und **kontinuierlich verbessern** – ganz nach dem Prinzip des aktiven Lernens!

#### Collage des Projekts (Code + APP)
### Sonstige Infos

!!! Help Inhaltsverzechnis
    - Dokumentation Zeitplan
    - Lastenheft (Skizzen, etc.)
    - Pflichtenheft
    - Anleitung
    - Bugs/Issues
    - Erweiterungsmöglichkeiten

!!! info Projekt Zeitplan
    |Datum|Beschreibung|Status|Issue|
    |---|---|---|---|
    |**29.04/30.04**|MUST-Haves und NICE-Haves bestimmen|100%||
    |**06.05**|UML-Diagramm entwerfen, GUI-Zeichnung erstellen|100%/80%||
    |**07.05**|Gui Zeichnen|100%||
    |**13.05**|GUI Zeichnung umsetzen/anwenden|30%||
    |**14.05**|Gui Zeichnung umsetzen/anwenden|90%| edit fehlt|
    |**16.05**|Speichern und laden umsetzen/verbessern|60%||
    |**17.05**|Speichern und laden umsetzen/verbessern|90%| doppelter Eintrag von der Hinterseite|
    |**21.05**|Laden und Speichern Verbesserung, Klassen verbessert|||
    |**27.05**|Erstellung des Deck-Managers|||
    |**28.05**|Erstellung eines Decks eingebaut|||
    |**29.05**|Hier wurde das Logging erweitert, Erstellung des PlayWindows und eine neue Laden Klasse erstellt|||
    |**02.06**|Hier wurde das PlayWindow erweitert|||
    |**03.06**|Bearbeitung eines Decks per Select eines Decks|||
    |**04.06**|laden und Speichern improvisiert (Probleme mit dem GIT durch das OneDrive)|||
    |**06.06**|.vs wurde hinzugefügt, Vokabelliste und das Edit wurde verändert, Deckmanager, Deck, Flashcard ebenfalls|||
    |**07.06**|Improvisierung PlayWindow und die Vokabelliste|||
    |**08.06**|Funktionierung des PlayWindows||
    |**09.06**|Erstellung CreateDeck, Löschung von Files, Prävention versehentlichem Löschen.||
    |**10.06**|Decknamen als Anzeige, Abstand zwischen den ListViewItems, kleine Design Änderungen,
    Fehlerbehandlung im CreateDeck (Eingabe),
    Hier wurde das Aussehen der Vokabelliste verbessert,
    Hier wurde das Löschen von Files gefixt (Diese existierten immer noch).||
    |**11.06**|Hier wurde das Punktesystem eingefügt und gefixt, Frage wurde zum
    Label, beim Laden wird das letzte Element genommen. In allen Windows wurde das Logging 
    angepasst. Allerdings wurde das Speichern der Punkte entfernt.|||
    |**14.06**|Optimierung der App - Entfernung von unnötigen Buttons,
    Implementierung vom X im PlayWindow. Hier wurde das Löschen noch so angepasst, dass man eine Liste 
    auswählen muss + das Visuelle vom EditWindow wurde angepasst - Zentrierung|||



!!! Example Lastenheft

    |Must-Haves|
    |---|
    |Erstellen einer Karteikarte|
    |Speichern einer Karteikarte|
    |Laden einer Karteikartei|
    |Abspielung einer Karteikarte|
    |Karteikartenliste erstellen|
    |-,- speichern|
    |Karteikarten löschen|
    |Korrektur der Eingaben|
    ||

    |NICE-Haves|Beschreibung|
    |---|---|
    |Bestenliste|erklärt sich von selber|
    |Gamification|Punktesystem|
    |verschiedene Modis|Wie unten angegeben|
    |Gegen die Zeit|z.B. 10 sek|
    |Hard-Mode|Schwierigere Fragen, Zeitknappheit, keine Pause etc.|
    |Verschiedene Fächer|Mathematik, Physik, Chemie etc.|

!!! Example Pflichtenheft

    Technologie: Logging, GIT, Visual Studio 2022

    Probleme: Laden und Speicher Struktur ändern. + Lösung: Deckmanager ruft die Deck-Speicher Methode auf und Das Deck speichert die Flashcards ab.
    Abspielen von den Karten + Lösung: Index merken.

    Die Architektur ist so aufgebaut, dass die Deckmanager Speichermethode die Deck-Speichermethode beinhaltet.
    Für die Speicherung von Flashcards und laden von Flashcards benötigt man die Deck Klasse.
    Die DeckManager Klasse ladet aber nur das Deck (inkl. Inhalt).
    Zuvor wird nach dem schließen des Vokabellistenwindows die Karten ins Deck gespeichert.

    Getestet wurde diese Software im Visual Studio 2022.

!!! Quote Anleitung

    Man fügt per Add ein Deck hinzu.
    Wenn man eine Karte ausgewählt hat und man dann auf Edit drückt kommt man zum editieren.
    Wenn man im Edit_Window ist kann man durch Add neue Karten einfügen.
    Nach der Eingabe der Vorder- und Hinterseite kann man dies submitten.
    Wenn Karteikarten im Window bzw. im Deck enthalten sind kann man 
    diese abspielen - also sich testen.
    Falls man aus dem Deck herausgehen möchte wird der gesamte Inhalt gespeichert
    aber nicht der Inhalt, welcher durch delete gelöscht wird._

!!! Danger Bugs

    Es gibt offenbar keine. V1.0.1

!!! Tip Erweiterungsmöglichkeiten 

    Für andere Fächer
    verschiedene Modis
    Bilder
    Sounds, Musik

[TOC]