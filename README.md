## (PL): WebAppStudenciINF

<img src="screenshot-localhost-57484-2017-11-14-23-20-49-319.png" height = 450>

**Aplikacja jest warunkiem otrzymania oceny z przedmiotu "Programowanie .NET".**

Prosta przykładowa aplikacja Webowa umożliwiająca następujące czynności i funkcje.
* pobranie i wyświetlenie wszystkich obiektów z tabeli (bazy) studenta.
* możliwość wyświetlenia szczegółowych informacji o studentach.
* możliwość dodania nowego obiektu do tabeli (bazy) za pomocą formularza z poziomu aplikacji.
* możliwość usunięcia dowolnego obiektu z tabeli (bazy) z poziomu aplikacji.

### Wymagania / Narzędzia i technologie:
* Visual Studio [2017].
* .NET Framework 4.6.1.
* SQL Server 13.0.4001 [LocalDB].
* Entity Framework v6.0.
* Bootstrap, jQuery, knockout.js.

### Uruchomienie:
1. Pobierz projekt. Uruchom go za pomocą Visual Studio (plik z rozszerzeniem .sln).
2. Otwórz konsolę menedżera pakietów NuGet (Narzędzia => Menedżer Pakietów NuGet => Konsola menedżera pakietów).
3. Na dole ekranu pojawi się okno konsoli NuGet. Kliknij na przycisk `Przywróć`.
4. W oknie konsoli wpisz następującą komendę: `Update-Database`.
5. Wciśnij F5, aby zacząć debugowanie.

### Komentarz
Moja pierwsza aplikacja Webowa [WebApi]!

Na początku plan był taki, aby połączyć dwie tabele (tabele Grupa i Student) ze sobą za pomocą klucza obcego, ale przy tworzeniu nowego obiektu pojawiały się problemy. Ostatecznie zrezygnowałem z dwóch tabel i zostałem przy jednej. Wszystko było w porzadku, aż do momentu zmiany typu danych dla pola *BirthDate*. Podczas projektowania i debugowania aplikacji zostawiłem to pole jako pole typu `string`, ale prędzej czy później trzeba było je zmienić na właściwy typ danych `DateTime`, jeśli chcę trzymać się konwencji.

Tutaj pojawiły się problemy.

Dane w tabeli są w porządku i nie ma problemu z ich pobieraniem. Natomiast ich końcowy format na front-endzie różni się tym od danych w tabeli - pojawia się atrybut Time i czas obok daty studenta. Próbowałem ten problem rozwiązać - nie udało się.

Z drugiej strony, sam formularz zmusza użytkownika do wpisania daty i niczego innego (jako ciąg znaków w tym przypadku), więc teoretycznie `string` mógłby w tym wypadku przejść. Bądź co bądź, zostałem przy konwencji. Mam nadzieję, że kiedyś uda mi się ten niewielki problem rozwiązać i nie zaważy to zbytnio na ocenie końcowej z projektu.

PS. Visual Studio potrafi nieźle mieszać, jeśli niektóre komponenty nie są dostępne albo zainstalowane. W razie problemów, proszę o kontakt.
