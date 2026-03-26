using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace r22z3
{
    public class PasswordStrengthBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty StrengthLabelProperty =
         BindableProperty.Create(
          "StrengthLabel",
          typeof(Label),
          typeof(PasswordStrengthBehavior),
          null);

        public Label StrengthLabel
        {
            get { return (Label)GetValue(StrengthLabelProperty); }
            set { SetValue(StrengthLabelProperty, value); }
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string password = e.NewTextValue ?? string.Empty;
            string strength = EvaluatePasswordStrength(password);

            if (StrengthLabel != null)
            {
                StrengthLabel.Text = strength;

                if (strength == "Słabe")
                    StrengthLabel.TextColor = Colors.Red;
                else if (strength == "Średnie")
                    StrengthLabel.TextColor = Colors.Orange;
                else if (strength == "Silne")
                    StrengthLabel.TextColor = Colors.Green;
            }
        }

        private string EvaluatePasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "";

            bool hasDigit = password.Any(c => char.IsDigit(c));
            bool hasUpperCase = password.Any(c => char.IsUpper(c));

            if (password.Length < 8)
                return "Słabe";
            else if (hasDigit && hasUpperCase)
                return "Silne";
            else if (hasDigit)
                return "Średnie";
            else
                return "Słabe";
        }
    }
}

/*
*********************** 
nazwa funkcji: StrengthLabel
opis funkcji: Pobiera lub ustawia Label, ktora wyswietla informacje o sile hasla
parametry: brak
zwracany typ i opis: Label - obiekt przypisany do zachowania
autor: Karol Slotwinski
***********************
nazwa funkcji: OnAttachedTo
opis funkcji: pilnuje zdarzenia zmiany tekstu
parametry: Entry entry - kontrolka, do ktorej podpinane jest zachowanie
zwracany typ i opis: void
autor: Karol Slotwinski
***********************
nazwa funkcji: OnDetachingFrom
opis funkcji: Wywolywana w momencie odpinania zachowania od kontrolki
parametry: Entry entry - kontrolka, od ktorej odpinane jest zachowanie
zwracany typ i opis: void
autor: Karol Slotwinski
***********************
nazwa funkcji: OnEntryTextChanged
opis funkcji: Obsluguje zdarzenie zmiany tekstu w polu Entry; ocenia sile hasla i aktualizuje tekst oraz kolor etykiety StrengthLabel
parametry: object sender, TextChangedEventArgs e
zwracany typ i opis: brak
autor: Karol Slotwinski
***********************
nazwa funkcji: EvaluatePasswordStrength
opis funkcji: sprawdza jakie cechy ma haslo (duze litery, liczby) i wyswietla odpowiedni komunikat
parametry: string password
zwracany typ i opis: string - informacje o sile hasla
autor: Karol Slotwinski
***********************
*/