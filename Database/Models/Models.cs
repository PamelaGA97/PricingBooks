using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Models
    {
        public int Id { get; set; } //identificador de precio ya que el precio normal del producto puede variar por año o temporada

        public string IdProduct { get; set; } //identificador del producto que registra el grupo B es de tipo String por los requerimientos que les pidieron para la presente práctica

        public float PercentOffer { get; set; } //oferta por porcentaje del producto los valores admitidos son del 0 % (caso en el que no existe una oferta) hasta el 100% caso en el que el producto ya es gratis

        public string Type { get; set; } //Tipo de oferta dependiendo de la temporada en la que se realiza (navidad, verano, día de la madre...)

        public int Year { get; set; } //Año de publicación del precio 
    }
}
