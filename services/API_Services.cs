﻿using Microsoft.Extensions.Hosting;
using System.Net.Http.Json;
using System.Text.Json;
using webAPIMiniReddit.Model;
using static System.Net.Mime.MediaTypeNames;

namespace webAPIMiniReddit.Services
{
    public class Api_Service
    {
        private readonly DataContext _dc;
        private readonly HttpClient http;
        private readonly IConfiguration configuration;
        private readonly string baseAPI = "";

        public Api_Service(DataContext dc)
        {
            _dc = dc;
        }

        //Hent tråde
        public async Task<Traad[]> hentTraade()
        {
            return _dc.Traade.ToArray();
        }

        //Opret tråde
        public async Task<Traad> opretTraad(int id, string brugerTraad, string titel, string beskrivelse)
        {
            _dc.Traade.Add(new Traad()
            {
                id = id,
                brugerTraad = brugerTraad,
                titel = titel,
                beskrivelse = beskrivelse,
                date = DateTime.Now,
            });
            _dc.SaveChanges();
            return (await _dc.Traade.FindAsync(id))!;
        }


        //Opret kommentar
        public async Task<Kommentar> opretKommentar(string text, int idTraad, string brugerKommentar)
        {
            Traad traad = _dc.Traade.FirstOrDefault (t  => t.id == idTraad);
            Kommentar kommentar = new Kommentar
            {
                brugerKommentar = brugerKommentar,
                text = text,
                dato = DateTime.Now
            };
            traad.Kommentarer.Add(kommentar);
            _dc.SaveChanges();
            return kommentar;
        }


        //Hent kommentar
        public async Task<Kommentar[]> hentKommentarer(int idTraad)
        {
            Traad traad = _dc.Traade.FirstOrDefault(t => t.id == idTraad);
            return traad.Kommentarer.ToArray();
        }

        public void SeedData()
        {

            Traad traad = _dc.Traade.FirstOrDefault()!;
            if (traad == null)
            {
                traad = new Traad { titel = "Yo", beskrivelse = "hfiefjo" };
                _dc.Traade.Add(traad);
                _dc.Traade.Add(new Traad { titel = "Satoshi", beskrivelse = "hfiefhoei" });
                _dc.Traade.Add(new Traad { titel = "Wassup", beskrivelse = "jopfjp" });

                traad.Kommentarer = _dc.Traade.Kommentarer.FirstOrDefault()!;
                if (traad.Kommentarer == null)
                {
                    _dc.Traade.Kommentarer.Add(new Traad.Kommentar { text = "Bro, who is Satoshi", brugerKommentar = "Nakamigo" });
                    _dc.Traade.Kommentarer.Add(new Kommentar { text = "What is Bitcoin?", brugerKommentar = "WakawakaEH-EH"  });
                    _dc.Traade.Kommentarer.Add(new Kommentar { text = "Do you think Satoshi is Elon?", brugerKommentar = "SHAMINAMINA-EH-EH" });
                }
            }

            
            _dc.SaveChanges();
        

        }
    }
}