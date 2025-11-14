using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CiccioGest.Presentation.WpfApp.Converters
{
    // Converte un oggetto Indirizzo in una singola riga di anteprima.
    public class IndirizzoToStringConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;

            // Se l'oggetto è già una stringa (eventualità), la ritorniamo
            if (value is string s) return s;

            // Tentiamo il cast verso la tua classe Indirizzo
            var indirizzo = value as dynamic;
            if (indirizzo == null) return string.Empty;

            // Costruiamo la riga in modo robusto; evitiamo valori null/empty
            var parts = new StringBuilder();

            void Add(string? part)
            {
                if (!string.IsNullOrWhiteSpace(part))
                {
                    if (parts.Length > 0) parts.Append(", ");
                    parts.Append(part.Trim());
                }
            }

            try
            {
                Add((string?)indirizzo.Via);
                Add((string?)indirizzo.Civico);
                Add((string?)indirizzo.CAP);
                Add((string?)indirizzo.Citta);
                Add((string?)indirizzo.Stato);
            }
            catch
            {
                // Se la shape dell'oggetto non è quella attesa, proviamo reflection (fallback)
                try
                {
                    var type = value.GetType();
                    Add(type.GetProperty("Via")?.GetValue(value)?.ToString());
                    Add(type.GetProperty("Civico")?.GetValue(value)?.ToString());
                    Add(type.GetProperty("CAP")?.GetValue(value)?.ToString());
                    Add(type.GetProperty("Citta")?.GetValue(value)?.ToString());
                    Add(type.GetProperty("Stato")?.GetValue(value)?.ToString());
                }
                catch
                {
                    return string.Empty;
                }
            }

            return parts.ToString();
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // Non necessario per la preview; implementazione semplice per completeness
            if (value is string s && targetType != null)
            {
                var result = Activator.CreateInstance(targetType);

                if (result == null) return Binding.DoNothing;

                // Tentativo naive: splitta la stringa e assegna per ordine (Via, Civico, CAP, Citta, Stato)
                var tokens = s.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    var props = new[] { "Via", "Civico", "CAP", "Citta", "Stato" };
                    for (int i = 0; i < Math.Min(tokens.Length, props.Length); i++)
                    {
                        var prop = targetType.GetProperty(props[i]);
                        if (prop?.CanWrite == true)
                        {
                            prop.SetValue(result, tokens[i].Trim());
                        }
                    }
                    return result;
                }
                catch
                {
                    return Binding.DoNothing;
                }
            }

            return Binding.DoNothing;
        }
    }
}
