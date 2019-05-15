using System;
using System.Collections.Generic;
using System.Linq;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Base;
using Mondial.DotNet.Library.Repositories.Interfaces;

namespace Mondial.DotNet.Library.Repositories.InMemory
{
    public class InMemoryTeamRepository :
        BaseInMemoryRepository<Team>,
        ITeamRepository
    {      
        public override List<Team> SampleData =>
            new List<Team>()
            {
                /*new Team(1, "Olympique lyonnais", "https://cdn.sofifa.org/teams/4/light/66.png", "67 Rue Sully, 69150 Décines-Charpieu", 45.76482861073421, 4.976699352264403),
                new Team(2, "EA Guigamp", "https://cdn.sofifa.org/teams/4/light/62.png", "1 Rue Joseph le Brix, Saint-Brieuc, Bretagne", 48.5082, -2.74734),
                new Team(3, "Arsenal WFC", "https://cdn.sofifa.org/teams/4/light/1.png", "nan", 0, 0),
                new Team(4, "Montpellier HSC", "https://cdn.sofifa.org/teams/4/light/70.png", "Stade Jules Rimet, 34160 Sussargues ", 4.00899, 43.69855),
                new Team(5, "Paris Saint-Germain", "https://cdn.sofifa.org/teams/4/light/73.png", "Parc des Princes, 24 Rue du Commandant Guilbaud, 75016 Paris", 48.8413634, 2.2530693),
                new Team(6, "Atlético de Madrid", "https://cdn.sofifa.org/teams/4/light/240.png", "Campos de Fútbol Cerro del Espino, Avenida del Príncipe de Asturias, 28221 Majadahonda", 40.45831138789836, -3.8601279258728),
                new Team(7, "Paris FC", "https://cdn.sofifa.org/teams/4/light/111817.png", "2 Rue Gutenberg, 91070 Bondoufle", 48.619236282568636, 2.391870617866516),
                new Team(8, "Dijon FCO", "https://cdn.sofifa.org/teams/4/light/110569.png", "Place Gaston Gérard, Dijon", 47.323, 5.065339999999992),
                new Team(9, "FC Fleury 91", "https://fr.wikipedia.org/wiki/Football_Club_Fleury_91_C%C5%93ur_d%27Essonne#/media/File:Logo_Football_Club_Fleury_91_C%C5%93ur_d%27Essonne.png", "Stade Auguste Gentelet, Rue des Chaqueux, 91700 Fleury-Mérogis", 48.633759436686546, 2.36356258392334),
                new Team(10, "Girondins de Bordeaux", "https://cdn.sofifa.org/teams/4/light/59.png", "Rue Ferdinand de Lesseps, 33110 Le Bouscat", 44.8718, -0.616823999999951),
                new Team(11, "AS Saint-Etienne", "https://cdn.sofifa.org/teams/4/light/1819.png", "14 e Rue Paul et Pierre Guichard, Saint-Étienne", 45.458999999999996, 4.388140000000021),
                new Team(12, "FC Barcelone", "https://cdn.sofifa.org/teams/4/light/241.png", "Sant Joan Despí, Catalunya", 41.3668, 2.0570299999999406),
                new Team(13, "VfL Wolfsbourg", "https://cdn.sofifa.org/teams/4/light/175.png", "AOK Stadion, Allerpark, 38448 Wolfsburg", 52.4345833, 10.8075),
                new Team(14, "US Compiègne CO", "https://fr.wikipedia.org/wiki/Union_sportive_Compi%C3%A8gne_Club_Oise#/media/File:USCCO.gif", "14 Rue Albert Robida, 60200 Compiègne", 49.42335502641003, 2.8433561325073238),
                new Team(15, "Saint-Memmie Olympique", "https://fr.wikipedia.org/wiki/Saint-Memmie_Olympique#/media/File:Logo_Saint-Memmie_Olympique.jpg", "Rue des Fontaines, Saint-Memmie, Grand-Est", 48.9549, 4.391110000000026),
                new Team(16, "Olympique de Marseille", "https://cdn.sofifa.org/teams/4/light/219.png", "94 Rue Jules Isaac, Marseille 9e Arrondissement, Provence-Alpes-Côte d'Azur", 43.2514, 5.40115000000003),
                new Team(17, "FC Rouen", "https://fr.wikipedia.org/wiki/Football_Club_de_Rouen_1899#/media/File:Logo_FC_Rouen_2009.svg", "2 Rue Porte de Diane, Le Petit-Quevilly, Normandie", 49.4269, 1.0511699999999564),
                new Team(18, "Toulouse FC", "https://cdn.sofifa.org/teams/4/light/1809.png", "112 Chemin des Côtes de Pech David, 31400 Toulouse", 43.562248151413506, 1.4481568336486816),
                new Team(19, "CNFE Clairefontaine", "nan", "Centre national de formation et d'entraînement de Clairefontaine, Chemin des Bruyères, 78120 Clairefontaine-en-Yvelines", 48.616158085279075, 1.9221246242523196),
                new Team(20, "FF Issy", "https://fr.wikipedia.org/wiki/Football_f%C3%A9minin_Issy-les-Moulineaux#/media/File:Logo_issy.jpg", "5 Avenue Jean Bouin, Issy-les-Moulineaux, Île-de-France", 48.8253, 2.2649099999999858),
                new Team(21, "FCF Hénin-Beaumont", "https://fr.wikipedia.org/wiki/Football_Club_f%C3%A9minin_H%C3%A9nin-Beaumont#/media/File:FCF_H%C3%A9nin-Beaumont.gif", "Boulevard du Président Salvador Allende, Hénin-Beaumont", 50.4196, 2.934979999999996) */
            };
    }
}