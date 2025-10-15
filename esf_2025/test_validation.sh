#!/bin/bash

echo "=== Validation du fichier de mapping ESF 2025 ==="
echo ""

FILE="esf_2025_colonnes_mapping.txt"

# Vérifier l'existence du fichier
if [ ! -f "$FILE" ]; then
    echo "❌ ERREUR: Le fichier $FILE n'existe pas"
    exit 1
fi

# Compter le nombre de lignes
LINES=$(wc -l < "$FILE")
echo "✓ Nombre total de colonnes mappées: $LINES"

# Vérifier qu'on a au moins 100 colonnes
if [ $LINES -lt 100 ]; then
    echo "❌ ERREUR: Nombre insuffisant de colonnes (attendu: >= 100)"
    exit 1
fi

# Vérifier la présence de tous les types de données
echo ""
echo "Distribution des types de données:"
for TYPE in SSTR LSTR EMAL TELP INTE DECI DATE DATI; do
    COUNT=$(cut -f2 "$FILE" | grep -c "^$TYPE$")
    echo "  - $TYPE: $COUNT"
done

# Vérifier des colonnes spécifiques importantes
echo ""
echo "Vérification de colonnes clés:"

# AGE doit être de type INTE
if grep -q "^AGE\sINTE" "$FILE"; then
    echo "  ✓ AGE: type INTE correct"
else
    echo "  ❌ AGE: type incorrect"
fi

# EMAIL doit être de type EMAL
if grep -q "^EMAIL\sEMAL" "$FILE"; then
    echo "  ✓ EMAIL: type EMAL correct"
else
    echo "  ❌ EMAIL: type incorrect"
fi

# Les téléphones doivent être de type TELP
PHONE_COUNT=$(grep -c "PHONE.*TELP" "$FILE")
if [ $PHONE_COUNT -ge 1 ]; then
    echo "  ✓ Téléphones: $PHONE_COUNT trouvés avec type TELP"
else
    echo "  ❌ Téléphones: type incorrect"
fi

# DATE_SURVEY doit être de type DATE
if grep -q "DATE_SURVEY\sDATE" "$FILE" || grep -q "DATE.*SURVEY.*DATE" "$FILE"; then
    echo "  ✓ Date enquête: type DATE trouvé"
else
    echo "  ⚠ Date enquête: non trouvée ou type différent"
fi

# Vérifier le format (6 colonnes par ligne)
echo ""
echo "Vérification du format:"
INVALID_LINES=$(awk -F'\t' 'NF != 6' "$FILE" | wc -l)
if [ $INVALID_LINES -eq 0 ]; then
    echo "  ✓ Toutes les lignes ont 6 colonnes (format correct)"
else
    echo "  ❌ $INVALID_LINES lignes ont un format incorrect"
fi

echo ""
echo "=== Validation terminée ==="
