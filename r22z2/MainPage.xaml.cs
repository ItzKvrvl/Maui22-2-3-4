using System.Threading.Tasks;

namespace r22z2
{
    public partial class MainPage : ContentPage
    {
        bool EmailCorrect = false;
        bool PasswordCorrect = false;
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnEmailTextChanged(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            if (email.Contains('@') && email.Contains('.')) { EmailCorrect = true; EmailErrorLabel.IsVisible = false; }
            else { EmailCorrect = false; EmailErrorLabel.IsVisible = true; }
            UpdateLoginButtonColor();
        }
        private void OnPasswordTextChanged(object sender, EventArgs e)
        {
            if (PasswordEntry.Text.Length >= 6) { PasswordCorrect = true; PasswordErrorLabel.IsVisible = false; }
            else { PasswordCorrect = false; PasswordErrorLabel.IsVisible = true; }
            UpdateLoginButtonColor();
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (EmailCorrect == true && PasswordCorrect == true) await DisplayAlert("Sukces", "Zalogowano pomyślnie!", "ok");
            else await DisplayAlert("Blad", "dane nie sa poprawne", "ok");
        }
        private void UpdateLoginButtonColor()
        {
            bool isValid = EmailCorrect && PasswordCorrect;

            LoginButton.IsEnabled = isValid;
            LoginButton.Background = isValid ? Colors.Green : Colors.Gray;
        }
    }
}

/*
****************************
nazwa funkcji: OnEmailTextChanged
opis funkcji: sprawdza czy tekst w polu email zawiera @ i . oraz ustawia odpowiednio zmienna EmailCorrect
parametry: object sender, EventArgs e
zwracany typ i opis: brak
autor: Karol Słotwiński
****************************
nazwa funkcji: OnPasswordTextChanged
opis funkcji: sprawdza czy tekst w polu hasla awiera przynajmniuej 6 znakow oraz ustawia odpowiednio zmienna PasswordCorrect
parametry: object sender, EventArgs e
zwracany typ i opis: brak
autor: Karol Słotwiński
****************************
nazwa funkcji: OnLoginClicked
opis funkcji: po kliknieciu przycisku wyswietla alert powodzenia/bledu logowania
parametry: object sender, EventArgs e
zwracany typ i opis: brak
autor: Karol Słotwiński
****************************
nazwa funkcji: UpdateLoginButtonColor()
opis funkcji: jesli oba pola sa poprawnie wypelnione funkcja zmienia kolor przycisku na zielony
parametry brak
zwracany typ i opis: brak
autor: Karol Słotwiński
****************************
*/
