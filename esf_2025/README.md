# Générateur de Mapping ESF 2025

## Description

Ce projet contient un générateur automatique de mapping pour les colonnes du fichier de données de l'**Enquête Services Financiers (ESF) 2025** en Côte d'Ivoire.

L'outil permet de transformer les en-têtes de colonnes françaises en un format structuré incluant :
- Codes normalisés (snake_case)
- Types de données détectés automatiquement
- Noms simplifiés en français et anglais
- Traductions complètes

## Contexte

L'enquête ESF 2025 collecte des données sur l'accès et l'utilisation des services financiers en Côte d'Ivoire. Le fichier source contient plus de **1000 colonnes** avec des libellés en français qu'il faut mapper vers un format exploitable pour l'analyse de données.

## Fichiers du projet

```
esf_2025/
├── ColumnMappingGenerator.cs      # Programme C# principal
├── esf_2025_applatit.txt          # Fichier source (en-têtes des colonnes)
├── esf_2025_colonnes_mapping.txt  # Fichier de sortie généré
├── DOCUMENTATION.md               # Documentation complète
└── README.md                      # Ce fichier
```

## Installation et utilisation

### Prérequis

- .NET Framework 4.5+ (Windows)
- OU .NET Core 3.1+ / .NET 5+ (Windows, Linux, macOS)

### Compilation

#### Windows (.NET Framework)
```bash
csc ColumnMappingGenerator.cs
```

#### Multi-plateforme (.NET Core/5+)
```bash
# Créer un projet
dotnet new console -n ESF2025Generator
# Copier le fichier source
cp ColumnMappingGenerator.cs ESF2025Generator/Program.cs
# Compiler
cd ESF2025Generator
dotnet build
```

### Exécution

#### Utilisation simple
```bash
# Windows
ColumnMappingGenerator.exe

# Linux/Mac (avec .NET Core)
dotnet run
```

#### Avec paramètres personnalisés
```bash
ColumnMappingGenerator.exe mon_fichier_source.txt mon_fichier_sortie.txt
```

### Sortie attendue

Le programme affiche :
```
=== Générateur de Mapping ESF 2025 ===
Fichier source : esf_2025_applatit.txt
Fichier de sortie : esf_2025_colonnes_mapping.txt

Fichier de mapping généré : esf_2025_colonnes_mapping.txt
Nombre de colonnes traitées : 118

Génération terminée avec succès!
```

## Format du fichier de sortie

Chaque ligne du fichier `esf_2025_colonnes_mapping.txt` contient 6 champs séparés par des tabulations :

```
CODE    TYPE    NAME_FR    NAME_EN    LABEL_FR    LABEL_EN
```

### Exemple
```
AGE	INTE	Âge	Age	Âge	Age
SEXE	SSTR	Sexe	Gender	Sexe	Gender
REVENU_MENSUEL_PRINCIPAL	INTE	Revenu mensuel	Monthly Income	Revenu mensuel de l'activité principale	Monthly income main activity
```

## Types de données

| Code | Type | Description |
|------|------|-------------|
| SSTR | Short String | Texte court (≤150 caractères) |
| LSTR | Long String | Texte long (>150 caractères) |
| EMAL | Email | Adresse email |
| TELP | Telephone | Numéro de téléphone |
| INTE | Integer | Nombre entier |
| DECI | Decimal | Nombre décimal |
| DATE | Date | Date au format yyyy-MM-dd |
| DATI | DateTime | Date avec heure yyyy-MM-dd HH:mm |

## Fonctionnalités principales

### 1. Détection automatique du type de données
Le programme analyse le nom de la colonne pour déterminer le type approprié :
- **Email** : détecté par les mots-clés `email`, `courriel`
- **Téléphone** : détecté par `téléphone`, `phone`, `mobile`
- **Date** : détecté par `date`, `année`, `naissance`
- **Entier** : détecté par `âge`, `montant`, `nombre`, `satisfaction`
- Etc.

### 2. Traduction automatique
Dictionnaire de plus de **100 termes** français → anglais spécifiques au domaine :
- Géographie : zone → area, région → region
- Finance : crédit → credit, épargne → savings
- Personnel : âge → age, sexe → gender
- Etc.

### 3. Génération de codes normalisés
Transformation automatique en codes snake_case :
- `Revenu mensuel principal` → `REVENU_MENSUEL_PRINCIPAL`
- `Satisfaction qualité service` → `SATISFACTION_QUALITE_SERVICE`

### 4. Simplification des noms
Création de noms courts et lisibles :
- `Satisfaction vis-à-vis de la qualité générale des produits` → `Satisfaction`
- `Revenu mensuel de l'activité principale` → `Revenu mensuel`

## Personnalisation

Voir le fichier [DOCUMENTATION.md](DOCUMENTATION.md) pour :
- Ajouter de nouveaux termes au dictionnaire de traduction
- Modifier les règles de détection de type
- Ajouter de nouveaux types de données
- Personnaliser les règles de simplification

## Exemple complet

### Fichier source (esf_2025_applatit.txt)
```
Identifiant	Âge	Sexe	Zone	Revenu mensuel de l'activité principale	...
```

### Fichier généré (esf_2025_colonnes_mapping.txt)
```
IDENTIFIANT	SSTR	Identifiant	Identifier	Identifiant	Identifier
AGE	INTE	Âge	Age	Âge	Age
SEXE	SSTR	Sexe	Gender	Sexe	Gender
ZONE	SSTR	Zone	Area	Zone	Area
REVENU_MENSUEL_PRINCIPAL	INTE	Revenu mensuel	Monthly Income	Revenu mensuel de l'activité principale	Monthly income main activity
```

## Utilisation dans un pipeline de données

Le fichier de mapping généré peut être utilisé pour :

1. **Import de données** : Définir le schéma de la base de données
2. **ETL** : Mapper les colonnes sources vers les colonnes cibles
3. **Documentation** : Référence pour les analystes de données
4. **Génération de code** : Créer automatiquement des classes/entités
5. **API** : Définir les noms de champs standardisés

## Structure du projet ESF 2025

Ce générateur fait partie du projet d'analyse de l'Enquête Services Financiers 2025 pour la Côte d'Ivoire, mené par **I.S.P. (Ivoire Services et Protections)**.

### Objectifs de l'enquête
- Mesurer l'accès aux services financiers
- Évaluer la satisfaction des usagers
- Identifier les obstacles à l'inclusion financière
- Analyser l'utilisation du mobile money
- Comprendre les besoins en formation financière

### Domaines couverts
- Informations démographiques
- Accès aux services bancaires
- Utilisation du mobile money
- Crédit et épargne
- Assurance
- Satisfaction et qualité de service
- Littératie financière
- Inclusion financière

## Auteur

**I.S.P. - Ivoire Services et Protections**
- Site web : [www.isp-groupe.ci](http://www.isp-groupe.ci)
- Email : info@isp-groupe.ci
- Téléphone : 01 03 45 41 19 / 07 05 94 73 66
- Adresse : Abidjan Bingerville, Côte d'Ivoire

Spécialisé en :
- Ingénierie du feu
- Électricité et fluides
- Automatisme et sécurité
- Études et analyses de données

## Licence

© 2025 Ivoire Services et Protections (I.S.P.)
Tous droits réservés.

## Support

Pour toute question, suggestion ou problème :
1. Consultez la [DOCUMENTATION.md](DOCUMENTATION.md)
2. Contactez-nous par email : info@isp-groupe.ci
3. Appelez : 01 03 45 41 19 / 07 05 94 73 66

---

**Version** : 1.0  
**Date** : Octobre 2025  
**Statut** : Production
