using System;
using System.Collections.Generic;
using System.Linq;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Base;
using Mondial.DotNet.Library.Repositories.Interfaces;

namespace Mondial.DotNet.Library.Repositories.InMemory
{
    public class InMemoryPlayerRepository :
        BaseInMemoryRepository<Player>,
        IPlayerRepository
    {      
        public override List<Player> SampleData =>
            new List<Player>()
            {
                /*new Player(1, "Sarah", "Bouhaddi", new DateTime(1986, 10, 17), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403151943_bouhaddi_copie.png"),
                new Player(2, "Solène", "Durand", new DateTime(1994, 11, 20), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152236_durand_copie.png.png"),
                new Player(3, "Pauline", "Peyraud-Magnin", new DateTime(1992, 3, 17), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403153008_peyraud_magnin_copie.png"),
                new Player(4, "Julie", "Debever", new DateTime(1988, 4, 18), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152137_debever_copie.png.png"),
                new Player(5, "Sakina", "Karchaoui", new DateTime(1996, 1, 26), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152543_karchaoui_copie.png.png"),
                new Player(6, "Amel", "Majri", new DateTime(1993, 1, 25), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152738_majri_copie.png"),
                new Player(7, "Griedge", "Mbock", new DateTime(1995, 2, 26), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152829_mbock_copie.png"),
                new Player(8, "Eve", "Périsset", new DateTime(1994, 12, 24), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152931_perisset_copie.png"),
                new Player(9, "Wendie", "Renard", new DateTime(1990, 4, 20), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403153108_renard_copie.png"),
                new Player(10, "Marion", "Torrent", new DateTime(1992, 4, 17), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403153240_torrent_copie.png.png"),
                new Player(11, "Aïssatou", "Tounkara", new DateTime(1995, 3, 16), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403153327_tounkara_copie.png"),
                new Player(12, "Charlotte", "Bilbault", new DateTime(1990, 6, 5), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403151905_bilbault_copie.png"),
                new Player(13, "Elise", "Bussaglia", new DateTime(1985, 9, 24), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152021_bussaglia_copie.png"),
                new Player(14, "Maéva", "Clemaron", new DateTime(1992, 11, 10), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F5000%2F180406150945_clemaron.png"),
                new Player(15, "Grace", "Geyoro", new DateTime(1997, 7, 2), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152343_geyoro_copie.png.png"),
                new Player(16, "Amandine", "Henry", new DateTime(1989, 9, 28), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152512_henry_copie.png"),
                new Player(17, "Gaëtane", "Thiney", new DateTime(1985, 10, 28), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403153143_thiney_copie.png"),
                new Player(18, "Viviane", "Asseyi", new DateTime(1993, 11, 20), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403151832_asseyi_copie.png.png"),
                new Player(19, "Delphine", "Cascarino", new DateTime(1997, 2, 5), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152108_cascarino_copie.png.png"),
                new Player(20, "Kadidiatou", "Diani", new DateTime(1994, 4, 1), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152208_diani_copie.png.png"),
                new Player(21, "Valérie", "Gauvin", new DateTime(1996, 6, 1), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152308_gauvin_copie.png"),
                new Player(22, "Emelyne", "Laurent", new DateTime(1998, 11, 4), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152626_laurent_copie.png.png"),
                new Player(23, "Eugénie", "Le Sommer", new DateTime(1989, 5, 18), "https://www.fff.fr/%2Fcommon%2Fbib_img%2Fimages%2F550000%2F6500%2F190403152659_le_sommer_copie.png")*/
            };
    }
}