using System;
using System.Collections.Generic;
using System.Linq;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Interfaces;

namespace Mondial.DotNet.Library.Context
{
    public class SeedData
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPlayerRepository  _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IContractRepository _contractRepository;
        public SeedData(ApplicationDbContext dbContext, IPlayerRepository playerRepository, ITeamRepository teamRepository, IContractRepository contractRepository)
        {
            _dbContext = dbContext;
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _contractRepository = contractRepository;
        }

        public void DropCreateDatabase()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        public void AddPlayers()
        {
            // Ne rien faire s'il y a déjà des villes
            if(_dbContext.PlayerCollection.Any()) return;
            var players = new List<Player>
            {
                new Player("Sarah", "Bouhaddi", new DateTime(1986, 10, 17), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403151943_bouhaddi_copie.png"),
                new Player("Solène", "Durand", new DateTime(1994, 11, 20), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152236_durand_copie.png.png"),
                new Player("Pauline", "Peyraud-Magnin", new DateTime(1992, 3, 17), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403153008_peyraud_magnin_copie.png"),
                new Player("Julie", "Debever", new DateTime(1988, 4, 18), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152137_debever_copie.png.png"),
                new Player("Sakina", "Karchaoui", new DateTime(1996, 1, 26), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152543_karchaoui_copie.png.png"),
                new Player("Amel", "Majri", new DateTime(1993, 1, 25), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152738_majri_copie.png"),
                new Player("Griedge", "Mbock", new DateTime(1995, 2, 26), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152829_mbock_copie.png"),
                new Player("Eve", "Périsset", new DateTime(1994, 12, 24), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152931_perisset_copie.png"),
                new Player("Wendie", "Renard", new DateTime(1990, 4, 20), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403153108_renard_copie.png"),
                new Player("Marion", "Torrent", new DateTime(1992, 4, 17), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403153240_torrent_copie.png.png"),
                new Player("Aïssatou", "Tounkara", new DateTime(1995, 3, 16), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403153327_tounkara_copie.png"),
                new Player("Charlotte", "Bilbault", new DateTime(1990, 6, 5), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403151905_bilbault_copie.png"),
                new Player("Elise", "Bussaglia", new DateTime(1985, 9, 24), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152021_bussaglia_copie.png"),
                new Player("Maéva", "Clemaron", new DateTime(1992, 11, 10), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F5000%2F180406150945_clemaron.png"),
                new Player("Grace", "Geyoro", new DateTime(1997, 7, 2), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152343_geyoro_copie.png.png"),
                new Player("Amandine", "Henry", new DateTime(1989, 9, 28), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152512_henry_copie.png"),
                new Player("Gaëtane", "Thiney", new DateTime(1985, 10, 28), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403153143_thiney_copie.png"),
                new Player("Viviane", "Asseyi", new DateTime(1993, 11, 20), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403151832_asseyi_copie.png.png"),
                new Player("Delphine", "Cascarino", new DateTime(1997, 2, 5), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152108_cascarino_copie.png.png"),
                new Player("Kadidiatou", "Diani", new DateTime(1994, 4, 1), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152208_diani_copie.png.png"),
                new Player("Valérie", "Gauvin", new DateTime(1996, 6, 1), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152308_gauvin_copie.png"),
                new Player("Emelyne", "Laurent", new DateTime(1998, 11, 4), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152626_laurent_copie.png.png"),
                new Player("Eugénie", "Le Sommer", new DateTime(1989, 5, 18), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152659_le_sommer_copie.png")
            };
            players.ForEach(player => _playerRepository.Update(player));
            _playerRepository.SaveChanges();
        }

        public void AddTeams()
        {
            // Ne rien faire si non vide
            if(_dbContext.TeamCollection.Any()) return;
            var teams = new List<Team>
            {
                new Team("Olympique lyonnais", "https://cdn.sofifa.org/teams/4/light/66.png", "67 Rue Sully, 69150 Décines-Charpieu", 45.76482861073421, 4.976699352264403),
                new Team("EA Guigamp", "https://cdn.sofifa.org/teams/4/light/62.png", "1 Rue Joseph le Brix, Saint-Brieuc, Bretagne", 48.5082, -2.74734),
                new Team("Arsenal WFC", "https://cdn.sofifa.org/teams/4/light/1.png", "nan", 0, 0),
                new Team("Montpellier HSC", "https://cdn.sofifa.org/teams/4/light/70.png", "Stade Jules Rimet, 34160 Sussargues ", 4.00899, 43.69855),
                new Team("Paris Saint-Germain", "https://cdn.sofifa.org/teams/4/light/73.png", "Parc des Princes, 24 Rue du Commandant Guilbaud, 75016 Paris", 48.8413634, 2.2530693),
                new Team("Atlético de Madrid", "https://cdn.sofifa.org/teams/4/light/240.png", "Campos de Fútbol Cerro del Espino, Avenida del Príncipe de Asturias, 28221 Majadahonda", 40.45831138789836, -3.8601279258728),
                new Team("Paris FC", "https://cdn.sofifa.org/teams/4/light/111817.png", "2 Rue Gutenberg, 91070 Bondoufle", 48.619236282568636, 2.391870617866516),
                new Team("Dijon FCO", "https://cdn.sofifa.org/teams/4/light/110569.png", "Place Gaston Gérard, Dijon", 47.323, 5.065339999999992),
                new Team("FC Fleury 91", "https://fr.wikipedia.org/wiki/Football_Club_Fleury_91_C%C5%93ur_d%27Essonne#/media/File:Logo_Football_Club_Fleury_91_C%C5%93ur_d%27Essonne.png", "Stade Auguste Gentelet, Rue des Chaqueux, 91700 Fleury-Mérogis", 48.633759436686546, 2.36356258392334),
                new Team("Girondins de Bordeaux", "https://cdn.sofifa.org/teams/4/light/59.png", "Rue Ferdinand de Lesseps, 33110 Le Bouscat", 44.8718, -0.616823999999951),
                new Team("AS Saint-Etienne", "https://cdn.sofifa.org/teams/4/light/1819.png", "14 e Rue Paul et Pierre Guichard, Saint-Étienne", 45.458999999999996, 4.388140000000021),
                new Team("FC Barcelone", "https://cdn.sofifa.org/teams/4/light/241.png", "Sant Joan Despí, Catalunya", 41.3668, 2.0570299999999406),
                new Team("VfL Wolfsbourg", "https://cdn.sofifa.org/teams/4/light/175.png", "AOK Stadion, Allerpark, 38448 Wolfsburg", 52.4345833, 10.8075),
                new Team("US Compiègne CO", "https://fr.wikipedia.org/wiki/Union_sportive_Compi%C3%A8gne_Club_Oise#/media/File:USCCO.gif", "14 Rue Albert Robida, 60200 Compiègne", 49.42335502641003, 2.8433561325073238),
                new Team("Saint-Memmie Olympique", "https://fr.wikipedia.org/wiki/Saint-Memmie_Olympique#/media/File:Logo_Saint-Memmie_Olympique.jpg", "Rue des Fontaines, Saint-Memmie, Grand-Est", 48.9549, 4.391110000000026),
                new Team("Olympique de Marseille", "https://cdn.sofifa.org/teams/4/light/219.png", "94 Rue Jules Isaac, Marseille 9e Arrondissement, Provence-Alpes-Côte d'Azur", 43.2514, 5.40115000000003),
                new Team("FC Rouen", "https://fr.wikipedia.org/wiki/Football_Club_de_Rouen_1899#/media/File:Logo_FC_Rouen_2009.svg", "2 Rue Porte de Diane, Le Petit-Quevilly, Normandie", 49.4269, 1.0511699999999564),
                new Team("Toulouse FC", "https://cdn.sofifa.org/teams/4/light/1809.png", "112 Chemin des Côtes de Pech David, 31400 Toulouse", 43.562248151413506, 1.4481568336486816),
                new Team("CNFE Clairefontaine", "nan", "Centre national de formation et d'entraînement de Clairefontaine, Chemin des Bruyères, 78120 Clairefontaine-en-Yvelines", 48.616158085279075, 1.9221246242523196),
                new Team("FF Issy", "https://fr.wikipedia.org/wiki/Football_f%C3%A9minin_Issy-les-Moulineaux#/media/File:Logo_issy.jpg", "5 Avenue Jean Bouin, Issy-les-Moulineaux, Île-de-France", 48.8253, 2.2649099999999858),
                new Team("FCF Hénin-Beaumont", "https://fr.wikipedia.org/wiki/Football_Club_f%C3%A9minin_H%C3%A9nin-Beaumont#/media/File:FCF_H%C3%A9nin-Beaumont.gif", "Boulevard du Président Salvador Allende, Hénin-Beaumont", 50.4196, 2.934979999999996)
            };
            teams.ForEach(team => _teamRepository.Update(team));
            _teamRepository.SaveChanges();
        }

        public void AddContracts()
        {
            // Ne rien faire si non vide
            if(_dbContext.ContractCollection.Any()) return;
            var contracts = new List<Contract>
            {
                new Contract(_playerRepository.Single("Sarah BOUHADDI"), _teamRepository.Single("CNFE Clairefontaine"), 2003, 2005),
                new Contract(_playerRepository.Single("Sarah BOUHADDI"), _teamRepository.Single("Toulouse FC"), 2005, 2006),
                new Contract(_playerRepository.Single("Sarah BOUHADDI"), _teamRepository.Single("Dijon FCO"), 2006, 2009),
                new Contract(_playerRepository.Single("Sarah BOUHADDI"), _teamRepository.Single("Olympique lyonnais"), 2009, null),
                new Contract(_playerRepository.Single("Solène DURAND"), _teamRepository.Single("Montpellier HSC"), 2011, 2017),
                new Contract(_playerRepository.Single("Solène DURAND"), _teamRepository.Single("EA Guigamp"), 2017, null),
                new Contract(_playerRepository.Single("Pauline PEYRAUD-MAGNIN"), _teamRepository.Single("Olympique lyonnais"), 2008, 2014),
                new Contract(_playerRepository.Single("Pauline PEYRAUD-MAGNIN"), _teamRepository.Single("FF Issy"), 2014, 2015),
                new Contract(_playerRepository.Single("Pauline PEYRAUD-MAGNIN"), _teamRepository.Single("AS Saint-Etienne"), 2015, 2016),
                new Contract(_playerRepository.Single("Pauline PEYRAUD-MAGNIN"), _teamRepository.Single("Olympique de Marseille"), 2016, 2017),
                new Contract(_playerRepository.Single("Pauline PEYRAUD-MAGNIN"), _teamRepository.Single("Olympique lyonnais"), 2017, 2018),
                new Contract(_playerRepository.Single("Pauline PEYRAUD-MAGNIN"), _teamRepository.Single("Arsenal WFC"), 2018, null),
                new Contract(_playerRepository.Single("Julie DEBEVER"), _teamRepository.Single("FCF Hénin-Beaumont"), 2002, 2011),
                new Contract(_playerRepository.Single("Julie DEBEVER"), _teamRepository.Single("Paris FC"), 2011, 2012),
                new Contract(_playerRepository.Single("Julie DEBEVER"), _teamRepository.Single("AS Saint-Etienne"), 2012, 2015),
                new Contract(_playerRepository.Single("Julie DEBEVER"), _teamRepository.Single("EA Guigamp"), 2015, null),
                new Contract(_playerRepository.Single("Sakina KARCHAOUI"), _teamRepository.Single("Montpellier HSC"), 2012, null),
                new Contract(_playerRepository.Single("Amel MAJRI"), _teamRepository.Single("Olympique lyonnais"), 2010, null),
                new Contract(_playerRepository.Single("Griedge MBOCK"), _teamRepository.Single("EA Guigamp"), 2010, 2015),
                new Contract(_playerRepository.Single("Griedge MBOCK"), _teamRepository.Single("Olympique lyonnais"), 2015, null),
                new Contract(_playerRepository.Single("Eve PÉRISSET"), _teamRepository.Single("Olympique lyonnais"), 2012, 2016),
                new Contract(_playerRepository.Single("Eve PÉRISSET"), _teamRepository.Single("Paris Saint-Germain"), 2012, null),
                new Contract(_playerRepository.Single("Wendie RENARD"), _teamRepository.Single("Olympique lyonnais"), 2006, null),
                new Contract(_playerRepository.Single("Marion TORRENT"), _teamRepository.Single("Montpellier HSC"), 2007, null),
                new Contract(_playerRepository.Single("Aïssatou TOUNKARA"), _teamRepository.Single("FF Issy"), 2008, 2017),
                new Contract(_playerRepository.Single("Aïssatou TOUNKARA"), _teamRepository.Single("Paris FC"), 2010, 2018),
                new Contract(_playerRepository.Single("Aïssatou TOUNKARA"), _teamRepository.Single("Atlético de Madrid"), 2018, null),
                new Contract(_playerRepository.Single("Charlotte BILBAULT"), _teamRepository.Single("Paris FC"), 2015, null),
                new Contract(_playerRepository.Single("Elise BUSSAGLIA"), _teamRepository.Single("CNFE Clairefontaine"), 2003, 2004),
                new Contract(_playerRepository.Single("Elise BUSSAGLIA"), _teamRepository.Single("Paris FC"), 2004, 2007),
                new Contract(_playerRepository.Single("Elise BUSSAGLIA"), _teamRepository.Single("Montpellier HSC"), 2007, 2009),
                new Contract(_playerRepository.Single("Elise BUSSAGLIA"), _teamRepository.Single("Paris Saint-Germain"), 2009, 2012),
                new Contract(_playerRepository.Single("Elise BUSSAGLIA"), _teamRepository.Single("Olympique lyonnais"), 2012, 2015),
                new Contract(_playerRepository.Single("Elise BUSSAGLIA"), _teamRepository.Single("VfL Wolfsbourg"), 2015, 2017),
                new Contract(_playerRepository.Single("Elise BUSSAGLIA"), _teamRepository.Single("FC Barcelone"), 2017, 2018),
                new Contract(_playerRepository.Single("Elise BUSSAGLIA"), _teamRepository.Single("Dijon FCO"), 2018, null),
                new Contract(_playerRepository.Single("Maéva CLEMARON"), _teamRepository.Single("Olympique lyonnais"), 2007, 2008),
                new Contract(_playerRepository.Single("Maéva CLEMARON"), _teamRepository.Single("AS Saint-Etienne"), 2008, 2017),
                new Contract(_playerRepository.Single("Maéva CLEMARON"), _teamRepository.Single("FC Fleury 91"), 2017, null),
                new Contract(_playerRepository.Single("Grace GEYORO"), _teamRepository.Single("Paris Saint-Germain"), 2014, null),
                new Contract(_playerRepository.Single("Amandine HENRY"), _teamRepository.Single("FCF Hénin-Beaumont"), 2004, 2005),
                new Contract(_playerRepository.Single("Amandine HENRY"), _teamRepository.Single("CNFE Clairefontaine"), 2005, 2007),
                new Contract(_playerRepository.Single("Amandine HENRY"), _teamRepository.Single("Olympique lyonnais"), 2007, 2017),
                new Contract(_playerRepository.Single("Amandine HENRY"), _teamRepository.Single("Paris Saint-Germain"), 2017, 2018),
                new Contract(_playerRepository.Single("Amandine HENRY"), _teamRepository.Single("Olympique lyonnais"), 2018, null),
                new Contract(_playerRepository.Single("Gaëtane THINEY"), _teamRepository.Single("Saint-Memmie Olympique"), 2000, 2006),
                new Contract(_playerRepository.Single("Gaëtane THINEY"), _teamRepository.Single("US Compiègne CO"), 2006, 2008),
                new Contract(_playerRepository.Single("Gaëtane THINEY"), _teamRepository.Single("Paris FC"), 2008, null),
                new Contract(_playerRepository.Single("Viviane ASSEYI"), _teamRepository.Single("FC Rouen"), 2008, 2009),
                new Contract(_playerRepository.Single("Viviane ASSEYI"), _teamRepository.Single("Montpellier HSC"), 2009, 2016),
                new Contract(_playerRepository.Single("Viviane ASSEYI"), _teamRepository.Single("Olympique de Marseille"), 2016, 2018),
                new Contract(_playerRepository.Single("Viviane ASSEYI"), _teamRepository.Single("Girondins de Bordeaux"), 2018, null),
                new Contract(_playerRepository.Single("Delphine CASCARINO"), _teamRepository.Single("Olympique lyonnais"), 2015, null),
                new Contract(_playerRepository.Single("Kadidiatou DIANI"), _teamRepository.Single("Paris FC"), 2010, 2017),
                new Contract(_playerRepository.Single("Kadidiatou DIANI"), _teamRepository.Single("Paris Saint-Germain"), 2017, null),
                new Contract(_playerRepository.Single("Valérie GAUVIN"), _teamRepository.Single("Toulouse FC"), 2011, 2014),
                new Contract(_playerRepository.Single("Valérie GAUVIN"), _teamRepository.Single("Montpellier HSC"), 2014, null),
                new Contract(_playerRepository.Single("Emelyne LAURENT"), _teamRepository.Single("Montpellier HSC"), 2013, 2016),
                new Contract(_playerRepository.Single("Emelyne LAURENT"), _teamRepository.Single("Girondins de Bordeaux"), 2016, 2017),
                new Contract(_playerRepository.Single("Emelyne LAURENT"), _teamRepository.Single("Olympique lyonnais"), 2017, 2019),
                new Contract(_playerRepository.Single("Emelyne LAURENT"), _teamRepository.Single("EA Guigamp"), 2019, null),
                new Contract(_playerRepository.Single("Eugénie LE SOMMER"), _teamRepository.Single("EA Guigamp"), 2007, 2010),
                new Contract(_playerRepository.Single("Eugénie LE SOMMER"), _teamRepository.Single("Olympique lyonnais"), 2010, null)
            };
            contracts.ForEach(contract => _contractRepository.Update(contract));
            _contractRepository.SaveChanges();
        }
    }
}