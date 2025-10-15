# Guide de Référence Rapide - ESF 2025

## Exemples de Mapping

Ce document présente des exemples concrets de mapping générés par le système pour différentes catégories de colonnes.

## Informations Démographiques

| CODE | TYPE | NAME_FR | NAME_EN | LABEL_FR | LABEL_EN |
|------|------|---------|---------|----------|----------|
| AGE | INTE | Âge | Age | Âge | Age |
| GENDER | SSTR | Sexe | Gender | Sexe | Gender |

## Géographie

| CODE | TYPE | NAME_FR | NAME_EN | LABEL_FR | LABEL_EN |
|------|------|---------|---------|----------|----------|
| AREA | SSTR | Zone | Area | Zone | Area |
| REGION | SSTR | Région | Region | Région | Region |
| DISTRICT | SSTR | District | District | District | District |
| DEPARTMENT | SSTR | Département | Department | Département | Department |
| MUNICIPALITY | SSTR | Commune | Municipality | Commune | Municipality |
| NEIGHBORHOOD | SSTR | Quartier | Neighborhood | Quartier | Neighborhood |

## Revenus et Activités

| CODE | TYPE | NAME_FR | NAME_EN | LABEL_FR | LABEL_EN |
|------|------|---------|---------|----------|----------|
| INCOME_MENSUEL_TOTAL | INTE | Revenu mensuel total | Income mensuel total | Revenu mensuel total | Income mensuel total |
| OCCUPATION | SSTR | Profession | Occupation | Profession | Occupation |

## Services Bancaires

| CODE | TYPE | NAME_FR | NAME_EN | LABEL_FR | LABEL_EN |
|------|------|---------|---------|----------|----------|
| POSSESSION_BANK_ACCOUNT | SSTR | Possession compte bancaire | Possession bank Account | Possession compte bancaire | Possession bank_account |
| TYPE_BANK_ACCOUNT | SSTR | Type de compte bancaire | Type bank Account | Type de compte bancaire | Type bank_account |

## Satisfaction

| CODE | TYPE | NAME_FR | NAME_EN | LABEL_FR | LABEL_EN |
|------|------|---------|---------|----------|----------|
| SATISFACTION_QUALITY_SERVICE_ACCUEIL | INTE | Satisfaction qualité service accueil | Satisfaction quality service accueil | Satisfaction qualité service accueil | Satisfaction quality service accueil |
| SATISFACTION_QUALITY_SERVICE_CONSEIL | INTE | Satisfaction qualité service conseil | Satisfaction quality service conseil | Satisfaction qualité service conseil | Satisfaction quality service conseil |

## Mobile Money

| CODE | TYPE | NAME_FR | NAME_EN | LABEL_FR | LABEL_EN |
|------|------|---------|---------|----------|----------|
| UTILISATION_MOBILE_MONEY | SSTR | Utilisation mobile money | Utilisation mobile Money | Utilisation mobile money | Utilisation mobile_money |
| OPERATEUR_MOBILE_MONEY | SSTR | Opérateur mobile money | Operateur mobile Money | Opérateur mobile money | Operateur mobile_money |
| TYPE_TRANSACTION_MOBILE_MONEY | SSTR | Type transaction mobile money | Type transaction mobile Money | Type transaction mobile money | Type transaction mobile_money |

## Crédit et Épargne

| CODE | TYPE | NAME_FR | NAME_EN | LABEL_FR | LABEL_EN |
|------|------|---------|---------|----------|----------|
| POSSESSION_CREDIT | SSTR | Possession crédit | Possession credit | Possession crédit | Possession credit |
| TYPE_CREDIT | SSTR | Type crédit | Type credit | Type crédit | Type credit |
| AMOUNT_CREDIT | INTE | Montant crédit | Amount credit | Montant crédit | Amount credit |
| POSSESSION_SAVINGS | SSTR | Possession épargne | Possession savings | Possession épargne | Possession savings |
| TYPE_BANK_ACCOUNT_SAVINGS | SSTR | Type compte épargne | Type bank Account savings | Type compte épargne | Type bank_account savings |

## Assurance

| CODE | TYPE | NAME_FR | NAME_EN | LABEL_FR | LABEL_EN |
|------|------|---------|---------|----------|----------|
| POSSESSION_INSURANCE | SSTR | Possession assurance | Possession insurance | Possession assurance | Possession insurance |
| TYPE_INSURANCE | SSTR | Type assurance | Type insurance | Type assurance | Type insurance |

## Contact et Communication

| CODE | TYPE | NAME_FR | NAME_EN | LABEL_FR | LABEL_EN |
|------|------|---------|---------|----------|----------|
| EMAIL | EMAL | Email | Email | Email | Email |
| PHONE_PRINCIPAL | TELP | Téléphone principal | Phone principal | Téléphone principal | Phone principal |
| PHONE_SECONDARY | TELP | Téléphone secondaire | Phone secondary | Téléphone secondaire | Phone secondary |

## Dates et Heures

| CODE | TYPE | NAME_FR | NAME_EN | LABEL_FR | LABEL_EN |
|------|------|---------|---------|----------|----------|
| DATE_SURVEY | DATE | Date enquête | Date Survey | Date enquête | Date survey |
| TIME_START_SURVEY | DATI | Heure début enquête | Time start survey | Heure début enquête | Time start survey |
| TIME_END_SURVEY | DATI | Heure fin enquête | Time end survey | Heure fin enquête | Time end survey |

## Nombres Décimaux

| CODE | TYPE | NAME_FR | NAME_EN | LABEL_FR | LABEL_EN |
|------|------|---------|---------|----------|----------|
| RATE_INTEREST_CREDIT | DECI | Taux intérêt crédit | Rate interest credit | Taux intérêt crédit | Rate interest credit |

## Texte Long

| CODE | TYPE | NAME_FR | NAME_EN | LABEL_FR | LABEL_EN |
|------|------|---------|---------|----------|----------|
| OBSERVATIONS | LSTR | Observations | Observations | Observations | Observations |
| COMMENTS_ADDITIONNELS | LSTR | Commentaires additionnels | Comments additionnels | Commentaires additionnels | Comments additionnels |

## Statistiques Globales

- **Total de colonnes mappées** : 118
- **Types SSTR** : Majoritaires (textes courts comme noms, catégories)
- **Types INTE** : Montants, âges, effectifs, scores de satisfaction
- **Types DATE** : 1 (Date enquête)
- **Types DATI** : 2 (Heures de début et fin)
- **Types EMAL** : 1 (Email)
- **Types TELP** : 2 (Téléphones principal et secondaire)
- **Types DECI** : Quelques taux d'intérêt et pourcentages
- **Types LSTR** : Commentaires et observations

## Règles de Nommage Appliquées

### 1. Codes (CODE)
- Format : SNAKE_CASE en majuscules
- Basé sur la traduction anglaise
- Suppression des articles et prépositions
- Exemples :
  - `Satisfaction vis-à-vis de la qualité` → `SATISFACTION_QUALITY`
  - `Revenu mensuel principal` → `INCOME_MENSUEL_PRINCIPAL`

### 2. Noms Simplifiés (NAME_FR, NAME_EN)
- Suppression des détails après virgule
- Suppression des expressions de relation
- Capitalisation appropriée
- Exemples :
  - `Satisfaction vis-à-vis de la qualité générale des produits` → `Satisfaction`
  - `Revenu mensuel de l'activité principale` → `Revenu mensuel`

### 3. Labels (LABEL_FR, LABEL_EN)
- Conservation du texte original pour LABEL_FR
- Traduction terme à terme pour LABEL_EN
- Préservation de la structure complète

## Utilisation Pratique

### Import dans Excel/CSV
```python
import pandas as pd
df = pd.read_csv('esf_2025_colonnes_mapping.txt', sep='\t', header=None,
                 names=['CODE', 'TYPE', 'NAME_FR', 'NAME_EN', 'LABEL_FR', 'LABEL_EN'])
```

### Génération de Schéma SQL
```sql
-- Exemple basé sur le mapping
CREATE TABLE esf_2025 (
    AGE INT,
    GENDER VARCHAR(150),
    AREA VARCHAR(150),
    EMAIL VARCHAR(255),
    PHONE_PRINCIPAL VARCHAR(20),
    DATE_SURVEY DATE,
    TIME_START_SURVEY DATETIME,
    OBSERVATIONS TEXT,
    -- ... autres colonnes
);
```

### Import dans Power BI / Tableau
Le fichier peut être utilisé comme référence pour renommer automatiquement les colonnes lors de l'import des données.

## Notes Importantes

1. **Cohérence des types** : Les types sont détectés automatiquement mais peuvent nécessiter une vérification manuelle selon le contexte spécifique.

2. **Traductions** : Les traductions sont basées sur un dictionnaire de plus de 100 termes. Des ajustements manuels peuvent être nécessaires pour des termes très spécialisés.

3. **Codes uniques** : Chaque CODE doit être unique. En cas de doublons, ajouter un suffixe numérique ou contextuel.

4. **Longueur des champs** : 
   - SSTR : Maximum 150 caractères
   - LSTR : Plus de 150 caractères
   - Ajuster selon les besoins de la base de données cible

## Version et Maintenance

- **Version** : 1.0
- **Date** : Octobre 2025
- **Contact** : info@isp-groupe.ci
- **Dernière mise à jour** : 2025-10-15
