# ESF 2025 - Index des Fichiers

## 📋 Guide de Navigation

Ce répertoire contient tous les fichiers du projet ESF 2025 Column Mapping Generator.

---

## 🎯 FICHIERS PRINCIPAUX

### 1. Fichier de Mapping (LIVRABLE PRINCIPAL)
**📄 `esf_2025_colonnes_mapping.txt`** (15 KB)
- **Description** : Fichier de mapping complet des 118 colonnes ESF 2025
- **Format** : TSV (Tab-Separated Values)
- **Encodage** : UTF-8
- **Utilisation** : Import dans bases de données, ETL, analyses
- ✅ **PRÊT À L'EMPLOI**

### 2. Programme Générateur
**💻 `ColumnMappingGenerator.cs`** (15 KB, 396 lignes)
- **Description** : Programme C# pour générer automatiquement le mapping
- **Langage** : C# (.NET 8.0+)
- **Fonctionnalités** :
  - Détection automatique de 8 types de données
  - Traduction français-anglais (100+ termes)
  - Génération de codes normalisés
  - Simplification des noms
- ✅ **TESTÉ ET FONCTIONNEL**

### 3. Fichier Source
**📊 `esf_2025_applatit.txt`** (2.9 KB)
- **Description** : En-têtes de colonnes de l'enquête ESF 2025
- **Contenu** : 118 colonnes représentatives
- **Format** : TSV (première ligne = en-têtes)
- ✅ **EXEMPLE COMPLET**

---

## 📚 DOCUMENTATION

### Pour Débuter
**📖 `README.md`** (6.7 KB)
- Vue d'ensemble du projet
- Installation et compilation
- Guide d'utilisation
- Exemples pratiques
- **👉 COMMENCER ICI**

### Documentation Technique
**📘 `DOCUMENTATION.md`** (12 KB)
- Règles de nommage détaillées
- Types de données disponibles
- Règles de détection automatique
- Dictionnaire de traduction complet
- Personnalisation et maintenance
- **👉 POUR DÉVELOPPEURS**

### Guide de Référence
**📗 `GUIDE_REFERENCE.md`** (8 KB)
- Exemples concrets par catégorie
- Statistiques du mapping
- Applications pratiques (SQL, Excel, Power BI)
- Notes importantes
- **👉 POUR UTILISATEURS**

### Résumé Exécutif
**📕 `RESUME_EXECUTIF.md`** (7.1 KB)
- Vue d'ensemble complète
- Tous les livrables
- Statistiques globales
- Validation et résultats
- **👉 POUR MANAGERS**

---

## 🔧 OUTILS ET SCRIPTS

### Validation
**✅ `test_validation.sh`** (2 KB)
- Script de validation du fichier de mapping
- Vérifications automatiques :
  - Nombre de colonnes
  - Distribution des types
  - Format correct
  - Colonnes clés
- **Exécution** : `./test_validation.sh`

---

## 📁 RÉPERTOIRES

### MappingGenerator/
Projet .NET compilé
- `MappingGenerator.csproj` : Fichier de projet .NET
- `Program.cs` : Code source (copie de ColumnMappingGenerator.cs)
- `bin/` : Binaires compilés (exclu du git)
- `obj/` : Fichiers objets (exclu du git)

---

## 🚀 DÉMARRAGE RAPIDE

### 1. Consulter le Mapping
```bash
# Voir le fichier de mapping généré
cat esf_2025_colonnes_mapping.txt | head -10
```

### 2. Exécuter le Générateur
```bash
# Compiler le projet
cd MappingGenerator
dotnet build -c Release

# Générer le mapping
cd ..
dotnet MappingGenerator/bin/Release/net8.0/MappingGenerator.dll
```

### 3. Valider les Résultats
```bash
# Exécuter la validation
./test_validation.sh
```

---

## 📊 STATISTIQUES

- **Total de fichiers** : 10 fichiers principaux
- **Lignes de code C#** : 396 lignes
- **Colonnes mappées** : 118
- **Documentation** : ~34 KB (4 fichiers markdown)
- **Taille totale** : ~48 KB (hors binaires)

---

## 🎓 PARCOURS D'APPRENTISSAGE

### Niveau Débutant
1. Lire `README.md`
2. Consulter `esf_2025_colonnes_mapping.txt`
3. Lire `RESUME_EXECUTIF.md`

### Niveau Intermédiaire
1. Lire `GUIDE_REFERENCE.md`
2. Exécuter `test_validation.sh`
3. Étudier les exemples de mapping

### Niveau Avancé
1. Lire `DOCUMENTATION.md`
2. Étudier `ColumnMappingGenerator.cs`
3. Personnaliser le dictionnaire de traduction
4. Modifier les règles de détection

---

## 🔍 RECHERCHE RAPIDE

### Par Type de Besoin

**Je veux...**

- **Utiliser le mapping** → `esf_2025_colonnes_mapping.txt`
- **Comprendre le projet** → `README.md`
- **Voir des exemples** → `GUIDE_REFERENCE.md`
- **Personnaliser le générateur** → `DOCUMENTATION.md`
- **Vérifier la qualité** → `./test_validation.sh`
- **Vue d'ensemble** → `RESUME_EXECUTIF.md`
- **Modifier le code** → `ColumnMappingGenerator.cs`

### Par Rôle

**Je suis...**

- **Analyste de données** → `GUIDE_REFERENCE.md` + `esf_2025_colonnes_mapping.txt`
- **Développeur** → `DOCUMENTATION.md` + `ColumnMappingGenerator.cs`
- **Chef de projet** → `RESUME_EXECUTIF.md`
- **Utilisateur final** → `README.md` + `GUIDE_REFERENCE.md`

---

## 📞 SUPPORT

**Ivoire Services et Protections (I.S.P.)**
- 📧 Email : info@isp-groupe.ci
- 📞 Téléphone : 01 03 45 41 19 / 07 05 94 73 66
- 🌐 Web : www.isp-groupe.ci
- 📍 Adresse : Abidjan Bingerville, Côte d'Ivoire

---

## 📄 LICENCE

© 2025 Ivoire Services et Protections (I.S.P.)
Tous droits réservés.

---

## 🔄 VERSION

- **Version actuelle** : 1.0
- **Date de création** : Octobre 2025
- **Dernière mise à jour** : 2025-10-15
- **Statut** : Production

---

**✅ Tous les livrables sont complets et validés**
