﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Fase {
        public int IdFase { get; set; }
        public string Dificuldade { get; set; }
        public int PortasParaVencer { get; set; }

        public Fase(string dificuldade) {
            Dificuldade = dificuldade;  
                                        
            switch (dificuldade.ToLower()) {
                case "facil":
                    PortasParaVencer = 5;
                    break;
                case "medio":
                    PortasParaVencer = 7;
                    break;
                case "dificil":
                    PortasParaVencer = 10;
                    break;
                case "extremo":
                    PortasParaVencer = 12;
                    break;
                default:
                    PortasParaVencer = 5; 
                    break;
            }
        }
    }
}
