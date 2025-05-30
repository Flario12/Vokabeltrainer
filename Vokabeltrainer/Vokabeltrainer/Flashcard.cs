﻿using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokabeltrainer
{
    public class Flashcard
    {
        private string? frontText { get; set; }
        private string? backText { get; set; }
        private DateTime lastReviewed {  get; set; }
        private int timesReviewed { get; set; }

        public Flashcard()
        {

        }
        
        public Flashcard(string fronttext) : this()
        {
            this.frontText = fronttext;
        }

        public Flashcard(string fronttext, string backtext) : this() // hier wird ein existierendes Flashcard objekt verwendet.
        {
            this.backText = backtext;
            this.frontText = fronttext;
        }

        public string Showfront()
        {
            return frontText;
        }

        public string Showback()
        {
            return backText;
        }

        public void Review()
        {

        }

        public void ResetProgress()
        {

        }

        public string Serialize()
        {
            return $"{frontText};{backText}";
        }

        public override string ToString()
        {
            return $"{frontText};{backText}";
        }

        public static Flashcard Deserialize(string data)
        {
            string[] datasplit = data.Split(";");
            if (datasplit.Length < 2)
            {
                Log.Error("invalide split length ...");
                throw new Exception("Dieser Inhalt ist invalide");
            } 
            else
            {
                return new Flashcard(datasplit[0], datasplit[1]);
                // Flashcard(fronttext, backtext)
            }
        }
    }
}
