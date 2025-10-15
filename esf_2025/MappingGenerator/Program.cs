using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ESF2025
{
    /// <summary>
    /// Générateur de mapping pour les colonnes du fichier ESF 2025
    /// </summary>
    public class ColumnMappingGenerator
    {
        // Dictionnaire de traduction français-anglais pour les termes courants
        private static readonly Dictionary<string, string> TranslationDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            // Informations personnelles
            {"âge", "age"},
            {"age", "age"},
            {"sexe", "gender"},
            {"genre", "gender"},
            {"nom", "name"},
            {"prénom", "first_name"},
            {"prenom", "first_name"},
            {"date de naissance", "date_of_birth"},
            {"lieu de naissance", "place_of_birth"},
            {"nationalité", "nationality"},
            {"nationalite", "nationality"},
            
            // Géographie
            {"zone", "area"},
            {"région", "region"},
            {"region", "region"},
            {"district", "district"},
            {"département", "department"},
            {"departement", "department"},
            {"commune", "municipality"},
            {"village", "village"},
            {"localité", "locality"},
            {"localite", "locality"},
            {"quartier", "neighborhood"},
            {"adresse", "address"},
            
            // Activité économique
            {"revenu", "income"},
            {"revenu mensuel", "monthly_income"},
            {"revenu annuel", "annual_income"},
            {"salaire", "salary"},
            {"activité", "activity"},
            {"activite", "activity"},
            {"activité principale", "main_activity"},
            {"activite principale", "main_activity"},
            {"activité secondaire", "secondary_activity"},
            {"activite secondaire", "secondary_activity"},
            {"profession", "occupation"},
            {"emploi", "employment"},
            {"secteur", "sector"},
            {"entreprise", "company"},
            
            // Éducation
            {"niveau d'instruction", "education_level"},
            {"niveau d'éducation", "education_level"},
            {"niveau scolaire", "school_level"},
            {"diplôme", "diploma"},
            {"diplome", "diploma"},
            {"formation", "training"},
            
            // Services financiers
            {"compte bancaire", "bank_account"},
            {"banque", "bank"},
            {"institution financière", "financial_institution"},
            {"crédit", "credit"},
            {"credit", "credit"},
            {"prêt", "loan"},
            {"pret", "loan"},
            {"épargne", "savings"},
            {"epargne", "savings"},
            {"assurance", "insurance"},
            {"mobile money", "mobile_money"},
            {"transfert", "transfer"},
            {"transaction", "transaction"},
            
            // Satisfaction
            {"satisfaction", "satisfaction"},
            {"qualité", "quality"},
            {"qualite", "quality"},
            {"service", "service"},
            {"produit", "product"},
            {"général", "general"},
            {"generale", "general"},
            
            // Temps
            {"durée", "duration"},
            {"duree", "duration"},
            {"fréquence", "frequency"},
            {"frequence", "frequency"},
            {"date", "date"},
            {"année", "year"},
            {"annee", "year"},
            {"mois", "month"},
            {"jour", "day"},
            
            // Montants
            {"montant", "amount"},
            {"coût", "cost"},
            {"cout", "cost"},
            {"prix", "price"},
            {"frais", "fees"},
            {"taux", "rate"},
            
            // Autres termes courants
            {"nombre", "number"},
            {"type", "type"},
            {"catégorie", "category"},
            {"categorie", "category"},
            {"statut", "status"},
            {"état", "state"},
            {"etat", "state"},
            {"oui/non", "yes_no"},
            {"principal", "main"},
            {"secondaire", "secondary"},
            {"total", "total"},
            {"moyenne", "average"},
            {"minimum", "minimum"},
            {"maximum", "maximum"}
        };

        /// <summary>
        /// Types de données disponibles
        /// </summary>
        public enum DataType
        {
            SSTR, // Texte court (≤150 caractères)
            LSTR, // Texte long (>150 caractères)
            EMAL, // Adresse email
            TELP, // Téléphone
            INTE, // Nombre entier
            DECI, // Nombre décimal
            DATE, // Date courte au format yyyy-MM-dd
            DATI  // Date longue au format yyyy-MM-dd HH:mm
        }

        /// <summary>
        /// Détecte le type de données basé sur le nom de la colonne
        /// </summary>
        private static DataType DetectDataType(string columnName)
        {
            string lowerName = columnName.ToLower();
            
            // Email
            if (lowerName.Contains("email") || lowerName.Contains("e-mail") || lowerName.Contains("courriel"))
                return DataType.EMAL;
            
            // Téléphone
            if (lowerName.Contains("téléphone") || lowerName.Contains("telephone") || lowerName.Contains("phone") || 
                lowerName.Contains("mobile") || lowerName.Contains("tel") || lowerName.Contains("contact"))
                return DataType.TELP;
            
            // Date avec heure
            if (lowerName.Contains("heure") || lowerName.Contains("time") || lowerName.Contains("timestamp"))
                return DataType.DATI;
            
            // Date
            if (lowerName.Contains("date") || lowerName.Contains("année") || lowerName.Contains("annee") || 
                lowerName.Contains("year") || lowerName.Contains("naissance"))
                return DataType.DATE;
            
            // Nombres décimaux
            if (lowerName.Contains("taux") || lowerName.Contains("rate") || lowerName.Contains("pourcentage") || 
                lowerName.Contains("percentage") || lowerName.Contains("moyenne") || lowerName.Contains("average"))
                return DataType.DECI;
            
            // Nombres entiers
            if (lowerName.Contains("nombre") || lowerName.Contains("number") || lowerName.Contains("âge") || 
                lowerName.Contains("age") || lowerName.Contains("montant") || lowerName.Contains("amount") ||
                lowerName.Contains("revenu") || lowerName.Contains("income") || lowerName.Contains("salaire") ||
                lowerName.Contains("salary") || lowerName.Contains("coût") || lowerName.Contains("cout") ||
                lowerName.Contains("cost") || lowerName.Contains("prix") || lowerName.Contains("price") ||
                lowerName.Contains("effectif") || lowerName.Contains("quantité") || lowerName.Contains("quantite") ||
                lowerName.Contains("satisfaction") || lowerName.Contains("note") || lowerName.Contains("score"))
                return DataType.INTE;
            
            // Texte long
            if (lowerName.Contains("description") || lowerName.Contains("commentaire") || lowerName.Contains("comment") ||
                lowerName.Contains("observation") || lowerName.Contains("remarque") || lowerName.Contains("détail") ||
                lowerName.Contains("detail") || lowerName.Contains("adresse complète") || lowerName.Contains("adresse complete"))
                return DataType.LSTR;
            
            // Par défaut: texte court
            return DataType.SSTR;
        }

        /// <summary>
        /// Traduit un texte français en anglais
        /// </summary>
        private static string TranslateToEnglish(string frenchText)
        {
            string result = frenchText.ToLower();
            
            // Remplacer les termes connus
            foreach (var kvp in TranslationDictionary)
            {
                result = Regex.Replace(result, @"\b" + Regex.Escape(kvp.Key) + @"\b", kvp.Value, RegexOptions.IgnoreCase);
            }
            
            // Nettoyer les caractères spéciaux
            result = RemoveDiacritics(result);
            
            return result;
        }

        /// <summary>
        /// Crée un code (nom de variable) à partir du texte anglais
        /// </summary>
        private static string CreateCode(string englishText)
        {
            string code = englishText;
            
            // Supprimer les articles et prépositions
            code = Regex.Replace(code, @"\b(the|a|an|of|from|to|for|with|in|on|at|by|and|or)\b", "", RegexOptions.IgnoreCase);
            
            // Remplacer espaces et tirets par underscore
            code = Regex.Replace(code, @"[\s\-']+", "_");
            
            // Supprimer les caractères spéciaux
            code = Regex.Replace(code, @"[^a-zA-Z0-9_]", "");
            
            // Supprimer les underscores multiples
            code = Regex.Replace(code, @"_+", "_");
            
            // Supprimer les underscores au début et à la fin
            code = code.Trim('_');
            
            // Convertir en majuscules
            code = code.ToUpper();
            
            return code;
        }

        /// <summary>
        /// Crée un nom simplifié à partir du label
        /// </summary>
        private static string CreateSimplifiedName(string label)
        {
            // Supprimer les expressions entre parenthèses
            string simplified = Regex.Replace(label, @"\([^)]*\)", "");
            
            // Supprimer les détails après virgule, point-virgule, ou tiret
            simplified = Regex.Replace(simplified, @"[,;:–—-].*$", "");
            
            // Supprimer "vis-à-vis de", "concernant", etc.
            simplified = Regex.Replace(simplified, @"\b(vis-à-vis de|vis-a-vis de|concernant|à propos de|relatif à|par rapport à)\b.*$", "", RegexOptions.IgnoreCase);
            
            // Nettoyer les espaces
            simplified = simplified.Trim();
            
            return simplified;
        }

        /// <summary>
        /// Supprime les accents et diacritiques
        /// </summary>
        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Génère une ligne de mapping pour une colonne
        /// </summary>
        public static string GenerateMappingLine(string labelFr)
        {
            // Déterminer le type de données
            DataType dataType = DetectDataType(labelFr);
            
            // Créer le nom simplifié français
            string nameFr = CreateSimplifiedName(labelFr);
            
            // Traduire en anglais
            string nameEn = TranslateToEnglish(nameFr);
            
            // Créer le code
            string code = CreateCode(nameEn);
            
            // Traduire le label complet
            string labelEn = TranslateToEnglish(labelFr);
            
            // Capitaliser la première lettre des noms
            nameFr = CapitalizeFirstLetter(nameFr);
            nameEn = CapitalizeWords(nameEn);
            labelEn = CapitalizeFirstLetter(labelEn);
            
            // Format: CODE\tTYPE\tNAME_FR\tNAME_EN\tLABEL_FR\tLABEL_EN
            return $"{code}\t{dataType}\t{nameFr}\t{nameEn}\t{labelFr}\t{labelEn}";
        }

        private static string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            
            return char.ToUpper(text[0]) + text.Substring(1);
        }

        private static string CapitalizeWords(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            
            var words = text.Split('_');
            return string.Join(" ", words.Select(w => CapitalizeFirstLetter(w)));
        }

        /// <summary>
        /// Génère le fichier de mapping complet
        /// </summary>
        public static void GenerateMappingFile(string inputFile, string outputFile)
        {
            if (!File.Exists(inputFile))
            {
                throw new FileNotFoundException($"Le fichier source {inputFile} n'existe pas.");
            }

            var lines = new List<string>();
            
            // Lire la première ligne (en-têtes)
            using (var reader = new StreamReader(inputFile))
            {
                var headerLine = reader.ReadLine();
                if (headerLine != null)
                {
                    var headers = headerLine.Split('\t');
                    
                    foreach (var header in headers)
                    {
                        if (!string.IsNullOrWhiteSpace(header))
                        {
                            lines.Add(GenerateMappingLine(header.Trim()));
                        }
                    }
                }
            }

            // Écrire dans le fichier de sortie
            File.WriteAllLines(outputFile, lines, Encoding.UTF8);
            
            Console.WriteLine($"Fichier de mapping généré : {outputFile}");
            Console.WriteLine($"Nombre de colonnes traitées : {lines.Count}");
        }

        /// <summary>
        /// Point d'entrée du programme
        /// </summary>
        public static void Main(string[] args)
        {
            string inputFile = "esf_2025_applatit.txt";
            string outputFile = "esf_2025_colonnes_mapping.txt";
            
            if (args.Length >= 1)
                inputFile = args[0];
            if (args.Length >= 2)
                outputFile = args[1];

            try
            {
                Console.WriteLine("=== Générateur de Mapping ESF 2025 ===");
                Console.WriteLine($"Fichier source : {inputFile}");
                Console.WriteLine($"Fichier de sortie : {outputFile}");
                Console.WriteLine();
                
                GenerateMappingFile(inputFile, outputFile);
                
                Console.WriteLine();
                Console.WriteLine("Génération terminée avec succès!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                Environment.Exit(1);
            }
        }
    }
}
