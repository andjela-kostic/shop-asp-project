# shop-asp-project

"Initial" migracija ukljucuje i pocetne podatke za tabele Categories, Users, Products, Sizes, SizesProducts, Orders, OrderLines UserUseCases

- paginacija je podesena na 5 rezultata po stranici
- validacija je odradjena za svako kreiranje, menjanje i brisanje
- swagger je postavljen
- baza podataka je postavljena i popunjena code first pristupom
- autorizacija se vrsi upotrebom Jwt-a
- use caseovi su granulirani za svaku komandu i upit
- email se salje nakon uspesne registracije
- svaki endpoint vraca statusne kodove u zavisnosti od uspeha
- loguje se svako izvrsavanje bilo kog use case-a, a mogu se i pretrazivati
- automapper je koriscen za mapiranje svakog Dto objekta

Use case-ove sam podesila tako da admini mogu da izvrse sve (jwt token je postavljen da istice za sat vremena),
pored toga neautorizovan korisnik moze da odradi get kategorija, proizvoda i velicina kao i da odradi register i login,
a autorizovan korisnik pored toga moze da odradi i postavljanje ordera (kupovinu).

Admin nalozi su: andjela@gmail.com i luka.lukic@gmail.com, dok je password za oba naloga "pass123". Oba naloga imaju sve privilegije.
