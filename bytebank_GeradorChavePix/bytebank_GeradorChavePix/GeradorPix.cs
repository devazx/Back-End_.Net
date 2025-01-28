using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_GeradorChavePix
{
    /// <summary>
    /// Classe qe gera chaves pix usando o formado guid.
    /// </summary>
    public static class GeradorPix
    {
        /// <summary>
        /// metodo que retorna uma chave pix
        /// </summary>
        /// <returns>returna uma chave pix no formato string.</returns>
        public static string GetChavePix()
        {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// metodo que retorna uma lista aleatoria de chaves pix
        /// </summary>
        /// <param name="numeroChaves">quantidade de chaves a serem geradas.</param>
        /// <returns>uma lista de strings de chaves pix.</returns>
        public static List<string> GetChavesPix(int numeroChaves)
        {
            if (numeroChaves <= 0)
            { 
                return null;
            }
            else
            {
                var chaves = new List<string>();
                for (int i = 0; i < numeroChaves; i++)
                {
                    chaves.Add(Guid.NewGuid().ToString());
                }

                return chaves;
            }
        }
    }
}
