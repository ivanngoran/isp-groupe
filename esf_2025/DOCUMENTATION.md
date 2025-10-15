# Documentation - Générateur de Mapping ESF 2025

## Vue d'ensemble

Ce document décrit les règles de nommage et les correspondances de types utilisées pour générer le fichier de mapping des colonnes de l'enquête ESF (Enquête Services Financiers) 2025 pour la Côte d'Ivoire.

## Structure du fichier de mapping

Le fichier `esf_2025_colonnes_mapping.txt` contient une ligne par colonne avec 6 champs séparés par des tabulations (TAB) :

```
CODE	TYPE	NAME_FR	NAME_EN	LABEL_FR	LABEL_EN
```

### Description des champs

1. **CODE** : Identifiant de la colonne en format snake_case majuscules
   - Version codifiée du nom anglais
   - Uniquement lettres, chiffres et underscores
   - Exemple : `REVENU_MENSUEL_PRINCIPAL`

2. **TYPE** : Type de données de la colonne
   - Voir section "Types de données" ci-dessous

3. **NAME_FR** : Nom français simplifié
   - Version courte et lisible du label
   - Commence par une majuscule
   - Exemple : `Revenu principal`

4. **NAME_EN** : Traduction anglaise du nom simplifié
   - Version anglaise du NAME_FR
   - Chaque mot commence par une majuscule
   - Exemple : `Main Income`

5. **LABEL_FR** : Libellé exact du fichier source
   - Label complet original en français
   - Exemple : `Revenu mensuel de l'activité principale`

6. **LABEL_EN** : Traduction anglaise du libellé
   - Traduction complète du LABEL_FR
   - Exemple : `Monthly income from main activity`

## Types de données

### SSTR - Short String (Texte court)
- **Description** : Chaîne de caractères courte (≤ 150 caractères)
- **Utilisation** : 
  - Noms, prénoms
  - Codes, identifiants
  - Catégories simples
  - Réponses courtes
- **Exemples** : `Sexe`, `Zone`, `Type de compte`, `Statut matrimonial`

### LSTR - Long String (Texte long)
- **Description** : Chaîne de caractères longue (> 150 caractères)
- **Utilisation** :
  - Descriptions détaillées
  - Commentaires
  - Observations
  - Adresses complètes
- **Exemples** : `Observations`, `Commentaires additionnels`, `Description détaillée`

### EMAL - Email
- **Description** : Adresse email
- **Utilisation** : Tout champ contenant une adresse email
- **Format attendu** : `utilisateur@domaine.ext`
- **Exemples** : `Email`, `Adresse email`, `Contact email`

### TELP - Telephone
- **Description** : Numéro de téléphone
- **Utilisation** : Numéros de téléphone fixe ou mobile
- **Format attendu** : Formats ivoiriens ou internationaux
- **Exemples** : `Téléphone principal`, `Téléphone secondaire`, `Contact mobile`

### INTE - Integer (Nombre entier)
- **Description** : Nombre entier (sans décimales)
- **Utilisation** :
  - Âges
  - Quantités, effectifs
  - Montants en FCFA (généralement sans centimes)
  - Scores de satisfaction (échelles)
  - Durées en unités entières
- **Exemples** : `Âge`, `Nombre de personnes`, `Montant crédit`, `Satisfaction (échelle 1-5)`

### DECI - Decimal (Nombre décimal)
- **Description** : Nombre à virgule (avec décimales)
- **Utilisation** :
  - Taux (intérêt, pourcentage)
  - Moyennes calculées
  - Mesures précises
- **Exemples** : `Taux d'intérêt`, `Moyenne mensuelle`, `Pourcentage`

### DATE - Date courte
- **Description** : Date sans heure
- **Format** : `yyyy-MM-dd` (ISO 8601)
- **Utilisation** :
  - Dates de naissance
  - Dates d'événements
  - Dates de référence
- **Exemples** : `Date de naissance`, `Date d'ouverture compte`, `Date enquête`

### DATI - Date/Time (Date longue)
- **Description** : Date avec heure
- **Format** : `yyyy-MM-dd HH:mm` ou `yyyy-MM-dd HH:mm:ss`
- **Utilisation** :
  - Horodatages précis
  - Heures d'événements
- **Exemples** : `Heure début enquête`, `Heure fin enquête`, `Timestamp création`

## Règles de détection automatique des types

Le programme applique les règles suivantes pour détecter automatiquement le type de données :

### 1. EMAL (Email)
Mots-clés : `email`, `e-mail`, `courriel`

### 2. TELP (Téléphone)
Mots-clés : `téléphone`, `telephone`, `phone`, `mobile`, `tel`, `contact`

### 3. DATI (Date avec heure)
Mots-clés : `heure`, `time`, `timestamp`

### 4. DATE (Date)
Mots-clés : `date`, `année`, `annee`, `year`, `naissance`

### 5. DECI (Décimal)
Mots-clés : `taux`, `rate`, `pourcentage`, `percentage`, `moyenne`, `average`

### 6. INTE (Entier)
Mots-clés : `nombre`, `number`, `âge`, `age`, `montant`, `amount`, `revenu`, `income`, `salaire`, `salary`, `coût`, `cout`, `cost`, `prix`, `price`, `effectif`, `quantité`, `quantite`, `satisfaction`, `note`, `score`

### 7. LSTR (Texte long)
Mots-clés : `description`, `commentaire`, `comment`, `observation`, `remarque`, `détail`, `detail`, `adresse complète`

### 8. SSTR (Texte court)
Par défaut pour tous les autres cas

## Règles de création du CODE

Le code est généré à partir du nom anglais selon les règles suivantes :

### 1. Traduction en anglais
- Application du dictionnaire de traduction (voir section ci-dessous)
- Suppression des accents et caractères spéciaux

### 2. Nettoyage
- Suppression des articles : `the`, `a`, `an`
- Suppression des prépositions : `of`, `from`, `to`, `for`, `with`, `in`, `on`, `at`, `by`
- Suppression des conjonctions : `and`, `or`

### 3. Formatage
- Remplacement des espaces et tirets par underscore `_`
- Suppression des caractères spéciaux
- Suppression des underscores multiples
- Conversion en majuscules

### Exemples de transformation

| Label original | Traduction anglaise | CODE |
|----------------|---------------------|------|
| Âge | age | AGE |
| Revenu mensuel | monthly income | MONTHLY_INCOME |
| Satisfaction vis-à-vis de la qualité | satisfaction quality | SATISFACTION_QUALITY |
| Type de compte bancaire | type bank account | TYPE_BANK_ACCOUNT |

## Règles de simplification des noms

Les noms simplifiés (NAME_FR et NAME_EN) sont créés selon les règles suivantes :

### 1. Suppression des détails
- Expressions entre parenthèses : `(détail)` → supprimé
- Détails après virgule ou point-virgule : `, détail` → supprimé
- Expressions de relation : `vis-à-vis de`, `concernant`, `à propos de` → supprimées

### 2. Capitalisation
- NAME_FR : Première lettre en majuscule
- NAME_EN : Première lettre de chaque mot en majuscule (Title Case)

### Exemples

| LABEL_FR | NAME_FR | NAME_EN |
|----------|---------|---------|
| Satisfaction vis-à-vis de la qualité générale des produits offerts | Satisfaction | Satisfaction |
| Revenu mensuel de l'activité principale | Revenu mensuel | Monthly Income |
| Nombre de visites à l'agence par mois | Nombre de visites | Number Visits |

## Dictionnaire de traduction

Le programme utilise un dictionnaire complet de traduction français-anglais pour les termes spécifiques au domaine :

### Informations personnelles
- âge → age
- sexe → gender
- nom → name
- prénom → first_name
- date de naissance → date_of_birth
- nationalité → nationality

### Géographie
- zone → area
- région → region
- district → district
- département → department
- commune → municipality
- village → village
- quartier → neighborhood
- adresse → address

### Activité économique
- revenu → income
- salaire → salary
- activité → activity
- profession → occupation
- emploi → employment
- secteur → sector
- entreprise → company

### Services financiers
- compte bancaire → bank_account
- banque → bank
- crédit → credit
- prêt → loan
- épargne → savings
- assurance → insurance
- mobile money → mobile_money
- transfert → transfer
- transaction → transaction

### Satisfaction et qualité
- satisfaction → satisfaction
- qualité → quality
- service → service
- produit → product

### Temps
- durée → duration
- fréquence → frequency
- date → date
- année → year
- mois → month
- jour → day

### Montants
- montant → amount
- coût → cost
- prix → price
- frais → fees
- taux → rate

## Utilisation du programme

### Prérequis
- .NET Framework 4.5 ou supérieur
- Ou .NET Core 3.1 / .NET 5+ pour la compilation cross-platform

### Compilation

```bash
# Windows avec .NET Framework
csc ColumnMappingGenerator.cs

# Linux/Mac/Windows avec .NET Core/5+
dotnet build ColumnMappingGenerator.cs
```

### Exécution

```bash
# Utilisation par défaut (fichiers dans le répertoire courant)
ColumnMappingGenerator.exe

# Spécification des fichiers
ColumnMappingGenerator.exe fichier_source.txt fichier_sortie.txt
```

### Paramètres

1. **Premier argument** (optionnel) : Chemin du fichier source
   - Par défaut : `esf_2025_applatit.txt`

2. **Deuxième argument** (optionnel) : Chemin du fichier de sortie
   - Par défaut : `esf_2025_colonnes_mapping.txt`

### Exemple

```bash
ColumnMappingGenerator.exe esf_2025_applatit.txt esf_2025_colonnes_mapping.txt
```

## Format du fichier source

Le fichier source doit être un fichier texte avec :
- Encodage : UTF-8
- Séparateur : Tabulation (TAB)
- Première ligne : En-têtes de colonnes en français
- Les lignes suivantes sont ignorées (seuls les en-têtes sont nécessaires)

## Format du fichier de sortie

Le fichier de sortie généré contient :
- Encodage : UTF-8
- Séparateur : Tabulation (TAB)
- Une ligne par colonne source
- Pas d'en-tête (les données commencent directement)

## Personnalisation

Pour adapter le générateur à d'autres contextes :

### Ajouter des traductions
Modifier le dictionnaire `TranslationDictionary` dans le code :

```csharp
{"terme_français", "english_term"}
```

### Modifier les règles de détection de type
Modifier la méthode `DetectDataType()` pour ajouter de nouvelles règles :

```csharp
if (lowerName.Contains("nouveau_motcle"))
    return DataType.NOUVEAU_TYPE;
```

### Ajouter de nouveaux types
Ajouter une valeur à l'énumération `DataType` :

```csharp
public enum DataType
{
    // ... types existants ...
    NEWT  // Nouveau type
}
```

## Exemples de lignes générées

```
AGE	INTE	Âge	Age	Âge	Age
SEXE	SSTR	Sexe	Gender	Sexe	Gender
ZONE	SSTR	Zone	Area	Zone	Area
REVENU_MENSUEL_PRINCIPAL	INTE	Revenu mensuel	Monthly Income	Revenu mensuel de l'activité principale	Monthly income main activity
SATISFACTION_QUALITE_GENERALE	INTE	Satisfaction	Satisfaction	Satisfaction vis-à-vis de la qualité générale des produits offerts	Satisfaction general quality products offered
EMAIL	EMAL	Email	Email	Email	Email
TELEPHONE_PRINCIPAL	TELP	Téléphone principal	Main Phone	Téléphone principal	Main phone
DATE_ENQUETE	DATE	Date enquête	Survey Date	Date enquête	Survey date
HEURE_DEBUT_ENQUETE	DATI	Heure début enquête	Start Time Survey	Heure début enquête	Start time survey
TAUX_INTERET_CREDIT	DECI	Taux intérêt crédit	Interest Rate Credit	Taux intérêt crédit	Interest rate credit
```

## Maintenance et évolution

### Version actuelle : 1.0
- Date de création : Octobre 2025
- Auteur : I.S.P. (Ivoire Services et Protections)
- Contexte : Enquête Services Financiers Côte d'Ivoire 2025

### Historique des modifications
- v1.0 (2025-10) : Version initiale

## Support et contact

Pour toute question ou suggestion d'amélioration :
- Email : info@isp-groupe.ci
- Téléphone : 01 03 45 41 19 / 07 05 94 73 66
- Adresse : Abidjan Bingerville, Côte d'Ivoire

## Licence

© 2025 Ivoire Services et Protections (I.S.P.)
Tous droits réservés.
