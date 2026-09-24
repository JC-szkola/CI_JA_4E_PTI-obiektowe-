// ObservableCollection powiadamia interfejs (CollectionView w XAML) o każdej zmianie
// swojej zawartości - to dzięki niej lista odświeża się automatycznie po dodaniu elementu,
// bez potrzeby ręcznego przeładowywania widoku czy restartu aplikacji.
using System.Collections.ObjectModel;

namespace NotatkiMobilne;

// "partial" oznacza, że ta klasa jest połączona z plikiem MainPage.xaml (patrz x:Class tam).
// InitializeComponent() (wywoływane w konstruktorze) wczytuje i buduje wszystkie kontrolki
// zdefiniowane w XAML-u, dzięki czemu można się do nich odwołać po x:Name (np. NoteEntry).
public partial class MainPage : ContentPage
{
    // Kolekcja notatek. Właściwość publiczna, żeby XAML mógł się do niej dowiązać
    // przez "{Binding Notes}" w CollectionView.
    public ObservableCollection<string> Notes { get; set; }

    public MainPage()
    {
        InitializeComponent();

        // Dane początkowe - wymagane trzy notatki widoczne od razu po uruchomieniu.
        Notes = new ObservableCollection<string>
        {
            "Kupić mleko i chleb",
            "Zadzwonić do dentysty",
            "Oddać książkę do biblioteki"
        };

        // BindingContext = this sprawia, że wszystkie wyrażenia "{Binding ...}" w XAML
        // (np. {Binding Notes}) szukają właściwości właśnie w tej klasie MainPage.
        BindingContext = this;
    }

    // Metoda podpięta w XAML jako Clicked="OnAddButtonClicked" na przycisku DODAJ.
    // "sender" to obiekt, który wywołał zdarzenie (tu: przycisk), "e" to dodatkowe
    // dane zdarzenia - w tym prostym przypadku żadnego z nich nie potrzebujemy.
    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        // Pobieramy aktualnie wpisany tekst z pola Entry (odwołanie po x:Name z XAML).
        var text = NoteEntry.Text;

        // Zabezpieczenie: nie dodajemy pustych notatek ani samych spacji.
        if (!string.IsNullOrWhiteSpace(text))
        {
            // Dodanie do kolekcji automatycznie odświeża listę na ekranie
            // (to właśnie zasługa ObservableCollection).
            Notes.Add(text);

            // Czyścimy pole edycyjne, żeby było gotowe na kolejny wpis.
            NoteEntry.Text = string.Empty;
        }
    }
}