# Jeu du Pendu - C# (.NET 10.0)

Ce projet est une implémentation classique du **Jeu du Pendu** développée en C# sous forme d'application console. Il a été conçu pour illustrer une architecture logicielle simple et la Programmation Orientée Objet (POO).

## 🚀 Fonctionnalités

*   **Menu Interactif :** Interface console avec dessins en ASCII Art.
*   **Difficulté Ajustable :** Le joueur choisit le pourcentage de lettres révélées au début du jeu.
*   **Système de Vies :** 10 vies au départ. Perte de 1 vie pour une lettre fausse, 2 vies pour un mot faux.
*   **Mots Aléatoires :** Mots chargés dynamiquement depuis un fichier local (`words.txt`).

## 🧠 Concepts Abordés

*   **Architecture POO :** Séparation en classes distinctes (`Display`, `GameLoop`, etc.) pour bien diviser les responsabilités.
*   **Collections et LINQ :** Manipulation de listes (`List<T>`) pour trier, mélanger et filtrer des données.
*   **Entrées/Sorties (I/O) :** Lecture de fichiers externes et interactions avancées avec la console.

## 📂 Architecture du Projet

*   `Main.cs` : Point d'entrée de l'application.
*   `/lib/Display.cs` : Gère uniquement l'affichage (menus, pendu, couleurs).
*   `/lib/GameLoop.cs` : Gère le déroulement d'une partie (score, victoires, défaites).
*   `/lib/GameRule.cs` : Contient les règles du jeu (choix du mot, vérification des lettres).
*   `/lib/PlayerInputs.cs` : Sécurise et centralise les saisies de l'utilisateur.

## 🛠️ Exécution

1.  Assurez-vous d'avoir le SDK **.NET 10.0** installé.
2.  Depuis un terminal, à la racine du projet (là où se trouvent `words.txt` et `states.txt`), lancez :
    ```bash
    dotnet run
    ```

## 💡 Pistes d'Amélioration

*   Améliorer la gestion des erreurs lors de la saisie au clavier (`int.TryParse`).
*   Rendre le système plus robuste face aux chemins de fichiers (paths dynamiques).
*   Ajouter des tests unitaires pour valider les règles du jeu.
