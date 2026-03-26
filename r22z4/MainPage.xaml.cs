using System.Numerics;

namespace r22z4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private List<string> ValidateRegistrationForm()
        {
            List<string> errors = new List<string>();

            string email = EmailEntry.Text ?? string.Empty;
            string password = PasswordEntry.Text ?? string.Empty;
            string confirmPassword = ConfirmPasswordEntry.Text ?? string.Empty;
            string ageText = AgeEntry.Text ?? string.Empty;
            bool termsAccepted = TermsCheckBox.IsChecked;

            if (string.IsNullOrEmpty(email) || !email.Contains('@') || !email.Contains('.')) errors.Add("Email jest nieprawidlowy. Sprawdz dane i obecnosc znaku @ i .");
            if (!IsPasswordStrong(password)) errors.Add("Haslo jest zbyt krotkie lub nie zawiera duzej litery i liczby");
            if (confirmPassword != password) errors.Add("Potwierdzenie rozni sie od hasla");
            if (!int.TryParse(ageText, out int age) || age < 13 || age > 120)  errors.Add("Podany wiek jest nieprawidlowy (mus byc w przedziale 13 - 120)");
            if (termsAccepted == false) errors.Add("Nie zaznaczyles okienka akceptacji");

            // TODO: Implementujcie wszystkie walidacje 
            // Email: nie pusty, zawiera @ i . 
            // Hasło: nie puste, min 8 znaków, cyfra, wielka litera 
            // Potwierdzenie: nie puste, zgadza się z hasłem 
            // Wiek: liczba, między 13 a 120 
            // Regulamin: musi być zaznaczony 

            return errors;
        }
        private bool IsPasswordStrong(string password)
        {
            if (password.Length >= 8 && password.Any(char.IsDigit) && password.Any(char.IsUpper)) return true;
            else return false;

            // TODO: Sprawdzić, czy hasło ma: 
            // – co najmniej 8 znaków 
            // – co najmniej 1 cyfrę 
            // – co najmniej 1 wielką literę 
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            List<string> errors = ValidateRegistrationForm();

            if (errors.Count > 0)
            {
                string errorMessage = string.Join("\n• ", errors);
                DisplayAlert("Błędy walidacji", "• " + errorMessage, "OK");
            }
            else
            {
                DisplayAlert("Sukces", "Rejestracja zakończona pomyślnie!", "OK");
                // Czyszczenie pól 

                EmailEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;
                ConfirmPasswordEntry.Text = string.Empty;
                AgeEntry.Text = string.Empty;
                TermsCheckBox.IsChecked = false;
            }
        }
    }
}

/*
*********************** 
nazwa funkcji: ValidateRegistrationForm
opis funkcji: lista wszystkich danych formularza ktora zwraca bledy jezeli dane sa bledne
parametry: brak
zwracany typ i opis: errors - bledy pol formularza ktore se nie zgadzaja
autor: Karol Slotwinski
***********************
nazwa funkcji: IsPasswordStrong
opis funkcji: Sprawdza czy haslo zawiera  >= 8 znakow, cyfre i wielka litere
parametry: string password
zwracany typ i opis: bool przechowujacy info czy haslo jest mocne czy slabe
autor: Karol Slotwinski
***********************
nazwa funkcji: OnRegisterClicked
opis funkcji: po kliknieciu przycisku sprawdza czy sa jakeis bledu i wyswietla wszystkie nieprawidlowosci albo alert z potwierdzeniem rejestracji i czysci pola
parametry: object sender, EventArgs e
zwracany typ i opis: brak
autor: Karol Slotwinski
***********************
*/
