# Student Registry

Εφαρμογή ASP.NET Core MVC για καταχώρηση και διαχείριση μαθητών.

## Λειτουργίες

- Λίστα μαθητών με αναζήτηση βάσει ονόματος ή email
- Προσθήκη, επεξεργασία και διαγραφή μαθητή (CRUD)
- Έλεγχος πεδίων στον browser και στον server (Data Annotations)
- Έλεγχος για διπλό email
- Μηνύματα επιβεβαίωσης μετά από κάθε ενέργεια
- Responsive εμφάνιση με Bootstrap 5

## Τεχνολογίες

- .NET 10, ASP.NET Core MVC
- Razor Views, Tag Helpers
- Bootstrap 5, jQuery Validation

## Δομή

```
Controllers/
  HomeController.cs        Αρχική και σελίδα απορρήτου
  StudentsController.cs    Λίστα, προσθήκη, επεξεργασία, διαγραφή
Models/
  Student.cs               Μοντέλο μαθητή με κανόνες ελέγχου
Services/
  StudentStore.cs          Αποθήκευση στη μνήμη
Views/
  Home/                    Αρχική, Απόρρητο
  Students/                Index, Create, Edit, Delete, _StudentForm
```

## Εκτέλεση

Χρειάζεται το [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
dotnet run
```

Μετά άνοιξε τη διεύθυνση που εμφανίζεται στο τερματικό, π.χ. `http://localhost:5199`.

Εναλλακτικά, άνοιξε το `studentregistry.sln` στο Visual Studio και πάτα **F5**.

## Σημείωση

Τα δεδομένα κρατιούνται στη μνήμη, οπότε χάνονται όταν σταματήσει η εφαρμογή. Επόμενο βήμα θα ήταν η αποθήκευση σε βάση δεδομένων με Entity Framework Core.
